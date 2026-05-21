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
    [RpcAttribute ("SpaceCenter", "CargoBay_get_Open")]
    public bool Open {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "CargoBay_get_Open", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CargoBay_set_Open", _args);
        }
    }

    /// <summary>
    /// The part object for this cargo bay.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CargoBay_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "CargoBay_get_Part", _args);
        }
    }

    /// <summary>
    /// The state of the cargo bay.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CargoBay_get_State")]
    public CargoBayState State {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<CargoBayState> ("SpaceCenter", "CargoBay_get_State", _args);
        }
    }
}
