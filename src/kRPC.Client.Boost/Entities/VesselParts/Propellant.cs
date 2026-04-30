using BasePropellant = KRPC.Client.Services.SpaceCenter.Propellant;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Propellant object.
/// </summary>
public class Propellant
{
    internal BasePropellant Internal { get; }

    internal Propellant(BasePropellant propellant)
    {
        Internal = propellant;
    }
    public double CurrentAmount
        => Internal.CurrentAmount;
    public double CurrentRequirement
        => Internal.CurrentRequirement;
    public bool DrawStackGauge
        => Internal.DrawStackGauge;
    public bool IgnoreForIsp
        => Internal.IgnoreForIsp;
    public bool IgnoreForThrustCurve
        => Internal.IgnoreForThrustCurve;
    public bool IsDeprived
        => Internal.IsDeprived;
    public string Name
        => Internal.Name;
    public float Ratio
        => Internal.Ratio;
    public double TotalResourceAvailable
        => Internal.TotalResourceAvailable;
    public double TotalResourceCapacity
        => Internal.TotalResourceCapacity;
}
