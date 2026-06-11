namespace kRPC.Client.Boost.Helpers;

/// <summary>
/// Provides methods for simplifying synchronisation between threads.
/// </summary>
internal static class Sync
{
    /// <summary>
    /// Executes an action after obtaining a read lock on a ReaderWriteLockSlim, and releases it once the action is complete.
    /// </summary>
    /// <param name="lockSlim">The lock to use</param>
    /// <param name="action">The action to perform</param>
    public static void WithReadLock(ReaderWriterLockSlim lockSlim, Action action)
    {
        lockSlim.EnterReadLock();
        try
        {
            action();
        }
        finally
        {
            lockSlim.ExitReadLock();
        }
    }
    
    /// <summary>
    /// Executes an action after obtaining a write lock on a ReaderWriteLockSlim, and releases it once the action is complete.
    /// </summary>
    /// <param name="lockSlim">The lock to use</param>
    /// <param name="action">The action to perform</param>
    public static void WithWriteLock(ReaderWriterLockSlim lockSlim, Action action)
    {
        lockSlim.EnterWriteLock();
        try
        {
            action();
        }
        finally
        {
            lockSlim.ExitWriteLock();
        }
    }
}