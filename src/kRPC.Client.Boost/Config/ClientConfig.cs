using System.Text;
using kRPC.Client.Boost.Exceptions;

namespace kRPC.Client.Boost.Config;

/// <summary>
/// The top level configuration object that is passed when creating the <see cref="Connection.ConnectionMultiplexer">multiplexer</see>.
/// </summary>
/// <param name="multiplexerConfig">The multiplexer configuration to use</param>
/// <param name="connectionConfig">The connection configuration to use</param>
/// <param name="streamConfig">The stream configuration to use</param>
public class ClientConfig(
    MultiplexerConfig? multiplexerConfig = null, 
    ConnectionConfig? connectionConfig = null,
    StreamConfig? streamConfig = null)
{
    /// <summary>
    /// The multiplexer configuration.
    /// </summary>
    public MultiplexerConfig Multiplexer = multiplexerConfig ?? new MultiplexerConfig();
    
    /// <summary>
    /// The connection configuration.
    /// </summary>
    public ConnectionConfig Connection = connectionConfig ?? new ConnectionConfig();
    
    /// <summary>
    /// The stream configuration.
    /// </summary>
    public StreamConfig Stream = streamConfig ?? new StreamConfig();

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