using System.Net;
using kRPC.Client.Boost.Configuration;
using Microsoft.Extensions.Logging;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Provides static methods for creating connections to a KRPC server.
/// </summary>
public static class ConnectionBuilder
{
    /// <summary>
    /// Creates a new connection to the KRPC server, using the provided details.
    /// </summary>
    /// <param name="config">The configuration to use with the client. Uses all default values if left null.</param>
    /// <param name="loggerFactory">The optional ILoggerFactory implementation to use when logging</param>
    public static IConnection NewConnection(ClientConfig? config = null, ILoggerFactory? loggerFactory = null)
    {
        return new ConnectionMultiplexer(config, loggerFactory);
    }
    
    /// <summary>
    /// Creates a connection to the KRPC server, using the provided details.
    /// </summary>
    /// <param name="address">The IP Address of the server</param>
    /// <param name="rpcPort">The port to use for RPC connections</param>
    /// <param name="streamPort">The port to use for streaming connections</param>
    /// <param name="clientName">The name of the client using this configuration</param>
    /// <param name="loggerFactory">The optional ILoggerFactory implementation to use when logging</param>
    /// <returns></returns>
    public static IConnection NewConnection(IPAddress address, 
        int rpcPort, 
        int streamPort, 
        string clientName, 
        ILoggerFactory? loggerFactory = null)
    {
        var config = new ClientConfig(address, rpcPort, streamPort, clientName);
        return new ConnectionMultiplexer(config, loggerFactory);
    }
}