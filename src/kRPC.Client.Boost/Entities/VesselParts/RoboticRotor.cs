using BaseRoboticRotor = KRPC.Client.Services.SpaceCenter.RoboticRotor;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticRotor object.
/// </summary>
public class RoboticRotor
{
    internal BaseRoboticRotor Internal { get; }

    internal RoboticRotor(BaseRoboticRotor roboticRotor)
    {
        Internal = roboticRotor;
    }
    public float CurrentRPM
        => Internal.CurrentRPM;
    public bool Inverted
    {
        get => Internal.Inverted;
        set => Internal.Inverted = value;
    }
    public bool Locked
    {
        get => Internal.Locked;
        set => Internal.Locked = value;
    }
    public bool MotorEngaged
    {
        get => Internal.MotorEngaged;
        set => Internal.MotorEngaged = value;
    }
    public Part Part
        => new Part(Internal.Part);
    public float TargetRPM
    {
        get => Internal.TargetRPM;
        set => Internal.TargetRPM = value;
    }
    public float TorqueLimit
    {
        get => Internal.TorqueLimit;
        set => Internal.TorqueLimit = value;
    }
}
