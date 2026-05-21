namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// The control state of a vessel.
/// See <see cref="M:SpaceCenter.Control.GetState" />.
/// </summary>
[Serializable]
public enum ControlState
{
    /// <summary>
    /// Full controllable.
    /// </summary>
    Full = 0,
    /// <summary>
    /// Partially controllable.
    /// </summary>
    Partial = 1,
    /// <summary>
    /// Not controllable.
    /// </summary>
    None = 2
}
