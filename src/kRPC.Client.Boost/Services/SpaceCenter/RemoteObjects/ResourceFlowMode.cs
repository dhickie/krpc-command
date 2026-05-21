namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// The way in which a resource flows between parts. See <see cref="M:SpaceCenter.Resources.FlowMode" />.
/// </summary>
[Serializable]
public enum ResourceFlowMode
{
    /// <summary>
    /// The resource flows to any part in the vessel. For example, electric charge.
    /// </summary>
    Vessel = 0,
    /// <summary>
    /// The resource flows from parts in the first stage, followed by the second,
    /// and so on. For example, mono-propellant.
    /// </summary>
    Stage = 1,
    /// <summary>
    /// The resource flows between adjacent parts within the vessel. For example,
    /// liquid fuel or oxidizer.
    /// </summary>
    Adjacent = 2,
    /// <summary>
    /// The resource does not flow. For example, solid fuel.
    /// </summary>
    None = 3
}