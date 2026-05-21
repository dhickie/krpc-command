namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of a parachute. See <see cref="M:SpaceCenter.Parachute.GetState" />.
/// </summary>
[Serializable]
public enum ParachuteState
{
    /// <summary>
    /// The parachute is safely tucked away inside its housing.
    /// </summary>
    Stowed = 0,
    /// <summary>
    /// The parachute is armed for deployment.
    /// </summary>
    Armed = 1,
    /// <summary>
    /// The parachute has been deployed and is providing some drag,
    /// but is not fully deployed yet. (Stock parachutes only)
    /// </summary>
    SemiDeployed = 2,
    /// <summary>
    /// The parachute is fully deployed.
    /// </summary>
    Deployed = 3,
    /// <summary>
    /// The parachute has been cut.
    /// </summary>
    Cut = 4
}
