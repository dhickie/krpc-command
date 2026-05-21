using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// An individual resource stored within a part.
/// Created using methods in the <see cref="T:SpaceCenter.Resources" /> class.
/// </summary>
public class Resource : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Resource(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets the amount of the resource that is currently stored in the part.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Amount")]
    public float GetAmount()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Resource_get_Amount", args);
    }

    /// <summary>
    /// Gets the amount of the resource that is currently stored in the part.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Amount")]
    public async Task<float> GetAmountAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Resource_get_Amount", args);
    }

    /// <summary>
    /// Gets the density of the resource, in <math>kg/l</math>.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Density")]
    public float GetDensity()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Resource_get_Density", args);
    }

    /// <summary>
    /// Gets the density of the resource, in <math>kg/l</math>.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Density")]
    public async Task<float> GetDensityAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Resource_get_Density", args);
    }

    /// <summary>
    /// Gets whether use of this resource is enabled.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Enabled")]
    public bool GetEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Resource_get_Enabled", args);
    }

    /// <summary>
    /// Gets whether use of this resource is enabled.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Enabled")]
    public async Task<bool> GetEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Resource_get_Enabled", args);
    }

    /// <summary>
    /// Sets whether use of this resource is enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Resource_set_Enabled")]
    public void SetEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Resource_set_Enabled", args);
    }

    /// <summary>
    /// Sets whether use of this resource is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Resource_set_Enabled")]
    public async Task SetEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Resource_set_Enabled", args);
    }

    /// <summary>
    /// Gets the flow mode of the resource.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_FlowMode")]
    public ResourceFlowMode GetFlowMode()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ResourceFlowMode>("SpaceCenter", "Resource_get_FlowMode", args);
    }

    /// <summary>
    /// Gets the flow mode of the resource.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_FlowMode")]
    public async Task<ResourceFlowMode> GetFlowModeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ResourceFlowMode>("SpaceCenter", "Resource_get_FlowMode", args);
    }

    /// <summary>
    /// Gets the total amount of the resource that can be stored in the part.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Max")]
    public float GetMax()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Resource_get_Max", args);
    }

    /// <summary>
    /// Gets the total amount of the resource that can be stored in the part.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Max")]
    public async Task<float> GetMaxAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Resource_get_Max", args);
    }

    /// <summary>
    /// Gets the name of the resource.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Name")]
    public string GetName()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Resource_get_Name", args);
    }

    /// <summary>
    /// Gets the name of the resource.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Name")]
    public async Task<string> GetNameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Resource_get_Name", args);
    }

    /// <summary>
    /// Gets the part containing the resource.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Resource_get_Part", args);
    }

    /// <summary>
    /// Gets the part containing the resource.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Resource_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Resource_get_Part", args);
    }
}
