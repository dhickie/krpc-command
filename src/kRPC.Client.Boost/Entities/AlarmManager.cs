using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseAlarmManager = KRPC.Client.Services.SpaceCenter.AlarmManager;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter AlarmManager object.
/// </summary>
public class AlarmManager
{
    internal readonly BaseAlarmManager Wrapped;

    internal AlarmManager(BaseAlarmManager alarmManager)
    {
        Wrapped = alarmManager;
    }

    public IList<Alarm> Alarms
        => Wrapped.Alarms.Select(item => new Alarm(item)).ToList();

    public static Alarm AddAlarm(KrpcConnection connection, double time, string title = "Alarm", string description = "")
        => new(BaseAlarmManager.AddAlarm(connection.Connection, time, title, description));

    public static Alarm AddApoapsisAlarm(KrpcConnection connection, Vessel vessel, double offset = 60d, string title = "Apoapsis Alarm", string description = "")
        => new(BaseAlarmManager.AddApoapsisAlarm(connection.Connection, vessel.Wrapped, offset, title));

    public static Alarm AddManeuverNodeAlarm(KrpcConnection connection, Vessel vessel, Node node, double offset = 60d, bool addBurnTime = true, string title = "Maneuver Node Alarm", string description = "")
        => new(BaseAlarmManager.AddManeuverNodeAlarm(connection.Connection, vessel.Wrapped, node.Wrapped, offset, addBurnTime, title, description));

    public static Alarm AddPeriapsisAlarm(KrpcConnection connection, Vessel vessel, double offset = 60d, string title = "Periapsis Alarm", string description = "")
        => new(BaseAlarmManager.AddPeriapsisAlarm(connection.Connection, vessel.Wrapped, offset, title, description));

    public static Alarm AddSOIAlarm(KrpcConnection connection, Vessel vessel, double offset = 60d, string title = "SOI Change Alarm", string description = "")
        => new(BaseAlarmManager.AddSOIAlarm(connection.Connection, vessel.Wrapped, offset, title, description));

    public static Alarm AddVesselAlarm(KrpcConnection connection, double time, Vessel vessel, string title = "Vessel Alarm", string description = "")
        => new(BaseAlarmManager.AddVesselAlarm(connection.Connection, time, vessel.Wrapped, title, description));
}
