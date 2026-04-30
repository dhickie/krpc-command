using BaseDecoupler = KRPC.Client.Services.SpaceCenter.Decoupler;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Decoupler object.
/// </summary>
public class Decoupler
{
    internal readonly BaseDecoupler Wrapped;

    internal Decoupler(BaseDecoupler decoupler)
    {
        Wrapped = decoupler;
    }

    public Part AttachedPart
        => new Part(Wrapped.AttachedPart);

    public bool Decoupled
        => Wrapped.Decoupled;

    public float Impulse
        => Wrapped.Impulse;

    public bool IsOmniDecoupler
        => Wrapped.IsOmniDecoupler;

    public Part Part
        => new Part(Wrapped.Part);

    public bool Staged
        => Wrapped.Staged;

    public Vessel Decouple()
        => new Vessel(Wrapped.Decouple());
}
