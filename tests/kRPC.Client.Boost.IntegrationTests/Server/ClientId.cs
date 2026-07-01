using Google.Protobuf;
using kRPC.Client.Boost.Connection;
using NSubstitute;

namespace kRPC.Client.Boost.IntegrationTests.Server;

public class ClientId(string id) : IEquatable<ClientId>
{
    private readonly string _stringId = id;
    private static readonly IConnectionMultiplexer FakeConnection = Substitute.For<IConnectionMultiplexer>();

    public static implicit operator ByteString(ClientId id) => Codec.Encode(id._stringId);
    public static implicit operator string(ClientId id) => id._stringId;
    
    public static implicit operator ClientId(string id) => new(id);
    public static implicit operator ClientId(ByteString id) =>
        new((string)Codec.Decode(id, typeof(string), FakeConnection)!);

    public bool Equals(ClientId? other)
    {
        if (other == null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return _stringId == other._stringId;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ClientId);
    }

    public override int GetHashCode()
    {
        return _stringId.GetHashCode();
    }
}