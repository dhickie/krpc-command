using KRPC.Client.Services.SpaceCenter;
using BaseAntenna = KRPC.Client.Services.SpaceCenter.Antenna;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Antenna object.
/// </summary>
public class Antenna
{
    internal readonly BaseAntenna Wrapped;

    internal Antenna(BaseAntenna antenna)
    {
        Wrapped = antenna;
    }

    public bool AllowPartial
    {
        get => Wrapped.AllowPartial;
        set => Wrapped.AllowPartial = value;
    }

    public bool CanTransmit
        => Wrapped.CanTransmit;

    public bool Combinable
        => Wrapped.Combinable;

    public double CombinableExponent
        => Wrapped.CombinableExponent;

    public bool Deployable
        => Wrapped.Deployable;

    public bool Deployed
    {
        get => Wrapped.Deployed;
        set => Wrapped.Deployed = value;
    }

    public float PacketInterval
        => Wrapped.PacketInterval;

    public double PacketResourceCost
        => Wrapped.PacketResourceCost;

    public float PacketSize
        => Wrapped.PacketSize;

    public Part Part
        => new(Wrapped.Part);

    public double Power
        => Wrapped.Power;

    public AntennaState State
        => Wrapped.State;

    public void Cancel()
        => Wrapped.Cancel();

    public void Transmit()
        => Wrapped.Transmit();
}
