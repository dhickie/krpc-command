using BasePropellant = KRPC.Client.Services.SpaceCenter.Propellant;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Propellant object.
/// </summary>
public class Propellant
{
    internal readonly BasePropellant Wrapped;

    internal Propellant(BasePropellant propellant)
    {
        Wrapped = propellant;
    }

    public double CurrentAmount
        => Wrapped.CurrentAmount;

    public double CurrentRequirement
        => Wrapped.CurrentRequirement;

    public bool DrawStackGauge
        => Wrapped.DrawStackGauge;

    public bool IgnoreForIsp
        => Wrapped.IgnoreForIsp;

    public bool IgnoreForThrustCurve
        => Wrapped.IgnoreForThrustCurve;

    public bool IsDeprived
        => Wrapped.IsDeprived;

    public string Name
        => Wrapped.Name;

    public float Ratio
        => Wrapped.Ratio;

    public double TotalResourceAvailable
        => Wrapped.TotalResourceAvailable;

    public double TotalResourceCapacity
        => Wrapped.TotalResourceCapacity;
}
