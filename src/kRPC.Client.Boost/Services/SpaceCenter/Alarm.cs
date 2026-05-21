using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An alarm. Can be accessed using <see cref="M:SpaceCenter.GetAlarmManager" />.
/// </summary>
public class Alarm : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Alarm(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Description of the alarm.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Description")]
    public string GetDescription()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Alarm_get_Description", args);
    }

    /// <summary>
    /// Seconds between the alarm going off and the event it references.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_EventOffset")]
    public double GetEventOffset()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Alarm_get_EventOffset", args);
    }

    /// <summary>
    /// Unique identifier of the alarm.
    /// KSP destroys and recreates an alarm when it is edited.
    /// This id will remain constant between the old and new alarms.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_ID")]
    public uint GetID()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<uint>("SpaceCenter", "Alarm_get_ID", args);
    }

    /// <summary>
    /// Time the alarm will trigger.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Time")]
    public double GetTime()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Alarm_get_Time", args);
    }

    /// <summary>
    /// Time until the alarm triggers.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_TimeUntil")]
    public double GetTimeUntil()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Alarm_get_TimeUntil", args);
    }

    /// <summary>
    /// Title of the alarm
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Title")]
    public string GetTitle()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Alarm_get_Title", args);
    }

    /// <summary>
    /// Type of alarm
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Type")]
    public string GetType()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Alarm_get_Type", args);
    }

    /// <summary>
    /// Vessel the alarm references. <c>null</c> if it does not reference a vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Vessel")]
    public Vessel GetVessel()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Vessel>("SpaceCenter", "Alarm_get_Vessel", args);
    }
}
