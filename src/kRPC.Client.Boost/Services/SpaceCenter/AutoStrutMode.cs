namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of an auto-strut. <see cref="M:SpaceCenter.Part.AutoStrutMode" /></summary>
[Serializable]
public enum AutoStrutMode
{
    /// <summary>
    /// Off
    /// </summary>
    Off = 0,
    /// <summary>
    /// Root
    /// </summary>
    Root = 1,
    /// <summary>
    /// Heaviest
    /// </summary>
    Heaviest = 2,
    /// <summary>
    /// Grandparent
    /// </summary>
    Grandparent = 3,
    /// <summary>
    /// ForceRoot
    /// </summary>
    ForceRoot = 4,
    /// <summary>
    /// ForceHeaviest
    /// </summary>
    ForceHeaviest = 5,
    /// <summary>
    /// ForceGrandparent
    /// </summary>
    ForceGrandparent = 6
}