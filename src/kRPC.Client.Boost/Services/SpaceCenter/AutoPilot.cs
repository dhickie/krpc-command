using Google.Protobuf;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Provides basic auto-piloting utilities for a vessel.
/// Created by calling <see cref="M:SpaceCenter.Vessel.AutoPilot" />.
/// </summary>
/// <remarks>
/// If a client engages the auto-pilot and then closes its connection to the server,
/// the auto-pilot will be disengaged and its target reference frame, direction and roll
/// reset to default.
/// </remarks>
public class AutoPilot : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public AutoPilot (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Disengage the auto-pilot.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_Disengage")]
    public void Disengage ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
        };
        connection.Invoke ("SpaceCenter", "AutoPilot_Disengage", _args);
    }

    /// <summary>
    /// Engage the auto-pilot.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_Engage")]
    public void Engage ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
        };
        connection.Invoke ("SpaceCenter", "AutoPilot_Engage", _args);
    }

    /// <summary>
    /// Set target pitch and heading angles.
    /// </summary>
    /// <param name="pitch">Target pitch angle, in degrees between -90° and +90°.</param>
    /// <param name="heading">Target heading angle, in degrees between 0° and 360°.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_TargetPitchAndHeading")]
    public void TargetPitchAndHeading (float pitch, float heading)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
            global::KRPC.Client.Encoder.Encode (pitch, typeof(float)),
            global::KRPC.Client.Encoder.Encode (heading, typeof(float))
        };
        connection.Invoke ("SpaceCenter", "AutoPilot_TargetPitchAndHeading", _args);
    }

    /// <summary>
    /// Blocks until the vessel is pointing in the target direction and has
    /// the target roll (if set). Throws an exception if the auto-pilot has not been engaged.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_Wait")]
    public void Wait ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
        };
        connection.Invoke ("SpaceCenter", "AutoPilot_Wait", _args);
    }

    /// <summary>
    /// The angle at which the autopilot considers the vessel to be pointing
    /// close to the target.
    /// This determines the midpoint of the target velocity attenuation function.
    /// A vector of three angles, in degrees, one for each of the pitch, roll and yaw axes.
    /// Defaults to 1° for each axis.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_AttenuationAngle")]
    public systemAlias::Tuple<double,double,double> AttenuationAngle {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_AttenuationAngle", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_AttenuationAngle", _args);
        }
    }

    /// <summary>
    /// Whether the rotation rate controllers PID parameters should be automatically tuned
    /// using the vessels moment of inertia and available torque. Defaults to <c>true</c>.
    /// See <see cref="M:SpaceCenter.AutoPilot.TimeToPeak" /> and <see cref="M:SpaceCenter.AutoPilot.Overshoot" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_AutoTune")]
    public bool AutoTune {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_AutoTune", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_AutoTune", _args);
        }
    }

    /// <summary>
    /// The time the vessel should take to come to a stop pointing in the target direction.
    /// This determines the angular acceleration used to decelerate the vessel.
    /// A vector of three times, in seconds, one for each of the pitch, roll and yaw axes.
    /// Defaults to 5 seconds for each axis.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_DecelerationTime")]
    public systemAlias::Tuple<double,double,double> DecelerationTime {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_DecelerationTime", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_DecelerationTime", _args);
        }
    }

    /// <summary>
    /// The error, in degrees, between the direction the ship has been asked
    /// to point in and the direction it is pointing in. Throws an exception if the auto-pilot
    /// has not been engaged and SAS is not enabled or is in stability assist mode.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_Error")]
    public float Error {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_Error", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The error, in degrees, between the vessels current and target heading.
    /// Throws an exception if the auto-pilot has not been engaged.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_HeadingError")]
    public float HeadingError {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_HeadingError", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The target overshoot percentage used to autotune the PID controllers.
    /// A vector of three values, between 0 and 1, for each of the pitch, roll and yaw axes.
    /// Defaults to 0.01 for each axis.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_Overshoot")]
    public systemAlias::Tuple<double,double,double> Overshoot {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_Overshoot", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_Overshoot", _args);
        }
    }

    /// <summary>
    /// The error, in degrees, between the vessels current and target pitch.
    /// Throws an exception if the auto-pilot has not been engaged.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_PitchError")]
    public float PitchError {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_PitchError", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Gains for the pitch PID controller.
    /// </summary>
    /// <remarks>
    /// When <see cref="M:SpaceCenter.AutoPilot.AutoTune" /> is true, these values are updated automatically,
    /// which will overwrite any manual changes.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_PitchPIDGains")]
    public systemAlias::Tuple<double,double,double> PitchPIDGains {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_PitchPIDGains", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_PitchPIDGains", _args);
        }
    }

    /// <summary>
    /// The reference frame for the target direction (<see cref="M:SpaceCenter.AutoPilot.TargetDirection" />).
    /// </summary>
    /// <remarks>
    /// An error will be thrown if this property is set to a reference frame that rotates with
    /// the vessel being controlled, as it is impossible to rotate the vessel in such a
    /// reference frame.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_ReferenceFrame")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_ReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_ReferenceFrame", _args);
        }
    }

    /// <summary>
    /// The error, in degrees, between the vessels current and target roll.
    /// Throws an exception if the auto-pilot has not been engaged or no target roll is set.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_RollError")]
    public float RollError {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_RollError", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Gains for the roll PID controller.
    /// </summary>
    /// <remarks>
    /// When <see cref="M:SpaceCenter.AutoPilot.AutoTune" /> is true, these values are updated automatically,
    /// which will overwrite any manual changes.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_RollPIDGains")]
    public systemAlias::Tuple<double,double,double> RollPIDGains {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_RollPIDGains", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_RollPIDGains", _args);
        }
    }

    /// <summary>
    /// The threshold at which the autopilot will try to match the target roll angle, if any.
    /// Defaults to 5 degrees.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_RollThreshold")]
    public double RollThreshold {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_RollThreshold", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_RollThreshold", _args);
        }
    }

    /// <summary>
    /// The state of SAS.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.Control.SAS" /></remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_SAS")]
    public bool SAS {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_SAS", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_SAS", _args);
        }
    }

    /// <summary>
    /// The current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to the left of the navball that appear
    /// when SAS is enabled.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.Control.SASMode" /></remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_SASMode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.SASMode SASMode {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_SASMode", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.SASMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.SASMode), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.SASMode))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_SASMode", _args);
        }
    }

    /// <summary>
    /// The maximum amount of time that the vessel should need to come to a complete stop.
    /// This determines the maximum angular velocity of the vessel.
    /// A vector of three stopping times, in seconds, one for each of the pitch, roll
    /// and yaw axes. Defaults to 0.5 seconds for each axis.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_StoppingTime")]
    public systemAlias::Tuple<double,double,double> StoppingTime {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_StoppingTime", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_StoppingTime", _args);
        }
    }

    /// <summary>
    /// Direction vector corresponding to the target pitch and heading.
    /// This is in the reference frame specified by <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TargetDirection")]
    public systemAlias::Tuple<double,double,double> TargetDirection {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TargetDirection", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_TargetDirection", _args);
        }
    }

    /// <summary>
    /// The target heading, in degrees, between 0° and 360°.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TargetHeading")]
    public float TargetHeading {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TargetHeading", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_TargetHeading", _args);
        }
    }

    /// <summary>
    /// The target pitch, in degrees, between -90° and +90°.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TargetPitch")]
    public float TargetPitch {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TargetPitch", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_TargetPitch", _args);
        }
    }

    /// <summary>
    /// The target roll, in degrees. <c>NaN</c> if no target roll is set.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TargetRoll")]
    public float TargetRoll {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TargetRoll", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_TargetRoll", _args);
        }
    }

    /// <summary>
    /// The target time to peak used to autotune the PID controllers.
    /// A vector of three times, in seconds, for each of the pitch, roll and yaw axes.
    /// Defaults to 3 seconds for each axis.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TimeToPeak")]
    public systemAlias::Tuple<double,double,double> TimeToPeak {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TimeToPeak", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_TimeToPeak", _args);
        }
    }

    /// <summary>
    /// Gains for the yaw PID controller.
    /// </summary>
    /// <remarks>
    /// When <see cref="M:SpaceCenter.AutoPilot.AutoTune" /> is true, these values are updated automatically,
    /// which will overwrite any manual changes.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_YawPIDGains")]
    public systemAlias::Tuple<double,double,double> YawPIDGains {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_YawPIDGains", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_set_YawPIDGains", _args);
        }
    }
}