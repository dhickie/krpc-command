using System.Collections.Concurrent;
using System.Linq.Expressions;
using kRPC.Client.Boost.Connection.Requests;
using kRPC.Client.Boost.Exceptions;
using kRPC.Client.Boost.Logging;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;
using kRPC.Client.Boost.Streams;
using Microsoft.Extensions.Logging;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// A multiplexer that distributes requests among multiple connections to the kRPC server.
/// This is the point of entry for clients wishing to interact with the server.
/// </summary>
public class ConnectionMultiplexer : IDisposable
{
    private readonly StreamConnection _streamConnection;
    private readonly RpcConnection[] _rpcConnections;
    
    private readonly BlockingCollection<StreamRequest> _streamRequests;
    private readonly BlockingCollection<ProcedureRequest> _rpcRequests;
    private readonly ConcurrentDictionary<string, ProcedureResult> _results;
    
    private readonly LogManager _logManager;
    private readonly ILogger<ConnectionMultiplexer> _logger;

    private readonly CancellationTokenSource _disposalTokenSource = new();
    private bool _disposed;

    /// <summary>
    /// Creates a connection multiplexer that manages one or more connections to a kRPC server.
    /// All interaction with kRPC starts with an instance of this class.
    /// </summary>
    /// <param name="numRpcConnections">The number of simultaneous RPC connections to create</param>
    /// <param name="config">The configuration for the connection(s)</param>
    /// <param name="loggerFactory">The optional ILoggerFactory implementation to use when logging</param>
    public ConnectionMultiplexer(int numRpcConnections, ConnectionConfig config, ILoggerFactory? loggerFactory = null)
    {
        try
        {
            _logManager = new LogManager(loggerFactory);
            _logger = LogManager.GetLogger<ConnectionMultiplexer>();

            _streamRequests = new BlockingCollection<StreamRequest>();
            _rpcRequests = new BlockingCollection<ProcedureRequest>();
            _results = new ConcurrentDictionary<string, ProcedureResult>();

            LogStartupInformation(config);

            // Create the stream connection - we intentionally keep a single stream connection to ensure that all stream
            // requests are passed through the same TCP connection, which the server has associated with the streaming
            // TCP connection
            _logger.LogInformation("Establishing stream connection");
            var streamConnName = $"{config.Name}_stream_1";
            _streamConnection = new StreamConnection(this, config, streamConnName, _streamRequests, _results);

            // Create the RPC connections
            _rpcConnections = new RpcConnection[numRpcConnections];
            for (var i = 0; i < numRpcConnections; i++)
            {
                var connName = $"{config.Name}_rpc_{i+1}";
                _logger.LogInformation("Establishing RPC connection {connectionNumber} of {numConnections}", 
                    i, 
                    numRpcConnections);
                _rpcConnections[0] = new RpcConnection(this, config, connName, _rpcRequests, _results);
            }
            
            StreamManager.Initialise(this);
        }
        catch (Exception e)
        {
            _logger?.LogError(e, "Fatal error occured while trying to establish connection with server");
            throw;
        }
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
        _logger.LogInformation("Disconnecting from kRPC server");
        
        if (disposing)
        {
            foreach (var connection in _rpcConnections)
            {
                connection.Dispose();
            }
            
            _streamConnection.Dispose();
        }

        _disposed = true;
        _disposalTokenSource.Cancel();
    }

    /// <summary>
    /// Returns an object providing access to the KRPC service.
    /// </summary>
    public Services.KRPC.KRPC KRPC => new(this);

    /// <summary>
    /// Synchronously adds a new stream to the server.
    /// </summary>
    /// <param name="expression">The expression for the stream</param>
    /// <param name="start">Whether to start the stream immediately</param>
    /// <typeparam name="T">The type of the data updated by the stream</typeparam>
    /// <returns>The remote stream object</returns>
    internal RemoteStream AddStream<T>(Expression<Func<T>> expression, bool start)
    {
        var result = AddNewStreamRequestToQueue(expression, start);
        return result.WaitForResult(_disposalTokenSource.Token) 
               ?? throw new StreamCreationException("Received null stream creation result");
    }
    
    /// <summary>
    /// Asynchronously adds a new stream to the server.
    /// </summary>
    /// <param name="expression">The expression for the stream</param>
    /// <param name="start">Whether to start the stream immediately</param>
    /// <typeparam name="T">The type of the data updated by the stream</typeparam>
    /// <returns>The remote stream object</returns>
    internal async Task<RemoteStream> AddStreamAsync<T>(Expression<Func<T>> expression, bool start)
    {
        var result = AddNewStreamRequestToQueue(expression, start);
        return await result.WaitForResultAsync(_disposalTokenSource.Token)
               ?? throw new StreamCreationException("Received null stream creation result");
    }

    /// <summary>
    /// Synchronously removes a stream from the server.
    /// </summary>
    /// <param name="streamId">The ID of the stream to remove</param>
    internal void RemoveStream(ulong streamId)
    {
        var result = AddRemoveStreamRequestToQueue(streamId);
        result.WaitForCompletion(_disposalTokenSource.Token);
    }

    /// <summary>
    /// Asynchronously removes a stream from the server.
    /// </summary>
    /// <param name="streamId">The ID of the stream to remove</param>
    internal async Task RemoveStreamAsync(ulong streamId)
    {
        var result = AddRemoveStreamRequestToQueue(streamId);
        await result.WaitForCompletionAsync(_disposalTokenSource.Token);
    }

    /// <summary>
    /// Synchronously invokes a procedure that doesn't have a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    internal void Invoke(string service, string procedure, object?[]? arguments = null)
    {
        CheckDisposed();
        var result = AddRpcRequestToQueue(service, procedure, arguments);
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
    internal TResponse? Invoke<TResponse>(string service, string procedure, object?[]? arguments = null)
    {
        CheckDisposed();
        var result = AddRpcRequestToQueue<TResponse>(service, procedure, arguments);
        return result.WaitForResult(_disposalTokenSource.Token);
    }

    /// <summary>
    /// Asynchronously invokes a procedure that doesn't have a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    internal async Task InvokeAsync(string service, string procedure, object?[]? arguments = null)
    {
        CheckDisposed();
        var result = AddRpcRequestToQueue(service, procedure, arguments);
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
    internal async Task<TResponse?> InvokeAsync<TResponse>(string service, string procedure, object?[]? arguments = null)
    {
        CheckDisposed();
        var result = AddRpcRequestToQueue<TResponse>(service, procedure, arguments);
        return await result.WaitForResultAsync(_disposalTokenSource.Token);
    }

    private ProcedureResult<T> AddRpcRequestToQueue<T>(string service, string procedure, object?[]? arguments = null)
    {
        // Set up the request and result object
        var request = new ReturningProcedureRequest(typeof(T), service, procedure, arguments);
        var result = new ProcedureResult<T>();

        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        // Add the request to the queue
        _rpcRequests.Add(request);

        return result;
    }

    private ProcedureResult AddRpcRequestToQueue(string service, string procedure, object?[]? arguments = null)
    {
        var request = new ProcedureRequest(service, procedure, arguments);
        var result = new ProcedureResult();
        
        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        _rpcRequests.Add(request);

        return result;
    }

    private ProcedureResult<RemoteStream> AddNewStreamRequestToQueue<T>(Expression<Func<T>> expression, bool start)
    {
        var request = new AddStreamRequest(typeof(T), expression, start);
        var result = new ProcedureResult<RemoteStream>();
        
        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        _streamRequests.Add(request);

        return result;
    }

    private ProcedureResult AddRemoveStreamRequestToQueue(ulong streamId)
    {
        var request = new RemoveStreamRequest(streamId);
        return AddExistingStreamRequestToQueue(request);
    }
    
    private ProcedureResult AddExistingStreamRequestToQueue(ExistingStreamRequest request)
    {
        var result = new ProcedureResult();
        
        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        _streamRequests.Add(request);

        return result;
    }

    private void CheckDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }
    
    private void LogStartupInformation(ConnectionConfig config)
    {
        _logger.LogInformation("Initialising connection to kRPC server:");
        _logger.LogInformation("IP: {ipAddress}", config.Address);
        _logger.LogInformation("Stream port: {streamPort}", config.StreamPort);
        _logger.LogInformation("RPC port: {rpcPort}", config.RpcPort);
        _logger.LogInformation("Client name: {clientName}", config.Name);
    }
}
