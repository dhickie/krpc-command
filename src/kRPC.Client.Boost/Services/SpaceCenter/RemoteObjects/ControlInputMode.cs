namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// See <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Control.GetInputMode" />.
/// </summary>
[Serializable]
public enum ControlInputMode
{
    /// <summary>
    /// Control inputs are added to the vessels current control inputs.
    /// </summary>
    Additive = 0,
    /// <summary>
    /// Control inputs (when they are non-zero) override the vessels current control inputs.
    /// </summary>
    Override = 1
}
