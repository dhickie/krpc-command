using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseWaypoint = KRPC.Client.Services.SpaceCenter.Waypoint;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Waypoint object.
/// </summary>
public class Waypoint
{
    internal readonly BaseWaypoint Wrapped;

    internal Waypoint(BaseWaypoint waypoint)
    {
        Wrapped = waypoint;
    }

    public double BedrockAltitude
    {
        get => Wrapped.BedrockAltitude;
        set => Wrapped.BedrockAltitude = value;
    }

    public CelestialBody Body
    {
        get => new CelestialBody(Wrapped.Body);
        set => Wrapped.Body = value.Wrapped;
    }

    public bool Clustered
        => Wrapped.Clustered;

    public int Color
    {
        get => Wrapped.Color;
        set => Wrapped.Color = value;
    }

    public Contract Contract
        => new Contract(Wrapped.Contract);

    public bool Grounded
        => Wrapped.Grounded;

    public bool HasContract
        => Wrapped.HasContract;

    public string Icon
    {
        get => Wrapped.Icon;
        set => Wrapped.Icon = value;
    }

    public int Index
        => Wrapped.Index;

    public double Latitude
    {
        get => Wrapped.Latitude;
        set => Wrapped.Latitude = value;
    }

    public double Longitude
    {
        get => Wrapped.Longitude;
        set => Wrapped.Longitude = value;
    }

    public double MeanAltitude
    {
        get => Wrapped.MeanAltitude;
        set => Wrapped.MeanAltitude = value;
    }

    public string Name
    {
        get => Wrapped.Name;
        set => Wrapped.Name = value;
    }

    public bool NearSurface
        => Wrapped.NearSurface;

    public double SurfaceAltitude
    {
        get => Wrapped.SurfaceAltitude;
        set => Wrapped.SurfaceAltitude = value;
    }

    public void Remove()
        => Wrapped.Remove();
}
