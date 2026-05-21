using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A fairing. Obtained by calling <see cref="M:SpaceCenter.Part.Fairing" />.
/// Supports both stock fairings, and those from the ProceduralFairings mod.
/// </summary>
public class Fairing : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Fairing (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Jettison the fairing. Has no effect if it has already been jettisoned.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Fairing_Jettison")]
    public void Jettison ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Fairing_Jettison", _args);
    }

    /// <summary>
    /// Whether the fairing has been jettisoned.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Fairing_get_Jettisoned")]
    public bool Jettisoned {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Fairing_get_Jettisoned", _args);
        }
    }

    /// <summary>
    /// The part object for this fairing.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Fairing_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Fairing_get_Part", _args);
        }
    }
}
