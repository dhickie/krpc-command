using System.Collections.Concurrent;
using kRPC.Client.Boost.Connection.Requests;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Represents a connection to the server that polls for pending RPC requests and actions them in order.
/// </summary>
/// <typeparam name="TRequest">The type of request that this connection processes</typeparam>
internal abstract class PollingConnection<TRequest> : Connection, IDisposable where TRequest : ProcedureRequest
{
    private readonly BlockingCollection<TRequest> _requestQueue;
    private readonly ConcurrentDictionary<string, ProcedureResult> _responses;
    
    private Thread? _pollingThread;
    private bool _disposed;
    private readonly ReaderWriterLockSlim _disposeLock = new();
    private readonly CancellationTokenSource _disposeTokenSource = new();

    private Action<TRequest, ProcedureResult>? _invokeAction;
    
    /// <summary>
    /// Creates a new polling connection.
    /// </summary>
    /// <param name="connection">The top level connection for passing to remote object instances</param>
    /// <param name="config">The configuration for the connection</param>
    /// <param name="requestQueue">The queue of requests for processing</param>
    /// <param name="responses">The collection of responses to pending requests</param>
    protected PollingConnection(IConnection connection, 
        ConnectionConfig config, 
        BlockingCollection<TRequest> requestQueue, 
        ConcurrentDictionary<string, ProcedureResult> responses)
        : base(connection, config)
    {
        _requestQueue = requestQueue;
        _responses = responses;
    }

    /// <summary>
    /// Sets the action that should be invoked when processing a pending request.
    /// </summary>
    /// <param name="action">The action to invoke</param>
    protected void SetInvokeAction(Action<TRequest, ProcedureResult> action)
    {
        _invokeAction = action;
    }

    /// <summary>
    /// Starts the polling thread to poll for new requests until this connection is disposed.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if called before the invoke action has been set</exception>
    protected void StartPolling()
    {
        if (_invokeAction == null)
            throw new InvalidOperationException("Cannot start polling thread if invoke action hasn't been set");
        
        _pollingThread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            PollForRequests();
        });
        _pollingThread.Start();
    }
    
    private void PollForRequests()
    {
        while (true)
        {
            var request = _requestQueue.Take(_disposeTokenSource.Token);
            if (!_responses.TryGetValue(request.RequestId, out var response))
                continue; // TODO Log a warning here, and move on

            _disposeLock.EnterReadLock();
            try
            {
                // Kill the thread if the connection has been disposed
                if (_disposed)
                    break;
                
                _invokeAction!(request, response);
            }
            catch (Exception e)
            {
                // TODO Log an error here
                response.MarkFaulted(e);
            }
            finally
            {
                _disposeLock.ExitReadLock();
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
}