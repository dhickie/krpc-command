using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A parachute. Obtained by calling <see cref="M:SpaceCenter.Part.GetParachute" />.
/// </summary>
public class Parachute : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Parachute(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Deploys the parachute. This has no effect if the parachute has already
    /// been armed or deployed.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_Arm")]
    public void Arm()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Parachute_Arm", args);
    }

    /// <summary>
    /// Deploys the parachute. This has no effect if the parachute has already
    /// been armed or deployed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_Arm")]
    public async Task ArmAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Parachute_Arm", args);
    }

    /// <summary>
    /// Cuts the parachute.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_Cut")]
    public void Cut()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Parachute_Cut", args);
    }

    /// <summary>
    /// Cuts the parachute.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_Cut")]
    public async Task CutAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Parachute_Cut", args);
    }

    /// <summary>
    /// Deploys the parachute. This has no effect if the parachute has already
    /// been deployed.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_Deploy")]
    public void Deploy()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Parachute_Deploy", args);
    }

    /// <summary>
    /// Deploys the parachute. This has no effect if the parachute has already
    /// been deployed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_Deploy")]
    public async Task DeployAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Parachute_Deploy", args);
    }

    /// <summary>
    /// Gets whether the parachute has been armed or deployed.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_Armed")]
    public bool GetArmed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Parachute_get_Armed", args);
    }

    /// <summary>
    /// Gets whether the parachute has been armed or deployed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_Armed")]
    public async Task<bool> GetArmedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Parachute_get_Armed", args);
    }

    /// <summary>
    /// Gets the altitude at which the parachute will full deploy, in meters.
    /// Only applicable to stock parachutes.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_DeployAltitude")]
    public float GetDeployAltitude()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Parachute_get_DeployAltitude", args);
    }

    /// <summary>
    /// Gets the altitude at which the parachute will full deploy, in meters.
    /// Only applicable to stock parachutes.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_DeployAltitude")]
    public async Task<float> GetDeployAltitudeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Parachute_get_DeployAltitude", args);
    }

    /// <summary>
    /// Sets the altitude at which the parachute will full deploy, in meters.
    /// Only applicable to stock parachutes.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Parachute_set_DeployAltitude")]
    public void SetDeployAltitude(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Parachute_set_DeployAltitude", args);
    }

    /// <summary>
    /// Sets the altitude at which the parachute will full deploy, in meters.
    /// Only applicable to stock parachutes.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Parachute_set_DeployAltitude")]
    public async Task SetDeployAltitudeAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Parachute_set_DeployAltitude", args);
    }

    /// <summary>
    /// Gets the minimum pressure at which the parachute will semi-deploy, in atmospheres.
    /// Only applicable to stock parachutes.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_DeployMinPressure")]
    public float GetDeployMinPressure()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Parachute_get_DeployMinPressure", args);
    }

    /// <summary>
    /// Gets the minimum pressure at which the parachute will semi-deploy, in atmospheres.
    /// Only applicable to stock parachutes.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_DeployMinPressure")]
    public async Task<float> GetDeployMinPressureAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Parachute_get_DeployMinPressure", args);
    }

    /// <summary>
    /// Sets the minimum pressure at which the parachute will semi-deploy, in atmospheres.
    /// Only applicable to stock parachutes.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Parachute_set_DeployMinPressure")]
    public void SetDeployMinPressure(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Parachute_set_DeployMinPressure", args);
    }

    /// <summary>
    /// Sets the minimum pressure at which the parachute will semi-deploy, in atmospheres.
    /// Only applicable to stock parachutes.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Parachute_set_DeployMinPressure")]
    public async Task SetDeployMinPressureAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Parachute_set_DeployMinPressure", args);
    }

    /// <summary>
    /// Gets whether the parachute has been deployed.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_Deployed")]
    public bool GetDeployed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Parachute_get_Deployed", args);
    }

    /// <summary>
    /// Gets whether the parachute has been deployed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_Deployed")]
    public async Task<bool> GetDeployedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Parachute_get_Deployed", args);
    }

    /// <summary>
    /// Gets the part object for this parachute.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Parachute_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this parachute.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Parachute_get_Part", args);
    }

    /// <summary>
    /// Gets the current state of the parachute.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_State")]
    public ParachuteState GetState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ParachuteState>("SpaceCenter", "Parachute_get_State", args);
    }

    /// <summary>
    /// Gets the current state of the parachute.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Parachute_get_State")]
    public async Task<ParachuteState> GetStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ParachuteState>("SpaceCenter", "Parachute_get_State", args);
    }
}
