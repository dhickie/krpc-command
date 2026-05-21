using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A robotic rotation servo. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticRotation" />.
/// </summary>
public class RoboticRotation : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticRotation (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Move rotation servo to it's built position.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotation_MoveHome")]
    public void MoveHome ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation))
        };
        connection.Invoke ("SpaceCenter", "RoboticRotation_MoveHome", _args);
    }

    /// <summary>
    /// Current angle.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotation_get_CurrentAngle")]
    public float CurrentAngle {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_CurrentAngle", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Damping percentage.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotation_get_Damping")]
    public float Damping {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_Damping", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotation_set_Damping", _args);
        }
    }

    /// <summary>
    /// Lock Movement
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotation_get_Locked")]
    public bool Locked {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_Locked", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotation_set_Locked", _args);
        }
    }

    /// <summary>
    /// Whether the motor is engaged.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotation_get_MotorEngaged")]
    public bool MotorEngaged {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_MotorEngaged", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotation_set_MotorEngaged", _args);
        }
    }

    /// <summary>
    /// The part object for this robotic rotation servo.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotation_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Target movement rate in degrees per second.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotation_get_Rate")]
    public float Rate {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_Rate", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotation_set_Rate", _args);
        }
    }

    /// <summary>
    /// Target angle.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotation_get_TargetAngle")]
    public float TargetAngle {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_TargetAngle", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotation_set_TargetAngle", _args);
        }
    }
}
