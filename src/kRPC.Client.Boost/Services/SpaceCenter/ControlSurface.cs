using Google.Protobuf;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An aerodynamic control surface. Obtained by calling <see cref="M:SpaceCenter.Part.ControlSurface" />.
/// </summary>
public class ControlSurface : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ControlSurface (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// The authority limiter for the control surface, which controls how far the
    /// control surface will move.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_AuthorityLimiter")]
    public float AuthorityLimiter {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_AuthorityLimiter", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "ControlSurface_set_AuthorityLimiter", _args);
        }
    }

    /// <summary>
    /// The available torque, in Newton meters, that can be produced by this control surface,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_AvailableTorque")]
    public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableTorque {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_AvailableTorque", _args);
            return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
        }
    }

    /// <summary>
    /// Whether the control surface has been fully deployed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_Deployed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "ControlSurface_set_Deployed", _args);
        }
    }

    /// <summary>
    /// Whether the control surface movement is inverted.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_Inverted")]
    public bool Inverted {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_Inverted", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "ControlSurface_set_Inverted", _args);
        }
    }

    /// <summary>
    /// The part object for this control surface.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Whether the control surface has pitch control enabled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_PitchEnabled")]
    public bool PitchEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_PitchEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "ControlSurface_set_PitchEnabled", _args);
        }
    }

    /// <summary>
    /// Whether the control surface has roll control enabled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_RollEnabled")]
    public bool RollEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_RollEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "ControlSurface_set_RollEnabled", _args);
        }
    }

    /// <summary>
    /// Surface area of the control surface in <math>m^2</math>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_SurfaceArea")]
    public float SurfaceArea {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_SurfaceArea", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the control surface has yaw control enabled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_YawEnabled")]
    public bool YawEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_YawEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "ControlSurface_set_YawEnabled", _args);
        }
    }
}