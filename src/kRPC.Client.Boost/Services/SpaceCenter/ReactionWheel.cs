using Google.Protobuf;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A reaction wheel. Obtained by calling <see cref="M:SpaceCenter.Part.ReactionWheel" />.
/// </summary>
public class ReactionWheel : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ReactionWheel (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the reaction wheel is active.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_Active")]
    public bool Active {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_Active", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "ReactionWheel_set_Active", _args);
        }
    }

    /// <summary>
    /// The available torque, in Newton meters, that can be produced by this reaction wheel,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// Returns zero if the reaction wheel is inactive or broken.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_AvailableTorque")]
    public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableTorque {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_AvailableTorque", _args);
            return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
        }
    }

    /// <summary>
    /// Whether the reaction wheel is broken.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_Broken")]
    public bool Broken {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_Broken", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The maximum torque, in Newton meters, that can be produced by this reaction wheel,
    /// when it is active, in the positive and negative pitch, roll and yaw axes of the vessel.
    /// These axes correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_MaxTorque")]
    public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> MaxTorque {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_MaxTorque", _args);
            return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
        }
    }

    /// <summary>
    /// The part object for this reaction wheel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }
}