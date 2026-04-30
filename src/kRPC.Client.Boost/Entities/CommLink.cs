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
    internal BaseCommLink Internal { get; }

    internal CommLink(BaseCommLink commLink)
    {
        Internal = commLink;
    }
    public CommNode End
        => new CommNode(Internal.End);
    public double SignalStrength
        => Internal.SignalStrength;
    public CommNode Start
        => new CommNode(Internal.Start);
    public CommLinkType Type
        => Internal.Type;
}
