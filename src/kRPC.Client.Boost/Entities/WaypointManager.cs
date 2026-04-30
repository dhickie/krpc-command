using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseWaypointManager = KRPC.Client.Services.SpaceCenter.WaypointManager;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter WaypointManager object.
/// </summary>
public class WaypointManager
{
    internal BaseWaypointManager Internal { get; }

    internal WaypointManager(BaseWaypointManager waypointManager)
    {
        Internal = waypointManager;
    }
    public IDictionary<string, int> Colors
        => Internal.Colors;
    public IList<string> Icons
        => Internal.Icons;
    public IList<Waypoint> Waypoints
        => Internal.Waypoints.Select(item => new Waypoint(item)).ToList();
    public Waypoint AddWaypoint(double latitude, double longitude, CelestialBody body, string name)
        => new Waypoint(Internal.AddWaypoint(latitude, longitude, body.Internal, name));
    public Waypoint AddWaypointAtAltitude(double latitude, double longitude, double altitude, CelestialBody body, string name)
        => new Waypoint(Internal.AddWaypointAtAltitude(latitude, longitude, altitude, body.Internal, name));
}
