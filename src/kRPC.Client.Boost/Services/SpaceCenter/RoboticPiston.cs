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
    [Rpc ("SpaceCenter", "RoboticPiston_MoveHome")]
    public void MoveHome ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "RoboticPiston_MoveHome", args);
    }

    /// <summary>
    /// Current extension of the piston.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticPiston_get_CurrentExtension")]
    public float CurrentExtension {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticPiston_get_CurrentExtension", args);
        }
    }

    /// <summary>
    /// Damping percentage.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticPiston_get_Damping")]
    public float Damping {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticPiston_get_Damping", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_Damping", args);
        }
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticPiston_get_Locked")]
    public bool Locked {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticPiston_get_Locked", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_Locked", args);
        }
    }

    /// <summary>
    /// Whether the motor is engaged.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticPiston_get_MotorEngaged")]
    public bool MotorEngaged {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticPiston_get_MotorEngaged", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_MotorEngaged", args);
        }
    }

    /// <summary>
    /// The part object for this robotic piston.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticPiston_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "RoboticPiston_get_Part", args);
        }
    }

    /// <summary>
    /// Target movement rate in degrees per second.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticPiston_get_Rate")]
    public float Rate {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticPiston_get_Rate", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_Rate", args);
        }
    }

    /// <summary>
    /// Target extension of the piston.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticPiston_get_TargetExtension")]
    public float TargetExtension {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticPiston_get_TargetExtension", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticPiston_set_TargetExtension", args);
        }
    }
}
