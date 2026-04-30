using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseAlarm = KRPC.Client.Services.SpaceCenter.Alarm;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Alarm object.
/// </summary>
public class Alarm
{
    internal readonly BaseAlarm Wrapped;

    internal Alarm(BaseAlarm alarm)
    {
        Wrapped = alarm;
    }

    public string Description
        => Wrapped.Description;

    public double EventOffset
        => Wrapped.EventOffset;

    public uint ID
        => Wrapped.ID;

    public double Time
        => Wrapped.Time;

    public double TimeUntil
        => Wrapped.TimeUntil;

    public string Title
        => Wrapped.Title;

    public string Type
        => Wrapped.Type;

    public Vessel Vessel
        => new Vessel(Wrapped.Vessel);
}
