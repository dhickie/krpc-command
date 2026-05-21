namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// The game mode.
/// Returned by <see cref="T:SpaceCenter.GameMode" /></summary>
[Serializable]
public enum GameMode
{
    /// <summary>
    /// Sandbox mode.
    /// </summary>
    Sandbox = 0,
    /// <summary>
    /// Career mode.
    /// </summary>
    Career = 1,
    /// <summary>
    /// Science career mode.
    /// </summary>
    Science = 2,
    /// <summary>
    /// Science sandbox mode.
    /// </summary>
    ScienceSandbox = 3,
    /// <summary>
    /// Mission mode.
    /// </summary>
    Mission = 4,
    /// <summary>
    /// Mission builder mode.
    /// </summary>
    MissionBuilder = 5,
    /// <summary>
    /// Scenario mode.
    /// </summary>
    Scenario = 6,
    /// <summary>
    /// Scenario mode that cannot be resumed.
    /// </summary>
    ScenarioNonResumable = 7
}