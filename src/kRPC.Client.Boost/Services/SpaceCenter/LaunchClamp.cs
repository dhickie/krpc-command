using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A launch clamp. Obtained by calling <see cref="M:SpaceCenter.Part.LaunchClamp" />.
/// </summary>
public class LaunchClamp : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public LaunchClamp (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Releases the docking clamp. Has no effect if the clamp has already been released.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "LaunchClamp_Release")]
    public void Release ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "LaunchClamp_Release", args);
    }

    /// <summary>
    /// The part object for this launch clamp.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "LaunchClamp_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "LaunchClamp_get_Part", args);
        }
    }
}
