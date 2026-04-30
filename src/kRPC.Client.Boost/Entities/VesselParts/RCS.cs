using BaseRCS = KRPC.Client.Services.SpaceCenter.RCS;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RCS object.
/// </summary>
public class RCS
{
    internal BaseRCS Internal { get; }

    internal RCS(BaseRCS rCS)
    {
        Internal = rCS;
    }
    public bool Active
        => Internal.Active;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableForce
        => Internal.AvailableForce;
    public float AvailableThrust
        => Internal.AvailableThrust;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Internal.AvailableTorque;
    public bool Enabled
    {
        get => Internal.Enabled;
        set => Internal.Enabled = value;
    }
    public bool ForwardEnabled
    {
        get => Internal.ForwardEnabled;
        set => Internal.ForwardEnabled = value;
    }
    public bool HasFuel
        => Internal.HasFuel;
    public float KerbinSeaLevelSpecificImpulse
        => Internal.KerbinSeaLevelSpecificImpulse;
    public float MaxThrust
        => Internal.MaxThrust;
    public float MaxVacuumThrust
        => Internal.MaxVacuumThrust;
    public Part Part
        => new Part(Internal.Part);
    public bool PitchEnabled
    {
        get => Internal.PitchEnabled;
        set => Internal.PitchEnabled = value;
    }
    public IDictionary<string, float> PropellantRatios
        => Internal.PropellantRatios;
    public IList<string> Propellants
        => Internal.Propellants;
    public bool RightEnabled
    {
        get => Internal.RightEnabled;
        set => Internal.RightEnabled = value;
    }
    public bool RollEnabled
    {
        get => Internal.RollEnabled;
        set => Internal.RollEnabled = value;
    }
    public float SpecificImpulse
        => Internal.SpecificImpulse;
    public float ThrustLimit
    {
        get => Internal.ThrustLimit;
        set => Internal.ThrustLimit = value;
    }
    public IList<Thruster> Thrusters
        => Internal.Thrusters.Select(item => new Thruster(item)).ToList();
    public bool UpEnabled
    {
        get => Internal.UpEnabled;
        set => Internal.UpEnabled = value;
    }
    public float VacuumSpecificImpulse
        => Internal.VacuumSpecificImpulse;
    public bool YawEnabled
    {
        get => Internal.YawEnabled;
        set => Internal.YawEnabled = value;
    }
}
