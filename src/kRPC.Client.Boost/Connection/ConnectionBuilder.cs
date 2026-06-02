using kRPC.Client.Boost.Config;
using Microsoft.Extensions.Logging;

namespace kRPC.Client.Boost.Connection;

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
}