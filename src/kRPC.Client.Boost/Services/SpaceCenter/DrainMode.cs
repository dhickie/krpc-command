namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Resource drain mode.
/// See <see cref="M:SpaceCenter.ResourceDrain.DrainMode" />.
/// </summary>
[Serializable]
public enum DrainMode
{
    /// <summary>
    /// Drains from the parent part.
    /// </summary>
    Part = 0,
    /// <summary>
    /// Drains from all available parts.
    /// </summary>
    Vessel = 1
}