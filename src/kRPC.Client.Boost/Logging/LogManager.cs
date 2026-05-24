using Microsoft.Extensions.Logging;

namespace kRPC.Client.Boost.Logging;

internal class LogManager
{
    private static ILoggerFactory? _loggerFactory;

    public LogManager(ILoggerFactory? loggerFactory)
    {
        _loggerFactory = loggerFactory ?? LoggerFactory.Create(builder => builder.AddConsole());
    }

    public static ILogger GetLogger<T>()
    {
        if (_loggerFactory == null)
            throw new InvalidOperationException("Cannot create a logger before the logger factory is initialised");
        
        return _loggerFactory.CreateLogger<T>();
    }
}