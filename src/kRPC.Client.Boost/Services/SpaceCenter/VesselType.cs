namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The type of a vessel.
/// See <see cref="M:SpaceCenter.Vessel.Type" />.
/// </summary>
[Serializable]
public enum VesselType
{
    /// <summary>
    /// Base.
    /// </summary>
    Base = 0,
    /// <summary>
    /// Debris.
    /// </summary>
    Debris = 1,
    /// <summary>
    /// Lander.
    /// </summary>
    Lander = 2,
    /// <summary>
    /// Plane.
    /// </summary>
    Plane = 3,
    /// <summary>
    /// Probe.
    /// </summary>
    Probe = 4,
    /// <summary>
    /// Relay.
    /// </summary>
    Relay = 5,
    /// <summary>
    /// Rover.
    /// </summary>
    Rover = 6,
    /// <summary>
    /// Ship.
    /// </summary>
    Ship = 7,
    /// <summary>
    /// Station.
    /// </summary>
    Station = 8,
    /// <summary>
    /// SpaceObject.
    /// </summary>
    SpaceObject = 9,
    /// <summary>
    /// Unknown.
    /// </summary>
    Unknown = 10,
    /// <summary>
    /// EVA.
    /// </summary>
    EVA = 11,
    /// <summary>
    /// Flag.
    /// </summary>
    Flag = 12,
    /// <summary>
    /// DeployedScienceController.
    /// </summary>
    DeployedScienceController = 13,
    /// <summary>
    /// DeploedSciencePart.
    /// </summary>
    DeployedSciencePart = 14,
    /// <summary>
    /// DroppedPart.
    /// </summary>
    DroppedPart = 15,
    /// <summary>
    /// DeployedGroundPart.
    /// </summary>
    DeployedGroundPart = 16
}