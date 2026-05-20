using KRPC.Client.Services.SpaceCenter;
using BaseCargoBay = kRPC.Client.Boost.Services.SpaceCenter.CargoBay;
using CargoBayState = kRPC.Client.Boost.Services.SpaceCenter.CargoBayState;

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
