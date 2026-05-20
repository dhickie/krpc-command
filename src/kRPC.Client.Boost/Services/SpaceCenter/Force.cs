using Google.Protobuf;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Obtained by calling <see cref="M:SpaceCenter.Part.AddForce" />.
/// </summary>
public class Force : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Force (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Remove the force.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_Remove")]
    public void Remove ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Force))
        };
        connection.Invoke ("SpaceCenter", "Force_Remove", _args);
    }

    /// <summary>
    /// The force vector, in Newtons.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_get_ForceVector")]
    public systemAlias::Tuple<double,double,double> ForceVector {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Force))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Force_get_ForceVector", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Force)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "Force_set_ForceVector", _args);
        }
    }

    /// <summary>
    /// The part that this force is applied to.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Force))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Force_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// The position at which the force acts, in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_get_Position")]
    public systemAlias::Tuple<double,double,double> Position {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Force))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Force_get_Position", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Force)),
                global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
            };
            connection.Invoke ("SpaceCenter", "Force_set_Position", _args);
        }
    }

    /// <summary>
    /// The reference frame of the force vector and position.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_get_ReferenceFrame")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Force))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Force_get_ReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Force)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
            };
            connection.Invoke ("SpaceCenter", "Force_set_ReferenceFrame", _args);
        }
    }
}