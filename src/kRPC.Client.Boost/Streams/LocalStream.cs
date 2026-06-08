using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Helpers;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;

namespace kRPC.Client.Boost.Streams;

/// <summary>
/// LocalStream encapsulates the local state of a server side stream that can be used by multiple subscribers.
/// It can be torn down, removing the stream from the server, and then re-initialised without re-providing the expression
/// that retrieves the desired data. This type is not threadsafe.
/// </summary>
/// <typeparam name="T">The datatype that's contained in the stream</typeparam>
[SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
internal sealed class LocalStream<T> : LocalStream
{
    private bool _initialised;
    private readonly ReaderWriterLockSlim _initLock = new();
    private readonly IConnectionMultiplexer _connection;
    private readonly Expression<Func<T>> _expression;
    private object? _value;

    /// <summary>
    /// Used in testing when simulating race conditions - should not be used in application code
    /// </summary>
    internal int NumInitLockWriteWaiters => _initLock.WaitingWriteCount;
    
    /// <summary>
    /// Register a stream with the provided expression.
    /// </summary>
    /// <param name="connection">The kRPC connection.</param>
    /// <param name="expression">The expression to register</param>
    public LocalStream(IConnectionMultiplexer connection, Expression<Func<T>> expression) : base(typeof(T))
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

        Sync.WithWriteLock(_initLock, () => 
        {
            if (_initialised)
                return;

            RemoteStream = _connection.AddStream(_expression, true);
            _initialised = true;
        });
    }
    
    /// <inheritdoc/>
    public override void TearDown()
    {
        if (!_initialised)
            return;

        Sync.WithWriteLock(_initLock, () =>
        {
            if (!_initialised)
                return;

            RemoteStream?.Remove();
            RemoteStream = null;
            _initialised = false;
        });
    }

    /// <summary>
    /// Gets the current value of the stream.
    /// </summary>
    /// <param name="value">The value as an out parameter</param>
    /// <returns>Whether the value was successfully obtained</returns>
    public bool TryGet(out T? value)
    {
        return TryGet<T>(out value);
    }
    
    protected override bool TryGetImpl(out object? value)
    {
        var result = false;
        object? innerValue = null; 
        
        Sync.WithReadLock(_initLock, () =>
        {
            if (!_initialised)
            {
                result = false;
                return;
            }

            StaticMethodInjector.DoWork(RemoteId);
            innerValue = _value;
            result = true;
        });
        
        value = innerValue;
        return result;
    }
    
    protected override bool TrySetImpl(object? value)
    {
        var result = false;
        
        Sync.WithReadLock(_initLock, () =>
        {
            if (!_initialised)
                return;

            StaticMethodInjector.DoWork(RemoteId);
            _value = value;
            result = true;
        });

        return result;
    }
}

internal abstract class LocalStream(Type dataType)
{
    protected RemoteStream? RemoteStream;
    public ulong? RemoteId => RemoteStream?.Id;
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
            throw new InvalidOperationException("Cannot remove a stream subscriber from a stream with no subscribers");
        
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
    public bool TryGet<T>(out T? value)
    {
        var requestedType = typeof(T);
        if (requestedType != dataType)
            throw new ArgumentException(
                $"Attempt to get stream value of type {requestedType.Name} from stream containing data type {dataType.Name}");

        var result = TryGetImpl(out var innerValue);
        value = (T?)innerValue;
        return result;
    }

    /// <summary>
    /// Tries to set the current value of the data contained in the stream.
    /// This should only be called by the stream manager after receiving an update from the server.
    /// </summary>
    /// <param name="value">The value to set for the stream</param>
    /// <returns>Whether the value was successfully set</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown if the type of the provided value doesn't match the data type contained in the stream.
    /// </exception>
    public bool TrySet(object? value)
    {
        var valueType = value?.GetType();
        if (valueType != null && valueType != dataType)
            throw new ArgumentException(
                $"Attempt to set stream value of type {valueType.Name} on a stream containing data type {dataType.Name}");

        return TrySetImpl(value);
    }
    
    /// <summary>
    /// Teardown the stream and remove it from the server, if it is currently initialised.
    /// </summary>
    public abstract void TearDown();
    
    /// <summary>
    /// Initialises the stream with the server, if it hasn't been already.
    /// </summary>
    public abstract void InitialiseStream();
    
    protected abstract bool TryGetImpl(out object? value);

    protected abstract bool TrySetImpl(object? value);
}
