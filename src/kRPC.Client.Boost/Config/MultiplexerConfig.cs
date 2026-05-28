using System.Text;

namespace kRPC.Client.Boost.Config;

public class MultiplexerConfig(int? numRpcConnections = null, string? clientName = null) : Config
{
    public int NumRpcConnections = numRpcConnections ?? 3;
    public string ClientName = clientName ?? "kRPC.Client.Boost";
    
    protected override void Validate()
    {
        IsInvalid(NumRpcConnections, x => x <= 0, "NumRpcConnections must be greater than 0");
        IsInvalid(ClientName, string.IsNullOrWhiteSpace, "ClientName must be a non-empty string");
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Multiplexer:");
        builder.AppendLine($"  {nameof(numRpcConnections)}: {numRpcConnections}");
        builder.AppendLine($"  {nameof(ClientName)}: {clientName}");
        
        return builder.ToString();
    }
}