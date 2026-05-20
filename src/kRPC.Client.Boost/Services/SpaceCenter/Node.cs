using Google.Protobuf;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a maneuver node. Can be created using <see cref="M:SpaceCenter.Control.AddNode" />.
/// </summary>
public class Node : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Node (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Returns the burn vector for the maneuver node.
    /// </summary>
    /// <param name="referenceFrame">The reference frame that the returned vector is in.
    /// Defaults to <see cref="M:SpaceCenter.Vessel.OrbitalReferenceFrame" />.</param>
    /// <returns>A vector whose direction is the direction of the maneuver node burn, and
    /// magnitude is the delta-v of the burn in meters per second.
    /// </returns>
    /// <remarks>
    /// Does not change when executing the maneuver node. See <see cref="M:SpaceCenter.Node.RemainingBurnVector" />.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_BurnVector")]
    public systemAlias::Tuple<double,double,double> BurnVector (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame = null)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Node_BurnVector", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The direction of the maneuver nodes burn.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_Direction")]
    public systemAlias::Tuple<double,double,double> Direction (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Node_Direction", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The position vector of the maneuver node in the given reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_Position")]
    public systemAlias::Tuple<double,double,double> Position (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Node_Position", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// Returns the remaining burn vector for the maneuver node.
    /// </summary>
    /// <param name="referenceFrame">The reference frame that the returned vector is in.
    /// Defaults to <see cref="M:SpaceCenter.Vessel.OrbitalReferenceFrame" />.</param>
    /// <returns>A vector whose direction is the direction of the maneuver node burn, and
    /// magnitude is the delta-v of the burn in meters per second.
    /// </returns>
    /// <remarks>
    /// Changes as the maneuver node is executed. See <see cref="M:SpaceCenter.Node.BurnVector" />.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_RemainingBurnVector")]
    public systemAlias::Tuple<double,double,double> RemainingBurnVector (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame = null)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Node_RemainingBurnVector", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// Removes the maneuver node.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_Remove")]
    public void Remove ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
        };
        connection.Invoke ("SpaceCenter", "Node_Remove", _args);
    }

    /// <summary>
    /// The delta-v of the maneuver node, in meters per second.
    /// </summary>
    /// <remarks>
    /// Does not change when executing the maneuver node. See <see cref="M:SpaceCenter.Node.RemainingDeltaV" />.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_DeltaV")]
    public double DeltaV {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_DeltaV", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Node_set_DeltaV", _args);
        }
    }

    /// <summary>
    /// The magnitude of the maneuver nodes delta-v in the normal direction,
    /// in meters per second.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_Normal")]
    public double Normal {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_Normal", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Node_set_Normal", _args);
        }
    }

    /// <summary>
    /// The orbit that results from executing the maneuver node.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_Orbit")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Orbit Orbit {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_Orbit", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Orbit)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Orbit), connection);
        }
    }

    /// <summary>
    /// The reference frame that is fixed relative to the maneuver node, and
    /// orientated with the orbital prograde/normal/radial directions of the
    /// original orbit at the maneuver node's position.
    /// <list type="bullet"><item><description>The origin is at the position of the maneuver node.</description></item><item><description>The x-axis points in the orbital anti-radial direction of the original
    /// orbit, at the position of the maneuver node.</description></item><item><description>The y-axis points in the orbital prograde direction of the original
    /// orbit, at the position of the maneuver node.</description></item><item><description>The z-axis points in the orbital normal direction of the original orbit,
    /// at the position of the maneuver node.</description></item></list></summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_OrbitalReferenceFrame")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame OrbitalReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_OrbitalReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// The magnitude of the maneuver nodes delta-v in the prograde direction,
    /// in meters per second.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_Prograde")]
    public double Prograde {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_Prograde", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Node_set_Prograde", _args);
        }
    }

    /// <summary>
    /// The magnitude of the maneuver nodes delta-v in the radial direction,
    /// in meters per second.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_Radial")]
    public double Radial {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_Radial", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Node_set_Radial", _args);
        }
    }

    /// <summary>
    /// The reference frame that is fixed relative to the maneuver node's burn.
    /// <list type="bullet"><item><description>The origin is at the position of the maneuver node.</description></item><item><description>The y-axis points in the direction of the burn.</description></item><item><description>The x-axis and z-axis point in arbitrary but fixed directions.</description></item></list></summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_ReferenceFrame")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_ReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// Gets the remaining delta-v of the maneuver node, in meters per second. Changes as the
    /// node is executed. This is equivalent to the delta-v reported in-game.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_RemainingDeltaV")]
    public double RemainingDeltaV {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_RemainingDeltaV", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The time until the maneuver node will be encountered, in seconds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_TimeTo")]
    public double TimeTo {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_TimeTo", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The universal time at which the maneuver will occur, in seconds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_UT")]
    public double UT {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_UT", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Node_set_UT", _args);
        }
    }
}