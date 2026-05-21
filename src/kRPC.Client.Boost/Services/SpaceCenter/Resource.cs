using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An individual resource stored within a part.
/// Created using methods in the <see cref="T:SpaceCenter.Resources" /> class.
/// </summary>
public class Resource : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Resource (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// The amount of the resource that is currently stored in the part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Amount")]
    public float Amount {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Amount", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The density of the resource, in <math>kg/l</math>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Density")]
    public float Density {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Density", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether use of this resource is enabled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Enabled")]
    public bool Enabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Enabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Resource_set_Enabled", _args);
        }
    }

    /// <summary>
    /// The flow mode of the resource.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_FlowMode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ResourceFlowMode FlowMode {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_FlowMode", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ResourceFlowMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceFlowMode), connection);
        }
    }

    /// <summary>
    /// The total amount of the resource that can be stored in the part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Max")]
    public float Max {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Max", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The name of the resource.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Name")]
    public string Name {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// The part containing the resource.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }
}
