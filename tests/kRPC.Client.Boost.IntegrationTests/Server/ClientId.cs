using Google.Protobuf;
using kRPC.Client.Boost.Connection;
using NSubstitute;

namespace kRPC.Client.Boost.IntegrationTests.Server;

public class ClientId(string id)
{
    private readonly string _stringId = id;
    private static readonly IConnectionMultiplexer FakeConnection = Substitute.For<IConnectionMultiplexer>();

    public static implicit operator ByteString(ClientId id) => Codec.Encode(id);
    public static implicit operator string(ClientId id) => id._stringId;
    
    public static implicit operator ClientId(string id) => new(id);
    public static implicit operator ClientId(ByteString id) =>
        new((string)Codec.Decode(id, typeof(string), FakeConnection)!);
}