using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A radiator. Obtained by calling <see cref="M:SpaceCenter.Part.GetRadiator" />.
/// </summary>
public class Radiator : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Radiator (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Gets whether the radiator is deployable.
    /// </summary>
    [Rpc ("SpaceCenter", "Radiator_get_Deployable")]
    public bool GetDeployable ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Radiator_get_Deployable", args);
    }

    /// <summary>
    /// Returns <c>true</c> if a deployable radiator is extended.
    /// If the radiator is not deployable, this is always <c>true</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Radiator_get_Deployed")]
    public bool GetDeployed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Radiator_get_Deployed", args);
    }

    /// <summary>
    /// Sets whether a deployable radiator is extended.
    /// If the radiator is not deployable, this is always <c>true</c>.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetDeployed (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Radiator_set_Deployed", args);
    }

    /// <summary>
    /// Gets the part object for this radiator.
    /// </summary>
    [Rpc ("SpaceCenter", "Radiator_get_Part")]
    public Part GetPart ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Part> ("SpaceCenter", "Radiator_get_Part", args);
    }

    /// <summary>
    /// Gets the current state of the radiator.
    /// </summary>
    /// <remarks>
    /// A fixed radiator is always <see cref="M:SpaceCenter.RadiatorState.Extended" />.
    /// </remarks>
    [Rpc ("SpaceCenter", "Radiator_get_State")]
    public RadiatorState GetState ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<RadiatorState> ("SpaceCenter", "Radiator_get_State", args);
    }
}
