using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A resource harvester (drill). Obtained by calling <see cref="M:SpaceCenter.Part.ResourceHarvester" />.
/// </summary>
public class ResourceHarvester : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ResourceHarvester (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the harvester is actively drilling.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_Active")]
    public bool Active {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_Active", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "ResourceHarvester_set_Active", _args);
        }
    }

    /// <summary>
    /// The core temperature of the drill, in Kelvin.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_CoreTemperature")]
    public float CoreTemperature {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_CoreTemperature", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the harvester is deployed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_Deployed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "ResourceHarvester_set_Deployed", _args);
        }
    }

    /// <summary>
    /// The rate at which the drill is extracting ore, in units per second.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_ExtractionRate")]
    public float ExtractionRate {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_ExtractionRate", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The core temperature at which the drill will operate with peak efficiency, in Kelvin.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature")]
    public float OptimumCoreTemperature {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The part object for this harvester.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// The state of the harvester.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_State")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvesterState State {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_State", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvesterState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvesterState), connection);
        }
    }

    /// <summary>
    /// The thermal efficiency of the drill, as a percentage of its maximum.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency")]
    public float ThermalEfficiency {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }
}