using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseReferenceFrame = KRPC.Client.Services.SpaceCenter.ReferenceFrame;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter ReferenceFrame object.
/// </summary>
public class ReferenceFrame
{
    internal readonly BaseReferenceFrame Wrapped;

    internal ReferenceFrame(BaseReferenceFrame referenceFrame)
    {
        Wrapped = referenceFrame;
    }

    public static ReferenceFrame CreateHybrid(IConnection connection, ReferenceFrame position, ReferenceFrame rotation = null, ReferenceFrame velocity = null, ReferenceFrame angularVelocity = null)
        => new ReferenceFrame(BaseReferenceFrame.CreateHybrid(connection, position.Wrapped, rotation?.Wrapped, velocity?.Wrapped, angularVelocity?.Wrapped));

    public static ReferenceFrame CreateRelative(IConnection connection, ReferenceFrame referenceFrame, Tuple<double, double, double> position = null, Tuple<double, double, double, double> rotation = null, Tuple<double, double, double> velocity = null, Tuple<double, double, double> angularVelocity = null)
        => new ReferenceFrame(BaseReferenceFrame.CreateRelative(connection, referenceFrame.Wrapped, position, rotation, velocity, angularVelocity));
}
