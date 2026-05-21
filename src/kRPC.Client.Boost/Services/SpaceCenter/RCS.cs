using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An RCS block or thruster. Obtained by calling <see cref="M:SpaceCenter.Part.RCS" />.
/// </summary>
public class RCS : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RCS (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the RCS thrusters are active.
    /// An RCS thruster is inactive if the RCS action group is disabled
    /// (<see cref="M:SpaceCenter.Control.RCS" />), the RCS thruster itself is not enabled
    /// (<see cref="M:SpaceCenter.RCS.Enabled" />) or it is covered by a fairing (<see cref="M:SpaceCenter.Part.Shielded" />).
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_Active")]
    public bool Active {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RCS_get_Active", _args);
        }
    }

    /// <summary>
    /// The available force, in Newtons, that can be produced by this RCS,
    /// in the positive and negative x, y and z axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// Returns zero if RCS is disabled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_AvailableForce")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableForce {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "RCS_get_AvailableForce", _args);
        }
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the thruster when activated.
    /// Returns zero if the thruster does not have any fuel.
    /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.ThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_AvailableThrust")]
    public float AvailableThrust {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RCS_get_AvailableThrust", _args);
        }
    }

    /// <summary>
    /// The available torque, in Newton meters, that can be produced by this RCS,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// Returns zero if RCS is disable.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_AvailableTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableTorque {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "RCS_get_AvailableTorque", _args);
        }
    }

    /// <summary>
    /// Whether the RCS thrusters are enabled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_Enabled")]
    public bool Enabled {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RCS_get_Enabled", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RCS_set_Enabled", _args);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_ForwardEnabled")]
    public bool ForwardEnabled {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RCS_get_ForwardEnabled", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RCS_set_ForwardEnabled", _args);
        }
    }

    /// <summary>
    /// Whether the RCS has fuel available.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_HasFuel")]
    public bool HasFuel {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RCS_get_HasFuel", _args);
        }
    }

    /// <summary>
    /// The specific impulse of the RCS at sea level on Kerbin, in seconds.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse")]
    public float KerbinSeaLevelSpecificImpulse {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse", _args);
        }
    }

    /// <summary>
    /// The maximum amount of thrust that can be produced by the RCS thrusters when active,
    /// in Newtons.
    /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.ThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_MaxThrust")]
    public float MaxThrust {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RCS_get_MaxThrust", _args);
        }
    }

    /// <summary>
    /// The maximum amount of thrust that can be produced by the RCS thrusters when active
    /// in a vacuum, in Newtons.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_MaxVacuumThrust")]
    public float MaxVacuumThrust {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RCS_get_MaxVacuumThrust", _args);
        }
    }

    /// <summary>
    /// The part object for this RCS.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "RCS_get_Part", _args);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_PitchEnabled")]
    public bool PitchEnabled {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RCS_get_PitchEnabled", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RCS_set_PitchEnabled", _args);
        }
    }

    /// <summary>
    /// The ratios of resources that the RCS consumes. A dictionary mapping resource names
    /// to the ratios at which they are consumed by the RCS.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_PropellantRatios")]
    public IDictionary<string,float> PropellantRatios {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IDictionary<string,float>> ("SpaceCenter", "RCS_get_PropellantRatios", _args);
        }
    }

    /// <summary>
    /// The names of resources that the RCS consumes.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_Propellants")]
    public IList<string> Propellants {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "RCS_get_Propellants", _args);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_RightEnabled")]
    public bool RightEnabled {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RCS_get_RightEnabled", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RCS_set_RightEnabled", _args);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_RollEnabled")]
    public bool RollEnabled {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RCS_get_RollEnabled", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RCS_set_RollEnabled", _args);
        }
    }

    /// <summary>
    /// The current specific impulse of the RCS, in seconds. Returns zero
    /// if the RCS is not active.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_SpecificImpulse")]
    public float SpecificImpulse {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RCS_get_SpecificImpulse", _args);
        }
    }

    /// <summary>
    /// The thrust limiter of the thruster. A value between 0 and 1.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_ThrustLimit")]
    public float ThrustLimit {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RCS_get_ThrustLimit", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RCS_set_ThrustLimit", _args);
        }
    }

    /// <summary>
    /// A list of thrusters, one of each nozzel in the RCS part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_Thrusters")]
    public IList<Thruster> Thrusters {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<Thruster>> ("SpaceCenter", "RCS_get_Thrusters", _args);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_UpEnabled")]
    public bool UpEnabled {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RCS_get_UpEnabled", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RCS_set_UpEnabled", _args);
        }
    }

    /// <summary>
    /// The vacuum specific impulse of the RCS, in seconds.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_VacuumSpecificImpulse")]
    public float VacuumSpecificImpulse {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RCS_get_VacuumSpecificImpulse", _args);
        }
    }

    /// <summary>
    /// Whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RCS_get_YawEnabled")]
    public bool YawEnabled {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RCS_get_YawEnabled", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RCS_set_YawEnabled", _args);
        }
    }
}
