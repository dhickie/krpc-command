using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseCrewMember = KRPC.Client.Services.SpaceCenter.CrewMember;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter CrewMember object.
/// </summary>
public class CrewMember
{
    internal readonly BaseCrewMember Wrapped;

    internal CrewMember(BaseCrewMember crewMember)
    {
        Wrapped = crewMember;
    }

    public bool Badass
    {
        get => Wrapped.Badass;
        set => Wrapped.Badass = value;
    }

    public IList<int> CareerLogFlights
        => Wrapped.CareerLogFlights;

    public IList<string> CareerLogTargets
        => Wrapped.CareerLogTargets;

    public IList<string> CareerLogTypes
        => Wrapped.CareerLogTypes;

    public float Courage
    {
        get => Wrapped.Courage;
        set => Wrapped.Courage = value;
    }

    public float Experience
    {
        get => Wrapped.Experience;
        set => Wrapped.Experience = value;
    }

    public CrewMemberGender Gender
        => Wrapped.Gender;

    public string Name
    {
        get => Wrapped.Name;
        set => Wrapped.Name = value;
    }

    public bool OnMission
        => Wrapped.OnMission;

    public RosterStatus RosterStatus
        => Wrapped.RosterStatus;

    public float Stupidity
    {
        get => Wrapped.Stupidity;
        set => Wrapped.Stupidity = value;
    }

    public SuitType SuitType
    {
        get => Wrapped.SuitType;
        set => Wrapped.SuitType = value;
    }

    public string Trait
        => Wrapped.Trait;

    public CrewMemberType Type
        => Wrapped.Type;

    public bool Veteran
    {
        get => Wrapped.Veteran;
        set => Wrapped.Veteran = value;
    }
}
