using System.Net;

namespace kRPC.Client.Boost.Connection;

public class ConnectionConfig(string name, IPAddress? address = null, int rpcPort = 50000, int streamPort = 50001)
{
    public readonly string Name = name;
    public readonly IPAddress Address = address ?? IPAddress.Loopback;
    public readonly int RpcPort = rpcPort;
    public readonly int StreamPort = streamPort;
}