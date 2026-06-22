using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Connection.Schema;

namespace kRPC.Client.Boost.IntegrationTests.Server;

public class TestServer
{
    private readonly TcpListener _rpcListener;
    private readonly Thread _newClientThread;
    private readonly ConcurrentDictionary<string, TcpConnection> _clients;
    private readonly ConcurrentDictionary<string, string> _clientNameMap;
    private readonly ConcurrentDictionary<string, Thread> _clientThreads;
    
    private readonly RequestHandler _requestHandler;

    public const int RpcPort = 16253;

    public TestServer()
    {
        _clientThreads = new ConcurrentDictionary<string, Thread>();
        _clients = new ConcurrentDictionary<string, TcpConnection>();
        _clientNameMap = new ConcurrentDictionary<string, string>();
        _rpcListener = new TcpListener(IPAddress.Any, RpcPort);
        _rpcListener.Start();
        
        _requestHandler = new RequestHandler();

        _newClientThread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            NewClientLoop();
        });
        _newClientThread.Start();
    }

    public void ConfigureResponse(string clientName, string service, string procedure, Func<object?> response)
    {
        if (!_clientNameMap.TryGetValue(clientName, out var clientId))
            throw new ArgumentException($"No client ID found for name '{clientName}'");

        _requestHandler.ConfigureResponse(clientId, service, procedure, response);
    }

    public void Received(string clientName, Func<CallInfo, bool> predicate)
    {
        if (!_clientNameMap.TryGetValue(clientName, out var clientId))
            throw new ArgumentException($"No client ID found for name '{clientName}'");
        
        var received = _requestHandler.Received(clientId, predicate);
        Assert.True(received);
    }

    private void ClientLoop(string clientId)
    {
        var client = _clients[clientId];
        
        // Read the connection request and provide the client with an ID
        var clientByteString = Codec.Encode(clientId);
        var connectionRequest = client.Receive(ConnectionRequest.Parser);
        _clientNameMap[connectionRequest.ClientName] = clientId;
        var connectionResponse = new ConnectionResponse
        {
            Status = ConnectionResponse.Types.Status.Ok,
            Message = string.Empty,
            ClientIdentifier = clientByteString
        };
        client.Send(connectionResponse);
        
        while (true)
        {
            var request = client.Receive(Request.Parser)
                ?? throw new InvalidOperationException("Received null request");
            
            var response = _requestHandler.Respond(clientId, request);
            client.Send(response);
        }
    }
    
    private void NewClientLoop()
    {
        while (true)
        {
            var clientId = Guid.NewGuid().ToString();
            var client = _rpcListener.AcceptTcpClient();
            _clients.TryAdd(clientId, new TcpConnection(client));

            var newThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                ClientLoop(clientId);
            });
            newThread.Start();
            _clientThreads.TryAdd(clientId, newThread);
        }
    }
}