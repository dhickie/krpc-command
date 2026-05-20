using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A launch clamp. Obtained by calling <see cref="M:SpaceCenter.Part.LaunchClamp" />.
/// </summary>
public class LaunchClamp : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public LaunchClamp (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Releases the docking clamp. Has no effect if the clamp has already been released.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchClamp_Release")]
    public void Release ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.LaunchClamp))
        };
        connection.Invoke ("SpaceCenter", "LaunchClamp_Release", _args);
    }

    /// <summary>
    /// The part object for this launch clamp.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchClamp_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.LaunchClamp))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "LaunchClamp_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }
}