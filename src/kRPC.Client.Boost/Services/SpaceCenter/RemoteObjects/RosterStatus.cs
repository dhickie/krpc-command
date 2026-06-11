namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A crew member's roster status.
/// See <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.CrewMember.GetRosterStatus" />.
/// </summary>
[Serializable]
public enum RosterStatus
{
    /// <summary>
    /// Available.
    /// </summary>
    Available = 0,
    /// <summary>
    /// Assigned.
    /// </summary>
    Assigned = 1,
    /// <summary>
    /// Dead.
    /// </summary>
    Dead = 2,
    /// <summary>
    /// Missing.
    /// </summary>
    Missing = 3
}
