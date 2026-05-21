using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A wheel. Includes landing gear and rover wheels.
/// Obtained by calling <see cref="M:SpaceCenter.Part.Wheel" />.
/// Can be used to control the motors, steering and deployment of wheels, among other things.
/// </summary>
public class Wheel : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Wheel (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether automatic friction control is enabled.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_AutoFrictionControl")]
    public bool GetAutoFrictionControl ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_AutoFrictionControl", args);
    }

    /// <summary>
    /// Sets the AutoFrictionControl value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetAutoFrictionControl (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_AutoFrictionControl", args);
    }

    /// <summary>
    /// The braking force, as a percentage of maximum, when the brakes are applied.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Brakes")]
    public float GetBrakes ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_Brakes", args);
    }

    /// <summary>
    /// Sets the Brakes value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetBrakes (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_Brakes", args);
    }

    /// <summary>
    /// Whether the wheel is broken.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Broken")]
    public bool GetBroken ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_Broken", args);
    }

    /// <summary>
    /// Current deflection of the wheel.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Deflection")]
    public float GetDeflection ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_Deflection", args);
    }

    /// <summary>
    /// Whether the wheel is deployable.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Deployable")]
    public bool GetDeployable ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_Deployable", args);
    }

    /// <summary>
    /// Whether the wheel is deployed.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Deployed")]
    public bool GetDeployed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_Deployed", args);
    }

    /// <summary>
    /// Sets the Deployed value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetDeployed (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_Deployed", args);
    }

    /// <summary>
    /// Manual setting for the motor limiter.
    /// Only takes effect if the wheel has automatic traction control disabled.
    /// A value between 0 and 100 inclusive.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_DriveLimiter")]
    public float GetDriveLimiter ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_DriveLimiter", args);
    }

    /// <summary>
    /// Sets the DriveLimiter value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetDriveLimiter (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_DriveLimiter", args);
    }

    /// <summary>
    /// Whether the wheel is touching the ground.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Grounded")]
    public bool GetGrounded ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_Grounded", args);
    }

    /// <summary>
    /// Whether the wheel has brakes.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_HasBrakes")]
    public bool GetHasBrakes ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_HasBrakes", args);
    }

    /// <summary>
    /// Whether the wheel has suspension.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_HasSuspension")]
    public bool GetHasSuspension ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_HasSuspension", args);
    }

    /// <summary>
    /// Manual friction control value. Only has an effect if automatic friction control is disabled.
    /// A value between 0 and 5 inclusive.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_ManualFrictionControl")]
    public float GetManualFrictionControl ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_ManualFrictionControl", args);
    }

    /// <summary>
    /// Sets the ManualFrictionControl value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetManualFrictionControl (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_ManualFrictionControl", args);
    }

    /// <summary>
    /// Whether the motor is enabled.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_MotorEnabled")]
    public bool GetMotorEnabled ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_MotorEnabled", args);
    }

    /// <summary>
    /// Sets the MotorEnabled value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetMotorEnabled (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_MotorEnabled", args);
    }

    /// <summary>
    /// Whether the direction of the motor is inverted.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_MotorInverted")]
    public bool GetMotorInverted ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_MotorInverted", args);
    }

    /// <summary>
    /// Sets the MotorInverted value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetMotorInverted (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_MotorInverted", args);
    }

    /// <summary>
    /// The output of the motor. This is the torque currently being generated, in Newton meters.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_MotorOutput")]
    public float GetMotorOutput ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_MotorOutput", args);
    }

    /// <summary>
    /// Whether the direction of the motor is inverted.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_MotorState")]
    public MotorState GetMotorState ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<MotorState> ("SpaceCenter", "Wheel_get_MotorState", args);
    }

    /// <summary>
    /// The part object for this wheel.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Part")]
    public Part GetPart ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Part> ("SpaceCenter", "Wheel_get_Part", args);
    }

    /// <summary>
    /// Whether the wheel is powered by a motor.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Powered")]
    public bool GetPowered ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_Powered", args);
    }

    /// <summary>
    /// Radius of the wheel, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Radius")]
    public float GetRadius ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_Radius", args);
    }

    /// <summary>
    /// Whether the wheel is repairable.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Repairable")]
    public bool GetRepairable ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_Repairable", args);
    }

    /// <summary>
    /// Current slip of the wheel.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Slip")]
    public float GetSlip ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_Slip", args);
    }

    /// <summary>
    /// The current state of the wheel.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_State")]
    public WheelState GetState ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<WheelState> ("SpaceCenter", "Wheel_get_State", args);
    }

    /// <summary>
    /// Whether the wheel has steering.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Steerable")]
    public bool GetSteerable ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_Steerable", args);
    }

    /// <summary>
    /// The steering angle limit.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_SteeringAngleLimit")]
    public float GetSteeringAngleLimit ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_SteeringAngleLimit", args);
    }

    /// <summary>
    /// Sets the SteeringAngleLimit value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSteeringAngleLimit (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_SteeringAngleLimit", args);
    }

    /// <summary>
    /// Whether the wheel steering is enabled.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_SteeringEnabled")]
    public bool GetSteeringEnabled ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_SteeringEnabled", args);
    }

    /// <summary>
    /// Sets the SteeringEnabled value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSteeringEnabled (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_SteeringEnabled", args);
    }

    /// <summary>
    /// Whether the wheel steering is inverted.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_SteeringInverted")]
    public bool GetSteeringInverted ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_SteeringInverted", args);
    }

    /// <summary>
    /// Sets the SteeringInverted value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSteeringInverted (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_SteeringInverted", args);
    }

    /// <summary>
    /// Steering response time.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_SteeringResponseTime")]
    public float GetSteeringResponseTime ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_SteeringResponseTime", args);
    }

    /// <summary>
    /// Sets the SteeringResponseTime value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSteeringResponseTime (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_SteeringResponseTime", args);
    }

    /// <summary>
    /// Current stress on the wheel.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_Stress")]
    public float GetStress ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_Stress", args);
    }

    /// <summary>
    /// Current stress on the wheel as a percentage of its stress tolerance.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_StressPercentage")]
    public float GetStressPercentage ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_StressPercentage", args);
    }

    /// <summary>
    /// Stress tolerance of the wheel.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_StressTolerance")]
    public float GetStressTolerance ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_StressTolerance", args);
    }

    /// <summary>
    /// Suspension damper strength, as set in the editor.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_SuspensionDamperStrength")]
    public float GetSuspensionDamperStrength ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_SuspensionDamperStrength", args);
    }

    /// <summary>
    /// Suspension spring strength, as set in the editor.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_SuspensionSpringStrength")]
    public float GetSuspensionSpringStrength ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_SuspensionSpringStrength", args);
    }

    /// <summary>
    /// Setting for the traction control.
    /// Only takes effect if the wheel has automatic traction control enabled.
    /// A value between 0 and 5 inclusive.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_TractionControl")]
    public float GetTractionControl ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Wheel_get_TractionControl", args);
    }

    /// <summary>
    /// Sets the TractionControl value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTractionControl (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_TractionControl", args);
    }

    /// <summary>
    /// Whether automatic traction control is enabled.
    /// A wheel only has traction control if it is powered.
    /// </summary>
    [Rpc ("SpaceCenter", "Wheel_get_TractionControlEnabled")]
    public bool GetTractionControlEnabled ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Wheel_get_TractionControlEnabled", args);
    }

    /// <summary>
    /// Sets the TractionControlEnabled value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTractionControlEnabled (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Wheel_set_TractionControlEnabled", args);
    }
}
