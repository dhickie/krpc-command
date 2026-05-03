using System.Net;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Streams;

namespace kRPC.Client.Boost;

/// <summary>
/// Provides access to boosted kRPC service wrappers.
/// </summary>
public class KrpcConnection
{
    internal readonly Connection Connection;
    
    public KrpcConnection(string name, IPAddress ip, int rpcPort, int streamPort)
    {
        Connection = new Connection(name, ip, rpcPort, streamPort);
        StreamManager.Initialise(Connection);
    }
    
    /// <summary>
    /// Gets the boosted SpaceCenter service wrapper.
    /// </summary>
    public SpaceCenter SpaceCenter => new(Connection.SpaceCenter());
}
