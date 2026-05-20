namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of a solar panel. See <see cref="M:SpaceCenter.SolarPanel.State" />.
/// </summary>
[Serializable]
public enum SolarPanelState
{
    /// <summary>
    /// Solar panel is fully extended.
    /// </summary>
    Extended = 0,
    /// <summary>
    /// Solar panel is fully retracted.
    /// </summary>
    Retracted = 1,
    /// <summary>
    /// Solar panel is being extended.
    /// </summary>
    Extending = 2,
    /// <summary>
    /// Solar panel is being retracted.
    /// </summary>
    Retracting = 3,
    /// <summary>
    /// Solar panel is broken.
    /// </summary>
    Broken = 4
}