using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A resource harvester (drill). Obtained by calling <see cref="M:SpaceCenter.Part.ResourceHarvester" />.
/// </summary>
public class ResourceHarvester : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ResourceHarvester (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the harvester is actively drilling.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_Active")]
    public bool Active {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ResourceHarvester_get_Active", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ResourceHarvester_set_Active", _args);
        }
    }

    /// <summary>
    /// The core temperature of the drill, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_CoreTemperature")]
    public float CoreTemperature {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceHarvester_get_CoreTemperature", _args);
        }
    }

    /// <summary>
    /// Whether the harvester is deployed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ResourceHarvester_get_Deployed", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ResourceHarvester_set_Deployed", _args);
        }
    }

    /// <summary>
    /// The rate at which the drill is extracting ore, in units per second.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_ExtractionRate")]
    public float ExtractionRate {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceHarvester_get_ExtractionRate", _args);
        }
    }

    /// <summary>
    /// The core temperature at which the drill will operate with peak efficiency, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature")]
    public float OptimumCoreTemperature {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature", _args);
        }
    }

    /// <summary>
    /// The part object for this harvester.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "ResourceHarvester_get_Part", _args);
        }
    }

    /// <summary>
    /// The state of the harvester.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_State")]
    public ResourceHarvesterState State {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ResourceHarvesterState> ("SpaceCenter", "ResourceHarvester_get_State", _args);
        }
    }

    /// <summary>
    /// The thermal efficiency of the drill, as a percentage of its maximum.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency")]
    public float ThermalEfficiency {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency", _args);
        }
    }
}
