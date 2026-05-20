using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A robotic piston part. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticPiston" />.
/// </summary>
public class RoboticPiston : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticPiston (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Move piston to it's built position.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_MoveHome")]
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_CurrentExtension")]
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_Damping")]
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_Locked")]
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_MotorEngaged")]
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_Part")]
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_Rate")]
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_TargetExtension")]
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