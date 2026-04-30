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
    internal BaseWaypoint Internal { get; }

    internal Waypoint(BaseWaypoint waypoint)
    {
        Internal = waypoint;
    }
    public double BedrockAltitude
    {
        get => Internal.BedrockAltitude;
        set => Internal.BedrockAltitude = value;
    }
    public CelestialBody Body
    {
        get => new CelestialBody(Internal.Body);
        set => Internal.Body = value.Internal;
    }
    public bool Clustered
        => Internal.Clustered;
    public int Color
    {
        get => Internal.Color;
        set => Internal.Color = value;
    }
    public Contract Contract
        => new Contract(Internal.Contract);
    public bool Grounded
        => Internal.Grounded;
    public bool HasContract
        => Internal.HasContract;
    public string Icon
    {
        get => Internal.Icon;
        set => Internal.Icon = value;
    }
    public int Index
        => Internal.Index;
    public double Latitude
    {
        get => Internal.Latitude;
        set => Internal.Latitude = value;
    }
    public double Longitude
    {
        get => Internal.Longitude;
        set => Internal.Longitude = value;
    }
    public double MeanAltitude
    {
        get => Internal.MeanAltitude;
        set => Internal.MeanAltitude = value;
    }
    public string Name
    {
        get => Internal.Name;
        set => Internal.Name = value;
    }
    public bool NearSurface
        => Internal.NearSurface;
    public double SurfaceAltitude
    {
        get => Internal.SurfaceAltitude;
        set => Internal.SurfaceAltitude = value;
    }
    public void Remove()
        => Internal.Remove();
}
