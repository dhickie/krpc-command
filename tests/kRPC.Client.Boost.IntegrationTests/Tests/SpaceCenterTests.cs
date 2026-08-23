using System.Collections;
using System.Net;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;
using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Configuration;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.IntegrationTests.AutoFixture;
using kRPC.Client.Boost.IntegrationTests.Exceptions;
using kRPC.Client.Boost.IntegrationTests.Extensions;
using kRPC.Client.Boost.IntegrationTests.Server;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Services.SpaceCenter;
using MathNet.Spatial.Euclidean;
using NSubstitute;
using MethodInvoker = AutoFixture.Kernel.MethodInvoker;
using Type = System.Type;

namespace kRPC.Client.Boost.IntegrationTests.Tests;

[Collection("IntegrationTests")]
public class SpaceCenterTests
{
    private readonly Fixture _fixture;
    private readonly IConnectionMultiplexer _fakeConnection;
    
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
        _fakeConnection = Substitute.For<IConnectionMultiplexer>();
    }

    [Fact]
    public void SynchronousGetRpcs_ReturnCorrectValues()
    {
        var serviceType = typeof(SpaceCenter);
        var clientName = _fixture.Create<string>();
        using var connection = Connect(clientName);
        ServiceObjectCustomisation.ServiceObjectBuilder.SetConnection(connection); // So that test data has access to the connection
        var rpcs = new Dictionary<Type, ProcedureInfo[]>();
        GetRpcMethods(serviceType, true, false, rpcs);

        TestRpcs(clientName, rpcs);
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
        Dictionary<Type, ProcedureInfo[]> rpcs)
    {
        foreach (var serviceType in rpcs.Keys)
        {
            var typeRpcs = rpcs[serviceType];
            foreach (var rpc in typeRpcs)
            {
                TestRpc(clientName, serviceType, rpc);
            }
        }
    }

    private void TestRpc(string clientName, Type instanceType, ProcedureInfo rpc)
    {
        // Arrange
        var arguments = rpc.ArgumentTypes
            .Select(x => _fixture.Create(x))
            .ToArray();
        var returnValue = _fixture.Create(rpc.ReturnType);
        var instance = _fixture.Create(instanceType);
        
        _server.ConfigureResponse(clientName, rpc.Service, rpc.Procedure, () => returnValue);
        
        // Act
        var result = rpc.Method.Invoke(instance, arguments);
        
        // Assert
        var equal = ValuesAreEqual(rpc.ReturnType, returnValue, result);
        Assert.True(ValuesAreEqual(rpc.ReturnType, returnValue, result));
        _server.Received(clientName, callInfo =>
        {
            if (callInfo.Service != rpc.Service)
                return false;

            if (callInfo.Procedure != rpc.Procedure)
                return false;

            // RPCs on remote objects will send the remote object as the first argument
            if (instanceType.IsAssignableTo(typeof(RemoteObject)))
            {
                if (callInfo.Arguments!.Length != arguments.Length + 1)
                    return false;

                if (!ValuesAreEqual(instanceType, instance, callInfo.Arguments[0]))
                    return false;
                
                for (var i = 0; i < arguments.Length; i++)
                {
                    var argType = arguments[i]?.GetType() ?? typeof(object);
                    if (!ValuesAreEqual(argType, arguments[i], callInfo.Arguments[i+1]))
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
                    if (!ValuesAreEqual(argType, arguments[i], callInfo.Arguments[i]))
                        return false;
                }
            }

            return true;
        });
    }

    private bool ValuesAreEqual(Type type, object? expectedValue, object? actualValue)
    {
        if (expectedValue == null || actualValue == null)
            return expectedValue == actualValue;
        
        // We have to convert some types due to client side type conversions
        var convertedActualValue = ConvertTypesIfRequired(type, actualValue);

        if (!type.IsInstanceOfType(expectedValue) || !type.IsInstanceOfType(convertedActualValue))
            return false;
        
        if (type.IsSubclassOf(typeof(RemoteObject)))
            return ((RemoteObject)expectedValue).Id == ((RemoteObject)convertedActualValue).Id;
        
        if (Codec.IsACollectionType(type))
            return CollectionValuesAreEqual(type, expectedValue, convertedActualValue);
        
        if (type.IsEnum 
            || type == typeof(string) 
            || type == typeof(float) 
            || type == typeof(double) 
            || type == typeof(int) 
            || type == typeof(long) 
            || type == typeof(uint) 
            || type == typeof(ulong) 
            || type == typeof(bool) 
            || type == typeof(byte[]) 
            || type == typeof(Vector3D) 
            || type == typeof(Quaternion))
            return Equals(expectedValue, convertedActualValue);
        
        throw new ArgumentException($"Unable to assert value of type {type.Name}");
    }

    // The client converts some types, which is unknown to the server. If that is the case, we have to convert
    // the actualValue into that type so that equality can be tested correctly
    private object ConvertTypesIfRequired(Type type, object actualValue)
    {
        var actualType = actualValue.GetType();
        
        if (type == typeof(Vector3D) && Codec.IsAGenericType(actualType, typeof(Tuple<,,>)))
        {
            // Easiest to just encode and decode
            var encoded = Codec.Encode(actualValue);
            return Codec.Decode(encoded, typeof(Vector3D), _fakeConnection)
                ?? throw new ArgumentException($"Unable to assert value of type {actualType} to Vector3D");
        }
        
        if (type == typeof(Quaternion) && Codec.IsAGenericType(actualType, typeof(Tuple<,,,>)))
        {
            var encoded = Codec.Encode(actualValue);
            return Codec.Decode(encoded, typeof(Quaternion), _fakeConnection)
                ?? throw new ArgumentException($"Unable to assert value of type {actualType} to Quaternion");
        }
        
        return actualValue;
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

        var serviceTypeMethods = typeMethods.Select(m =>
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
        });

        // Useful in testing - get specific RPCs to make diagnosing errors easier
        (string, string)[] targetRpcs =
        [
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
}

public class ProcedureInfo
{
    public required MethodInfo Method { get; init; }
    public required string Service { get; init; }
    public required string Procedure { get; init; }
    public required Type[] ArgumentTypes { get; init; }
    public required Type ReturnType { get; init; }
}