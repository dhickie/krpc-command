using System.Collections.Concurrent;
using System.Diagnostics;
using kRPC.Client.Boost.Connection.Requests;
using Microsoft.Extensions.Logging;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Represents a connection to the server that polls for pending RPC requests and actions them in order.
/// </summary>
/// <typeparam name="TRequest">The type of request that this connection processes</typeparam>
/// <typeparam name="TConnection">The type of connection that has been established</typeparam>
internal abstract class PollingConnection<TRequest,TConnection> : Connection, IDisposable where TRequest : ProcedureRequest
{
    private readonly BlockingCollection<TRequest> _requestQueue;
    private readonly ConcurrentDictionary<string, ProcedureResult> _responses;
    
    private Thread? _pollingThread;
    private bool _disposed;
    private readonly ReaderWriterLockSlim _disposeLock = new();
    private readonly CancellationTokenSource _disposeTokenSource = new();
    
    private ILogger<TConnection>? _logger;
    private Action<TRequest, ProcedureResult>? _invokeAction;
    private bool _setupComplete;

    /// <summary>
    /// Creates a new polling connection.
    /// </summary>
    /// <param name="connection">The top level connection for passing to remote object instances</param>
    /// <param name="config">The configuration for the connection</param>
    /// <param name="connectionName">The name of this connection</param>
    /// <param name="requestQueue">The queue of requests for processing</param>
    /// <param name="responses">The collection of responses to pending requests</param>
    protected PollingConnection(ConnectionMultiplexer connection, 
        ConnectionConfig config,
        string connectionName,
        BlockingCollection<TRequest> requestQueue, 
        ConcurrentDictionary<string, ProcedureResult> responses)
        : base(connection, config, connectionName)
    {
        _requestQueue = requestQueue;
        _responses = responses;
    }

    /// <summary>
    /// Sets up the connection with data from the derived type.
    /// </summary>
    /// <param name="logger">The logger to use for this connection</param>
    /// <param name="action">The action to invoke</param>
    protected void Setup(ILogger<TConnection> logger, Action<TRequest, ProcedureResult> action)
    {
        _logger = logger;
        _invokeAction = action;
        _setupComplete = true;
    }

    /// <summary>
    /// Starts the polling thread to poll for new requests until this connection is disposed.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if called before the invoke action has been set</exception>
    protected void StartPolling()
    {
        if (!_setupComplete)
            throw new InvalidOperationException("Cannot start polling thread if setup isn't complete");
        
        _pollingThread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            PollForRequests();
        });
        _pollingThread.Start();
    }
    
    private void PollForRequests()
    {
        var sw = new Stopwatch();
        var success = false;
        
        sw.Start();
        
        while (true)
        {
            var request = _requestQueue.Take(_disposeTokenSource.Token);
            LogRequestStart(request);
            var start = sw.Elapsed;
            
            try
            {
                if (!_responses.TryGetValue(request.RequestId, out var response))
                {
                    _logger!.LogWarning(
                        "Response collection did not contain a response for request {RequestId}, skipping request",
                        request.RequestId);
                    continue;
                }

                _disposeLock.EnterReadLock();
                try
                {
                    // Kill the thread if the connection has been disposed
                    if (_disposed)
                        break;

                    _invokeAction!(request, response);
                    success = true;
                }
                catch (Exception e)
                {
                    _logger!.LogError(e, "An exception occured trying to invoke the requested procedure");
                    response.MarkFaulted(e);
                    success = false;
                }
                finally
                {
                    _disposeLock.ExitReadLock();
                }
            }
            finally
            {
                LogRequestEnd(request, sw.Elapsed - start, success);
            }
        }
    }
    
    /// <summary>
    /// Finalize the connection.
    /// </summary>
    ~PollingConnection()
    {
        Dispose();
    }

    /// <summary>
    /// Dispose the connection.
    /// </summary>
    public new void Dispose()
    {
        _disposeLock.EnterWriteLock();
        try
        {
            if (_disposed)
                return;

            _disposed = true;
            _disposeTokenSource.Cancel();
            base.Dispose();
        }
        finally
        {
            _disposeLock.ExitWriteLock();
        }
        
        GC.SuppressFinalize(this);
    }
    
    protected abstract void LogRequestStart(TRequest request);
    
    protected abstract void LogRequestEnd(TRequest request, TimeSpan duration, bool success);
}