using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Obtained by calling <see cref="M:SpaceCenter.Experiment.GetData" />.
/// </summary>
public class ScienceData : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ScienceData(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Data amount.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceData_get_DataAmount")]
    public float GetDataAmount()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ScienceData_get_DataAmount", args);
    }

    /// <summary>
    /// Data amount.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceData_get_DataAmount")]
    public async Task<float> GetDataAmountAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ScienceData_get_DataAmount", args);
    }

    /// <summary>
    /// Science value.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceData_get_ScienceValue")]
    public float GetScienceValue()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ScienceData_get_ScienceValue", args);
    }

    /// <summary>
    /// Science value.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceData_get_ScienceValue")]
    public async Task<float> GetScienceValueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ScienceData_get_ScienceValue", args);
    }

    /// <summary>
    /// Transmit value.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceData_get_TransmitValue")]
    public float GetTransmitValue()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ScienceData_get_TransmitValue", args);
    }

    /// <summary>
    /// Transmit value.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ScienceData_get_TransmitValue")]
    public async Task<float> GetTransmitValueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ScienceData_get_TransmitValue", args);
    }
}
