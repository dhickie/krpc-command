using System.Collections;
using System.Net;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;
using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Configuration;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Connection.Schema;
using kRPC.Client.Boost.IntegrationTests.Exceptions;
using kRPC.Client.Boost.IntegrationTests.Server;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Services.SpaceCenter;
using MathNet.Spatial.Euclidean;
using Type = System.Type;

namespace kRPC.Client.Boost.IntegrationTests.Tests;

[Collection("IntegrationTests")]
public class SpaceCenterTests(TestServer server)
{
    private readonly Fixture _fixture = new();
    
    private readonly ConnectionConfig _connectionConfig = new()
    {
        Address = IPAddress.Loopback,
        RpcPort = TestServer.RpcPort,
        StreamPort = TestServer.StreamPort
    };

    [Fact]
    public void SynchronousGetRpcs_ReturnCorrectValues()
    {
        var serviceType = typeof(SpaceCenter);
        var clientName = _fixture.Create<string>();
        using var connection = Connect(clientName);
        var rpcs = new Dictionary<Type, ProcedureInfo[]>();
        GetRpcMethods(serviceType, true, false, rpcs);

        TestRpcs(clientName, connection, rpcs);
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

    private void TestRpcs(string clientName,
        IConnectionMultiplexer connection,
        Dictionary<Type, ProcedureInfo[]> rpcs)
    {
        foreach (var serviceType in rpcs.Keys)
        {
            var typeRpcs = rpcs[serviceType];
            foreach (var rpc in typeRpcs)
            {
                TestRpc(clientName, connection, serviceType, rpc);
            }
        }
    }

    private void TestRpc(string clientName, IConnectionMultiplexer connection, Type instanceType, ProcedureInfo rpc)
    {
        // Arrange
        var arguments = rpc.ArgumentTypes.Select(CreateRandomValue).ToArray();
        var returnValue = CreateRandomValue(rpc.ReturnType);
        var instance = CreateInstance(instanceType, connection);
        
        server.ConfigureResponse(clientName, rpc.Service, rpc.Procedure, () => returnValue);
        
        // Act
        var result = rpc.Method.Invoke(instance, arguments);
        
        // Assert
        Assert.True(ValuesAreEqual(rpc.ReturnType, returnValue, result));
        server.Received(clientName, callInfo =>
        {
            if (callInfo.Service != rpc.Service)
                return false;

            if (callInfo.Procedure != rpc.Procedure)
                return false;

            if (callInfo.Arguments!.Length != arguments.Length)
                return false;

            for (var i = 0; i < arguments.Length; i++)
            {
                var argType = arguments[i]?.GetType() ?? typeof(object);
                if (!ValuesAreEqual(argType, arguments[i], callInfo.Arguments[i]))
                    return false;
            }

            return true;
        });
    }

    private bool ValuesAreEqual(Type responseType, object? expectedValue, object? actualValue)
    {
        if (expectedValue == null || actualValue == null)
            return expectedValue == actualValue;

        if (responseType != expectedValue.GetType() || responseType != actualValue.GetType())
            return false;
        
        if (responseType.IsSubclassOf(typeof(RemoteObject)))
            return ((RemoteObject)expectedValue).Id == ((RemoteObject)actualValue).Id;
        
        if (Codec.IsACollectionType(responseType))
            return CollectionValuesAreEqual(responseType, expectedValue, actualValue);
        
        if (responseType.IsEnum 
            || responseType == typeof(string) 
            || responseType == typeof(float) 
            || responseType == typeof(double) 
            || responseType == typeof(int) 
            || responseType == typeof(long) 
            || responseType == typeof(uint) 
            || responseType == typeof(ulong) 
            || responseType == typeof(bool) 
            || responseType == typeof(byte[]) 
            || responseType == typeof(Vector3D) 
            || responseType == typeof(Quaternion))
            return expectedValue == actualValue;
        
        throw new ArgumentException($"Unable to assert value of type {responseType.Name}");
    }

    private bool CollectionValuesAreEqual(Type responseType, object expectedValue, object actualValue)
    {
        if (Codec.IsATupleType(responseType))
            return TupleValuesAreEqual(responseType, expectedValue, actualValue);
        
        if (Codec.IsAnArrayType(responseType) || Codec.IsAListType(responseType))
            return ArrayOrListValuesAreEqual(responseType, expectedValue, actualValue);
        
        if (Codec.IsADictionaryType(responseType))
            return DictionaryValuesAreEqual(responseType, expectedValue, actualValue);
        
        if (Codec.IsASetType(responseType))
            return SetValuesAreEqual(responseType, expectedValue, actualValue);
        
        throw new ArgumentException($"Unable to assert value of unknown collection type: {responseType.Name}");
    }

    private bool TupleValuesAreEqual(Type responseType, object expectedValue, object actualValue)
    {
        var typeArguments = responseType.GenericTypeArguments;
        for (var i = 0; i < typeArguments.Length; i++)
        {
            var fieldInfo = responseType.GetField($"Item{i+1}")
                ?? throw new ArgumentException($"Unable to find item field {i} on type {responseType.Name}");
            var expectedFieldValue = fieldInfo.GetValue(expectedValue);
            var actualFieldValue = fieldInfo.GetValue(actualValue);

            if (!ValuesAreEqual(typeArguments[i], expectedFieldValue, actualFieldValue))
                return false;
        }

        return true;
    }

    private bool ArrayOrListValuesAreEqual(Type responseType, object expectedValue, object actualValue)
    {
        var listInterface = responseType.GetInterface("IList`1")
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

            if (!ValuesAreEqual(valueType, expectedElementValue, actualElementValue))
                return false;
        }

        return true;
    }

    private bool DictionaryValuesAreEqual(Type responseType, object expectedValue, object actualValue)
    {
        var dictionaryInterface = responseType.GetInterface("IDictionary`2")
            ?? throw new ArgumentException($"Unable to find dictionary interface on type {responseType.Name}");
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
                && ValuesAreEqual(valueType, expectedDictionary[key], actualDictionary[key]));
    }

    private bool SetValuesAreEqual(Type responseType, object expectedValue, object actualValue)
    {
        var setInterface = responseType.GetInterface("ISet`1")
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
            if (!ValuesAreEqual(valueType, expectedValues[i], actualValues[i]))
                return false;
        }

        return true;
    }

    private object CreateInstance(Type instanceType, IConnectionMultiplexer connection)
    {
        if (!instanceType.IsSubclassOf(typeof(ServiceObject)))
            throw new TestSetupException(
                $"Cannot invoke RPC on {instanceType.Name} - it is not a service object or remote object");

        object?[]? args;
        if (instanceType.IsSubclassOf(typeof(RemoteObject)))
        {
            var id = _fixture.Create<ulong>();
            args = [connection, id];
        }
        else
        {
            args = [connection];
        }
        
        var instance = Activator.CreateInstance(
            instanceType,
            BindingFlags.Instance | BindingFlags.NonPublic,
            null,
            args,
            null);
        
        return instance ?? throw new TestSetupException($"Failed to create instance of {instanceType.Name}");
    }

    private object? CreateRandomValue(Type type)
    {
        return new SpecimenContext(_fixture).Resolve(type);
    }

    private void GetRpcMethods(Type serviceType, bool isGet, bool isAsync, Dictionary<Type, ProcedureInfo[]> rpcMethods)
    {
        // Get all methods on the provided service type
        var getAtt = typeof(GetRpcAttribute);
        var setAtt = typeof(SetRpcAttribute);
        var allMethods = serviceType
            .GetMethods()
            .Where(m => 
                m.CustomAttributes.Any(a => a.AttributeType == getAtt || a.AttributeType == setAtt));

        // Work out how we identify the methods we're actually interested in
        Func<MethodInfo, bool> isAsyncMethodMatcher = isAsync 
            ? x => x.ReturnType.IsAssignableTo(typeof(Task))
            : x => !x.ReturnType.IsAssignableTo(typeof(Task));
        Func<MethodInfo, bool> isGetMethodMatcher = isGet
            ? x => x.CustomAttributes.Any(a => a.AttributeType == getAtt)
            : x => x.CustomAttributes.Any(a => a.AttributeType == setAtt);

        // Add the current type to the dictionary with an empty collection to prevent any recursive calls doing the same work
        rpcMethods.Add(serviceType, []);
        var typeMethods = new List<MethodInfo>();
        foreach (var method in allMethods)
        {
            if (isAsyncMethodMatcher(method) && isGetMethodMatcher(method))
                typeMethods.Add(method);
            
            // We want to look at RPCs on the return type even if this method is one we're not interested in - the return
            // type might have methods we _are_ interested in
            if (method.ReturnType.IsAssignableTo(typeof(ServiceObject)) && !rpcMethods.ContainsKey(method.ReturnType))
                GetRpcMethods(method.ReturnType, isGet, isAsync, rpcMethods);
        }

        rpcMethods[serviceType] = typeMethods.Select(m =>
        {
            var att = isGet ? getAtt : setAtt;
            var attribute = m.GetCustomAttribute(att) as RpcAttribute;
            return new ProcedureInfo
            {
                Method = m,
                Service = attribute!.Service,
                Procedure = attribute!.Procedure,
                ArgumentTypes = m.GetParameters().Select(x => x.ParameterType).ToArray(),
                ReturnType = m.ReturnType
            };
        }).ToArray();
    }
}

public class ProcedureInfo
{
    public required MethodInfo Method { get; init; }
    public required string Service { get; init; }
    public required string Procedure { get; init; }
    public required Type[] ArgumentTypes { get; init; }
    public required Type ReturnType { get; init; }
}