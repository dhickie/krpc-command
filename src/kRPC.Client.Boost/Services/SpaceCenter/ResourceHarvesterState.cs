namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of a resource harvester. See <see cref="M:SpaceCenter.ResourceHarvester.GetState" />.
/// </summary>
[Serializable]
public enum ResourceHarvesterState
{
    /// <summary>
    /// The drill is deploying.
    /// </summary>
    Deploying = 0,
    /// <summary>
    /// The drill is deployed and ready.
    /// </summary>
    Deployed = 1,
    /// <summary>
    /// The drill is retracting.
    /// </summary>
    Retracting = 2,
    /// <summary>
    /// The drill is retracted.
    /// </summary>
    Retracted = 3,
    /// <summary>
    /// The drill is running.
    /// </summary>
    Active = 4
}
