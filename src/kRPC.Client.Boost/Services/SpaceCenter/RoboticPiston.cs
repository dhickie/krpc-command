using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A robotic piston part. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticPiston" />.
/// </summary>
public class RoboticPiston : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticPiston (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Move piston to it's built position.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_MoveHome")]
    public void MoveHome ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston))
        };
        connection.Invoke ("SpaceCenter", "RoboticPiston_MoveHome", _args);
    }

    /// <summary>
    /// Current extension of the piston.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_CurrentExtension")]
    public float CurrentExtension {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_CurrentExtension", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Damping percentage.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_Damping")]
    public float Damping {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_Damping", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "RoboticPiston_set_Damping", _args);
        }
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_Locked")]
    public bool Locked {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_Locked", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RoboticPiston_set_Locked", _args);
        }
    }

    /// <summary>
    /// Whether the motor is engaged.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_MotorEngaged")]
    public bool MotorEngaged {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_MotorEngaged", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RoboticPiston_set_MotorEngaged", _args);
        }
    }

    /// <summary>
    /// The part object for this robotic piston.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Target movement rate in degrees per second.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_Rate")]
    public float Rate {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_Rate", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "RoboticPiston_set_Rate", _args);
        }
    }

    /// <summary>
    /// Target extension of the piston.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_TargetExtension")]
    public float TargetExtension {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_TargetExtension", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "RoboticPiston_set_TargetExtension", _args);
        }
    }
}
