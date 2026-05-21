using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A launch clamp. Obtained by calling <see cref="M:SpaceCenter.Part.GetLaunchClamp" />.
/// </summary>
public class LaunchClamp : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public LaunchClamp(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Releases the docking clamp. Has no effect if the clamp has already been released.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchClamp_Release")]
    public void Release()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "LaunchClamp_Release", args);
    }

    /// <summary>
    /// Releases the docking clamp. Has no effect if the clamp has already been released.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchClamp_Release")]
    public async Task ReleaseAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "LaunchClamp_Release", args);
    }

    /// <summary>
    /// Gets the part object for this launch clamp.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchClamp_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "LaunchClamp_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this launch clamp.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchClamp_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "LaunchClamp_get_Part", args);
    }
}
