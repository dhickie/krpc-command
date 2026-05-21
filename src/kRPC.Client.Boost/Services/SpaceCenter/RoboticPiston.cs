using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
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
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "RoboticPiston_MoveHome", _args);
    }

    /// <summary>
    /// Current extension of the piston.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_CurrentExtension")]
    public float CurrentExtension {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticPiston_get_CurrentExtension", _args);
        }
    }

    /// <summary>
    /// Damping percentage.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_Damping")]
    public float Damping {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticPiston_get_Damping", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_Damping", _args);
        }
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_Locked")]
    public bool Locked {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticPiston_get_Locked", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_Locked", _args);
        }
    }

    /// <summary>
    /// Whether the motor is engaged.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_MotorEngaged")]
    public bool MotorEngaged {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticPiston_get_MotorEngaged", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_MotorEngaged", _args);
        }
    }

    /// <summary>
    /// The part object for this robotic piston.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "RoboticPiston_get_Part", _args);
        }
    }

    /// <summary>
    /// Target movement rate in degrees per second.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_Rate")]
    public float Rate {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticPiston_get_Rate", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_Rate", _args);
        }
    }

    /// <summary>
    /// Target extension of the piston.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticPiston_get_TargetExtension")]
    public float TargetExtension {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticPiston_get_TargetExtension", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_TargetExtension", _args);
        }
    }
}
