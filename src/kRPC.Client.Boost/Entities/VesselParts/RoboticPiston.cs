using BaseRoboticPiston = KRPC.Client.Services.SpaceCenter.RoboticPiston;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticPiston object.
/// </summary>
public class RoboticPiston
{
    internal readonly BaseRoboticPiston Wrapped;

    internal RoboticPiston(BaseRoboticPiston roboticPiston)
    {
        Wrapped = roboticPiston;
    }

    public float CurrentExtension
        => Wrapped.CurrentExtension;

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

    public float TargetExtension
    {
        get => Wrapped.TargetExtension;
        set => Wrapped.TargetExtension = value;
    }

    public void MoveHome()
        => Wrapped.MoveHome();
}
