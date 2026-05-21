using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using KRPC.Client;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Alarm manager.
/// Obtained by calling <see cref="M:SpaceCenter.GetAlarmManager" />.
/// </summary>
public class AlarmManager : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public AlarmManager(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Create an alarm.
    /// </summary>
    /// <param name="time">Number of seconds from now that the alarm should trigger.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddAlarm")]
    public Alarm AddAlarm(double time, string title = "Alarm", string description = "")
    {
        var args = new object[]
        {
            time,
            title,
            description
        };
        return Connection.Invoke<Alarm>("SpaceCenter", "AlarmManager_static_AddAlarm", args);
    }

    /// <summary>
    /// Create an alarm.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="time">Number of seconds from now that the alarm should trigger.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddAlarm")]
    public async Task<Alarm> AddAlarmAsync(double time, string title = "Alarm", string description = "")
    {
        var args = new object[]
        {
            time,
            title,
            description
        };
        return await Connection.InvokeAsync<Alarm>("SpaceCenter", "AlarmManager_static_AddAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next apoapsis.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm")]
    public Alarm AddApoapsisAlarm(Vessel vessel, double offset = 60.0, string title = "Apoapsis Alarm", string description = "")
    {
        var args = new object[]
        {
            vessel,
            offset,
            title,
            description
        };
        return Connection.Invoke<Alarm>("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next apoapsis.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm")]
    public async Task<Alarm> AddApoapsisAlarmAsync(Vessel vessel, double offset = 60.0, string title = "Apoapsis Alarm", string description = "")
    {
        var args = new object[]
        {
            vessel,
            offset,
            title,
            description
        };
        return await Connection.InvokeAsync<Alarm>("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm", args);
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
    [Rpc("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm")]
    public Alarm AddManeuverNodeAlarm(Vessel vessel, Node node, double offset = 60.0, bool addBurnTime = true, string title = "Maneuver Node Alarm", string description = "")
    {
        var args = new object[]
        {
            vessel,
            node,
            offset,
            addBurnTime,
            title,
            description
        };
        return Connection.Invoke<Alarm>("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel and maneuver node.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="node">The maneuver node.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="addBurnTime">Whether the node's burn time should be included in the alarm.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm")]
    public async Task<Alarm> AddManeuverNodeAlarmAsync(Vessel vessel, Node node, double offset = 60.0, bool addBurnTime = true, string title = "Maneuver Node Alarm", string description = "")
    {
        var args = new object[]
        {
            vessel,
            node,
            offset,
            addBurnTime,
            title,
            description
        };
        return await Connection.InvokeAsync<Alarm>("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next periapsis.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm")]
    public Alarm AddPeriapsisAlarm(Vessel vessel, double offset = 60.0, string title = "Periapsis Alarm", string description = "")
    {
        var args = new object[]
        {
            vessel,
            offset,
            title,
            description
        };
        return Connection.Invoke<Alarm>("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next periapsis.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm")]
    public async Task<Alarm> AddPeriapsisAlarmAsync(Vessel vessel, double offset = 60.0, string title = "Periapsis Alarm", string description = "")
    {
        var args = new object[]
        {
            vessel,
            offset,
            title,
            description
        };
        return await Connection.InvokeAsync<Alarm>("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next sphere of influence change.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddSOIAlarm")]
    public Alarm AddSOIAlarm(Vessel vessel, double offset = 60.0, string title = "SOI Change Alarm", string description = "")
    {
        var args = new object[]
        {
            vessel,
            offset,
            title,
            description
        };
        return Connection.Invoke<Alarm>("SpaceCenter", "AlarmManager_static_AddSOIAlarm", args);
    }

    /// <summary>
    /// Create an alarm for the given vessel's next sphere of influence change.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="vessel">The vessel.</param>
    /// <param name="offset">Time in seconds to offset the alarm by.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddSOIAlarm")]
    public async Task<Alarm> AddSOIAlarmAsync(Vessel vessel, double offset = 60.0, string title = "SOI Change Alarm", string description = "")
    {
        var args = new object[]
        {
            vessel,
            offset,
            title,
            description
        };
        return await Connection.InvokeAsync<Alarm>("SpaceCenter", "AlarmManager_static_AddSOIAlarm", args);
    }

    /// <summary>
    /// Create an alarm linked to a vessel.
    /// </summary>
    /// <param name="time">Number of seconds from now that the alarm should trigger.</param>
    /// <param name="vessel">Vessel to link the alarm to.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddVesselAlarm")]
    public Alarm AddVesselAlarm(double time, Vessel vessel, string title = "Vessel Alarm", string description = "")
    {
        var args = new object[]
        {
            time,
            vessel,
            title,
            description
        };
        return Connection.Invoke<Alarm>("SpaceCenter", "AlarmManager_static_AddVesselAlarm", args);
    }

    /// <summary>
    /// Create an alarm linked to a vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="time">Number of seconds from now that the alarm should trigger.</param>
    /// <param name="vessel">Vessel to link the alarm to.</param>
    /// <param name="title">Title for the alarm.</param>
    /// <param name="description">Description for the alarm.</param>
    [Rpc("SpaceCenter", "AlarmManager_static_AddVesselAlarm")]
    public async Task<Alarm> AddVesselAlarmAsync(double time, Vessel vessel, string title = "Vessel Alarm", string description = "")
    {
        var args = new object[]
        {
            time,
            vessel,
            title,
            description
        };
        return await Connection.InvokeAsync<Alarm>("SpaceCenter", "AlarmManager_static_AddVesselAlarm", args);
    }

    /// <summary>
    /// Gets a list of all alarms.
    /// </summary>
    [Rpc("SpaceCenter", "AlarmManager_get_Alarms")]
    public IList<Alarm> GetAlarms()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Alarm>>("SpaceCenter", "AlarmManager_get_Alarms", args);
    }

    /// <summary>
    /// Gets a list of all alarms.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AlarmManager_get_Alarms")]
    public async Task<IList<Alarm>> GetAlarmsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Alarm>>("SpaceCenter", "AlarmManager_get_Alarms", args);
    }
}
