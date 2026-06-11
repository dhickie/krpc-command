namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Editor facility.
/// See <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.LaunchSite.GetEditorFacility" />.
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
