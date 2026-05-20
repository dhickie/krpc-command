namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A crew member's roster status.
/// See <see cref="M:SpaceCenter.CrewMember.RosterStatus" />.
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