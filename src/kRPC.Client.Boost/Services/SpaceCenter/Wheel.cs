using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A wheel. Includes landing gear and rover wheels.
/// Obtained by calling <see cref="M:SpaceCenter.Part.Wheel" />.
/// Can be used to control the motors, steering and deployment of wheels, among other things.
/// </summary>
public class Wheel : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Wheel (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether automatic friction control is enabled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_AutoFrictionControl")]
    public bool AutoFrictionControl {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_AutoFrictionControl", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_AutoFrictionControl", _args);
        }
    }

    /// <summary>
    /// The braking force, as a percentage of maximum, when the brakes are applied.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Brakes")]
    public float Brakes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Brakes", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_Brakes", _args);
        }
    }

    /// <summary>
    /// Whether the wheel is broken.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Broken")]
    public bool Broken {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Broken", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Current deflection of the wheel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Deflection")]
    public float Deflection {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Deflection", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the wheel is deployable.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Deployable")]
    public bool Deployable {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Deployable", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the wheel is deployed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Deployed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_Deployed", _args);
        }
    }

    /// <summary>
    /// Manual setting for the motor limiter.
    /// Only takes effect if the wheel has automatic traction control disabled.
    /// A value between 0 and 100 inclusive.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_DriveLimiter")]
    public float DriveLimiter {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_DriveLimiter", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_DriveLimiter", _args);
        }
    }

    /// <summary>
    /// Whether the wheel is touching the ground.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Grounded")]
    public bool Grounded {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Grounded", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the wheel has brakes.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_HasBrakes")]
    public bool HasBrakes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_HasBrakes", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the wheel has suspension.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_HasSuspension")]
    public bool HasSuspension {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_HasSuspension", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Manual friction control value. Only has an effect if automatic friction control is disabled.
    /// A value between 0 and 5 inclusive.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_ManualFrictionControl")]
    public float ManualFrictionControl {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_ManualFrictionControl", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_ManualFrictionControl", _args);
        }
    }

    /// <summary>
    /// Whether the motor is enabled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_MotorEnabled")]
    public bool MotorEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_MotorEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_MotorEnabled", _args);
        }
    }

    /// <summary>
    /// Whether the direction of the motor is inverted.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_MotorInverted")]
    public bool MotorInverted {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_MotorInverted", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_MotorInverted", _args);
        }
    }

    /// <summary>
    /// The output of the motor. This is the torque currently being generated, in Newton meters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_MotorOutput")]
    public float MotorOutput {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_MotorOutput", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the direction of the motor is inverted.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_MotorState")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.MotorState MotorState {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_MotorState", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.MotorState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.MotorState), connection);
        }
    }

    /// <summary>
    /// The part object for this wheel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Whether the wheel is powered by a motor.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Powered")]
    public bool Powered {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Powered", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Radius of the wheel, in meters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Radius")]
    public float Radius {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Radius", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the wheel is repairable.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Repairable")]
    public bool Repairable {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Repairable", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Current slip of the wheel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Slip")]
    public float Slip {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Slip", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The current state of the wheel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_State")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.WheelState State {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_State", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.WheelState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.WheelState), connection);
        }
    }

    /// <summary>
    /// Whether the wheel has steering.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Steerable")]
    public bool Steerable {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Steerable", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The steering angle limit.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SteeringAngleLimit")]
    public float SteeringAngleLimit {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SteeringAngleLimit", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_SteeringAngleLimit", _args);
        }
    }

    /// <summary>
    /// Whether the wheel steering is enabled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SteeringEnabled")]
    public bool SteeringEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SteeringEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_SteeringEnabled", _args);
        }
    }

    /// <summary>
    /// Whether the wheel steering is inverted.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SteeringInverted")]
    public bool SteeringInverted {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SteeringInverted", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_SteeringInverted", _args);
        }
    }

    /// <summary>
    /// Steering response time.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SteeringResponseTime")]
    public float SteeringResponseTime {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SteeringResponseTime", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_SteeringResponseTime", _args);
        }
    }

    /// <summary>
    /// Current stress on the wheel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Stress")]
    public float Stress {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Stress", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Current stress on the wheel as a percentage of its stress tolerance.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_StressPercentage")]
    public float StressPercentage {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_StressPercentage", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Stress tolerance of the wheel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_StressTolerance")]
    public float StressTolerance {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_StressTolerance", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Suspension damper strength, as set in the editor.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SuspensionDamperStrength")]
    public float SuspensionDamperStrength {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SuspensionDamperStrength", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Suspension spring strength, as set in the editor.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SuspensionSpringStrength")]
    public float SuspensionSpringStrength {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SuspensionSpringStrength", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Setting for the traction control.
    /// Only takes effect if the wheel has automatic traction control enabled.
    /// A value between 0 and 5 inclusive.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_TractionControl")]
    public float TractionControl {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_TractionControl", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_TractionControl", _args);
        }
    }

    /// <summary>
    /// Whether automatic traction control is enabled.
    /// A wheel only has traction control if it is powered.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_TractionControlEnabled")]
    public bool TractionControlEnabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_TractionControlEnabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Wheel_set_TractionControlEnabled", _args);
        }
    }
}