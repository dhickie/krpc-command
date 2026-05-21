namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of an antenna. See <see cref="M:SpaceCenter.Antenna.GetState" />.
/// </summary>
[Serializable]
public enum AntennaState
{
    /// <summary>
    /// Antenna is fully deployed.
    /// </summary>
    Deployed = 0,
    /// <summary>
    /// Antenna is fully retracted.
    /// </summary>
    Retracted = 1,
    /// <summary>
    /// Antenna is being deployed.
    /// </summary>
    Deploying = 2,
    /// <summary>
    /// Antenna is being retracted.
    /// </summary>
    Retracting = 3,
    /// <summary>
    /// Antenna is broken.
    /// </summary>
    Broken = 4
}
