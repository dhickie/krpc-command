using MathNet.Spatial.Units;
using BaseRoboticRotation = kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation;

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
