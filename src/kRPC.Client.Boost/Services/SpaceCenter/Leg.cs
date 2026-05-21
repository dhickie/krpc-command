using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A landing leg. Obtained by calling <see cref="M:SpaceCenter.Part.Leg" />.
/// </summary>
public class Leg : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Leg (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the leg is deployable.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Leg_get_Deployable")]
    public bool Deployable {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Leg))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_Deployable", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the landing leg is deployed.
    /// </summary>
    /// <remarks>
    /// Fixed landing legs are always deployed.
    /// Returns an error if you try to deploy fixed landing gear.
    /// </remarks>
    [RpcAttribute ("SpaceCenter", "Leg_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Leg))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_Deployed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Leg)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Leg_set_Deployed", _args);
        }
    }

    /// <summary>
    /// Returns whether the leg is touching the ground.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Leg_get_IsGrounded")]
    public bool IsGrounded {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Leg))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_IsGrounded", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The part object for this landing leg.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Leg_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Leg))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// The current state of the landing leg.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Leg_get_State")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.LegState State {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Leg))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_State", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.LegState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.LegState), connection);
        }
    }
}
