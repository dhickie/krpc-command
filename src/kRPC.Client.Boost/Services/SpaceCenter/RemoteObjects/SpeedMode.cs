namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// The mode of the speed reported in the navball.
/// See <see cref="M:SpaceCenter.Control.GetSpeedMode" />.
/// </summary>
[Serializable]
public enum SpeedMode
{
    /// <summary>
    /// Speed is relative to the vessel's orbit.
    /// </summary>
    Orbit = 0,
    /// <summary>
    /// Speed is relative to the surface of the body being orbited.
    /// </summary>
    Surface = 1,
    /// <summary>
    /// Speed is relative to the current target.
    /// </summary>
    Target = 2
}
