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
    internal readonly BaseControl Wrapped;

    internal Control(BaseControl control)
    {
        Wrapped = control;
    }

    public bool Abort
    {
        get => Wrapped.Abort;
        set => Wrapped.Abort = value;
    }

    public bool Antennas
    {
        get => Wrapped.Antennas;
        set => Wrapped.Antennas = value;
    }

    public bool Brakes
    {
        get => Wrapped.Brakes;
        set => Wrapped.Brakes = value;
    }

    public bool CargoBays
    {
        get => Wrapped.CargoBays;
        set => Wrapped.CargoBays = value;
    }

    public int CurrentStage
        => Wrapped.CurrentStage;

    public float CustomAxis01
    {
        get => Wrapped.CustomAxis01;
        set => Wrapped.CustomAxis01 = value;
    }

    public float CustomAxis02
    {
        get => Wrapped.CustomAxis02;
        set => Wrapped.CustomAxis02 = value;
    }

    public float CustomAxis03
    {
        get => Wrapped.CustomAxis03;
        set => Wrapped.CustomAxis03 = value;
    }

    public float CustomAxis04
    {
        get => Wrapped.CustomAxis04;
        set => Wrapped.CustomAxis04 = value;
    }

    public float Forward
    {
        get => Wrapped.Forward;
        set => Wrapped.Forward = value;
    }

    public bool Gear
    {
        get => Wrapped.Gear;
        set => Wrapped.Gear = value;
    }

    public ControlInputMode InputMode
    {
        get => Wrapped.InputMode;
        set => Wrapped.InputMode = value;
    }

    public bool Intakes
    {
        get => Wrapped.Intakes;
        set => Wrapped.Intakes = value;
    }

    public bool Legs
    {
        get => Wrapped.Legs;
        set => Wrapped.Legs = value;
    }

    public bool Lights
    {
        get => Wrapped.Lights;
        set => Wrapped.Lights = value;
    }

    public IList<Node> Nodes
        => Wrapped.Nodes.Select(item => new Node(item)).ToList();

    public bool Parachutes
    {
        get => Wrapped.Parachutes;
        set => Wrapped.Parachutes = value;
    }

    public float Pitch
    {
        get => Wrapped.Pitch;
        set => Wrapped.Pitch = value;
    }

    public bool RCS
    {
        get => Wrapped.RCS;
        set => Wrapped.RCS = value;
    }

    public bool Radiators
    {
        get => Wrapped.Radiators;
        set => Wrapped.Radiators = value;
    }

    public bool ReactionWheels
    {
        get => Wrapped.ReactionWheels;
        set => Wrapped.ReactionWheels = value;
    }

    public bool ResourceHarvesters
    {
        get => Wrapped.ResourceHarvesters;
        set => Wrapped.ResourceHarvesters = value;
    }

    public bool ResourceHarvestersActive
    {
        get => Wrapped.ResourceHarvestersActive;
        set => Wrapped.ResourceHarvestersActive = value;
    }

    public float Right
    {
        get => Wrapped.Right;
        set => Wrapped.Right = value;
    }

    public float Roll
    {
        get => Wrapped.Roll;
        set => Wrapped.Roll = value;
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

    public bool SolarPanels
    {
        get => Wrapped.SolarPanels;
        set => Wrapped.SolarPanels = value;
    }

    public ControlSource Source
        => Wrapped.Source;

    public SpeedMode SpeedMode
    {
        get => Wrapped.SpeedMode;
        set => Wrapped.SpeedMode = value;
    }

    public bool StageLock
    {
        get => Wrapped.StageLock;
        set => Wrapped.StageLock = value;
    }

    public ControlState State
        => Wrapped.State;

    public float Throttle
    {
        get => Wrapped.Throttle;
        set => Wrapped.Throttle = value;
    }

    public float Up
    {
        get => Wrapped.Up;
        set => Wrapped.Up = value;
    }

    public float WheelSteering
    {
        get => Wrapped.WheelSteering;
        set => Wrapped.WheelSteering = value;
    }

    public float WheelThrottle
    {
        get => Wrapped.WheelThrottle;
        set => Wrapped.WheelThrottle = value;
    }

    public bool Wheels
    {
        get => Wrapped.Wheels;
        set => Wrapped.Wheels = value;
    }

    public float Yaw
    {
        get => Wrapped.Yaw;
        set => Wrapped.Yaw = value;
    }

    public IList<Vessel> ActivateNextStage()
        => Wrapped.ActivateNextStage().Select(item => new Vessel(item)).ToList();

    public Node AddNode(double ut, float prograde = 0f, float normal = 0f, float radial = 0f)
        => new Node(Wrapped.AddNode(ut, prograde, normal, radial));

    public bool GetActionGroup(uint group)
        => Wrapped.GetActionGroup(group);

    public void RemoveNodes()
        => Wrapped.RemoveNodes();

    public void SetActionGroup(uint group, bool state)
        => Wrapped.SetActionGroup(group, state);

    public void ToggleActionGroup(uint group)
        => Wrapped.ToggleActionGroup(group);
}
