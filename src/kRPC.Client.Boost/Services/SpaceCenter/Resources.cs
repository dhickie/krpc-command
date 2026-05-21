using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using KRPC.Client;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents the collection of resources stored in a vessel, stage or part.
/// Created by calling <see cref="M:SpaceCenter.Vessel.GetResources" />,
/// <see cref="M:SpaceCenter.Vessel.ResourcesInDecoupleStage" /> or
/// <see cref="M:SpaceCenter.Part.GetResources" />.
/// </summary>
public class Resources : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Resources(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Returns the amount of a resource that is currently stored.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [Rpc("SpaceCenter", "Resources_Amount")]
    public float Amount(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return Connection.Invoke<float>("SpaceCenter", "Resources_Amount", args);
    }

    /// <summary>
    /// Check whether the named resource can be stored.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [Rpc("SpaceCenter", "Resources_HasResource")]
    public bool HasResource(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return Connection.Invoke<bool>("SpaceCenter", "Resources_HasResource", args);
    }

    /// <summary>
    /// Returns the amount of a resource that can be stored.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [Rpc("SpaceCenter", "Resources_Max")]
    public float Max(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return Connection.Invoke<float>("SpaceCenter", "Resources_Max", args);
    }

    /// <summary>
    /// All the individual resources with the given name that can be stored.
    /// </summary>
    [Rpc("SpaceCenter", "Resources_WithResource")]
    public IList<Resource> WithResource(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return Connection.Invoke<IList<Resource>>("SpaceCenter", "Resources_WithResource", args);
    }

    /// <summary>
    /// Returns the density of a resource, in <math>kg/l</math>.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [Rpc("SpaceCenter", "Resources_static_Density")]
    public float Density(string name)
    {
        var args = new object[]
        {
            name
        };
        return Connection.Invoke<float>("SpaceCenter", "Resources_static_Density", args);
    }

    /// <summary>
    /// Returns the flow mode of a resource.
    /// </summary>
    /// <param name="name">The name of the resource.</param>
    [Rpc("SpaceCenter", "Resources_static_FlowMode")]
    public ResourceFlowMode FlowMode(string name)
    {
        var args = new object[]
        {
            name
        };
        return Connection.Invoke<ResourceFlowMode>("SpaceCenter", "Resources_static_FlowMode", args);
    }

    /// <summary>
    /// Gets all the individual resources that can be stored.
    /// </summary>
    [Rpc("SpaceCenter", "Resources_get_All")]
    public IList<Resource> GetAll()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Resource>>("SpaceCenter", "Resources_get_All", args);
    }

    /// <summary>
    /// Gets whether all resources are enabled.
    /// </summary>
    /// <remarks>
    /// This is <c>true</c> if all of the resources are enabled.
    /// If any of the resources are not enabled, this is <c>false</c>.
    /// </remarks>
    [Rpc("SpaceCenter", "Resources_get_Enabled")]
    public bool GetEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Resources_get_Enabled", args);
    }

    /// <summary>
    /// Sets whether all resources are enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Resources_set_Enabled", args);
    }

    /// <summary>
    /// Gets a list of resource names that can be stored.
    /// </summary>
    [Rpc("SpaceCenter", "Resources_get_Names")]
    public IList<string> GetNames()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "Resources_get_Names", args);
    }
}
