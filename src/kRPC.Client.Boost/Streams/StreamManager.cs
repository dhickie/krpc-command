using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using KRPC.Client;

namespace kRPC.Client.Boost.Streams;

[SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
internal static class StreamManager
{
    // TODO make these configurable
    private const int CompactionIntervalSeconds = 10;
    private const int MaxDictionarySize = 8192;
    private const int MaxDictionarySizeIncreaseInterval = 512;
    private static int _currentMaxDictionarySize = 1024;

    private static bool _initialised;
    private static readonly object InitLock = new();
    private static Connection _connection;
    private static Thread _compactionThread;
    private static readonly ReaderWriterLockSlim CompactionLock = new();
    private static readonly ConcurrentDictionary<string, object> Locks = new();
    private static readonly ConcurrentDictionary<string, StreamRegistration> Streams = new();

    public static void Initialise(Connection connection)
    {
        if (_initialised)
            return;

        lock (InitLock)
        {
            if (_initialised)
                return;
            
            _connection = connection;
            _compactionThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                CompactionLoop();
            });
            _compactionThread.Start();
            _initialised = true;
        }
    }
    
    public static void AddSubscription<T>(string key, LambdaExpression expression) where T : class
    {
        ValidateState();

        // Any number of threads can enter in read mode, unless compaction is in progress and has a write lock or 
        // is about to start and is waiting to obtain a write lock.
        // We only want to "stop the world" when compacting the lock and stream dictionaries.
        CompactionLock.EnterReadLock();
        try
        {
            AddSubscriptionImpl<T>(key, null, expression);
        }
        finally
        {
            CompactionLock.ExitReadLock();
        }
    }

    public static void AddSubscription<T>(string key, Expression<Func<T>> expression) where T : class
    {
        ValidateState();

        CompactionLock.EnterReadLock();
        try
        {
            AddSubscriptionImpl(key, expression, null);
        }
        finally
        {
            CompactionLock.ExitReadLock();
        }
    }

    private static void AddSubscriptionImpl<T>(string key, 
        Expression<Func<T>> expression, 
        LambdaExpression lambdaExpression) where T : class
    {
        // Lock the registration to prevent multiple threads adding or removing
        // subscribers at the same time
        var registrationLock = Locks.GetOrAdd(key, new object());
        lock (registrationLock)
        {
            if (Streams.TryGetValue(key, out var streamRegistration))
            {
                // Increment the subscriber count
                if (streamRegistration.AddSubscriber())
                {
                    // This is the first subscriber - re-initialise the stream
                    streamRegistration.InitialiseStream();
                }
            }
            else
            {
                // Create a new stream
                var registration = expression != null 
                    ? new StreamRegistration<T>(_connection, expression) 
                    : new StreamRegistration<T>(_connection, lambdaExpression);
                if (!Streams.TryAdd(key, registration))
                {
                    // TODO add a more specific exception type
                    throw new Exception("Unable to add new stream registration, this should never happen");
                }
            }
        }
    }

    public static void RemoveSubscription(string key)
    {
        ValidateState();

        CompactionLock.EnterReadLock();
        try
        {
            RemoveSubscriptionImpl(key);
        }
        finally
        {
            CompactionLock.ExitReadLock();
        }
    }

    private static void RemoveSubscriptionImpl(string key)
    {
        // If there's no lock for the registration, then there can't be any stream to remove the subscription from
        // so we ignore the request
        if (!Locks.TryGetValue(key, out var registrationLock)) 
            return;
        
        lock (registrationLock)
        {
            if (!Streams.TryGetValue(key, out var streamRegistration)) 
                return;

            if (streamRegistration.RemoveSubscriber()) 
                return;
            
            // The stream doesn't have any more subscribers - remove it
            streamRegistration.TearDown();
        }
    }

    public static bool TryGet<T>(string key, out T value) where T : class
    {
        ValidateState();
        
        if (Streams.TryGetValue(key, out var streamRegistration))
        {
            try
            {
                return streamRegistration.TryGet(out value);
            }
            catch
            {
                // The get can fail if there's a server side issue or if the stream has been closed elsewhere.
                // If this happens, just return false.
                // TODO Add logging
                value = null;
                return false;
            }
        }

        value = null;
        return false;
    }

    private static void ValidateState()
    {
        if (!_initialised)
            throw new InvalidOperationException("StreamManager must be initialised before use");
    }

    private static void CompactionLoop()
    {
        var sw = new Stopwatch();
        sw.Start();
        
        var nextCycle = sw.Elapsed + TimeSpan.FromSeconds(CompactionIntervalSeconds);
        while (true)
        {
            try
            {
                if (sw.Elapsed > nextCycle)
                    continue; // If the next cycle was immediately due, then skip it TODO log a warning here

                Thread.Sleep(nextCycle - sw.Elapsed);
                CompactDictionaries();
            }
            finally
            {
                nextCycle += TimeSpan.FromSeconds(CompactionIntervalSeconds);
            }
        }
    }

    private static void CompactDictionaries()
    {
        if (Locks.Count <= _currentMaxDictionarySize)
            return;
        
        // Obtain the write lock - this prevents any read locks from being acquired and waits until
        // all threads inside the lock have exited
        CompactionLock.EnterWriteLock();

        try
        {
            // Check again in case another timer execution did a compaction while waiting for the lock
            if (Locks.Count <= _currentMaxDictionarySize)
                return;

            foreach (var key in Streams.Keys)
            {
                if (!Streams.TryGetValue(key, out var streamRegistration))
                    continue;

                if (streamRegistration.Subscribers > 0)
                    continue;

                var lockRemoved = Locks.TryRemove(key, out _);
                var streamRemoved = Streams.TryRemove(key, out _);

                if (!lockRemoved || !streamRemoved)
                    throw new Exception("Unabled to removed lock or stream from dictionaries during compaction");
            }
            
            // If the dictionary count is still above the limit, then increase the limit if possible
            if (Locks.Count < _currentMaxDictionarySize) 
                return;
            
            var nextMax = _currentMaxDictionarySize + MaxDictionarySizeIncreaseInterval;
            if (nextMax > MaxDictionarySize)
            {
                // TODO Log a warning here
            }
                
            _currentMaxDictionarySize = nextMax;
        }
        finally
        {
            CompactionLock.ExitWriteLock();
        }
    }
}

[SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
internal sealed class StreamRegistration<T> : StreamRegistration
{
    private bool _initialised;
    private readonly ReaderWriterLockSlim _initLock = new();
    private readonly Connection _connection;
    private readonly Expression<Func<T>> _expression;
    private readonly LambdaExpression _lambdaExpression;
    private Stream<T> _stream;
    
    public StreamRegistration(Connection connection, Expression<Func<T>> expression) : base(typeof(T))
    {
        _connection = connection;
        _expression = expression;
        
        InitialiseStream();
    }
    
    public StreamRegistration(Connection connection, LambdaExpression expression) : base(typeof(T))
    {
        _connection = connection;
        _lambdaExpression = expression;
        
        InitialiseStream();
    }

    public override void InitialiseStream()
    {
        if (_initialised)
            return;

        _initLock.EnterWriteLock();
        try
        {
            if (_initialised)
                return;

            _stream = _expression != null
                ? _connection.AddStream(_expression)
                : _connection.AddStream<T>(_lambdaExpression);
            _initialised = true;
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
}

internal abstract class StreamRegistration(Type dataType)
{
    public int Subscribers = 1;

    // Returns true if this is the first subscriber
    public bool AddSubscriber()
    {
        Subscribers++;
        return Subscribers == 1;
    }

    // Returns true if the stream still has more subscribers, otherwise false
    public bool RemoveSubscriber()
    {
        if (Subscribers == 0)
        {
            throw new InvalidOperationException("Cannot remove a stream subscriber from a stream with no subscribers");
        }
        
        Subscribers--;
        return Subscribers != 0;
    }

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
    
    protected abstract bool TryGetImpl<T>(out T value) where T : class;

    public abstract void TearDown();
    
    public abstract void InitialiseStream();
}