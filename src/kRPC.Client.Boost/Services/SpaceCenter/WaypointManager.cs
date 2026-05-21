using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Waypoints are the location markers you can see on the map view showing you where contracts are targeted for.
/// With this structure, you can obtain coordinate data for the locations of these waypoints.
/// Obtained by calling <see cref="M:SpaceCenter.WaypointManager" />.
/// </summary>
public class WaypointManager : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public WaypointManager (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Creates a waypoint at the given position at ground level, and returns a
    /// <see cref="T:SpaceCenter.Waypoint" /> object that can be used to modify it.
    /// </summary>
    /// <param name="latitude">Latitude of the waypoint.</param>
    /// <param name="longitude">Longitude of the waypoint.</param>
    /// <param name="body">Celestial body the waypoint is attached to.</param>
    /// <param name="name">Name of the waypoint.</param>
    /// <returns></returns>
    [RpcAttribute ("SpaceCenter", "WaypointManager_AddWaypoint")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint AddWaypoint (double latitude, double longitude, global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody body, string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.WaypointManager)),
            global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (body, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_AddWaypoint", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint), connection);
    }

    /// <summary>
    /// Creates a waypoint at the given position and altitude, and returns a
    /// <see cref="T:SpaceCenter.Waypoint" /> object that can be used to modify it.
    /// </summary>
    /// <param name="latitude">Latitude of the waypoint.</param>
    /// <param name="longitude">Longitude of the waypoint.</param>
    /// <param name="altitude">Altitude (above sea level) of the waypoint.</param>
    /// <param name="body">Celestial body the waypoint is attached to.</param>
    /// <param name="name">Name of the waypoint.</param>
    /// <returns></returns>
    [RpcAttribute ("SpaceCenter", "WaypointManager_AddWaypointAtAltitude")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint AddWaypointAtAltitude (double latitude, double longitude, double altitude, global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody body, string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.WaypointManager)),
            global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (altitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (body, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_AddWaypointAtAltitude", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint), connection);
    }

    /// <summary>
    /// An example map of known color - seed pairs.
    /// Any other integers may be used as seed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "WaypointManager_get_Colors")]
    public global::System.Collections.Generic.IDictionary<string,int> Colors {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.WaypointManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_get_Colors", _args);
            return (global::System.Collections.Generic.IDictionary<string,int>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,int>), connection);
        }
    }

    /// <summary>
    /// Returns all available icons (from "GameData/Squad/Contracts/Icons/").
    /// </summary>
    [RpcAttribute ("SpaceCenter", "WaypointManager_get_Icons")]
    public global::System.Collections.Generic.IList<string> Icons {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.WaypointManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_get_Icons", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// A list of all existing waypoints.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "WaypointManager_get_Waypoints")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint> Waypoints {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.WaypointManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_get_Waypoints", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Waypoint>), connection);
        }
    }
}
