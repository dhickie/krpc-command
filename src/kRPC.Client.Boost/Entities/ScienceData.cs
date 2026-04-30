using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseScienceData = KRPC.Client.Services.SpaceCenter.ScienceData;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter ScienceData object.
/// </summary>
public class ScienceData
{
    internal readonly BaseScienceData Wrapped;

    internal ScienceData(BaseScienceData scienceData)
    {
        Wrapped = scienceData;
    }

    public float DataAmount
        => Wrapped.DataAmount;

    public float ScienceValue
        => Wrapped.ScienceValue;

    public float TransmitValue
        => Wrapped.TransmitValue;
}
