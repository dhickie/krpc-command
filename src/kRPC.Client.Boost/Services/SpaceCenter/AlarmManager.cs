using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using KRPC.Client;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

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
    [Rpc ("SpaceCenter", "AlarmManager_static_AddAlarm")]
    public static Alarm AddAlarm (ConnectionMultiplexer connection, double time, string title = "Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            time,
            title,
            description
        };
        return connection.Invoke<Alarm> ("SpaceCenter", "AlarmManager_static_AddAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next apoapsis.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [Rpc ("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm")]
    public static Alarm AddApoapsisAlarm (ConnectionMultiplexer connection, Vessel vessel, double offset = 60.0, string title = "Apoapsis Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            vessel,
            offset,
            title,
            description
        };
        return connection.Invoke<Alarm> ("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm", args);
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
    [Rpc ("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm")]
    public static Alarm AddManeuverNodeAlarm (ConnectionMultiplexer connection, Vessel vessel, Node node, double offset = 60.0, bool addBurnTime = true, string title = "Maneuver Node Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            vessel,
            node,
            offset,
            addBurnTime,
            title,
            description
        };
        return connection.Invoke<Alarm> ("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next periapsis.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [Rpc ("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm")]
    public static Alarm AddPeriapsisAlarm (ConnectionMultiplexer connection, Vessel vessel, double offset = 60.0, string title = "Periapsis Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            vessel,
            offset,
            title,
            description
        };
        return connection.Invoke<Alarm> ("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next sphere of influence change.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [Rpc ("SpaceCenter", "AlarmManager_static_AddSOIAlarm")]
    public static Alarm AddSOIAlarm (ConnectionMultiplexer connection, Vessel vessel, double offset = 60.0, string title = "SOI Change Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            vessel,
            offset,
            title,
            description
        };
        return connection.Invoke<Alarm> ("SpaceCenter", "AlarmManager_static_AddSOIAlarm", args);
    }

    /// <summary>
    /// Create an alarm linked to a vessel.
    /// </summary>
    /// <param name="time">Number of seconds from now that the alarm should trigger.</param>
    /// <param name="vessel">Vessel to link the alarm to.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    /// <param name="connection">A connection object.</param>
    [Rpc ("SpaceCenter", "AlarmManager_static_AddVesselAlarm")]
    public static Alarm AddVesselAlarm (ConnectionMultiplexer connection, double time, Vessel vessel, string title = "Vessel Alarm", string description = "")
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            time,
            vessel,
            title,
            description
        };
        return connection.Invoke<Alarm> ("SpaceCenter", "AlarmManager_static_AddVesselAlarm", args);
    }

    /// <summary>
    /// A list of all alarms.
    /// </summary>
    [Rpc ("SpaceCenter", "AlarmManager_get_Alarms")]
    public IList<Alarm> Alarms {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Alarm>> ("SpaceCenter", "AlarmManager_get_Alarms", args);
        }
    }
}
