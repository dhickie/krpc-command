using BaseEngine = KRPC.Client.Services.SpaceCenter.Engine;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Engine object.
/// </summary>
public class Engine
{
    internal BaseEngine Internal { get; }

    internal Engine(BaseEngine engine)
    {
        Internal = engine;
    }
    public bool Active
    {
        get => Internal.Active;
        set => Internal.Active = value;
    }
    public bool AutoModeSwitch
    {
        get => Internal.AutoModeSwitch;
        set => Internal.AutoModeSwitch = value;
    }
    public float AvailableThrust
        => Internal.AvailableThrust;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Internal.AvailableTorque;
    public bool CanRestart
        => Internal.CanRestart;
    public bool CanShutdown
        => Internal.CanShutdown;
    public float GimbalLimit
    {
        get => Internal.GimbalLimit;
        set => Internal.GimbalLimit = value;
    }
    public bool GimbalLocked
    {
        get => Internal.GimbalLocked;
        set => Internal.GimbalLocked = value;
    }
    public float GimbalRange
        => Internal.GimbalRange;
    public bool Gimballed
        => Internal.Gimballed;
    public bool HasFuel
        => Internal.HasFuel;
    public bool HasModes
        => Internal.HasModes;
    public bool IndependentThrottle
    {
        get => Internal.IndependentThrottle;
        set => Internal.IndependentThrottle = value;
    }
    public float KerbinSeaLevelSpecificImpulse
        => Internal.KerbinSeaLevelSpecificImpulse;
    public float MaxThrust
        => Internal.MaxThrust;
    public float MaxVacuumThrust
        => Internal.MaxVacuumThrust;
    public string Mode
    {
        get => Internal.Mode;
        set => Internal.Mode = value;
    }
    public IDictionary<string, Engine> Modes
        => Internal.Modes.ToDictionary(pair => pair.Key, pair => new Engine(pair.Value));
    public Part Part
        => new Part(Internal.Part);
    public IList<string> PropellantNames
        => Internal.PropellantNames;
    public IDictionary<string, float> PropellantRatios
        => Internal.PropellantRatios;
    public IList<Propellant> Propellants
        => Internal.Propellants.Select(item => new Propellant(item)).ToList();
    public float SpecificImpulse
        => Internal.SpecificImpulse;
    public float Throttle
    {
        get => Internal.Throttle;
        set => Internal.Throttle = value;
    }
    public bool ThrottleLocked
        => Internal.ThrottleLocked;
    public float Thrust
        => Internal.Thrust;
    public float ThrustLimit
    {
        get => Internal.ThrustLimit;
        set => Internal.ThrustLimit = value;
    }
    public IList<Thruster> Thrusters
        => Internal.Thrusters.Select(item => new Thruster(item)).ToList();
    public float VacuumSpecificImpulse
        => Internal.VacuumSpecificImpulse;
    public float AvailableThrustAt(double pressure)
        => Internal.AvailableThrustAt(pressure);
    public float MaxThrustAt(double pressure)
        => Internal.MaxThrustAt(pressure);
    public float SpecificImpulseAt(double pressure)
        => Internal.SpecificImpulseAt(pressure);
    public void ToggleMode()
        => Internal.ToggleMode();
}
