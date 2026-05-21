using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

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
    [RpcAttribute ("SpaceCenter", "ResourceConverter_Active")]
    public bool Active (int index)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter)),
            global::KRPC.Client.Encoder.Encode (index, typeof(int))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_Active", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// List of the names of resources consumed by the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_Inputs")]
    public global::System.Collections.Generic.IList<string> Inputs (int index)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter)),
            global::KRPC.Client.Encoder.Encode (index, typeof(int))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_Inputs", _args);
        return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
    }

    /// <summary>
    /// The name of the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_Name")]
    public string Name (int index)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter)),
            global::KRPC.Client.Encoder.Encode (index, typeof(int))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_Name", _args);
        return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
    }

    /// <summary>
    /// List of the names of resources produced by the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_Outputs")]
    public global::System.Collections.Generic.IList<string> Outputs (int index)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter)),
            global::KRPC.Client.Encoder.Encode (index, typeof(int))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_Outputs", _args);
        return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
    }

    /// <summary>
    /// Start the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_Start")]
    public void Start (int index)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter)),
            global::KRPC.Client.Encoder.Encode (index, typeof(int))
        };
        connection.Invoke ("SpaceCenter", "ResourceConverter_Start", _args);
    }

    /// <summary>
    /// The state of the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_State")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverterState State (int index)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter)),
            global::KRPC.Client.Encoder.Encode (index, typeof(int))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_State", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverterState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverterState), connection);
    }

    /// <summary>
    /// Status information for the specified converter.
    /// This is the full status message shown in the in-game UI.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_StatusInfo")]
    public string StatusInfo (int index)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter)),
            global::KRPC.Client.Encoder.Encode (index, typeof(int))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_StatusInfo", _args);
        return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
    }

    /// <summary>
    /// Stop the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_Stop")]
    public void Stop (int index)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter)),
            global::KRPC.Client.Encoder.Encode (index, typeof(int))
        };
        connection.Invoke ("SpaceCenter", "ResourceConverter_Stop", _args);
    }

    /// <summary>
    /// The core temperature of the converter, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_get_CoreTemperature")]
    public float CoreTemperature {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_CoreTemperature", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The number of converters in the part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_get_Count")]
    public int Count {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_Count", _args);
            return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
        }
    }

    /// <summary>
    /// The core temperature at which the converter will operate with peak efficiency, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature")]
    public float OptimumCoreTemperature {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The part object for this converter.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// The thermal efficiency of the converter, as a percentage of its maximum.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceConverter_get_ThermalEfficiency")]
    public float ThermalEfficiency {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_ThermalEfficiency", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }
}
