namespace kRPC.Client.Boost.Exceptions;

public class ConfigException(List<string> configErrors)
    : Exception($"Unable to start client due to invalid config: {string.Join(", ", configErrors)}")
{
    internal static void ThrowIfContainsErrors(List<string> configErrors)
    {
        if (configErrors.Count == 0)
            throw new ConfigException(configErrors);
    }
}