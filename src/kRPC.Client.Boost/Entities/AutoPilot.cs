using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
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

    public Tuple<double, double, double> AttenuationAngle
    {
        get => Wrapped.AttenuationAngle;
        set => Wrapped.AttenuationAngle = value;
    }

    public bool AutoTune
    {
        get => Wrapped.AutoTune;
        set => Wrapped.AutoTune = value;
    }

    public Tuple<double, double, double> DecelerationTime
    {
        get => Wrapped.DecelerationTime;
        set => Wrapped.DecelerationTime = value;
    }

    public float Error
        => Wrapped.Error;

    public float HeadingError
        => Wrapped.HeadingError;

    public Tuple<double, double, double> Overshoot
    {
        get => Wrapped.Overshoot;
        set => Wrapped.Overshoot = value;
    }

    public float PitchError
        => Wrapped.PitchError;

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

    public float RollError
        => Wrapped.RollError;

    public Tuple<double, double, double> RollPIDGains
    {
        get => Wrapped.RollPIDGains;
        set => Wrapped.RollPIDGains = value;
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

    public Tuple<double, double, double> StoppingTime
    {
        get => Wrapped.StoppingTime;
        set => Wrapped.StoppingTime = value;
    }

    public Tuple<double, double, double> TargetDirection
    {
        get => Wrapped.TargetDirection;
        set => Wrapped.TargetDirection = value;
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

    public Tuple<double, double, double> TimeToPeak
    {
        get => Wrapped.TimeToPeak;
        set => Wrapped.TimeToPeak = value;
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

    public void TargetPitchAndHeading(float pitch, float heading)
        => Wrapped.TargetPitchAndHeading(pitch, heading);

    public void Wait()
        => Wrapped.Wait();
}
