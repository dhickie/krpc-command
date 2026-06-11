using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// An antenna. Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetAntenna" />.
/// </summary>
public class Antenna : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal Antenna(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Cancel current transmission of data.
    /// </summary>
    [SetRpc("SpaceCenter", "Antenna_Cancel")]
    public void Cancel()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        InvokeVoid("SpaceCenter", "Antenna_Cancel", args);
    }

    /// <summary>
    /// Cancel current transmission of data.
    /// Executes asynchronously.
    /// </summary>
    [SetRpc("SpaceCenter", "Antenna_Cancel")]
    public async Task CancelAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        await InvokeVoidAsync("SpaceCenter", "Antenna_Cancel", args);
    }

    /// <summary>
    /// Transmit data.
    /// </summary>
    [SetRpc("SpaceCenter", "Antenna_Transmit")]
    public void Transmit()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        InvokeVoid("SpaceCenter", "Antenna_Transmit", args);
    }

    /// <summary>
    /// Transmit data.
    /// Executes asynchronously.
    /// </summary>
    [SetRpc("SpaceCenter", "Antenna_Transmit")]
    public async Task TransmitAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        await InvokeVoidAsync("SpaceCenter", "Antenna_Transmit", args);
    }

    /// <summary>
    /// Gets whether partial data transmission is permitted.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_AllowPartial")]
    public bool GetAllowPartial()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Antenna_get_AllowPartial", args);
    }

    /// <summary>
    /// Gets whether partial data transmission is permitted.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_AllowPartial")]
    public async Task<bool> GetAllowPartialAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Antenna_get_AllowPartial", args);
    }

    /// <summary>
    /// Sets whether partial data transmission is permitted.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Antenna_set_AllowPartial")]
    public void SetAllowPartial(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "Antenna_set_AllowPartial", args);
    }

    /// <summary>
    /// Sets whether partial data transmission is permitted.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Antenna_set_AllowPartial")]
    public async Task SetAllowPartialAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "Antenna_set_AllowPartial", args);
    }

    /// <summary>
    /// Gets whether data can be transmitted by this antenna.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_CanTransmit")]
    public bool GetCanTransmit()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Antenna_get_CanTransmit", args);
    }

    /// <summary>
    /// Gets whether data can be transmitted by this antenna.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_CanTransmit")]
    public async Task<bool> GetCanTransmitAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Antenna_get_CanTransmit", args);
    }

    /// <summary>
    /// Gets whether the antenna can be combined with other antennae on the vessel
    /// to boost the power.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_Combinable")]
    public bool GetCombinable()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Antenna_get_Combinable", args);
    }

    /// <summary>
    /// Gets whether the antenna can be combined with other antennae on the vessel
    /// to boost the power.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_Combinable")]
    public async Task<bool> GetCombinableAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Antenna_get_Combinable", args);
    }

    /// <summary>
    /// Exponent used to calculate the combined power of multiple antennae on a vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_CombinableExponent")]
    public double GetCombinableExponent()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Antenna_get_CombinableExponent", args);
    }

    /// <summary>
    /// Exponent used to calculate the combined power of multiple antennae on a vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_CombinableExponent")]
    public async Task<double> GetCombinableExponentAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Antenna_get_CombinableExponent", args);
    }

    /// <summary>
    /// Gets whether the antenna is deployable.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_Deployable")]
    public bool GetDeployable()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Antenna_get_Deployable", args);
    }

    /// <summary>
    /// Gets whether the antenna is deployable.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_Deployable")]
    public async Task<bool> GetDeployableAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Antenna_get_Deployable", args);
    }

    /// <summary>
    /// Gets whether the antenna is deployed.
    /// </summary>
    /// <remarks>
    /// Fixed antennas are always deployed.
    /// Returns an error if you try to deploy a fixed antenna.
    /// </remarks>
    [GetRpc("SpaceCenter", "Antenna_get_Deployed")]
    public bool GetDeployed()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Antenna_get_Deployed", args);
    }

    /// <summary>
    /// Gets whether the antenna is deployed.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// Fixed antennas are always deployed.
    /// Returns an error if you try to deploy a fixed antenna.
    /// </remarks>
    [GetRpc("SpaceCenter", "Antenna_get_Deployed")]
    public async Task<bool> GetDeployedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Antenna_get_Deployed", args);
    }

    /// <summary>
    /// Sets whether the antenna is deployed.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Antenna_set_Deployed")]
    public void SetDeployed(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "Antenna_set_Deployed", args);
    }

    /// <summary>
    /// Sets whether the antenna is deployed.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Antenna_set_Deployed")]
    public async Task SetDeployedAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "Antenna_set_Deployed", args);
    }

    /// <summary>
    /// Interval between sending packets in seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_PacketInterval")]
    public float GetPacketInterval()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "Antenna_get_PacketInterval", args);
    }

    /// <summary>
    /// Interval between sending packets in seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_PacketInterval")]
    public async Task<float> GetPacketIntervalAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "Antenna_get_PacketInterval", args);
    }

    /// <summary>
    /// Units of electric charge consumed per packet sent.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_PacketResourceCost")]
    public double GetPacketResourceCost()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Antenna_get_PacketResourceCost", args);
    }

    /// <summary>
    /// Units of electric charge consumed per packet sent.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_PacketResourceCost")]
    public async Task<double> GetPacketResourceCostAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Antenna_get_PacketResourceCost", args);
    }

    /// <summary>
    /// Amount of data sent per packet in Mits.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_PacketSize")]
    public float GetPacketSize()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "Antenna_get_PacketSize", args);
    }

    /// <summary>
    /// Amount of data sent per packet in Mits.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_PacketSize")]
    public async Task<float> GetPacketSizeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "Antenna_get_PacketSize", args);
    }

    /// <summary>
    /// Gets the part object for this antenna.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_Part")]
    public Part GetPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "Antenna_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this antenna.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "Antenna_get_Part", args);
    }

    /// <summary>
    /// Gets the power of the antenna.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_Power")]
    public double GetPower()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Antenna_get_Power", args);
    }

    /// <summary>
    /// Gets the power of the antenna.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_Power")]
    public async Task<double> GetPowerAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Antenna_get_Power", args);
    }

    /// <summary>
    /// Gets the current state of the antenna.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_State")]
    public AntennaState GetState()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<AntennaState>("SpaceCenter", "Antenna_get_State", args);
    }

    /// <summary>
    /// Gets the current state of the antenna.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Antenna_get_State")]
    public async Task<AntennaState> GetStateAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<AntennaState>("SpaceCenter", "Antenna_get_State", args);
    }
}
