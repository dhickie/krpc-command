using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A fairing. Obtained by calling <see cref="M:SpaceCenter.Part.GetFairing" />.
/// Supports both stock fairings, and those from the ProceduralFairings mod.
/// </summary>
public class Fairing : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal Fairing(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Jettison the fairing. Has no effect if it has already been jettisoned.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_Jettison")]
    public void Jettison()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        InvokeVoid("SpaceCenter", "Fairing_Jettison", args);
    }

    /// <summary>
    /// Jettison the fairing. Has no effect if it has already been jettisoned.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_Jettison")]
    public async Task JettisonAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        await InvokeVoidAsync("SpaceCenter", "Fairing_Jettison", args);
    }

    /// <summary>
    /// Gets whether the fairing has been jettisoned.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_get_Jettisoned")]
    public bool GetJettisoned()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "Fairing_get_Jettisoned", args);
    }

    /// <summary>
    /// Gets whether the fairing has been jettisoned.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_get_Jettisoned")]
    public async Task<bool> GetJettisonedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "Fairing_get_Jettisoned", args);
    }

    /// <summary>
    /// Gets the part object for this fairing.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_get_Part")]
    public Part GetPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "Fairing_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this fairing.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "Fairing_get_Part", args);
    }
}
