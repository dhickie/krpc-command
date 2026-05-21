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
    public bool Badass {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "CrewMember_get_Badass", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Badass", args);
        }
    }

    /// <summary>
    /// The flight IDs for each entry in the career flight log.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_CareerLogFlights")]
    public IList<int> CareerLogFlights {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<int>> ("SpaceCenter", "CrewMember_get_CareerLogFlights", args);
        }
    }

    /// <summary>
    /// The body name for each entry in the career flight log.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_CareerLogTargets")]
    public IList<string> CareerLogTargets {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "CrewMember_get_CareerLogTargets", args);
        }
    }

    /// <summary>
    /// The type for each entry in the career flight log.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_CareerLogTypes")]
    public IList<string> CareerLogTypes {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "CrewMember_get_CareerLogTypes", args);
        }
    }

    /// <summary>
    /// The crew members courage.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Courage")]
    public float Courage {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "CrewMember_get_Courage", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Courage", args);
        }
    }

    /// <summary>
    /// The crew members experience.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Experience")]
    public float Experience {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "CrewMember_get_Experience", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Experience", args);
        }
    }

    /// <summary>
    /// The crew member's gender.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Gender")]
    public CrewMemberGender Gender {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<CrewMemberGender> ("SpaceCenter", "CrewMember_get_Gender", args);
        }
    }

    /// <summary>
    /// The crew members name.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Name")]
    public string Name {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "CrewMember_get_Name", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Name", args);
        }
    }

    /// <summary>
    /// Whether the crew member is on a mission.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_OnMission")]
    public bool OnMission {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "CrewMember_get_OnMission", args);
        }
    }

    /// <summary>
    /// The crew member's current roster status.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_RosterStatus")]
    public RosterStatus RosterStatus {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<RosterStatus> ("SpaceCenter", "CrewMember_get_RosterStatus", args);
        }
    }

    /// <summary>
    /// The crew members stupidity.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Stupidity")]
    public float Stupidity {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "CrewMember_get_Stupidity", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Stupidity", args);
        }
    }

    /// <summary>
    /// The crew member's suit type.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_SuitType")]
    public SuitType SuitType {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<SuitType> ("SpaceCenter", "CrewMember_get_SuitType", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_SuitType", args);
        }
    }

    /// <summary>
    /// The crew member's job.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Trait")]
    public string Trait {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "CrewMember_get_Trait", args);
        }
    }

    /// <summary>
    /// The type of crew member.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Type")]
    public CrewMemberType Type {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<CrewMemberType> ("SpaceCenter", "CrewMember_get_Type", args);
        }
    }

    /// <summary>
    /// Whether the crew member is a veteran.
    /// </summary>
    [Rpc ("SpaceCenter", "CrewMember_get_Veteran")]
    public bool Veteran {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "CrewMember_get_Veteran", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Veteran", args);
        }
    }
}
