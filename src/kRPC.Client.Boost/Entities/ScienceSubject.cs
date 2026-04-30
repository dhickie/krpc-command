using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseScienceSubject = KRPC.Client.Services.SpaceCenter.ScienceSubject;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter ScienceSubject object.
/// </summary>
public class ScienceSubject
{
    internal BaseScienceSubject Internal { get; }

    internal ScienceSubject(BaseScienceSubject scienceSubject)
    {
        Internal = scienceSubject;
    }
    public float DataScale
        => Internal.DataScale;
    public bool IsComplete
        => Internal.IsComplete;
    public float Science
        => Internal.Science;
    public float ScienceCap
        => Internal.ScienceCap;
    public float ScientificValue
        => Internal.ScientificValue;
    public float SubjectValue
        => Internal.SubjectValue;
    public string Title
        => Internal.Title;
}
