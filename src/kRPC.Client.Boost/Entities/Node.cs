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
    internal BaseNode Internal { get; }

    internal Node(BaseNode node)
    {
        Internal = node;
    }
    public double DeltaV
    {
        get => Internal.DeltaV;
        set => Internal.DeltaV = value;
    }
    public double Normal
    {
        get => Internal.Normal;
        set => Internal.Normal = value;
    }
    public Orbit Orbit
        => new Orbit(Internal.Orbit);
    public ReferenceFrame OrbitalReferenceFrame
        => new ReferenceFrame(Internal.OrbitalReferenceFrame);
    public double Prograde
    {
        get => Internal.Prograde;
        set => Internal.Prograde = value;
    }
    public double Radial
    {
        get => Internal.Radial;
        set => Internal.Radial = value;
    }
    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Internal.ReferenceFrame);
    public double RemainingDeltaV
        => Internal.RemainingDeltaV;
    public double TimeTo
        => Internal.TimeTo;
    public double UT
    {
        get => Internal.UT;
        set => Internal.UT = value;
    }
    public Tuple<double, double, double> BurnVector(ReferenceFrame referenceFrame = null)
        => Internal.BurnVector(referenceFrame?.Internal);
    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Internal.Direction(referenceFrame.Internal);
    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Internal.Position(referenceFrame.Internal);
    public Tuple<double, double, double> RemainingBurnVector(ReferenceFrame referenceFrame = null)
        => Internal.RemainingBurnVector(referenceFrame?.Internal);
    public void Remove()
        => Internal.Remove();
}
