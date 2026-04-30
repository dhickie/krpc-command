using KRPC.Client.Services.SpaceCenter;
using BaseLeg = KRPC.Client.Services.SpaceCenter.Leg;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Leg object.
/// </summary>
public class Leg
{
    internal readonly BaseLeg Wrapped;

    internal Leg(BaseLeg leg)
    {
        Wrapped = leg;
    }

    public bool Deployable
        => Wrapped.Deployable;

    public bool Deployed
    {
        get => Wrapped.Deployed;
        set => Wrapped.Deployed = value;
    }

    public bool IsGrounded
        => Wrapped.IsGrounded;

    public Part Part
        => new Part(Wrapped.Part);

    public LegState State
        => Wrapped.State;
}
