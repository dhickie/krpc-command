using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Connection.Schema;
using ConnectionType = kRPC.Client.Boost.Connection.Schema.ConnectionRequest.Types.Type;

namespace kRPC.Client.Boost.IntegrationTests.Server;

public class TestServer
{
    private readonly TcpListener _rpcListener;
    private readonly TcpListener _streamListener;
    private readonly Thread _newRpcClientThread;
    private readonly Thread _newStreamClientThread;
    private readonly Thread _pendingClientsThread;
    private readonly Thread _streamClientThread;
    private readonly ConcurrentDictionary<ClientId, Thread> _rpcClientThreads;
    private readonly ConcurrentDictionary<ClientId, TcpConnection> _rpcClients;
    private readonly ConcurrentDictionary<ClientId, TcpConnection> _streamClients;
    private readonly ConcurrentDictionary<string, ClientId> _clientNameMap;
    
    private readonly BlockingCollection<(TcpConnection, ConnectionType)> _pendingClients = new();
    
    private readonly RequestHandler _requestHandler;

    public const int RpcPort = 16253;
    public const int StreamPort = 16254;

    public TestServer()
    {
        // Collections
        _rpcClientThreads = new ConcurrentDictionary<ClientId, Thread>();
        _rpcClients = new ConcurrentDictionary<ClientId, TcpConnection>();
        _streamClients = new ConcurrentDictionary<ClientId, TcpConnection>();
        _clientNameMap = new ConcurrentDictionary<string, ClientId>();
        
        // Listeners
        _rpcListener = new TcpListener(IPAddress.Any, RpcPort);
        _rpcListener.Start();
        _streamListener = new TcpListener(IPAddress.Any, StreamPort);
        _streamListener.Start();
        
        // Request handler
        _requestHandler = new RequestHandler();

        // Threads
        _newRpcClientThread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            NewRpcClientLoop();
        });
        _newRpcClientThread.Start();
        
        _newStreamClientThread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            NewStreamClientLoop();
        });
        _newStreamClientThread.Start();

        _pendingClientsThread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            PendingClientsLoop();
        });
        _pendingClientsThread.Start();

        _streamClientThread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            StreamClientLoop();
        });
        _streamClientThread.Start();
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

    private void RpcClientLoop(string clientId)
    {
        var client = _rpcClients[clientId];
        while (true)
        {
            var request = client.Receive(Request.Parser)
                ?? throw new InvalidOperationException("Received null request");
            
            var response = _requestHandler.Respond(clientId, request);
            client.Send(response);
        }
    }

    private void StreamClientLoop()
    {
        var sw = new Stopwatch();
        const int updateHz = 60;
        var tickRate = TimeSpan.FromSeconds(1) / updateHz;
        while (true)
        {
            var start = sw.Elapsed;
            var nextStart = start + tickRate;
            
            // TODO: actually send stream updates

            var sleepTime = nextStart - sw.Elapsed;
            Thread.Sleep(sleepTime);
        }
    }
    
    private void NewRpcClientLoop()
    {
        while (true)
        {
            var client = _rpcListener.AcceptTcpClient();
            _pendingClients.Add((new TcpConnection(client), ConnectionType.Rpc));
        }
    }
    
    private void NewStreamClientLoop()
    {
        while (true)
        {
            var client = _streamListener.AcceptTcpClient();
            _pendingClients.Add((new TcpConnection(client), ConnectionType.Stream));
        }
    }

    private void PendingClientsLoop()
    {
        while (true)
        {
            var (pendingClient, connectionType) = _pendingClients.Take();
            
            // Accept the connection
            var clientId = AcceptClient(pendingClient, connectionType, () => Guid.NewGuid().ToString());
            if (clientId != null && connectionType == ConnectionType.Rpc)
            {
                // RPC clients are given their own thread for processing requests
                var newThread = new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    RpcClientLoop(clientId);
                });
                newThread.Start();
                _rpcClientThreads.TryAdd(clientId, newThread);
            }
            
            // Stream clients are sent updates from a single update loop, so no need to start a client thread
        }
    }
    
    private ClientId? AcceptClient(TcpConnection client, ConnectionType expectedConnectionType, Func<string> clientIdFactory)
    {
        var errorMessage = string.Empty;
        var request = client.Receive(ConnectionRequest.Parser);
        
        if (request.Type != expectedConnectionType)
            errorMessage = $"Received connection request for unexpected connection type. Expected {expectedConnectionType} but received {request.Type}.";

        ClientId? clientId = null;
        if (request.Type == ConnectionType.Stream)
        {
            if (!_rpcClients.TryGetValue(request.ClientIdentifier, out _))
            {
                errorMessage = "Received streaming connection request for client with no RPC connection";
            }
            else
            {
                clientId = request.ClientIdentifier;
                _streamClients.TryAdd(clientId, client);
            }
        }
        else if (errorMessage == string.Empty)
        {
            // This client will have the original client name with an extra string appended to the end
            // to support multiplexing, so we have to extract the original client name in order for tests
            // to be able to just pass in the original client name
            var originalClientName = ExtractOriginalClientName(request.ClientName);
            clientId = clientIdFactory();
            _clientNameMap[originalClientName] = clientId;
            _rpcClients.TryAdd(clientId, client);
        }
        
        ConnectionResponse response;
        if (errorMessage != string.Empty)
        {
            response = new ConnectionResponse
            {
                Status = ConnectionResponse.Types.Status.WrongType,
                Message = errorMessage,
                ClientIdentifier = null
            };
        }
        else
        {
            response = new ConnectionResponse
            {
                Status = ConnectionResponse.Types.Status.Ok,
                Message = string.Empty,
                ClientIdentifier = clientId!
            };
        }
        
        client.Send(response);
        return clientId;
    }

    private string ExtractOriginalClientName(string multiplexedClientName)
    {
        var match = Regex.Match(multiplexedClientName, @"^(.*?)_(?:stream|rpc)_\d+$");

        if (match.Success)
        {
            return match.Groups[1].Value;
        }

        throw new ArgumentException($"The provided multiplexed client name did not match the expected pattern");
    }
}