using BaseFairing = KRPC.Client.Services.SpaceCenter.Fairing;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Fairing object.
/// </summary>
public class Fairing
{
    internal BaseFairing Internal { get; }

    internal Fairing(BaseFairing fairing)
    {
        Internal = fairing;
    }
    public bool Jettisoned
        => Internal.Jettisoned;
    public Part Part
        => new Part(Internal.Part);
    public void Jettison()
        => Internal.Jettison();
}
