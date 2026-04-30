using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseCommLink = KRPC.Client.Services.SpaceCenter.CommLink;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter CommLink object.
/// </summary>
public class CommLink
{
    internal readonly BaseCommLink Wrapped;

    internal CommLink(BaseCommLink commLink)
    {
        Wrapped = commLink;
    }

    public CommNode End
        => new CommNode(Wrapped.End);

    public double SignalStrength
        => Wrapped.SignalStrength;

    public CommNode Start
        => new CommNode(Wrapped.Start);

    public CommLinkType Type
        => Wrapped.Type;
}
