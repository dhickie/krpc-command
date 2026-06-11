using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A place where craft can be launched from.
/// More of these can be added with mods like Kerbal Konstructs.
/// </summary>
public class LaunchSite : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal LaunchSite(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets the celestial body the launch site is on.
    /// </summary>
    [GetRpc("SpaceCenter", "LaunchSite_get_Body")]
    public CelestialBody GetBody()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<CelestialBody>("SpaceCenter", "LaunchSite_get_Body", args);
    }

    /// <summary>
    /// Gets the celestial body the launch site is on.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "LaunchSite_get_Body")]
    public async Task<CelestialBody> GetBodyAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<CelestialBody>("SpaceCenter", "LaunchSite_get_Body", args);
    }

    /// <summary>
    /// Which editor is normally used for this launch site.
    /// </summary>
    [GetRpc("SpaceCenter", "LaunchSite_get_EditorFacility")]
    public EditorFacility GetEditorFacility()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<EditorFacility>("SpaceCenter", "LaunchSite_get_EditorFacility", args);
    }

    /// <summary>
    /// Which editor is normally used for this launch site.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "LaunchSite_get_EditorFacility")]
    public async Task<EditorFacility> GetEditorFacilityAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<EditorFacility>("SpaceCenter", "LaunchSite_get_EditorFacility", args);
    }

    /// <summary>
    /// Gets the name of the launch site.
    /// </summary>
    [GetRpc("SpaceCenter", "LaunchSite_get_Name")]
    public string GetName()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<string>("SpaceCenter", "LaunchSite_get_Name", args);
    }

    /// <summary>
    /// Gets the name of the launch site.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "LaunchSite_get_Name")]
    public async Task<string> GetNameAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<string>("SpaceCenter", "LaunchSite_get_Name", args);
    }
}
