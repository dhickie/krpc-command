namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The situation a vessel is in.
/// See <see cref="M:SpaceCenter.Vessel.GetSituation" />.
/// </summary>
[Serializable]
public enum VesselSituation
{
    /// <summary>
    /// Vessel is awaiting launch.
    /// </summary>
    PreLaunch = 0,
    /// <summary>
    /// Vessel is orbiting a body.
    /// </summary>
    Orbiting = 1,
    /// <summary>
    /// Vessel is on a sub-orbital trajectory.
    /// </summary>
    SubOrbital = 2,
    /// <summary>
    /// Escaping.
    /// </summary>
    Escaping = 3,
    /// <summary>
    /// Vessel is flying through an atmosphere.
    /// </summary>
    Flying = 4,
    /// <summary>
    /// Vessel is landed on the surface of a body.
    /// </summary>
    Landed = 5,
    /// <summary>
    /// Vessel has splashed down in an ocean.
    /// </summary>
    Splashed = 6,
    /// <summary>
    /// Vessel is docked to another.
    /// </summary>
    Docked = 7
}
