using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using KRPC.Client;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Alarm manager.
/// Obtained by calling <see cref="M:SpaceCenter.AlarmManager" />.
/// </summary>
public class AlarmManager : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public AlarmManager (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Create an alarm.
    /// </summary>
    /// <param name="time">Number of seconds from now that the alarm should trigger.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddAlarm")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.Alarm AddAlarm (IConnection connection, double time, string title = "Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (time, typeof(double)),
            global::KRPC.Client.Encoder.Encode (title, typeof(string)),
            global::KRPC.Client.Encoder.Encode (description, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddAlarm", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm), connection);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next apoapsis.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.Alarm AddApoapsisAlarm (IConnection connection, global::kRPC.Client.Boost.Services.SpaceCenter.Vessel vessel, double offset = 60.0, string title = "Apoapsis Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (vessel, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (offset, typeof(double)),
            global::KRPC.Client.Encoder.Encode (title, typeof(string)),
            global::KRPC.Client.Encoder.Encode (description, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm), connection);
    }

    /// <summary>
    /// Create an alarm for the given vessel and maneuver node.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="node">The maneuver node.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="addBurnTime">Whether the node's burn time should be included in the alarm.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.Alarm AddManeuverNodeAlarm (IConnection connection, global::kRPC.Client.Boost.Services.SpaceCenter.Vessel vessel, global::kRPC.Client.Boost.Services.SpaceCenter.Node node, double offset = 60.0, bool addBurnTime = true, string title = "Maneuver Node Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (vessel, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (node, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Node)),
            global::KRPC.Client.Encoder.Encode (offset, typeof(double)),
            global::KRPC.Client.Encoder.Encode (addBurnTime, typeof(bool)),
            global::KRPC.Client.Encoder.Encode (title, typeof(string)),
            global::KRPC.Client.Encoder.Encode (description, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm), connection);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next periapsis.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.Alarm AddPeriapsisAlarm (IConnection connection, global::kRPC.Client.Boost.Services.SpaceCenter.Vessel vessel, double offset = 60.0, string title = "Periapsis Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (vessel, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (offset, typeof(double)),
            global::KRPC.Client.Encoder.Encode (title, typeof(string)),
            global::KRPC.Client.Encoder.Encode (description, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm), connection);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next sphere of influence change.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddSOIAlarm")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.Alarm AddSOIAlarm (IConnection connection, global::kRPC.Client.Boost.Services.SpaceCenter.Vessel vessel, double offset = 60.0, string title = "SOI Change Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (vessel, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (offset, typeof(double)),
            global::KRPC.Client.Encoder.Encode (title, typeof(string)),
            global::KRPC.Client.Encoder.Encode (description, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddSOIAlarm", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm), connection);
    }

    /// <summary>
    /// Create an alarm linked to a vessel.
    /// </summary>
    /// <param name="time">Number of seconds from now that the alarm should trigger.</param>
    /// <param name="vessel">Vessel to link the alarm to.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddVesselAlarm")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.Alarm AddVesselAlarm (IConnection connection, double time, global::kRPC.Client.Boost.Services.SpaceCenter.Vessel vessel, string title = "Vessel Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (time, typeof(double)),
            global::KRPC.Client.Encoder.Encode (vessel, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (title, typeof(string)),
            global::KRPC.Client.Encoder.Encode (description, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddVesselAlarm", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Alarm), connection);
    }

    /// <summary>
    /// A list of all alarms.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_get_Alarms")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Alarm> Alarms {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AlarmManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_get_Alarms", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Alarm>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Alarm>), connection);
        }
    }
}
