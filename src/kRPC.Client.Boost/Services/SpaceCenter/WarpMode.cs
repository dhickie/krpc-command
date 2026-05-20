namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The time warp mode.
/// Returned by <see cref="T:SpaceCenter.WarpMode" /></summary>
[Serializable]
public enum WarpMode
{
    /// <summary>
    /// Time warp is active, and in regular "on-rails" mode.
    /// </summary>
    Rails = 0,
    /// <summary>
    /// Time warp is active, and in physical time warp mode.
    /// </summary>
    Physics = 1,
    /// <summary>
    /// Time warp is not active.
    /// </summary>
    None = 2
}