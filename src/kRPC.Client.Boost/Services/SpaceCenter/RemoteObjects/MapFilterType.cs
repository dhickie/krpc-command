namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// The set of things that are visible in map mode.
/// These may be combined with bitwise logic.
/// </summary>
[Serializable]
public enum MapFilterType
{
    /// <summary>
    /// Everything.
    /// </summary>
    All = -1,
    /// <summary>
    /// Nothing.
    /// </summary>
    None = 0,
    /// <summary>
    /// Debris.
    /// </summary>
    Debris = 1,
    /// <summary>
    /// Unknown.
    /// </summary>
    Unknown = 2,
    /// <summary>
    /// SpaceObjects.
    /// </summary>
    SpaceObjects = 4,
    /// <summary>
    /// Probes.
    /// </summary>
    Probes = 8,
    /// <summary>
    /// Rovers.
    /// </summary>
    Rovers = 16,
    /// <summary>
    /// Landers.
    /// </summary>
    Landers = 32,
    /// <summary>
    /// Ships.
    /// </summary>
    Ships = 64,
    /// <summary>
    /// Stations.
    /// </summary>
    Stations = 128,
    /// <summary>
    /// Bases.
    /// </summary>
    Bases = 256,
    /// <summary>
    /// EVAs.
    /// </summary>
    EVAs = 512,
    /// <summary>
    /// Flags.
    /// </summary>
    Flags = 1024,
    /// <summary>
    /// Planes.
    /// </summary>
    Plane = 2048,
    /// <summary>
    /// Relays.
    /// </summary>
    Relay = 4096,
    /// <summary>
    /// Launch Sites.
    /// </summary>
    Site = 8192,
    /// <summary>
    /// Deployed Science Controllers.
    /// </summary>
    DeployedScienceController = 16384
}