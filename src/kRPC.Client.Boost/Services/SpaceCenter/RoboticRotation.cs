using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
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
    [Rpc ("SpaceCenter", "RoboticRotation_MoveHome")]
    public void MoveHome ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "RoboticRotation_MoveHome", args);
    }

    /// <summary>
    /// Current angle.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotation_get_CurrentAngle")]
    public float CurrentAngle {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotation_get_CurrentAngle", args);
        }
    }

    /// <summary>
    /// Damping percentage.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotation_get_Damping")]
    public float Damping {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotation_get_Damping", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotation_set_Damping", args);
        }
    }

    /// <summary>
    /// Lock Movement
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotation_get_Locked")]
    public bool Locked {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotation_get_Locked", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotation_set_Locked", args);
        }
    }

    /// <summary>
    /// Whether the motor is engaged.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotation_get_MotorEngaged")]
    public bool MotorEngaged {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotation_get_MotorEngaged", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotation_set_MotorEngaged", args);
        }
    }

    /// <summary>
    /// The part object for this robotic rotation servo.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotation_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "RoboticRotation_get_Part", args);
        }
    }

    /// <summary>
    /// Target movement rate in degrees per second.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotation_get_Rate")]
    public float Rate {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotation_get_Rate", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotation_set_Rate", args);
        }
    }

    /// <summary>
    /// Target angle.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotation_get_TargetAngle")]
    public float TargetAngle {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "RoboticRotation_get_TargetAngle", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "RoboticRotation_set_TargetAngle", args);
        }
    }
}
