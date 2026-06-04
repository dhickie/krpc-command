namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// The type of a communication link.
/// See <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.CommLink.GetComLinkType" />.
/// </summary>
[Serializable]
public enum CommLinkType
{
    /// <summary>
    /// Link is to a base station on Kerbin.
    /// </summary>
    Home = 0,
    /// <summary>
    /// Link is to a control source, for example a manned spacecraft.
    /// </summary>
    Control = 1,
    /// <summary>
    /// Link is to a relay satellite.
    /// </summary>
    Relay = 2
}
