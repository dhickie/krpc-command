using System.Linq.Expressions;
using Google.Protobuf;
using kRPC.Client.Boost.Configuration;
using kRPC.Client.Boost.Connection.Schema;
using kRPC.Client.Boost.Exceptions;
using kRPC.Client.Boost.Helpers;
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

    private readonly TcpConnection _tcpConnection;

    private readonly ByteString _clientId;

    /// <summary>
    /// Create a new connection to the server.
    /// </summary>
    /// <param name="connection">The top level connection object, for passing to decoded remote objects</param>
    /// <param name="config">The configuration of the connection</param>
    /// <param name="connectionName">The name of this connection</param>
    protected Connection(ConnectionMultiplexer connection, ConnectionConfig config, string connectionName)
    {
        _connection = connection;

        // Initialise the RCP connection
        _tcpConnection = new TcpConnection(config.Address, config.RpcPort);
        _clientId = Connect(RequestType.Rpc, connectionName);
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
        Sync.WithWriteLock(_disposeLock, () => 
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _tcpConnection.Dispose();
            }

            _disposed = true;
        });
    }
    
    /// <summary>
    /// Connects to the kRPC server.
    /// </summary>
    /// <param name="type">Whether this is connecting to the RPC or Stream server</param>
    /// <param name="clientName">The name of the client</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Thrown when trying to create an RPC connection with no client name</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if passed an unexpected RequestType</exception>
    /// <exception cref="ConnectionException">Thrown if the client is unable to connect with the server</exception>
    protected ByteString Connect(RequestType type, string? clientName = null)
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
        _tcpConnection.Send(request);

        // Response
        var response = _tcpConnection.Receive(ConnectionResponse.Parser);

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
    /// <param name="cancellationToken">The cancellation token for cancelling the invocation</param>
    /// <returns>The result object</returns>
    protected object? Invoke(System.Type resultType, 
        string service, 
        string procedure, 
        IList<ProcedureArgument>? arguments, 
        CancellationToken cancellationToken)
    {
        var result = Invoke(GetCall(service, procedure, arguments), cancellationToken);
        return Codec.Decode(result, resultType, _connection);
    }

    /// <summary>
    /// Invokes an RPC on the server that does not return a result object.
    /// </summary>
    /// <param name="service">The service the procedure is in</param>
    /// <param name="procedure">The name of the procedure</param>
    /// <param name="arguments">Arguments to the procedure</param>
    /// <param name="cancellationToken">The cancellation token for cancelling the invocation</param>
    protected void Invoke(string service, 
        string procedure, 
        IEnumerable<ProcedureArgument>? arguments, 
        CancellationToken cancellationToken)
    {
        Invoke(GetCall(service, procedure, arguments), cancellationToken);
    }

    private ByteString Invoke(ProcedureCall call, CancellationToken cancellationToken)
    {
        var request = new Request();
        request.Calls.Add(call);
        Response? response = null;

        Sync.WithReadLock(_disposeLock, () =>
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(Connection));
                
            lock (_connectionLock)
            {
                // Send request to server
                cancellationToken.ThrowIfCancellationRequested();
                _tcpConnection.Send(request);
            
                // Receive response
                cancellationToken.ThrowIfCancellationRequested();
                response = _tcpConnection.Receive(Response.Parser, cancellationToken);
            }
        });

        AssertSuccess(response);
        return response!.Results[0].Value;
    }

    private static ProcedureCall GetCall(string service, string procedure, IEnumerable<ProcedureArgument>? arguments = null)
    {
        var call = new ProcedureCall
        {
            Service = service,
            Procedure = procedure
        };

        if (arguments == null)
            return call;
        
        uint position = 0;
        foreach (var argument in arguments)
        {
            var encodedValue = Codec.Encode(argument.Value, argument.Type);
            var procArgument = new Argument
            {
                Position = position,
                Value = encodedValue
            };
            call.Arguments.Add(procArgument);
            position++;
        }

        return call;
    }

    /// <summary>
    /// Return the protobuf procedure call message for a remote procedure call, for use in creating streams.
    /// </summary>
    /// <param name="expression">The expression to get the call of</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided expression is null</exception>
    /// <exception cref="ArgumentException">Thrown if the provided expression is not valid in creating a stream</exception>
    internal static ProcedureCall GetCall(LambdaExpression expression)
    {
        if (ReferenceEquals(expression, null))
            throw new ArgumentNullException(nameof(expression));

        var parser = new ExpressionParser(expression);
        var call = new ProcedureCall
        {
            Procedure = parser.Procedure,
            Service = parser.Service
        };

        var position = 0u;
        foreach (var argument in parser.Arguments)
        {
            var encodedValue = Codec.Encode(argument.value, argument.type);
            var arg = new Argument
            {
                Position = position,
                Value = encodedValue
            };
            call.Arguments.Add(arg);
            position++;
        }

        return call;
    }
    
    private static void AssertSuccess(Response? response)
    {
        if (response == null)
            throw new ProcedureException("Response object is null");
        
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
