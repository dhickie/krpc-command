using System.Net;
using System.Text;

namespace kRPC.Client.Boost.Config;

/// <summary>
/// Encapsulates all configuration for connecting to the kRPC server.
/// </summary>
/// <param name="address">The IP address of the server. Defaults to localhost.</param>
/// <param name="rpcPort">The port to use for RPC connections. Defaults to 5000.</param>
/// <param name="streamPort">The port to use for the Streaming connection. Defaults to 5001.</param>
public class ConnectionConfig(
    IPAddress? address = null, 
    int? rpcPort = null, 
    int? streamPort = null) : Config
{
    /// <summary>
    /// The IP address of the server.
    /// </summary>
    public IPAddress Address = address ?? IPAddress.Loopback;
    
    /// <summary>
    /// The port to use for RPC connections.
    /// </summary>
    public int RpcPort = rpcPort ?? 5000;
    
    /// <summary>
    /// The port to use for the Streaming connection.
    /// </summary>
    public int StreamPort = streamPort ?? 5001;
    
    /// <summary>
    /// Converts this configuration object to a formatted string.
    /// </summary>
    /// <returns>The configuration as a formatted string.</returns>
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Connection:");
        builder.AppendLine($"  {nameof(Address)}: {Address}");
        builder.AppendLine($"  {nameof(RpcPort)}: {RpcPort}");
        builder.AppendLine($"  {nameof(StreamPort)}: {StreamPort}");
        
        return builder.ToString();
    }
    
    protected override void Validate()
    {
        IsInvalid(Address, IsInvalidIP, "Server IP must be a valid IP address pointing to a specific server");
        IsInvalid(RpcPort, IsInvalidPort, "RPC port must be a valid port number greater than 0 and less than or equal to 65535");
        IsInvalid(StreamPort, IsInvalidPort, "Stream port must be a valid port number greater than 0 and less than or equal to 65535");
        IsInvalid(RpcPort, StreamPort, (x, y) => x.Equals(y), "RPC port and Stream port must be different values");
    }
    
    private static bool IsInvalidIP(IPAddress address)
    {
        return Equals(address, IPAddress.Any) ||
               Equals(address, IPAddress.Broadcast) ||
               Equals(address, IPAddress.None) ||
               Equals(address, IPAddress.IPv6Any) ||
               Equals(address, IPAddress.IPv6None);
    }

    private static bool IsInvalidPort(int port)
    {
        return port is <= 0 or > 65535;
    }
}