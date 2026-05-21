using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a waypoint. Can be created using <see cref="M:SpaceCenter.WaypointManager.AddWaypoint" />.
/// </summary>
public class Waypoint : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Waypoint(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Removes the waypoint.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_Remove")]
    public void Remove()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Waypoint_Remove", args);
    }

    /// <summary>
    /// Removes the waypoint.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_Remove")]
    public async Task RemoveAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_Remove", args);
    }

    /// <summary>
    /// Gets the altitude of the waypoint above the surface of the body, in meters.
    /// When over water, this is the altitude above the sea floor.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_BedrockAltitude")]
    public double GetBedrockAltitude()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Waypoint_get_BedrockAltitude", args);
    }

    /// <summary>
    /// Gets the altitude of the waypoint above the surface of the body, in meters.
    /// When over water, this is the altitude above the sea floor.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_BedrockAltitude")]
    public async Task<double> GetBedrockAltitudeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Waypoint_get_BedrockAltitude", args);
    }

    /// <summary>
    /// Sets the altitude of the waypoint above the surface of the body, in meters.
    /// When over water, this is the altitude above the sea floor.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetBedrockAltitude(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Waypoint_set_BedrockAltitude", args);
    }

    /// <summary>
    /// Sets the altitude of the waypoint above the surface of the body, in meters.
    /// When over water, this is the altitude above the sea floor.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetBedrockAltitudeAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_set_BedrockAltitude", args);
    }

    /// <summary>
    /// Gets the celestial body the waypoint is attached to.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Body")]
    public CelestialBody GetBody()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<CelestialBody>("SpaceCenter", "Waypoint_get_Body", args);
    }

    /// <summary>
    /// Gets the celestial body the waypoint is attached to.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Body")]
    public async Task<CelestialBody> GetBodyAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<CelestialBody>("SpaceCenter", "Waypoint_get_Body", args);
    }

    /// <summary>
    /// Sets the celestial body the waypoint is attached to.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetBody(CelestialBody value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Waypoint_set_Body", args);
    }

    /// <summary>
    /// Sets the celestial body the waypoint is attached to.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetBodyAsync(CelestialBody value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_set_Body", args);
    }

    /// <summary>
    /// Returns <c>true</c> if this waypoint is part of a set of clustered waypoints with greek letter
    /// names appended (Alpha, Beta, Gamma, etc).
    /// If <c>true</c>, there is a one-to-one correspondence with the greek letter name and
    /// the <see cref="M:SpaceCenter.Waypoint.GetIndex" />.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Clustered")]
    public bool GetClustered()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Waypoint_get_Clustered", args);
    }

    /// <summary>
    /// Returns <c>true</c> if this waypoint is part of a set of clustered waypoints with greek letter
    /// names appended (Alpha, Beta, Gamma, etc).
    /// If <c>true</c>, there is a one-to-one correspondence with the greek letter name and
    /// the <see cref="M:SpaceCenter.Waypoint.GetIndex" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Clustered")]
    public async Task<bool> GetClusteredAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Waypoint_get_Clustered", args);
    }

    /// <summary>
    /// Gets the seed of the icon color. See <see cref="M:SpaceCenter.WaypointManager.GetColors" /> for example colors.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Color")]
    public int GetColor()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<int>("SpaceCenter", "Waypoint_get_Color", args);
    }

    /// <summary>
    /// Gets the seed of the icon color. See <see cref="M:SpaceCenter.WaypointManager.GetColors" /> for example colors.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Color")]
    public async Task<int> GetColorAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<int>("SpaceCenter", "Waypoint_get_Color", args);
    }

    /// <summary>
    /// Sets the seed of the icon color. See <see cref="M:SpaceCenter.WaypointManager.GetColors" /> for example colors.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetColor(int value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Waypoint_set_Color", args);
    }

    /// <summary>
    /// Sets the seed of the icon color. See <see cref="M:SpaceCenter.WaypointManager.GetColors" /> for example colors.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetColorAsync(int value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_set_Color", args);
    }

    /// <summary>
    /// Gets the associated contract.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Contract")]
    public Contract GetContract()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Contract>("SpaceCenter", "Waypoint_get_Contract", args);
    }

    /// <summary>
    /// Gets the associated contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Contract")]
    public async Task<Contract> GetContractAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Contract>("SpaceCenter", "Waypoint_get_Contract", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the waypoint is attached to the ground.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Grounded")]
    public bool GetGrounded()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Waypoint_get_Grounded", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the waypoint is attached to the ground.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Grounded")]
    public async Task<bool> GetGroundedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Waypoint_get_Grounded", args);
    }

    /// <summary>
    /// Gets whether the waypoint belongs to a contract.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_HasContract")]
    public bool GetHasContract()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Waypoint_get_HasContract", args);
    }

    /// <summary>
    /// Gets whether the waypoint belongs to a contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_HasContract")]
    public async Task<bool> GetHasContractAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Waypoint_get_HasContract", args);
    }

    /// <summary>
    /// Gets the icon of the waypoint.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Icon")]
    public string GetIcon()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Waypoint_get_Icon", args);
    }

    /// <summary>
    /// Gets the icon of the waypoint.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Icon")]
    public async Task<string> GetIconAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Waypoint_get_Icon", args);
    }

    /// <summary>
    /// Sets the icon of the waypoint.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetIcon(string value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Waypoint_set_Icon", args);
    }

    /// <summary>
    /// Sets the icon of the waypoint.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetIconAsync(string value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_set_Icon", args);
    }

    /// <summary>
    /// Gets the integer index of this waypoint within its cluster of sibling waypoints.
    /// In other words, when you have a cluster of waypoints called "Somewhere Alpha",
    /// "Somewhere Beta" and "Somewhere Gamma", the alpha site has index 0, the beta
    /// site has index 1 and the gamma site has index 2.
    /// When <see cref="M:SpaceCenter.Waypoint.GetClustered" /> is <c>false</c>, this is zero.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Index")]
    public int GetIndex()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<int>("SpaceCenter", "Waypoint_get_Index", args);
    }

    /// <summary>
    /// Gets the integer index of this waypoint within its cluster of sibling waypoints.
    /// In other words, when you have a cluster of waypoints called "Somewhere Alpha",
    /// "Somewhere Beta" and "Somewhere Gamma", the alpha site has index 0, the beta
    /// site has index 1 and the gamma site has index 2.
    /// When <see cref="M:SpaceCenter.Waypoint.GetClustered" /> is <c>false</c>, this is zero.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Index")]
    public async Task<int> GetIndexAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<int>("SpaceCenter", "Waypoint_get_Index", args);
    }

    /// <summary>
    /// Gets the latitude of the waypoint.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Latitude")]
    public double GetLatitude()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Waypoint_get_Latitude", args);
    }

    /// <summary>
    /// Gets the latitude of the waypoint.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Latitude")]
    public async Task<double> GetLatitudeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Waypoint_get_Latitude", args);
    }

    /// <summary>
    /// Sets the latitude of the waypoint.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetLatitude(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Waypoint_set_Latitude", args);
    }

    /// <summary>
    /// Sets the latitude of the waypoint.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetLatitudeAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_set_Latitude", args);
    }

    /// <summary>
    /// Gets the longitude of the waypoint.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Longitude")]
    public double GetLongitude()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Waypoint_get_Longitude", args);
    }

    /// <summary>
    /// Gets the longitude of the waypoint.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Longitude")]
    public async Task<double> GetLongitudeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Waypoint_get_Longitude", args);
    }

    /// <summary>
    /// Sets the longitude of the waypoint.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetLongitude(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Waypoint_set_Longitude", args);
    }

    /// <summary>
    /// Sets the longitude of the waypoint.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetLongitudeAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_set_Longitude", args);
    }

    /// <summary>
    /// Gets the altitude of the waypoint above sea level, in meters.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_MeanAltitude")]
    public double GetMeanAltitude()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Waypoint_get_MeanAltitude", args);
    }

    /// <summary>
    /// Gets the altitude of the waypoint above sea level, in meters.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_MeanAltitude")]
    public async Task<double> GetMeanAltitudeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Waypoint_get_MeanAltitude", args);
    }

    /// <summary>
    /// Sets the altitude of the waypoint above sea level, in meters.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetMeanAltitude(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Waypoint_set_MeanAltitude", args);
    }

    /// <summary>
    /// Sets the altitude of the waypoint above sea level, in meters.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetMeanAltitudeAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_set_MeanAltitude", args);
    }

    /// <summary>
    /// Gets the name of the waypoint as it appears on the map and the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Name")]
    public string GetName()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Waypoint_get_Name", args);
    }

    /// <summary>
    /// Gets the name of the waypoint as it appears on the map and the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_Name")]
    public async Task<string> GetNameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Waypoint_get_Name", args);
    }

    /// <summary>
    /// Sets the name of the waypoint as it appears on the map and the contract.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetName(string value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Waypoint_set_Name", args);
    }

    /// <summary>
    /// Sets the name of the waypoint as it appears on the map and the contract.
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
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_set_Name", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the waypoint is near to the surface of a body.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_NearSurface")]
    public bool GetNearSurface()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Waypoint_get_NearSurface", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the waypoint is near to the surface of a body.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_NearSurface")]
    public async Task<bool> GetNearSurfaceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Waypoint_get_NearSurface", args);
    }

    /// <summary>
    /// Gets the altitude of the waypoint above the surface of the body or sea level,
    /// whichever is closer, in meters.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_SurfaceAltitude")]
    public double GetSurfaceAltitude()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Waypoint_get_SurfaceAltitude", args);
    }

    /// <summary>
    /// Gets the altitude of the waypoint above the surface of the body or sea level,
    /// whichever is closer, in meters.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Waypoint_get_SurfaceAltitude")]
    public async Task<double> GetSurfaceAltitudeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Waypoint_get_SurfaceAltitude", args);
    }

    /// <summary>
    /// Sets the altitude of the waypoint above the surface of the body or sea level,
    /// whichever is closer, in meters.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSurfaceAltitude(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Waypoint_set_SurfaceAltitude", args);
    }

    /// <summary>
    /// Sets the altitude of the waypoint above the surface of the body or sea level,
    /// whichever is closer, in meters.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetSurfaceAltitudeAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Waypoint_set_SurfaceAltitude", args);
    }
}
