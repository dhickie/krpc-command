using KRPC.Client.Services.SpaceCenter;
using BaseAntenna = KRPC.Client.Services.SpaceCenter.Antenna;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Antenna object.
/// </summary>
public class Antenna
{
    internal BaseAntenna Internal { get; }

    internal Antenna(BaseAntenna antenna)
    {
        Internal = antenna;
    }

    public bool AllowPartial
    {
        get => Internal.AllowPartial;
        set => Internal.AllowPartial = value;
    }

    public bool CanTransmit
        => Internal.CanTransmit;

    public bool Combinable
        => Internal.Combinable;

    public double CombinableExponent
        => Internal.CombinableExponent;

    public bool Deployable
        => Internal.Deployable;

    public bool Deployed
    {
        get => Internal.Deployed;
        set => Internal.Deployed = value;
    }

    public float PacketInterval
        => Internal.PacketInterval;

    public double PacketResourceCost
        => Internal.PacketResourceCost;

    public float PacketSize
        => Internal.PacketSize;

    public Part Part
        => new(Internal.Part);

    public double Power
        => Internal.Power;

    public AntennaState State
        => Internal.State;

    public void Cancel()
        => Internal.Cancel();

    public void Transmit()
        => Internal.Transmit();
}
