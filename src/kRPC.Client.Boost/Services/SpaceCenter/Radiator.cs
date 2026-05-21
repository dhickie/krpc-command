using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
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
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Radiator))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Radiator_get_Deployable", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// For a deployable radiator, <c>true</c> if the radiator is extended.
    /// If the radiator is not deployable, this is always <c>true</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Radiator_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Radiator))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Radiator_get_Deployed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Radiator)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Radiator_set_Deployed", _args);
        }
    }

    /// <summary>
    /// The part object for this radiator.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Radiator_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Radiator))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Radiator_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// The current state of the radiator.
    /// </summary>
    /// <remarks>
    /// A fixed radiator is always <see cref="M:SpaceCenter.RadiatorState.Extended" />.
    /// </remarks>
    [RpcAttribute ("SpaceCenter", "Radiator_get_State")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.RadiatorState State {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Radiator))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Radiator_get_State", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.RadiatorState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RadiatorState), connection);
        }
    }
}
