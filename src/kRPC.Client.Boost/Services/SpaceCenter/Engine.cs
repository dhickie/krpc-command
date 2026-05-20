using Google.Protobuf;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An engine, including ones of various types.
/// For example liquid fuelled gimballed engines, solid rocket boosters and jet engines.
/// Obtained by calling <see cref="M:SpaceCenter.Part.Engine" />.
/// </summary>
/// <remarks>
/// For RCS thrusters <see cref="M:SpaceCenter.Part.RCS" />.
/// </remarks>
public class Engine : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Engine (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and with its throttle set to 100%.
    /// Returns zero if the engine does not have any fuel.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_AvailableThrustAt")]
    public float AvailableThrustAt (double pressure)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
            global::KRPC.Client.Encoder.Encode (pressure, typeof(double))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Engine_AvailableThrustAt", _args);
        return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and fueled, with its throttle and throttle limiter set to 100%.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_MaxThrustAt")]
    public float MaxThrustAt (double pressure)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
            global::KRPC.Client.Encoder.Encode (pressure, typeof(double))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Engine_MaxThrustAt", _args);
        return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
    }

    /// <summary>
    /// The specific impulse of the engine under the given pressure, in seconds. Returns zero
    /// if the engine is not active.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_SpecificImpulseAt")]
    public float SpecificImpulseAt (double pressure)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
            global::KRPC.Client.Encoder.Encode (pressure, typeof(double))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Engine_SpecificImpulseAt", _args);
        return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
    }

    /// <summary>
    /// Toggle the current engine mode.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_ToggleMode")]
    public void ToggleMode ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
        };
        connection.Invoke ("SpaceCenter", "Engine_ToggleMode", _args);
    }

    /// <summary>
    /// Whether the engine is active. Setting this attribute may have no effect,
    /// depending on <see cref="M:SpaceCenter.Engine.CanShutdown" /> and <see cref="M:SpaceCenter.Engine.CanRestart" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Active")]
    public bool Active {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Active", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Engine_set_Active", _args);
        }
    }

    /// <summary>
    /// Whether the engine will automatically switch modes.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_AutoModeSwitch")]
    public bool AutoModeSwitch {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_AutoModeSwitch", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Engine_set_AutoModeSwitch", _args);
        }
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and with its throttle set to 100%.
    /// Returns zero if the engine does not have any fuel.
    /// Takes the engine's current <see cref="M:SpaceCenter.Engine.ThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_AvailableThrust")]
    public float AvailableThrust {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_AvailableThrust", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The available torque, in Newton meters, that can be produced by this engine,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// Returns zero if the engine is inactive, or not gimballed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_AvailableTorque")]
    public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableTorque {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_AvailableTorque", _args);
            return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
        }
    }

    /// <summary>
    /// Whether the engine can be restarted once shutdown. If the engine cannot be shutdown,
    /// returns <c>false</c>. For example, this is <c>true</c> for liquid fueled rockets
    /// and <c>false</c> for solid rocket boosters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_CanRestart")]
    public bool CanRestart {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_CanRestart", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the engine can be shutdown once activated. For example, this is
    /// <c>true</c> for liquid fueled rockets and <c>false</c> for solid rocket boosters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_CanShutdown")]
    public bool CanShutdown {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_CanShutdown", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The gimbal limiter of the engine. A value between 0 and 1.
    /// Returns 0 if the gimbal is locked.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_GimbalLimit")]
    public float GimbalLimit {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_GimbalLimit", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Engine_set_GimbalLimit", _args);
        }
    }

    /// <summary>
    /// Whether the engines gimbal is locked in place. Setting this attribute has
    /// no effect if the engine is not gimballed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_GimbalLocked")]
    public bool GimbalLocked {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_GimbalLocked", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Engine_set_GimbalLocked", _args);
        }
    }

    /// <summary>
    /// The range over which the gimbal can move, in degrees.
    /// Returns 0 if the engine is not gimballed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_GimbalRange")]
    public float GimbalRange {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_GimbalRange", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the engine is gimballed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Gimballed")]
    public bool Gimballed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Gimballed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the engine has any fuel available.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_HasFuel")]
    public bool HasFuel {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_HasFuel", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the engine has multiple modes of operation.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_HasModes")]
    public bool HasModes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_HasModes", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the independent throttle is enabled for the engine.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_IndependentThrottle")]
    public bool IndependentThrottle {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_IndependentThrottle", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Engine_set_IndependentThrottle", _args);
        }
    }

    /// <summary>
    /// The specific impulse of the engine at sea level on Kerbin, in seconds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_KerbinSeaLevelSpecificImpulse")]
    public float KerbinSeaLevelSpecificImpulse {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_KerbinSeaLevelSpecificImpulse", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and fueled, with its throttle and throttle limiter set to 100%.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_MaxThrust")]
    public float MaxThrust {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_MaxThrust", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The maximum amount of thrust that can be produced by the engine in a
    /// vacuum, in Newtons. This is the amount of thrust produced by the engine
    /// when activated, <see cref="M:SpaceCenter.Engine.ThrustLimit" /> is set to 100%, the main
    /// vessel's throttle is set to 100% and the engine is in a vacuum.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_MaxVacuumThrust")]
    public float MaxVacuumThrust {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_MaxVacuumThrust", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The name of the current engine mode.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Mode")]
    public string Mode {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Mode", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (value, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Engine_set_Mode", _args);
        }
    }

    /// <summary>
    /// The available modes for the engine.
    /// A dictionary mapping mode names to <see cref="T:SpaceCenter.Engine" /> objects.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Modes")]
    public global::System.Collections.Generic.IDictionary<string,global::kRPC.Client.Boost.Services.SpaceCenter.Engine> Modes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Modes", _args);
            return (global::System.Collections.Generic.IDictionary<string,global::kRPC.Client.Boost.Services.SpaceCenter.Engine>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,global::kRPC.Client.Boost.Services.SpaceCenter.Engine>), connection);
        }
    }

    /// <summary>
    /// The part object for this engine.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// The names of the propellants that the engine consumes.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_PropellantNames")]
    public global::System.Collections.Generic.IList<string> PropellantNames {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_PropellantNames", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// The ratio of resources that the engine consumes. A dictionary mapping resource names
    /// to the ratio at which they are consumed by the engine.
    /// </summary>
    /// <remarks>
    /// For example, if the ratios are 0.6 for LiquidFuel and 0.4 for Oxidizer, then for every
    /// 0.6 units of LiquidFuel that the engine burns, it will burn 0.4 units of Oxidizer.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_PropellantRatios")]
    public global::System.Collections.Generic.IDictionary<string,float> PropellantRatios {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_PropellantRatios", _args);
            return (global::System.Collections.Generic.IDictionary<string,float>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,float>), connection);
        }
    }

    /// <summary>
    /// The propellants that the engine consumes.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Propellants")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Propellant> Propellants {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Propellants", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Propellant>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Propellant>), connection);
        }
    }

    /// <summary>
    /// The current specific impulse of the engine, in seconds. Returns zero
    /// if the engine is not active.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_SpecificImpulse")]
    public float SpecificImpulse {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_SpecificImpulse", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The current throttle setting for the engine. A value between 0 and 1.
    /// This is not necessarily the same as the vessel's main throttle
    /// setting, as some engines take time to adjust their throttle
    /// (such as jet engines), or independent throttle may be enabled.
    ///
    /// When the engine's independent throttle is enabled
    /// (see <see cref="M:SpaceCenter.Engine.IndependentThrottle" />), can be used to set the throttle percentage.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Throttle")]
    public float Throttle {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Throttle", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Engine_set_Throttle", _args);
        }
    }

    /// <summary>
    /// Whether the <see cref="M:SpaceCenter.Control.Throttle" /> affects the engine. For example,
    /// this is <c>true</c> for liquid fueled rockets, and <c>false</c> for solid rocket
    /// boosters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_ThrottleLocked")]
    public bool ThrottleLocked {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_ThrottleLocked", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The current amount of thrust being produced by the engine, in Newtons.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Thrust")]
    public float Thrust {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Thrust", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The thrust limiter of the engine. A value between 0 and 1. Setting this
    /// attribute may have no effect, for example the thrust limit for a solid
    /// rocket booster cannot be changed in flight.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_ThrustLimit")]
    public float ThrustLimit {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_ThrustLimit", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Engine_set_ThrustLimit", _args);
        }
    }

    /// <summary>
    /// The components of the engine that generate thrust.
    /// </summary>
    /// <remarks>
    /// For example, this corresponds to the rocket nozzel on a solid rocket booster,
    /// or the individual nozzels on a RAPIER engine.
    /// The overall thrust produced by the engine, as reported by <see cref="M:SpaceCenter.Engine.AvailableThrust" />,
    /// <see cref="M:SpaceCenter.Engine.MaxThrust" /> and others, is the sum of the thrust generated by each thruster.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Thrusters")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Thruster> Thrusters {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Thrusters", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Thruster>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Thruster>), connection);
        }
    }

    /// <summary>
    /// The vacuum specific impulse of the engine, in seconds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_VacuumSpecificImpulse")]
    public float VacuumSpecificImpulse {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_VacuumSpecificImpulse", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }
}