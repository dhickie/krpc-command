using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;

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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_CheckResource")]
    public bool CheckResource (global::kRPC.Client.Boost.Services.SpaceCenter.Resource resource)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain)),
            global::KRPC.Client.Encoder.Encode (resource, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_CheckResource", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Whether the given resource should be drained.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_SetResource")]
    public void SetResource (global::kRPC.Client.Boost.Services.SpaceCenter.Resource resource, bool enabled)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain)),
            global::KRPC.Client.Encoder.Encode (resource, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resource)),
            global::KRPC.Client.Encoder.Encode (enabled, typeof(bool))
        };
        connection.Invoke ("SpaceCenter", "ResourceDrain_SetResource", _args);
    }

    /// <summary>
    /// Activates resource draining for all enabled parts.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_Start")]
    public void Start ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain))
        };
        connection.Invoke ("SpaceCenter", "ResourceDrain_Start", _args);
    }

    /// <summary>
    /// Turns off resource draining.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_Stop")]
    public void Stop ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain))
        };
        connection.Invoke ("SpaceCenter", "ResourceDrain_Stop", _args);
    }

    /// <summary>
    /// List of available resources.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_AvailableResources")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Resource> AvailableResources {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_AvailableResources", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Resource>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Resource>), connection);
        }
    }

    /// <summary>
    /// The drain mode.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_DrainMode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.DrainMode DrainMode {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_DrainMode", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.DrainMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DrainMode), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DrainMode))
            };
            connection.Invoke ("SpaceCenter", "ResourceDrain_set_DrainMode", _args);
        }
    }

    /// <summary>
    /// Maximum possible drain rate.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_MaxRate")]
    public float MaxRate {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_MaxRate", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Minimum possible drain rate
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_MinRate")]
    public float MinRate {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_MinRate", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The part object for this resource drain.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Current drain rate.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_Rate")]
    public float Rate {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_Rate", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "ResourceDrain_set_Rate", _args);
        }
    }
}
