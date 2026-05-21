using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An air intake. Obtained by calling <see cref="M:SpaceCenter.Part.GetIntake" />.
/// </summary>
public class Intake : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Intake(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets the area of the intake's opening, in square meters.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Area")]
    public float GetArea()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Intake_get_Area", args);
    }

    /// <summary>
    /// Gets the area of the intake's opening, in square meters.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Area")]
    public async Task<float> GetAreaAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Intake_get_Area", args);
    }

    /// <summary>
    /// Gets the rate of flow into the intake, in units of resource per second.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Flow")]
    public float GetFlow()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Intake_get_Flow", args);
    }

    /// <summary>
    /// Gets the rate of flow into the intake, in units of resource per second.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Flow")]
    public async Task<float> GetFlowAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Intake_get_Flow", args);
    }

    /// <summary>
    /// Gets whether the intake is open.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Open")]
    public bool GetOpen()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Intake_get_Open", args);
    }

    /// <summary>
    /// Gets whether the intake is open.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Open")]
    public async Task<bool> GetOpenAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Intake_get_Open", args);
    }

    /// <summary>
    /// Sets whether the intake is open.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetOpen(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Intake_set_Open", args);
    }

    /// <summary>
    /// Sets whether the intake is open.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetOpenAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Intake_set_Open", args);
    }

    /// <summary>
    /// Gets the part object for this intake.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Intake_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this intake.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Intake_get_Part", args);
    }

    /// <summary>
    /// Speed of the flow into the intake, in <math>m/s</math>.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Speed")]
    public float GetSpeed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Intake_get_Speed", args);
    }

    /// <summary>
    /// Speed of the flow into the intake, in <math>m/s</math>.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Intake_get_Speed")]
    public async Task<float> GetSpeedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Intake_get_Speed", args);
    }
}
