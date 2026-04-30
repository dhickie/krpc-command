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
    internal BaseComms Internal { get; }

    internal Comms(BaseComms comms)
    {
        Internal = comms;
    }
    public bool CanCommunicate
        => Internal.CanCommunicate;
    public bool CanTransmitScience
        => Internal.CanTransmitScience;
    public IList<CommLink> ControlPath
        => Internal.ControlPath.Select(item => new CommLink(item)).ToList();
    public double Power
        => Internal.Power;
    public double SignalDelay
        => Internal.SignalDelay;
    public double SignalStrength
        => Internal.SignalStrength;
}
