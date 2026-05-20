using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Obtained by calling <see cref="M:SpaceCenter.Part.Experiment" />.
/// </summary>
public class Experiment : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Experiment (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Dump the experimental data contained by the experiment.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_Dump")]
    public void Dump ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
        };
        connection.Invoke ("SpaceCenter", "Experiment_Dump", _args);
    }

    /// <summary>
    /// Reset the experiment.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_Reset")]
    public void Reset ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
        };
        connection.Invoke ("SpaceCenter", "Experiment_Reset", _args);
    }

    /// <summary>
    /// Run the experiment.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_Run")]
    public void Run ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
        };
        connection.Invoke ("SpaceCenter", "Experiment_Run", _args);
    }

    /// <summary>
    /// Transmit all experimental data contained by this part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_Transmit")]
    public void Transmit ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
        };
        connection.Invoke ("SpaceCenter", "Experiment_Transmit", _args);
    }

    /// <summary>
    /// Determines if the experiment is available given the current conditions.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Available")]
    public bool Available {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Available", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The name of the biome the experiment is currently in.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Biome")]
    public string Biome {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Biome", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// The data contained in this experiment.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Data")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ScienceData> Data {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Data", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ScienceData>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ScienceData>), connection);
        }
    }

    /// <summary>
    /// Whether the experiment has been deployed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Deployed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the experiment contains data.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_HasData")]
    public bool HasData {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_HasData", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the experiment is inoperable.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Inoperable")]
    public bool Inoperable {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Inoperable", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Internal name of the experiment, as used in
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/CFG_File_Documentation">part cfg files</a>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Name")]
    public string Name {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// The part object for this experiment.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// Whether the experiment can be re-run.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Rerunnable")]
    public bool Rerunnable {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Rerunnable", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Containing information on the corresponding specific science result for the current
    /// conditions. Returns <c>null</c> if the experiment is unavailable.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_ScienceSubject")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject ScienceSubject {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_ScienceSubject", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject), connection);
        }
    }

    /// <summary>
    /// Title of the experiment, as shown on the in-game UI.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Title")]
    public string Title {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Title", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }
}