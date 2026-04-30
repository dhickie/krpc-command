using kRPC.Client.Boost.Extensions;
using KRPC.Client.Services.SpaceCenter;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
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

    public Tuple<Angle, Angle, Angle> AttenuationAngle
    {
        get
        {
            var aa = Wrapped.AttenuationAngle;
            return new Tuple<Angle, Angle, Angle>(
                Angle.FromDegrees(aa.Item1), Angle.FromDegrees(aa.Item2), Angle.FromDegrees(aa.Item3));
        }
        set => Wrapped.AttenuationAngle = 
            new Tuple<double, double, double>(value.Item1.Degrees, value.Item2.Degrees, value.Item3.Degrees);
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

    public Angle HeadingError
        => Angle.FromDegrees(Wrapped.HeadingError);

    public Tuple<double, double, double> Overshoot
    {
        get => Wrapped.Overshoot;
        set => Wrapped.Overshoot = value;
    }

    public Angle PitchError
        => Angle.FromDegrees(Wrapped.PitchError);

    public Tuple<double, double, double> PitchPIDGains
    {
        get => Wrapped.PitchPIDGains;
        set => Wrapped.PitchPIDGains = value;
    }

    public ReferenceFrame ReferenceFrame
    {
        get => new ReferenceFrame(Wrapped.ReferenceFrame);
        set => Wrapped.ReferenceFrame = value.Wrapped;
    }

    public Angle RollError
        => Angle.FromDegrees(Wrapped.RollError);

    public Tuple<double, double, double> RollPIDGains
    {
        get => Wrapped.RollPIDGains;
        set => Wrapped.RollPIDGains = value;
    }

    public Angle RollThreshold
    {
        get => Angle.FromDegrees(Wrapped.RollThreshold);
        set => Wrapped.RollThreshold = value.Degrees;
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

    public Angle TargetHeading
    {
        get => Angle.FromDegrees(Wrapped.TargetHeading);
        set => Wrapped.TargetHeading = (float)value.Degrees;
    }

    public Angle TargetPitch
    {
        get => Angle.FromDegrees(Wrapped.TargetPitch);
        set => Wrapped.TargetPitch = (float)value.Degrees;
    }

    public Angle TargetRoll
    {
        get => Angle.FromDegrees(Wrapped.TargetRoll);
        set => Wrapped.TargetRoll = (float)value.Degrees;
    }

    public Vector3D TimeToPeak
    {
        get => Wrapped.TimeToPeak.ToVector3D();
        set => Wrapped.TimeToPeak = value.ToTuple();
    }

    public Tuple<double, double, double> YawPIDGains
    {
        get => Wrapped.YawPIDGains;
        set => Wrapped.YawPIDGains = value;
    }

    public void Disengage()
        => Wrapped.Disengage();

    public void Engage()
        => Wrapped.Engage();

    public void TargetPitchAndHeading(Angle pitch, Angle heading)
        => Wrapped.TargetPitchAndHeading((float)pitch.Degrees, (float)heading.Degrees);

    public void Wait()
        => Wrapped.Wait();
}
