using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A cargo bay. Obtained by calling <see cref="M:SpaceCenter.Part.GetCargoBay" />.
/// </summary>
public class CargoBay : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CargoBay(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the cargo bay is open.
    /// </summary>
    [Rpc("SpaceCenter", "CargoBay_get_Open")]
    public bool GetOpen()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "CargoBay_get_Open", args);
    }

    /// <summary>
    /// Gets whether the cargo bay is open.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CargoBay_get_Open")]
    public async Task<bool> GetOpenAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "CargoBay_get_Open", args);
    }

    /// <summary>
    /// Sets whether the cargo bay is open.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "CargoBay_set_Open")]
    public void SetOpen(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "CargoBay_set_Open", args);
    }

    /// <summary>
    /// Sets whether the cargo bay is open.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "CargoBay_set_Open")]
    public async Task SetOpenAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "CargoBay_set_Open", args);
    }

    /// <summary>
    /// Gets the part object for this cargo bay.
    /// </summary>
    [Rpc("SpaceCenter", "CargoBay_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "CargoBay_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this cargo bay.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CargoBay_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "CargoBay_get_Part", args);
    }

    /// <summary>
    /// Gets the state of the cargo bay.
    /// </summary>
    [Rpc("SpaceCenter", "CargoBay_get_State")]
    public CargoBayState GetState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<CargoBayState>("SpaceCenter", "CargoBay_get_State", args);
    }

    /// <summary>
    /// Gets the state of the cargo bay.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CargoBay_get_State")]
    public async Task<CargoBayState> GetStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<CargoBayState>("SpaceCenter", "CargoBay_get_State", args);
    }
}
