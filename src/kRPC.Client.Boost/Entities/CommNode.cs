using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseCommNode = KRPC.Client.Services.SpaceCenter.CommNode;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter CommNode object.
/// </summary>
public class CommNode
{
    internal BaseCommNode Internal { get; }

    internal CommNode(BaseCommNode commNode)
    {
        Internal = commNode;
    }
    public bool IsControlPoint
        => Internal.IsControlPoint;
    public bool IsHome
        => Internal.IsHome;
    public bool IsVessel
        => Internal.IsVessel;
    public string Name
        => Internal.Name;
    public Vessel Vessel
        => new Vessel(Internal.Vessel);
}
