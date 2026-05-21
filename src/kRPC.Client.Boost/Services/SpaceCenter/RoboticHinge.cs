using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A robotic hinge. Obtained by calling <see cref="M:SpaceCenter.Part.GetRoboticHinge" />.
/// </summary>
public class RoboticHinge : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticHinge (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Move hinge to it's built position.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticHinge_MoveHome")]
    public void MoveHome ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "RoboticHinge_MoveHome", args);
    }

    /// <summary>
    /// Gets the current angle.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticHinge_get_CurrentAngle")]
    public float GetCurrentAngle ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "RoboticHinge_get_CurrentAngle", args);
    }

    /// <summary>
    /// Damping percentage.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticHinge_get_Damping")]
    public float GetDamping ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "RoboticHinge_get_Damping", args);
    }

    /// <summary>
    /// Sets the damping percentage.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetDamping (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticHinge_set_Damping", args);
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticHinge_get_Locked")]
    public bool GetLocked ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "RoboticHinge_get_Locked", args);
    }

    /// <summary>
    /// Sets whether movement is locked.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetLocked (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticHinge_set_Locked", args);
    }

    /// <summary>
    /// Gets whether the motor is engaged.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticHinge_get_MotorEngaged")]
    public bool GetMotorEngaged ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "RoboticHinge_get_MotorEngaged", args);
    }

    /// <summary>
    /// Sets whether the motor is engaged.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetMotorEngaged (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticHinge_set_MotorEngaged", args);
    }

    /// <summary>
    /// Gets the part object for this robotic hinge.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticHinge_get_Part")]
    public Part GetPart ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Part> ("SpaceCenter", "RoboticHinge_get_Part", args);
    }

    /// <summary>
    /// Target movement rate in degrees per second.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticHinge_get_Rate")]
    public float GetRate ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "RoboticHinge_get_Rate", args);
    }

    /// <summary>
    /// Sets the target movement rate in degrees per second.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRate (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticHinge_set_Rate", args);
    }

    /// <summary>
    /// Target angle.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticHinge_get_TargetAngle")]
    public float GetTargetAngle ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "RoboticHinge_get_TargetAngle", args);
    }

    /// <summary>
    /// Sets the target angle.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetAngle (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticHinge_set_TargetAngle", args);
    }
}
