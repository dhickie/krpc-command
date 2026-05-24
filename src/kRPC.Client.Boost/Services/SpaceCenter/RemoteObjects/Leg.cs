using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A landing leg. Obtained by calling <see cref="M:SpaceCenter.Part.GetLeg" />.
/// </summary>
public class Leg : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Leg(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the leg is deployable.
    /// </summary>
    [Rpc("SpaceCenter", "Leg_get_Deployable")]
    public bool GetDeployable()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Leg_get_Deployable", args);
    }

    /// <summary>
    /// Gets whether the leg is deployable.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Leg_get_Deployable")]
    public async Task<bool> GetDeployableAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Leg_get_Deployable", args);
    }

    /// <summary>
    /// Gets whether the landing leg is deployed.
    /// </summary>
    /// <remarks>
    /// Fixed landing legs are always deployed.
    /// Returns an error if you try to deploy fixed landing gear.
    /// </remarks>
    [Rpc("SpaceCenter", "Leg_get_Deployed")]
    public bool GetDeployed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Leg_get_Deployed", args);
    }

    /// <summary>
    /// Gets whether the landing leg is deployed.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// Fixed landing legs are always deployed.
    /// Returns an error if you try to deploy fixed landing gear.
    /// </remarks>
    [Rpc("SpaceCenter", "Leg_get_Deployed")]
    public async Task<bool> GetDeployedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Leg_get_Deployed", args);
    }

    /// <summary>
    /// Sets whether the landing leg is deployed.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Leg_set_Deployed")]
    public void SetDeployed(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Leg_set_Deployed", args);
    }

    /// <summary>
    /// Sets whether the landing leg is deployed.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Leg_set_Deployed")]
    public async Task SetDeployedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Leg_set_Deployed", args);
    }

    /// <summary>
    /// Returns whether the leg is touching the ground.
    /// </summary>
    [Rpc("SpaceCenter", "Leg_get_IsGrounded")]
    public bool GetIsGrounded()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Leg_get_IsGrounded", args);
    }

    /// <summary>
    /// Returns whether the leg is touching the ground.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Leg_get_IsGrounded")]
    public async Task<bool> GetIsGroundedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Leg_get_IsGrounded", args);
    }

    /// <summary>
    /// Gets the part object for this landing leg.
    /// </summary>
    [Rpc("SpaceCenter", "Leg_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Leg_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this landing leg.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Leg_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Leg_get_Part", args);
    }

    /// <summary>
    /// Gets the current state of the landing leg.
    /// </summary>
    [Rpc("SpaceCenter", "Leg_get_State")]
    public LegState GetState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<LegState>("SpaceCenter", "Leg_get_State", args);
    }

    /// <summary>
    /// Gets the current state of the landing leg.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Leg_get_State")]
    public async Task<LegState> GetStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<LegState>("SpaceCenter", "Leg_get_State", args);
    }
}
