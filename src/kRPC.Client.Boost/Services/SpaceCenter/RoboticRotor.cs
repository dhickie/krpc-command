using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A robotic rotor. Obtained by calling <see cref="M:SpaceCenter.Part.GetRoboticRotor" />.
/// </summary>
public class RoboticRotor : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticRotor(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets the current RPM.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_CurrentRPM")]
    public float GetCurrentRPM()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RoboticRotor_get_CurrentRPM", args);
    }

    /// <summary>
    /// Gets the current RPM.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_CurrentRPM")]
    public async Task<float> GetCurrentRPMAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RoboticRotor_get_CurrentRPM", args);
    }

    /// <summary>
    /// Gets whether the rotor direction is inverted.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_Inverted")]
    public bool GetInverted()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RoboticRotor_get_Inverted", args);
    }

    /// <summary>
    /// Gets whether the rotor direction is inverted.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_Inverted")]
    public async Task<bool> GetInvertedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RoboticRotor_get_Inverted", args);
    }

    /// <summary>
    /// Sets whether the rotor direction is inverted.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_Inverted")]
    public void SetInverted(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticRotor_set_Inverted", args);
    }

    /// <summary>
    /// Sets whether the rotor direction is inverted.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_Inverted")]
    public async Task SetInvertedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotor_set_Inverted", args);
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_Locked")]
    public bool GetLocked()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RoboticRotor_get_Locked", args);
    }

    /// <summary>
    /// Lock movement.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_Locked")]
    public async Task<bool> GetLockedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RoboticRotor_get_Locked", args);
    }

    /// <summary>
    /// Sets whether movement is locked.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_Locked")]
    public void SetLocked(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticRotor_set_Locked", args);
    }

    /// <summary>
    /// Sets whether movement is locked.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_Locked")]
    public async Task SetLockedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotor_set_Locked", args);
    }

    /// <summary>
    /// Gets whether the motor is engaged.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_MotorEngaged")]
    public bool GetMotorEngaged()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RoboticRotor_get_MotorEngaged", args);
    }

    /// <summary>
    /// Gets whether the motor is engaged.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_MotorEngaged")]
    public async Task<bool> GetMotorEngagedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RoboticRotor_get_MotorEngaged", args);
    }

    /// <summary>
    /// Sets whether the motor is engaged.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_MotorEngaged")]
    public void SetMotorEngaged(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticRotor_set_MotorEngaged", args);
    }

    /// <summary>
    /// Sets whether the motor is engaged.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_MotorEngaged")]
    public async Task SetMotorEngagedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotor_set_MotorEngaged", args);
    }

    /// <summary>
    /// Gets the part object for this robotic rotor.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "RoboticRotor_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this robotic rotor.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "RoboticRotor_get_Part", args);
    }

    /// <summary>
    /// Target RPM.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_TargetRPM")]
    public float GetTargetRPM()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RoboticRotor_get_TargetRPM", args);
    }

    /// <summary>
    /// Target RPM.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_TargetRPM")]
    public async Task<float> GetTargetRPMAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RoboticRotor_get_TargetRPM", args);
    }

    /// <summary>
    /// Sets the target RPM.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_TargetRPM")]
    public void SetTargetRPM(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticRotor_set_TargetRPM", args);
    }

    /// <summary>
    /// Sets the target RPM.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_TargetRPM")]
    public async Task SetTargetRPMAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotor_set_TargetRPM", args);
    }

    /// <summary>
    /// Torque limit percentage.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_TorqueLimit")]
    public float GetTorqueLimit()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RoboticRotor_get_TorqueLimit", args);
    }

    /// <summary>
    /// Torque limit percentage.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotor_get_TorqueLimit")]
    public async Task<float> GetTorqueLimitAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RoboticRotor_get_TorqueLimit", args);
    }

    /// <summary>
    /// Sets the torque limit percentage.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_TorqueLimit")]
    public void SetTorqueLimit(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticRotor_set_TorqueLimit", args);
    }

    /// <summary>
    /// Sets the torque limit percentage.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotor_set_TorqueLimit")]
    public async Task SetTorqueLimitAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotor_set_TorqueLimit", args);
    }
}
