using kRPC.Client.Boost.Extensions;
using KRPC.Client.Services.SpaceCenter;
using MathNet.Spatial.Euclidean;
using BaseAutoPilot = KRPC.Client.Services.SpaceCenter.AutoPilot;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter AutoPilot object.
/// </summary>
public class AutoPilot
{
    internal readonly BaseAutoPilot Wrapped;

    internal AutoPilot(BaseAutoPilot autoPilot)
    {
        Wrapped = autoPilot;
    }

    public Vector3D AttenuationAngle
    {
        get => Wrapped.AttenuationAngle.ToVector3D();
        set => Wrapped.AttenuationAngle = value.ToTuple();
    }

    public bool AutoTune
    {
        get => Wrapped.AutoTune;
        set => Wrapped.AutoTune = value;
    }

    public Vector3D DecelerationTime
    {
        get => Wrapped.DecelerationTime.ToVector3D();
        set => Wrapped.DecelerationTime = value.ToTuple();
    }

    public float Error
        => Wrapped.Error;

    public float HeadingError
        => Wrapped.HeadingError;

    public Vector3D Overshoot
    {
        get => Wrapped.Overshoot.ToVector3D();
        set => Wrapped.Overshoot = value.ToTuple();
    }

    public float PitchError
        => Wrapped.PitchError;

    public Vector3D PitchPIDGains
    {
        get => Wrapped.PitchPIDGains.ToVector3D();
        set => Wrapped.PitchPIDGains = value.ToTuple();
    }

    public ReferenceFrame ReferenceFrame
    {
        get => new ReferenceFrame(Wrapped.ReferenceFrame);
        set => Wrapped.ReferenceFrame = value.Wrapped;
    }

    public float RollError
        => Wrapped.RollError;

    public Vector3D RollPIDGains
    {
        get => Wrapped.RollPIDGains.ToVector3D();
        set => Wrapped.RollPIDGains = value.ToTuple();
    }

    public double RollThreshold
    {
        get => Wrapped.RollThreshold;
        set => Wrapped.RollThreshold = value;
    }

    public bool SAS
    {
        get => Wrapped.SAS;
        set => Wrapped.SAS = value;
    }

    public SASMode SASMode
    {
        get => Wrapped.SASMode;
        set => Wrapped.SASMode = value;
    }

    public Vector3D StoppingTime
    {
        get => Wrapped.StoppingTime.ToVector3D();
        set => Wrapped.StoppingTime = value.ToTuple();
    }

    public Vector3D TargetDirection
    {
        get => Wrapped.TargetDirection.ToVector3D();
        set => Wrapped.TargetDirection = value.ToTuple();
    }

    public float TargetHeading
    {
        get => Wrapped.TargetHeading;
        set => Wrapped.TargetHeading = value;
    }

    public float TargetPitch
    {
        get => Wrapped.TargetPitch;
        set => Wrapped.TargetPitch = value;
    }

    public float TargetRoll
    {
        get => Wrapped.TargetRoll;
        set => Wrapped.TargetRoll = value;
    }

    public Vector3D TimeToPeak
    {
        get => Wrapped.TimeToPeak.ToVector3D();
        set => Wrapped.TimeToPeak = value.ToTuple();
    }

    public Vector3D YawPIDGains
    {
        get => Wrapped.YawPIDGains.ToVector3D();
        set => Wrapped.YawPIDGains = value.ToTuple();
    }

    public void Disengage()
        => Wrapped.Disengage();

    public void Engage()
        => Wrapped.Engage();

    public void TargetPitchAndHeading(float pitch, float heading)
        => Wrapped.TargetPitchAndHeading(pitch, heading);

    public void Wait()
        => Wrapped.Wait();
}
