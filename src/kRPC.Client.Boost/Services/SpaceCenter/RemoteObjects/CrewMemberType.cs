namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// The type of a crew member.
/// See <see cref="M:SpaceCenter.CrewMember.GetType" />.
/// </summary>
[Serializable]
public enum CrewMemberType
{
    /// <summary>
    /// An applicant for crew.
    /// </summary>
    Applicant = 0,
    /// <summary>
    /// Rocket crew.
    /// </summary>
    Crew = 1,
    /// <summary>
    /// A tourist.
    /// </summary>
    Tourist = 2,
    /// <summary>
    /// An unowned crew member.
    /// </summary>
    Unowned = 3
}
