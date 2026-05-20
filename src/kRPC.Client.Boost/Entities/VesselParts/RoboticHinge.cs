using MathNet.Spatial.Units;
using BaseRoboticHinge = kRPC.Client.Boost.Services.SpaceCenter.RoboticHinge;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticHinge object.
/// </summary>
public class RoboticHinge
{
    internal readonly BaseRoboticHinge Wrapped;

    internal RoboticHinge(BaseRoboticHinge roboticHinge)
    {
        Wrapped = roboticHinge;
    }

    public Angle CurrentAngle
        => Angle.FromDegrees(Wrapped.CurrentAngle);

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

    public Angle Rate
    {
        get => Angle.FromDegrees(Wrapped.Rate);
        set => Wrapped.Rate = (float)value.Degrees;
    }

    public Angle TargetAngle
    {
        get => Angle.FromDegrees(Wrapped.TargetAngle);
        set => Wrapped.TargetAngle = (float)value.Degrees;
    }

    public void MoveHome()
        => Wrapped.MoveHome();
}
