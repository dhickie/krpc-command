namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// See <see cref="M:SpaceCenter.Camera.GetMode" />.
/// </summary>
[Serializable]
public enum CameraMode
{
    /// <summary>
    /// The camera is showing the active vessel, in "auto" mode.
    /// </summary>
    Automatic = 0,
    /// <summary>
    /// The camera is showing the active vessel, in "free" mode.
    /// </summary>
    Free = 1,
    /// <summary>
    /// The camera is showing the active vessel, in "chase" mode.
    /// </summary>
    Chase = 2,
    /// <summary>
    /// The camera is showing the active vessel, in "locked" mode.
    /// </summary>
    Locked = 3,
    /// <summary>
    /// The camera is showing the active vessel, in "orbital" mode.
    /// </summary>
    Orbital = 4,
    /// <summary>
    /// The Intra-Vehicular Activity view is being shown.
    /// </summary>
    IVA = 5,
    /// <summary>
    /// The map view is being shown.
    /// </summary>
    Map = 6
}
