using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;
using MathNet.Spatial.Units;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Waypoints are the location markers you can see on the map view showing you where contracts are targeted for.
/// With this structure, you can obtain coordinate data for the locations of these waypoints.
/// Obtained by calling <see cref="M:SpaceCenter.GetWaypointManager" />.
/// </summary>
public class WaypointManager : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public WaypointManager(ConnectionMultiplexer connection, ulong id) : base(connection, id)
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
    [Rpc("SpaceCenter", "WaypointManager_AddWaypoint")]
    public Waypoint AddWaypoint(Angle latitude, Angle longitude, CelestialBody body, string name)
    {
        var args = new object[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            body,
            name
        };
        return Connection.Invoke<Waypoint>("SpaceCenter", "WaypointManager_AddWaypoint", args);
    }

    /// <summary>
    /// Creates a waypoint at the given position at ground level, and returns a
    /// <see cref="T:SpaceCenter.Waypoint" /> object that can be used to modify it.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="latitude">Latitude of the waypoint.</param>
    /// <param name="longitude">Longitude of the waypoint.</param>
    /// <param name="body">Celestial body the waypoint is attached to.</param>
    /// <param name="name">Name of the waypoint.</param>
    /// <returns></returns>
    [Rpc("SpaceCenter", "WaypointManager_AddWaypoint")]
    public async Task<Waypoint> AddWaypointAsync(Angle latitude, Angle longitude, CelestialBody body, string name)
    {
        var args = new object[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            body,
            name
        };
        return await Connection.InvokeAsync<Waypoint>("SpaceCenter", "WaypointManager_AddWaypoint", args);
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
    [Rpc("SpaceCenter", "WaypointManager_AddWaypointAtAltitude")]
    public Waypoint AddWaypointAtAltitude(Angle latitude, Angle longitude, double altitude, CelestialBody body, string name)
    {
        var args = new object[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            altitude,
            body,
            name
        };
        return Connection.Invoke<Waypoint>("SpaceCenter", "WaypointManager_AddWaypointAtAltitude", args);
    }

    /// <summary>
    /// Creates a waypoint at the given position and altitude, and returns a
    /// <see cref="T:SpaceCenter.Waypoint" /> object that can be used to modify it.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="latitude">Latitude of the waypoint.</param>
    /// <param name="longitude">Longitude of the waypoint.</param>
    /// <param name="altitude">Altitude (above sea level) of the waypoint.</param>
    /// <param name="body">Celestial body the waypoint is attached to.</param>
    /// <param name="name">Name of the waypoint.</param>
    /// <returns></returns>
    [Rpc("SpaceCenter", "WaypointManager_AddWaypointAtAltitude")]
    public async Task<Waypoint> AddWaypointAtAltitudeAsync(Angle latitude, Angle longitude, double altitude, CelestialBody body, string name)
    {
        var args = new object[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            altitude,
            body,
            name
        };
        return await Connection.InvokeAsync<Waypoint>("SpaceCenter", "WaypointManager_AddWaypointAtAltitude", args);
    }

    /// <summary>
    /// Gets an example map of known color - seed pairs.
    /// Any other integers may be used as seed.
    /// </summary>
    [Rpc("SpaceCenter", "WaypointManager_get_Colors")]
    public IDictionary<string,int> GetColors()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IDictionary<string,int>>("SpaceCenter", "WaypointManager_get_Colors", args);
    }

    /// <summary>
    /// Gets an example map of known color - seed pairs.
    /// Any other integers may be used as seed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "WaypointManager_get_Colors")]
    public async Task<IDictionary<string,int>> GetColorsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IDictionary<string,int>>("SpaceCenter", "WaypointManager_get_Colors", args);
    }

    /// <summary>
    /// Returns all available icons (from "GameData/Squad/Contracts/Icons/").
    /// </summary>
    [Rpc("SpaceCenter", "WaypointManager_get_Icons")]
    public IList<string> GetIcons()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "WaypointManager_get_Icons", args);
    }

    /// <summary>
    /// Returns all available icons (from "GameData/Squad/Contracts/Icons/").
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "WaypointManager_get_Icons")]
    public async Task<IList<string>> GetIconsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "WaypointManager_get_Icons", args);
    }

    /// <summary>
    /// Gets a list of all existing waypoints.
    /// </summary>
    [Rpc("SpaceCenter", "WaypointManager_get_Waypoints")]
    public IList<Waypoint> GetWaypoints()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Waypoint>>("SpaceCenter", "WaypointManager_get_Waypoints", args);
    }

    /// <summary>
    /// Gets a list of all existing waypoints.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "WaypointManager_get_Waypoints")]
    public async Task<IList<Waypoint>> GetWaypointsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Waypoint>>("SpaceCenter", "WaypointManager_get_Waypoints", args);
    }
}
