using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
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
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Resource_get_Amount", _args);
        }
    }

    /// <summary>
    /// The density of the resource, in <math>kg/l</math>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Density")]
    public float Density {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Resource_get_Density", _args);
        }
    }

    /// <summary>
    /// Whether use of this resource is enabled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Enabled")]
    public bool Enabled {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Resource_get_Enabled", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Resource_set_Enabled", _args);
        }
    }

    /// <summary>
    /// The flow mode of the resource.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_FlowMode")]
    public ResourceFlowMode FlowMode {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ResourceFlowMode> ("SpaceCenter", "Resource_get_FlowMode", _args);
        }
    }

    /// <summary>
    /// The total amount of the resource that can be stored in the part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Max")]
    public float Max {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Resource_get_Max", _args);
        }
    }

    /// <summary>
    /// The name of the resource.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Name")]
    public string Name {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Resource_get_Name", _args);
        }
    }

    /// <summary>
    /// The part containing the resource.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resource_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Resource_get_Part", _args);
        }
    }
}
