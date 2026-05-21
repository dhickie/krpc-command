using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An alarm. Can be accessed using <see cref="M:SpaceCenter.AlarmManager" />.
/// </summary>
public class Alarm : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Alarm (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Description of the alarm.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Alarm_get_Description")]
    public string Description {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Description", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// Seconds between the alarm going off and the event it references.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Alarm_get_EventOffset")]
    public double EventOffset {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_EventOffset", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Unique identifier of the alarm.
    /// KSP destroys and recreates an alarm when it is edited.
    /// This id will remain constant between the old and new alarms.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Alarm_get_ID")]
    public uint ID {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_ID", _args);
            return (uint)global::KRPC.Client.Encoder.Decode (_data, typeof(uint), connection);
        }
    }

    /// <summary>
    /// Time the alarm will trigger.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Alarm_get_Time")]
    public double Time {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Time", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Time until the alarm triggers.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Alarm_get_TimeUntil")]
    public double TimeUntil {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_TimeUntil", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Title of the alarm
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Alarm_get_Title")]
    public string Title {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Title", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// Type of alarm
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Alarm_get_Type")]
    public string Type {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Type", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// Vessel the alarm references. <c>null</c> if it does not reference a vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Alarm_get_Vessel")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Vessel Vessel {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Vessel", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel), connection);
        }
    }
}
