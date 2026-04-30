using BaseRoboticRotor = KRPC.Client.Services.SpaceCenter.RoboticRotor;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticRotor object.
/// </summary>
public class RoboticRotor
{
    internal readonly BaseRoboticRotor Wrapped;

    internal RoboticRotor(BaseRoboticRotor roboticRotor)
    {
        Wrapped = roboticRotor;
    }

    public float CurrentRPM
        => Wrapped.CurrentRPM;

    public bool Inverted
    {
        get => Wrapped.Inverted;
        set => Wrapped.Inverted = value;
    }

    public bool Locked
    {
        get => Wrapped.Locked;
        set => Wrapped.Locked = value;
    }

    public bool MotorEngaged
    {
        get => Wrapped.MotorEngaged;
        set => Wrapped.MotorEngaged = value;
    }

    public Part Part
        => new Part(Wrapped.Part);

    public float TargetRPM
    {
        get => Wrapped.TargetRPM;
        set => Wrapped.TargetRPM = value;
    }

    public float TorqueLimit
    {
        get => Wrapped.TorqueLimit;
        set => Wrapped.TorqueLimit = value;
    }
}
