using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An antenna. Obtained by calling <see cref="M:SpaceCenter.Part.GetAntenna" />.
/// </summary>
public class Antenna : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Antenna(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Cancel current transmission of data.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_Cancel")]
    public void Cancel()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Antenna_Cancel", args);
    }

    /// <summary>
    /// Cancel current transmission of data.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_Cancel")]
    public async Task CancelAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Antenna_Cancel", args);
    }

    /// <summary>
    /// Transmit data.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_Transmit")]
    public void Transmit()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Antenna_Transmit", args);
    }

    /// <summary>
    /// Transmit data.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_Transmit")]
    public async Task TransmitAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Antenna_Transmit", args);
    }

    /// <summary>
    /// Gets whether partial data transmission is permitted.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_AllowPartial")]
    public bool GetAllowPartial()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Antenna_get_AllowPartial", args);
    }

    /// <summary>
    /// Gets whether partial data transmission is permitted.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_AllowPartial")]
    public async Task<bool> GetAllowPartialAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Antenna_get_AllowPartial", args);
    }

    /// <summary>
    /// Sets whether partial data transmission is permitted.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Antenna_set_AllowPartial")]
    public void SetAllowPartial(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Antenna_set_AllowPartial", args);
    }

    /// <summary>
    /// Sets whether partial data transmission is permitted.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Antenna_set_AllowPartial")]
    public async Task SetAllowPartialAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Antenna_set_AllowPartial", args);
    }

    /// <summary>
    /// Gets whether data can be transmitted by this antenna.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_CanTransmit")]
    public bool GetCanTransmit()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Antenna_get_CanTransmit", args);
    }

    /// <summary>
    /// Gets whether data can be transmitted by this antenna.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_CanTransmit")]
    public async Task<bool> GetCanTransmitAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Antenna_get_CanTransmit", args);
    }

    /// <summary>
    /// Gets whether the antenna can be combined with other antennae on the vessel
    /// to boost the power.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_Combinable")]
    public bool GetCombinable()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Antenna_get_Combinable", args);
    }

    /// <summary>
    /// Gets whether the antenna can be combined with other antennae on the vessel
    /// to boost the power.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_Combinable")]
    public async Task<bool> GetCombinableAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Antenna_get_Combinable", args);
    }

    /// <summary>
    /// Exponent used to calculate the combined power of multiple antennae on a vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_CombinableExponent")]
    public double GetCombinableExponent()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Antenna_get_CombinableExponent", args);
    }

    /// <summary>
    /// Exponent used to calculate the combined power of multiple antennae on a vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_CombinableExponent")]
    public async Task<double> GetCombinableExponentAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Antenna_get_CombinableExponent", args);
    }

    /// <summary>
    /// Gets whether the antenna is deployable.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_Deployable")]
    public bool GetDeployable()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Antenna_get_Deployable", args);
    }

    /// <summary>
    /// Gets whether the antenna is deployable.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_Deployable")]
    public async Task<bool> GetDeployableAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Antenna_get_Deployable", args);
    }

    /// <summary>
    /// Gets whether the antenna is deployed.
    /// </summary>
    /// <remarks>
    /// Fixed antennas are always deployed.
    /// Returns an error if you try to deploy a fixed antenna.
    /// </remarks>
    [Rpc("SpaceCenter", "Antenna_get_Deployed")]
    public bool GetDeployed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Antenna_get_Deployed", args);
    }

    /// <summary>
    /// Gets whether the antenna is deployed.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// Fixed antennas are always deployed.
    /// Returns an error if you try to deploy a fixed antenna.
    /// </remarks>
    [Rpc("SpaceCenter", "Antenna_get_Deployed")]
    public async Task<bool> GetDeployedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Antenna_get_Deployed", args);
    }

    /// <summary>
    /// Sets whether the antenna is deployed.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Antenna_set_Deployed")]
    public void SetDeployed(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Antenna_set_Deployed", args);
    }

    /// <summary>
    /// Sets whether the antenna is deployed.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Antenna_set_Deployed")]
    public async Task SetDeployedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Antenna_set_Deployed", args);
    }

    /// <summary>
    /// Interval between sending packets in seconds.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_PacketInterval")]
    public float GetPacketInterval()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Antenna_get_PacketInterval", args);
    }

    /// <summary>
    /// Interval between sending packets in seconds.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_PacketInterval")]
    public async Task<float> GetPacketIntervalAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Antenna_get_PacketInterval", args);
    }

    /// <summary>
    /// Units of electric charge consumed per packet sent.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_PacketResourceCost")]
    public double GetPacketResourceCost()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Antenna_get_PacketResourceCost", args);
    }

    /// <summary>
    /// Units of electric charge consumed per packet sent.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_PacketResourceCost")]
    public async Task<double> GetPacketResourceCostAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Antenna_get_PacketResourceCost", args);
    }

    /// <summary>
    /// Amount of data sent per packet in Mits.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_PacketSize")]
    public float GetPacketSize()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Antenna_get_PacketSize", args);
    }

    /// <summary>
    /// Amount of data sent per packet in Mits.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_PacketSize")]
    public async Task<float> GetPacketSizeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Antenna_get_PacketSize", args);
    }

    /// <summary>
    /// Gets the part object for this antenna.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Antenna_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this antenna.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Antenna_get_Part", args);
    }

    /// <summary>
    /// Gets the power of the antenna.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_Power")]
    public double GetPower()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Antenna_get_Power", args);
    }

    /// <summary>
    /// Gets the power of the antenna.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_Power")]
    public async Task<double> GetPowerAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Antenna_get_Power", args);
    }

    /// <summary>
    /// Gets the current state of the antenna.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_State")]
    public AntennaState GetState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<AntennaState>("SpaceCenter", "Antenna_get_State", args);
    }

    /// <summary>
    /// Gets the current state of the antenna.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Antenna_get_State")]
    public async Task<AntennaState> GetStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<AntennaState>("SpaceCenter", "Antenna_get_State", args);
    }
}
