using KRPC.Client.Services.SpaceCenter;
using BaseWheel = KRPC.Client.Services.SpaceCenter.Wheel;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Wheel object.
/// </summary>
public class Wheel
{
    internal BaseWheel Internal { get; }

    internal Wheel(BaseWheel wheel)
    {
        Internal = wheel;
    }
    public bool AutoFrictionControl
    {
        get => Internal.AutoFrictionControl;
        set => Internal.AutoFrictionControl = value;
    }
    public float Brakes
    {
        get => Internal.Brakes;
        set => Internal.Brakes = value;
    }
    public bool Broken
        => Internal.Broken;
    public float Deflection
        => Internal.Deflection;
    public bool Deployable
        => Internal.Deployable;
    public bool Deployed
    {
        get => Internal.Deployed;
        set => Internal.Deployed = value;
    }
    public float DriveLimiter
    {
        get => Internal.DriveLimiter;
        set => Internal.DriveLimiter = value;
    }
    public bool Grounded
        => Internal.Grounded;
    public bool HasBrakes
        => Internal.HasBrakes;
    public bool HasSuspension
        => Internal.HasSuspension;
    public float ManualFrictionControl
    {
        get => Internal.ManualFrictionControl;
        set => Internal.ManualFrictionControl = value;
    }
    public bool MotorEnabled
    {
        get => Internal.MotorEnabled;
        set => Internal.MotorEnabled = value;
    }
    public bool MotorInverted
    {
        get => Internal.MotorInverted;
        set => Internal.MotorInverted = value;
    }
    public float MotorOutput
        => Internal.MotorOutput;
    public MotorState MotorState
        => Internal.MotorState;
    public Part Part
        => new Part(Internal.Part);
    public bool Powered
        => Internal.Powered;
    public float Radius
        => Internal.Radius;
    public bool Repairable
        => Internal.Repairable;
    public float Slip
        => Internal.Slip;
    public WheelState State
        => Internal.State;
    public bool Steerable
        => Internal.Steerable;
    public float SteeringAngleLimit
    {
        get => Internal.SteeringAngleLimit;
        set => Internal.SteeringAngleLimit = value;
    }
    public bool SteeringEnabled
    {
        get => Internal.SteeringEnabled;
        set => Internal.SteeringEnabled = value;
    }
    public bool SteeringInverted
    {
        get => Internal.SteeringInverted;
        set => Internal.SteeringInverted = value;
    }
    public float SteeringResponseTime
    {
        get => Internal.SteeringResponseTime;
        set => Internal.SteeringResponseTime = value;
    }
    public float Stress
        => Internal.Stress;
    public float StressPercentage
        => Internal.StressPercentage;
    public float StressTolerance
        => Internal.StressTolerance;
    public float SuspensionDamperStrength
        => Internal.SuspensionDamperStrength;
    public float SuspensionSpringStrength
        => Internal.SuspensionSpringStrength;
    public float TractionControl
    {
        get => Internal.TractionControl;
        set => Internal.TractionControl = value;
    }
    public bool TractionControlEnabled
    {
        get => Internal.TractionControlEnabled;
        set => Internal.TractionControlEnabled = value;
    }
}
