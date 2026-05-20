using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A robotic rotor. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticRotor" />.
/// </summary>
public class RoboticRotor : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticRotor (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Current RPM.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_CurrentRPM")]
    public float CurrentRPM {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_CurrentRPM", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the rotor direction is inverted.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_Inverted")]
    public bool Inverted {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_Inverted", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotor_set_Inverted", _args);
        }
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_Locked")]
    public bool Locked {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_Locked", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotor_set_Locked", _args);
        }
    }

    /// <summary>
    /// Whether the motor is engaged.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_MotorEngaged")]
    public bool MotorEngaged {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_MotorEngaged", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotor_set_MotorEngaged", _args);
        }
    }

    /// <summary>
    /// The part object for this robotic rotor.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Target RPM.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_TargetRPM")]
    public float TargetRPM {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_TargetRPM", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotor_set_TargetRPM", _args);
        }
    }

    /// <summary>
    /// Torque limit percentage.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_TorqueLimit")]
    public float TorqueLimit {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_TorqueLimit", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotor_set_TorqueLimit", _args);
        }
    }
}