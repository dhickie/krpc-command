using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using MathNet.Spatial.Units;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A wheel. Includes landing gear and rover wheels.
/// Obtained by calling <see cref="M:SpaceCenter.Part.GetWheel" />.
/// Can be used to control the motors, steering and deployment of wheels, among other things.
/// </summary>
public class Wheel : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Wheel(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether automatic friction control is enabled.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_AutoFrictionControl")]
    public bool GetAutoFrictionControl()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_AutoFrictionControl", args);
    }

    /// <summary>
    /// Gets whether automatic friction control is enabled.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_AutoFrictionControl")]
    public async Task<bool> GetAutoFrictionControlAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_AutoFrictionControl", args);
    }

    /// <summary>
    /// Sets whether automatic friction control is enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_AutoFrictionControl")]
    public void SetAutoFrictionControl(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_AutoFrictionControl", args);
    }

    /// <summary>
    /// Sets whether automatic friction control is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_AutoFrictionControl")]
    public async Task SetAutoFrictionControlAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_AutoFrictionControl", args);
    }

    /// <summary>
    /// Gets the braking force, as a percentage of maximum, when the brakes are applied.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Brakes")]
    public float GetBrakes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_Brakes", args);
    }

    /// <summary>
    /// Gets the braking force, as a percentage of maximum, when the brakes are applied.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Brakes")]
    public async Task<float> GetBrakesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_Brakes", args);
    }

    /// <summary>
    /// Sets the braking force, as a percentage of maximum, when the brakes are applied.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_Brakes")]
    public void SetBrakes(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_Brakes", args);
    }

    /// <summary>
    /// Sets the braking force, as a percentage of maximum, when the brakes are applied.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_Brakes")]
    public async Task SetBrakesAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_Brakes", args);
    }

    /// <summary>
    /// Gets whether the wheel is broken.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Broken")]
    public bool GetBroken()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_Broken", args);
    }

    /// <summary>
    /// Gets whether the wheel is broken.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Broken")]
    public async Task<bool> GetBrokenAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_Broken", args);
    }

    /// <summary>
    /// Gets the current deflection of the wheel.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Deflection")]
    public float GetDeflection()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_Deflection", args);
    }

    /// <summary>
    /// Gets the current deflection of the wheel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Deflection")]
    public async Task<float> GetDeflectionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_Deflection", args);
    }

    /// <summary>
    /// Gets whether the wheel is deployable.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Deployable")]
    public bool GetDeployable()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_Deployable", args);
    }

    /// <summary>
    /// Gets whether the wheel is deployable.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Deployable")]
    public async Task<bool> GetDeployableAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_Deployable", args);
    }

    /// <summary>
    /// Gets whether the wheel is deployed.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Deployed")]
    public bool GetDeployed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_Deployed", args);
    }

    /// <summary>
    /// Gets whether the wheel is deployed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Deployed")]
    public async Task<bool> GetDeployedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_Deployed", args);
    }

    /// <summary>
    /// Sets whether the wheel is deployed.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_Deployed")]
    public void SetDeployed(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_Deployed", args);
    }

    /// <summary>
    /// Sets whether the wheel is deployed.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_Deployed")]
    public async Task SetDeployedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_Deployed", args);
    }

    /// <summary>
    /// Manual setting for the motor limiter.
    /// Only takes effect if the wheel has automatic traction control disabled.
    /// A value between 0 and 100 inclusive.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_DriveLimiter")]
    public float GetDriveLimiter()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_DriveLimiter", args);
    }

    /// <summary>
    /// Manual setting for the motor limiter.
    /// Only takes effect if the wheel has automatic traction control disabled.
    /// A value between 0 and 100 inclusive.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_DriveLimiter")]
    public async Task<float> GetDriveLimiterAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_DriveLimiter", args);
    }

    /// <summary>
    /// Sets the manual motor limiter.
    /// Only takes effect if the wheel has automatic traction control disabled.
    /// A value between 0 and 100 inclusive.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_DriveLimiter")]
    public void SetDriveLimiter(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_DriveLimiter", args);
    }

    /// <summary>
    /// Sets the manual motor limiter.
    /// Only takes effect if the wheel has automatic traction control disabled.
    /// A value between 0 and 100 inclusive.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_DriveLimiter")]
    public async Task SetDriveLimiterAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_DriveLimiter", args);
    }

    /// <summary>
    /// Gets whether the wheel is touching the ground.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Grounded")]
    public bool GetGrounded()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_Grounded", args);
    }

    /// <summary>
    /// Gets whether the wheel is touching the ground.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Grounded")]
    public async Task<bool> GetGroundedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_Grounded", args);
    }

    /// <summary>
    /// Gets whether the wheel has brakes.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_HasBrakes")]
    public bool GetHasBrakes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_HasBrakes", args);
    }

    /// <summary>
    /// Gets whether the wheel has brakes.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_HasBrakes")]
    public async Task<bool> GetHasBrakesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_HasBrakes", args);
    }

    /// <summary>
    /// Gets whether the wheel has suspension.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_HasSuspension")]
    public bool GetHasSuspension()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_HasSuspension", args);
    }

    /// <summary>
    /// Gets whether the wheel has suspension.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_HasSuspension")]
    public async Task<bool> GetHasSuspensionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_HasSuspension", args);
    }

    /// <summary>
    /// Manual friction control value. Only has an effect if automatic friction control is disabled.
    /// A value between 0 and 5 inclusive.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_ManualFrictionControl")]
    public float GetManualFrictionControl()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_ManualFrictionControl", args);
    }

    /// <summary>
    /// Manual friction control value. Only has an effect if automatic friction control is disabled.
    /// A value between 0 and 5 inclusive.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_ManualFrictionControl")]
    public async Task<float> GetManualFrictionControlAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_ManualFrictionControl", args);
    }

    /// <summary>
    /// Sets the manual friction control value. Only has an effect if automatic friction control is disabled.
    /// A value between 0 and 5 inclusive.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_ManualFrictionControl")]
    public void SetManualFrictionControl(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_ManualFrictionControl", args);
    }

    /// <summary>
    /// Sets the manual friction control value. Only has an effect if automatic friction control is disabled.
    /// A value between 0 and 5 inclusive.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_ManualFrictionControl")]
    public async Task SetManualFrictionControlAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_ManualFrictionControl", args);
    }

    /// <summary>
    /// Gets whether the motor is enabled.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_MotorEnabled")]
    public bool GetMotorEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_MotorEnabled", args);
    }

    /// <summary>
    /// Gets whether the motor is enabled.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_MotorEnabled")]
    public async Task<bool> GetMotorEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_MotorEnabled", args);
    }

    /// <summary>
    /// Sets whether the motor is enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_MotorEnabled")]
    public void SetMotorEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_MotorEnabled", args);
    }

    /// <summary>
    /// Sets whether the motor is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_MotorEnabled")]
    public async Task SetMotorEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_MotorEnabled", args);
    }

    /// <summary>
    /// Gets whether the direction of the motor is inverted.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_MotorInverted")]
    public bool GetMotorInverted()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_MotorInverted", args);
    }

    /// <summary>
    /// Gets whether the direction of the motor is inverted.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_MotorInverted")]
    public async Task<bool> GetMotorInvertedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_MotorInverted", args);
    }

    /// <summary>
    /// Sets whether the direction of the motor is inverted.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_MotorInverted")]
    public void SetMotorInverted(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_MotorInverted", args);
    }

    /// <summary>
    /// Sets whether the direction of the motor is inverted.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_MotorInverted")]
    public async Task SetMotorInvertedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_MotorInverted", args);
    }

    /// <summary>
    /// Gets the output of the motor. This is the torque currently being generated, in Newton meters.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_MotorOutput")]
    public float GetMotorOutput()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_MotorOutput", args);
    }

    /// <summary>
    /// Gets the output of the motor. This is the torque currently being generated, in Newton meters.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_MotorOutput")]
    public async Task<float> GetMotorOutputAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_MotorOutput", args);
    }

    /// <summary>
    /// Gets whether the direction of the motor is inverted.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_MotorState")]
    public MotorState GetMotorState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<MotorState>("SpaceCenter", "Wheel_get_MotorState", args);
    }

    /// <summary>
    /// Gets whether the direction of the motor is inverted.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_MotorState")]
    public async Task<MotorState> GetMotorStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<MotorState>("SpaceCenter", "Wheel_get_MotorState", args);
    }

    /// <summary>
    /// Gets the part object for this wheel.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Wheel_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this wheel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Wheel_get_Part", args);
    }

    /// <summary>
    /// Gets whether the wheel is powered by a motor.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Powered")]
    public bool GetPowered()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_Powered", args);
    }

    /// <summary>
    /// Gets whether the wheel is powered by a motor.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Powered")]
    public async Task<bool> GetPoweredAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_Powered", args);
    }

    /// <summary>
    /// Radius of the wheel, in meters.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Radius")]
    public float GetRadius()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_Radius", args);
    }

    /// <summary>
    /// Radius of the wheel, in meters.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Radius")]
    public async Task<float> GetRadiusAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_Radius", args);
    }

    /// <summary>
    /// Gets whether the wheel is repairable.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Repairable")]
    public bool GetRepairable()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_Repairable", args);
    }

    /// <summary>
    /// Gets whether the wheel is repairable.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Repairable")]
    public async Task<bool> GetRepairableAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_Repairable", args);
    }

    /// <summary>
    /// Gets the current slip of the wheel.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Slip")]
    public float GetSlip()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_Slip", args);
    }

    /// <summary>
    /// Gets the current slip of the wheel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Slip")]
    public async Task<float> GetSlipAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_Slip", args);
    }

    /// <summary>
    /// Gets the current state of the wheel.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_State")]
    public WheelState GetState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<WheelState>("SpaceCenter", "Wheel_get_State", args);
    }

    /// <summary>
    /// Gets the current state of the wheel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_State")]
    public async Task<WheelState> GetStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<WheelState>("SpaceCenter", "Wheel_get_State", args);
    }

    /// <summary>
    /// Gets whether the wheel has steering.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Steerable")]
    public bool GetSteerable()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_Steerable", args);
    }

    /// <summary>
    /// Gets whether the wheel has steering.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Steerable")]
    public async Task<bool> GetSteerableAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_Steerable", args);
    }

    /// <summary>
    /// Gets the steering angle limit.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SteeringAngleLimit")]
    public Angle GetSteeringAngleLimit()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "Wheel_get_SteeringAngleLimit", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the steering angle limit.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SteeringAngleLimit")]
    public async Task<Angle> GetSteeringAngleLimitAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_SteeringAngleLimit", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Sets the steering angle limit.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_SteeringAngleLimit")]
    public void SetSteeringAngleLimit(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_SteeringAngleLimit", args);
    }

    /// <summary>
    /// Sets the steering angle limit.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_SteeringAngleLimit")]
    public async Task SetSteeringAngleLimitAsync(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_SteeringAngleLimit", args);
    }

    /// <summary>
    /// Gets whether the wheel steering is enabled.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SteeringEnabled")]
    public bool GetSteeringEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_SteeringEnabled", args);
    }

    /// <summary>
    /// Gets whether the wheel steering is enabled.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SteeringEnabled")]
    public async Task<bool> GetSteeringEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_SteeringEnabled", args);
    }

    /// <summary>
    /// Sets whether the wheel steering is enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_SteeringEnabled")]
    public void SetSteeringEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_SteeringEnabled", args);
    }

    /// <summary>
    /// Sets whether the wheel steering is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_SteeringEnabled")]
    public async Task SetSteeringEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_SteeringEnabled", args);
    }

    /// <summary>
    /// Gets whether the wheel steering is inverted.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SteeringInverted")]
    public bool GetSteeringInverted()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_SteeringInverted", args);
    }

    /// <summary>
    /// Gets whether the wheel steering is inverted.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SteeringInverted")]
    public async Task<bool> GetSteeringInvertedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_SteeringInverted", args);
    }

    /// <summary>
    /// Sets whether the wheel steering is inverted.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_SteeringInverted")]
    public void SetSteeringInverted(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_SteeringInverted", args);
    }

    /// <summary>
    /// Sets whether the wheel steering is inverted.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_SteeringInverted")]
    public async Task SetSteeringInvertedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_SteeringInverted", args);
    }

    /// <summary>
    /// Steering response time.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SteeringResponseTime")]
    public float GetSteeringResponseTime()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_SteeringResponseTime", args);
    }

    /// <summary>
    /// Steering response time.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SteeringResponseTime")]
    public async Task<float> GetSteeringResponseTimeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_SteeringResponseTime", args);
    }

    /// <summary>
    /// Sets the steering response time.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_SteeringResponseTime")]
    public void SetSteeringResponseTime(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_SteeringResponseTime", args);
    }

    /// <summary>
    /// Sets the steering response time.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_SteeringResponseTime")]
    public async Task SetSteeringResponseTimeAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_SteeringResponseTime", args);
    }

    /// <summary>
    /// Gets the current stress on the wheel.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Stress")]
    public float GetStress()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_Stress", args);
    }

    /// <summary>
    /// Gets the current stress on the wheel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_Stress")]
    public async Task<float> GetStressAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_Stress", args);
    }

    /// <summary>
    /// Gets the current stress on the wheel as a percentage of its stress tolerance.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_StressPercentage")]
    public float GetStressPercentage()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_StressPercentage", args);
    }

    /// <summary>
    /// Gets the current stress on the wheel as a percentage of its stress tolerance.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_StressPercentage")]
    public async Task<float> GetStressPercentageAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_StressPercentage", args);
    }

    /// <summary>
    /// Stress tolerance of the wheel.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_StressTolerance")]
    public float GetStressTolerance()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_StressTolerance", args);
    }

    /// <summary>
    /// Stress tolerance of the wheel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_StressTolerance")]
    public async Task<float> GetStressToleranceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_StressTolerance", args);
    }

    /// <summary>
    /// Suspension damper strength, as set in the editor.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SuspensionDamperStrength")]
    public float GetSuspensionDamperStrength()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_SuspensionDamperStrength", args);
    }

    /// <summary>
    /// Suspension damper strength, as set in the editor.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SuspensionDamperStrength")]
    public async Task<float> GetSuspensionDamperStrengthAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_SuspensionDamperStrength", args);
    }

    /// <summary>
    /// Suspension spring strength, as set in the editor.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SuspensionSpringStrength")]
    public float GetSuspensionSpringStrength()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_SuspensionSpringStrength", args);
    }

    /// <summary>
    /// Suspension spring strength, as set in the editor.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_SuspensionSpringStrength")]
    public async Task<float> GetSuspensionSpringStrengthAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_SuspensionSpringStrength", args);
    }

    /// <summary>
    /// Setting for the traction control.
    /// Only takes effect if the wheel has automatic traction control enabled.
    /// A value between 0 and 5 inclusive.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_TractionControl")]
    public float GetTractionControl()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Wheel_get_TractionControl", args);
    }

    /// <summary>
    /// Setting for the traction control.
    /// Only takes effect if the wheel has automatic traction control enabled.
    /// A value between 0 and 5 inclusive.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_TractionControl")]
    public async Task<float> GetTractionControlAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Wheel_get_TractionControl", args);
    }

    /// <summary>
    /// Sets the traction control value.
    /// Only takes effect if the wheel has automatic traction control enabled.
    /// A value between 0 and 5 inclusive.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_TractionControl")]
    public void SetTractionControl(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_TractionControl", args);
    }

    /// <summary>
    /// Sets the traction control value.
    /// Only takes effect if the wheel has automatic traction control enabled.
    /// A value between 0 and 5 inclusive.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_TractionControl")]
    public async Task SetTractionControlAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_TractionControl", args);
    }

    /// <summary>
    /// Gets whether automatic traction control is enabled.
    /// A wheel only has traction control if it is powered.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_TractionControlEnabled")]
    public bool GetTractionControlEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Wheel_get_TractionControlEnabled", args);
    }

    /// <summary>
    /// Gets whether automatic traction control is enabled.
    /// A wheel only has traction control if it is powered.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Wheel_get_TractionControlEnabled")]
    public async Task<bool> GetTractionControlEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Wheel_get_TractionControlEnabled", args);
    }

    /// <summary>
    /// Sets whether automatic traction control is enabled.
    /// A wheel only has traction control if it is powered.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_TractionControlEnabled")]
    public void SetTractionControlEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Wheel_set_TractionControlEnabled", args);
    }

    /// <summary>
    /// Sets whether automatic traction control is enabled.
    /// A wheel only has traction control if it is powered.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Wheel_set_TractionControlEnabled")]
    public async Task SetTractionControlEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Wheel_set_TractionControlEnabled", args);
    }
}
