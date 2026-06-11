using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Experiment.GetData" />.
/// </summary>
public class ScienceData : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal ScienceData(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Data amount.
    /// </summary>
    [GetRpc("SpaceCenter", "ScienceData_get_DataAmount")]
    public float GetDataAmount()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "ScienceData_get_DataAmount", args);
    }

    /// <summary>
    /// Data amount.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ScienceData_get_DataAmount")]
    public async Task<float> GetDataAmountAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "ScienceData_get_DataAmount", args);
    }

    /// <summary>
    /// Science value.
    /// </summary>
    [GetRpc("SpaceCenter", "ScienceData_get_ScienceValue")]
    public float GetScienceValue()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "ScienceData_get_ScienceValue", args);
    }

    /// <summary>
    /// Science value.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ScienceData_get_ScienceValue")]
    public async Task<float> GetScienceValueAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "ScienceData_get_ScienceValue", args);
    }

    /// <summary>
    /// Transmit value.
    /// </summary>
    [GetRpc("SpaceCenter", "ScienceData_get_TransmitValue")]
    public float GetTransmitValue()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "ScienceData_get_TransmitValue", args);
    }

    /// <summary>
    /// Transmit value.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ScienceData_get_TransmitValue")]
    public async Task<float> GetTransmitValueAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "ScienceData_get_TransmitValue", args);
    }
}
