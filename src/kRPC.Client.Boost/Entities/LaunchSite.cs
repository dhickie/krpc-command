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
    internal BaseLaunchSite Internal { get; }

    internal LaunchSite(BaseLaunchSite launchSite)
    {
        Internal = launchSite;
    }
    public CelestialBody Body
        => new CelestialBody(Internal.Body);
    public EditorFacility EditorFacility
        => Internal.EditorFacility;
    public string Name
        => Internal.Name;
}
