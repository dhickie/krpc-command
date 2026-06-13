using System.Net;
using System.Net.Sockets;
using Google.Protobuf;
using kRPC.Client.Boost.Connection.Schema;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Represents a TCP connection to the server on a particular port - either the RPC port or the Stream port.
/// Responsible for sending/receiving messages to/from the server over the low level TCP protocol.
/// </summary>
internal class TcpConnection : IDisposable
{
    private const int BufferInitialSize = 1 * 1024 * 1024;
    private const int BufferIncreaseSize = 512 * 1024;
    private byte[] _responseBuffer = new byte[BufferInitialSize];
    private readonly object _disposeLock = new();
    private bool _disposed;
    
    private readonly TcpClient _client;
    private readonly NetworkStream _inputStream;
    private readonly CodedOutputStream _outputStream;

    /// <summary>
    /// Creates a new TCP connection to the server.
    /// </summary>
    /// <param name="address">The IP address of the server</param>
    /// <param name="port">The port to connect to on the server</param>
    public TcpConnection(IPAddress address, int port)
    {
        _client = new TcpClient();
        _client.Connect(address, port);
        _inputStream = _client.GetStream();
        _outputStream = new CodedOutputStream(_inputStream, true);
    }
    
    /// <summary>
    /// Finalize the TCP connection.
    /// </summary>
    ~TcpConnection()
    {
        Dispose(false);
    }

    /// <summary>
    /// Dispose the TCP connection.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    private void Dispose(bool disposing)
    {
        if (_disposed)
            return;
        
        lock(_disposeLock)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _client.Close();
            }

            _disposed = true;
        };
    }

    /// <summary>
    /// Send a connection request.
    /// </summary>
    /// <param name="request">The request to send</param>
    public void Send(ConnectionRequest request)
    {
        _outputStream.WriteLength(request.CalculateSize());
        request.WriteTo(_outputStream);
        _outputStream.Flush();
    }

    /// <summary>
    /// Send an RPC request.
    /// </summary>
    /// <param name="request">The request to send</param>
    public void Send(Request request)
    {
        _outputStream.WriteLength(request.CalculateSize());
        request.WriteTo(_outputStream);
        _outputStream.Flush();
    }

    /// <summary>
    /// Receive a message from the server. Assumes that the incoming message is of the expected type.
    /// </summary>
    /// <param name="parser">The protobuf parser that parses the incoming bytes</param>
    /// <param name="cancellationToken">The cancellation token to cancel the operation</param>
    /// <typeparam name="T">The type of the received message</typeparam>
    /// <returns>The received message</returns>
    /// <exception cref="OperationCanceledException">Thrown if the cancellation token is cancelled</exception>
    public T Receive<T>(MessageParser<T> parser, CancellationToken cancellationToken = default) where T : IMessage<T>
    {
        var size = ReadMessageData(_inputStream, ref _responseBuffer, cancellationToken);
        if (size == 0)
            throw new OperationCanceledException("Cancellation requested while waiting for response");
        
        return parser.ParseFrom(new CodedInputStream(_responseBuffer, 0, size));
    }
    
    private static int ReadMessageData(System.IO.Stream stream, ref byte[] buffer, CancellationToken? cancellationToken)
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
}