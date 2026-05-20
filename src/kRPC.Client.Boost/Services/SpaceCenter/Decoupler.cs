using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A decoupler. Obtained by calling <see cref="M:SpaceCenter.Part.Decoupler" /></summary>
public class Decoupler : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Decoupler (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_Decouple")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Vessel Decouple ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_Decouple", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel), connection);
    }

    /// <summary>
    /// The part attached to this decoupler's explosive node.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_AttachedPart")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part AttachedPart {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_AttachedPart", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Whether the decoupler has fired.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_Decoupled")]
    public bool Decoupled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_Decoupled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The impulse that the decoupler imparts when it is fired, in Newton seconds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_Impulse")]
    public float Impulse {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_Impulse", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the decoupler is an omni-decoupler (e.g. stack separator)
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_IsOmniDecoupler")]
    public bool IsOmniDecoupler {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_IsOmniDecoupler", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The part object for this decoupler.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Whether the decoupler is enabled in the staging sequence.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_Staged")]
    public bool Staged {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_Staged", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }
}