using BaseRoboticHinge = KRPC.Client.Services.SpaceCenter.RoboticHinge;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticHinge object.
/// </summary>
public class RoboticHinge
{
    internal BaseRoboticHinge Internal { get; }

    internal RoboticHinge(BaseRoboticHinge roboticHinge)
    {
        Internal = roboticHinge;
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
