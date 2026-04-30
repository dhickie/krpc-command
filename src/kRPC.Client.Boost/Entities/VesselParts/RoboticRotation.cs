using BaseRoboticRotation = KRPC.Client.Services.SpaceCenter.RoboticRotation;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticRotation object.
/// </summary>
public class RoboticRotation
{
    internal BaseRoboticRotation Internal { get; }

    internal RoboticRotation(BaseRoboticRotation roboticRotation)
    {
        Internal = roboticRotation;
    }
    public float CurrentAngle
        => Internal.CurrentAngle;
    public float Damping
    {
        get => Internal.Damping;
        set => Internal.Damping = value;
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
    public float Rate
    {
        get => Internal.Rate;
        set => Internal.Rate = value;
    }
    public float TargetAngle
    {
        get => Internal.TargetAngle;
        set => Internal.TargetAngle = value;
    }
    public void MoveHome()
        => Internal.MoveHome();
}
