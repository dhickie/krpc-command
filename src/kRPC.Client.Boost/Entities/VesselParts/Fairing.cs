using BaseFairing = KRPC.Client.Services.SpaceCenter.Fairing;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Fairing object.
/// </summary>
public class Fairing
{
    internal readonly BaseFairing Wrapped;

    internal Fairing(BaseFairing fairing)
    {
        Wrapped = fairing;
    }

    public bool Jettisoned
        => Wrapped.Jettisoned;

    public Part Part
        => new Part(Wrapped.Part);

    public void Jettison()
        => Wrapped.Jettison();
}
