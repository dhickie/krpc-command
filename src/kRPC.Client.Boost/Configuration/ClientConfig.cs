using System.Net;
using System.Text;
using kRPC.Client.Boost.Exceptions;

namespace kRPC.Client.Boost.Configuration;

/// <summary>
/// The top level configuration object that is passed when creating the <see cref="Connection.ConnectionMultiplexer">multiplexer</see>.
/// </summary>
public class ClientConfig
{
    /// <summary>
    /// Creates a new client configuration using the provided sub-configuration objects.
    /// </summary>
    /// <param name="multiplexerConfig">The multiplexer configuration to use</param>
    /// <param name="connectionConfig">The connection configuration to use</param>
    /// <param name="streamConfig">The stream configuration to use</param>
    public ClientConfig(MultiplexerConfig? multiplexerConfig = null,
        ConnectionConfig? connectionConfig = null,
        StreamConfig? streamConfig = null)
    {
        Multiplexer = multiplexerConfig ?? new MultiplexerConfig();
        Connection = connectionConfig ?? new ConnectionConfig();
        Stream = streamConfig ?? new StreamConfig();
    }

    /// <summary>
    /// Creates a new client configuration using the provided connection details.
    /// </summary>
    /// <param name="address">The IP Address of the server</param>
    /// <param name="rpcPort">The port to use for RPC connections</param>
    /// <param name="streamPort">The port to use for streaming connections</param>
    /// <param name="clientName">The name of the client using this configuration</param>
    public ClientConfig(IPAddress address, int rpcPort, int streamPort, string clientName)
    {
        Multiplexer = new MultiplexerConfig
        {
            ClientName = clientName
        };
        Connection = new ConnectionConfig
        {
            Address = address,
            RpcPort = rpcPort,
            StreamPort = streamPort
        };
        Stream = new StreamConfig();
    }
    
    /// <summary>
    /// The multiplexer configuration.
    /// </summary>
    public MultiplexerConfig Multiplexer
    {
        get;
        init;
    }
    
    /// <summary>
    /// The connection configuration.
    /// </summary>
    public ConnectionConfig Connection
    {
        get;
        init;
    }

    /// <summary>
    /// The stream configuration.
    /// </summary>
    public StreamConfig Stream
    {
        get;
        init;
    }

    /// <summary>
    /// Validates that the current configuration is valid.
    /// </summary>
    /// <exception cref="ConfigException">Thrown if the configuration is invalid.</exception>
    public void Validate()
    {
        var errors = new List<string>();
        Multiplexer.Validate(errors);
        Connection.Validate(errors);
        Stream.Validate(errors);
        
        ConfigException.ThrowIfContainsErrors(errors);
    }

    /// <summary>
    /// Converts the configuration to a formatted string.
    /// </summary>
    /// <returns>The configuration as a formatted string.</returns>
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(Multiplexer.ToString());
        builder.AppendLine(Connection.ToString());
        builder.AppendLine(Stream.ToString());

        return builder.ToString();
    }
}