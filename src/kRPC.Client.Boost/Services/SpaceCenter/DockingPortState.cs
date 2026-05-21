namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of a docking port. See <see cref="M:SpaceCenter.DockingPort.GetState" />.
/// </summary>
[Serializable]
public enum DockingPortState
{
    /// <summary>
    /// The docking port is ready to dock to another docking port.
    /// </summary>
    Ready = 0,
    /// <summary>
    /// The docking port is docked to another docking port, or docked to
    /// another part (from the VAB/SPH).
    /// </summary>
    Docked = 1,
    /// <summary>
    /// The docking port is very close to another docking port,
    /// but has not docked. It is using magnetic force to acquire a solid dock.
    /// </summary>
    Docking = 2,
    /// <summary>
    /// The docking port has just been undocked from another docking port,
    /// and is disabled until it moves away by a sufficient distance
    /// (<see cref="M:SpaceCenter.DockingPort.GetReengageDistance" />).
    /// </summary>
    Undocking = 3,
    /// <summary>
    /// The docking port has a shield, and the shield is closed.
    /// </summary>
    Shielded = 4,
    /// <summary>
    /// The docking ports shield is currently opening/closing.
    /// </summary>
    Moving = 5
}
