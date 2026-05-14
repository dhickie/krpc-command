using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Net.Sockets;
using Google.Protobuf;
using kRPC.Client.Boost.Connection.Schema;
using kRPC.Client.Boost.Exceptions;
using RequestType = kRPC.Client.Boost.Connection.Schema.ConnectionRequest.Types.Type;
using Exception = System.Exception;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// A connection to the kRPC server. All interaction with kRPC is performed via an instance of this class.
/// </summary>
internal class Connection : IDisposable
{
    private readonly IConnection _connection;
    private readonly BlockingCollection<ProcedureRequest> _requestQueue;
    private readonly ConcurrentDictionary<string, ProcedureResult> _responses;

    private readonly Thread _pollingThread;
    private readonly object _connectionLock = new();
    private bool _disposed;
    
    private readonly TcpClient _rpcClient;
    private readonly NetworkStream _rpcStream;
    private readonly CodedOutputStream _codedRpcStream;
    
    private readonly TcpClient _streamClient;
    private readonly NetworkStream _streamStream;
    private readonly CodedOutputStream _codedStreamStream;
    
    private const int BufferInitialSize = 1 * 1024 * 1024;
    private const int BufferIncreaseSize = 512 * 1024;
    private byte[] _responseBuffer = new byte [BufferInitialSize];

    private readonly ByteString _clientId;

    public Connection(IConnection connection, 
        ConnectionConfig config, 
        BlockingCollection<ProcedureRequest> requestQueue, 
        ConcurrentDictionary<string, ProcedureResult> responses)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(config.RpcPort);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(config.StreamPort);

        _connection = connection;
        _requestQueue = requestQueue;
        _responses = responses;

        // Initialise the TCP connections
        _rpcClient = new TcpClient();
        _rpcClient.Connect(config.Address, config.RpcPort);
        _rpcStream = _rpcClient.GetStream();
        _codedRpcStream = new CodedOutputStream(_rpcStream, true);
        
        _streamClient = new TcpClient();
        _streamClient.Connect(config.Address, config.StreamPort);
        _streamStream = _streamClient.GetStream();
        _codedStreamStream = new CodedOutputStream(_streamStream, true);
        
        // Connect to the RPC and Stream servers
        _clientId = Connect(RequestType.Rpc, config.Name);
        Connect(RequestType.Stream);
        
        // TODO setup the stream manager
        
        // Start the polling thread
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
            var request = _requestQueue.Take();
            if (!_responses.TryGetValue(request.RequestId, out var response))
                continue; // TODO Log a warning here, and move on

            try
            {
                if (request.ResultType != null)
                {
                    var result = Invoke(request.ResultType, request.Service, request.Procedure, request.Arguments);
                    response.MarkComplete(result);
                }
                else
                {
                    Invoke(request.Service, request.Procedure, request.Arguments);
                    response.MarkComplete();
                }
            }
            catch (Exception e)
            {
                // TODO Log an error here
                response.MarkFaulted(e);
            }
        }
    }

    /// <summary>
    /// Finalize the connection.
    /// </summary>
    ~Connection()
    {
        Dispose(false);
    }

    /// <summary>
    /// Dispose the connection.
    /// </summary>
    public void Dispose()
    {
        Dispose (true);
        GC.SuppressFinalize (this);
    }

    /// <summary>
    /// Dispose the connection.
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        
        if (disposing)
        {
            _rpcClient.Close();
            _streamClient.Close();
        }
        _disposed = true;
    }

    private void CheckDisposed()
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
    }
    
    private ByteString Connect(RequestType type, string? clientName = null)
    {
        var request = new ConnectionRequest
        {
            Type = type
        };

        switch (type)
        {
            case RequestType.Rpc:
                request.ClientName = clientName ?? throw new ArgumentNullException(nameof(clientName));
                break;
            case RequestType.Stream:
                request.ClientIdentifier = 
                    _clientId ?? throw new Exception("Unable to connect to stream server - no client ID available");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type));
        }

        ConnectionResponse response;
        lock (_connectionLock)
        {
            // Request
            _codedRpcStream.WriteLength(request.CalculateSize());
            request.WriteTo(_codedRpcStream);
            _codedRpcStream.Flush();

            // Response
            var size = ReadMessageData(_rpcStream, ref _responseBuffer);
            response = ConnectionResponse.Parser.ParseFrom(new CodedInputStream(_responseBuffer, 0, size));
        }

        // Check we're successfully connected
        return response.Status != ConnectionResponse.Types.Status.Ok 
            ? throw new ConnectionException(response.Message) 
            : response.ClientIdentifier;
    }

    // TODO Add streaming functionality to connection
    //public Stream<TResult> AddStream<TResult> (Expression<Func<TResult>> expression)
    //{
    //    CheckDisposed ();
    //    
    //    throw new NotImplementedException();
    //}

    /// <summary>
    /// Invoke a remote procedure.
    /// Should not be called directly. This interface is used by service client stubs.
    /// </summary>
    private object Invoke(System.Type resultType, string service, string procedure, IList<object>? arguments = null)
    {
        CheckDisposed();
        var result = Invoke(GetCall(service, procedure, arguments));
        return Codec.Decode(result, resultType, _connection);
    }

    private void Invoke(string service, string procedure, IEnumerable<object>? arguments = null)
    {
        CheckDisposed();
        Invoke(GetCall(service, procedure, arguments));
    }

    private ByteString Invoke(ProcedureCall call)
    {
        var request = new Request();
        request.Calls.Add(call);
        Response response;

        lock (_connectionLock) 
        {
            // Send request to server
            _codedRpcStream.WriteLength(request.CalculateSize());
            request.WriteTo (_codedRpcStream);
            _codedRpcStream.Flush ();
            
            // Receive response
            var size = ReadMessageData (_rpcStream, ref _responseBuffer);
            response = Response.Parser.ParseFrom (new CodedInputStream (_responseBuffer, 0, size));
        }

        AssertSuccess(response);
        return response.Results[0].Value;
    }

    private static ProcedureCall GetCall(string service, string procedure, IEnumerable<object>? arguments = null)
    {
        var call = new ProcedureCall
        {
            Service = service,
            Procedure = procedure
        };

        if (arguments == null)
            return call;
        
        uint position = 0;
        foreach (var value in arguments)
        {
            var encodedValue = Codec.Encode(value);
            var argument = new Argument
            {
                Position = position,
                Value = encodedValue
            };
            call.Arguments.Add (argument);
            position++;
        }

        return call;
    }

    /// <summary>
    /// Return the procedure call message for a remote procedure call.
    /// </summary>
    private static ProcedureCall GetCall (LambdaExpression expression)
    {
        if (ReferenceEquals (expression, null))
            throw new ArgumentNullException (nameof (expression));

        var body = expression.Body;

        if (body is MethodCallExpression methodCallExpression)
            return GetCall (methodCallExpression);

        throw new ArgumentException ("Invalid expression. Must consist of a method call only.");
    }

    private static ProcedureCall GetCall (MethodCallExpression expression)
    {
        // TODO Implement fetching the correct procedure from a MethodCallExpression when we have attributes on procedures
        throw new NotImplementedException();
    }

    /// <summary>
    /// Read the data from a message from the given stream into the given buffer.
    /// May reallocate the buffer if it is too small to receive the message.
    /// Returns the length of the message in bytes.
    /// If a stopEvent is specified, this method will return 0 if the event is triggered.
    /// </summary>
    private static int ReadMessageData (System.IO.Stream stream, ref byte[] buffer, EventWaitHandle? stopEvent = null)
    {
        var stop = stopEvent != null && stopEvent.WaitOne (0);
        var bufferSize = 0;
        var messageSize = 0;

        // Read the offset and size of the message data
        while (!stop) 
        {
            bufferSize += stream.Read (buffer, bufferSize, 1);
            stop |= stopEvent != null && stopEvent.WaitOne (0);
            try 
            {
                var codedStream = new CodedInputStream (buffer, 0, bufferSize);
                messageSize = (int)codedStream.ReadUInt32 ();
                stop |= stopEvent != null && stopEvent.WaitOne (0);
                break;
            } 
            catch (InvalidProtocolBufferException) 
            {
                // TODO At least log some som info if this happens
            }
        }
        
        if (stop)
            return 0;

        // Read the response data
        bufferSize = 0;
        while (!stop && bufferSize < messageSize) 
        {
            // Increase the size of the buffer if the remaining space is low
            if (buffer.Length - bufferSize < BufferIncreaseSize) 
            {
                var newBuffer = new byte [buffer.Length + BufferIncreaseSize];
                Array.Copy (buffer, newBuffer, bufferSize);
                buffer = newBuffer;
            }
            bufferSize += stream.Read (buffer, bufferSize, messageSize - bufferSize);
            stop |= stopEvent != null && stopEvent.WaitOne (0);
        }
        
        return stop ? 0 : messageSize;
    }
    
    private static void AssertSuccess(Response response)
    {
        if (response.Error != null)
            throw GetException (response.Error);
        
        if (response.Results[0].Error != null)
            throw GetException (response.Results[0].Error);
    }

    private static Exception GetException (Error error)
    {
        var message = error.Description;
        if (error.StackTrace.Length > 0) 
        {
            var newline = Environment.NewLine;
            message += newline + "Server stack trace: " + newline + error.StackTrace;
        }

        if (error.Service.Length <= 0 || error.Name.Length <= 0) 
            return new RemoteException(message);
        
        var key = error.Service + "." + error.Name;
        return key switch
        {
            "KRPC.InvalidOperationException" => new InvalidOperationException(message),
            "KRPC.ArgumentException" => new ArgumentException(string.Empty, message),
            "KRPC.ArgumentNullException" => new ArgumentNullException(string.Empty, message),
            "KRPC.ArgumentOutOfRangeException" => new ArgumentOutOfRangeException(string.Empty, message),
            _ => new RemoteException(message)
        };
    }
}