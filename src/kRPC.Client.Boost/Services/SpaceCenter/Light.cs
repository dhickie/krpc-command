using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A light. Obtained by calling <see cref="M:SpaceCenter.Part.GetLight" />.
/// </summary>
public class Light : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Light(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the light is switched on.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_Active")]
    public bool GetActive()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Light_get_Active", args);
    }

    /// <summary>
    /// Gets whether the light is switched on.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_Active")]
    public async Task<bool> GetActiveAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Light_get_Active", args);
    }

    /// <summary>
    /// Sets whether the light is switched on.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Light_set_Active")]
    public void SetActive(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Light_set_Active", args);
    }

    /// <summary>
    /// Sets whether the light is switched on.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Light_set_Active")]
    public async Task SetActiveAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Light_set_Active", args);
    }

    /// <summary>
    /// Gets whether blinking is enabled.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_Blink")]
    public bool GetBlink()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Light_get_Blink", args);
    }

    /// <summary>
    /// Gets whether blinking is enabled.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_Blink")]
    public async Task<bool> GetBlinkAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Light_get_Blink", args);
    }

    /// <summary>
    /// Sets whether blinking is enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Light_set_Blink")]
    public void SetBlink(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Light_set_Blink", args);
    }

    /// <summary>
    /// Sets whether blinking is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Light_set_Blink")]
    public async Task SetBlinkAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Light_set_Blink", args);
    }

    /// <summary>
    /// Gets the blink rate of the light.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_BlinkRate")]
    public float GetBlinkRate()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Light_get_BlinkRate", args);
    }

    /// <summary>
    /// Gets the blink rate of the light.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_BlinkRate")]
    public async Task<float> GetBlinkRateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Light_get_BlinkRate", args);
    }

    /// <summary>
    /// Sets the blink rate of the light.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Light_set_BlinkRate")]
    public void SetBlinkRate(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Light_set_BlinkRate", args);
    }

    /// <summary>
    /// Sets the blink rate of the light.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Light_set_BlinkRate")]
    public async Task SetBlinkRateAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Light_set_BlinkRate", args);
    }

    /// <summary>
    /// Gets the color of the light, as an RGB triple.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_Color")]
    public Tuple<float,float,float> GetColor()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<float,float,float>>("SpaceCenter", "Light_get_Color", args);
    }

    /// <summary>
    /// Gets the color of the light, as an RGB triple.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_Color")]
    public async Task<Tuple<float,float,float>> GetColorAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<float,float,float>>("SpaceCenter", "Light_get_Color", args);
    }

    /// <summary>
    /// Sets the color of the light, as an RGB triple.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Light_set_Color")]
    public void SetColor(Tuple<float,float,float> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Light_set_Color", args);
    }

    /// <summary>
    /// Sets the color of the light, as an RGB triple.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Light_set_Color")]
    public async Task SetColorAsync(Tuple<float,float,float> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Light_set_Color", args);
    }

    /// <summary>
    /// Gets the part object for this light.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Light_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this light.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Light_get_Part", args);
    }

    /// <summary>
    /// Gets the current power usage, in units of charge per second.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_PowerUsage")]
    public float GetPowerUsage()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Light_get_PowerUsage", args);
    }

    /// <summary>
    /// Gets the current power usage, in units of charge per second.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Light_get_PowerUsage")]
    public async Task<float> GetPowerUsageAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Light_get_PowerUsage", args);
    }
}
