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
    public MultiplexerConfig Multiplexer = multiplexerConfig ?? new MultiplexerConfig();
    public ConnectionConfig Connection = connectionConfig ?? new ConnectionConfig();
    public StreamConfig Stream = streamConfig ?? new StreamConfig();

    public void Validate()
    {
        var errors = new List<string>();
        Multiplexer.Validate(errors);
        Connection.Validate(errors);
        Stream.Validate(errors);
        
        ConfigException.ThrowIfContainsErrors(errors);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(Multiplexer.ToString());
        builder.AppendLine(Connection.ToString());
        builder.AppendLine(Stream.ToString());

        return builder.ToString();
    }
}