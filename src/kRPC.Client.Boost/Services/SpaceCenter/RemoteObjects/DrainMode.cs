namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Resource drain mode.
/// See <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.ResourceDrain.GetDrainMode" />.
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
