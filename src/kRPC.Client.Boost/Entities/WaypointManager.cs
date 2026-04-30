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
    internal readonly BaseWaypointManager Wrapped;

    internal WaypointManager(BaseWaypointManager waypointManager)
    {
        Wrapped = waypointManager;
    }

    public IDictionary<string, int> Colors
        => Wrapped.Colors;

    public IList<string> Icons
        => Wrapped.Icons;

    public IList<Waypoint> Waypoints
        => Wrapped.Waypoints.Select(item => new Waypoint(item)).ToList();

    public Waypoint AddWaypoint(double latitude, double longitude, CelestialBody body, string name)
        => new(Wrapped.AddWaypoint(latitude, longitude, body.Wrapped, name));

    public Waypoint AddWaypointAtAltitude(double latitude, double longitude, double altitude, CelestialBody body, string name)
        => new(Wrapped.AddWaypointAtAltitude(latitude, longitude, altitude, body.Wrapped, name));
}
