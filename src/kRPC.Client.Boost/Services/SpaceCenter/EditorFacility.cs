namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Editor facility.
/// See <see cref="M:SpaceCenter.LaunchSite.EditorFacility" />.
/// </summary>
[Serializable]
public enum EditorFacility
{
    /// <summary>
    /// Vehicle Assembly Building.
    /// </summary>
    VAB = 1,
    /// <summary>
    /// Space Plane Hanger.
    /// </summary>
    SPH = 2,
    /// <summary>
    /// None.
    /// </summary>
    None = 0
}