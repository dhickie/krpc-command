using KRPC.Client.Services.SpaceCenter;
using BaseWheel = KRPC.Client.Services.SpaceCenter.Wheel;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Wheel object.
/// </summary>
public class Wheel
{
    internal readonly BaseWheel Wrapped;

    internal Wheel(BaseWheel wheel)
    {
        Wrapped = wheel;
    }

    public bool AutoFrictionControl
    {
        get => Wrapped.AutoFrictionControl;
        set => Wrapped.AutoFrictionControl = value;
    }

    public float Brakes
    {
        get => Wrapped.Brakes;
        set => Wrapped.Brakes = value;
    }

    public bool Broken
        => Wrapped.Broken;

    public float Deflection
        => Wrapped.Deflection;

    public bool Deployable
        => Wrapped.Deployable;

    public bool Deployed
    {
        get => Wrapped.Deployed;
        set => Wrapped.Deployed = value;
    }

    public float DriveLimiter
    {
        get => Wrapped.DriveLimiter;
        set => Wrapped.DriveLimiter = value;
    }

    public bool Grounded
        => Wrapped.Grounded;

    public bool HasBrakes
        => Wrapped.HasBrakes;

    public bool HasSuspension
        => Wrapped.HasSuspension;

    public float ManualFrictionControl
    {
        get => Wrapped.ManualFrictionControl;
        set => Wrapped.ManualFrictionControl = value;
    }

    public bool MotorEnabled
    {
        get => Wrapped.MotorEnabled;
        set => Wrapped.MotorEnabled = value;
    }

    public bool MotorInverted
    {
        get => Wrapped.MotorInverted;
        set => Wrapped.MotorInverted = value;
    }

    public float MotorOutput
        => Wrapped.MotorOutput;

    public MotorState MotorState
        => Wrapped.MotorState;

    public Part Part
        => new Part(Wrapped.Part);

    public bool Powered
        => Wrapped.Powered;

    public float Radius
        => Wrapped.Radius;

    public bool Repairable
        => Wrapped.Repairable;

    public float Slip
        => Wrapped.Slip;

    public WheelState State
        => Wrapped.State;

    public bool Steerable
        => Wrapped.Steerable;

    public float SteeringAngleLimit
    {
        get => Wrapped.SteeringAngleLimit;
        set => Wrapped.SteeringAngleLimit = value;
    }

    public bool SteeringEnabled
    {
        get => Wrapped.SteeringEnabled;
        set => Wrapped.SteeringEnabled = value;
    }

    public bool SteeringInverted
    {
        get => Wrapped.SteeringInverted;
        set => Wrapped.SteeringInverted = value;
    }

    public float SteeringResponseTime
    {
        get => Wrapped.SteeringResponseTime;
        set => Wrapped.SteeringResponseTime = value;
    }

    public float Stress
        => Wrapped.Stress;

    public float StressPercentage
        => Wrapped.StressPercentage;

    public float StressTolerance
        => Wrapped.StressTolerance;

    public float SuspensionDamperStrength
        => Wrapped.SuspensionDamperStrength;

    public float SuspensionSpringStrength
        => Wrapped.SuspensionSpringStrength;

    public float TractionControl
    {
        get => Wrapped.TractionControl;
        set => Wrapped.TractionControl = value;
    }

    public bool TractionControlEnabled
    {
        get => Wrapped.TractionControlEnabled;
        set => Wrapped.TractionControlEnabled = value;
    }
}
