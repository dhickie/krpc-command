using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A resource converter. Obtained by calling <see cref="M:SpaceCenter.Part.GetResourceConverter" />.
/// </summary>
public class ResourceConverter : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ResourceConverter(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// True if the specified converter is active.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Active")]
    public bool Active(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return Connection.Invoke<bool>("SpaceCenter", "ResourceConverter_Active", args);
    }

    /// <summary>
    /// True if the specified converter is active.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Active")]
    public async Task<bool> ActiveAsync(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "ResourceConverter_Active", args);
    }

    /// <summary>
    /// List of the names of resources consumed by the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Inputs")]
    public IList<string> Inputs(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "ResourceConverter_Inputs", args);
    }

    /// <summary>
    /// List of the names of resources consumed by the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Inputs")]
    public async Task<IList<string>> InputsAsync(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "ResourceConverter_Inputs", args);
    }

    /// <summary>
    /// The name of the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Name")]
    public string Name(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return Connection.Invoke<string>("SpaceCenter", "ResourceConverter_Name", args);
    }

    /// <summary>
    /// The name of the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Name")]
    public async Task<string> NameAsync(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "ResourceConverter_Name", args);
    }

    /// <summary>
    /// List of the names of resources produced by the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Outputs")]
    public IList<string> Outputs(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "ResourceConverter_Outputs", args);
    }

    /// <summary>
    /// List of the names of resources produced by the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Outputs")]
    public async Task<IList<string>> OutputsAsync(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "ResourceConverter_Outputs", args);
    }

    /// <summary>
    /// Start the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Start")]
    public void Start(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        Connection.Invoke("SpaceCenter", "ResourceConverter_Start", args);
    }

    /// <summary>
    /// Start the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Start")]
    public async Task StartAsync(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        await Connection.InvokeAsync("SpaceCenter", "ResourceConverter_Start", args);
    }

    /// <summary>
    /// The state of the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_State")]
    public ResourceConverterState State(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return Connection.Invoke<ResourceConverterState>("SpaceCenter", "ResourceConverter_State", args);
    }

    /// <summary>
    /// The state of the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_State")]
    public async Task<ResourceConverterState> StateAsync(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return await Connection.InvokeAsync<ResourceConverterState>("SpaceCenter", "ResourceConverter_State", args);
    }

    /// <summary>
    /// Status information for the specified converter.
    /// This is the full status message shown in the in-game UI.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_StatusInfo")]
    public string StatusInfo(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return Connection.Invoke<string>("SpaceCenter", "ResourceConverter_StatusInfo", args);
    }

    /// <summary>
    /// Status information for the specified converter.
    /// This is the full status message shown in the in-game UI.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_StatusInfo")]
    public async Task<string> StatusInfoAsync(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "ResourceConverter_StatusInfo", args);
    }

    /// <summary>
    /// Stop the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Stop")]
    public void Stop(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        Connection.Invoke("SpaceCenter", "ResourceConverter_Stop", args);
    }

    /// <summary>
    /// Stop the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [Rpc("SpaceCenter", "ResourceConverter_Stop")]
    public async Task StopAsync(int index)
    {
        var args = new object[]
        {
            this,
            index
        };
        await Connection.InvokeAsync("SpaceCenter", "ResourceConverter_Stop", args);
    }

    /// <summary>
    /// Gets the core temperature of the converter, in Kelvin.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_CoreTemperature")]
    public float GetCoreTemperature()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceConverter_get_CoreTemperature", args);
    }

    /// <summary>
    /// Gets the core temperature of the converter, in Kelvin.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_CoreTemperature")]
    public async Task<float> GetCoreTemperatureAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceConverter_get_CoreTemperature", args);
    }

    /// <summary>
    /// Gets the number of converters in the part.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_Count")]
    public int GetCount()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<int>("SpaceCenter", "ResourceConverter_get_Count", args);
    }

    /// <summary>
    /// Gets the number of converters in the part.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_Count")]
    public async Task<int> GetCountAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<int>("SpaceCenter", "ResourceConverter_get_Count", args);
    }

    /// <summary>
    /// Gets the core temperature at which the converter will operate with peak efficiency, in Kelvin.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature")]
    public float GetOptimumCoreTemperature()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature", args);
    }

    /// <summary>
    /// Gets the core temperature at which the converter will operate with peak efficiency, in Kelvin.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature")]
    public async Task<float> GetOptimumCoreTemperatureAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature", args);
    }

    /// <summary>
    /// Gets the part object for this converter.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "ResourceConverter_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this converter.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "ResourceConverter_get_Part", args);
    }

    /// <summary>
    /// Gets the thermal efficiency of the converter, as a percentage of its maximum.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_ThermalEfficiency")]
    public float GetThermalEfficiency()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceConverter_get_ThermalEfficiency", args);
    }

    /// <summary>
    /// Gets the thermal efficiency of the converter, as a percentage of its maximum.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceConverter_get_ThermalEfficiency")]
    public async Task<float> GetThermalEfficiencyAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceConverter_get_ThermalEfficiency", args);
    }
}
