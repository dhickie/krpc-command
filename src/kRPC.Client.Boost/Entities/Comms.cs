using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseComms = KRPC.Client.Services.SpaceCenter.Comms;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Comms object.
/// </summary>
public class Comms
{
    internal readonly BaseComms Wrapped;

    internal Comms(BaseComms comms)
    {
        Wrapped = comms;
    }

    public bool CanCommunicate
        => Wrapped.CanCommunicate;

    public bool CanTransmitScience
        => Wrapped.CanTransmitScience;

    public IList<CommLink> ControlPath
        => Wrapped.ControlPath.Select(item => new CommLink(item)).ToList();

    public double Power
        => Wrapped.Power;

    public double SignalDelay
        => Wrapped.SignalDelay;

    public double SignalStrength
        => Wrapped.SignalStrength;
}
