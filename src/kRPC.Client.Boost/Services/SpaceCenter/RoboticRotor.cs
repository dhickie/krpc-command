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
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotor_get_CurrentRPM", args);
        }
    }

    /// <summary>
    /// Whether the rotor direction is inverted.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_Inverted")]
    public bool Inverted {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotor_get_Inverted", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_Inverted", args);
        }
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_Locked")]
    public bool Locked {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotor_get_Locked", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_Locked", args);
        }
    }

    /// <summary>
    /// Whether the motor is engaged.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_MotorEngaged")]
    public bool MotorEngaged {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotor_get_MotorEngaged", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_MotorEngaged", args);
        }
    }

    /// <summary>
    /// The part object for this robotic rotor.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "RoboticRotor_get_Part", args);
        }
    }

    /// <summary>
    /// Target RPM.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_TargetRPM")]
    public float TargetRPM {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotor_get_TargetRPM", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_TargetRPM", args);
        }
    }

    /// <summary>
    /// Torque limit percentage.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticRotor_get_TorqueLimit")]
    public float TorqueLimit {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotor_get_TorqueLimit", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotor_set_TorqueLimit", args);
        }
    }
}
