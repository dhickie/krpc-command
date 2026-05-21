using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a communication node in the network. For example, a vessel or the KSC.
/// </summary>
public class CommLink : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CommLink (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Start point of the link.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommLink_get_End")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CommNode End {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommLink))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CommLink_get_End", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.CommNode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommNode), connection);
        }
    }

    /// <summary>
    /// Signal strength of the link.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommLink_get_SignalStrength")]
    public double SignalStrength {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommLink))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CommLink_get_SignalStrength", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Start point of the link.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommLink_get_Start")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CommNode Start {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommLink))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CommLink_get_Start", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.CommNode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommNode), connection);
        }
    }

    /// <summary>
    /// The type of link.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommLink_get_Type")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CommLinkType Type {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommLink))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CommLink_get_Type", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.CommLinkType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommLinkType), connection);
        }
    }
}
