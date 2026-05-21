using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A decoupler. Obtained by calling <see cref="M:SpaceCenter.Part.Decoupler" /></summary>
public class Decoupler : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Decoupler (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Fires the decoupler. Returns the new vessel created when the decoupler fires.
    /// Throws an exception if the decoupler has already fired.
    /// </summary>
    /// <remarks>
    /// When called, the active vessel may change. It is therefore possible that,
    /// after calling this function, the object(s) returned by previous call(s) to
    /// <see cref="M:SpaceCenter.ActiveVessel" /> no longer refer to the active vessel.
    /// </remarks>
    [Rpc ("SpaceCenter", "Decoupler_Decouple")]
    public Vessel Decouple ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Vessel> ("SpaceCenter", "Decoupler_Decouple", args);
    }

    /// <summary>
    /// The part attached to this decoupler's explosive node.
    /// </summary>
    [Rpc ("SpaceCenter", "Decoupler_get_AttachedPart")]
    public Part AttachedPart {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Decoupler_get_AttachedPart", args);
        }
    }

    /// <summary>
    /// Whether the decoupler has fired.
    /// </summary>
    [Rpc ("SpaceCenter", "Decoupler_get_Decoupled")]
    public bool Decoupled {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Decoupler_get_Decoupled", args);
        }
    }

    /// <summary>
    /// The impulse that the decoupler imparts when it is fired, in Newton seconds.
    /// </summary>
    [Rpc ("SpaceCenter", "Decoupler_get_Impulse")]
    public float Impulse {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Decoupler_get_Impulse", args);
        }
    }

    /// <summary>
    /// Whether the decoupler is an omni-decoupler (e.g. stack separator)
    /// </summary>
    [Rpc ("SpaceCenter", "Decoupler_get_IsOmniDecoupler")]
    public bool IsOmniDecoupler {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Decoupler_get_IsOmniDecoupler", args);
        }
    }

    /// <summary>
    /// The part object for this decoupler.
    /// </summary>
    [Rpc ("SpaceCenter", "Decoupler_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Decoupler_get_Part", args);
        }
    }

    /// <summary>
    /// Whether the decoupler is enabled in the staging sequence.
    /// </summary>
    [Rpc ("SpaceCenter", "Decoupler_get_Staged")]
    public bool Staged {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Decoupler_get_Staged", args);
        }
    }
}
