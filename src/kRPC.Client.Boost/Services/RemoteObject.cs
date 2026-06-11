using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services;

/// <summary>
/// Represents an object that exists on the server.
/// </summary>
public abstract class RemoteObject : ServiceObject
{
    /// <summary>
    /// Creates a new remote object.
    /// </summary>
    /// <param name="connection">The connection multiplexer that provides access to the server</param>
    /// <param name="id">The ID of the object on the server</param>
    internal RemoteObject(IConnectionMultiplexer connection, ulong id) : base(connection)
    {
        Id = id;
    }
    
    /// <summary>
    /// The ID of the object on the server.
    /// </summary>
    internal ulong Id { get; }
}
