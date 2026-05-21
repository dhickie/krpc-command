using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A place where craft can be launched from.
/// More of these can be added with mods like Kerbal Konstructs.
/// </summary>
public class LaunchSite : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public LaunchSite (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// The celestial body the launch site is on.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchSite_get_Body")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody Body {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.LaunchSite))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "LaunchSite_get_Body", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody), connection);
        }
    }

    /// <summary>
    /// Which editor is normally used for this launch site.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchSite_get_EditorFacility")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.EditorFacility EditorFacility {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.LaunchSite))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "LaunchSite_get_EditorFacility", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.EditorFacility)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.EditorFacility), connection);
        }
    }

    /// <summary>
    /// The name of the launch site.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchSite_get_Name")]
    public string Name {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.LaunchSite))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "LaunchSite_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }
}
