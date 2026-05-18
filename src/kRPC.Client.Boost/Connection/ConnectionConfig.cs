using System.Net;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Encapsulates all configuration for connecting to the kRPC server.
/// </summary>
/// <param name="name">The name of the client connection</param>
/// <param name="address">The IP address of the server</param>
/// <param name="rpcPort">The port to use for the RPC connection</param>
/// <param name="streamPort">The port to use for the Streaming connection</param>
public class ConnectionConfig(string name, IPAddress? address = null, int rpcPort = 50000, int streamPort = 50001)
{
    public readonly string Name = name;
    public readonly IPAddress Address = address ?? IPAddress.Loopback;
    public readonly int RpcPort = rpcPort;
    public readonly int StreamPort = streamPort;
}