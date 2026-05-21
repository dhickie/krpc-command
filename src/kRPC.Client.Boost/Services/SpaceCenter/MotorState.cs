namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of the motor on a powered wheel. See <see cref="M:SpaceCenter.Wheel.GetMotorState" />.
/// </summary>
[Serializable]
public enum MotorState
{
    /// <summary>
    /// The motor is idle.
    /// </summary>
    Idle = 0,
    /// <summary>
    /// The motor is running.
    /// </summary>
    Running = 1,
    /// <summary>
    /// The motor is disabled.
    /// </summary>
    Disabled = 2,
    /// <summary>
    /// The motor is inoperable.
    /// </summary>
    Inoperable = 3,
    /// <summary>
    /// The motor does not have enough resources to run.
    /// </summary>
    NotEnoughResources = 4
}
