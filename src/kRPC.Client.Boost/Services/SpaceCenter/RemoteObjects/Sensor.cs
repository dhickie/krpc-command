using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A sensor, such as a thermometer. Obtained by calling <see cref="M:SpaceCenter.Part.GetSensor" />.
/// </summary>
public class Sensor : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal Sensor(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the sensor is active.
    /// </summary>
    [Rpc("SpaceCenter", "Sensor_get_Active")]
    public bool GetActive()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Sensor_get_Active", args);
    }

    /// <summary>
    /// Gets whether the sensor is active.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Sensor_get_Active")]
    public async Task<bool> GetActiveAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Sensor_get_Active", args);
    }

    /// <summary>
    /// Sets whether the sensor is active.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Sensor_set_Active")]
    public void SetActive(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "Sensor_set_Active", args);
    }

    /// <summary>
    /// Sets whether the sensor is active.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Sensor_set_Active")]
    public async Task SetActiveAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "Sensor_set_Active", args);
    }

    /// <summary>
    /// Gets the part object for this sensor.
    /// </summary>
    [Rpc("SpaceCenter", "Sensor_get_Part")]
    public Part GetPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "Sensor_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this sensor.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Sensor_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "Sensor_get_Part", args);
    }

    /// <summary>
    /// Gets the current value of the sensor.
    /// </summary>
    [Rpc("SpaceCenter", "Sensor_get_Value")]
    public string GetValue()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<string>("SpaceCenter", "Sensor_get_Value", args);
    }

    /// <summary>
    /// Gets the current value of the sensor.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Sensor_get_Value")]
    public async Task<string> GetValueAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<string>("SpaceCenter", "Sensor_get_Value", args);
    }
}
