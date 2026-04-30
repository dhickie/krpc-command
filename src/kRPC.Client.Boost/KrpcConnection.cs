using System.Net;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;

namespace kRPC.Client.Boost;

public class KrpcConnection(string name, IPAddress ip, int rpcPort, int streamPort)
{
    private readonly Connection _connection = new(name, ip, rpcPort, streamPort);
    
    public Service SpaceCenter => _connection.SpaceCenter();
}