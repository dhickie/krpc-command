using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services;

public class RemoteObject(long id, ConnectionMultiplexer connection)
{
    public long Id { get; } = id;

    protected ConnectionMultiplexer Connection { get; } = connection;
}