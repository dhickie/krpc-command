using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

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
    [RpcAttribute ("SpaceCenter", "Waypoint_Remove")]
    public void Remove ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Waypoint_Remove", args);
    }

    /// <summary>
    /// The altitude of the waypoint above the surface of the body, in meters.
    /// When over water, this is the altitude above the sea floor.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_BedrockAltitude")]
    public double BedrockAltitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Waypoint_get_BedrockAltitude", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Waypoint_set_BedrockAltitude", args);
        }
    }

    /// <summary>
    /// The celestial body the waypoint is attached to.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Body")]
    public CelestialBody Body {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<CelestialBody> ("SpaceCenter", "Waypoint_get_Body", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Waypoint_set_Body", args);
        }
    }

    /// <summary><c>true</c> if this waypoint is part of a set of clustered waypoints with greek letter
    /// names appended (Alpha, Beta, Gamma, etc).
    /// If <c>true</c>, there is a one-to-one correspondence with the greek letter name and
    /// the <see cref="M:SpaceCenter.Waypoint.Index" />.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Clustered")]
    public bool Clustered {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Waypoint_get_Clustered", args);
        }
    }

    /// <summary>
    /// The seed of the icon color. See <see cref="M:SpaceCenter.WaypointManager.Colors" /> for example colors.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Color")]
    public int Color {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<int> ("SpaceCenter", "Waypoint_get_Color", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Waypoint_set_Color", args);
        }
    }

    /// <summary>
    /// The associated contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Contract")]
    public Contract Contract {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Contract> ("SpaceCenter", "Waypoint_get_Contract", args);
        }
    }

    /// <summary><c>true</c> if the waypoint is attached to the ground.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Grounded")]
    public bool Grounded {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Waypoint_get_Grounded", args);
        }
    }

    /// <summary>
    /// Whether the waypoint belongs to a contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_HasContract")]
    public bool HasContract {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Waypoint_get_HasContract", args);
        }
    }

    /// <summary>
    /// The icon of the waypoint.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Icon")]
    public string Icon {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Waypoint_get_Icon", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Waypoint_set_Icon", args);
        }
    }

    /// <summary>
    /// The integer index of this waypoint within its cluster of sibling waypoints.
    /// In other words, when you have a cluster of waypoints called "Somewhere Alpha",
    /// "Somewhere Beta" and "Somewhere Gamma", the alpha site has index 0, the beta
    /// site has index 1 and the gamma site has index 2.
    /// When <see cref="M:SpaceCenter.Waypoint.Clustered" /> is <c>false</c>, this is zero.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Index")]
    public int Index {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<int> ("SpaceCenter", "Waypoint_get_Index", args);
        }
    }

    /// <summary>
    /// The latitude of the waypoint.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Latitude")]
    public double Latitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Waypoint_get_Latitude", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Waypoint_set_Latitude", args);
        }
    }

    /// <summary>
    /// The longitude of the waypoint.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Longitude")]
    public double Longitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Waypoint_get_Longitude", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Waypoint_set_Longitude", args);
        }
    }

    /// <summary>
    /// The altitude of the waypoint above sea level, in meters.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_MeanAltitude")]
    public double MeanAltitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Waypoint_get_MeanAltitude", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Waypoint_set_MeanAltitude", args);
        }
    }

    /// <summary>
    /// The name of the waypoint as it appears on the map and the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_Name")]
    public string Name {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Waypoint_get_Name", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Waypoint_set_Name", args);
        }
    }

    /// <summary><c>true</c> if the waypoint is near to the surface of a body.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_NearSurface")]
    public bool NearSurface {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Waypoint_get_NearSurface", args);
        }
    }

    /// <summary>
    /// The altitude of the waypoint above the surface of the body or sea level,
    /// whichever is closer, in meters.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Waypoint_get_SurfaceAltitude")]
    public double SurfaceAltitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Waypoint_get_SurfaceAltitude", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Waypoint_set_SurfaceAltitude", args);
        }
    }
}
