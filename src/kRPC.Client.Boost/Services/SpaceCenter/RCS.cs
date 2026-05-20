using Google.Protobuf;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An RCS block or thruster. Obtained by calling <see cref="M:SpaceCenter.Part.RCS" />.
/// </summary>
public class RCS : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RCS (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the RCS thrusters are active.
    /// An RCS thruster is inactive if the RCS action group is disabled
    /// (<see cref="M:SpaceCenter.Control.RCS" />), the RCS thruster itself is not enabled
    /// (<see cref="M:SpaceCenter.RCS.Enabled" />) or it is covered by a fairing (<see cref="M:SpaceCenter.Part.Shielded" />).
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Active")]
    public bool Active {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Active", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The available force, in Newtons, that can be produced by this RCS,
    /// in the positive and negative x, y and z axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// Returns zero if RCS is disabled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_AvailableForce")]
    public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableForce {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_AvailableForce", _args);
            return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
        }
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the thruster when activated.
    /// Returns zero if the thruster does not have any fuel.
    /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.ThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_AvailableThrust")]
    public float AvailableThrust {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_AvailableThrust", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The available torque, in Newton meters, that can be produced by this RCS,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// Returns zero if RCS is disable.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_AvailableTorque")]
    public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableTorque {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_AvailableTorque", _args);
            return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
        }
    }

    /// <summary>
    /// Whether the RCS thrusters are enabled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Enabled")]
    public bool Enabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Enabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RCS_set_Enabled", _args);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_ForwardEnabled")]
    public bool ForwardEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_ForwardEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RCS_set_ForwardEnabled", _args);
        }
    }

    /// <summary>
    /// Whether the RCS has fuel available.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_HasFuel")]
    public bool HasFuel {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_HasFuel", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The specific impulse of the RCS at sea level on Kerbin, in seconds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse")]
    public float KerbinSeaLevelSpecificImpulse {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The maximum amount of thrust that can be produced by the RCS thrusters when active,
    /// in Newtons.
    /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.ThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_MaxThrust")]
    public float MaxThrust {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_MaxThrust", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The maximum amount of thrust that can be produced by the RCS thrusters when active
    /// in a vacuum, in Newtons.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_MaxVacuumThrust")]
    public float MaxVacuumThrust {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_MaxVacuumThrust", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The part object for this RCS.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_PitchEnabled")]
    public bool PitchEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_PitchEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RCS_set_PitchEnabled", _args);
        }
    }

    /// <summary>
    /// The ratios of resources that the RCS consumes. A dictionary mapping resource names
    /// to the ratios at which they are consumed by the RCS.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_PropellantRatios")]
    public global::System.Collections.Generic.IDictionary<string,float> PropellantRatios {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_PropellantRatios", _args);
            return (global::System.Collections.Generic.IDictionary<string,float>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,float>), connection);
        }
    }

    /// <summary>
    /// The names of resources that the RCS consumes.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Propellants")]
    public global::System.Collections.Generic.IList<string> Propellants {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Propellants", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_RightEnabled")]
    public bool RightEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_RightEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RCS_set_RightEnabled", _args);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_RollEnabled")]
    public bool RollEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_RollEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RCS_set_RollEnabled", _args);
        }
    }

    /// <summary>
    /// The current specific impulse of the RCS, in seconds. Returns zero
    /// if the RCS is not active.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_SpecificImpulse")]
    public float SpecificImpulse {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_SpecificImpulse", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The thrust limiter of the thruster. A value between 0 and 1.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_ThrustLimit")]
    public float ThrustLimit {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_ThrustLimit", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "RCS_set_ThrustLimit", _args);
        }
    }

    /// <summary>
    /// A list of thrusters, one of each nozzel in the RCS part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Thrusters")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Thruster> Thrusters {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Thrusters", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Thruster>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Thruster>), connection);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_UpEnabled")]
    public bool UpEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_UpEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RCS_set_UpEnabled", _args);
        }
    }

    /// <summary>
    /// The vacuum specific impulse of the RCS, in seconds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_VacuumSpecificImpulse")]
    public float VacuumSpecificImpulse {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_VacuumSpecificImpulse", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_YawEnabled")]
    public bool YawEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_YawEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RCS_set_YawEnabled", _args);
        }
    }
}