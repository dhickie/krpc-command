using System.Net;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using kRPC.Client.Boost.Services;

namespace kRPC.Client.Boost;

/// <summary>
/// Provides access to boosted kRPC service wrappers.
/// </summary>
public class KrpcConnection(string name, IPAddress ip, int rpcPort, int streamPort)
{
    internal readonly Connection Connection = new(name, ip, rpcPort, streamPort);
    
    /// <summary>
    /// Gets the boosted SpaceCenter service wrapper.
    /// </summary>
    public SpaceCenter SpaceCenter => new(Connection.SpaceCenter());
}
