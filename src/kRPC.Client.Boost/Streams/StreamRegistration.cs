using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using KRPC.Client;

namespace kRPC.Client.Boost.Streams;

/// <summary>
/// StreamRegistration represents a stream from the server that can be used by multiple subscribers. It can be
/// town down, removing the stream from the server, and then re-initialised without re-providing the expression
/// that retrieves the desired data.
/// </summary>
/// <typeparam name="T">The datatype that's contained in the stream</typeparam>
[SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
internal sealed class StreamRegistration<T> : StreamRegistration
{
    private bool _initialised;
    private readonly ReaderWriterLockSlim _initLock = new();
    private readonly Connection _connection;
    private readonly Expression<Func<T>> _expression;
    private Stream<T> _stream;
    
    /// <summary>
    /// Register a stream with the provided expression.
    /// </summary>
    /// <param name="connection">The kRPC connection.</param>
    /// <param name="expression">The expression to register</param>
    public StreamRegistration(Connection connection, Expression<Func<T>> expression) : base(typeof(T))
    {
        _connection = connection;
        _expression = expression;
        
        InitialiseStream();
    }

    /// <inheritdoc/>
    public override void InitialiseStream()
    {
        if (_initialised)
            return;

        _initLock.EnterWriteLock();
        try
        {
            if (_initialised)
                return;

            _connection.AddStream(_expression);
            _initialised = true;
        }
        finally
        {
            _initLock.ExitWriteLock();
        }
    }
    
    /// <inheritdoc/>
    public override void TearDown()
    {
        if (!_initialised)
            return;

        _initLock.EnterWriteLock();
        try
        {
            if (!_initialised)
                return;

            _stream.Remove();
            _stream = null;
            _initialised = false;
        }
        finally
        {
            _initLock.ExitWriteLock();
        }
    }
    
    protected override bool TryGetImpl<TOut>(out TOut value) where TOut : class
    {
        _initLock.EnterReadLock();
        try
        {
            if (!_initialised)
            {
                value = null;
                return false;
            }

            value = _stream.Get() as TOut;
            return true;
        }
        finally
        {
            _initLock.ExitReadLock();
        }
    }
}

internal abstract class StreamRegistration(Type dataType)
{
    public int Subscribers = 1;

    /// <summary>
    /// Adds a subscriber to this stream.
    /// </summary>
    /// <returns>True if this is the first subscriber to the stream, otherwise false</returns>
    public bool AddSubscriber()
    {
        Subscribers++;
        return Subscribers == 1;
    }

    /// <summary>
    /// Removes a subscriber to the stream.
    /// </summary>
    /// <returns>True if the stream still has other subscribers after this operation.</returns>
    /// <exception cref="InvalidOperationException">Thrown is there are no subscribers to remove</exception>
    public bool RemoveSubscriber()
    {
        if (Subscribers == 0)
        {
            throw new InvalidOperationException("Cannot remove a stream subscriber from a stream with no subscribers");
        }
        
        Subscribers--;
        return Subscribers != 0;
    }

    /// <summary>
    /// Tries to get the current value of the stream. Returns false if the stream isn't currently initialised.
    /// </summary>
    /// <param name="value">The value of the stream.</param>
    /// <typeparam name="T">The datatype of the stream.</typeparam>
    /// <returns>Whether the value was successfully obtained.</returns>
    /// <exception cref="ArgumentException">Thrown if the provided data type doesn't match the actual type in the stream</exception>
    public bool TryGet<T>(out T value) where T : class
    {
        var requestedType = typeof(T);
        if (requestedType != dataType)
        {
            throw new ArgumentException(
                $"Attempt to get stream value of type {requestedType.Name} from stream containing data type {dataType.Name}");
        }

        return TryGetImpl(out value);
    }
    
    /// <summary>
    /// Teardown the stream and remove it from the server, if it is currently initialised.
    /// </summary>
    public abstract void TearDown();
    
    /// <summary>
    /// Initialises the stream with the server, if it hasn't been already.
    /// </summary>
    public abstract void InitialiseStream();
    
    protected abstract bool TryGetImpl<T>(out T value) where T : class;
}