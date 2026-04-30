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
    internal BaseScienceData Internal { get; }

    internal ScienceData(BaseScienceData scienceData)
    {
        Internal = scienceData;
    }
    public float DataAmount
        => Internal.DataAmount;
    public float ScienceValue
        => Internal.ScienceValue;
    public float TransmitValue
        => Internal.TransmitValue;
}
