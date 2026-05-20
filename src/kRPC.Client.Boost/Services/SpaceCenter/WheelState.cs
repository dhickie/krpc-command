namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of a wheel. See <see cref="M:SpaceCenter.Wheel.State" />.
/// </summary>
[Serializable]
public enum WheelState
{
    /// <summary>
    /// Wheel is fully deployed.
    /// </summary>
    Deployed = 0,
    /// <summary>
    /// Wheel is fully retracted.
    /// </summary>
    Retracted = 1,
    /// <summary>
    /// Wheel is being deployed.
    /// </summary>
    Deploying = 2,
    /// <summary>
    /// Wheel is being retracted.
    /// </summary>
    Retracting = 3,
    /// <summary>
    /// Wheel is broken.
    /// </summary>
    Broken = 4
}