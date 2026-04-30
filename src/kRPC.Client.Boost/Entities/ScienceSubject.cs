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
    internal readonly BaseScienceSubject Wrapped;

    internal ScienceSubject(BaseScienceSubject scienceSubject)
    {
        Wrapped = scienceSubject;
    }

    public float DataScale
        => Wrapped.DataScale;

    public bool IsComplete
        => Wrapped.IsComplete;

    public float Science
        => Wrapped.Science;

    public float ScienceCap
        => Wrapped.ScienceCap;

    public float ScientificValue
        => Wrapped.ScientificValue;

    public float SubjectValue
        => Wrapped.SubjectValue;

    public string Title
        => Wrapped.Title;
}
