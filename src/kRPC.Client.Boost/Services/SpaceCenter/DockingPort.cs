using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A docking port. Obtained by calling <see cref="M:SpaceCenter.Part.DockingPort" /></summary>
public class DockingPort : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public DockingPort (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// The direction that docking port points in, in the given reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_Direction")]
    public systemAlias::Tuple<double,double,double> Direction (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_Direction", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The position of the docking port, in the given reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_Position")]
    public systemAlias::Tuple<double,double,double> Position (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_Position", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The rotation of the docking port, in the given reference frame.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_Rotation")]
    public systemAlias::Tuple<double,double,double,double> Rotation (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_Rotation", _args);
        return (systemAlias::Tuple<double,double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double,double>), connection);
    }

    /// <summary>
    /// Undocks the docking port and returns the new <see cref="T:SpaceCenter.Vessel" /> that is created.
    /// This method can be called for either docking port in a docked pair.
    /// Throws an exception if the docking port is not docked to anything.
    /// </summary>
    /// <remarks>
    /// When called, the active vessel may change. It is therefore possible that,
    /// after calling this function, the object(s) returned by previous call(s) to
    /// <see cref="M:SpaceCenter.ActiveVessel" /> no longer refer to the active vessel.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_Undock")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Vessel Undock ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_Undock", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel), connection);
    }

    /// <summary>
    /// Whether the docking port can be commanded to rotate while docked.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_CanRotate")]
    public bool CanRotate {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_CanRotate", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The part that this docking port is docked to. Returns <c>null</c> if this
    /// docking port is not docked to anything.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_DockedPart")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part DockedPart {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_DockedPart", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Whether the docking port has a shield.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_HasShield")]
    public bool HasShield {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_HasShield", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Maximum rotation angle in degrees.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_MaximumRotation")]
    public float MaximumRotation {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_MaximumRotation", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Minimum rotation angle in degrees.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_MinimumRotation")]
    public float MinimumRotation {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_MinimumRotation", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The part object for this docking port.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// The distance a docking port must move away when it undocks before it
    /// becomes ready to dock with another port, in meters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_ReengageDistance")]
    public float ReengageDistance {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_ReengageDistance", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The reference frame that is fixed relative to this docking port, and
    /// oriented with the port.
    /// <list type="bullet"><item><description>The origin is at the position of the docking port.
    /// </description></item><item><description>The axes rotate with the docking port.</description></item><item><description>The x-axis points out to the right side of the docking port.
    /// </description></item><item><description>The y-axis points in the direction the docking port is facing.
    /// </description></item><item><description>The z-axis points out of the bottom off the docking port.
    /// </description></item></list></summary>
    /// <remarks>
    /// This reference frame is not necessarily equivalent to the reference frame
    /// for the part, returned by <see cref="M:SpaceCenter.Part.ReferenceFrame" />.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_ReferenceFrame")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_ReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// Lock rotation. When locked, allows auto-strut to work across the joint.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_RotationLocked")]
    public bool RotationLocked {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_RotationLocked", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "DockingPort_set_RotationLocked", _args);
        }
    }

    /// <summary>
    /// Rotation target angle in degrees.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_RotationTarget")]
    public float RotationTarget {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_RotationTarget", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "DockingPort_set_RotationTarget", _args);
        }
    }

    /// <summary>
    /// The state of the docking ports shield, if it has one.
    ///
    /// Returns <c>true</c> if the docking port has a shield, and the shield is
    /// closed. Otherwise returns <c>false</c>. When set to <c>true</c>, the shield is
    /// closed, and when set to <c>false</c> the shield is opened. If the docking
    /// port does not have a shield, setting this attribute has no effect.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_Shielded")]
    public bool Shielded {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_Shielded", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "DockingPort_set_Shielded", _args);
        }
    }

    /// <summary>
    /// The current state of the docking port.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_State")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.DockingPortState State {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_State", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.DockingPortState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPortState), connection);
        }
    }
}
