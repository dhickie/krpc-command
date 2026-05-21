using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A resource harvester (drill). Obtained by calling <see cref="M:SpaceCenter.Part.GetResourceHarvester" />.
/// </summary>
public class ResourceHarvester : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ResourceHarvester(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the harvester is actively drilling.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_Active")]
    public bool GetActive()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ResourceHarvester_get_Active", args);
    }

    /// <summary>
    /// Gets whether the harvester is actively drilling.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_Active")]
    public async Task<bool> GetActiveAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "ResourceHarvester_get_Active", args);
    }

    /// <summary>
    /// Sets whether the harvester is actively drilling.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ResourceHarvester_set_Active")]
    public void SetActive(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ResourceHarvester_set_Active", args);
    }

    /// <summary>
    /// Sets whether the harvester is actively drilling.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ResourceHarvester_set_Active")]
    public async Task SetActiveAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "ResourceHarvester_set_Active", args);
    }

    /// <summary>
    /// Gets the core temperature of the drill, in Kelvin.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_CoreTemperature")]
    public float GetCoreTemperature()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceHarvester_get_CoreTemperature", args);
    }

    /// <summary>
    /// Gets the core temperature of the drill, in Kelvin.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_CoreTemperature")]
    public async Task<float> GetCoreTemperatureAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceHarvester_get_CoreTemperature", args);
    }

    /// <summary>
    /// Gets whether the harvester is deployed.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_Deployed")]
    public bool GetDeployed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ResourceHarvester_get_Deployed", args);
    }

    /// <summary>
    /// Gets whether the harvester is deployed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_Deployed")]
    public async Task<bool> GetDeployedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "ResourceHarvester_get_Deployed", args);
    }

    /// <summary>
    /// Sets whether the harvester is deployed.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ResourceHarvester_set_Deployed")]
    public void SetDeployed(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ResourceHarvester_set_Deployed", args);
    }

    /// <summary>
    /// Sets whether the harvester is deployed.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ResourceHarvester_set_Deployed")]
    public async Task SetDeployedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "ResourceHarvester_set_Deployed", args);
    }

    /// <summary>
    /// Gets the rate at which the drill is extracting ore, in units per second.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_ExtractionRate")]
    public float GetExtractionRate()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceHarvester_get_ExtractionRate", args);
    }

    /// <summary>
    /// Gets the rate at which the drill is extracting ore, in units per second.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_ExtractionRate")]
    public async Task<float> GetExtractionRateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceHarvester_get_ExtractionRate", args);
    }

    /// <summary>
    /// Gets the core temperature at which the drill will operate with peak efficiency, in Kelvin.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature")]
    public float GetOptimumCoreTemperature()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature", args);
    }

    /// <summary>
    /// Gets the core temperature at which the drill will operate with peak efficiency, in Kelvin.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature")]
    public async Task<float> GetOptimumCoreTemperatureAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature", args);
    }

    /// <summary>
    /// Gets the part object for this harvester.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "ResourceHarvester_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this harvester.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "ResourceHarvester_get_Part", args);
    }

    /// <summary>
    /// Gets the state of the harvester.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_State")]
    public ResourceHarvesterState GetState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ResourceHarvesterState>("SpaceCenter", "ResourceHarvester_get_State", args);
    }

    /// <summary>
    /// Gets the state of the harvester.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_State")]
    public async Task<ResourceHarvesterState> GetStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ResourceHarvesterState>("SpaceCenter", "ResourceHarvester_get_State", args);
    }

    /// <summary>
    /// Gets the thermal efficiency of the drill, as a percentage of its maximum.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency")]
    public float GetThermalEfficiency()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency", args);
    }

    /// <summary>
    /// Gets the thermal efficiency of the drill, as a percentage of its maximum.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency")]
    public async Task<float> GetThermalEfficiencyAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency", args);
    }
}
