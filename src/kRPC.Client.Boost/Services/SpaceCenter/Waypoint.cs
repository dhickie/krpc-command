using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a waypoint. Can be created using <see cref="M:SpaceCenter.WaypointManager.AddWaypoint" />.
/// </summary>
public class Waypoint : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Waypoint (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Removes the waypoint.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_Remove")]
    public void Remove ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
        };
        connection.Invoke ("SpaceCenter", "Waypoint_Remove", _args);
    }

    /// <summary>
    /// The altitude of the waypoint above the surface of the body, in meters.
    /// When over water, this is the altitude above the sea floor.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_BedrockAltitude")]
    public double BedrockAltitude {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_BedrockAltitude", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_set_BedrockAltitude", _args);
        }
    }

    /// <summary>
    /// The celestial body the waypoint is attached to.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Body")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody Body {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Body", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_set_Body", _args);
        }
    }

    /// <summary><c>true</c> if this waypoint is part of a set of clustered waypoints with greek letter
    /// names appended (Alpha, Beta, Gamma, etc).
    /// If <c>true</c>, there is a one-to-one correspondence with the greek letter name and
    /// the <see cref="M:SpaceCenter.Waypoint.Index" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Clustered")]
    public bool Clustered {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Clustered", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The seed of the icon color. See <see cref="M:SpaceCenter.WaypointManager.Colors" /> for example colors.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Color")]
    public int Color {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Color", _args);
            return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)),
                global::KRPC.Client.Encoder.Encode (value, typeof(int))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_set_Color", _args);
        }
    }

    /// <summary>
    /// The associated contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Contract")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Contract Contract {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Contract", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Contract)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract), connection);
        }
    }

    /// <summary><c>true</c> if the waypoint is attached to the ground.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Grounded")]
    public bool Grounded {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Grounded", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the waypoint belongs to a contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_HasContract")]
    public bool HasContract {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_HasContract", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The icon of the waypoint.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Icon")]
    public string Icon {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Icon", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)),
                global::KRPC.Client.Encoder.Encode (value, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_set_Icon", _args);
        }
    }

    /// <summary>
    /// The integer index of this waypoint within its cluster of sibling waypoints.
    /// In other words, when you have a cluster of waypoints called "Somewhere Alpha",
    /// "Somewhere Beta" and "Somewhere Gamma", the alpha site has index 0, the beta
    /// site has index 1 and the gamma site has index 2.
    /// When <see cref="M:SpaceCenter.Waypoint.Clustered" /> is <c>false</c>, this is zero.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Index")]
    public int Index {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Index", _args);
            return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
        }
    }

    /// <summary>
    /// The latitude of the waypoint.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Latitude")]
    public double Latitude {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Latitude", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_set_Latitude", _args);
        }
    }

    /// <summary>
    /// The longitude of the waypoint.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Longitude")]
    public double Longitude {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Longitude", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_set_Longitude", _args);
        }
    }

    /// <summary>
    /// The altitude of the waypoint above sea level, in meters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_MeanAltitude")]
    public double MeanAltitude {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_MeanAltitude", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_set_MeanAltitude", _args);
        }
    }

    /// <summary>
    /// The name of the waypoint as it appears on the map and the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Name")]
    public string Name {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)),
                global::KRPC.Client.Encoder.Encode (value, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_set_Name", _args);
        }
    }

    /// <summary><c>true</c> if the waypoint is near to the surface of a body.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_NearSurface")]
    public bool NearSurface {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_NearSurface", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The altitude of the waypoint above the surface of the body or sea level,
    /// whichever is closer, in meters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_SurfaceAltitude")]
    public double SurfaceAltitude {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_SurfaceAltitude", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)),
                global::KRPC.Client.Encoder.Encode (value, typeof(double))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_set_SurfaceAltitude", _args);
        }
    }
}
