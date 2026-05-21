using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

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
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Badass", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "CrewMember_set_Badass", _args);
        }
    }

    /// <summary>
    /// The flight IDs for each entry in the career flight log.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_CareerLogFlights")]
    public global::System.Collections.Generic.IList<int> CareerLogFlights {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_CareerLogFlights", _args);
            return (global::System.Collections.Generic.IList<int>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<int>), connection);
        }
    }

    /// <summary>
    /// The body name for each entry in the career flight log.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_CareerLogTargets")]
    public global::System.Collections.Generic.IList<string> CareerLogTargets {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_CareerLogTargets", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// The type for each entry in the career flight log.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_CareerLogTypes")]
    public global::System.Collections.Generic.IList<string> CareerLogTypes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_CareerLogTypes", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// The crew members courage.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Courage")]
    public float Courage {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Courage", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "CrewMember_set_Courage", _args);
        }
    }

    /// <summary>
    /// The crew members experience.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Experience")]
    public float Experience {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Experience", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "CrewMember_set_Experience", _args);
        }
    }

    /// <summary>
    /// The crew member's gender.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Gender")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CrewMemberGender Gender {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Gender", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.CrewMemberGender)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMemberGender), connection);
        }
    }

    /// <summary>
    /// The crew members name.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Name")]
    public string Name {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember)),
                global::KRPC.Client.Encoder.Encode (value, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "CrewMember_set_Name", _args);
        }
    }

    /// <summary>
    /// Whether the crew member is on a mission.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_OnMission")]
    public bool OnMission {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_OnMission", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The crew member's current roster status.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_RosterStatus")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.RosterStatus RosterStatus {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_RosterStatus", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.RosterStatus)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RosterStatus), connection);
        }
    }

    /// <summary>
    /// The crew members stupidity.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Stupidity")]
    public float Stupidity {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Stupidity", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "CrewMember_set_Stupidity", _args);
        }
    }

    /// <summary>
    /// The crew member's suit type.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_SuitType")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.SuitType SuitType {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_SuitType", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.SuitType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.SuitType), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.SuitType))
            };
            connection.Invoke ("SpaceCenter", "CrewMember_set_SuitType", _args);
        }
    }

    /// <summary>
    /// The crew member's job.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Trait")]
    public string Trait {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Trait", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// The type of crew member.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Type")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CrewMemberType Type {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Type", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.CrewMemberType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMemberType), connection);
        }
    }

    /// <summary>
    /// Whether the crew member is a veteran.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CrewMember_get_Veteran")]
    public bool Veteran {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Veteran", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "CrewMember_set_Veteran", _args);
        }
    }
}
