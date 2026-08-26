using System.Collections;
using System.Net;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;
using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Configuration;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.IntegrationTests.AutoFixture;
using kRPC.Client.Boost.IntegrationTests.Extensions;
using kRPC.Client.Boost.IntegrationTests.Server;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Services.SpaceCenter;
using MathNet.Spatial.Euclidean;
using MethodInvoker = AutoFixture.Kernel.MethodInvoker;
using Type = System.Type;

namespace kRPC.Client.Boost.IntegrationTests.Tests;

[Collection("IntegrationTests")]
public class SpaceCenterTests
{
    private readonly Fixture _fixture;
    private readonly Type _serviceType = typeof(SpaceCenter);
    
    private readonly ConnectionConfig _connectionConfig = new()
    {
        Address = IPAddress.Loopback,
        RpcPort = TestServer.RpcPort,
        StreamPort = TestServer.StreamPort
    };
    
    private readonly TestServer _server;

    public SpaceCenterTests(TestServer server)
    {
        _server = server;
        _fixture = new Fixture();
        _fixture.Customize(new ServiceObjectCustomisation()); // Enables creation of service and remote objects
        _fixture.Customize<Quaternion>(c => c.FromFactory(
            new MethodInvoker(
                new GreedyConstructorQuery()))); // Needed to ensure the right constructor is used
    }

    [Theory]
    [InlineData(RpcType.Get, false)]
    [InlineData(RpcType.Set, false)]
    [InlineData(RpcType.Static, false)]
    [InlineData(RpcType.Get, true)]
    [InlineData(RpcType.Set, true)]
    [InlineData(RpcType.Static, true)]
    public async Task TestService(RpcType rpcType, bool isAsync)
    {
        var clientName = _fixture.Create<string>();
        using var connection = Connect(clientName);
        ServiceObjectCustomisation.ServiceObjectBuilder.SetConnection(connection); // So that test data has access to the connection
        var rpcs = new Dictionary<Type, ProcedureInfo[]>();
        GetRpcMethods(_serviceType, rpcType, isAsync, rpcs);

        await TestRpcsAsync(clientName, rpcs);
    }

    private IConnectionMultiplexer Connect(string clientName)
    {
        var multiplexerConfig = new MultiplexerConfig
        {
            ClientName = clientName,
            NumRpcConnections = 1
        };
        var config = new ClientConfig
        {
            Multiplexer = multiplexerConfig,
            Connection = _connectionConfig,
        };
        return (IConnectionMultiplexer)ConnectionBuilder.NewConnection(config);
    }

    private async Task TestRpcsAsync(string clientName,
        Dictionary<Type, ProcedureInfo[]> rpcs)
    {
        foreach (var serviceType in rpcs.Keys)
        {
            var typeRpcs = rpcs[serviceType];
            foreach (var rpc in typeRpcs)
            {
                await TestRpcAsync(clientName, serviceType, rpc);
            }
        }
    }

    private async Task TestRpcAsync(string clientName, Type instanceType, ProcedureInfo rpc)
    {
        // Arrange
        var arguments = rpc.ArgumentTypes
            .Select(x => _fixture.Create(x))
            .ToArray();
        var instance = _fixture.Create(instanceType);

        var returnValue = new object();
        if (rpc.ReturnType != typeof(void))
        {
            returnValue = _fixture.Create(rpc.ReturnType);
        
            _server.ConfigureResponse(clientName, rpc.Service, rpc.Procedure, () =>
            {
                var converter = new ClientObjectConverter(rpc.AngleType, rpc.AngleDataType);
                return converter.ConvertClientObject(returnValue);
            });
        }
        
        // Act
        object? result;
        if (rpc.IsAsync)
        {
            var task = (Task)rpc.Method.Invoke(instance, arguments)!;
            await task;
            var taskType = task.GetType();
            var taskResult = taskType.GetProperty("Result");

            if (taskResult == null && taskType != typeof(Task))
                throw new InvalidOperationException("Failed to get result property of returning Task RPC result");

            result = taskResult?.GetValue(task);
        }
        else
        {
            result = rpc.Method.Invoke(instance, arguments);
        }
        
        // Assert
        if (rpc.ReturnType != typeof(void))
        {
            Assert.True(ValuesAreEqual(rpc.ReturnType, returnValue, result, rpc));
        }
        
        _server.Received(clientName, callInfo =>
        {
            if (callInfo.Service != rpc.Service)
                return false;

            if (callInfo.Procedure != rpc.Procedure)
                return false;

            // RPCs on remote objects will send the remote object as the first argument
            if (instanceType.IsAssignableTo(typeof(RemoteObject)) && rpc.RpcType != RpcType.Static)
            {
                if (callInfo.Arguments!.Length != arguments.Length + 1)
                    return false;

                if (!ValuesAreEqual(instanceType, instance, callInfo.Arguments[0], rpc))
                    return false;
                
                for (var i = 0; i < arguments.Length; i++)
                {
                    var argType = arguments[i]?.GetType() ?? typeof(object);
                    if (!ValuesAreEqual(argType, arguments[i], callInfo.Arguments[i+1], rpc))
                        return false;
                }
            }
            else
            {
                if (callInfo.Arguments!.Length != arguments.Length)
                    return false;

                for (var i = 0; i < arguments.Length; i++)
                {
                    var argType = arguments[i]?.GetType() ?? typeof(object);
                    if (!ValuesAreEqual(argType, arguments[i], callInfo.Arguments[i], rpc))
                        return false;
                }
            }

            return true;
        });
    }

    private bool ValuesAreEqual(Type type, object? expectedValue, object? actualValue, ProcedureInfo rpc)
    {
        if (expectedValue == null || actualValue == null)
            return expectedValue == actualValue;
        
        // Some client side types are unknown to the server, so convert the expected and actual values into types
        // the server would understand. This ensures the assertion works both for checking the return value from
        // the RPC and the RPC parameters received by the server.
        var converter = new ClientObjectConverter(rpc.AngleType, rpc.AngleDataType);
        var convertedExpectedValue = converter.ConvertClientObject(expectedValue);
        var convertedActualValue = converter.ConvertClientObject(actualValue);
        var convertedType = converter.ConvertClientType(type);

        if (!convertedType.IsInstanceOfType(convertedExpectedValue) || !convertedType.IsInstanceOfType(convertedActualValue))
            return false;
        
        if (convertedType.IsSubclassOf(typeof(RemoteObject)))
            return ((RemoteObject)convertedExpectedValue).Id == ((RemoteObject)convertedActualValue).Id;
        
        if (Codec.IsACollectionType(convertedType))
            return CollectionValuesAreEqual(convertedType, convertedExpectedValue, convertedActualValue, rpc);
        
        if (convertedType.IsEnum 
            || convertedType == typeof(string) 
            || convertedType == typeof(float) 
            || convertedType == typeof(double) 
            || convertedType == typeof(int) 
            || convertedType == typeof(long) 
            || convertedType == typeof(uint) 
            || convertedType == typeof(ulong) 
            || convertedType == typeof(bool) 
            || convertedType == typeof(byte[]))
            return Equals(convertedExpectedValue, convertedActualValue);
        
        throw new ArgumentException($"Unable to assert value of type {type.Name}");
    }

    private bool CollectionValuesAreEqual(Type responseType, object expectedValue, object actualValue, ProcedureInfo rpc)
    {
        if (Codec.IsATupleType(responseType))
            return TupleValuesAreEqual(responseType, expectedValue, actualValue, rpc);
        
        if (Codec.IsAnArrayType(responseType) || Codec.IsAListType(responseType))
            return ArrayOrListValuesAreEqual(responseType, expectedValue, actualValue, rpc);
        
        if (Codec.IsADictionaryType(responseType))
            return DictionaryValuesAreEqual(responseType, expectedValue, actualValue, rpc);
        
        if (Codec.IsASetType(responseType))
            return SetValuesAreEqual(responseType, expectedValue, actualValue, rpc);
        
        throw new ArgumentException($"Unable to assert value of unknown collection type: {responseType.Name}");
    }

    private bool TupleValuesAreEqual(Type responseType, object expectedValue, object actualValue, ProcedureInfo rpc)
    {
        var typeArguments = responseType.GenericTypeArguments;
        for (var i = 0; i < typeArguments.Length; i++)
        {
            var fieldInfo = responseType.GetProperty($"Item{i+1}")
                ?? throw new ArgumentException($"Unable to find item field {i} on type {responseType.Name}");
            var expectedFieldValue = fieldInfo.GetValue(expectedValue);
            var actualFieldValue = fieldInfo.GetValue(actualValue);

            if (!ValuesAreEqual(typeArguments[i], expectedFieldValue, actualFieldValue, rpc))
                return false;
        }

        return true;
    }

    private bool ArrayOrListValuesAreEqual(Type responseType, object expectedValue, object actualValue, ProcedureInfo rpc)
    {
        var listInterface = responseType.GetGenericTypeDefinition() == typeof(IList<>) 
            ? responseType
            : responseType.GetInterface("IList`1")
                ?? throw new ArgumentException($"Unable to find IList interface on array type {responseType.Name}");
        var valueType = listInterface.GetGenericArguments().Single();
        
        var expectedArrayValue = (IList)expectedValue;
        var actualArrayValue = (IList)actualValue;

        if (expectedArrayValue.Count != actualArrayValue.Count)
            return false;

        for (var i = 0; i < expectedArrayValue.Count; i++)
        {
            var expectedElementValue = expectedArrayValue[i];
            var actualElementValue = actualArrayValue[i];

            if (!ValuesAreEqual(valueType, expectedElementValue, actualElementValue, rpc))
                return false;
        }

        return true;
    }

    private bool DictionaryValuesAreEqual(Type responseType, object expectedValue, object actualValue, ProcedureInfo rpc)
    {
        var dictionaryInterface = responseType.GetGenericTypeDefinition() == typeof(IDictionary<,>) ?
            responseType :
            responseType.GetInterface("IDictionary`2");
        if (dictionaryInterface == null)
            throw new ArgumentException($"Unable to find dictionary interface for type {responseType.Name}");
        
        var typeArgs = dictionaryInterface.GetGenericArguments();
        var valueType = typeArgs[1];
        
        var expectedDictionary = (IDictionary)expectedValue;
        var actualDictionary = (IDictionary)actualValue;

        if (expectedDictionary.Count != actualDictionary.Count)
            return false;

        return expectedDictionary.Keys
            .Cast<object?>()
            .All(key => 
                key != null 
                && actualDictionary.Contains(key) 
                && ValuesAreEqual(valueType, expectedDictionary[key], actualDictionary[key], rpc));
    }

    private bool SetValuesAreEqual(Type responseType, object expectedValue, object actualValue, ProcedureInfo rpc)
    {
        var setInterface = responseType.GetGenericTypeDefinition() == typeof(ISet<>) 
            ? responseType
            : responseType.GetInterface("ISet`1")
              ?? throw new ArgumentException($"Unable to find set interface on type {responseType.Name}");
        
        var valueType = setInterface.GetGenericArguments().Single();

        var expectedValues = ((IEnumerable)expectedValue)
            .Cast<object?>()
            .OrderBy(x => x)
            .ToArray();
        var actualValues = ((IEnumerable)actualValue)
            .Cast<object>()
            .OrderBy(x => x)
            .ToArray();

        if (expectedValues.Length != actualValues.Length)
            return false;

        for (var i = 0; i < expectedValues.Length; i++)
        {
            if (!ValuesAreEqual(valueType, expectedValues[i], actualValues[i], rpc))
                return false;
        }

        return true;
    }

    private void GetRpcMethods(Type serviceType, RpcType rpcType, bool isAsync, Dictionary<Type, ProcedureInfo[]> rpcMethods)
    {
        // Get all methods on the provided service type
        var getAtt = typeof(GetRpcAttribute);
        var setAtt = typeof(SetRpcAttribute);
        var staticAtt = typeof(StaticRpcAttribute);
        var allMethods = serviceType
            .GetMethods()
            .Where(m =>
                m.CustomAttributes.Any(
                    a => a.AttributeType == getAtt || a.AttributeType == setAtt || a.AttributeType == staticAtt));

        // Work out how we identify the methods we're actually interested in
        Func<MethodInfo, bool> isAsyncMethodMatcher = isAsync
            ? x => x.ReturnType.IsAssignableTo(typeof(Task))
            : x => !x.ReturnType.IsAssignableTo(typeof(Task));

        bool RpcTypeMethodMatcher(MethodInfo x)
        {
            if (rpcType == RpcType.Get) 
                return x.CustomAttributes.Any(a => a.AttributeType == getAtt);
            if (rpcType == RpcType.Set) 
                return x.CustomAttributes.Any(a => a.AttributeType == setAtt);
            if (rpcType == RpcType.Static) 
                return x.CustomAttributes.Any(a => a.AttributeType == staticAtt);

            throw new InvalidOperationException($"Unsupported RpcType: {rpcType}");
        }

        // Add the current type to the dictionary with an empty collection to prevent any recursive calls doing the same work
        rpcMethods.Add(serviceType, []);
        var typeMethods = new List<MethodInfo>();
        foreach (var method in allMethods)
        {
            if (isAsyncMethodMatcher(method) && RpcTypeMethodMatcher(method))
                typeMethods.Add(method);

            // We want to look at RPCs on the return type even if this method is one we're not interested in - the return
            // type might have methods we _are_ interested in
            var returnType = GetReturnType(method);
            if (returnType.IsAssignableTo(typeof(ServiceObject)) && !rpcMethods.ContainsKey(returnType))
                GetRpcMethods(returnType, rpcType, isAsync, rpcMethods);
        }

        var serviceTypeMethods = typeMethods.Select(m =>
        {
            var att = rpcType switch
            {
                RpcType.Get => typeof(GetRpcAttribute),
                RpcType.Set => typeof(SetRpcAttribute),
                RpcType.Static => typeof(StaticRpcAttribute),
                _ => throw new InvalidOperationException($"Unsupported RpcType: {rpcType}")
            };
            var rpcAttribute = m.GetCustomAttribute(att) as RpcAttribute;
            var conversionAttribute = m.GetCustomAttribute<AngleConversion>();
            return new ProcedureInfo
            {
                Method = m,
                Service = rpcAttribute!.Service,
                Procedure = rpcAttribute!.Procedure,
                ArgumentTypes = m.GetParameters().Select(x => x.ParameterType).ToArray(),
                ReturnType = GetReturnType(m),
                IsAsync = isAsync,
                RpcType = rpcType,
                AngleType = conversionAttribute?.AngleType,
                AngleDataType = conversionAttribute?.AngleDataType
            };
        });

        // Useful in testing - get specific RPCs to make diagnosing errors easier
        (string, string)[] targetRpcs =
        [
            //("SpaceCenter", "ClearTarget")
        ];

        if (targetRpcs.Length > 0)
        {
            rpcMethods[serviceType] = serviceTypeMethods
                .Where(x => targetRpcs.Contains((x.Service, x.Procedure)))
                .ToArray();
        }
        else
        {
            rpcMethods[serviceType] = serviceTypeMethods.ToArray();
        }
    }

    private Type GetReturnType(MethodInfo method)
    {
        if (method.ReturnType == typeof(void) 
            || !method.ReturnType.IsAssignableTo(typeof(Task)))
        {
            return method.ReturnType;
        }

        if (method.ReturnType == typeof(Task))
        {
            return typeof(void);
        }

        // If it's an async method we need to get the inner type
        return method.ReturnType.GetGenericArguments().Single();
    }
}

public class ProcedureInfo
{
    public required MethodInfo Method { get; init; }
    public required string Service { get; init; }
    public required string Procedure { get; init; }
    public required Type[] ArgumentTypes { get; init; }
    public required Type ReturnType { get; init; }
    public required bool IsAsync { get; init; }
    public required RpcType RpcType { get; init; }
    public required AngleType? AngleType { get; init; }
    public required Type? AngleDataType { get; init; }
}

public enum RpcType
{
    Get,
    Set,
    Static
}