using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseLaunchSite = KRPC.Client.Services.SpaceCenter.LaunchSite;

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
