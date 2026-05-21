using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

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
    [RpcAttribute ("SpaceCenter", "LaunchSite_get_Body")]
    public CelestialBody Body {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<CelestialBody> ("SpaceCenter", "LaunchSite_get_Body", args);
        }
    }

    /// <summary>
    /// Which editor is normally used for this launch site.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "LaunchSite_get_EditorFacility")]
    public EditorFacility EditorFacility {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<EditorFacility> ("SpaceCenter", "LaunchSite_get_EditorFacility", args);
        }
    }

    /// <summary>
    /// The name of the launch site.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "LaunchSite_get_Name")]
    public string Name {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "LaunchSite_get_Name", args);
        }
    }
}
