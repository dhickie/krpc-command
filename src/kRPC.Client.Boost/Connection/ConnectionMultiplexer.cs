using System.Collections.Concurrent;
using kRPC.Client.Boost.Exceptions;

namespace kRPC.Client.Boost.Connection;

public class ConnectionMultiplexer : IConnection
{
    private Connection[] _connections;
    private BlockingCollection<ProcedureRequest> _requests;
    private ConcurrentDictionary<string, ProcedureResult> _results;
    
    public ConnectionMultiplexer(int numConnections, ConnectionConfig config)
    {
        _requests = new BlockingCollection<ProcedureRequest>();
        _results = new ConcurrentDictionary<string, ProcedureResult>();
        
        _connections = new Connection[numConnections];
        for (var i = 0; i < numConnections; i++)
        {
            _connections[0] = new Connection(this, config, _requests, _results);
        }
    }
    
    public TResponse Invoke<TResponse>(string service, string procedure, object[]? arguments = null)
    {
        var result = AddToQueue<TResponse>(service, procedure, arguments);
        
        // Wait for the response
        return result.WaitForResult();
    }

    public async Task<TResponse> InvokeAsync<TResponse>(string service, string procedure, object[]? arguments = null)
    {
        var result = AddToQueue<TResponse>(service, procedure, arguments);
        
        // Wait for the response
        return await result.WaitForResultAsync();
    }

    private ProcedureResult<T> AddToQueue<T>(string service, string procedure, object[]? arguments = null)
    {
        // Set up the request and result object
        var request = new ProcedureRequest(typeof(T), service, procedure, arguments);
        var result = new ProcedureResult<T>();

        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        // Add the request to the queue
        _requests.Add(request);

        return result;
    }
}