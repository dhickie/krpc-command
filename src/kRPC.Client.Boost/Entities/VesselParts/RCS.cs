using BaseRCS = KRPC.Client.Services.SpaceCenter.RCS;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RCS object.
/// </summary>
public class RCS
{
    internal readonly BaseRCS Wrapped;

    internal RCS(BaseRCS rCS)
    {
        Wrapped = rCS;
    }

    public bool Active
        => Wrapped.Active;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableForce
        => Wrapped.AvailableForce;

    public float AvailableThrust
        => Wrapped.AvailableThrust;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Wrapped.AvailableTorque;

    public bool Enabled
    {
        get => Wrapped.Enabled;
        set => Wrapped.Enabled = value;
    }

    public bool ForwardEnabled
    {
        get => Wrapped.ForwardEnabled;
        set => Wrapped.ForwardEnabled = value;
    }

    public bool HasFuel
        => Wrapped.HasFuel;

    public float KerbinSeaLevelSpecificImpulse
        => Wrapped.KerbinSeaLevelSpecificImpulse;

    public float MaxThrust
        => Wrapped.MaxThrust;

    public float MaxVacuumThrust
        => Wrapped.MaxVacuumThrust;

    public Part Part
        => new Part(Wrapped.Part);

    public bool PitchEnabled
    {
        get => Wrapped.PitchEnabled;
        set => Wrapped.PitchEnabled = value;
    }

    public IDictionary<string, float> PropellantRatios
        => Wrapped.PropellantRatios;

    public IList<string> Propellants
        => Wrapped.Propellants;

    public bool RightEnabled
    {
        get => Wrapped.RightEnabled;
        set => Wrapped.RightEnabled = value;
    }

    public bool RollEnabled
    {
        get => Wrapped.RollEnabled;
        set => Wrapped.RollEnabled = value;
    }

    public float SpecificImpulse
        => Wrapped.SpecificImpulse;

    public float ThrustLimit
    {
        get => Wrapped.ThrustLimit;
        set => Wrapped.ThrustLimit = value;
    }

    public IList<Thruster> Thrusters
        => Wrapped.Thrusters.Select(item => new Thruster(item)).ToList();

    public bool UpEnabled
    {
        get => Wrapped.UpEnabled;
        set => Wrapped.UpEnabled = value;
    }

    public float VacuumSpecificImpulse
        => Wrapped.VacuumSpecificImpulse;

    public bool YawEnabled
    {
        get => Wrapped.YawEnabled;
        set => Wrapped.YawEnabled = value;
    }
}
