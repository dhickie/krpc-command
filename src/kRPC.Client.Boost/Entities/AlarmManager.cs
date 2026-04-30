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
    internal BaseAlarmManager Internal { get; }

    internal AlarmManager(BaseAlarmManager alarmManager)
    {
        Internal = alarmManager;
    }
    public IList<Alarm> Alarms
        => Internal.Alarms.Select(item => new Alarm(item)).ToList();
    public static Alarm AddAlarm(IConnection connection, double time, string title = "Alarm", string description = "")
        => new Alarm(BaseAlarmManager.AddAlarm(connection, time, title, description));
    public static Alarm AddApoapsisAlarm(IConnection connection, Vessel vessel, double offset = 60d, string title = "Apoapsis Alarm", string description = "")
        => new Alarm(BaseAlarmManager.AddApoapsisAlarm(connection, vessel.Internal, offset, title, description));
    public static Alarm AddManeuverNodeAlarm(IConnection connection, Vessel vessel, Node node, double offset = 60d, bool addBurnTime = true, string title = "Maneuver Node Alarm", string description = "")
        => new Alarm(BaseAlarmManager.AddManeuverNodeAlarm(connection, vessel.Internal, node.Internal, offset, addBurnTime, title, description));
    public static Alarm AddPeriapsisAlarm(IConnection connection, Vessel vessel, double offset = 60d, string title = "Periapsis Alarm", string description = "")
        => new Alarm(BaseAlarmManager.AddPeriapsisAlarm(connection, vessel.Internal, offset, title, description));
    public static Alarm AddSOIAlarm(IConnection connection, Vessel vessel, double offset = 60d, string title = "SOI Change Alarm", string description = "")
        => new Alarm(BaseAlarmManager.AddSOIAlarm(connection, vessel.Internal, offset, title, description));
    public static Alarm AddVesselAlarm(IConnection connection, double time, Vessel vessel, string title = "Vessel Alarm", string description = "")
        => new Alarm(BaseAlarmManager.AddVesselAlarm(connection, time, vessel.Internal, title, description));
}
