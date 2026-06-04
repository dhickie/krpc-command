using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A resource drain. Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetResourceDrain" />.
/// </summary>
public class ResourceDrain : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal ResourceDrain(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Whether the provided resource is enabled for draining.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_CheckResource")]
    public bool CheckResource(Resource resource)
    {
        var args = new ProcedureArgument[]
        {
            this,
            resource
        };
        return InvokeNonNullable<bool>("SpaceCenter", "ResourceDrain_CheckResource", args);
    }

    /// <summary>
    /// Whether the provided resource is enabled for draining.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_CheckResource")]
    public async Task<bool> CheckResourceAsync(Resource resource)
    {
        var args = new ProcedureArgument[]
        {
            this,
            resource
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "ResourceDrain_CheckResource", args);
    }

    /// <summary>
    /// Whether the given resource should be drained.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_SetResource")]
    public void SetResource(Resource resource, bool enabled)
    {
        var args = new ProcedureArgument[]
        {
            this,
            resource,
            enabled
        };
        InvokeVoid("SpaceCenter", "ResourceDrain_SetResource", args);
    }

    /// <summary>
    /// Whether the given resource should be drained.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_SetResource")]
    public async Task SetResourceAsync(Resource resource, bool enabled)
    {
        var args = new ProcedureArgument[]
        {
            this,
            resource,
            enabled
        };
        await InvokeVoidAsync("SpaceCenter", "ResourceDrain_SetResource", args);
    }

    /// <summary>
    /// Activates resource draining for all enabled parts.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_Start")]
    public void Start()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        InvokeVoid("SpaceCenter", "ResourceDrain_Start", args);
    }

    /// <summary>
    /// Activates resource draining for all enabled parts.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_Start")]
    public async Task StartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        await InvokeVoidAsync("SpaceCenter", "ResourceDrain_Start", args);
    }

    /// <summary>
    /// Turns off resource draining.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_Stop")]
    public void Stop()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        InvokeVoid("SpaceCenter", "ResourceDrain_Stop", args);
    }

    /// <summary>
    /// Turns off resource draining.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_Stop")]
    public async Task StopAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        await InvokeVoidAsync("SpaceCenter", "ResourceDrain_Stop", args);
    }

    /// <summary>
    /// Gets the list of available resources.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_AvailableResources")]
    public IList<Resource> GetAvailableResources()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<IList<Resource>>("SpaceCenter", "ResourceDrain_get_AvailableResources", args);
    }

    /// <summary>
    /// Gets the list of available resources.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_AvailableResources")]
    public async Task<IList<Resource>> GetAvailableResourcesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<IList<Resource>>("SpaceCenter", "ResourceDrain_get_AvailableResources", args);
    }

    /// <summary>
    /// Gets the drain mode.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_DrainMode")]
    public DrainMode GetDrainMode()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<DrainMode>("SpaceCenter", "ResourceDrain_get_DrainMode", args);
    }

    /// <summary>
    /// Gets the drain mode.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_DrainMode")]
    public async Task<DrainMode> GetDrainModeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<DrainMode>("SpaceCenter", "ResourceDrain_get_DrainMode", args);
    }

    /// <summary>
    /// Sets the drain mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ResourceDrain_set_DrainMode")]
    public void SetDrainMode(DrainMode value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "ResourceDrain_set_DrainMode", args);
    }

    /// <summary>
    /// Sets the drain mode.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ResourceDrain_set_DrainMode")]
    public async Task SetDrainModeAsync(DrainMode value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "ResourceDrain_set_DrainMode", args);
    }

    /// <summary>
    /// Gets the maximum possible drain rate.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_MaxRate")]
    public float GetMaxRate()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "ResourceDrain_get_MaxRate", args);
    }

    /// <summary>
    /// Gets the maximum possible drain rate.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_MaxRate")]
    public async Task<float> GetMaxRateAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "ResourceDrain_get_MaxRate", args);
    }

    /// <summary>
    /// Gets the minimum possible drain rate
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_MinRate")]
    public float GetMinRate()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "ResourceDrain_get_MinRate", args);
    }

    /// <summary>
    /// Gets the minimum possible drain rate
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_MinRate")]
    public async Task<float> GetMinRateAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "ResourceDrain_get_MinRate", args);
    }

    /// <summary>
    /// Gets the part object for this resource drain.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_Part")]
    public Part GetPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "ResourceDrain_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this resource drain.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "ResourceDrain_get_Part", args);
    }

    /// <summary>
    /// Gets the current drain rate.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_Rate")]
    public float GetRate()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "ResourceDrain_get_Rate", args);
    }

    /// <summary>
    /// Gets the current drain rate.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceDrain_get_Rate")]
    public async Task<float> GetRateAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "ResourceDrain_get_Rate", args);
    }

    /// <summary>
    /// Sets the current drain rate.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ResourceDrain_set_Rate")]
    public void SetRate(float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "ResourceDrain_set_Rate", args);
    }

    /// <summary>
    /// Sets the current drain rate.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ResourceDrain_set_Rate")]
    public async Task SetRateAsync(float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "ResourceDrain_set_Rate", args);
    }
}
