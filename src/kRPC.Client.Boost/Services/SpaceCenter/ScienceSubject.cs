using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Obtained by calling <see cref="M:SpaceCenter.Experiment.ScienceSubject" />.
/// </summary>
public class ScienceSubject : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ScienceSubject (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Multiply science value by this to determine data amount in mits.
    /// </summary>
    [Rpc ("SpaceCenter", "ScienceSubject_get_DataScale")]
    public float GetDataScale ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_DataScale", args);
    }

    /// <summary>
    /// Whether the experiment has been completed.
    /// </summary>
    [Rpc ("SpaceCenter", "ScienceSubject_get_IsComplete")]
    public bool GetIsComplete ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "ScienceSubject_get_IsComplete", args);
    }

    /// <summary>
    /// Amount of science already earned from this subject, not updated until after
    /// transmission/recovery.
    /// </summary>
    [Rpc ("SpaceCenter", "ScienceSubject_get_Science")]
    public float GetScience ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_Science", args);
    }

    /// <summary>
    /// Total science allowable for this subject.
    /// </summary>
    [Rpc ("SpaceCenter", "ScienceSubject_get_ScienceCap")]
    public float GetScienceCap ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_ScienceCap", args);
    }

    /// <summary>
    /// Diminishing value multiplier for decreasing the science value returned from repeated
    /// experiments.
    /// </summary>
    [Rpc ("SpaceCenter", "ScienceSubject_get_ScientificValue")]
    public float GetScientificValue ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_ScientificValue", args);
    }

    /// <summary>
    /// Multiplier for specific Celestial Body/Experiment Situation combination.
    /// </summary>
    [Rpc ("SpaceCenter", "ScienceSubject_get_SubjectValue")]
    public float GetSubjectValue ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_SubjectValue", args);
    }

    /// <summary>
    /// Title of science subject, displayed in science archives
    /// </summary>
    [Rpc ("SpaceCenter", "ScienceSubject_get_Title")]
    public string GetTitle ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "ScienceSubject_get_Title", args);
    }
}
