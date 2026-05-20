using Google.Protobuf;

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
public class Control : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Control (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_ActivateNextStage")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Vessel> ActivateNextStage ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Control_ActivateNextStage", _args);
        return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Vessel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Vessel>), connection);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_AddNode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Node AddNode (double ut, float prograde = 0.0f, float normal = 0.0f, float radial = 0.0f)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
            global::KRPC.Client.Encoder.Encode (ut, typeof(double)),
            global::KRPC.Client.Encoder.Encode (prograde, typeof(float)),
            global::KRPC.Client.Encoder.Encode (normal, typeof(float)),
            global::KRPC.Client.Encoder.Encode (radial, typeof(float))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Control_AddNode", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Node)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node), connection);
    }

    /// <summary>
    /// Returns <c>true</c> if the given action group is enabled.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_GetActionGroup")]
    public bool GetActionGroup (uint group)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
            global::KRPC.Client.Encoder.Encode (group, typeof(uint))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Control_GetActionGroup", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Remove all maneuver nodes.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_RemoveNodes")]
    public void RemoveNodes ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
        };
        connection.Invoke ("SpaceCenter", "Control_RemoveNodes", _args);
    }

    /// <summary>
    /// Sets the state of the given action group.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    /// <param name="state"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_SetActionGroup")]
    public void SetActionGroup (uint group, bool state)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
            global::KRPC.Client.Encoder.Encode (group, typeof(uint)),
            global::KRPC.Client.Encoder.Encode (state, typeof(bool))
        };
        connection.Invoke ("SpaceCenter", "Control_SetActionGroup", _args);
    }

    /// <summary>
    /// Toggles the state of the given action group.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_ToggleActionGroup")]
    public void ToggleActionGroup (uint group)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
            global::KRPC.Client.Encoder.Encode (group, typeof(uint))
        };
        connection.Invoke ("SpaceCenter", "Control_ToggleActionGroup", _args);
    }

    /// <summary>
    /// The state of the abort action group.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Abort")]
    public bool Abort {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Abort", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Abort", _args);
        }
    }

    /// <summary>
    /// Returns whether all antennas on the vessel are deployed,
    /// and sets the deployment state of all antennas.
    /// See <see cref="M:SpaceCenter.Antenna.Deployed" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Antennas")]
    public bool Antennas {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Antennas", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Antennas", _args);
        }
    }

    /// <summary>
    /// The state of the wheel brakes.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Brakes")]
    public bool Brakes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Brakes", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Brakes", _args);
        }
    }

    /// <summary>
    /// Returns whether any of the cargo bays on the vessel are open,
    /// and sets the open state of all cargo bays.
    /// See <see cref="M:SpaceCenter.CargoBay.Open" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CargoBays")]
    public bool CargoBays {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CargoBays", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_CargoBays", _args);
        }
    }

    /// <summary>
    /// The current stage of the vessel. Corresponds to the stage number in
    /// the in-game UI.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CurrentStage")]
    public int CurrentStage {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CurrentStage", _args);
            return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
        }
    }

    /// <summary>
    /// The state of CustomAxis01.
    /// A value between -1 and 1.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CustomAxis01")]
    public float CustomAxis01 {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CustomAxis01", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_CustomAxis01", _args);
        }
    }

    /// <summary>
    /// The state of CustomAxis02.
    /// A value between -1 and 1.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CustomAxis02")]
    public float CustomAxis02 {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CustomAxis02", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_CustomAxis02", _args);
        }
    }

    /// <summary>
    /// The state of CustomAxis03.
    /// A value between -1 and 1.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CustomAxis03")]
    public float CustomAxis03 {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CustomAxis03", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_CustomAxis03", _args);
        }
    }

    /// <summary>
    /// The state of CustomAxis04.
    /// A value between -1 and 1.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CustomAxis04")]
    public float CustomAxis04 {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CustomAxis04", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_CustomAxis04", _args);
        }
    }

    /// <summary>
    /// The state of the forward translational control.
    /// A value between -1 and 1.
    /// Equivalent to the h and n keys.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Forward")]
    public float Forward {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Forward", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Forward", _args);
        }
    }

    /// <summary>
    /// The state of the landing gear/legs.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Gear")]
    public bool Gear {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Gear", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Gear", _args);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_InputMode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ControlInputMode InputMode {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_InputMode", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ControlInputMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlInputMode), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlInputMode))
            };
            connection.Invoke ("SpaceCenter", "Control_set_InputMode", _args);
        }
    }

    /// <summary>
    /// Returns whether all of the air intakes on the vessel are open,
    /// and sets the open state of all air intakes.
    /// See <see cref="M:SpaceCenter.Intake.Open" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Intakes")]
    public bool Intakes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Intakes", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Intakes", _args);
        }
    }

    /// <summary>
    /// Returns whether all landing legs on the vessel are deployed,
    /// and sets the deployment state of all landing legs.
    /// Does not include wheels (for example landing gear).
    /// See <see cref="M:SpaceCenter.Leg.Deployed" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Legs")]
    public bool Legs {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Legs", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Legs", _args);
        }
    }

    /// <summary>
    /// The state of the lights.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Lights")]
    public bool Lights {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Lights", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Lights", _args);
        }
    }

    /// <summary>
    /// Returns a list of all existing maneuver nodes, ordered by time from first to last.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Nodes")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Node> Nodes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Nodes", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Node>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Node>), connection);
        }
    }

    /// <summary>
    /// Returns whether all parachutes on the vessel are deployed,
    /// and sets the deployment state of all parachutes.
    /// Cannot be set to <c>false</c>.
    /// See <see cref="M:SpaceCenter.Parachute.Deployed" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Parachutes")]
    public bool Parachutes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Parachutes", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Parachutes", _args);
        }
    }

    /// <summary>
    /// The state of the pitch control.
    /// A value between -1 and 1.
    /// Equivalent to the w and s keys.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Pitch")]
    public float Pitch {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Pitch", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Pitch", _args);
        }
    }

    /// <summary>
    /// The state of RCS.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_RCS")]
    public bool RCS {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_RCS", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_RCS", _args);
        }
    }

    /// <summary>
    /// Returns whether all radiators on the vessel are deployed,
    /// and sets the deployment state of all radiators.
    /// See <see cref="M:SpaceCenter.Radiator.Deployed" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Radiators")]
    public bool Radiators {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Radiators", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Radiators", _args);
        }
    }

    /// <summary>
    /// Returns whether all reactive wheels on the vessel are active,
    /// and sets the active state of all reaction wheels.
    /// See <see cref="M:SpaceCenter.ReactionWheel.Active" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_ReactionWheels")]
    public bool ReactionWheels {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_ReactionWheels", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_ReactionWheels", _args);
        }
    }

    /// <summary>
    /// Returns whether all of the resource harvesters on the vessel are deployed,
    /// and sets the deployment state of all resource harvesters.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.Deployed" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_ResourceHarvesters")]
    public bool ResourceHarvesters {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_ResourceHarvesters", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_ResourceHarvesters", _args);
        }
    }

    /// <summary>
    /// Returns whether any of the resource harvesters on the vessel are active,
    /// and sets the active state of all resource harvesters.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.Active" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_ResourceHarvestersActive")]
    public bool ResourceHarvestersActive {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_ResourceHarvestersActive", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_ResourceHarvestersActive", _args);
        }
    }

    /// <summary>
    /// The state of the right translational control.
    /// A value between -1 and 1.
    /// Equivalent to the j and l keys.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Right")]
    public float Right {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Right", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Right", _args);
        }
    }

    /// <summary>
    /// The state of the roll control.
    /// A value between -1 and 1.
    /// Equivalent to the q and e keys.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Roll")]
    public float Roll {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Roll", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Roll", _args);
        }
    }

    /// <summary>
    /// The state of SAS.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.SAS" /></remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_SAS")]
    public bool SAS {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_SAS", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_SAS", _args);
        }
    }

    /// <summary>
    /// The current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to
    /// the left of the navball that appear when SAS is enabled.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.SASMode" /></remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_SASMode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.SASMode SASMode {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_SASMode", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.SASMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.SASMode), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.SASMode))
            };
            connection.Invoke ("SpaceCenter", "Control_set_SASMode", _args);
        }
    }

    /// <summary>
    /// Returns whether all solar panels on the vessel are deployed,
    /// and sets the deployment state of all solar panels.
    /// See <see cref="M:SpaceCenter.SolarPanel.Deployed" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_SolarPanels")]
    public bool SolarPanels {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_SolarPanels", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_SolarPanels", _args);
        }
    }

    /// <summary>
    /// The source of the vessels control, for example by a kerbal or a probe core.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Source")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ControlSource Source {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Source", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ControlSource)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSource), connection);
        }
    }

    /// <summary>
    /// The current <see cref="T:SpaceCenter.SpeedMode" /> of the navball.
    /// This is the mode displayed next to the speed at the top of the navball.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_SpeedMode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.SpeedMode SpeedMode {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_SpeedMode", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.SpeedMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.SpeedMode), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.SpeedMode))
            };
            connection.Invoke ("SpaceCenter", "Control_set_SpeedMode", _args);
        }
    }

    /// <summary>
    /// Whether staging is locked on the vessel.
    /// </summary>
    /// <remarks>
    /// This is equivalent to locking the staging using Alt+L
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_StageLock")]
    public bool StageLock {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_StageLock", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_StageLock", _args);
        }
    }

    /// <summary>
    /// The control state of the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_State")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ControlState State {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_State", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ControlState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlState), connection);
        }
    }

    /// <summary>
    /// The state of the throttle. A value between 0 and 1.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Throttle")]
    public float Throttle {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Throttle", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Throttle", _args);
        }
    }

    /// <summary>
    /// The state of the up translational control.
    /// A value between -1 and 1.
    /// Equivalent to the i and k keys.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Up")]
    public float Up {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Up", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Up", _args);
        }
    }

    /// <summary>
    /// The state of the wheel steering.
    /// A value between -1 and 1.
    /// A value of 1 steers to the left, and a value of -1 steers to the right.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_WheelSteering")]
    public float WheelSteering {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_WheelSteering", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_WheelSteering", _args);
        }
    }

    /// <summary>
    /// The state of the wheel throttle.
    /// A value between -1 and 1.
    /// A value of 1 rotates the wheels forwards, a value of -1 rotates
    /// the wheels backwards.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_WheelThrottle")]
    public float WheelThrottle {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_WheelThrottle", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_WheelThrottle", _args);
        }
    }

    /// <summary>
    /// Returns whether all wheels on the vessel are deployed,
    /// and sets the deployment state of all wheels.
    /// Does not include landing legs.
    /// See <see cref="M:SpaceCenter.Wheel.Deployed" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Wheels")]
    public bool Wheels {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Wheels", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Wheels", _args);
        }
    }

    /// <summary>
    /// The state of the yaw control.
    /// A value between -1 and 1.
    /// Equivalent to the a and d keys.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Yaw")]
    public float Yaw {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Yaw", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Control_set_Yaw", _args);
        }
    }
}