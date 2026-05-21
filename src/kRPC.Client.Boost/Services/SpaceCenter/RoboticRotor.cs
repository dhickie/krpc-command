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
    [Rpc ("SpaceCenter", "RoboticRotor_get_CurrentRPM")]
    public float GetCurrentRPM ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "RoboticRotor_get_CurrentRPM", args);
    }

    /// <summary>
    /// Whether the rotor direction is inverted.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotor_get_Inverted")]
    public bool GetInverted ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotor_get_Inverted", args);
    }

    /// <summary>
    /// Sets the Inverted value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetInverted (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticRotor_set_Inverted", args);
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotor_get_Locked")]
    public bool GetLocked ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotor_get_Locked", args);
    }

    /// <summary>
    /// Sets the Locked value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetLocked (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticRotor_set_Locked", args);
    }

    /// <summary>
    /// Whether the motor is engaged.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotor_get_MotorEngaged")]
    public bool GetMotorEngaged ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "RoboticRotor_get_MotorEngaged", args);
    }

    /// <summary>
    /// Sets the MotorEngaged value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetMotorEngaged (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticRotor_set_MotorEngaged", args);
    }

    /// <summary>
    /// The part object for this robotic rotor.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotor_get_Part")]
    public Part GetPart ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Part> ("SpaceCenter", "RoboticRotor_get_Part", args);
    }

    /// <summary>
    /// Target RPM.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotor_get_TargetRPM")]
    public float GetTargetRPM ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "RoboticRotor_get_TargetRPM", args);
    }

    /// <summary>
    /// Sets the TargetRPM value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetRPM (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticRotor_set_TargetRPM", args);
    }

    /// <summary>
    /// Torque limit percentage.
    /// </summary>
    [Rpc ("SpaceCenter", "RoboticRotor_get_TorqueLimit")]
    public float GetTorqueLimit ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "RoboticRotor_get_TorqueLimit", args);
    }

    /// <summary>
    /// Sets the TorqueLimit value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTorqueLimit (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "RoboticRotor_set_TorqueLimit", args);
    }
}
