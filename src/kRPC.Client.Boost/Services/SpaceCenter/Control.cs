using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Used to manipulate the controls of a vessel. This includes adjusting the
/// throttle, enabling/disabling systems such as SAS and RCS, or altering the
/// direction in which the vessel is pointing.
/// Obtained by calling <see cref="M:SpaceCenter.Vessel.Control" />.
/// </summary>
/// <remarks>
/// Control inputs (such as pitch, yaw and roll) are zeroed when all clients
/// that have set one or more of these inputs are no longer connected.
/// </remarks>
public class Control : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Control (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Activates the next stage. Equivalent to pressing the space bar in-game.
    /// </summary>
    /// <returns>A list of vessel objects that are jettisoned from the active vessel.</returns>
    /// <remarks>
    /// When called, the active vessel may change. It is therefore possible that,
    /// after calling this function, the object(s) returned by previous call(s) to
    /// <see cref="M:SpaceCenter.ActiveVessel" /> no longer refer to the active vessel.
    /// Throws an exception if staging is locked.
    /// </remarks>
    [Rpc ("SpaceCenter", "Control_ActivateNextStage")]
    public IList<Vessel> ActivateNextStage ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<Vessel>> ("SpaceCenter", "Control_ActivateNextStage", args);
    }

    /// <summary>
    /// Creates a maneuver node at the given universal time, and returns a
    /// <see cref="T:SpaceCenter.Node" /> object that can be used to modify it.
    /// Optionally sets the magnitude of the delta-v for the maneuver node
    /// in the prograde, normal and radial directions.
    /// </summary>
    /// <param name="ut">Universal time of the maneuver node.</param>
    /// <param name="prograde">Delta-v in the prograde direction.</param>
    /// <param name="normal">Delta-v in the normal direction.</param>
    /// <param name="radial">Delta-v in the radial direction.</param>
    [Rpc ("SpaceCenter", "Control_AddNode")]
    public Node AddNode (double ut, float prograde = 0.0f, float normal = 0.0f, float radial = 0.0f)
    {
        var args = new object[] {
            this,
            ut,
            prograde,
            normal,
            radial
        };
        return Connection.Invoke<Node> ("SpaceCenter", "Control_AddNode", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the given action group is enabled.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    [Rpc ("SpaceCenter", "Control_GetActionGroup")]
    public bool GetActionGroup (uint group)
    {
        var args = new object[] {
            this,
            group
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Control_GetActionGroup", args);
    }

    /// <summary>
    /// Remove all maneuver nodes.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_RemoveNodes")]
    public void RemoveNodes ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Control_RemoveNodes", args);
    }

    /// <summary>
    /// Sets the state of the given action group.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    /// <param name="state"></param>
    [Rpc ("SpaceCenter", "Control_SetActionGroup")]
    public void SetActionGroup (uint group, bool state)
    {
        var args = new object[] {
            this,
            group,
            state
        };
        Connection.Invoke ("SpaceCenter", "Control_SetActionGroup", args);
    }

    /// <summary>
    /// Toggles the state of the given action group.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    [Rpc ("SpaceCenter", "Control_ToggleActionGroup")]
    public void ToggleActionGroup (uint group)
    {
        var args = new object[] {
            this,
            group
        };
        Connection.Invoke ("SpaceCenter", "Control_ToggleActionGroup", args);
    }

    /// <summary>
    /// The state of the abort action group.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Abort")]
    public bool Abort {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Abort", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Abort", args);
        }
    }

    /// <summary>
    /// Returns whether all antennas on the vessel are deployed,
    /// and sets the deployment state of all antennas.
    /// See <see cref="M:SpaceCenter.Antenna.Deployed" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Antennas")]
    public bool Antennas {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Antennas", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Antennas", args);
        }
    }

    /// <summary>
    /// The state of the wheel brakes.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Brakes")]
    public bool Brakes {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Brakes", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Brakes", args);
        }
    }

    /// <summary>
    /// Returns whether any of the cargo bays on the vessel are open,
    /// and sets the open state of all cargo bays.
    /// See <see cref="M:SpaceCenter.CargoBay.Open" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_CargoBays")]
    public bool CargoBays {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_CargoBays", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_CargoBays", args);
        }
    }

    /// <summary>
    /// The current stage of the vessel. Corresponds to the stage number in
    /// the in-game UI.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_CurrentStage")]
    public int CurrentStage {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<int> ("SpaceCenter", "Control_get_CurrentStage", args);
        }
    }

    /// <summary>
    /// The state of CustomAxis01.
    /// A value between -1 and 1.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_CustomAxis01")]
    public float CustomAxis01 {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_CustomAxis01", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_CustomAxis01", args);
        }
    }

    /// <summary>
    /// The state of CustomAxis02.
    /// A value between -1 and 1.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_CustomAxis02")]
    public float CustomAxis02 {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_CustomAxis02", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_CustomAxis02", args);
        }
    }

    /// <summary>
    /// The state of CustomAxis03.
    /// A value between -1 and 1.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_CustomAxis03")]
    public float CustomAxis03 {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_CustomAxis03", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_CustomAxis03", args);
        }
    }

    /// <summary>
    /// The state of CustomAxis04.
    /// A value between -1 and 1.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_CustomAxis04")]
    public float CustomAxis04 {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_CustomAxis04", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_CustomAxis04", args);
        }
    }

    /// <summary>
    /// The state of the forward translational control.
    /// A value between -1 and 1.
    /// Equivalent to the h and n keys.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Forward")]
    public float Forward {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_Forward", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Forward", args);
        }
    }

    /// <summary>
    /// The state of the landing gear/legs.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Gear")]
    public bool Gear {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Gear", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Gear", args);
        }
    }

    /// <summary>
    /// Sets the behavior of the pitch, yaw, roll and translation control inputs.
    /// When set to additive, these inputs are added to the vessels current inputs.
    /// This mode is the default.
    /// When set to override, these inputs (if non-zero) override the vessels inputs.
    /// This mode prevents keyboard control, or SAS, from interfering with the controls when
    /// they are set.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_InputMode")]
    public ControlInputMode InputMode {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ControlInputMode> ("SpaceCenter", "Control_get_InputMode", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_InputMode", args);
        }
    }

    /// <summary>
    /// Returns whether all of the air intakes on the vessel are open,
    /// and sets the open state of all air intakes.
    /// See <see cref="M:SpaceCenter.Intake.Open" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Intakes")]
    public bool Intakes {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Intakes", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Intakes", args);
        }
    }

    /// <summary>
    /// Returns whether all landing legs on the vessel are deployed,
    /// and sets the deployment state of all landing legs.
    /// Does not include wheels (for example landing gear).
    /// See <see cref="M:SpaceCenter.Leg.Deployed" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Legs")]
    public bool Legs {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Legs", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Legs", args);
        }
    }

    /// <summary>
    /// The state of the lights.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Lights")]
    public bool Lights {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Lights", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Lights", args);
        }
    }

    /// <summary>
    /// Returns a list of all existing maneuver nodes, ordered by time from first to last.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Nodes")]
    public IList<Node> Nodes {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Node>> ("SpaceCenter", "Control_get_Nodes", args);
        }
    }

    /// <summary>
    /// Returns whether all parachutes on the vessel are deployed,
    /// and sets the deployment state of all parachutes.
    /// Cannot be set to <c>false</c>.
    /// See <see cref="M:SpaceCenter.Parachute.Deployed" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Parachutes")]
    public bool Parachutes {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Parachutes", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Parachutes", args);
        }
    }

    /// <summary>
    /// The state of the pitch control.
    /// A value between -1 and 1.
    /// Equivalent to the w and s keys.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Pitch")]
    public float Pitch {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_Pitch", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Pitch", args);
        }
    }

    /// <summary>
    /// The state of RCS.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_RCS")]
    public bool RCS {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_RCS", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_RCS", args);
        }
    }

    /// <summary>
    /// Returns whether all radiators on the vessel are deployed,
    /// and sets the deployment state of all radiators.
    /// See <see cref="M:SpaceCenter.Radiator.Deployed" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Radiators")]
    public bool Radiators {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Radiators", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Radiators", args);
        }
    }

    /// <summary>
    /// Returns whether all reactive wheels on the vessel are active,
    /// and sets the active state of all reaction wheels.
    /// See <see cref="M:SpaceCenter.ReactionWheel.Active" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_ReactionWheels")]
    public bool ReactionWheels {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_ReactionWheels", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_ReactionWheels", args);
        }
    }

    /// <summary>
    /// Returns whether all of the resource harvesters on the vessel are deployed,
    /// and sets the deployment state of all resource harvesters.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.Deployed" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_ResourceHarvesters")]
    public bool ResourceHarvesters {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_ResourceHarvesters", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_ResourceHarvesters", args);
        }
    }

    /// <summary>
    /// Returns whether any of the resource harvesters on the vessel are active,
    /// and sets the active state of all resource harvesters.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.Active" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_ResourceHarvestersActive")]
    public bool ResourceHarvestersActive {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_ResourceHarvestersActive", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_ResourceHarvestersActive", args);
        }
    }

    /// <summary>
    /// The state of the right translational control.
    /// A value between -1 and 1.
    /// Equivalent to the j and l keys.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Right")]
    public float Right {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_Right", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Right", args);
        }
    }

    /// <summary>
    /// The state of the roll control.
    /// A value between -1 and 1.
    /// Equivalent to the q and e keys.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Roll")]
    public float Roll {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_Roll", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Roll", args);
        }
    }

    /// <summary>
    /// The state of SAS.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.SAS" /></remarks>
    [Rpc ("SpaceCenter", "Control_get_SAS")]
    public bool SAS {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_SAS", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_SAS", args);
        }
    }

    /// <summary>
    /// The current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to
    /// the left of the navball that appear when SAS is enabled.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.SASMode" /></remarks>
    [Rpc ("SpaceCenter", "Control_get_SASMode")]
    public SASMode SASMode {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<SASMode> ("SpaceCenter", "Control_get_SASMode", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_SASMode", args);
        }
    }

    /// <summary>
    /// Returns whether all solar panels on the vessel are deployed,
    /// and sets the deployment state of all solar panels.
    /// See <see cref="M:SpaceCenter.SolarPanel.Deployed" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_SolarPanels")]
    public bool SolarPanels {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_SolarPanels", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_SolarPanels", args);
        }
    }

    /// <summary>
    /// The source of the vessels control, for example by a kerbal or a probe core.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Source")]
    public ControlSource Source {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ControlSource> ("SpaceCenter", "Control_get_Source", args);
        }
    }

    /// <summary>
    /// The current <see cref="T:SpaceCenter.SpeedMode" /> of the navball.
    /// This is the mode displayed next to the speed at the top of the navball.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_SpeedMode")]
    public SpeedMode SpeedMode {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<SpeedMode> ("SpaceCenter", "Control_get_SpeedMode", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_SpeedMode", args);
        }
    }

    /// <summary>
    /// Whether staging is locked on the vessel.
    /// </summary>
    /// <remarks>
    /// This is equivalent to locking the staging using Alt+L
    /// </remarks>
    [Rpc ("SpaceCenter", "Control_get_StageLock")]
    public bool StageLock {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_StageLock", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_StageLock", args);
        }
    }

    /// <summary>
    /// The control state of the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_State")]
    public ControlState State {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ControlState> ("SpaceCenter", "Control_get_State", args);
        }
    }

    /// <summary>
    /// The state of the throttle. A value between 0 and 1.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Throttle")]
    public float Throttle {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_Throttle", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Throttle", args);
        }
    }

    /// <summary>
    /// The state of the up translational control.
    /// A value between -1 and 1.
    /// Equivalent to the i and k keys.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Up")]
    public float Up {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_Up", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Up", args);
        }
    }

    /// <summary>
    /// The state of the wheel steering.
    /// A value between -1 and 1.
    /// A value of 1 steers to the left, and a value of -1 steers to the right.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_WheelSteering")]
    public float WheelSteering {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_WheelSteering", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_WheelSteering", args);
        }
    }

    /// <summary>
    /// The state of the wheel throttle.
    /// A value between -1 and 1.
    /// A value of 1 rotates the wheels forwards, a value of -1 rotates
    /// the wheels backwards.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_WheelThrottle")]
    public float WheelThrottle {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_WheelThrottle", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_WheelThrottle", args);
        }
    }

    /// <summary>
    /// Returns whether all wheels on the vessel are deployed,
    /// and sets the deployment state of all wheels.
    /// Does not include landing legs.
    /// See <see cref="M:SpaceCenter.Wheel.Deployed" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Wheels")]
    public bool Wheels {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Control_get_Wheels", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Wheels", args);
        }
    }

    /// <summary>
    /// The state of the yaw control.
    /// A value between -1 and 1.
    /// Equivalent to the a and d keys.
    /// </summary>
    [Rpc ("SpaceCenter", "Control_get_Yaw")]
    public float Yaw {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Control_get_Yaw", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Control_set_Yaw", args);
        }
    }
}
