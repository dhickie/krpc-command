using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A resource converter. Obtained by calling <see cref="M:SpaceCenter.Part.ResourceConverter" />.
/// </summary>
public class ResourceConverter : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ResourceConverter (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// True if the specified converter is active.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc ("SpaceCenter", "ResourceConverter_Active")]
    public bool Active (int index)
    {
        var args = new object[] {
            this,
            index
        };
        return Connection.Invoke<bool> ("SpaceCenter", "ResourceConverter_Active", args);
    }

    /// <summary>
    /// List of the names of resources consumed by the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc ("SpaceCenter", "ResourceConverter_Inputs")]
    public IList<string> Inputs (int index)
    {
        var args = new object[] {
            this,
            index
        };
        return Connection.Invoke<IList<string>> ("SpaceCenter", "ResourceConverter_Inputs", args);
    }

    /// <summary>
    /// The name of the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc ("SpaceCenter", "ResourceConverter_Name")]
    public string Name (int index)
    {
        var args = new object[] {
            this,
            index
        };
        return Connection.Invoke<string> ("SpaceCenter", "ResourceConverter_Name", args);
    }

    /// <summary>
    /// List of the names of resources produced by the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc ("SpaceCenter", "ResourceConverter_Outputs")]
    public IList<string> Outputs (int index)
    {
        var args = new object[] {
            this,
            index
        };
        return Connection.Invoke<IList<string>> ("SpaceCenter", "ResourceConverter_Outputs", args);
    }

    /// <summary>
    /// Start the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc ("SpaceCenter", "ResourceConverter_Start")]
    public void Start (int index)
    {
        var args = new object[] {
            this,
            index
        };
        Connection.Invoke ("SpaceCenter", "ResourceConverter_Start", args);
    }

    /// <summary>
    /// The state of the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc ("SpaceCenter", "ResourceConverter_State")]
    public ResourceConverterState State (int index)
    {
        var args = new object[] {
            this,
            index
        };
        return Connection.Invoke<ResourceConverterState> ("SpaceCenter", "ResourceConverter_State", args);
    }

    /// <summary>
    /// Status information for the specified converter.
    /// This is the full status message shown in the in-game UI.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc ("SpaceCenter", "ResourceConverter_StatusInfo")]
    public string StatusInfo (int index)
    {
        var args = new object[] {
            this,
            index
        };
        return Connection.Invoke<string> ("SpaceCenter", "ResourceConverter_StatusInfo", args);
    }

    /// <summary>
    /// Stop the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc ("SpaceCenter", "ResourceConverter_Stop")]
    public void Stop (int index)
    {
        var args = new object[] {
            this,
            index
        };
        Connection.Invoke ("SpaceCenter", "ResourceConverter_Stop", args);
    }

    /// <summary>
    /// The core temperature of the converter, in Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "ResourceConverter_get_CoreTemperature")]
    public float CoreTemperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceConverter_get_CoreTemperature", args);
        }
    }

    /// <summary>
    /// The number of converters in the part.
    /// </summary>
    [Rpc ("SpaceCenter", "ResourceConverter_get_Count")]
    public int Count {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<int> ("SpaceCenter", "ResourceConverter_get_Count", args);
        }
    }

    /// <summary>
    /// The core temperature at which the converter will operate with peak efficiency, in Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature")]
    public float OptimumCoreTemperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature", args);
        }
    }

    /// <summary>
    /// The part object for this converter.
    /// </summary>
    [Rpc ("SpaceCenter", "ResourceConverter_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "ResourceConverter_get_Part", args);
        }
    }

    /// <summary>
    /// The thermal efficiency of the converter, as a percentage of its maximum.
    /// </summary>
    [Rpc ("SpaceCenter", "ResourceConverter_get_ThermalEfficiency")]
    public float ThermalEfficiency {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ResourceConverter_get_ThermalEfficiency", args);
        }
    }
}
