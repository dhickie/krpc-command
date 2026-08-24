using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A resource converter. Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetResourceConverter" />.
/// </summary>
public class ResourceConverter : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal ResourceConverter(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// True if the specified converter is active.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_Active")]
    public bool Active(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return InvokeNonNullable<bool>("SpaceCenter", "ResourceConverter_Active", args);
    }

    /// <summary>
    /// True if the specified converter is active.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_Active")]
    public async Task<bool> ActiveAsync(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "ResourceConverter_Active", args);
    }

    /// <summary>
    /// List of the names of resources consumed by the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_Inputs")]
    public IList<string> GetInputs(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return InvokeNonNullable<List<string>>("SpaceCenter", "ResourceConverter_Inputs", args);
    }

    /// <summary>
    /// List of the names of resources consumed by the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_Inputs")]
    public async Task<IList<string>> GetInputsAsync(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return await InvokeNonNullableAsync<List<string>>("SpaceCenter", "ResourceConverter_Inputs", args);
    }

    /// <summary>
    /// The name of the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_Name")]
    public string GetName(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return InvokeNonNullable<string>("SpaceCenter", "ResourceConverter_Name", args);
    }

    /// <summary>
    /// The name of the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_Name")]
    public async Task<string> GetNameAsync(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return await InvokeNonNullableAsync<string>("SpaceCenter", "ResourceConverter_Name", args);
    }

    /// <summary>
    /// List of the names of resources produced by the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_Outputs")]
    public IList<string> GetOutputs(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return InvokeNonNullable<List<string>>("SpaceCenter", "ResourceConverter_Outputs", args);
    }

    /// <summary>
    /// List of the names of resources produced by the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_Outputs")]
    public async Task<IList<string>> GetOutputsAsync(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return await InvokeNonNullableAsync<List<string>>("SpaceCenter", "ResourceConverter_Outputs", args);
    }

    /// <summary>
    /// Start the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [SetRpc("SpaceCenter", "ResourceConverter_Start")]
    public void Start(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        InvokeVoid("SpaceCenter", "ResourceConverter_Start", args);
    }

    /// <summary>
    /// Start the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [SetRpc("SpaceCenter", "ResourceConverter_Start")]
    public async Task StartAsync(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        await InvokeVoidAsync("SpaceCenter", "ResourceConverter_Start", args);
    }

    /// <summary>
    /// The state of the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_State")]
    public ResourceConverterState GetState(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return InvokeNonNullable<ResourceConverterState>("SpaceCenter", "ResourceConverter_State", args);
    }

    /// <summary>
    /// The state of the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_State")]
    public async Task<ResourceConverterState> GetStateAsync(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return await InvokeNonNullableAsync<ResourceConverterState>("SpaceCenter", "ResourceConverter_State", args);
    }

    /// <summary>
    /// Status information for the specified converter.
    /// This is the full status message shown in the in-game UI.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_StatusInfo")]
    public string GetStatusInfo(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return InvokeNonNullable<string>("SpaceCenter", "ResourceConverter_StatusInfo", args);
    }

    /// <summary>
    /// Status information for the specified converter.
    /// This is the full status message shown in the in-game UI.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [GetRpc("SpaceCenter", "ResourceConverter_StatusInfo")]
    public async Task<string> GetStatusInfoAsync(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        return await InvokeNonNullableAsync<string>("SpaceCenter", "ResourceConverter_StatusInfo", args);
    }

    /// <summary>
    /// Stop the specified converter.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [SetRpc("SpaceCenter", "ResourceConverter_Stop")]
    public void Stop(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        InvokeVoid("SpaceCenter", "ResourceConverter_Stop", args);
    }

    /// <summary>
    /// Stop the specified converter.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="index">Index of the converter.</param>
    [SetRpc("SpaceCenter", "ResourceConverter_Stop")]
    public async Task StopAsync(int index)
    {
        var args = new ProcedureArgument[]
        {
            this,
            index
        };
        await InvokeVoidAsync("SpaceCenter", "ResourceConverter_Stop", args);
    }

    /// <summary>
    /// Gets the core temperature of the converter, in Kelvin.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_CoreTemperature")]
    public float GetCoreTemperature()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "ResourceConverter_get_CoreTemperature", args);
    }

    /// <summary>
    /// Gets the core temperature of the converter, in Kelvin.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_CoreTemperature")]
    public async Task<float> GetCoreTemperatureAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "ResourceConverter_get_CoreTemperature", args);
    }

    /// <summary>
    /// Gets the number of converters in the part.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_Count")]
    public int GetCount()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<int>("SpaceCenter", "ResourceConverter_get_Count", args);
    }

    /// <summary>
    /// Gets the number of converters in the part.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_Count")]
    public async Task<int> GetCountAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<int>("SpaceCenter", "ResourceConverter_get_Count", args);
    }

    /// <summary>
    /// Gets the core temperature at which the converter will operate with peak efficiency, in Kelvin.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature")]
    public float GetOptimumCoreTemperature()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature", args);
    }

    /// <summary>
    /// Gets the core temperature at which the converter will operate with peak efficiency, in Kelvin.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature")]
    public async Task<float> GetOptimumCoreTemperatureAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature", args);
    }

    /// <summary>
    /// Gets the part object for this converter.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_Part")]
    public Part GetPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "ResourceConverter_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this converter.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "ResourceConverter_get_Part", args);
    }

    /// <summary>
    /// Gets the thermal efficiency of the converter, as a percentage of its maximum.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_ThermalEfficiency")]
    public float GetThermalEfficiency()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "ResourceConverter_get_ThermalEfficiency", args);
    }

    /// <summary>
    /// Gets the thermal efficiency of the converter, as a percentage of its maximum.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ResourceConverter_get_ThermalEfficiency")]
    public async Task<float> GetThermalEfficiencyAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "ResourceConverter_get_ThermalEfficiency", args);
    }
}
