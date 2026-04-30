using KRPC.Client.Services.SpaceCenter;
using BaseCargoBay = KRPC.Client.Services.SpaceCenter.CargoBay;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter CargoBay object.
/// </summary>
public class CargoBay
{
    internal readonly BaseCargoBay Wrapped;

    internal CargoBay(BaseCargoBay cargoBay)
    {
        Wrapped = cargoBay;
    }

    public bool Open
    {
        get => Wrapped.Open;
        set => Wrapped.Open = value;
    }

    public Part Part
        => new(Wrapped.Part);

    public CargoBayState State
        => Wrapped.State;
}
