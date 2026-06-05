using System.Linq.Expressions;
using System.Reflection;
using AutoFixture;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Connection.Schema;
using kRPC.Client.Boost.Exceptions;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;
using kRPC.Client.Boost.UnitTests.Fakes;
using kRPC.Client.Boost.UnitTests.Helpers;
using MathNet.Spatial.Euclidean;
using Type = System.Type;

namespace kRPC.Client.Boost.UnitTests.Connection;

public class CodecTests
{
    private readonly IConnectionMultiplexer _connection = new FakeConnectionMultiplexer();
    private readonly Fixture _fixture = new Fixture();
    
    [Theory]
    [InlineData(typeof(double), 1.5D, "1.5")]
    [InlineData(typeof(float), 2.5F, "2.5")]
    [InlineData(typeof(int), 1, "1")]
    [InlineData(typeof(long), 2L, "2")]
    [InlineData(typeof(uint), 3U, "3")]
    [InlineData(typeof(ulong), 4U, "4")]
    [InlineData(typeof(string), "hello", "hello")]
    [InlineData(typeof(bool), true, "True")]
    public void ReturnsCorrectValue_WhenWorkingWithPrimitiveTypes(Type type, object value, string expectedValue)
    {
        var byteString = Codec.Encode(value);
        var decodedValue = Codec.Decode(byteString, type, _connection);

        Assert.NotNull(decodedValue);
        Assert.Equal(type, decodedValue.GetType());
        Assert.Equal(expectedValue, decodedValue.ToString());
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithNullRemoteObjects()
    {
        Vessel? value = null;
        var byteString = Codec.Encode(value, typeof(Vessel));
        var decodedValue = Codec.Decode(byteString, typeof(Vessel), _connection);
        
        Assert.Null(decodedValue);
    }

    [Theory]
    [InlineData(typeof(Tuple<Vessel, int, FakeEnum>))]
    [InlineData(typeof(List<bool>))]
    [InlineData(typeof(long[]))]
    [InlineData(typeof(HashSet<Vector3D>))]
    [InlineData(typeof(Dictionary<string, Quaternion>))]
    public void DoesntThrow_WhenEncodingNullCollections(Type type)
    {
        // The protocol supports encoding null collections, but not decoding them in clients
        Codec.Encode(null, type);
    }

    [Theory]
    [InlineData(typeof(double))]
    [InlineData(typeof(float))]
    [InlineData(typeof(int))]
    [InlineData(typeof(long))]
    [InlineData(typeof(uint))]
    [InlineData(typeof(ulong))]
    [InlineData(typeof(string))]
    [InlineData(typeof(bool))]
    [InlineData(typeof(Vector3D))]
    [InlineData(typeof(Quaternion))]
    [InlineData(typeof(FakeEnum))]
    public void ThrowsException_WhenEncodingUnsupportedNullValues(Type type)
    {
        Assert.Throws<CodecException>(() => Codec.Encode(null, type));
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithEnums()
    {
        const FakeEnum enumValue = FakeEnum.Value2;
        var byteString = Codec.Encode(enumValue);
        var decodedValue = Codec.Decode(byteString, typeof(FakeEnum), _connection);
        Assert.NotNull(decodedValue);
        Assert.Equal(enumValue, (FakeEnum)decodedValue);
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithByteArrays()
    {
        var value = new byte[] {10, 20, 30};
        var byteString = Codec.Encode(value);
        var decodedValue = Codec.Decode(byteString, typeof(byte[]), _connection);
        
        Assert.Equal(value, decodedValue);
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithRemoteObjects()
    {
        // Find all instances of remote objects
        var remoteObjects = Assembly.GetAssembly(typeof(RemoteObject))!
            .GetTypes()
            .Where(x => x.IsSubclassOf(typeof(RemoteObject)));

        foreach (var remoteObject in remoteObjects)
        {
            var instance = (RemoteObject)RemoteObjectFixture.Create(remoteObject);
            var byteString = Codec.Encode(instance);
            var decodedValue = Codec.Decode(byteString, remoteObject, _connection);
            Assert.NotNull(decodedValue);
            
            var decodedInstance = decodedValue as RemoteObject;
            Assert.Equal(instance.Id, decodedInstance?.Id);
        }
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void DoesntThrow_WhenEncodingValidLambdaExpressions(bool useAsync)
    {
        var vessel = new Vessel(_connection, 1);
        LambdaExpression expression = useAsync ? () => vessel.GetBiomeAsync() : () => vessel.GetBiome();
        
        // All we can really do is check it doesn't throw - the client has no need to decode procedure calls into expressions
        Codec.Encode(expression);
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithTuples()
    {
        var vesselId = _fixture.Create<ulong>();
        var vessel = new Vessel(_connection, vesselId);
        var integer = _fixture.Create<int>();
        var enumValue = _fixture.Create<FakeEnum>();
        
        var tuple = new Tuple<Vessel, int, FakeEnum>(vessel, integer, enumValue);
        var byteString = Codec.Encode(tuple);
        var decodedValue = Codec.Decode(byteString, tuple.GetType(), _connection);
        Assert.NotNull(decodedValue);
        
        var decodedTuple = decodedValue as Tuple<Vessel, int, FakeEnum>;
        Assert.NotNull(decodedTuple);
        Assert.Equal(tuple.Item1.Id, decodedTuple.Item1.Id); // Vessel
        Assert.Equal(tuple.Item2, decodedTuple.Item2);       // int
        Assert.Equal(tuple.Item3, decodedTuple.Item3);       // enum
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithListTypes()
    {
        var arrayValue = _fixture.CreateMany<string>(3).ToArray();
        var listValue = _fixture.CreateMany<string>(3).ToList();
        
        var encodedArray = Codec.Encode(arrayValue);
        var encodedList = Codec.Encode(listValue);
        var decodedArrayObject = Codec.Decode(encodedArray, arrayValue.GetType(), _connection);
        var decodedListObject = Codec.Decode(encodedList, listValue.GetType(), _connection);
        Assert.NotNull(decodedArrayObject);
        Assert.NotNull(decodedListObject);

        var decodedArray = decodedArrayObject as string[];
        var decodedList = decodedListObject as List<string>;
        Assert.NotNull(decodedArray);
        Assert.NotNull(decodedList);

        for (var i = 0; i < 3; i++)
        {
            Assert.Equal(arrayValue[i], decodedArray[i]);
            Assert.Equal(listValue[i], decodedList[i]);
        }
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithSetTypes()
    {
        var set = _fixture.CreateMany<string>().ToHashSet();
        var encodedSet = Codec.Encode(set);
        var decodedSetObject = Codec.Decode(encodedSet, set.GetType(), _connection);
        Assert.NotNull(decodedSetObject);
        
        var decodedSet = decodedSetObject as HashSet<string>;
        Assert.NotNull(decodedSet);
        Assert.Equal(set.Count, decodedSet.Count);
        
        foreach (var item in decodedSet)
        {
            Assert.Contains(item, set);
        }
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithDictionaries()
    {
        var dictionary = _fixture.CreateMany<string>()
            .ToDictionary(x => x, y => _fixture.Create<long>());
        var encodedDictionary = Codec.Encode(dictionary);
        var decodedDictionaryObject = Codec.Decode(encodedDictionary, dictionary.GetType(), _connection);
        Assert.NotNull(decodedDictionaryObject);
        
        var decodedDictionary = decodedDictionaryObject as Dictionary<string, long>;
        Assert.NotNull(decodedDictionary);
        Assert.Equal(dictionary.Count, decodedDictionary.Count);

        foreach (var item in decodedDictionary)
        {
            Assert.Equal(dictionary[item.Key], item.Value);
        }
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithVectors()
    {
        var vector = _fixture.Create<Vector3D>();
        var encodedVector = Codec.Encode(vector);
        var decodedVectorObject = Codec.Decode(encodedVector, vector.GetType(), _connection);
        Assert.NotNull(decodedVectorObject);
        Assert.IsType<Vector3D>(decodedVectorObject);

        var decodedVector = (Vector3D)decodedVectorObject;
        Assert.Equal(vector.X, decodedVector.X);
        Assert.Equal(vector.Y, decodedVector.Y);
        Assert.Equal(vector.Z, decodedVector.Z);
    }

    [Fact]
    public void ReturnsCorrectValue_WhenWorkingWithQuaternions()
    {
        var quaternion = new Quaternion(
            _fixture.Create<double>(),
            _fixture.Create<double>(),
            _fixture.Create<double>(),
            _fixture.Create<double>()
        );
        var encodedQuaternion = Codec.Encode(quaternion);
        var decodedQuaternionObject = Codec.Decode(encodedQuaternion, quaternion.GetType(), _connection);
        Assert.NotNull(decodedQuaternionObject);
        Assert.IsType<Quaternion>(decodedQuaternionObject);
        
        var decodedQuaternion = (Quaternion)decodedQuaternionObject;
        Assert.Equal(quaternion.Real, decodedQuaternion.Real);
        Assert.Equal(quaternion.ImagX, decodedQuaternion.ImagX);
        Assert.Equal(quaternion.ImagY, decodedQuaternion.ImagY);
        Assert.Equal(quaternion.ImagZ, decodedQuaternion.ImagZ);
    }

    [Fact]
    public void DoesntThrow_WhenEncodingMessageTypes()
    {
        var arg1 = RemoteObjectFixture.Create<Vessel>();
        var arg2 = _fixture.Create<bool>();
        var call = new ProcedureCall
        {
            Service = _fixture.Create<string>(),
            Procedure = _fixture.Create<string>()
        };
        call.Arguments.Add(new Argument
            {
                Position = 0,
                Value = Codec.Encode(arg1)
            }
        );
        call.Arguments.Add(new Argument
            {
                Position = 0,
                Value = Codec.Encode(arg2)
            }
        );

        Codec.Encode(call);
    }

    [Fact]
    public void ThrowsException_WhenProvidedValueIsNotOfProvidedType()
    {
        const int value = 1;
        Assert.Throws<CodecException>(() => Codec.Encode(value, typeof(string)));
    }
}