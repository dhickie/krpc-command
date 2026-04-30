using BaseDecoupler = KRPC.Client.Services.SpaceCenter.Decoupler;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Decoupler object.
/// </summary>
public class Decoupler
{
    internal BaseDecoupler Internal { get; }

    internal Decoupler(BaseDecoupler decoupler)
    {
        Internal = decoupler;
    }
    public Part AttachedPart
        => new Part(Internal.AttachedPart);
    public bool Decoupled
        => Internal.Decoupled;
    public float Impulse
        => Internal.Impulse;
    public bool IsOmniDecoupler
        => Internal.IsOmniDecoupler;
    public Part Part
        => new Part(Internal.Part);
    public bool Staged
        => Internal.Staged;
    public Vessel Decouple()
        => new Vessel(Internal.Decouple());
}
