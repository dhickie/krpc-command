using System.Collections.Concurrent;
using System.Net.Sockets;
using Google.Protobuf;
using kRPC.Client.Boost.Connection.Requests;
using kRPC.Client.Boost.Connection.Schema;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;
using kRPC.Client.Boost.Streams;
using RequestType = kRPC.Client.Boost.Connection.Schema.ConnectionRequest.Types.Type;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Represents a connection to the server that invokes actions for creating, updating and removing streams from the server
/// from a queue of pending Stream requests. It also receives updates for existing streams and tells the StreamManager
/// to update the local state.
/// </summary>
internal class StreamConnection : PollingConnection<StreamRequest>, IDisposable
{
    private readonly IConnection _connection;
    private readonly Thread _streamThread;
    
    private readonly TcpClient _streamClient;
    private readonly NetworkStream _streamStream;

    private bool _disposed;
    private readonly ReaderWriterLockSlim _disposeLock = new();
    private readonly CancellationTokenSource _disposeTokenSource = new();
    
    private byte[] _streamBuffer = new byte[BufferInitialSize];
    
    private readonly ConcurrentDictionary<ulong, System.Type> _streamTypes = new();
    
    /// <summary>
    /// Create a new Stream connection.
    /// </summary>
    /// <param name="connection">The top level connection for passing to remote object instances</param>
    /// <param name="config">The configuration for the connection</param>
    /// <param name="requestQueue">The queue of pending stream requests</param>
    /// <param name="responses">The collection of response objects</param>
    public StreamConnection(IConnection connection,
        ConnectionConfig config,
        BlockingCollection<StreamRequest> requestQueue,
        ConcurrentDictionary<string, ProcedureResult> responses)
    : base(connection, config, requestQueue, responses)
    {
        _connection = connection;
        
        // Establish the Stream connection once the base connection has established the RPC connection
        _streamClient = new TcpClient();
        _streamClient.Connect(config.Address, config.StreamPort);
        _streamStream = _streamClient.GetStream();
        var codedStreamStream = new CodedOutputStream(_streamStream, true);
        Connect(codedStreamStream, _streamStream, ref _streamBuffer, RequestType.Stream);
        
        // Set the polling function for Stream RPC requests (create stream, remove stream etc.)
        SetInvokeAction(Invoke);
        
        // Setup the stream update thread
        _streamThread = new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            PollForStreamUpdates();
        });
        _streamThread.Start();
        
        // Start the stream RPC polling thread
        StartPolling();
    }

    private void Invoke(StreamRequest request, ProcedureResult response)
    {
        switch (request)
        {
            case AddStreamRequest r:
                HandleAddStream(r, response);
                break;
            case RemoveStreamRequest r:
                HandleRemoveStream(r, response);
                break;
            default:
                throw new NotSupportedException($"Stream request type {request.GetType().Name} is not supported");
        }
    }

    private void HandleAddStream(AddStreamRequest request, ProcedureResult response)
    {
        var result = Invoke(typeof(RemoteStream), request.Service, request.Procedure, request.Arguments);
        var stream = result as RemoteStream;
        
        _streamTypes[stream!.Id] = request.StreamType;
        response.MarkComplete(result);
    }

    private void HandleRemoveStream(RemoveStreamRequest request, ProcedureResult response)
    {
        Invoke(request.Service, request.Procedure, request.Arguments);
        _streamTypes.TryRemove(request.StreamId, out _);
        
        response.MarkComplete();
    }
    
    private void PollForStreamUpdates()
    {
        while (true)
        {
            var size = ReadMessageData(_streamStream, ref _streamBuffer, _disposeTokenSource.Token);
            if (size == 0)
                break; // ReadMessageData returns 0 if cancellation is requested due to disposal

            _disposeLock.EnterReadLock();
            try
            {
                var update = StreamUpdate.Parser.ParseFrom(new CodedInputStream(_streamBuffer, 0, size));

                foreach (var result in update.Results)
                {
                    if (!_streamTypes.TryGetValue(result.Id, out var type))
                        continue;

                    var resultValue = Codec.Decode(result.Result.Value, type, _connection);
                    StreamManager.SetValue(result.Id, resultValue);
                }
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
    ~StreamConnection()
    {
        Dispose(false);
    }

    /// <summary>
    /// Dispose the connection.
    /// </summary>
    public new void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dispose the connection.
    /// </summary>
    private void Dispose(bool disposing)
    {
        _disposeLock.EnterWriteLock();
        try
        {
            if (_disposed)
                return;

            if (disposing)
            {
                base.Dispose();
                _streamClient.Close();
            }

            _disposed = true;
            _disposeTokenSource.Cancel();
        }
        finally
        {
            _disposeLock.ExitWriteLock();
        }
    }
}