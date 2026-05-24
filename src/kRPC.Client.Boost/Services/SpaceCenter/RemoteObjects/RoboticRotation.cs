using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;
using MathNet.Spatial.Units;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A robotic rotation servo. Obtained by calling <see cref="M:SpaceCenter.Part.GetRoboticRotation" />.
/// </summary>
public class RoboticRotation : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticRotation(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Move rotation servo to it's built position.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_MoveHome")]
    public void MoveHome()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "RoboticRotation_MoveHome", args);
    }

    /// <summary>
    /// Move rotation servo to it's built position.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_MoveHome")]
    public async Task MoveHomeAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotation_MoveHome", args);
    }

    /// <summary>
    /// Gets the current angle.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_CurrentAngle")]
    public Angle GetCurrentAngle()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "RoboticRotation_get_CurrentAngle", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the current angle.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_CurrentAngle")]
    public async Task<Angle> GetCurrentAngleAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "RoboticRotation_get_CurrentAngle", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Damping percentage.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_Damping")]
    public float GetDamping()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RoboticRotation_get_Damping", args);
    }

    /// <summary>
    /// Damping percentage.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_Damping")]
    public async Task<float> GetDampingAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RoboticRotation_get_Damping", args);
    }

    /// <summary>
    /// Sets the damping percentage.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_Damping")]
    public void SetDamping(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticRotation_set_Damping", args);
    }

    /// <summary>
    /// Sets the damping percentage.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_Damping")]
    public async Task SetDampingAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotation_set_Damping", args);
    }

    /// <summary>
    /// Lock Movement
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_Locked")]
    public bool GetLocked()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RoboticRotation_get_Locked", args);
    }

    /// <summary>
    /// Lock Movement
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_Locked")]
    public async Task<bool> GetLockedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RoboticRotation_get_Locked", args);
    }

    /// <summary>
    /// Sets whether movement is locked.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_Locked")]
    public void SetLocked(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticRotation_set_Locked", args);
    }

    /// <summary>
    /// Sets whether movement is locked.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_Locked")]
    public async Task SetLockedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotation_set_Locked", args);
    }

    /// <summary>
    /// Gets whether the motor is engaged.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_MotorEngaged")]
    public bool GetMotorEngaged()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RoboticRotation_get_MotorEngaged", args);
    }

    /// <summary>
    /// Gets whether the motor is engaged.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_MotorEngaged")]
    public async Task<bool> GetMotorEngagedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RoboticRotation_get_MotorEngaged", args);
    }

    /// <summary>
    /// Sets whether the motor is engaged.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_MotorEngaged")]
    public void SetMotorEngaged(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RoboticRotation_set_MotorEngaged", args);
    }

    /// <summary>
    /// Sets whether the motor is engaged.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_MotorEngaged")]
    public async Task SetMotorEngagedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotation_set_MotorEngaged", args);
    }

    /// <summary>
    /// Gets the part object for this robotic rotation servo.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "RoboticRotation_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this robotic rotation servo.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "RoboticRotation_get_Part", args);
    }

    /// <summary>
    /// Gets the target movement rate as an angle per second.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_Rate")]
    public Angle GetRate()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "RoboticRotation_get_Rate", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the target movement rate as an angle per second.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_Rate")]
    public async Task<Angle> GetRateAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "RoboticRotation_get_Rate", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Sets the target movement rate as an angle per second.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_Rate")]
    public void SetRate(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        Connection.Invoke("SpaceCenter", "RoboticRotation_set_Rate", args);
    }

    /// <summary>
    /// Sets the target movement rate as an angle per second.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_Rate")]
    public async Task SetRateAsync(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotation_set_Rate", args);
    }

    /// <summary>
    /// Target angle.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_TargetAngle")]
    public Angle GetTargetAngle()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "RoboticRotation_get_TargetAngle", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Target angle.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RoboticRotation_get_TargetAngle")]
    public async Task<Angle> GetTargetAngleAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "RoboticRotation_get_TargetAngle", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Sets the target angle.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_TargetAngle")]
    public void SetTargetAngle(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        Connection.Invoke("SpaceCenter", "RoboticRotation_set_TargetAngle", args);
    }

    /// <summary>
    /// Sets the target angle.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "RoboticRotation_set_TargetAngle")]
    public async Task SetTargetAngleAsync(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        await Connection.InvokeAsync("SpaceCenter", "RoboticRotation_set_TargetAngle", args);
    }
}
