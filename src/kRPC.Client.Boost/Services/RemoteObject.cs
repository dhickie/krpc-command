using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services;

/// <summary>
/// Represents an object that exists on the server.
/// </summary>
public abstract class RemoteObject
{
    /// <summary>
    /// Creates a new remote object.
    /// </summary>
    /// <param name="id">The ID of the object on the server</param>
    /// <param name="connection">The connection multiplexer that provides access to the server</param>
    protected RemoteObject(ulong id, ConnectionMultiplexer connection)
    {
        Id = id;
        Connection = connection;
    }
    
    /// <summary>
    /// The ID of the object on the server.
    /// </summary>
    internal ulong Id { get; }

    protected ConnectionMultiplexer Connection { get; }
}