using System.Collections.Concurrent;
using System.Text.Json;
using Google.Protobuf;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Connection.Schema;
using kRPC.Client.Boost.IntegrationTests.ProcedureDefinitions;
using NSubstitute;
using ProcedureResult = kRPC.Client.Boost.Connection.Schema.ProcedureResult;
using Type = System.Type;

namespace kRPC.Client.Boost.IntegrationTests.Server;

public class RequestHandler
{
    private readonly Dictionary<string, ServiceDefinition> _services;
    private readonly IConnectionMultiplexer _connection = Substitute.For<IConnectionMultiplexer>();
    private readonly ConcurrentDictionary<string, Func<object?>> _configuredCalls;
    private ConcurrentDictionary<string, ConcurrentBag<CallInfo>> _calls;

    public RequestHandler()
    {
        _services = new Dictionary<string, ServiceDefinition>();
        _configuredCalls = new ConcurrentDictionary<string, Func<object?>>();
        _calls = [];
        
        LoadDefinitions();
    }

    public void ConfigureResponse(string clientId, 
        string service, 
        string procedure,
        Func<object?> response)
    {
        var key = $"{clientId}_{service}_{procedure}";
        _configuredCalls.AddOrUpdate(key, _ => response, (_, _) => response);
    }

    public bool Received(string clientId, Func<CallInfo, bool> predicate)
    {
        var calls = _calls[clientId];
        return calls.Any(predicate);
    }

    public Response Respond(string clientId, Request request)
    {
        var results = new List<ProcedureResult>();
        foreach (var call in request.Calls)
        {
            var result = new ProcedureResult();
            if (!TryProcessCall(clientId, call, out var returnValue, out var errors))
            {
                result.Error = new Error
                {
                    Description = string.Join("\n", errors!)
                };
            }
            else if (returnValue != null)
            {
                result.Value = returnValue;
            }
            
            results.Add(result);
        }

        var response = new Response();
        response.Results.AddRange(results);
        return response;
    }

    private void RecordCall(string clientId, string service, string procedure, object?[]? arguments)
    {
        var calls = _calls.GetOrAdd(clientId, _ => []);
        calls.Add(new CallInfo(service, procedure, arguments));
    }

    private bool TryProcessCall(string clientId, ProcedureCall call, out ByteString? returnValue, out string[]? errors)
    {
        returnValue = null;
        
        // Get the procedure definition
        if (!TryFindDefinition(call, out var def, out var defError))
        {
            errors = [defError!];
            return false;
        }
        
        // Get the arguments for the procedure
        if (!TryGetCallArguments(def!, call, out var args, out var argErrors))
        {
            errors = argErrors;
            return false;
        }

        if (def!.ReturnType != null)
        {
            // Get the return value that's been set up for this call
            _configuredCalls.TryGetValue($"{clientId}_{call.Service}_{call.Procedure}", out var configuredCall);
            var result = configuredCall?.Invoke();
            var resultType = GetArgumentType(def.ReturnType);
            returnValue = Codec.Encode(result, resultType);
        }
        
        RecordCall(clientId, call.Service, call.Procedure, args);
        errors = null;
        return true;
    }

    private bool TryGetCallArguments(ProcedureDefinition def, ProcedureCall call, out object?[]? args, out string[]? errors)
    {
        var errorsList = new List<string>();
        args = null;
        
        // Check the call has the correct number of arguments
        if (call.Arguments.Count != def.Parameters.Length)
        {
            var error = $"Procedure expected {def.Parameters.Length} arguments but received {call.Arguments.Count}";
            errorsList.Add(error);
            
            errors = errorsList.ToArray();
            return false;
        }
        
        // Check the provided parameters are of the correct type
        var orderedArguments = call.Arguments.OrderBy(a => a.Position).ToList();
        var decodedArgs = new object?[orderedArguments.Count];
        for (var i = 0; i < orderedArguments.Count; i++)
        {
            if (TryDecodeArgument(orderedArguments[i].Value, 
                    def.Parameters[i], 
                    out var decodedArg, 
                    out var error))
            {
                decodedArgs[i] = decodedArg;
            }
            else
            {
                errorsList.Add(error!);
            }
        }

        if (errorsList.Count > 0)
        {
            errors = errorsList.ToArray();
            return false;
        }

        args = decodedArgs;
        errors = null;
        return true;
    }

    private bool TryDecodeArgument(ByteString argument, 
        RpcParameter paramDef,
        out object? value, 
        out string? error)
    {
        var type = GetArgumentType(paramDef.Type);
        try
        {
            value = Codec.Decode(argument, type, _connection);

            if (value == null && !paramDef.Nullable)
            {
                error = $"Received null value for non-nullable argument {paramDef.Name}";
                return false;
            }
            
            error = null;
            return true;
        }
        catch (System.Exception e)
        {
            error = e.Message;
            value = null;
            return false;
        }
    }
    
    private void LoadDefinitions()
    {
        var path = Environment.CurrentDirectory;
        path = Path.Combine(path, "ProcedureDefinitions");
        var files = Directory.GetFiles(path, "KRPC.*.json");

        foreach (var file in files)
        {
            var json = File.ReadAllText(file);
            var services = JsonSerializer.Deserialize<Dictionary<string, ServiceDefinition>>(json)
                           ?? throw new InvalidOperationException($"Failed to deserialise definition file: {file}");

            foreach (var service in services.Keys)
            {
                _services.Add(service, services[service]);
            }
        }
    }

    private bool TryFindDefinition(ProcedureCall request, out ProcedureDefinition? def, out string? error)
    {
        if (!_services.TryGetValue(request.Service, out var service))
        {
            error = $"Service '{request.Service}' could not be found";
            def = null;
            return false;
        }

        if (!service.Procedures.TryGetValue(request.Procedure, out var procedure))
        {
            error = $"Procedure '{request.Procedure}' could not be found in service '{request.Service}'";
            def = null;
            return false;
        }

        def = procedure;
        error = null;
        return true;
    }
    
    private Type GetArgumentType(RpcParameterType defType)
    {
        return defType.Code switch
        {
            "STRING" => typeof(string),
            "BOOL" => typeof(bool),
            "DOUBLE" => typeof(double),
            "FLOAT" => typeof(float),
            "SINT32" => typeof(int),
            "UINT32" => typeof(uint),
            "LIST" => GetCollectionArgumentType(defType, "System.Collections.Generic.List", 1),
            "TUPLE" => GetCollectionArgumentType(defType, "System.Tuple", defType.Types.Length),
            "SET" => GetCollectionArgumentType(defType, "System.Collections.Generic.HashSet", 1),
            "DICTIONARY" => GetCollectionArgumentType(defType, "System.Collections.Generic.Dictionary", 2),
            "CLASS" or "ENUMERATION" => GetClassOrEnumerationArgumentType(defType),
            _ => throw new InvalidOperationException($"Unknown argument type code: {defType.Code}")
        };
    }
    
    private Type GetCollectionArgumentType(RpcParameterType defType, string dotnetType, int numTypeArguments)
    {
        var typeString = $"{dotnetType}`{numTypeArguments}";
        var genericType = Type.GetType(typeString);
        if (genericType == null)
            throw new InvalidOperationException($"Unable to find generic collection type for {typeString}");
        
        var typeArguments = defType.Types.Select(GetArgumentType).ToArray();
        return genericType.MakeGenericType(typeArguments);
    }

    private Type GetClassOrEnumerationArgumentType(RpcParameterType defType)
    {
        var typeString = $"kRPC.Client.Boost.Services.{defType.Service}.RemoteObjects.{defType.Name}";
        var allTypes = typeof(IConnectionMultiplexer).Assembly.GetTypes();
        return allTypes.Single(x => x.FullName == typeString);
    }
}