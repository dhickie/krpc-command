using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

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
    public LaunchSite(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets the celestial body the launch site is on.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchSite_get_Body")]
    public CelestialBody GetBody()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<CelestialBody>("SpaceCenter", "LaunchSite_get_Body", args);
    }

    /// <summary>
    /// Gets the celestial body the launch site is on.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchSite_get_Body")]
    public async Task<CelestialBody> GetBodyAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<CelestialBody>("SpaceCenter", "LaunchSite_get_Body", args);
    }

    /// <summary>
    /// Which editor is normally used for this launch site.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchSite_get_EditorFacility")]
    public EditorFacility GetEditorFacility()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<EditorFacility>("SpaceCenter", "LaunchSite_get_EditorFacility", args);
    }

    /// <summary>
    /// Which editor is normally used for this launch site.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchSite_get_EditorFacility")]
    public async Task<EditorFacility> GetEditorFacilityAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<EditorFacility>("SpaceCenter", "LaunchSite_get_EditorFacility", args);
    }

    /// <summary>
    /// Gets the name of the launch site.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchSite_get_Name")]
    public string GetName()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "LaunchSite_get_Name", args);
    }

    /// <summary>
    /// Gets the name of the launch site.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "LaunchSite_get_Name")]
    public async Task<string> GetNameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "LaunchSite_get_Name", args);
    }
}
