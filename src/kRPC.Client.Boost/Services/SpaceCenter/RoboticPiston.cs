using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A robotic piston part. Obtained by calling <see cref="M:SpaceCenter.Part.GetRoboticPiston" />.
/// </summary>
public class RoboticPiston : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticPiston(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Move piston to it's built position.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_MoveHome")]
    public void MoveHome()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "RoboticPiston_MoveHome", args);
    }

    /// <summary>
    /// Move piston to it's built position.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_MoveHome")]
    public async Task MoveHomeAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticPiston_MoveHome", args);
    }

    /// <summary>
    /// Gets the current extension of the piston.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_CurrentExtension")]
    public float GetCurrentExtension()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RoboticPiston_get_CurrentExtension", args);
    }

    /// <summary>
    /// Gets the current extension of the piston.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_CurrentExtension")]
    public async Task<float> GetCurrentExtensionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RoboticPiston_get_CurrentExtension", args);
    }

    /// <summary>
    /// Damping percentage.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_Damping")]
    public float GetDamping()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RoboticPiston_get_Damping", args);
    }

    /// <summary>
    /// Damping percentage.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_Damping")]
    public async Task<float> GetDampingAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RoboticPiston_get_Damping", args);
    }

    /// <summary>
    /// Sets the damping percentage.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetDamping(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticPiston_set_Damping", args);
    }

    /// <summary>
    /// Sets the damping percentage.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetDampingAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticPiston_set_Damping", args);
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_Locked")]
    public bool GetLocked()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RoboticPiston_get_Locked", args);
    }

    /// <summary>
    /// Lock movement.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_Locked")]
    public async Task<bool> GetLockedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RoboticPiston_get_Locked", args);
    }

    /// <summary>
    /// Sets whether movement is locked.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetLocked(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticPiston_set_Locked", args);
    }

    /// <summary>
    /// Sets whether movement is locked.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetLockedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticPiston_set_Locked", args);
    }

    /// <summary>
    /// Gets whether the motor is engaged.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_MotorEngaged")]
    public bool GetMotorEngaged()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RoboticPiston_get_MotorEngaged", args);
    }

    /// <summary>
    /// Gets whether the motor is engaged.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_MotorEngaged")]
    public async Task<bool> GetMotorEngagedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RoboticPiston_get_MotorEngaged", args);
    }

    /// <summary>
    /// Sets whether the motor is engaged.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetMotorEngaged(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticPiston_set_MotorEngaged", args);
    }

    /// <summary>
    /// Sets whether the motor is engaged.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetMotorEngagedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticPiston_set_MotorEngaged", args);
    }

    /// <summary>
    /// Gets the part object for this robotic piston.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "RoboticPiston_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this robotic piston.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "RoboticPiston_get_Part", args);
    }

    /// <summary>
    /// Target movement rate in degrees per second.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_Rate")]
    public float GetRate()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RoboticPiston_get_Rate", args);
    }

    /// <summary>
    /// Target movement rate in degrees per second.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_Rate")]
    public async Task<float> GetRateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RoboticPiston_get_Rate", args);
    }

    /// <summary>
    /// Sets the target movement rate in degrees per second.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRate(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticPiston_set_Rate", args);
    }

    /// <summary>
    /// Sets the target movement rate in degrees per second.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRateAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticPiston_set_Rate", args);
    }

    /// <summary>
    /// Target extension of the piston.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_TargetExtension")]
    public float GetTargetExtension()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RoboticPiston_get_TargetExtension", args);
    }

    /// <summary>
    /// Target extension of the piston.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticPiston_get_TargetExtension")]
    public async Task<float> GetTargetExtensionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RoboticPiston_get_TargetExtension", args);
    }

    /// <summary>
    /// Sets the target extension of the piston.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetExtension(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticPiston_set_TargetExtension", args);
    }

    /// <summary>
    /// Sets the target extension of the piston.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetTargetExtensionAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticPiston_set_TargetExtension", args);
    }
}
