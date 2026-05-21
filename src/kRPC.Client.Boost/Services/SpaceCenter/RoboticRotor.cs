using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A robotic rotor. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticRotor" />.
/// </summary>
public class RoboticRotor : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticRotor (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Current RPM.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_CurrentRPM")]
    public float CurrentRPM {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotor_get_CurrentRPM", _args);
        }
    }

    /// <summary>
    /// Whether the rotor direction is inverted.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_Inverted")]
    public bool Inverted {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotor_get_Inverted", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_Inverted", _args);
        }
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_Locked")]
    public bool Locked {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotor_get_Locked", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_Locked", _args);
        }
    }

    /// <summary>
    /// Whether the motor is engaged.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_MotorEngaged")]
    public bool MotorEngaged {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotor_get_MotorEngaged", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_MotorEngaged", _args);
        }
    }

    /// <summary>
    /// The part object for this robotic rotor.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "RoboticRotor_get_Part", _args);
        }
    }

    /// <summary>
    /// Target RPM.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_TargetRPM")]
    public float TargetRPM {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotor_get_TargetRPM", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_TargetRPM", _args);
        }
    }

    /// <summary>
    /// Torque limit percentage.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_TorqueLimit")]
    public float TorqueLimit {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotor_get_TorqueLimit", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_TorqueLimit", _args);
        }
    }
}
