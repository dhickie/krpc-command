namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The behavior of the SAS auto-pilot. See <see cref="M:SpaceCenter.AutoPilot.SASMode" />.
/// </summary>
[Serializable]
public enum SASMode
{
    /// <summary>
    /// Stability assist mode. Dampen out any rotation.
    /// </summary>
    StabilityAssist = 0,
    /// <summary>
    /// Point in the burn direction of the next maneuver node.
    /// </summary>
    Maneuver = 1,
    /// <summary>
    /// Point in the prograde direction.
    /// </summary>
    Prograde = 2,
    /// <summary>
    /// Point in the retrograde direction.
    /// </summary>
    Retrograde = 3,
    /// <summary>
    /// Point in the orbit normal direction.
    /// </summary>
    Normal = 4,
    /// <summary>
    /// Point in the orbit anti-normal direction.
    /// </summary>
    AntiNormal = 5,
    /// <summary>
    /// Point in the orbit radial direction.
    /// </summary>
    Radial = 6,
    /// <summary>
    /// Point in the orbit anti-radial direction.
    /// </summary>
    AntiRadial = 7,
    /// <summary>
    /// Point in the direction of the current target.
    /// </summary>
    Target = 8,
    /// <summary>
    /// Point away from the current target.
    /// </summary>
    AntiTarget = 9
}