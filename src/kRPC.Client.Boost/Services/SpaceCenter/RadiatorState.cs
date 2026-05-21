namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of a radiator. <see cref="M:SpaceCenter.Radiator.GetState" /></summary>
[Serializable]
public enum RadiatorState
{
    /// <summary>
    /// Radiator is fully extended.
    /// </summary>
    Extended = 0,
    /// <summary>
    /// Radiator is fully retracted.
    /// </summary>
    Retracted = 1,
    /// <summary>
    /// Radiator is being extended.
    /// </summary>
    Extending = 2,
    /// <summary>
    /// Radiator is being retracted.
    /// </summary>
    Retracting = 3,
    /// <summary>
    /// Radiator is broken.
    /// </summary>
    Broken = 4
}
