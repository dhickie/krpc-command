using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using KRPC.Client;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents the collection of resources stored in a vessel, stage or part.
/// Created by calling <see cref="M:SpaceCenter.Vessel.Resources" />,
/// <see cref="M:SpaceCenter.Vessel.ResourcesInDecoupleStage" /> or
/// <see cref="M:SpaceCenter.Part.Resources" />.
/// </summary>
public class Resources : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Resources (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Returns the amount of a resource that is currently stored.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [RpcAttribute ("SpaceCenter", "Resources_Amount")]
    public float Amount (string name)
    {
        var args = new object[] {
            this,
            name
        };
        return Connection.Invoke<float> ("SpaceCenter", "Resources_Amount", args);
    }

    /// <summary>
    /// Check whether the named resource can be stored.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [RpcAttribute ("SpaceCenter", "Resources_HasResource")]
    public bool HasResource (string name)
    {
        var args = new object[] {
            this,
            name
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Resources_HasResource", args);
    }

    /// <summary>
    /// Returns the amount of a resource that can be stored.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [RpcAttribute ("SpaceCenter", "Resources_Max")]
    public float Max (string name)
    {
        var args = new object[] {
            this,
            name
        };
        return Connection.Invoke<float> ("SpaceCenter", "Resources_Max", args);
    }

    /// <summary>
    /// All the individual resources with the given name that can be stored.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resources_WithResource")]
    public IList<Resource> WithResource (string name)
    {
        var args = new object[] {
            this,
            name
        };
        return Connection.Invoke<IList<Resource>> ("SpaceCenter", "Resources_WithResource", args);
    }

    /// <summary>
    /// Returns the density of a resource, in <math>kg/l</math>.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    /// <param name="connection">A connection object.</param>
    [RpcAttribute ("SpaceCenter", "Resources_static_Density")]
    public static float Density (ConnectionMultiplexer connection, string name)
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            name
        };
        return connection.Invoke<float> ("SpaceCenter", "Resources_static_Density", args);
    }

    /// <summary>
    /// Returns the flow mode of a resource.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    /// <param name="connection">A connection object.</param>
    [RpcAttribute ("SpaceCenter", "Resources_static_FlowMode")]
    public static ResourceFlowMode FlowMode (ConnectionMultiplexer connection, string name)
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            name
        };
        return connection.Invoke<ResourceFlowMode> ("SpaceCenter", "Resources_static_FlowMode", args);
    }

    /// <summary>
    /// All the individual resources that can be stored.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resources_get_All")]
    public IList<Resource> All {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Resource>> ("SpaceCenter", "Resources_get_All", args);
        }
    }

    /// <summary>
    /// Whether use of all the resources are enabled.
    /// </summary>
    /// <remarks>
    /// This is <c>true</c> if all of the resources are enabled.
    /// If any of the resources are not enabled, this is <c>false</c>.
    /// </remarks>
    [RpcAttribute ("SpaceCenter", "Resources_get_Enabled")]
    public bool Enabled {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Resources_get_Enabled", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Resources_set_Enabled", args);
        }
    }

    /// <summary>
    /// A list of resource names that can be stored.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Resources_get_Names")]
    public IList<string> Names {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "Resources_get_Names", args);
        }
    }
}
