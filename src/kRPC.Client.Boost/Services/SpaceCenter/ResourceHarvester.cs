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
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ResourceHarvester_get_Active", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ResourceHarvester_set_Active", args);
        }
    }

    /// <summary>
    /// The core temperature of the drill, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_CoreTemperature")]
    public float CoreTemperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceHarvester_get_CoreTemperature", args);
        }
    }

    /// <summary>
    /// Whether the harvester is deployed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_Deployed")]
    public bool Deployed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ResourceHarvester_get_Deployed", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ResourceHarvester_set_Deployed", args);
        }
    }

    /// <summary>
    /// The rate at which the drill is extracting ore, in units per second.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_ExtractionRate")]
    public float ExtractionRate {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceHarvester_get_ExtractionRate", args);
        }
    }

    /// <summary>
    /// The core temperature at which the drill will operate with peak efficiency, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature")]
    public float OptimumCoreTemperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature", args);
        }
    }

    /// <summary>
    /// The part object for this harvester.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "ResourceHarvester_get_Part", args);
        }
    }

    /// <summary>
    /// The state of the harvester.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_State")]
    public ResourceHarvesterState State {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ResourceHarvesterState> ("SpaceCenter", "ResourceHarvester_get_State", args);
        }
    }

    /// <summary>
    /// The thermal efficiency of the drill, as a percentage of its maximum.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency")]
    public float ThermalEfficiency {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency", args);
        }
    }
}
