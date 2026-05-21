using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A cargo bay. Obtained by calling <see cref="M:SpaceCenter.Part.CargoBay" />.
/// </summary>
public class CargoBay : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CargoBay (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the cargo bay is open.
    /// </summary>
    [Rpc ("SpaceCenter", "CargoBay_get_Open")]
    public bool GetOpen ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CargoBay_get_Open", args);
    }

    /// <summary>
    /// Sets the Open value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetOpen (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "CargoBay_set_Open", args);
    }

    /// <summary>
    /// The part object for this cargo bay.
    /// </summary>
    [Rpc ("SpaceCenter", "CargoBay_get_Part")]
    public Part GetPart ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Part> ("SpaceCenter", "CargoBay_get_Part", args);
    }

    /// <summary>
    /// The state of the cargo bay.
    /// </summary>
    [Rpc ("SpaceCenter", "CargoBay_get_State")]
    public CargoBayState GetState ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<CargoBayState> ("SpaceCenter", "CargoBay_get_State", args);
    }
}
