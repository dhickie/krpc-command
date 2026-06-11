using Microsoft.Extensions.Logging;

namespace kRPC.Client.Boost.Logging;

internal static class LogManager
{
    public static ILoggerFactory LoggerFactory { get; set; }

    static LogManager()
    {
        LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => builder.AddConsole());
    }

    public static ILogger<T> GetLogger<T>()
    {
        if (LoggerFactory == null)
            throw new InvalidOperationException("Cannot create a logger before the logger factory is initialised");
        
        return LoggerFactory.CreateLogger<T>();
    }

    public static ILogger GetLogger(Type classType)
    {
        if (LoggerFactory == null)
            throw new InvalidOperationException("Cannot create a logger before the logger factory is initialised");
        
        return LoggerFactory.CreateLogger(classType.FullName ?? classType.Name);
    }
}