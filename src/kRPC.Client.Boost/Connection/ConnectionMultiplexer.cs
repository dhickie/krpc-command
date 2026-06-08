using System.Collections.Concurrent;
using System.Linq.Expressions;
using kRPC.Client.Boost.Config;
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
internal class ConnectionMultiplexer : IDisposable, IConnectionMultiplexer
{
    private readonly StreamConnection _streamConnection;
    private readonly RpcConnection[] _rpcConnections;
    
    private readonly BlockingCollection<StreamRequest> _streamRequests;
    private readonly BlockingCollection<ProcedureRequest> _rpcRequests;
    private readonly ConcurrentDictionary<string, ProcedureResult> _results;
    
    private readonly ILogger<ConnectionMultiplexer> _logger;

    private readonly CancellationTokenSource _disposalTokenSource = new();
    private bool _disposed;

    /// <summary>
    /// Creates a connection multiplexer that manages one or more connections to a kRPC server.
    /// All interaction with kRPC starts with an instance of this class.
    /// </summary>
    /// <param name="config">The configuration to use with the client. Uses all default values if left null.</param>
    /// <param name="loggerFactory">The optional ILoggerFactory implementation to use when logging</param>
    public ConnectionMultiplexer(ClientConfig? config = null, ILoggerFactory? loggerFactory = null)
    {
        try
        {
            if (loggerFactory != null)
                LogManager.LoggerFactory = loggerFactory;
            _logger = LogManager.GetLogger<ConnectionMultiplexer>();
            config ??= new ClientConfig();
            config.Validate();

            _streamRequests = new BlockingCollection<StreamRequest>();
            _rpcRequests = new BlockingCollection<ProcedureRequest>();
            _results = new ConcurrentDictionary<string, ProcedureResult>();

            LogStartupInformation(config);

            // Create the stream connection - we intentionally keep a single stream connection to ensure that all stream
            // requests are passed through the same TCP connection, which the server has associated with the streaming
            // TCP connection
            _logger.LogInformation("Establishing stream connection");
            var streamConnName = $"{config.Multiplexer.ClientName}_stream_1";
            _streamConnection = new StreamConnection(this, config.Connection, streamConnName, _streamRequests, _results);

            // Create the RPC connections
            _rpcConnections = new RpcConnection[config.Multiplexer.NumRpcConnections];
            for (var i = 0; i < config.Multiplexer.NumRpcConnections; i++)
            {
                var connName = $"{config.Multiplexer.ClientName}_rpc_{i+1}";
                _logger.LogInformation("Establishing RPC connection {connectionNumber} of {numConnections}", 
                    i, 
                    config.Multiplexer.NumRpcConnections);
                _rpcConnections[0] = new RpcConnection(this, config.Connection, connName, _rpcRequests, _results);
            }
            
            StreamManager.Initialise(this, config.Stream);
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

    /// <inheritdoc/>
    public Services.KRPC.KRPC KRPC => new(this);

    /// <inheritdoc/>
    public Services.SpaceCenter.SpaceCenter SpaceCenter => new(this);

    /// <inheritdoc/>
    public RemoteStream AddStream<T>(Expression<Func<T>> expression, bool start)
    {
        var result = AddNewStreamRequestToQueue(expression, start);
        return result.WaitForResult(_disposalTokenSource.Token) 
               ?? throw new StreamCreationException("Received null stream creation result");
    }
    
    /// <inheritdoc/>
    public async Task<RemoteStream> AddStreamAsync<T>(Expression<Func<T>> expression, bool start)
    {
        var result = AddNewStreamRequestToQueue(expression, start);
        return await result.WaitForResultAsync(_disposalTokenSource.Token)
               ?? throw new StreamCreationException("Received null stream creation result");
    }

    /// <inheritdoc/>
    public void RemoveStream(ulong streamId)
    {
        var result = AddRemoveStreamRequestToQueue(streamId);
        result.WaitForCompletion(_disposalTokenSource.Token);
    }

    /// <inheritdoc/>
    public async Task RemoveStreamAsync(ulong streamId)
    {
        var result = AddRemoveStreamRequestToQueue(streamId);
        await result.WaitForCompletionAsync(_disposalTokenSource.Token);
    }

    /// <inheritdoc/>
    public void Invoke(string service, string procedure, ProcedureArgument[]? arguments = null)
    {
        CheckDisposed();
        var result = AddRpcRequestToQueue(service, procedure, arguments);
        result.WaitForCompletion(_disposalTokenSource.Token);
    }
    
    /// <inheritdoc/>
    public TResponse? Invoke<TResponse>(string service, string procedure, ProcedureArgument[]? arguments = null)
    {
        CheckDisposed();
        var result = AddRpcRequestToQueue<TResponse>(service, procedure, arguments);
        return result.WaitForResult(_disposalTokenSource.Token);
    }

    /// <inheritdoc/>
    public async Task InvokeAsync(string service, string procedure, ProcedureArgument[]? arguments = null)
    {
        CheckDisposed();
        var result = AddRpcRequestToQueue(service, procedure, arguments);
        await result.WaitForCompletionAsync(_disposalTokenSource.Token);
    }

    /// <inheritdoc/>
    public async Task<TResponse?> InvokeAsync<TResponse>(string service, string procedure, ProcedureArgument[]? arguments = null)
    {
        CheckDisposed();
        var result = AddRpcRequestToQueue<TResponse>(service, procedure, arguments);
        return await result.WaitForResultAsync(_disposalTokenSource.Token);
    }

    private ProcedureResult<T> AddRpcRequestToQueue<T>(string service, string procedure, ProcedureArgument[]? arguments = null)
    {
        // Set up the request and result object
        var request = new ReturningProcedureRequest(typeof(T), service, procedure, arguments);
        var result = new ProcedureResult<T>();

        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        // Add the request to the queue
        request.QueuedAt = DateTimeOffset.UtcNow;
        _rpcRequests.Add(request);

        return result;
    }

    private ProcedureResult AddRpcRequestToQueue(string service, string procedure, ProcedureArgument[]? arguments = null)
    {
        var request = new ProcedureRequest(service, procedure, arguments);
        var result = new ProcedureResult();
        
        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        request.QueuedAt = DateTimeOffset.UtcNow;
        _rpcRequests.Add(request);

        return result;
    }

    private ProcedureResult<RemoteStream> AddNewStreamRequestToQueue<T>(Expression<Func<T>> expression, bool start)
    {
        var request = new AddStreamRequest(typeof(T), expression, start);
        var result = new ProcedureResult<RemoteStream>();
        
        if (!_results.TryAdd(request.RequestId, result))
            throw new ProcedureException("Duplicate key in response dictionary");
        
        request.QueuedAt = DateTimeOffset.UtcNow;
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
        
        request.QueuedAt = DateTimeOffset.UtcNow;
        _streamRequests.Add(request);

        return result;
    }

    private void CheckDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }
    
    private void LogStartupInformation(ClientConfig config)
    {
        _logger.LogInformation("Initialising connection to kRPC server:");
        _logger.LogInformation("IP: {ipAddress}", config.Connection.Address);
        _logger.LogInformation("Stream port: {streamPort}", config.Connection.StreamPort);
        _logger.LogInformation("RPC port: {rpcPort}", config.Connection.RpcPort);
        _logger.LogInformation("Client name: {clientName}", config.Multiplexer.ClientName);
        
        _logger.LogDebug("Client configuration:\n{ClientConfig}", config);
    }
}
