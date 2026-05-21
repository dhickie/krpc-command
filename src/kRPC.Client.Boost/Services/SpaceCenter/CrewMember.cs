using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents crew in a vessel. Can be obtained using <see cref="M:SpaceCenter.Vessel.Crew" />.
/// </summary>
public class CrewMember : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CrewMember (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the crew member is a badass.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Badass")]
    public bool GetBadass ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CrewMember_get_Badass", args);
    }

    /// <summary>
    /// Sets the Badass value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetBadass (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "CrewMember_set_Badass", args);
    }

    /// <summary>
    /// The flight IDs for each entry in the career flight log.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_CareerLogFlights")]
    public IList<int> GetCareerLogFlights ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<int>> ("SpaceCenter", "CrewMember_get_CareerLogFlights", args);
    }

    /// <summary>
    /// The body name for each entry in the career flight log.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_CareerLogTargets")]
    public IList<string> GetCareerLogTargets ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<string>> ("SpaceCenter", "CrewMember_get_CareerLogTargets", args);
    }

    /// <summary>
    /// The type for each entry in the career flight log.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_CareerLogTypes")]
    public IList<string> GetCareerLogTypes ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<string>> ("SpaceCenter", "CrewMember_get_CareerLogTypes", args);
    }

    /// <summary>
    /// The crew members courage.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Courage")]
    public float GetCourage ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "CrewMember_get_Courage", args);
    }

    /// <summary>
    /// Sets the Courage value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetCourage (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "CrewMember_set_Courage", args);
    }

    /// <summary>
    /// The crew members experience.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Experience")]
    public float GetExperience ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "CrewMember_get_Experience", args);
    }

    /// <summary>
    /// Sets the Experience value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetExperience (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "CrewMember_set_Experience", args);
    }

    /// <summary>
    /// The crew member's gender.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Gender")]
    public CrewMemberGender GetGender ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<CrewMemberGender> ("SpaceCenter", "CrewMember_get_Gender", args);
    }

    /// <summary>
    /// The crew members name.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Name")]
    public string GetName ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "CrewMember_get_Name", args);
    }

    /// <summary>
    /// Sets the Name value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetName (string value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "CrewMember_set_Name", args);
    }

    /// <summary>
    /// Whether the crew member is on a mission.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_OnMission")]
    public bool GetOnMission ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CrewMember_get_OnMission", args);
    }

    /// <summary>
    /// The crew member's current roster status.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_RosterStatus")]
    public RosterStatus GetRosterStatus ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<RosterStatus> ("SpaceCenter", "CrewMember_get_RosterStatus", args);
    }

    /// <summary>
    /// The crew members stupidity.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Stupidity")]
    public float GetStupidity ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "CrewMember_get_Stupidity", args);
    }

    /// <summary>
    /// Sets the Stupidity value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetStupidity (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "CrewMember_set_Stupidity", args);
    }

    /// <summary>
    /// The crew member's suit type.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_SuitType")]
    public SuitType GetSuitType ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<SuitType> ("SpaceCenter", "CrewMember_get_SuitType", args);
    }

    /// <summary>
    /// Sets the SuitType value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSuitType (SuitType value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "CrewMember_set_SuitType", args);
    }

    /// <summary>
    /// The crew member's job.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Trait")]
    public string GetTrait ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "CrewMember_get_Trait", args);
    }

    /// <summary>
    /// The type of crew member.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Type")]
    public CrewMemberType GetType ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<CrewMemberType> ("SpaceCenter", "CrewMember_get_Type", args);
    }

    /// <summary>
    /// Whether the crew member is a veteran.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Veteran")]
    public bool GetVeteran ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CrewMember_get_Veteran", args);
    }

    /// <summary>
    /// Sets the Veteran value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetVeteran (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "CrewMember_set_Veteran", args);
    }
}
