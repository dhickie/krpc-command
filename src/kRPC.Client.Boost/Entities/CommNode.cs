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
    internal readonly BaseCommNode Wrapped;

    internal CommNode(BaseCommNode commNode)
    {
        Wrapped = commNode;
    }

    public bool IsControlPoint
        => Wrapped.IsControlPoint;

    public bool IsHome
        => Wrapped.IsHome;

    public bool IsVessel
        => Wrapped.IsVessel;

    public string Name
        => Wrapped.Name;

    public Vessel Vessel
        => new Vessel(Wrapped.Vessel);
}
