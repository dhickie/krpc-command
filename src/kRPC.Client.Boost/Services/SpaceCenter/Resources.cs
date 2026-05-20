using Google.Protobuf;
using KRPC.Client;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents the collection of resources stored in a vessel, stage or part.
/// Created by calling <see cref="M:SpaceCenter.Vessel.Resources" />,
/// <see cref="M:SpaceCenter.Vessel.ResourcesInDecoupleStage" /> or
/// <see cref="M:SpaceCenter.Part.Resources" />.
/// </summary>
public class Resources : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Resources (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Returns the amount of a resource that is currently stored.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_Amount")]
    public float Amount (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Resources_Amount", _args);
        return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
    }

    /// <summary>
    /// Check whether the named resource can be stored.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_HasResource")]
    public bool HasResource (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Resources_HasResource", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Returns the amount of a resource that can be stored.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_Max")]
    public float Max (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Resources_Max", _args);
        return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
    }

    /// <summary>
    /// All the individual resources with the given name that can be stored.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_WithResource")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Resource> WithResource (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Resources_WithResource", _args);
        return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Resource>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Resource>), connection);
    }

    /// <summary>
    /// Returns the density of a resource, in <math>kg/l</math>.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    /// <param name="connection">A connection object.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_static_Density")]
    public static float Density (IConnection connection, string name)
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Resources_static_Density", _args);
        return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
    }

    /// <summary>
    /// Returns the flow mode of a resource.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    /// <param name="connection">A connection object.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_static_FlowMode")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.ResourceFlowMode FlowMode (IConnection connection, string name)
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Resources_static_FlowMode", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.ResourceFlowMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceFlowMode), connection);
    }

    /// <summary>
    /// All the individual resources that can be stored.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_get_All")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Resource> All {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resources_get_All", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Resource>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Resource>), connection);
        }
    }

    /// <summary>
    /// Whether use of all the resources are enabled.
    /// </summary>
    /// <remarks>
    /// This is <c>true</c> if all of the resources are enabled.
    /// If any of the resources are not enabled, this is <c>false</c>.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_get_Enabled")]
    public bool Enabled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resources_get_Enabled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Resources_set_Enabled", _args);
        }
    }

    /// <summary>
    /// A list of resource names that can be stored.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_get_Names")]
    public global::System.Collections.Generic.IList<string> Names {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resources_get_Names", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }
}