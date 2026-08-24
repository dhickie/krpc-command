using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;
using MathNet.Spatial.Units;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A robotic hinge. Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetRoboticHinge" />.
/// </summary>
public class RoboticHinge : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal RoboticHinge(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Move hinge to it's built position.
    /// </summary>
    [SetRpc("SpaceCenter", "RoboticHinge_MoveHome")]
    public void MoveHome()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        InvokeVoid("SpaceCenter", "RoboticHinge_MoveHome", args);
    }

    /// <summary>
    /// Move hinge to it's built position.
    /// Executes asynchronously.
    /// </summary>
    [SetRpc("SpaceCenter", "RoboticHinge_MoveHome")]
    public async Task MoveHomeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        await InvokeVoidAsync("SpaceCenter", "RoboticHinge_MoveHome", args);
    }

    /// <summary>
    /// Gets the current angle.
    /// </summary>
    [AngleConversion(AngleType.Degrees, typeof(float))]
    [GetRpc("SpaceCenter", "RoboticHinge_get_CurrentAngle")]
    public Angle GetCurrentAngle()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<float>("SpaceCenter", "RoboticHinge_get_CurrentAngle", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the current angle.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Degrees, typeof(float))]
    [GetRpc("SpaceCenter", "RoboticHinge_get_CurrentAngle")]
    public async Task<Angle> GetCurrentAngleAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<float>("SpaceCenter", "RoboticHinge_get_CurrentAngle", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Damping percentage.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticHinge_get_Damping")]
    public float GetDamping()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "RoboticHinge_get_Damping", args);
    }

    /// <summary>
    /// Damping percentage.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticHinge_get_Damping")]
    public async Task<float> GetDampingAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "RoboticHinge_get_Damping", args);
    }

    /// <summary>
    /// Sets the damping percentage.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_Damping")]
    public void SetDamping(float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RoboticHinge_set_Damping", args);
    }

    /// <summary>
    /// Sets the damping percentage.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_Damping")]
    public async Task SetDampingAsync(float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RoboticHinge_set_Damping", args);
    }

    /// <summary>
    /// Lock movement.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticHinge_get_Locked")]
    public bool GetLocked()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RoboticHinge_get_Locked", args);
    }

    /// <summary>
    /// Lock movement.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticHinge_get_Locked")]
    public async Task<bool> GetLockedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RoboticHinge_get_Locked", args);
    }

    /// <summary>
    /// Sets whether movement is locked.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_Locked")]
    public void SetLocked(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RoboticHinge_set_Locked", args);
    }

    /// <summary>
    /// Sets whether movement is locked.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_Locked")]
    public async Task SetLockedAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RoboticHinge_set_Locked", args);
    }

    /// <summary>
    /// Gets whether the motor is engaged.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticHinge_get_MotorEngaged")]
    public bool GetMotorEngaged()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RoboticHinge_get_MotorEngaged", args);
    }

    /// <summary>
    /// Gets whether the motor is engaged.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticHinge_get_MotorEngaged")]
    public async Task<bool> GetMotorEngagedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RoboticHinge_get_MotorEngaged", args);
    }

    /// <summary>
    /// Sets whether the motor is engaged.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_MotorEngaged")]
    public void SetMotorEngaged(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RoboticHinge_set_MotorEngaged", args);
    }

    /// <summary>
    /// Sets whether the motor is engaged.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_MotorEngaged")]
    public async Task SetMotorEngagedAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RoboticHinge_set_MotorEngaged", args);
    }

    /// <summary>
    /// Gets the part object for this robotic hinge.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticHinge_get_Part")]
    public Part GetPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "RoboticHinge_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this robotic hinge.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticHinge_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "RoboticHinge_get_Part", args);
    }

    /// <summary>
    /// Gets the target movement rate as an angle per second.
    /// </summary>
    [AngleConversion(AngleType.Degrees, typeof(float))]
    [GetRpc("SpaceCenter", "RoboticHinge_get_Rate")]
    public Angle GetRate()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<float>("SpaceCenter", "RoboticHinge_get_Rate", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the target movement rate as an angle per second.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Degrees, typeof(float))]
    [GetRpc("SpaceCenter", "RoboticHinge_get_Rate")]
    public async Task<Angle> GetRateAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<float>("SpaceCenter", "RoboticHinge_get_Rate", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Sets the target movement rate as an angle per second.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_Rate")]
    public void SetRate(Angle value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            (float)value.Degrees
        };
        InvokeVoid("SpaceCenter", "RoboticHinge_set_Rate", args);
    }

    /// <summary>
    /// Sets the target movement rate as an angle per second.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_Rate")]
    public async Task SetRateAsync(Angle value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            (float)value.Degrees
        };
        await InvokeVoidAsync("SpaceCenter", "RoboticHinge_set_Rate", args);
    }

    /// <summary>
    /// Target angle.
    /// </summary>
    [AngleConversion(AngleType.Degrees, typeof(float))]
    [GetRpc("SpaceCenter", "RoboticHinge_get_TargetAngle")]
    public Angle GetTargetAngle()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<float>("SpaceCenter", "RoboticHinge_get_TargetAngle", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Target angle.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Degrees, typeof(float))]
    [GetRpc("SpaceCenter", "RoboticHinge_get_TargetAngle")]
    public async Task<Angle> GetTargetAngleAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<float>("SpaceCenter", "RoboticHinge_get_TargetAngle", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Sets the target angle.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_TargetAngle")]
    public void SetTargetAngle(Angle value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            (float)value.Degrees
        };
        InvokeVoid("SpaceCenter", "RoboticHinge_set_TargetAngle", args);
    }

    /// <summary>
    /// Sets the target angle.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RoboticHinge_set_TargetAngle")]
    public async Task SetTargetAngleAsync(Angle value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            (float)value.Degrees
        };
        await InvokeVoidAsync("SpaceCenter", "RoboticHinge_set_TargetAngle", args);
    }
}
