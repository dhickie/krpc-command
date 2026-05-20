using KRPC.Client.Services.SpaceCenter;
using BaseLaunchSite = kRPC.Client.Boost.Services.SpaceCenter.LaunchSite;
using EditorFacility = kRPC.Client.Boost.Services.SpaceCenter.EditorFacility;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter LaunchSite object.
/// </summary>
public class LaunchSite
{
    internal readonly BaseLaunchSite Wrapped;

    internal LaunchSite(BaseLaunchSite launchSite)
    {
        Wrapped = launchSite;
    }

    public CelestialBody Body
        => new CelestialBody(Wrapped.Body);

    public EditorFacility EditorFacility
        => Wrapped.EditorFacility;

    public string Name
        => Wrapped.Name;
}
