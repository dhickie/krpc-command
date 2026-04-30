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
    internal BaseAutoPilot Internal { get; }

    internal AutoPilot(BaseAutoPilot autoPilot)
    {
        Internal = autoPilot;
    }
    public Tuple<double, double, double> AttenuationAngle
    {
        get => Internal.AttenuationAngle;
        set => Internal.AttenuationAngle = value;
    }
    public bool AutoTune
    {
        get => Internal.AutoTune;
        set => Internal.AutoTune = value;
    }
    public Tuple<double, double, double> DecelerationTime
    {
        get => Internal.DecelerationTime;
        set => Internal.DecelerationTime = value;
    }
    public float Error
        => Internal.Error;
    public float HeadingError
        => Internal.HeadingError;
    public Tuple<double, double, double> Overshoot
    {
        get => Internal.Overshoot;
        set => Internal.Overshoot = value;
    }
    public float PitchError
        => Internal.PitchError;
    public Tuple<double, double, double> PitchPIDGains
    {
        get => Internal.PitchPIDGains;
        set => Internal.PitchPIDGains = value;
    }
    public ReferenceFrame ReferenceFrame
    {
        get => new ReferenceFrame(Internal.ReferenceFrame);
        set => Internal.ReferenceFrame = value.Internal;
    }
    public float RollError
        => Internal.RollError;
    public Tuple<double, double, double> RollPIDGains
    {
        get => Internal.RollPIDGains;
        set => Internal.RollPIDGains = value;
    }
    public double RollThreshold
    {
        get => Internal.RollThreshold;
        set => Internal.RollThreshold = value;
    }
    public bool SAS
    {
        get => Internal.SAS;
        set => Internal.SAS = value;
    }
    public SASMode SASMode
    {
        get => Internal.SASMode;
        set => Internal.SASMode = value;
    }
    public Tuple<double, double, double> StoppingTime
    {
        get => Internal.StoppingTime;
        set => Internal.StoppingTime = value;
    }
    public Tuple<double, double, double> TargetDirection
    {
        get => Internal.TargetDirection;
        set => Internal.TargetDirection = value;
    }
    public float TargetHeading
    {
        get => Internal.TargetHeading;
        set => Internal.TargetHeading = value;
    }
    public float TargetPitch
    {
        get => Internal.TargetPitch;
        set => Internal.TargetPitch = value;
    }
    public float TargetRoll
    {
        get => Internal.TargetRoll;
        set => Internal.TargetRoll = value;
    }
    public Tuple<double, double, double> TimeToPeak
    {
        get => Internal.TimeToPeak;
        set => Internal.TimeToPeak = value;
    }
    public Tuple<double, double, double> YawPIDGains
    {
        get => Internal.YawPIDGains;
        set => Internal.YawPIDGains = value;
    }
    public void Disengage()
        => Internal.Disengage();
    public void Engage()
        => Internal.Engage();
    public void TargetPitchAndHeading(float pitch, float heading)
        => Internal.TargetPitchAndHeading(pitch, heading);
    public void Wait()
        => Internal.Wait();
}
