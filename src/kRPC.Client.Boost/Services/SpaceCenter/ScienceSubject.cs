using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;

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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_DataScale")]
    public float DataScale {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_DataScale", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the experiment has been completed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_IsComplete")]
    public bool IsComplete {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_IsComplete", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Amount of science already earned from this subject, not updated until after
    /// transmission/recovery.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_Science")]
    public float Science {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_Science", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Total science allowable for this subject.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_ScienceCap")]
    public float ScienceCap {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_ScienceCap", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Diminishing value multiplier for decreasing the science value returned from repeated
    /// experiments.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_ScientificValue")]
    public float ScientificValue {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_ScientificValue", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Multiplier for specific Celestial Body/Experiment Situation combination.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_SubjectValue")]
    public float SubjectValue {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_SubjectValue", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Title of science subject, displayed in science archives
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_Title")]
    public string Title {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceSubject))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_Title", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }
}
