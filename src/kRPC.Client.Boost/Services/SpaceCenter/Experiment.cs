using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Obtained by calling <see cref="M:SpaceCenter.Part.Experiment" />.
/// </summary>
public class Experiment : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Experiment (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Dump the experimental data contained by the experiment.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_Dump")]
    public void Dump ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Experiment_Dump", _args);
    }

    /// <summary>
    /// Reset the experiment.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_Reset")]
    public void Reset ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Experiment_Reset", _args);
    }

    /// <summary>
    /// Run the experiment.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_Run")]
    public void Run ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Experiment_Run", _args);
    }

    /// <summary>
    /// Transmit all experimental data contained by this part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_Transmit")]
    public void Transmit ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Experiment_Transmit", _args);
    }

    /// <summary>
    /// Determines if the experiment is available given the current conditions.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_Available")]
    public bool Available {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_Available", _args);
        }
    }

    /// <summary>
    /// The name of the biome the experiment is currently in.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_Biome")]
    public string Biome {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Experiment_get_Biome", _args);
        }
    }

    /// <summary>
    /// The data contained in this experiment.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_Data")]
    public IList<ScienceData> Data {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<ScienceData>> ("SpaceCenter", "Experiment_get_Data", _args);
        }
    }

    /// <summary>
    /// Whether the experiment has been deployed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_Deployed")]
    public bool Deployed {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_Deployed", _args);
        }
    }

    /// <summary>
    /// Whether the experiment contains data.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_HasData")]
    public bool HasData {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_HasData", _args);
        }
    }

    /// <summary>
    /// Whether the experiment is inoperable.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_Inoperable")]
    public bool Inoperable {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_Inoperable", _args);
        }
    }

    /// <summary>
    /// Internal name of the experiment, as used in
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/CFG_File_Documentation">part cfg files</a>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_Name")]
    public string Name {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Experiment_get_Name", _args);
        }
    }

    /// <summary>
    /// The part object for this experiment.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Experiment_get_Part", _args);
        }
    }

    /// <summary>
    /// Whether the experiment can be re-run.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_Rerunnable")]
    public bool Rerunnable {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_Rerunnable", _args);
        }
    }

    /// <summary>
    /// Containing information on the corresponding specific science result for the current
    /// conditions. Returns <c>null</c> if the experiment is unavailable.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_ScienceSubject")]
    public ScienceSubject ScienceSubject {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ScienceSubject> ("SpaceCenter", "Experiment_get_ScienceSubject", _args);
        }
    }

    /// <summary>
    /// Title of the experiment, as shown on the in-game UI.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Experiment_get_Title")]
    public string Title {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Experiment_get_Title", _args);
        }
    }
}
