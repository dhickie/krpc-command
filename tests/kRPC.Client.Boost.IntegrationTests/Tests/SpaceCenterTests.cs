using System.Collections;
using System.Net;
using System.Reflection;
using AutoFixture;
using AutoFixture.Kernel;
using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Configuration;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.IntegrationTests.Exceptions;
using kRPC.Client.Boost.IntegrationTests.Server;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Services.SpaceCenter;
using MathNet.Spatial.Euclidean;

namespace kRPC.Client.Boost.IntegrationTests.Tests;

[Collection("IntegrationTests")]
public class SpaceCenterTests(TestServer server)
{
    private readonly Fixture _fixture = new();
    
    private readonly ConnectionConfig _connectionConfig = new()
    {
        Address = IPAddress.Loopback,
        RpcPort = TestServer.RpcPort,
        StreamPort = TestServer.RpcPort
    };

    [Fact]
    public void SynchronousGetRpcs_FunctionCorrectly()
    {
        var serviceType = typeof(SpaceCenter);
        var clientName = _fixture.Create<string>();
        using var connection = Connect(clientName);
        var rpcMethods = GetRpcMethods(serviceType, true, false);

        TestRpcTree(clientName, connection, serviceType, rpcMethods);
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

    private void TestRpcTree(string clientName,
        IConnectionMultiplexer connection,
        Type initialInstanceType,
        ProcedureInfo[] rpcs)
    {
        foreach (var rpc in rpcs)
        {
            TestRpc(clientName, connection, initialInstanceType, rpc);
            if (rpc.ChildProcedures.Length != 0)
                TestRpcTree(clientName, connection, rpc.ReturnType, rpc.ChildProcedures);
        }
    }

    private void TestRpc(string clientName, IConnectionMultiplexer connection, Type instanceType, ProcedureInfo rpc)
    {
        // Arrange
        var parameters = rpc.ParameterTypes.Select(CreateRandomValue).ToArray();
        var returnValue = CreateRandomValue(rpc.ReturnType);
        var instance = CreateInstance(instanceType, connection);
        
        server.ConfigureResponse(clientName, rpc.Service, rpc.Procedure, () => returnValue);
        
        // Act
        var result = rpc.Method.Invoke(instance, parameters);
        
        // Assert
        AssertResponseValue(rpc.ReturnType, returnValue, result);
    }

    private void AssertResponseValue(Type responseType, object? expectedValue, object? actualValue)
    {
        if (expectedValue == null || actualValue == null)
            Assert.Equal(expectedValue, actualValue);
        else
        {
            Assert.Equal(responseType, expectedValue.GetType());
            Assert.Equal(responseType, actualValue.GetType());
        
            if (responseType.IsSubclassOf(typeof(RemoteObject)))
                Assert.Equal((RemoteObject)expectedValue, (RemoteObject)actualValue);
            else if (responseType.IsEnum)
                Assert.Equal((int)expectedValue, (int)actualValue);
            else if (Codec.IsACollectionType(responseType))
                AssertCollectionValue(responseType, expectedValue, actualValue);
            else if (responseType == typeof(string))
                Assert.Equal((string)expectedValue, (string)actualValue);
            else if (responseType == typeof(float))
                Assert.Equal((float)expectedValue, (float)actualValue);
            else if (responseType == typeof(double))
                Assert.Equal((double)expectedValue, (double)actualValue);
            else if (responseType == typeof(int))
                Assert.Equal((int)expectedValue, (int)actualValue);
            else if (responseType == typeof(long))
                Assert.Equal((long)expectedValue, (long)actualValue);
            else if (responseType == typeof(uint))
                Assert.Equal((uint)expectedValue, (uint)actualValue);
            else if (responseType == typeof(ulong))
                Assert.Equal((ulong)expectedValue, (ulong)actualValue);
            else if (responseType == typeof(bool))
                Assert.Equal((bool)expectedValue, (bool)actualValue);
            else if (responseType == typeof(byte[]))
                Assert.Equal((byte[])expectedValue, (byte[])actualValue);
            else if (responseType == typeof(Vector3D))
                Assert.Equal((Vector3D)expectedValue, (Vector3D)actualValue);
            else if (responseType == typeof(Quaternion))
                Assert.Equal((Quaternion)expectedValue, (Quaternion)actualValue);
            else
                throw new ArgumentException($"Unable to assert value of type {responseType.Name}");
        }
    }

    private void AssertCollectionValue(Type responseType, object expectedValue, object actualValue)
    {
        if (Codec.IsATupleType(responseType))
            AssertTupleValue(responseType, expectedValue, actualValue);
        else if (Codec.IsAnArrayType(responseType) || Codec.IsAListType(responseType))
            AssertArrayOrListValue(responseType, expectedValue, actualValue);
        else if (Codec.IsADictionaryType(responseType))
            AssertDictionaryValue(responseType, expectedValue, actualValue);
        else if (Codec.IsASetType(responseType))
            AssertSetValue(responseType, expectedValue, actualValue);
        else
            throw new ArgumentException($"Unable to assert value of unknown collection type: {responseType.Name}");
    }

    private void AssertTupleValue(Type responseType, object expectedValue, object actualValue)
    {
        var typeArguments = responseType.GenericTypeArguments;
        for (var i = 0; i < typeArguments.Length; i++)
        {
            var fieldInfo = responseType.GetField($"Item{i+1}")
                ?? throw new ArgumentException($"Unable to find item field {i} on type {responseType.Name}");
            var expectedFieldValue = fieldInfo.GetValue(expectedValue);
            var actualFieldValue = fieldInfo.GetValue(actualValue);
            
            AssertResponseValue(typeArguments[i], expectedFieldValue, actualFieldValue);
        }
    }

    private void AssertArrayOrListValue(Type responseType, object expectedValue, object actualValue)
    {
        var listInterface = responseType.GetInterface("IList`1")
            ?? throw new ArgumentException($"Unable to find IList interface on array type {responseType.Name}");
        var valueType = listInterface.GetGenericArguments().Single();
        
        var expectedArrayValue = (IList)expectedValue;
        var actualArrayValue = (IList)actualValue;
        
        Assert.Equal(expectedArrayValue.Count, actualArrayValue.Count);

        for (var i = 0; i < expectedArrayValue.Count; i++)
        {
            var expectedElementValue = expectedArrayValue[i];
            var actualElementValue = actualArrayValue[i];
            
            AssertResponseValue(valueType, expectedElementValue, actualElementValue);
        }
    }

    private void AssertDictionaryValue(Type responseType, object expectedValue, object actualValue)
    {
        var dictionaryInterface = responseType.GetInterface("IDictionary`2")
            ?? throw new ArgumentException($"Unable to find dictionary interface on type {responseType.Name}");
        var typeArgs = dictionaryInterface.GetGenericArguments();
        var valueType = typeArgs[1];
        
        var expectedDictionary = (IDictionary)expectedValue;
        var actualDictionary = (IDictionary)actualValue;
        
        Assert.Equal(expectedDictionary.Count, actualDictionary.Count);

        foreach (var key in expectedDictionary.Keys)
        {
            Assert.NotNull(key);
            Assert.True(actualDictionary.Contains(key));
            AssertResponseValue(valueType, expectedDictionary[key], actualDictionary[key]);
        }
    }

    private void AssertSetValue(Type responseType, object expectedValue, object actualValue)
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
        
        Assert.Equal(expectedValues.Length, actualValues.Length);
        for (var i = 0; i < expectedValues.Length; i++)
            AssertResponseValue(valueType, expectedValues[i], actualValues[i]);
    }

    private object CreateInstance(Type instanceType, IConnectionMultiplexer connection)
    {
        if (!instanceType.IsSubclassOf(typeof(ServiceObject)))
            throw new TestSetupException(
                $"Cannot invoke RPC on {instanceType.Name} - it is not a service object or remote object");

        object? instance;
        if (instanceType.IsSubclassOf(typeof(RemoteObject)))
        {
            var id = _fixture.Create<ulong>();
            instance = Activator.CreateInstance(instanceType, connection, id);
        }
        else
        {
            instance = Activator.CreateInstance(instanceType, connection);
        }
        
        return instance ?? throw new TestSetupException($"Failed to create instance of {instanceType.Name}");
    }

    private object? CreateRandomValue(Type type)
    {
        return new SpecimenContext(_fixture).Resolve(type);
    }

    private ProcedureInfo[] GetRpcMethods(Type serviceType, bool isGet, bool isAsync)
    {
        var attributeType = isGet ? typeof(GetRpcAttribute) : typeof(SetRpcAttribute);
        var allMethods = serviceType
            .GetMethods()
            .Where(x => x.GetCustomAttributes().Any(y => y.GetType() == attributeType));

        Func<MethodInfo, bool> methodMatcher = isAsync 
            ? x => x.ReturnType.IsAssignableTo(typeof(Task))
            : x => !x.ReturnType.IsAssignableTo(typeof(Task));
            
        return allMethods
            .Where(methodMatcher)
            .Select(m =>
            {
                var childProcedures = GetRpcMethods(m.ReturnType, isGet, isAsync);
                var attribute = m.GetCustomAttribute(attributeType) as RpcAttribute;
                return new ProcedureInfo
                {
                    Method = m,
                    Service = attribute!.Service,
                    Procedure = attribute!.Procedure,
                    ParameterTypes = m.GetParameters().Select(x => x.ParameterType).ToArray(),
                    ReturnType = m.ReturnType,
                    ChildProcedures = childProcedures
                };
            })
            .ToArray();
    }
}

public class ProcedureInfo
{
    public required MethodInfo Method { get; init; }
    public required string Service { get; init; }
    public required string Procedure { get; init; }
    public required Type[] ParameterTypes { get; init; }
    public required Type ReturnType { get; init; }
    public required ProcedureInfo[] ChildProcedures { get; init; }
}