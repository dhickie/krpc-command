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
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Badass")]
    public bool Badass {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "CrewMember_get_Badass", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Badass", _args);
        }
    }

    /// <summary>
    /// The flight IDs for each entry in the career flight log.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_CareerLogFlights")]
    public IList<int> CareerLogFlights {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<int>> ("SpaceCenter", "CrewMember_get_CareerLogFlights", _args);
        }
    }

    /// <summary>
    /// The body name for each entry in the career flight log.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_CareerLogTargets")]
    public IList<string> CareerLogTargets {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "CrewMember_get_CareerLogTargets", _args);
        }
    }

    /// <summary>
    /// The type for each entry in the career flight log.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_CareerLogTypes")]
    public IList<string> CareerLogTypes {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "CrewMember_get_CareerLogTypes", _args);
        }
    }

    /// <summary>
    /// The crew members courage.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Courage")]
    public float Courage {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "CrewMember_get_Courage", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Courage", _args);
        }
    }

    /// <summary>
    /// The crew members experience.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Experience")]
    public float Experience {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "CrewMember_get_Experience", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Experience", _args);
        }
    }

    /// <summary>
    /// The crew member's gender.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Gender")]
    public CrewMemberGender Gender {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<CrewMemberGender> ("SpaceCenter", "CrewMember_get_Gender", _args);
        }
    }

    /// <summary>
    /// The crew members name.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Name")]
    public string Name {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "CrewMember_get_Name", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Name", _args);
        }
    }

    /// <summary>
    /// Whether the crew member is on a mission.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_OnMission")]
    public bool OnMission {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "CrewMember_get_OnMission", _args);
        }
    }

    /// <summary>
    /// The crew member's current roster status.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_RosterStatus")]
    public RosterStatus RosterStatus {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<RosterStatus> ("SpaceCenter", "CrewMember_get_RosterStatus", _args);
        }
    }

    /// <summary>
    /// The crew members stupidity.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Stupidity")]
    public float Stupidity {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "CrewMember_get_Stupidity", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Stupidity", _args);
        }
    }

    /// <summary>
    /// The crew member's suit type.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_SuitType")]
    public SuitType SuitType {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<SuitType> ("SpaceCenter", "CrewMember_get_SuitType", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_SuitType", _args);
        }
    }

    /// <summary>
    /// The crew member's job.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Trait")]
    public string Trait {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "CrewMember_get_Trait", _args);
        }
    }

    /// <summary>
    /// The type of crew member.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Type")]
    public CrewMemberType Type {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<CrewMemberType> ("SpaceCenter", "CrewMember_get_Type", _args);
        }
    }

    /// <summary>
    /// Whether the crew member is a veteran.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Veteran")]
    public bool Veteran {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "CrewMember_get_Veteran", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "CrewMember_set_Veteran", _args);
        }
    }
}
