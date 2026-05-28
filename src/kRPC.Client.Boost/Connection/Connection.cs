using System.Linq.Expressions;
using System.Net.Sockets;
using Google.Protobuf;
using kRPC.Client.Boost.Config;
using kRPC.Client.Boost.Connection.Schema;
using kRPC.Client.Boost.Exceptions;
using Exception = System.Exception;
using RequestType = kRPC.Client.Boost.Connection.Schema.ConnectionRequest.Types.Type;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Represents a connection to the server. Manages the low level kRPC protocol.
/// </summary>
internal abstract class Connection : IDisposable
{
    private readonly ConnectionMultiplexer _connection;

    private readonly object _connectionLock = new();
    private bool _disposed;
    private readonly ReaderWriterLockSlim _disposeLock = new();
    private readonly CancellationTokenSource _disposeTokenSource = new();
    
    private readonly TcpClient _rpcClient;
    private readonly NetworkStream _rpcStream;
    private readonly CodedOutputStream _codedRpcStream;
    
    protected const int BufferInitialSize = 1 * 1024 * 1024;
    private const int BufferIncreaseSize = 512 * 1024;
    private byte[] _responseBuffer = new byte[BufferInitialSize];

    private readonly ByteString _clientId;

    /// <summary>
    /// Create a new connection to the server.
    /// </summary>
    /// <param name="connection">The top level connection object, for passing to decoded remote objects</param>
    /// <param name="config">The configuration of the connection</param>
    /// <param name="connectionName">The name of this connection</param>
    protected Connection(ConnectionMultiplexer connection, ConnectionConfig config, string connectionName)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(config.RpcPort);

        _connection = connection;

        // Initialise the RCP connection
        _rpcClient = new TcpClient();
        _rpcClient.Connect(config.Address, config.RpcPort);
        _rpcStream = _rpcClient.GetStream();
        _codedRpcStream = new CodedOutputStream(_rpcStream, true);
        _clientId = Connect(_codedRpcStream, _rpcStream, ref _responseBuffer, RequestType.Rpc, connectionName);
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
                _rpcClient.Close();
            }

            _disposed = true;
            _disposeTokenSource.Cancel();
        }
        finally
        {
            _disposeLock.ExitWriteLock();
        }
    }
    
    /// <summary>
    /// Connects to the kRPC server.
    /// </summary>
    /// <param name="codedStream">The coded stream used by the TCP connection</param>
    /// <param name="networkStream">The raw network stream used by the TCP connection</param>
    /// <param name="buffer">The byte buffer for reading from the TCP connection</param>
    /// <param name="type">Whether this is connecting to the RPC or Stream server</param>
    /// <param name="clientName">The name of the client</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Thrown when trying to create an RPC connection with no client name</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if passed an unexpected RequestType</exception>
    /// <exception cref="ConnectionException">Thrown if the client is unable to connect with the server</exception>
    protected ByteString Connect(CodedOutputStream codedStream, 
        System.IO.Stream networkStream,
        ref byte[] buffer,
        RequestType type, 
        string? clientName = null)
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
                    _clientId ?? throw new ConnectionException("No client ID available when connecting to the stream server");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type));
        }

        // Request
        codedStream.WriteLength(request.CalculateSize());
        request.WriteTo(codedStream);
        codedStream.Flush();

        // Response
        var size = ReadMessageData(networkStream, ref buffer);
        var response = ConnectionResponse.Parser.ParseFrom(new CodedInputStream(buffer, 0, size));

        // Check we're successfully connected
        return response.Status != ConnectionResponse.Types.Status.Ok 
            ? throw new ConnectionException(response.Message) 
            : response.ClientIdentifier;
    }

    /// <summary>
    /// Invokes an RPC on the server that returns a result object.
    /// </summary>
    /// <param name="resultType">The type of result returned by the procedure</param>
    /// <param name="service">The service the procedure is in</param>
    /// <param name="procedure">The name of the procedure</param>
    /// <param name="arguments">Arguments to the procedure</param>
    /// <returns>The result object</returns>
    protected object? Invoke(System.Type resultType, string service, string procedure, IList<object?>? arguments = null)
    {
        var result = Invoke(GetCall(service, procedure, arguments));
        return Codec.Decode(result, resultType, _connection);
    }

    /// <summary>
    /// Invokes an RPC on the server that does not return a result object.
    /// </summary>
    /// <param name="service">The service the procedure is in</param>
    /// <param name="procedure">The name of the procedure</param>
    /// <param name="arguments">Arguments to the procedure</param>
    protected void Invoke(string service, string procedure, IEnumerable<object?>? arguments = null)
    {
        Invoke(GetCall(service, procedure, arguments));
    }
    
    /// <summary>
    /// Read the data for a message from a stream.
    /// Continues to read until an entire message has been received.
    /// May reallocate the buffer if it is too small to receive the message.
    /// </summary>
    /// <param name="stream">The stream to read the message from</param>
    /// <param name="buffer">The byte buffer to read the message into</param>
    /// <param name="cancellationToken">The cancellation token for the operation</param>
    /// <returns>The size of the read message in bytes, or 0 if the cancellation token is canceled</returns>
    protected static int ReadMessageData(System.IO.Stream stream, ref byte[] buffer, CancellationToken? cancellationToken = null)
    {
        var bufferSize = 0;
        var messageSize = 0;

        // Read the offset and size of the message data
        while (!Stop()) 
        {
            bufferSize += stream.Read(buffer, bufferSize, 1);
            try 
            {
                var codedStream = new CodedInputStream(buffer, 0, bufferSize);
                messageSize = (int)codedStream.ReadUInt32();
                break;
            }
            catch (InvalidProtocolBufferException) 
            {
            }
        }
        
        if (Stop())
            return 0;

        // Read the response data
        bufferSize = 0;
        while (!Stop() && bufferSize < messageSize) 
        {
            // Increase the size of the buffer if the remaining space is low
            if (buffer.Length - bufferSize < BufferIncreaseSize) 
            {
                var newBuffer = new byte[buffer.Length + BufferIncreaseSize];
                Array.Copy(buffer, newBuffer, bufferSize);
                buffer = newBuffer;
            }
            bufferSize += stream.Read(buffer, bufferSize, messageSize - bufferSize);
        }
        
        return Stop() ? 0 : messageSize;

        bool Stop()
        {
            return cancellationToken?.IsCancellationRequested ?? false;
        }
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
            request.WriteTo(_codedRpcStream);
            _codedRpcStream.Flush();
            
            // Receive response
            var size = ReadMessageData(_rpcStream, ref _responseBuffer);
            response = Response.Parser.ParseFrom(new CodedInputStream(_responseBuffer, 0, size));
        }

        AssertSuccess(response);
        return response.Results[0].Value;
    }

    private static ProcedureCall GetCall(string service, string procedure, IEnumerable<object?>? arguments = null)
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
            call.Arguments.Add(argument);
            position++;
        }

        return call;
    }

    /// <summary>
    /// Return the procedure call message for a remote procedure call.
    /// </summary>
    private static ProcedureCall GetCall(LambdaExpression expression)
    {
        if (ReferenceEquals(expression, null))
            throw new ArgumentNullException(nameof(expression));

        var body = expression.Body;

        if (body is MethodCallExpression methodCallExpression)
            return GetCall(methodCallExpression);

        throw new ArgumentException("Invalid expression. Must consist of a method call only.");
    }

    private static ProcedureCall GetCall(MethodCallExpression expression)
    {
        // TODO Implement fetching the correct procedure from a MethodCallExpression when we have attributes on procedures
        throw new NotImplementedException();
    }
    
    private static void AssertSuccess(Response response)
    {
        if (response.Error != null)
            throw GetException(response.Error);
        
        if (response.Results[0].Error != null)
            throw GetException(response.Results[0].Error);
    }

    private static Exception GetException(Error error)
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
