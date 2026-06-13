using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.IntegrationTests.Server;

internal class ClientConnection(TcpConnection connection)
{
    public TcpConnection Connection { get; } = connection;
    public string ClientName { get; set; } = string.Empty;
}