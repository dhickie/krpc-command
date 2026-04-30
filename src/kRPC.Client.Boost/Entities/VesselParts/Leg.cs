using KRPC.Client.Services.SpaceCenter;
using BaseLeg = KRPC.Client.Services.SpaceCenter.Leg;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Leg object.
/// </summary>
public class Leg
{
    internal BaseLeg Internal { get; }

    internal Leg(BaseLeg leg)
    {
        Internal = leg;
    }
    public bool Deployable
        => Internal.Deployable;
    public bool Deployed
    {
        get => Internal.Deployed;
        set => Internal.Deployed = value;
    }
    public bool IsGrounded
        => Internal.IsGrounded;
    public Part Part
        => new Part(Internal.Part);
    public LegState State
        => Internal.State;
}
