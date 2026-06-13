using System.Net;
using System.Net.Sockets;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Connection.Schema;

namespace kRPC.Client.Boost.IntegrationTests.Server;

public class TestServer
{
    private TcpListener _rpcListener;
    private Thread _newClientThread;
    private Dictionary<string, ClientConnection> _clients;
    private Dictionary<string, Thread> _clientThreads;
    private const int RpcPort = 5000;

    public TestServer()
    {
        _clients = new Dictionary<string, ClientConnection>();
        _rpcListener = new TcpListener(IPAddress.Any, RpcPort);
        _rpcListener.Start();

        _newClientThread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            NewClientLoop();
        });
        _newClientThread.Start();
    }

    private void ClientLoop(string clientId)
    {
        var client = _clients[clientId].Connection;
        
        // Read the connection request and provide the client with an ID
        var clientByteString = Codec.Encode(clientId);
        client.Receive(ConnectionRequest.Parser);
        var response = new ConnectionResponse
        {
            Status = ConnectionResponse.Types.Status.Ok,
            Message = string.Empty,
            ClientIdentifier = clientByteString
        };
        client.Send(response);
        
        while (true)
        {
            var request = client.Receive(Request.Parser);
            
        }
    }
    
    private void NewClientLoop()
    {
        while (true)
        {
            var clientId = Guid.NewGuid().ToString();
            var client = _rpcListener.AcceptTcpClient();
            _clients.Add(clientId, new ClientConnection(new TcpConnection(client)));

            var newThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                ClientLoop(clientId);
            });
            newThread.Start();
            _clientThreads.Add(clientId, newThread);
        }
    }
}