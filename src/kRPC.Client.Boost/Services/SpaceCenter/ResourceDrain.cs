using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A resource drain. Obtained by calling <see cref="M:SpaceCenter.Part.GetResourceDrain" />.
/// </summary>
public class ResourceDrain : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ResourceDrain(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Whether the provided resource is enabled for draining.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_CheckResource")]
    public bool CheckResource(Resource resource)
    {
        var args = new object[]
        {
            this,
            resource
        };
        return Connection.Invoke<bool>("SpaceCenter", "ResourceDrain_CheckResource", args);
    }

    /// <summary>
    /// Whether the provided resource is enabled for draining.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_CheckResource")]
    public async Task<bool> CheckResourceAsync(Resource resource)
    {
        var args = new object[]
        {
            this,
            resource
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "ResourceDrain_CheckResource", args);
    }

    /// <summary>
    /// Whether the given resource should be drained.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_SetResource")]
    public void SetResource(Resource resource, bool enabled)
    {
        var args = new object[]
        {
            this,
            resource,
            enabled
        };
        Connection.Invoke("SpaceCenter", "ResourceDrain_SetResource", args);
    }

    /// <summary>
    /// Whether the given resource should be drained.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_SetResource")]
    public async Task SetResourceAsync(Resource resource, bool enabled)
    {
        var args = new object[]
        {
            this,
            resource,
            enabled
        };
        await Connection.InvokeAsync("SpaceCenter", "ResourceDrain_SetResource", args);
    }

    /// <summary>
    /// Activates resource draining for all enabled parts.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_Start")]
    public void Start()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "ResourceDrain_Start", args);
    }

    /// <summary>
    /// Activates resource draining for all enabled parts.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_Start")]
    public async Task StartAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "ResourceDrain_Start", args);
    }

    /// <summary>
    /// Turns off resource draining.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_Stop")]
    public void Stop()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "ResourceDrain_Stop", args);
    }

    /// <summary>
    /// Turns off resource draining.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_Stop")]
    public async Task StopAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "ResourceDrain_Stop", args);
    }

    /// <summary>
    /// Gets the list of available resources.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_AvailableResources")]
    public IList<Resource> GetAvailableResources()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Resource>>("SpaceCenter", "ResourceDrain_get_AvailableResources", args);
    }

    /// <summary>
    /// Gets the list of available resources.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_AvailableResources")]
    public async Task<IList<Resource>> GetAvailableResourcesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Resource>>("SpaceCenter", "ResourceDrain_get_AvailableResources", args);
    }

    /// <summary>
    /// Gets the drain mode.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_DrainMode")]
    public DrainMode GetDrainMode()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<DrainMode>("SpaceCenter", "ResourceDrain_get_DrainMode", args);
    }

    /// <summary>
    /// Gets the drain mode.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_DrainMode")]
    public async Task<DrainMode> GetDrainModeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<DrainMode>("SpaceCenter", "ResourceDrain_get_DrainMode", args);
    }

    /// <summary>
    /// Sets the drain mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetDrainMode(DrainMode value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ResourceDrain_set_DrainMode", args);
    }

    /// <summary>
    /// Sets the drain mode.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetDrainModeAsync(DrainMode value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "ResourceDrain_set_DrainMode", args);
    }

    /// <summary>
    /// Gets the maximum possible drain rate.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_MaxRate")]
    public float GetMaxRate()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceDrain_get_MaxRate", args);
    }

    /// <summary>
    /// Gets the maximum possible drain rate.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_MaxRate")]
    public async Task<float> GetMaxRateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceDrain_get_MaxRate", args);
    }

    /// <summary>
    /// Gets the minimum possible drain rate
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_MinRate")]
    public float GetMinRate()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceDrain_get_MinRate", args);
    }

    /// <summary>
    /// Gets the minimum possible drain rate
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_MinRate")]
    public async Task<float> GetMinRateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceDrain_get_MinRate", args);
    }

    /// <summary>
    /// Gets the part object for this resource drain.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "ResourceDrain_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this resource drain.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "ResourceDrain_get_Part", args);
    }

    /// <summary>
    /// Gets the current drain rate.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_Rate")]
    public float GetRate()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceDrain_get_Rate", args);
    }

    /// <summary>
    /// Gets the current drain rate.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_Rate")]
    public async Task<float> GetRateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceDrain_get_Rate", args);
    }

    /// <summary>
    /// Sets the current drain rate.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRate(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ResourceDrain_set_Rate", args);
    }

    /// <summary>
    /// Sets the current drain rate.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRateAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "ResourceDrain_set_Rate", args);
    }
}
