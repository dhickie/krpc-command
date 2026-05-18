using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.KRPC.RemoteObjects;

/// <summary>
/// Represents the remote stream object on the server. Provides access to RPCs for the stream.
/// </summary>
public class RemoteStream : RemoteObject
{
    /// <summary>
    /// Create a new remote stream.
    /// </summary>
    /// <param name="id">The ID of the stream</param>
    /// <param name="connection">The multiplexer that provides access to the server</param>
    protected RemoteStream(ulong id, ConnectionMultiplexer connection) : base(id, connection)
    {}
    
    /// <summary>
    /// Synchronously removes the stream from the server.
    /// </summary>
    public void Remove()
    {
        Connection.RemoveStream(Id);
    }

    /// <summary>
    /// Asynchronously removes the stream from the server.
    /// </summary>
    public async Task RemoveAsync()
    {
        await Connection.RemoveStreamAsync(Id);
    }
}