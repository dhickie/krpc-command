using System.Collections.Concurrent;
using kRPC.Client.Boost.Exceptions;
using kRPC.Client.Boost.Streams;

namespace kRPC.Client.Boost.Connection;

public class ConnectionMultiplexer : IConnection, IDisposable
{
    private readonly Connection[] _connections;
    private readonly BlockingCollection<ProcedureRequest> _requests;
    private readonly ConcurrentDictionary<string, ProcedureResult> _results;

    private readonly CancellationTokenSource _disposalTokenSource = new();
    private bool _disposed;
    
    /// <summary>
    /// Creates a connection multiplexer that manages one or more connections to a kRPC server.
    /// All interaction with kRPC starts with an instance of this class.
    /// </summary>
    /// <param name="numConnections">The number of simultaneous connections to create</param>
    /// <param name="config">The configuration for the connection(s)</param>
    public ConnectionMultiplexer(int numConnections, ConnectionConfig config)
    {
        _requests = new BlockingCollection<ProcedureRequest>();
        _results = new ConcurrentDictionary<string, ProcedureResult>();
        
        _connections = new Connection[numConnections];
        for (var i = 0; i < numConnections; i++)
        {
            _connections[0] = new Connection(this, config, _requests, _results);
        }
        
        StreamManager.Initialise(this);
    }

    /// <summary>
    /// Finalises all connections to the kRPC server.
    /// </summary>
    ~ConnectionMultiplexer()
    {
        Dispose(false);
    }

    /// <summary>
    /// Disposes all connections to the kRPC server.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            foreach (var connection in _connections)
            {
                connection.Dispose();
            }
        }

        _disposed = true;
        _disposalTokenSource.Cancel();
    }

    public Services.KRPC.KRPC KRPC => new(this);

    /// <summary>
    /// Synchronously invokes a procedure that doesn't have a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    internal void Invoke(string service, string procedure, object[]? arguments = null)
    {
        CheckDisposed();
        var result = AddToQueue(service, procedure, arguments);
        result.WaitForCompletion(_disposalTokenSource.Token);
    }
    
    /// <summary>
    /// Synchronously invokes a procedure that returns a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    /// <typeparam name="TResponse">The type of the response object</typeparam>
    /// <returns>The result object from the procedure.</returns>
    internal TResponse Invoke<TResponse>(string service, string procedure, object[]? arguments = null)
    {
        CheckDisposed();
        var result = AddToQueue<TResponse>(service, procedure, arguments);
        return result.WaitForResult(_disposalTokenSource.Token);
    }

    /// <summary>
    /// Asynchronously invokes a procedure that doesn't have a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    internal async Task InvokeAsync(string service, string procedure, object[]? arguments = null)
    {
        CheckDisposed();
        var result = AddToQueue(service, procedure, arguments);
        await result.WaitForCompletionAsync(_disposalTokenSource.Token);
    }

    /// <summary>
    /// Asynchronously invokes a procedure that returns a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    /// <typeparam name="TResponse">The type of the response object</typeparam>
    /// <returns>The result object from the procedure.</returns>
    internal async Task<TResponse> InvokeAsync<TResponse>(string service, string procedure, object[]? arguments = null)
    {
        CheckDisposed();
        var result = AddToQueue<TResponse>(service, procedure, arguments);
        return await result.WaitForResultAsync(_disposalTokenSource.Token);
    }

    private ProcedureResult<T> AddToQueue<T>(string service, string procedure, object[]? arguments = null)
    {
        // Set up the request and result object
        var request = new ProcedureRequest(service, procedure, arguments, typeof(T));
        var result = new ProcedureResult<T>();

        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        // Add the request to the queue
        _requests.Add(request);

        return result;
    }

    private ProcedureResult AddToQueue(string service, string procedure, object[]? arguments = null)
    {
        var request = new ProcedureRequest(service, procedure, arguments);
        var result = new ProcedureResult();
        
        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        _requests.Add(request);

        return result;
    }

    private void CheckDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }
}