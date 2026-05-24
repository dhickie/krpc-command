using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Extension methods for SpaceCenter service.
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// Create an instance of the SpaceCenter service.
    /// </summary>
    public static SpaceCenter SpaceCenter(this ConnectionMultiplexer connection)
    {
        return new SpaceCenter(connection);
    }
}
