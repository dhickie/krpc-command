using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a communication node in the network. For example, a vessel or the KSC.
/// </summary>
public class CommNode : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CommNode (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the communication node is a control point, for example a manned vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_IsControlPoint")]
    public bool IsControlPoint {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommNode))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_IsControlPoint", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the communication node is on Kerbin.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_IsHome")]
    public bool IsHome {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommNode))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_IsHome", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the communication node is a vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_IsVessel")]
    public bool IsVessel {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommNode))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_IsVessel", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Name of the communication node.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_Name")]
    public string Name {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommNode))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// The vessel for this communication node.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_Vessel")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Vessel Vessel {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CommNode))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_Vessel", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel), connection);
        }
    }
}