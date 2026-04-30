using BaseRoboticRotation = KRPC.Client.Services.SpaceCenter.RoboticRotation;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticRotation object.
/// </summary>
public class RoboticRotation
{
    internal readonly BaseRoboticRotation Wrapped;

    internal RoboticRotation(BaseRoboticRotation roboticRotation)
    {
        Wrapped = roboticRotation;
    }

    public float CurrentAngle
        => Wrapped.CurrentAngle;

    public float Damping
    {
        get => Wrapped.Damping;
        set => Wrapped.Damping = value;
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

    public float Rate
    {
        get => Wrapped.Rate;
        set => Wrapped.Rate = value;
    }

    public float TargetAngle
    {
        get => Wrapped.TargetAngle;
        set => Wrapped.TargetAngle = value;
    }

    public void MoveHome()
        => Wrapped.MoveHome();
}
