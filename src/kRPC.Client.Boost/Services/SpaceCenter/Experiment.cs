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
    [Rpc ("SpaceCenter", "Experiment_Dump")]
    public void Dump ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Experiment_Dump", args);
    }

    /// <summary>
    /// Reset the experiment.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_Reset")]
    public void Reset ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Experiment_Reset", args);
    }

    /// <summary>
    /// Run the experiment.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_Run")]
    public void Run ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Experiment_Run", args);
    }

    /// <summary>
    /// Transmit all experimental data contained by this part.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_Transmit")]
    public void Transmit ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Experiment_Transmit", args);
    }

    /// <summary>
    /// Determines if the experiment is available given the current conditions.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_Available")]
    public bool GetAvailable ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_Available", args);
    }

    /// <summary>
    /// The name of the biome the experiment is currently in.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_Biome")]
    public string GetBiome ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "Experiment_get_Biome", args);
    }

    /// <summary>
    /// The data contained in this experiment.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_Data")]
    public IList<ScienceData> GetData ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<ScienceData>> ("SpaceCenter", "Experiment_get_Data", args);
    }

    /// <summary>
    /// Whether the experiment has been deployed.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_Deployed")]
    public bool GetDeployed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_Deployed", args);
    }

    /// <summary>
    /// Whether the experiment contains data.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_HasData")]
    public bool GetHasData ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_HasData", args);
    }

    /// <summary>
    /// Whether the experiment is inoperable.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_Inoperable")]
    public bool GetInoperable ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_Inoperable", args);
    }

    /// <summary>
    /// Internal name of the experiment, as used in
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/CFG_File_Documentation">part cfg files</a>.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_Name")]
    public string GetName ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "Experiment_get_Name", args);
    }

    /// <summary>
    /// The part object for this experiment.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_Part")]
    public Part GetPart ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Part> ("SpaceCenter", "Experiment_get_Part", args);
    }

    /// <summary>
    /// Whether the experiment can be re-run.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_Rerunnable")]
    public bool GetRerunnable ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Experiment_get_Rerunnable", args);
    }

    /// <summary>
    /// Containing information on the corresponding specific science result for the current
    /// conditions. Returns <c>null</c> if the experiment is unavailable.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_ScienceSubject")]
    public ScienceSubject GetScienceSubject ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ScienceSubject> ("SpaceCenter", "Experiment_get_ScienceSubject", args);
    }

    /// <summary>
    /// Title of the experiment, as shown on the in-game UI.
    /// </summary>
    [Rpc ("SpaceCenter", "Experiment_get_Title")]
    public string GetTitle ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "Experiment_get_Title", args);
    }
}
