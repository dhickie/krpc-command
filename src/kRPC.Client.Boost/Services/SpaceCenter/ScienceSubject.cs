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
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_DataScale", _args);
        }
    }

    /// <summary>
    /// Whether the experiment has been completed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_IsComplete")]
    public bool IsComplete {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ScienceSubject_get_IsComplete", _args);
        }
    }

    /// <summary>
    /// Amount of science already earned from this subject, not updated until after
    /// transmission/recovery.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_Science")]
    public float Science {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_Science", _args);
        }
    }

    /// <summary>
    /// Total science allowable for this subject.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_ScienceCap")]
    public float ScienceCap {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_ScienceCap", _args);
        }
    }

    /// <summary>
    /// Diminishing value multiplier for decreasing the science value returned from repeated
    /// experiments.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_ScientificValue")]
    public float ScientificValue {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_ScientificValue", _args);
        }
    }

    /// <summary>
    /// Multiplier for specific Celestial Body/Experiment Situation combination.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_SubjectValue")]
    public float SubjectValue {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ScienceSubject_get_SubjectValue", _args);
        }
    }

    /// <summary>
    /// Title of science subject, displayed in science archives
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceSubject_get_Title")]
    public string Title {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "ScienceSubject_get_Title", _args);
        }
    }
}
