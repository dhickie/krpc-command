using KRPC.Client.Services.SpaceCenter;
using BaseRadiator = KRPC.Client.Services.SpaceCenter.Radiator;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Radiator object.
/// </summary>
public class Radiator
{
    internal BaseRadiator Internal { get; }

    internal Radiator(BaseRadiator radiator)
    {
        Internal = radiator;
    }
    public bool Deployable
        => Internal.Deployable;
    public bool Deployed
    {
        get => Internal.Deployed;
        set => Internal.Deployed = value;
    }
    public Part Part
        => new Part(Internal.Part);
    public RadiatorState State
        => Internal.State;
}
