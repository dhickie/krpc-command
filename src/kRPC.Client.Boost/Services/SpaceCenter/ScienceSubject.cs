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
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_DataScale")]
    public float DataScale {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_DataScale", args);
        }
    }

    /// <summary>
    /// Whether the experiment has been completed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_IsComplete")]
    public bool IsComplete {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ScienceSubject_get_IsComplete", args);
        }
    }

    /// <summary>
    /// Amount of science already earned from this subject, not updated until after
    /// transmission/recovery.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_Science")]
    public float Science {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_Science", args);
        }
    }

    /// <summary>
    /// Total science allowable for this subject.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_ScienceCap")]
    public float ScienceCap {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_ScienceCap", args);
        }
    }

    /// <summary>
    /// Diminishing value multiplier for decreasing the science value returned from repeated
    /// experiments.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_ScientificValue")]
    public float ScientificValue {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_ScientificValue", args);
        }
    }

    /// <summary>
    /// Multiplier for specific Celestial Body/Experiment Situation combination.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_SubjectValue")]
    public float SubjectValue {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_SubjectValue", args);
        }
    }

    /// <summary>
    /// Title of science subject, displayed in science archives
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_Title")]
    public string Title {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "ScienceSubject_get_Title", args);
        }
    }
}
