using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using kRPC.Client.Boost.Config;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Exceptions;
using kRPC.Client.Boost.Helpers;
using kRPC.Client.Boost.Logging;
using Microsoft.Extensions.Logging;

namespace kRPC.Client.Boost.Streams;

/// <summary>
/// StreamManager is responsible for ensuring that we only keep a single stream for a particular piece of data,
/// and don't make unnecessary calls out to the server if we know we already have a stream available.
/// It also automatically determines when a stream can be removed from the server, and is fully threadsafe while
/// maintaining optimum performance.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
internal static class StreamManager
{
    private static TimeSpan _compactionInterval;
    private static int _maxDictionarySize;
    private static int _maxDictionarySizeIncreaseInterval;
    private static int _currentMaxDictionarySize;

    private static bool _initialised;
    private static readonly object InitLock = new();
    private static IConnectionMultiplexer? _connection;
    private static CancellationTokenSource? _compactionToken;
    private static Thread? _compactionThread;
    private static readonly ReaderWriterLockSlim CompactionLock = new();
    private static readonly ConcurrentDictionary<string, object> Locks = new();
    private static readonly ConcurrentDictionary<string, LocalStream> Streams = new();
    private static readonly ConcurrentDictionary<ulong, string> IdMap = new();

    private static readonly ILogger Logger = LogManager.GetLogger(typeof(StreamManager));

    /// <summary>
    /// Returns how many writers are waiting to enter the compaction lock. Should only be used by tests.
    /// </summary>
    internal static int NumCompactionLockWriteWaiters => CompactionLock.WaitingWriteCount;

    /// <summary>
    /// Initialises the StreamManager's internal state and starts the compaction thread.
    /// </summary>
    /// <param name="connection">The kRPC connection</param>
    /// <param name="config">The stream configuration to use</param>
    public static void Initialise(IConnectionMultiplexer connection, StreamConfig config)
    {
        if (_initialised)
            return;

        lock (InitLock)
        {
            if (_initialised)
                return;

            MethodInjector.DoWork(nameof(Initialise));
            _connection = connection;
            
            Locks.Clear();
            Streams.Clear();
            IdMap.Clear();
            
            _compactionInterval = config.CompactionInterval;
            _maxDictionarySize = config.MaxDictionarySize;
            _maxDictionarySizeIncreaseInterval = config.MaxDictionarySizeIncreaseInterval;
            _currentMaxDictionarySize = config.InitialDictionarySize;
            _compactionToken = new CancellationTokenSource();
            _compactionThread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                CompactionLoop(_compactionToken.Token);
            });
            _compactionThread.Start();
            _initialised = true;
        }
    }

    /// <summary>
    /// Resets the stream manager into its uninitialised state. Only used by tests to ensure clean state for each test.
    /// </summary>
    public static void Reset()
    {
        if (!_initialised)
            return;
        
        lock (InitLock)
        {
            if (!_initialised)
                return;
            
            // Kill the compaction thread, other state will be overwritten when reinitialised
            _compactionToken!.Cancel();
            SpinWait.SpinUntil(() => !_compactionThread!.IsAlive);
            _initialised = false;
        }
    }

    /// <summary>
    /// Adds a subscription to the stream with the provided key, using the provided expression if the stream
    /// doesn't yet exist.
    /// </summary>
    /// <param name="key">The key to subscribe to</param>
    /// <param name="expression">The expression to use to initialise the stream if it doesn't exist yet</param>
    /// <typeparam name="T">The data type returned by the stream</typeparam>
    public static void AddSubscription<T>(string key, Expression<Func<T>> expression)
    {
        ValidateState();

        // Any number of threads can enter in read mode, unless compaction is in progress and has a write lock or 
        // is about to start and is waiting to obtain a write lock.
        // We only want to "stop the world" when compacting the lock and stream dictionaries.
        Sync.WithReadLock(CompactionLock, () =>
        {
            AddSubscriptionImpl(key, expression);
        });
    }
    
    /// <summary>
    /// Removes a subscription to the stream with the provided key.
    /// </summary>
    /// <param name="key">The key to remove a subscription for</param>
    public static void RemoveSubscription(string key)
    {
        ValidateState();

        Sync.WithReadLock(CompactionLock, () =>
        {
            RemoveSubscriptionImpl(key);
        });
    }
    
    /// <summary>
    /// Tries to get the value of the stream with the provided key.
    /// </summary>
    /// <param name="key">The key of the stream to get the value for</param>
    /// <param name="value">The value of the stream</param>
    /// <typeparam name="T">The datatype returned by the stream</typeparam>
    /// <returns>Whether the value was successfully retrieved</returns>
    public static bool TryGet<T>(string key, out T? value)
    {
        ValidateState();
        
        if (Streams.TryGetValue(key, out var streamRegistration))
            return streamRegistration.TryGet(out value);

        value = default;
        return false;
    }

    /// <summary>
    /// Sets the current value of a stream using its remote stream ID.
    /// </summary>
    /// <param name="remoteId">The remote ID of the stream.</param>
    /// <param name="value">The value to set</param>
    public static void SetValue(ulong remoteId, object? value)
    {
        ValidateState();

        if (!IdMap.TryGetValue(remoteId, out var key))
            Logger.LogInformation("Unable to set stream value - remote ID {remoteId} not found in ID map", remoteId);
        else if (!Streams.TryGetValue(key, out var stream))
            Logger.LogInformation("Unable to set stream value - local stream with key {key} not found in stream collection", key);
        else if (!stream.TrySet(value))
            Logger.LogInformation("Failed to set value of stream with key {key}", key);
    }

    private static void AddSubscriptionImpl<T>(string key, Expression<Func<T>> expression)
    {
        // Lock the registration to prevent multiple threads adding or removing
        // subscribers at the same time
        var registrationLock = Locks.GetOrAdd(key, new object());
        lock (registrationLock)
        {
            if (Streams.TryGetValue(key, out var stream))
            {
                // Increment the subscriber count
                if (stream.AddSubscriber())
                {
                    // This is the first subscriber - re-initialise the stream
                    stream.InitialiseStream();
                    IdMap[stream.RemoteId!.Value] = key;
                }
            }
            else
            {
                // Create a new stream
                var newStream = new LocalStream<T>(_connection!, expression);
                IdMap[newStream.RemoteId!.Value] = key;

                if (Streams.TryAdd(key, newStream)) 
                    return;
                
                const string message = "Failed to add stream to streams collection";
                Logger.LogError(message);
                throw new StreamCreationException(message);
            }
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
            if (!Streams.TryGetValue(key, out var stream))
                return;

            if (stream.RemoveSubscriber())
                return;
            
            // The stream doesn't have any more subscribers - remove it
            IdMap.TryRemove(stream.RemoteId!.Value, out _);
            stream.TearDown();
        }
    }

    private static void ValidateState()
    {
        if (!_initialised)
            throw new InvalidOperationException("StreamManager must be initialised before use");
    }

    private static void CompactionLoop(CancellationToken cancellationToken)
    {
        var sw = new Stopwatch();
        sw.Start();
        
        var nextCycle = sw.Elapsed + _compactionInterval;
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                if (sw.Elapsed > nextCycle)
                {
                    Logger.LogWarning(
                        "Compaction cycle took longer than loop interval - next cycle is due at {nextCycle}, but stopwatch is already at {elapsed}",
                        nextCycle.TotalSeconds,
                        sw.Elapsed.TotalSeconds);
                    continue;
                }

                // Wait until we hit the next cycle or the cancellation token is cancelled
                if (!cancellationToken.WaitHandle.WaitOne((int)(nextCycle - sw.Elapsed).TotalMilliseconds))
                    CompactDictionaries();
            }
            catch (Exception e)
            {
                Logger.LogError(e, "An error occured while trying to perform dictionary compaction");
            }
            finally
            {
                nextCycle += _compactionInterval;
            }
        }
    }

    /// <summary>
    /// We can't remove entries from the lock dictionary while subscriptions are being added/removed without creating
    /// a race condition. If we did nothing, the size of the dictionaries would grow indefinitely, so instead we
    /// perform compaction by periodically "stopping the world" by obtaining the write lock, scan through and remove
    /// any entries that don't have any subscriptions, and then release the lock.
    /// If the size of the dictionaries is still at or above the current size limit, we bump the limit up. This keeps
    /// the size the smallest it can be, and makes it quicker to perform these compaction cycles.
    /// </summary>
    /// <exception cref="Exception">Thrown if we fail to remove an entry from either dictionary. In theory, this should never happen.</exception>
    private static void CompactDictionaries()
    {
        MethodInjector.DoWork($"{nameof(CompactDictionaries)}.Hold");
        MethodInjector.DoWork($"{nameof(CompactDictionaries)}.Start", new Dictionary<string, object>
        {
            {"NumEntries", Streams.Count},
            {"MaxSize", _currentMaxDictionarySize}
        });

        try
        {
            // Max size of 0 just means run compaction on every cycle
            if (Streams.Count <= _currentMaxDictionarySize && _currentMaxDictionarySize > 0)
                return;

            // Obtain the write lock - this prevents any read locks from being acquired and waits until
            // all threads inside the lock have exited
            Sync.WithWriteLock(CompactionLock, () =>
            {
                MethodInjector.DoWork($"{nameof(CompactDictionaries)}.InsideLock", new Dictionary<string, object>
                {
                    {"NumEntries", Streams.Count},
                    {"MaxSize", _currentMaxDictionarySize}
                });
                foreach (var key in Streams.Keys)
                {
                    if (!Streams.TryGetValue(key, out var streamRegistration))
                        continue;

                    if (streamRegistration.Subscribers > 0)
                        continue;

                    var lockRemoved = Locks.TryRemove(key, out _);
                    var streamRemoved = Streams.TryRemove(key, out _);

                    if (!lockRemoved || !streamRemoved)
                        throw new Exception("Unable to remove lock or stream from dictionaries during compaction");
                }

                // If the dictionary count is still above the limit, then increase the limit if possible
                if (Streams.Count < _currentMaxDictionarySize)
                    return;

                var nextMax = _currentMaxDictionarySize + _maxDictionarySizeIncreaseInterval;
                if (nextMax > _maxDictionarySize)
                {
                    Logger.LogWarning(
                        "Lock and stream collections are above max size limit: Max size: {maxSize}, current size: {currentSize}",
                        nextMax,
                        _maxDictionarySize);
                }
                else
                {
                    _currentMaxDictionarySize = nextMax;
                }
            });
        }
        finally
        {
            MethodInjector.DoWork($"{nameof(CompactDictionaries)}.End", new Dictionary<string, object>
            {
                {"NumEntries", Locks.Count},
                {"MaxSize", _currentMaxDictionarySize}
            });
        }
    }
}
