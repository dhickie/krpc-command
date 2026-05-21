using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

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
    /// Description of the alarm.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Description")]
    public async Task<string> GetDescriptionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Alarm_get_Description", args);
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
    /// Seconds between the alarm going off and the event it references.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_EventOffset")]
    public async Task<double> GetEventOffsetAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Alarm_get_EventOffset", args);
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
    /// Unique identifier of the alarm.
    /// KSP destroys and recreates an alarm when it is edited.
    /// This id will remain constant between the old and new alarms.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_ID")]
    public async Task<uint> GetIDAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<uint>("SpaceCenter", "Alarm_get_ID", args);
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
    /// Time the alarm will trigger.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Time")]
    public async Task<double> GetTimeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Alarm_get_Time", args);
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
    /// Time until the alarm triggers.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_TimeUntil")]
    public async Task<double> GetTimeUntilAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Alarm_get_TimeUntil", args);
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
    /// Title of the alarm
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Title")]
    public async Task<string> GetTitleAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Alarm_get_Title", args);
    }

    /// <summary>
    /// Type of alarm
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Type")]
    public string GetAlarmType()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Alarm_get_Type", args);
    }

    /// <summary>
    /// Type of alarm
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Type")]
    public async Task<string> GetAlarmTypeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Alarm_get_Type", args);
    }

    /// <summary>
    /// Vessel the alarm references. <c>null</c> if it does not reference a vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Vessel")]
    public Vessel? GetVessel()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Vessel?>("SpaceCenter", "Alarm_get_Vessel", args);
    }

    /// <summary>
    /// Vessel the alarm references. <c>null</c> if it does not reference a vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Alarm_get_Vessel")]
    public async Task<Vessel?> GetVesselAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Vessel?>("SpaceCenter", "Alarm_get_Vessel", args);
    }
}
