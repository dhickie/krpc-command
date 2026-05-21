namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A crew member's suit type.
/// See <see cref="M:SpaceCenter.CrewMember.GetSuitType" />.
/// </summary>
[Serializable]
public enum SuitType
{
    /// <summary>
    /// Default.
    /// </summary>
    Default = 0,
    /// <summary>
    /// Vintage.
    /// </summary>
    Vintage = 1,
    /// <summary>
    /// Future.
    /// </summary>
    Future = 2,
    /// <summary>
    /// Slim.
    /// </summary>
    Slim = 3
}
