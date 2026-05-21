using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A resource drain. Obtained by calling <see cref="M:SpaceCenter.Part.ResourceDrain" />.
/// </summary>
public class ResourceDrain : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ResourceDrain (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the provided resource is enabled for draining.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_CheckResource")]
    public bool CheckResource (Resource resource)
    {
        var _args = new object[] {
            this,
            resource
        };
        return Connection.Invoke<bool> ("SpaceCenter", "ResourceDrain_CheckResource", _args);
    }

    /// <summary>
    /// Whether the given resource should be drained.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_SetResource")]
    public void SetResource (Resource resource, bool enabled)
    {
        var _args = new object[] {
            this,
            resource,
            enabled
        };
        Connection.Invoke ("SpaceCenter", "ResourceDrain_SetResource", _args);
    }

    /// <summary>
    /// Activates resource draining for all enabled parts.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_Start")]
    public void Start ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "ResourceDrain_Start", _args);
    }

    /// <summary>
    /// Turns off resource draining.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_Stop")]
    public void Stop ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "ResourceDrain_Stop", _args);
    }

    /// <summary>
    /// List of available resources.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_get_AvailableResources")]
    public IList<Resource> AvailableResources {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<Resource>> ("SpaceCenter", "ResourceDrain_get_AvailableResources", _args);
        }
    }

    /// <summary>
    /// The drain mode.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_get_DrainMode")]
    public DrainMode DrainMode {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<DrainMode> ("SpaceCenter", "ResourceDrain_get_DrainMode", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ResourceDrain_set_DrainMode", _args);
        }
    }

    /// <summary>
    /// Maximum possible drain rate.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_get_MaxRate")]
    public float MaxRate {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceDrain_get_MaxRate", _args);
        }
    }

    /// <summary>
    /// Minimum possible drain rate
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_get_MinRate")]
    public float MinRate {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceDrain_get_MinRate", _args);
        }
    }

    /// <summary>
    /// The part object for this resource drain.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "ResourceDrain_get_Part", _args);
        }
    }

    /// <summary>
    /// Current drain rate.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceDrain_get_Rate")]
    public float Rate {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceDrain_get_Rate", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ResourceDrain_set_Rate", _args);
        }
    }
}
