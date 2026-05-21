using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Extension methods for SpaceCenter service.
/// </summary>
public static class ExtensionMethods
{
    /// <summary>
    /// Create an instance of the SpaceCenter service.
    /// </summary>
    public static SpaceCenterService SpaceCenter(this ConnectionMultiplexer connection)
    {
        return new SpaceCenterService(connection);
    }
}
