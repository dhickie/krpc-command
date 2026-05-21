using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A radiator. Obtained by calling <see cref="M:SpaceCenter.Part.Radiator" />.
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
    /// Whether the radiator is deployable.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Radiator_get_Deployable")]
    public bool Deployable {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Radiator_get_Deployable", _args);
        }
    }

    /// <summary>
    /// For a deployable radiator, <c>true</c> if the radiator is extended.
    /// If the radiator is not deployable, this is always <c>true</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Radiator_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Radiator_get_Deployed", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Radiator_set_Deployed", _args);
        }
    }

    /// <summary>
    /// The part object for this radiator.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Radiator_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Radiator_get_Part", _args);
        }
    }

    /// <summary>
    /// The current state of the radiator.
    /// </summary>
    /// <remarks>
    /// A fixed radiator is always <see cref="M:SpaceCenter.RadiatorState.Extended" />.
    /// </remarks>
    [RpcAttribute ("SpaceCenter", "Radiator_get_State")]
    public RadiatorState State {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<RadiatorState> ("SpaceCenter", "Radiator_get_State", _args);
        }
    }
}
