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
    internal BaseCrewMember Internal { get; }

    internal CrewMember(BaseCrewMember crewMember)
    {
        Internal = crewMember;
    }
    public bool Badass
    {
        get => Internal.Badass;
        set => Internal.Badass = value;
    }
    public IList<int> CareerLogFlights
        => Internal.CareerLogFlights;
    public IList<string> CareerLogTargets
        => Internal.CareerLogTargets;
    public IList<string> CareerLogTypes
        => Internal.CareerLogTypes;
    public float Courage
    {
        get => Internal.Courage;
        set => Internal.Courage = value;
    }
    public float Experience
    {
        get => Internal.Experience;
        set => Internal.Experience = value;
    }
    public CrewMemberGender Gender
        => Internal.Gender;
    public string Name
    {
        get => Internal.Name;
        set => Internal.Name = value;
    }
    public bool OnMission
        => Internal.OnMission;
    public RosterStatus RosterStatus
        => Internal.RosterStatus;
    public float Stupidity
    {
        get => Internal.Stupidity;
        set => Internal.Stupidity = value;
    }
    public SuitType SuitType
    {
        get => Internal.SuitType;
        set => Internal.SuitType = value;
    }
    public string Trait
        => Internal.Trait;
    public CrewMemberType Type
        => Internal.Type;
    public bool Veteran
    {
        get => Internal.Veteran;
        set => Internal.Veteran = value;
    }
}
