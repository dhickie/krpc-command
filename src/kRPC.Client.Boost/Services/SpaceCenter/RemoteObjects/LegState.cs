namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// The state of a landing leg. See <see cref="M:SpaceCenter.Leg.GetState" />.
/// </summary>
[Serializable]
public enum LegState
{
    /// <summary>
    /// Landing leg is fully deployed.
    /// </summary>
    Deployed = 0,
    /// <summary>
    /// Landing leg is fully retracted.
    /// </summary>
    Retracted = 1,
    /// <summary>
    /// Landing leg is being deployed.
    /// </summary>
    Deploying = 2,
    /// <summary>
    /// Landing leg is being retracted.
    /// </summary>
    Retracting = 3,
    /// <summary>
    /// Landing leg is broken.
    /// </summary>
    Broken = 4
}
