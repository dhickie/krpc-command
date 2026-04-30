using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseControl = KRPC.Client.Services.SpaceCenter.Control;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Control object.
/// </summary>
public class Control
{
    internal BaseControl Internal { get; }

    internal Control(BaseControl control)
    {
        Internal = control;
    }
    public bool Abort
    {
        get => Internal.Abort;
        set => Internal.Abort = value;
    }
    public bool Antennas
    {
        get => Internal.Antennas;
        set => Internal.Antennas = value;
    }
    public bool Brakes
    {
        get => Internal.Brakes;
        set => Internal.Brakes = value;
    }
    public bool CargoBays
    {
        get => Internal.CargoBays;
        set => Internal.CargoBays = value;
    }
    public int CurrentStage
        => Internal.CurrentStage;
    public float CustomAxis01
    {
        get => Internal.CustomAxis01;
        set => Internal.CustomAxis01 = value;
    }
    public float CustomAxis02
    {
        get => Internal.CustomAxis02;
        set => Internal.CustomAxis02 = value;
    }
    public float CustomAxis03
    {
        get => Internal.CustomAxis03;
        set => Internal.CustomAxis03 = value;
    }
    public float CustomAxis04
    {
        get => Internal.CustomAxis04;
        set => Internal.CustomAxis04 = value;
    }
    public float Forward
    {
        get => Internal.Forward;
        set => Internal.Forward = value;
    }
    public bool Gear
    {
        get => Internal.Gear;
        set => Internal.Gear = value;
    }
    public ControlInputMode InputMode
    {
        get => Internal.InputMode;
        set => Internal.InputMode = value;
    }
    public bool Intakes
    {
        get => Internal.Intakes;
        set => Internal.Intakes = value;
    }
    public bool Legs
    {
        get => Internal.Legs;
        set => Internal.Legs = value;
    }
    public bool Lights
    {
        get => Internal.Lights;
        set => Internal.Lights = value;
    }
    public IList<Node> Nodes
        => Internal.Nodes.Select(item => new Node(item)).ToList();
    public bool Parachutes
    {
        get => Internal.Parachutes;
        set => Internal.Parachutes = value;
    }
    public float Pitch
    {
        get => Internal.Pitch;
        set => Internal.Pitch = value;
    }
    public bool RCS
    {
        get => Internal.RCS;
        set => Internal.RCS = value;
    }
    public bool Radiators
    {
        get => Internal.Radiators;
        set => Internal.Radiators = value;
    }
    public bool ReactionWheels
    {
        get => Internal.ReactionWheels;
        set => Internal.ReactionWheels = value;
    }
    public bool ResourceHarvesters
    {
        get => Internal.ResourceHarvesters;
        set => Internal.ResourceHarvesters = value;
    }
    public bool ResourceHarvestersActive
    {
        get => Internal.ResourceHarvestersActive;
        set => Internal.ResourceHarvestersActive = value;
    }
    public float Right
    {
        get => Internal.Right;
        set => Internal.Right = value;
    }
    public float Roll
    {
        get => Internal.Roll;
        set => Internal.Roll = value;
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
    public bool SolarPanels
    {
        get => Internal.SolarPanels;
        set => Internal.SolarPanels = value;
    }
    public ControlSource Source
        => Internal.Source;
    public SpeedMode SpeedMode
    {
        get => Internal.SpeedMode;
        set => Internal.SpeedMode = value;
    }
    public bool StageLock
    {
        get => Internal.StageLock;
        set => Internal.StageLock = value;
    }
    public ControlState State
        => Internal.State;
    public float Throttle
    {
        get => Internal.Throttle;
        set => Internal.Throttle = value;
    }
    public float Up
    {
        get => Internal.Up;
        set => Internal.Up = value;
    }
    public float WheelSteering
    {
        get => Internal.WheelSteering;
        set => Internal.WheelSteering = value;
    }
    public float WheelThrottle
    {
        get => Internal.WheelThrottle;
        set => Internal.WheelThrottle = value;
    }
    public bool Wheels
    {
        get => Internal.Wheels;
        set => Internal.Wheels = value;
    }
    public float Yaw
    {
        get => Internal.Yaw;
        set => Internal.Yaw = value;
    }
    public IList<Vessel> ActivateNextStage()
        => Internal.ActivateNextStage().Select(item => new Vessel(item)).ToList();
    public Node AddNode(double ut, float prograde = 0f, float normal = 0f, float radial = 0f)
        => new Node(Internal.AddNode(ut, prograde, normal, radial));
    public bool GetActionGroup(uint group)
        => Internal.GetActionGroup(group);
    public void RemoveNodes()
        => Internal.RemoveNodes();
    public void SetActionGroup(uint group, bool state)
        => Internal.SetActionGroup(group, state);
    public void ToggleActionGroup(uint group)
        => Internal.ToggleActionGroup(group);
}
