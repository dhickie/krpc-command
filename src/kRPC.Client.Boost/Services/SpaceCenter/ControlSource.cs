namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The control source of a vessel.
/// See <see cref="M:SpaceCenter.Control.GetSource" />.
/// </summary>
[Serializable]
public enum ControlSource
{
    /// <summary>
    /// Vessel is controlled by a Kerbal.
    /// </summary>
    Kerbal = 0,
    /// <summary>
    /// Vessel is controlled by a probe core.
    /// </summary>
    Probe = 1,
    /// <summary>
    /// Vessel is not controlled.
    /// </summary>
    None = 2
}
