using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents crew in a vessel. Can be obtained using <see cref="M:SpaceCenter.Vessel.GetCrew" />.
/// </summary>
public class CrewMember : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CrewMember(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the crew member is a badass.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Badass")]
    public bool GetBadass()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "CrewMember_get_Badass", args);
    }

    /// <summary>
    /// Gets whether the crew member is a badass.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Badass")]
    public async Task<bool> GetBadassAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "CrewMember_get_Badass", args);
    }

    /// <summary>
    /// Sets whether the crew member is a badass.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetBadass(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "CrewMember_set_Badass", args);
    }

    /// <summary>
    /// Sets whether the crew member is a badass.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetBadassAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "CrewMember_set_Badass", args);
    }

    /// <summary>
    /// Gets the flight IDs for each entry in the career flight log.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_CareerLogFlights")]
    public IList<int> GetCareerLogFlights()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<int>>("SpaceCenter", "CrewMember_get_CareerLogFlights", args);
    }

    /// <summary>
    /// Gets the flight IDs for each entry in the career flight log.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_CareerLogFlights")]
    public async Task<IList<int>> GetCareerLogFlightsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<int>>("SpaceCenter", "CrewMember_get_CareerLogFlights", args);
    }

    /// <summary>
    /// Gets the body name for each entry in the career flight log.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_CareerLogTargets")]
    public IList<string> GetCareerLogTargets()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "CrewMember_get_CareerLogTargets", args);
    }

    /// <summary>
    /// Gets the body name for each entry in the career flight log.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_CareerLogTargets")]
    public async Task<IList<string>> GetCareerLogTargetsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "CrewMember_get_CareerLogTargets", args);
    }

    /// <summary>
    /// Gets the type for each entry in the career flight log.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_CareerLogTypes")]
    public IList<string> GetCareerLogTypes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "CrewMember_get_CareerLogTypes", args);
    }

    /// <summary>
    /// Gets the type for each entry in the career flight log.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_CareerLogTypes")]
    public async Task<IList<string>> GetCareerLogTypesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "CrewMember_get_CareerLogTypes", args);
    }

    /// <summary>
    /// Gets the crew members courage.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Courage")]
    public float GetCourage()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "CrewMember_get_Courage", args);
    }

    /// <summary>
    /// Gets the crew members courage.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Courage")]
    public async Task<float> GetCourageAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "CrewMember_get_Courage", args);
    }

    /// <summary>
    /// Sets the crew members courage.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetCourage(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "CrewMember_set_Courage", args);
    }

    /// <summary>
    /// Sets the crew members courage.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetCourageAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "CrewMember_set_Courage", args);
    }

    /// <summary>
    /// Gets the crew members experience.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Experience")]
    public float GetExperience()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "CrewMember_get_Experience", args);
    }

    /// <summary>
    /// Gets the crew members experience.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Experience")]
    public async Task<float> GetExperienceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "CrewMember_get_Experience", args);
    }

    /// <summary>
    /// Sets the crew members experience.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetExperience(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "CrewMember_set_Experience", args);
    }

    /// <summary>
    /// Sets the crew members experience.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetExperienceAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "CrewMember_set_Experience", args);
    }

    /// <summary>
    /// Gets the crew member's gender.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Gender")]
    public CrewMemberGender GetGender()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<CrewMemberGender>("SpaceCenter", "CrewMember_get_Gender", args);
    }

    /// <summary>
    /// Gets the crew member's gender.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Gender")]
    public async Task<CrewMemberGender> GetGenderAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<CrewMemberGender>("SpaceCenter", "CrewMember_get_Gender", args);
    }

    /// <summary>
    /// Gets the crew members name.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Name")]
    public string GetName()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "CrewMember_get_Name", args);
    }

    /// <summary>
    /// Gets the crew members name.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Name")]
    public async Task<string> GetNameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "CrewMember_get_Name", args);
    }

    /// <summary>
    /// Sets the crew members name.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetName(string value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "CrewMember_set_Name", args);
    }

    /// <summary>
    /// Sets the crew members name.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetNameAsync(string value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "CrewMember_set_Name", args);
    }

    /// <summary>
    /// Gets whether the crew member is on a mission.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_OnMission")]
    public bool GetOnMission()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "CrewMember_get_OnMission", args);
    }

    /// <summary>
    /// Gets whether the crew member is on a mission.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_OnMission")]
    public async Task<bool> GetOnMissionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "CrewMember_get_OnMission", args);
    }

    /// <summary>
    /// Gets the crew member's current roster status.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_RosterStatus")]
    public RosterStatus GetRosterStatus()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<RosterStatus>("SpaceCenter", "CrewMember_get_RosterStatus", args);
    }

    /// <summary>
    /// Gets the crew member's current roster status.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_RosterStatus")]
    public async Task<RosterStatus> GetRosterStatusAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<RosterStatus>("SpaceCenter", "CrewMember_get_RosterStatus", args);
    }

    /// <summary>
    /// Gets the crew members stupidity.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Stupidity")]
    public float GetStupidity()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "CrewMember_get_Stupidity", args);
    }

    /// <summary>
    /// Gets the crew members stupidity.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Stupidity")]
    public async Task<float> GetStupidityAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "CrewMember_get_Stupidity", args);
    }

    /// <summary>
    /// Sets the crew members stupidity.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetStupidity(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "CrewMember_set_Stupidity", args);
    }

    /// <summary>
    /// Sets the crew members stupidity.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetStupidityAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "CrewMember_set_Stupidity", args);
    }

    /// <summary>
    /// Gets the crew member's suit type.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_SuitType")]
    public SuitType GetSuitType()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<SuitType>("SpaceCenter", "CrewMember_get_SuitType", args);
    }

    /// <summary>
    /// Gets the crew member's suit type.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_SuitType")]
    public async Task<SuitType> GetSuitTypeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<SuitType>("SpaceCenter", "CrewMember_get_SuitType", args);
    }

    /// <summary>
    /// Sets the crew member's suit type.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSuitType(SuitType value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "CrewMember_set_SuitType", args);
    }

    /// <summary>
    /// Sets the crew member's suit type.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetSuitTypeAsync(SuitType value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "CrewMember_set_SuitType", args);
    }

    /// <summary>
    /// Gets the crew member's job.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Trait")]
    public string GetTrait()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "CrewMember_get_Trait", args);
    }

    /// <summary>
    /// Gets the crew member's job.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Trait")]
    public async Task<string> GetTraitAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "CrewMember_get_Trait", args);
    }

    /// <summary>
    /// Gets the type of crew member.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Type")]
    public CrewMemberType GetCrewMemberType()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<CrewMemberType>("SpaceCenter", "CrewMember_get_Type", args);
    }

    /// <summary>
    /// Gets the type of crew member.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Type")]
    public async Task<CrewMemberType> GetCrewMemberTypeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<CrewMemberType>("SpaceCenter", "CrewMember_get_Type", args);
    }

    /// <summary>
    /// Gets whether the crew member is a veteran.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Veteran")]
    public bool GetVeteran()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "CrewMember_get_Veteran", args);
    }

    /// <summary>
    /// Gets whether the crew member is a veteran.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CrewMember_get_Veteran")]
    public async Task<bool> GetVeteranAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "CrewMember_get_Veteran", args);
    }

    /// <summary>
    /// Sets whether the crew member is a veteran.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetVeteran(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "CrewMember_set_Veteran", args);
    }

    /// <summary>
    /// Sets whether the crew member is a veteran.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetVeteranAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "CrewMember_set_Veteran", args);
    }
}
