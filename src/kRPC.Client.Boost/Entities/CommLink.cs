using KRPC.Client.Services.SpaceCenter;
using BaseCommLink = kRPC.Client.Boost.Services.SpaceCenter.CommLink;
using CommLinkType = kRPC.Client.Boost.Services.SpaceCenter.CommLinkType;

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
