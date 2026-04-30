using KRPC.Client.Services.SpaceCenter;
using BaseCargoBay = KRPC.Client.Services.SpaceCenter.CargoBay;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter CargoBay object.
/// </summary>
public class CargoBay
{
    internal BaseCargoBay Internal { get; }

    internal CargoBay(BaseCargoBay cargoBay)
    {
        Internal = cargoBay;
    }
    public bool Open
    {
        get => Internal.Open;
        set => Internal.Open = value;
    }
    public Part Part
        => new Part(Internal.Part);
    public CargoBayState State
        => Internal.State;
}
