using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseNode = KRPC.Client.Services.SpaceCenter.Node;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Node object.
/// </summary>
public class Node
{
    internal readonly BaseNode Wrapped;

    internal Node(BaseNode node)
    {
        Wrapped = node;
    }

    public double DeltaV
    {
        get => Wrapped.DeltaV;
        set => Wrapped.DeltaV = value;
    }

    public double Normal
    {
        get => Wrapped.Normal;
        set => Wrapped.Normal = value;
    }

    public Orbit Orbit
        => new Orbit(Wrapped.Orbit);

    public ReferenceFrame OrbitalReferenceFrame
        => new ReferenceFrame(Wrapped.OrbitalReferenceFrame);

    public double Prograde
    {
        get => Wrapped.Prograde;
        set => Wrapped.Prograde = value;
    }

    public double Radial
    {
        get => Wrapped.Radial;
        set => Wrapped.Radial = value;
    }

    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Wrapped.ReferenceFrame);

    public double RemainingDeltaV
        => Wrapped.RemainingDeltaV;

    public double TimeTo
        => Wrapped.TimeTo;

    public double UT
    {
        get => Wrapped.UT;
        set => Wrapped.UT = value;
    }

    public Tuple<double, double, double> BurnVector(ReferenceFrame referenceFrame = null)
        => Wrapped.BurnVector(referenceFrame?.Wrapped);

    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Wrapped.Direction(referenceFrame.Wrapped);

    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Wrapped.Position(referenceFrame.Wrapped);

    public Tuple<double, double, double> RemainingBurnVector(ReferenceFrame referenceFrame = null)
        => Wrapped.RemainingBurnVector(referenceFrame?.Wrapped);

    public void Remove()
        => Wrapped.Remove();
}
