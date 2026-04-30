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
    internal BaseAlarm Internal { get; }

    internal Alarm(BaseAlarm alarm)
    {
        Internal = alarm;
    }
    public string Description
        => Internal.Description;
    public double EventOffset
        => Internal.EventOffset;
    public uint ID
        => Internal.ID;
    public double Time
        => Internal.Time;
    public double TimeUntil
        => Internal.TimeUntil;
    public string Title
        => Internal.Title;
    public string Type
        => Internal.Type;
    public Vessel Vessel
        => new Vessel(Internal.Vessel);
}
