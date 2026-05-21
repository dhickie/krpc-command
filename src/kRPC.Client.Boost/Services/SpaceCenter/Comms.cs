using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Used to interact with CommNet for a given vessel.
/// Obtained by calling <see cref="M:SpaceCenter.Vessel.GetComms" />.
/// </summary>
public class Comms : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Comms(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the vessel can communicate with KSC.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_CanCommunicate")]
    public bool GetCanCommunicate()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Comms_get_CanCommunicate", args);
    }

    /// <summary>
    /// Gets whether the vessel can communicate with KSC.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_CanCommunicate")]
    public async Task<bool> GetCanCommunicateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Comms_get_CanCommunicate", args);
    }

    /// <summary>
    /// Gets whether the vessel can transmit science data to KSC.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_CanTransmitScience")]
    public bool GetCanTransmitScience()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Comms_get_CanTransmitScience", args);
    }

    /// <summary>
    /// Gets whether the vessel can transmit science data to KSC.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_CanTransmitScience")]
    public async Task<bool> GetCanTransmitScienceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Comms_get_CanTransmitScience", args);
    }

    /// <summary>
    /// Gets the communication path used to control the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_ControlPath")]
    public IList<CommLink> GetControlPath()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<CommLink>>("SpaceCenter", "Comms_get_ControlPath", args);
    }

    /// <summary>
    /// Gets the communication path used to control the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_ControlPath")]
    public async Task<IList<CommLink>> GetControlPathAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<CommLink>>("SpaceCenter", "Comms_get_ControlPath", args);
    }

    /// <summary>
    /// Gets the combined power of all active antennae on the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_Power")]
    public double GetPower()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Comms_get_Power", args);
    }

    /// <summary>
    /// Gets the combined power of all active antennae on the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_Power")]
    public async Task<double> GetPowerAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Comms_get_Power", args);
    }

    /// <summary>
    /// Signal delay to KSC in seconds.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_SignalDelay")]
    public double GetSignalDelay()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Comms_get_SignalDelay", args);
    }

    /// <summary>
    /// Signal delay to KSC in seconds.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_SignalDelay")]
    public async Task<double> GetSignalDelayAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Comms_get_SignalDelay", args);
    }

    /// <summary>
    /// Signal strength to KSC.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_SignalStrength")]
    public double GetSignalStrength()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Comms_get_SignalStrength", args);
    }

    /// <summary>
    /// Signal strength to KSC.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Comms_get_SignalStrength")]
    public async Task<double> GetSignalStrengthAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Comms_get_SignalStrength", args);
    }
}
