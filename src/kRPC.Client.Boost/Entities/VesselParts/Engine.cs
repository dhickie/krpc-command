using BaseEngine = KRPC.Client.Services.SpaceCenter.Engine;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Engine object.
/// </summary>
public class Engine
{
    internal readonly BaseEngine Wrapped;

    internal Engine(BaseEngine engine)
    {
        Wrapped = engine;
    }

    public bool Active
    {
        get => Wrapped.Active;
        set => Wrapped.Active = value;
    }

    public bool AutoModeSwitch
    {
        get => Wrapped.AutoModeSwitch;
        set => Wrapped.AutoModeSwitch = value;
    }

    public float AvailableThrust
        => Wrapped.AvailableThrust;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Wrapped.AvailableTorque;

    public bool CanRestart
        => Wrapped.CanRestart;

    public bool CanShutdown
        => Wrapped.CanShutdown;

    public float GimbalLimit
    {
        get => Wrapped.GimbalLimit;
        set => Wrapped.GimbalLimit = value;
    }

    public bool GimbalLocked
    {
        get => Wrapped.GimbalLocked;
        set => Wrapped.GimbalLocked = value;
    }

    public float GimbalRange
        => Wrapped.GimbalRange;

    public bool Gimballed
        => Wrapped.Gimballed;

    public bool HasFuel
        => Wrapped.HasFuel;

    public bool HasModes
        => Wrapped.HasModes;

    public bool IndependentThrottle
    {
        get => Wrapped.IndependentThrottle;
        set => Wrapped.IndependentThrottle = value;
    }

    public float KerbinSeaLevelSpecificImpulse
        => Wrapped.KerbinSeaLevelSpecificImpulse;

    public float MaxThrust
        => Wrapped.MaxThrust;

    public float MaxVacuumThrust
        => Wrapped.MaxVacuumThrust;

    public string Mode
    {
        get => Wrapped.Mode;
        set => Wrapped.Mode = value;
    }

    public IDictionary<string, Engine> Modes
        => Wrapped.Modes.ToDictionary(pair => pair.Key, pair => new Engine(pair.Value));

    public Part Part
        => new Part(Wrapped.Part);

    public IList<string> PropellantNames
        => Wrapped.PropellantNames;

    public IDictionary<string, float> PropellantRatios
        => Wrapped.PropellantRatios;

    public IList<Propellant> Propellants
        => Wrapped.Propellants.Select(item => new Propellant(item)).ToList();

    public float SpecificImpulse
        => Wrapped.SpecificImpulse;

    public float Throttle
    {
        get => Wrapped.Throttle;
        set => Wrapped.Throttle = value;
    }

    public bool ThrottleLocked
        => Wrapped.ThrottleLocked;

    public float Thrust
        => Wrapped.Thrust;

    public float ThrustLimit
    {
        get => Wrapped.ThrustLimit;
        set => Wrapped.ThrustLimit = value;
    }

    public IList<Thruster> Thrusters
        => Wrapped.Thrusters.Select(item => new Thruster(item)).ToList();

    public float VacuumSpecificImpulse
        => Wrapped.VacuumSpecificImpulse;

    public float AvailableThrustAt(double pressure)
        => Wrapped.AvailableThrustAt(pressure);

    public float MaxThrustAt(double pressure)
        => Wrapped.MaxThrustAt(pressure);

    public float SpecificImpulseAt(double pressure)
        => Wrapped.SpecificImpulseAt(pressure);

    public void ToggleMode()
        => Wrapped.ToggleMode();
}
