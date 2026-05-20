namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of a resource converter. See <see cref="M:SpaceCenter.ResourceConverter.State" />.
/// </summary>
[Serializable]
public enum ResourceConverterState
{
    /// <summary>
    /// Converter is running.
    /// </summary>
    Running = 0,
    /// <summary>
    /// Converter is idle.
    /// </summary>
    Idle = 1,
    /// <summary>
    /// Converter is missing a required resource.
    /// </summary>
    MissingResource = 2,
    /// <summary>
    /// No available storage for output resource.
    /// </summary>
    StorageFull = 3,
    /// <summary>
    /// At preset resource capacity.
    /// </summary>
    Capacity = 4,
    /// <summary>
    /// Unknown state. Possible with modified resource converters.
    /// In this case, check <see cref="M:SpaceCenter.ResourceConverter.StatusInfo" /> for more information.
    /// </summary>
    Unknown = 5
}