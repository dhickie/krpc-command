namespace KrpcCommand.Manoeuvres;

/// <summary>
/// Provides logging capabilities during manoeuvre execution.
/// Log messages are displayed in the in-game UI.
/// </summary>
public class ManoeuvreLogger
{
    private readonly List<string> _messages = new();
    private readonly object _lock = new();

    /// <summary>
    /// Callback invoked when a new log message is added.
    /// Used by the UI to update the log display.
    /// </summary>
    public event Action<string>? OnLog;

    /// <summary>
    /// Log a message during manoeuvre execution.
    /// </summary>
    public void Log(string message)
    {
        var timestamped = $"[{DateTime.Now:HH:mm:ss}] {message}";
        lock (_lock)
        {
            _messages.Add(timestamped);
        }
        OnLog?.Invoke(timestamped);
    }

    /// <summary>
    /// Get all log messages.
    /// </summary>
    public IReadOnlyList<string> Messages
    {
        get
        {
            lock (_lock)
            {
                return _messages.ToList();
            }
        }
    }

    /// <summary>
    /// Clear all log messages.
    /// </summary>
    public void Clear()
    {
        lock (_lock)
        {
            _messages.Clear();
        }
    }
}
