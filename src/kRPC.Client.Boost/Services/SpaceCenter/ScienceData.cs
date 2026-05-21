using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Obtained by calling <see cref="M:SpaceCenter.Experiment.Data" />.
/// </summary>
public class ScienceData : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ScienceData (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Data amount.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceData_get_DataAmount")]
    public float DataAmount {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceData))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceData_get_DataAmount", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Science value.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceData_get_ScienceValue")]
    public float ScienceValue {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceData))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceData_get_ScienceValue", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Transmit value.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ScienceData_get_TransmitValue")]
    public float TransmitValue {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ScienceData))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ScienceData_get_TransmitValue", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }
}
