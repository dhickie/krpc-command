namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of a cargo bay. See <see cref="M:SpaceCenter.CargoBay.GetState" />.
/// </summary>
[Serializable]
public enum CargoBayState
{
    /// <summary>
    /// Cargo bay is fully open.
    /// </summary>
    Open = 0,
    /// <summary>
    /// Cargo bay closed and locked.
    /// </summary>
    Closed = 1,
    /// <summary>
    /// Cargo bay is opening.
    /// </summary>
    Opening = 2,
    /// <summary>
    /// Cargo bay is closing.
    /// </summary>
    Closing = 3
}
