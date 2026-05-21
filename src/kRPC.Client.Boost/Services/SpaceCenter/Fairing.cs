using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A fairing. Obtained by calling <see cref="M:SpaceCenter.Part.GetFairing" />.
/// Supports both stock fairings, and those from the ProceduralFairings mod.
/// </summary>
public class Fairing : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Fairing(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Jettison the fairing. Has no effect if it has already been jettisoned.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_Jettison")]
    public void Jettison()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Fairing_Jettison", args);
    }

    /// <summary>
    /// Jettison the fairing. Has no effect if it has already been jettisoned.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_Jettison")]
    public async Task JettisonAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Fairing_Jettison", args);
    }

    /// <summary>
    /// Gets whether the fairing has been jettisoned.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_get_Jettisoned")]
    public bool GetJettisoned()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Fairing_get_Jettisoned", args);
    }

    /// <summary>
    /// Gets whether the fairing has been jettisoned.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_get_Jettisoned")]
    public async Task<bool> GetJettisonedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Fairing_get_Jettisoned", args);
    }

    /// <summary>
    /// Gets the part object for this fairing.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Fairing_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this fairing.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Fairing_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Fairing_get_Part", args);
    }
}
