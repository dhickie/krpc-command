using BaseRoboticPiston = KRPC.Client.Services.SpaceCenter.RoboticPiston;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter RoboticPiston object.
/// </summary>
public class RoboticPiston
{
    internal BaseRoboticPiston Internal { get; }

    internal RoboticPiston(BaseRoboticPiston roboticPiston)
    {
        Internal = roboticPiston;
    }
    public float CurrentExtension
        => Internal.CurrentExtension;
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
    public float TargetExtension
    {
        get => Internal.TargetExtension;
        set => Internal.TargetExtension = value;
    }
    public void MoveHome()
        => Internal.MoveHome();
}
