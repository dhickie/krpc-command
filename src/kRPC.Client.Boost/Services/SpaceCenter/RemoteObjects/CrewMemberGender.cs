namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A crew member's gender.
/// See <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.CrewMember.GetGender" />.
/// </summary>
[Serializable]
public enum CrewMemberGender
{
    /// <summary>
    /// Male.
    /// </summary>
    Male = 0,
    /// <summary>
    /// Female.
    /// </summary>
    Female = 1
}
