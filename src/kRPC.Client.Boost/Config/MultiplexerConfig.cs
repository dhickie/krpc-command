using System.Text;

namespace kRPC.Client.Boost.Config;

/// <summary>
/// Encapsulates all configuration related to the <see cref="Connection.ConnectionMultiplexer">connection multiplexer</see>.
/// </summary>
/// <param name="numRpcConnections">
///     The number of concurrent RPC connections to open to the server.
///     The more connections you have, the less likely it is that a request will have to wait for a previous request to complete before this one can be served.
///     However, this also makes it easier to overload the server such that it can no longer serve all the requests in the permitted time per frame.
///     Defaults to 3.
/// </param>
/// <param name="clientName">
///     The name of the client. This will appear as a prefix to the multiple connections that are opened to the server.
///     Defaults to "kRPC.Client.Boost".
/// </param>
public class MultiplexerConfig(int? numRpcConnections = null, string? clientName = null) : Config
{
    /// <summary>
    /// The number of concurrent RPC connections to open to the server.
    /// The more connections you have, the less likely it is that a request will have to wait for a previous request to complete before this one can be served.
    /// However, this also makes it easier to overload the server such that it can no longer serve all the requests in the permitted time per frame.
    /// </summary>
    public int NumRpcConnections = numRpcConnections ?? 3;
    
    /// <summary>
    /// The name of the client. This will appear as a prefix to the multiple connections that are opened to the server.
    /// </summary>
    public string ClientName = clientName ?? "kRPC.Client.Boost";
    
    protected override void Validate()
    {
        IsInvalid(NumRpcConnections, x => x <= 0, "NumRpcConnections must be greater than 0");
        IsInvalid(ClientName, string.IsNullOrWhiteSpace, "ClientName must be a non-empty string");
    }

    /// <summary>
    /// Converts this configuration object to a formatted string.
    /// </summary>
    /// <returns>The configuration as a formatted string.</returns>
    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Multiplexer:");
        builder.AppendLine($"  {nameof(numRpcConnections)}: {numRpcConnections}");
        builder.AppendLine($"  {nameof(ClientName)}: {clientName}");
        
        return builder.ToString();
    }
}