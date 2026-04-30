using KRPC.Client.Services.SpaceCenter;
using BaseRadiator = KRPC.Client.Services.SpaceCenter.Radiator;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Radiator object.
/// </summary>
public class Radiator
{
    internal readonly BaseRadiator Wrapped;

    internal Radiator(BaseRadiator radiator)
    {
        Wrapped = radiator;
    }

    public bool Deployable
        => Wrapped.Deployable;

    public bool Deployed
    {
        get => Wrapped.Deployed;
        set => Wrapped.Deployed = value;
    }

    public Part Part
        => new Part(Wrapped.Part);

    public RadiatorState State
        => Wrapped.State;
}
