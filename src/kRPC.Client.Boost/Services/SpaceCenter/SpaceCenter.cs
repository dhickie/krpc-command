using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;
using MathNet.Spatial.Euclidean;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// SpaceCenter service.
/// </summary>
public class SpaceCenter : ServiceObject
{
    internal SpaceCenter(IConnectionMultiplexer connection) : base(connection)
    {
    }

    /// <summary>
    /// Returns <c>true</c> if regular "on-rails" time warp can be used, at the specified warp
    /// <paramref name="factor" />. The maximum time warp rate is limited by various things,
    /// including how close the active vessel is to a planet. See
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">the KSP wiki</a>
    /// for details.
    /// </summary>
    /// <param name="factor">The warp factor to check.</param>
    [GetRpc("SpaceCenter", "CanRailsWarpAt")]
    public bool CanRailsWarpAt(int factor = 1)
    {
        var args = new ProcedureArgument[]
        {
            factor
        };
        return InvokeNonNullable<bool>("SpaceCenter", "CanRailsWarpAt", args);
    }

    /// <summary>
    /// Returns <c>true</c> if regular "on-rails" time warp can be used, at the specified warp
    /// <paramref name="factor" />. The maximum time warp rate is limited by various things,
    /// including how close the active vessel is to a planet. See
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">the KSP wiki</a>
    /// for details.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="factor">The warp factor to check.</param>
    [GetRpc("SpaceCenter", "CanRailsWarpAt")]
    public async Task<bool> CanRailsWarpAtAsync(int factor = 1)
    {
        var args = new ProcedureArgument[]
        {
            factor
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "CanRailsWarpAt", args);
    }

    /// <summary>
    /// Whether the current flight can be reverted to launch.
    /// </summary>
    [GetRpc("SpaceCenter", "CanRevertToLaunch")]
    public bool CanRevertToLaunch()
    {
        return InvokeNonNullable<bool>("SpaceCenter", "CanRevertToLaunch");
    }

    /// <summary>
    /// Whether the current flight can be reverted to launch.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CanRevertToLaunch")]
    public async Task<bool> CanRevertToLaunchAsync()
    {
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "CanRevertToLaunch");
    }

    /// <summary>
    /// Clears the current target.
    /// </summary>
    [SetRpc("SpaceCenter", "ClearTarget")]
    public void ClearTarget()
    {
        InvokeVoid("SpaceCenter", "ClearTarget");
    }

    /// <summary>
    /// Clears the current target.
    /// Executes asynchronously.
    /// </summary>
    [SetRpc("SpaceCenter", "ClearTarget")]
    public async Task ClearTargetAsync()
    {
        await InvokeVoidAsync("SpaceCenter", "ClearTarget");
    }

    /// <summary>
    /// Creates a Kerbal.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="job"></param>
    /// <param name="male"></param>
    [SetRpc("SpaceCenter", "CreateKerbal")]
    public void CreateKerbal(string name, string job, bool male)
    {
        var args = new ProcedureArgument[]
        {
            name,
            job,
            male
        };
        InvokeVoid("SpaceCenter", "CreateKerbal", args);
    }

    /// <summary>
    /// Creates a Kerbal.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="job"></param>
    /// <param name="male"></param>
    [SetRpc("SpaceCenter", "CreateKerbal")]
    public async Task CreateKerbalAsync(string name, string job, bool male)
    {
        var args = new ProcedureArgument[]
        {
            name,
            job,
            male
        };
        await InvokeVoidAsync("SpaceCenter", "CreateKerbal", args);
    }

    /// <summary>
    /// Find a Kerbal by name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns><c>null</c> if no Kerbal with the given name exists.</returns>
    [GetRpc("SpaceCenter", "GetKerbal")]
    public CrewMember? GetKerbal(string name)
    {
        var args = new ProcedureArgument[]
        {
            name
        };
        return InvokeNullable<CrewMember>("SpaceCenter", "GetKerbal", args);
    }

    /// <summary>
    /// Find a Kerbal by name.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name"></param>
    /// <returns><c>null</c> if no Kerbal with the given name exists.</returns>
    [GetRpc("SpaceCenter", "GetKerbal")]
    public async Task<CrewMember?> GetKerbalAsync(string name)
    {
        var args = new ProcedureArgument[]
        {
            name
        };
        return await InvokeNullableAsync<CrewMember>("SpaceCenter", "GetKerbal", args);
    }

    /// <summary>
    /// Launch a vessel.
    /// </summary>
    /// <param name="craftDirectory">Name of the directory in the current saves
    /// "Ships" directory, that contains the craft file.
    /// For example <c>"VAB"</c> or <c>"SPH"</c>.</param>
    /// <param name="name">Name of the vessel to launch. This is the name of the ".craft" file
    /// in the save directory, without the ".craft" file extension.</param>
    /// <param name="launchSite">Name of the launch site. For example <c>"LaunchPad"</c> or
    /// <c>"Runway"</c>.</param>
    /// <param name="recover">If true and there is a vessel on the launch site,
    /// recover it before launching.</param>
    /// <param name="crew">If not <c>null</c>, a list of names of Kerbals to place in the craft. Otherwise the crew will use default assignments.</param>
    /// <param name="flagUrl">If not <c>null</c>, the asset URL of the mission flag to use for the launch.</param>
    /// <remarks>
    /// Throws an exception if any of the games pre-flight checks fail.
    /// </remarks>
    [SetRpc("SpaceCenter", "LaunchVessel")]
    public void LaunchVessel(string craftDirectory, string name, string launchSite, bool recover = true, IList<string>? crew = null, string flagUrl = "")
    {
        var args = new ProcedureArgument[]
        {
            craftDirectory,
            name,
            launchSite,
            recover,
            new(crew, typeof(List<string>)),
            flagUrl
        };
        InvokeVoid("SpaceCenter", "LaunchVessel", args);
    }

    /// <summary>
    /// Launch a vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="craftDirectory">Name of the directory in the current saves
    /// "Ships" directory, that contains the craft file.
    /// For example <c>"VAB"</c> or <c>"SPH"</c>.</param>
    /// <param name="name">Name of the vessel to launch. This is the name of the ".craft" file
    /// in the save directory, without the ".craft" file extension.</param>
    /// <param name="launchSite">Name of the launch site. For example <c>"LaunchPad"</c> or
    /// <c>"Runway"</c>.</param>
    /// <param name="recover">If true and there is a vessel on the launch site,
    /// recover it before launching.</param>
    /// <param name="crew">If not <c>null</c>, a list of names of Kerbals to place in the craft. Otherwise the crew will use default assignments.</param>
    /// <param name="flagUrl">If not <c>null</c>, the asset URL of the mission flag to use for the launch.</param>
    /// <remarks>
    /// Throws an exception if any of the games pre-flight checks fail.
    /// </remarks>
    [SetRpc("SpaceCenter", "LaunchVessel")]
    public async Task LaunchVesselAsync(string craftDirectory, string name, string launchSite, bool recover = true, IList<string>? crew = null, string flagUrl = "")
    {
        var args = new ProcedureArgument[]
        {
            craftDirectory,
            name,
            launchSite,
            recover,
            new(crew, typeof(List<string>)),
            flagUrl
        };
        await InvokeVoidAsync("SpaceCenter", "LaunchVessel", args);
    }

    /// <summary>
    /// Launch a new vessel from the SPH onto the runway.
    /// </summary>
    /// <param name="name">Name of the vessel to launch.</param>
    /// <param name="recover">If true and there is a vessel on the runway,
    /// recover it before launching.</param>
    /// <remarks>
    /// This is equivalent to calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.LaunchVessel" /> with the craft directory
    /// set to "SPH" and the launch site set to "Runway".
    /// Throws an exception if any of the games pre-flight checks fail.
    /// </remarks>
    [SetRpc("SpaceCenter", "LaunchVesselFromSPH")]
    public void LaunchVesselFromSPH(string name, bool recover = true)
    {
        var args = new ProcedureArgument[]
        {
            name,
            recover
        };
        InvokeVoid("SpaceCenter", "LaunchVesselFromSPH", args);
    }

    /// <summary>
    /// Launch a new vessel from the SPH onto the runway.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the vessel to launch.</param>
    /// <param name="recover">If true and there is a vessel on the runway,
    /// recover it before launching.</param>
    /// <remarks>
    /// This is equivalent to calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.LaunchVessel" /> with the craft directory
    /// set to "SPH" and the launch site set to "Runway".
    /// Throws an exception if any of the games pre-flight checks fail.
    /// </remarks>
    [SetRpc("SpaceCenter", "LaunchVesselFromSPH")]
    public async Task LaunchVesselFromSPHAsync(string name, bool recover = true)
    {
        var args = new ProcedureArgument[]
        {
            name,
            recover
        };
        await InvokeVoidAsync("SpaceCenter", "LaunchVesselFromSPH", args);
    }

    /// <summary>
    /// Launch a new vessel from the VAB onto the launchpad.
    /// </summary>
    /// <param name="name">Name of the vessel to launch.</param>
    /// <param name="recover">If true and there is a vessel on the launch pad,
    /// recover it before launching.</param>
    /// <remarks>
    /// This is equivalent to calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.LaunchVessel" /> with the craft directory
    /// set to "VAB" and the launch site set to "LaunchPad".
    /// Throws an exception if any of the games pre-flight checks fail.
    /// </remarks>
    [SetRpc("SpaceCenter", "LaunchVesselFromVAB")]
    public void LaunchVesselFromVAB(string name, bool recover = true)
    {
        var args = new ProcedureArgument[]
        {
            name,
            recover
        };
        InvokeVoid("SpaceCenter", "LaunchVesselFromVAB", args);
    }

    /// <summary>
    /// Launch a new vessel from the VAB onto the launchpad.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the vessel to launch.</param>
    /// <param name="recover">If true and there is a vessel on the launch pad,
    /// recover it before launching.</param>
    /// <remarks>
    /// This is equivalent to calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.LaunchVessel" /> with the craft directory
    /// set to "VAB" and the launch site set to "LaunchPad".
    /// Throws an exception if any of the games pre-flight checks fail.
    /// </remarks>
    [SetRpc("SpaceCenter", "LaunchVesselFromVAB")]
    public async Task LaunchVesselFromVABAsync(string name, bool recover = true)
    {
        var args = new ProcedureArgument[]
        {
            name,
            recover
        };
        await InvokeVoidAsync("SpaceCenter", "LaunchVesselFromVAB", args);
    }

    /// <summary>
    /// Returns a list of vessels from the given <paramref name="craftDirectory" />
    /// that can be launched.
    /// </summary>
    /// <param name="craftDirectory">Name of the directory in the current saves
    /// "Ships" directory. For example <c>"VAB"</c> or <c>"SPH"</c>.</param>
    [GetRpc("SpaceCenter", "LaunchableVessels")]
    public IList<string> GetLaunchableVessels(string craftDirectory)
    {
        var args = new ProcedureArgument[]
        {
            craftDirectory
        };
        return InvokeNonNullable<List<string>>("SpaceCenter", "LaunchableVessels", args);
    }

    /// <summary>
    /// Returns a list of vessels from the given <paramref name="craftDirectory" />
    /// that can be launched.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="craftDirectory">Name of the directory in the current saves
    /// "Ships" directory. For example <c>"VAB"</c> or <c>"SPH"</c>.</param>
    [GetRpc("SpaceCenter", "LaunchableVessels")]
    public async Task<IList<string>> GetLaunchableVesselsAsync(string craftDirectory)
    {
        var args = new ProcedureArgument[]
        {
            craftDirectory
        };
        return await InvokeNonNullableAsync<List<string>>("SpaceCenter", "LaunchableVessels", args);
    }

    /// <summary>
    /// Load the game with the given name.
    /// This will create a load a save file called <c>name.sfs</c> from the folder of the
    /// current save game.
    /// </summary>
    /// <param name="name">Name of the save.</param>
    [SetRpc("SpaceCenter", "Load")]
    public void Load(string name)
    {
        var args = new ProcedureArgument[]
        {
            name
        };
        InvokeVoid("SpaceCenter", "Load", args);
    }

    /// <summary>
    /// Load the game with the given name.
    /// This will create a load a save file called <c>name.sfs</c> from the folder of the
    /// current save game.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the save.</param>
    [SetRpc("SpaceCenter", "Load")]
    public async Task LoadAsync(string name)
    {
        var args = new ProcedureArgument[]
        {
            name
        };
        await InvokeVoidAsync("SpaceCenter", "Load", args);
    }

    /// <summary>
    /// Switch to the space center view.
    /// </summary>
    [SetRpc("SpaceCenter", "LoadSpaceCenter")]
    public void LoadSpaceCenter()
    {
        InvokeVoid("SpaceCenter", "LoadSpaceCenter");
    }

    /// <summary>
    /// Switch to the space center view.
    /// Executes asynchronously.
    /// </summary>
    [SetRpc("SpaceCenter", "LoadSpaceCenter")]
    public async Task LoadSpaceCenterAsync()
    {
        await InvokeVoidAsync("SpaceCenter", "LoadSpaceCenter");
    }

    /// <summary>
    /// Load a quicksave.
    /// </summary>
    /// <remarks>
    /// This is the same as calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.Load" /> with the name "quicksave".
    /// </remarks>
    [SetRpc("SpaceCenter", "Quickload")]
    public void Quickload()
    {
        InvokeVoid("SpaceCenter", "Quickload");
    }

    /// <summary>
    /// Load a quicksave.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This is the same as calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.Load" /> with the name "quicksave".
    /// </remarks>
    [SetRpc("SpaceCenter", "Quickload")]
    public async Task QuickloadAsync()
    {
        await InvokeVoidAsync("SpaceCenter", "Quickload");
    }

    /// <summary>
    /// Save a quicksave.
    /// </summary>
    /// <remarks>
    /// This is the same as calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.Save" /> with the name "quicksave".
    /// </remarks>
    [SetRpc("SpaceCenter", "Quicksave")]
    public void Quicksave()
    {
        InvokeVoid("SpaceCenter", "Quicksave");
    }

    /// <summary>
    /// Save a quicksave.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This is the same as calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.Save" /> with the name "quicksave".
    /// </remarks>
    [SetRpc("SpaceCenter", "Quicksave")]
    public async Task QuicksaveAsync()
    {
        await InvokeVoidAsync("SpaceCenter", "Quicksave");
    }

    /// <summary>
    /// Cast a ray from a given position in a given direction, and return the distance to the hit point.
    /// If no hit occurs, returns infinity.
    /// </summary>
    /// <param name="position">Position, as a vector, of the origin of the ray.</param>
    /// <param name="direction">Direction of the ray, as a unit vector.</param>
    /// <param name="referenceFrame">The reference frame that the position and direction are in.</param>
    /// <returns>The distance to the hit, in meters, or infinity if there was no hit.</returns>
    [GetRpc("SpaceCenter", "RaycastDistance")]
    public double RaycastDistance(Vector3D position, Vector3D direction, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            position,
            direction,
            referenceFrame
        };
        return InvokeNonNullable<double>("SpaceCenter", "RaycastDistance", args);
    }

    /// <summary>
    /// Cast a ray from a given position in a given direction, and return the distance to the hit point.
    /// If no hit occurs, returns infinity.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="position">Position, as a vector, of the origin of the ray.</param>
    /// <param name="direction">Direction of the ray, as a unit vector.</param>
    /// <param name="referenceFrame">The reference frame that the position and direction are in.</param>
    /// <returns>The distance to the hit, in meters, or infinity if there was no hit.</returns>
    [GetRpc("SpaceCenter", "RaycastDistance")]
    public async Task<double> RaycastDistanceAsync(Vector3D position, Vector3D direction, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            position,
            direction,
            referenceFrame
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "RaycastDistance", args);
    }

    /// <summary>
    /// Cast a ray from a given position in a given direction, and return the part that it hits.
    /// If no hit occurs, returns <c>null</c>.
    /// </summary>
    /// <param name="position">Position, as a vector, of the origin of the ray.</param>
    /// <param name="direction">Direction of the ray, as a unit vector.</param>
    /// <param name="referenceFrame">The reference frame that the position and direction are in.</param>
    /// <returns>The part that was hit or <c>null</c> if there was no hit.</returns>
    [GetRpc("SpaceCenter", "RaycastPart")]
    public Part? RaycastPart(Vector3D position, Vector3D direction, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            position,
            direction,
            referenceFrame
        };
        return InvokeNullable<Part>("SpaceCenter", "RaycastPart", args);
    }

    /// <summary>
    /// Cast a ray from a given position in a given direction, and return the part that it hits.
    /// If no hit occurs, returns <c>null</c>.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="position">Position, as a vector, of the origin of the ray.</param>
    /// <param name="direction">Direction of the ray, as a unit vector.</param>
    /// <param name="referenceFrame">The reference frame that the position and direction are in.</param>
    /// <returns>The part that was hit or <c>null</c> if there was no hit.</returns>
    [GetRpc("SpaceCenter", "RaycastPart")]
    public async Task<Part?> RaycastPartAsync(Vector3D position, Vector3D direction, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            position,
            direction,
            referenceFrame
        };
        return await InvokeNullableAsync<Part>("SpaceCenter", "RaycastPart", args);
    }

    /// <summary>
    /// Revert the current flight to launch.
    /// </summary>
    [SetRpc("SpaceCenter", "RevertToLaunch")]
    public void RevertToLaunch()
    {
        InvokeVoid("SpaceCenter", "RevertToLaunch");
    }

    /// <summary>
    /// Revert the current flight to launch.
    /// Executes asynchronously.
    /// </summary>
    [SetRpc("SpaceCenter", "RevertToLaunch")]
    public async Task RevertToLaunchAsync()
    {
        await InvokeVoidAsync("SpaceCenter", "RevertToLaunch");
    }

    /// <summary>
    /// Save the game with a given name.
    /// This will create a save file called <c>name.sfs</c> in the folder of the
    /// current save game.
    /// </summary>
    /// <param name="name">Name of the save.</param>
    [SetRpc("SpaceCenter", "Save")]
    public void Save(string name)
    {
        var args = new ProcedureArgument[]
        {
            name
        };
        InvokeVoid("SpaceCenter", "Save", args);
    }

    /// <summary>
    /// Save the game with a given name.
    /// This will create a save file called <c>name.sfs</c> in the folder of the
    /// current save game.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the save.</param>
    [SetRpc("SpaceCenter", "Save")]
    public async Task SaveAsync(string name)
    {
        var args = new ProcedureArgument[]
        {
            name
        };
        await InvokeVoidAsync("SpaceCenter", "Save", args);
    }

    /// <summary>
    /// Saves a screenshot.
    /// </summary>
    /// <param name="filePath">The path of the file to save.</param>
    /// <param name="scale">Resolution scaling factor</param>
    [SetRpc("SpaceCenter", "Screenshot")]
    public void Screenshot(string filePath, int scale = 1)
    {
        var args = new ProcedureArgument[]
        {
            filePath,
            scale
        };
        InvokeVoid("SpaceCenter", "Screenshot", args);
    }

    /// <summary>
    /// Saves a screenshot.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="filePath">The path of the file to save.</param>
    /// <param name="scale">Resolution scaling factor</param>
    [SetRpc("SpaceCenter", "Screenshot")]
    public async Task ScreenshotAsync(string filePath, int scale = 1)
    {
        var args = new ProcedureArgument[]
        {
            filePath,
            scale
        };
        await InvokeVoidAsync("SpaceCenter", "Screenshot", args);
    }

    /// <summary>
    /// Transfers a crew member to a different part.
    /// </summary>
    /// <param name="crewMember">The crew member to transfer.</param>
    /// <param name="targetPart">The part to move them to.</param>
    [SetRpc("SpaceCenter", "TransferCrew")]
    public void TransferCrew(CrewMember crewMember, Part targetPart)
    {
        var args = new ProcedureArgument[]
        {
            crewMember,
            targetPart
        };
        InvokeVoid("SpaceCenter", "TransferCrew", args);
    }

    /// <summary>
    /// Transfers a crew member to a different part.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="crewMember">The crew member to transfer.</param>
    /// <param name="targetPart">The part to move them to.</param>
    [SetRpc("SpaceCenter", "TransferCrew")]
    public async Task TransferCrewAsync(CrewMember crewMember, Part targetPart)
    {
        var args = new ProcedureArgument[]
        {
            crewMember,
            targetPart
        };
        await InvokeVoidAsync("SpaceCenter", "TransferCrew", args);
    }

    /// <summary>
    /// Converts a direction from one reference frame to another.
    /// </summary>
    /// <param name="direction">Direction, as a vector, in reference frame
    /// <paramref name="from" />. </param>
    /// <param name="from">The reference frame that the direction is in.</param>
    /// <param name="to">The reference frame to covert the direction to.</param>
    /// <returns>The corresponding direction, as a vector, in reference frame
    /// <paramref name="to" />.</returns>
    [GetRpc("SpaceCenter", "TransformDirection")]
    public Vector3D TransformDirection(Vector3D direction, ReferenceFrame from, ReferenceFrame to)
    {
        var args = new ProcedureArgument[]
        {
            direction,
            from,
            to
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "TransformDirection", args);
    }

    /// <summary>
    /// Converts a direction from one reference frame to another.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="direction">Direction, as a vector, in reference frame
    /// <paramref name="from" />. </param>
    /// <param name="from">The reference frame that the direction is in.</param>
    /// <param name="to">The reference frame to covert the direction to.</param>
    /// <returns>The corresponding direction, as a vector, in reference frame
    /// <paramref name="to" />.</returns>
    [GetRpc("SpaceCenter", "TransformDirection")]
    public async Task<Vector3D> TransformDirectionAsync(Vector3D direction, ReferenceFrame from, ReferenceFrame to)
    {
        var args = new ProcedureArgument[]
        {
            direction,
            from,
            to
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "TransformDirection", args);
    }

    /// <summary>
    /// Converts a position from one reference frame to another.
    /// </summary>
    /// <param name="position">Position, as a vector, in reference frame
    /// <paramref name="from" />.</param>
    /// <param name="from">The reference frame that the position is in.</param>
    /// <param name="to">The reference frame to covert the position to.</param>
    /// <returns>The corresponding position, as a vector, in reference frame
    /// <paramref name="to" />.</returns>
    [GetRpc("SpaceCenter", "TransformPosition")]
    public Vector3D TransformPosition(Vector3D position, ReferenceFrame from, ReferenceFrame to)
    {
        var args = new ProcedureArgument[]
        {
            position,
            from,
            to
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "TransformPosition", args);
    }

    /// <summary>
    /// Converts a position from one reference frame to another.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="position">Position, as a vector, in reference frame
    /// <paramref name="from" />.</param>
    /// <param name="from">The reference frame that the position is in.</param>
    /// <param name="to">The reference frame to covert the position to.</param>
    /// <returns>The corresponding position, as a vector, in reference frame
    /// <paramref name="to" />.</returns>
    [GetRpc("SpaceCenter", "TransformPosition")]
    public async Task<Vector3D> TransformPositionAsync(Vector3D position, ReferenceFrame from, ReferenceFrame to)
    {
        var args = new ProcedureArgument[]
        {
            position,
            from,
            to
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "TransformPosition", args);
    }

    /// <summary>
    /// Converts a rotation from one reference frame to another.
    /// </summary>
    /// <param name="rotation">Rotation, as a quaternion of the form <math>(x, y, z, w)</math>,
    /// in reference frame <paramref name="from" />.</param>
    /// <param name="from">The reference frame that the rotation is in.</param>
    /// <param name="to">The reference frame to covert the rotation to.</param>
    /// <returns>The corresponding rotation, as a quaternion of the form
    /// <math>(x, y, z, w)</math>, in reference frame <paramref name="to" />.</returns>
    [GetRpc("SpaceCenter", "TransformRotation")]
    public Quaternion TransformRotation(Quaternion rotation, ReferenceFrame from, ReferenceFrame to)
    {
        var args = new ProcedureArgument[]
        {
            rotation,
            from,
            to
        };
        return InvokeNonNullable<Quaternion>("SpaceCenter", "TransformRotation", args);
    }

    /// <summary>
    /// Converts a rotation from one reference frame to another.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="rotation">Rotation, as a quaternion of the form <math>(x, y, z, w)</math>,
    /// in reference frame <paramref name="from" />.</param>
    /// <param name="from">The reference frame that the rotation is in.</param>
    /// <param name="to">The reference frame to covert the rotation to.</param>
    /// <returns>The corresponding rotation, as a quaternion of the form
    /// <math>(x, y, z, w)</math>, in reference frame <paramref name="to" />.</returns>
    [GetRpc("SpaceCenter", "TransformRotation")]
    public async Task<Quaternion> TransformRotationAsync(Quaternion rotation, ReferenceFrame from, ReferenceFrame to)
    {
        var args = new ProcedureArgument[]
        {
            rotation,
            from,
            to
        };
        return await InvokeNonNullableAsync<Quaternion>("SpaceCenter", "TransformRotation", args);
    }

    /// <summary>
    /// Converts a velocity (acting at the specified position) from one reference frame
    /// to another. The position is required to take the relative angular velocity of the
    /// reference frames into account.
    /// </summary>
    /// <param name="position">Position, as a vector, in reference frame
    /// <paramref name="from" />.</param>
    /// <param name="velocity">Velocity, as a vector that points in the direction of travel and
    /// whose magnitude is the speed in meters per second, in reference frame
    /// <paramref name="from" />.</param>
    /// <param name="from">The reference frame that the position and velocity are in.</param>
    /// <param name="to">The reference frame to covert the velocity to.</param>
    /// <returns>The corresponding velocity, as a vector, in reference frame
    /// <paramref name="to" />.</returns>
    [GetRpc("SpaceCenter", "TransformVelocity")]
    public Vector3D TransformVelocity(Vector3D position, Vector3D velocity, ReferenceFrame from, ReferenceFrame to)
    {
        var args = new ProcedureArgument[]
        {
            position,
            velocity,
            from,
            to
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "TransformVelocity", args);
    }

    /// <summary>
    /// Converts a velocity (acting at the specified position) from one reference frame
    /// to another. The position is required to take the relative angular velocity of the
    /// reference frames into account.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="position">Position, as a vector, in reference frame
    /// <paramref name="from" />.</param>
    /// <param name="velocity">Velocity, as a vector that points in the direction of travel and
    /// whose magnitude is the speed in meters per second, in reference frame
    /// <paramref name="from" />.</param>
    /// <param name="from">The reference frame that the position and velocity are in.</param>
    /// <param name="to">The reference frame to covert the velocity to.</param>
    /// <returns>The corresponding velocity, as a vector, in reference frame
    /// <paramref name="to" />.</returns>
    [GetRpc("SpaceCenter", "TransformVelocity")]
    public async Task<Vector3D> TransformVelocityAsync(Vector3D position, Vector3D velocity, ReferenceFrame from, ReferenceFrame to)
    {
        var args = new ProcedureArgument[]
        {
            position,
            velocity,
            from,
            to
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "TransformVelocity", args);
    }

    /// <summary>
    /// Uses time acceleration to warp forward to a time in the future, specified
    /// by universal time <paramref name="ut" />. This call blocks until the desired
    /// time is reached. Uses regular "on-rails" or physical time warp as appropriate.
    /// For example, physical time warp is used when the active vessel is traveling
    /// through an atmosphere. When using regular "on-rails" time warp, the warp
    /// rate is limited by <paramref name="maxRailsRate" />, and when using physical
    /// time warp, the warp rate is limited by <paramref name="maxPhysicsRate" />.
    /// </summary>
    /// <param name="ut">The universal time to warp to, in seconds.</param>
    /// <param name="maxRailsRate">The maximum warp rate in regular "on-rails" time warp.
    /// </param>
    /// <param name="maxPhysicsRate">The maximum warp rate in physical time warp.</param>
    /// <returns>When the time warp is complete.</returns>
    [SetRpc("SpaceCenter", "WarpTo")]
    public void WarpTo(double ut, float maxRailsRate = 100000.0f, float maxPhysicsRate = 2.0f)
    {
        var args = new ProcedureArgument[]
        {
            ut,
            maxRailsRate,
            maxPhysicsRate
        };
        InvokeVoid("SpaceCenter", "WarpTo", args);
    }

    /// <summary>
    /// Uses time acceleration to warp forward to a time in the future, specified
    /// by universal time <paramref name="ut" />. This call blocks until the desired
    /// time is reached. Uses regular "on-rails" or physical time warp as appropriate.
    /// For example, physical time warp is used when the active vessel is traveling
    /// through an atmosphere. When using regular "on-rails" time warp, the warp
    /// rate is limited by <paramref name="maxRailsRate" />, and when using physical
    /// time warp, the warp rate is limited by <paramref name="maxPhysicsRate" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="ut">The universal time to warp to, in seconds.</param>
    /// <param name="maxRailsRate">The maximum warp rate in regular "on-rails" time warp.
    /// </param>
    /// <param name="maxPhysicsRate">The maximum warp rate in physical time warp.</param>
    /// <returns>When the time warp is complete.</returns>
    [SetRpc("SpaceCenter", "WarpTo")]
    public async Task WarpToAsync(double ut, float maxRailsRate = 100000.0f, float maxPhysicsRate = 2.0f)
    {
        var args = new ProcedureArgument[]
        {
            ut,
            maxRailsRate,
            maxPhysicsRate
        };
        await InvokeVoidAsync("SpaceCenter", "WarpTo", args);
    }

    /// <summary>
    /// Gets the currently active vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "get_ActiveVessel")]
    public Vessel GetActiveVessel()
    {
        return InvokeNonNullable<Vessel>("SpaceCenter", "get_ActiveVessel");
    }

    /// <summary>
    /// Gets the currently active vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_ActiveVessel")]
    public async Task<Vessel> GetActiveVesselAsync()
    {
        return await InvokeNonNullableAsync<Vessel>("SpaceCenter", "get_ActiveVessel");
    }

    /// <summary>
    /// Sets the currently active vessel.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_ActiveVessel")]
    public void SetActiveVessel(Vessel value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        InvokeVoid("SpaceCenter", "set_ActiveVessel", args);
    }

    /// <summary>
    /// Sets the currently active vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_ActiveVessel")]
    public async Task SetActiveVesselAsync(Vessel value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        await InvokeVoidAsync("SpaceCenter", "set_ActiveVessel", args);
    }

    /// <summary>
    /// Gets the alarm manager.
    /// </summary>
    [GetRpc("SpaceCenter", "get_AlarmManager")]
    public AlarmManager GetAlarmManager()
    {
        return InvokeNonNullable<AlarmManager>("SpaceCenter", "get_AlarmManager");
    }

    /// <summary>
    /// Gets the alarm manager.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_AlarmManager")]
    public async Task<AlarmManager> GetAlarmManagerAsync()
    {
        return await InvokeNonNullableAsync<AlarmManager>("SpaceCenter", "get_AlarmManager");
    }

    /// <summary>
    /// Gets a dictionary of all celestial bodies (planets, moons, etc.) in the game,
    /// keyed by the name of the body.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Bodies")]
    public IDictionary<string,CelestialBody> GetBodies()
    {
        return InvokeNonNullable<Dictionary<string,CelestialBody>>("SpaceCenter", "get_Bodies");
    }

    /// <summary>
    /// Gets a dictionary of all celestial bodies (planets, moons, etc.) in the game,
    /// keyed by the name of the body.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Bodies")]
    public async Task<IDictionary<string,CelestialBody>> GetBodiesAsync()
    {
        return await InvokeNonNullableAsync<Dictionary<string,CelestialBody>>("SpaceCenter", "get_Bodies");
    }

    /// <summary>
    /// Gets an object that can be used to control the camera.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Camera")]
    public Camera GetCamera()
    {
        return InvokeNonNullable<Camera>("SpaceCenter", "get_Camera");
    }

    /// <summary>
    /// Gets an object that can be used to control the camera.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Camera")]
    public async Task<Camera> GetCameraAsync()
    {
        return await InvokeNonNullableAsync<Camera>("SpaceCenter", "get_Camera");
    }

    /// <summary>
    /// Gets the contract manager.
    /// </summary>
    [GetRpc("SpaceCenter", "get_ContractManager")]
    public ContractManager GetContractManager()
    {
        return InvokeNonNullable<ContractManager>("SpaceCenter", "get_ContractManager");
    }

    /// <summary>
    /// Gets the contract manager.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_ContractManager")]
    public async Task<ContractManager> GetContractManagerAsync()
    {
        return await InvokeNonNullableAsync<ContractManager>("SpaceCenter", "get_ContractManager");
    }

    /// <summary>
    /// Gets whether <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a> is installed.
    /// </summary>
    [GetRpc("SpaceCenter", "get_FARAvailable")]
    public bool GetFARAvailable()
    {
        return InvokeNonNullable<bool>("SpaceCenter", "get_FARAvailable");
    }

    /// <summary>
    /// Gets whether <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a> is installed.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_FARAvailable")]
    public async Task<bool> GetFARAvailableAsync()
    {
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "get_FARAvailable");
    }

    /// <summary>
    /// Gets the current amount of funds.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Funds")]
    public double GetFunds()
    {
        return InvokeNonNullable<double>("SpaceCenter", "get_Funds");
    }

    /// <summary>
    /// Gets the current amount of funds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Funds")]
    public async Task<double> GetFundsAsync()
    {
        return await InvokeNonNullableAsync<double>("SpaceCenter", "get_Funds");
    }

    /// <summary>
    /// Gets the value of the <a href="https://en.wikipedia.org/wiki/Gravitational_constant">
    /// gravitational constant</a> G in <math>N(m/kg)^2</math>.
    /// </summary>
    [GetRpc("SpaceCenter", "get_G")]
    public double GetG()
    {
        return InvokeNonNullable<double>("SpaceCenter", "get_G");
    }

    /// <summary>
    /// Gets the value of the <a href="https://en.wikipedia.org/wiki/Gravitational_constant">
    /// gravitational constant</a> G in <math>N(m/kg)^2</math>.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_G")]
    public async Task<double> GetGAsync()
    {
        return await InvokeNonNullableAsync<double>("SpaceCenter", "get_G");
    }

    /// <summary>
    /// Gets the current mode the game is in.
    /// </summary>
    [GetRpc("SpaceCenter", "get_GameMode")]
    public GameMode GetGameMode()
    {
        return InvokeNonNullable<GameMode>("SpaceCenter", "get_GameMode");
    }

    /// <summary>
    /// Gets the current mode the game is in.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_GameMode")]
    public async Task<GameMode> GetGameModeAsync()
    {
        return await InvokeNonNullableAsync<GameMode>("SpaceCenter", "get_GameMode");
    }

    /// <summary>
    /// Gets a list of available launch sites.
    /// </summary>
    [GetRpc("SpaceCenter", "get_LaunchSites")]
    public IList<LaunchSite> GetLaunchSites()
    {
        return InvokeNonNullable<List<LaunchSite>>("SpaceCenter", "get_LaunchSites");
    }

    /// <summary>
    /// Gets a list of available launch sites.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_LaunchSites")]
    public async Task<IList<LaunchSite>> GetLaunchSitesAsync()
    {
        return await InvokeNonNullableAsync<List<LaunchSite>>("SpaceCenter", "get_LaunchSites");
    }

    /// <summary>
    /// Gets the visible objects in map mode.
    /// </summary>
    [GetRpc("SpaceCenter", "get_MapFilter")]
    public MapFilterType GetMapFilter()
    {
        return InvokeNonNullable<MapFilterType>("SpaceCenter", "get_MapFilter");
    }

    /// <summary>
    /// Gets the visible objects in map mode.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_MapFilter")]
    public async Task<MapFilterType> GetMapFilterAsync()
    {
        return await InvokeNonNullableAsync<MapFilterType>("SpaceCenter", "get_MapFilter");
    }

    /// <summary>
    /// Sets the visible objects in map mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_MapFilter")]
    public void SetMapFilter(MapFilterType value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        InvokeVoid("SpaceCenter", "set_MapFilter", args);
    }

    /// <summary>
    /// Sets the visible objects in map mode.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_MapFilter")]
    public async Task SetMapFilterAsync(MapFilterType value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        await InvokeVoidAsync("SpaceCenter", "set_MapFilter", args);
    }

    /// <summary>
    /// Gets the current maximum regular "on-rails" warp factor that can be set.
    /// A value between 0 and 7 inclusive. See
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">the KSP wiki</a>
    /// for details.
    /// </summary>
    [GetRpc("SpaceCenter", "get_MaximumRailsWarpFactor")]
    public int GetMaximumRailsWarpFactor()
    {
        return InvokeNonNullable<int>("SpaceCenter", "get_MaximumRailsWarpFactor");
    }

    /// <summary>
    /// Gets the current maximum regular "on-rails" warp factor that can be set.
    /// A value between 0 and 7 inclusive. See
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">the KSP wiki</a>
    /// for details.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_MaximumRailsWarpFactor")]
    public async Task<int> GetMaximumRailsWarpFactorAsync()
    {
        return await InvokeNonNullableAsync<int>("SpaceCenter", "get_MaximumRailsWarpFactor");
    }

    /// <summary>
    /// Gets whether the navball is visible.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Navball")]
    public bool GetNavball()
    {
        return InvokeNonNullable<bool>("SpaceCenter", "get_Navball");
    }

    /// <summary>
    /// Gets whether the navball is visible.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Navball")]
    public async Task<bool> GetNavballAsync()
    {
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "get_Navball");
    }

    /// <summary>
    /// Sets whether the navball is visible.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_Navball")]
    public void SetNavball(bool value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        InvokeVoid("SpaceCenter", "set_Navball", args);
    }

    /// <summary>
    /// Sets whether the navball is visible.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_Navball")]
    public async Task SetNavballAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        await InvokeVoidAsync("SpaceCenter", "set_Navball", args);
    }

    /// <summary>
    /// Gets the physical time warp rate. A value between 0 and 3 inclusive. 0 means
    /// no time warp. Returns 0 if regular "on-rails" time warp is active.
    /// </summary>
    [GetRpc("SpaceCenter", "get_PhysicsWarpFactor")]
    public int GetPhysicsWarpFactor()
    {
        return InvokeNonNullable<int>("SpaceCenter", "get_PhysicsWarpFactor");
    }

    /// <summary>
    /// Gets the physical time warp rate. A value between 0 and 3 inclusive. 0 means
    /// no time warp. Returns 0 if regular "on-rails" time warp is active.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_PhysicsWarpFactor")]
    public async Task<int> GetPhysicsWarpFactorAsync()
    {
        return await InvokeNonNullableAsync<int>("SpaceCenter", "get_PhysicsWarpFactor");
    }

    /// <summary>
    /// Sets the physical time warp rate. A value between 0 and 3 inclusive. 0 means
    /// no time warp. Returns 0 if regular "on-rails" time warp is active.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_PhysicsWarpFactor")]
    public void SetPhysicsWarpFactor(int value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        InvokeVoid("SpaceCenter", "set_PhysicsWarpFactor", args);
    }

    /// <summary>
    /// Sets the physical time warp rate. A value between 0 and 3 inclusive. 0 means
    /// no time warp. Returns 0 if regular "on-rails" time warp is active.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_PhysicsWarpFactor")]
    public async Task SetPhysicsWarpFactorAsync(int value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        await InvokeVoidAsync("SpaceCenter", "set_PhysicsWarpFactor", args);
    }

    /// <summary>
    /// Gets the time warp rate, using regular "on-rails" time warp. A value between
    /// 0 and 7 inclusive. 0 means no time warp. Returns 0 if physical time warp
    /// is active.
    ///
    /// If requested time warp factor cannot be set, it will be set to the next
    /// lowest possible value. For example, if the vessel is too close to a
    /// planet. See <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">
    /// the KSP wiki</a> for details.
    /// </summary>
    [GetRpc("SpaceCenter", "get_RailsWarpFactor")]
    public int GetRailsWarpFactor()
    {
        return InvokeNonNullable<int>("SpaceCenter", "get_RailsWarpFactor");
    }

    /// <summary>
    /// Gets the time warp rate, using regular "on-rails" time warp. A value between
    /// 0 and 7 inclusive. 0 means no time warp. Returns 0 if physical time warp
    /// is active.
    ///
    /// If requested time warp factor cannot be set, it will be set to the next
    /// lowest possible value. For example, if the vessel is too close to a
    /// planet. See <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">
    /// the KSP wiki</a> for details.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_RailsWarpFactor")]
    public async Task<int> GetRailsWarpFactorAsync()
    {
        return await InvokeNonNullableAsync<int>("SpaceCenter", "get_RailsWarpFactor");
    }

    /// <summary>
    /// Sets the time warp rate, using regular "on-rails" time warp. A value between
    /// 0 and 7 inclusive. 0 means no time warp. Returns 0 if physical time warp
    /// is active.
    ///
    /// If requested time warp factor cannot be set, it will be set to the next
    /// lowest possible value. For example, if the vessel is too close to a
    /// planet. See <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">
    /// the KSP wiki</a> for details.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_RailsWarpFactor")]
    public void SetRailsWarpFactor(int value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        InvokeVoid("SpaceCenter", "set_RailsWarpFactor", args);
    }

    /// <summary>
    /// Sets the time warp rate, using regular "on-rails" time warp. A value between
    /// 0 and 7 inclusive. 0 means no time warp. Returns 0 if physical time warp
    /// is active.
    ///
    /// If requested time warp factor cannot be set, it will be set to the next
    /// lowest possible value. For example, if the vessel is too close to a
    /// planet. See <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">
    /// the KSP wiki</a> for details.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_RailsWarpFactor")]
    public async Task SetRailsWarpFactorAsync(int value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        await InvokeVoidAsync("SpaceCenter", "set_RailsWarpFactor", args);
    }

    /// <summary>
    /// Gets the current amount of reputation.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Reputation")]
    public float GetReputation()
    {
        return InvokeNonNullable<float>("SpaceCenter", "get_Reputation");
    }

    /// <summary>
    /// Gets the current amount of reputation.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Reputation")]
    public async Task<float> GetReputationAsync()
    {
        return await InvokeNonNullableAsync<float>("SpaceCenter", "get_Reputation");
    }

    /// <summary>
    /// Gets the current amount of science.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Science")]
    public float GetScience()
    {
        return InvokeNonNullable<float>("SpaceCenter", "get_Science");
    }

    /// <summary>
    /// Gets the current amount of science.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Science")]
    public async Task<float> GetScienceAsync()
    {
        return await InvokeNonNullableAsync<float>("SpaceCenter", "get_Science");
    }

    /// <summary>
    /// Gets the currently targeted celestial body.
    /// </summary>
    [GetRpc("SpaceCenter", "get_TargetBody")]
    public CelestialBody GetTargetBody()
    {
        return InvokeNonNullable<CelestialBody>("SpaceCenter", "get_TargetBody");
    }

    /// <summary>
    /// Gets the currently targeted celestial body.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_TargetBody")]
    public async Task<CelestialBody> GetTargetBodyAsync()
    {
        return await InvokeNonNullableAsync<CelestialBody>("SpaceCenter", "get_TargetBody");
    }

    /// <summary>
    /// Sets the currently targeted celestial body.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_TargetBody")]
    public void SetTargetBody(CelestialBody value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        InvokeVoid("SpaceCenter", "set_TargetBody", args);
    }

    /// <summary>
    /// Sets the currently targeted celestial body.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_TargetBody")]
    public async Task SetTargetBodyAsync(CelestialBody value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        await InvokeVoidAsync("SpaceCenter", "set_TargetBody", args);
    }

    /// <summary>
    /// Gets the currently targeted docking port.
    /// </summary>
    [GetRpc("SpaceCenter", "get_TargetDockingPort")]
    public DockingPort GetTargetDockingPort()
    {
        return InvokeNonNullable<DockingPort>("SpaceCenter", "get_TargetDockingPort");
    }

    /// <summary>
    /// Gets the currently targeted docking port.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_TargetDockingPort")]
    public async Task<DockingPort> GetTargetDockingPortAsync()
    {
        return await InvokeNonNullableAsync<DockingPort>("SpaceCenter", "get_TargetDockingPort");
    }

    /// <summary>
    /// Sets the currently targeted docking port.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_TargetDockingPort")]
    public void SetTargetDockingPort(DockingPort value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        InvokeVoid("SpaceCenter", "set_TargetDockingPort", args);
    }

    /// <summary>
    /// Sets the currently targeted docking port.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_TargetDockingPort")]
    public async Task SetTargetDockingPortAsync(DockingPort value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        await InvokeVoidAsync("SpaceCenter", "set_TargetDockingPort", args);
    }

    /// <summary>
    /// Gets the currently targeted vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "get_TargetVessel")]
    public Vessel GetTargetVessel()
    {
        return InvokeNonNullable<Vessel>("SpaceCenter", "get_TargetVessel");
    }

    /// <summary>
    /// Gets the currently targeted vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_TargetVessel")]
    public async Task<Vessel> GetTargetVesselAsync()
    {
        return await InvokeNonNullableAsync<Vessel>("SpaceCenter", "get_TargetVessel");
    }

    /// <summary>
    /// Sets the currently targeted vessel.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_TargetVessel")]
    public void SetTargetVessel(Vessel value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        InvokeVoid("SpaceCenter", "set_TargetVessel", args);
    }

    /// <summary>
    /// Sets the currently targeted vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_TargetVessel")]
    public async Task SetTargetVesselAsync(Vessel value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        await InvokeVoidAsync("SpaceCenter", "set_TargetVessel", args);
    }

    /// <summary>
    /// Gets whether the UI is visible.
    /// </summary>
    [GetRpc("SpaceCenter", "get_UIVisible")]
    public bool GetUIVisible()
    {
        return InvokeNonNullable<bool>("SpaceCenter", "get_UIVisible");
    }

    /// <summary>
    /// Gets whether the UI is visible.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_UIVisible")]
    public async Task<bool> GetUIVisibleAsync()
    {
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "get_UIVisible");
    }

    /// <summary>
    /// Sets whether the UI is visible.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_UIVisible")]
    public void SetUIVisible(bool value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        InvokeVoid("SpaceCenter", "set_UIVisible", args);
    }

    /// <summary>
    /// Sets whether the UI is visible.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "set_UIVisible")]
    public async Task SetUIVisibleAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            value
        };
        await InvokeVoidAsync("SpaceCenter", "set_UIVisible", args);
    }

    /// <summary>
    /// Gets the current universal time in seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "get_UT")]
    public double GetUT()
    {
        return InvokeNonNullable<double>("SpaceCenter", "get_UT");
    }

    /// <summary>
    /// Gets the current universal time in seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_UT")]
    public async Task<double> GetUTAsync()
    {
        return await InvokeNonNullableAsync<double>("SpaceCenter", "get_UT");
    }

    /// <summary>
    /// Gets a list of all the vessels in the game.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Vessels")]
    public IList<Vessel> GetVessels()
    {
        return InvokeNonNullable<List<Vessel>>("SpaceCenter", "get_Vessels");
    }

    /// <summary>
    /// Gets a list of all the vessels in the game.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_Vessels")]
    public async Task<IList<Vessel>> GetVesselsAsync()
    {
        return await InvokeNonNullableAsync<List<Vessel>>("SpaceCenter", "get_Vessels");
    }

    /// <summary>
    /// Gets the current warp factor. This is the index of the rate at which time
    /// is passing for either regular "on-rails" or physical time warp. Returns 0
    /// if time warp is not active. When in on-rails time warp, this is equal to
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetRailsWarpFactor" />, and in physics time warp, this is equal to
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetPhysicsWarpFactor" />.
    /// </summary>
    [GetRpc("SpaceCenter", "get_WarpFactor")]
    public float GetWarpFactor()
    {
        return InvokeNonNullable<float>("SpaceCenter", "get_WarpFactor");
    }

    /// <summary>
    /// Gets the current warp factor. This is the index of the rate at which time
    /// is passing for either regular "on-rails" or physical time warp. Returns 0
    /// if time warp is not active. When in on-rails time warp, this is equal to
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetRailsWarpFactor" />, and in physics time warp, this is equal to
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetPhysicsWarpFactor" />.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_WarpFactor")]
    public async Task<float> GetWarpFactorAsync()
    {
        return await InvokeNonNullableAsync<float>("SpaceCenter", "get_WarpFactor");
    }

    /// <summary>
    /// Gets the current time warp mode. Returns <see cref="F:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.WarpMode.None" /> if time
    /// warp is not active, <see cref="F:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.WarpMode.Rails" /> if regular "on-rails" time warp
    /// is active, or <see cref="F:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.WarpMode.Physics" /> if physical time warp is active.
    /// </summary>
    [GetRpc("SpaceCenter", "get_WarpMode")]
    public WarpMode GetWarpMode()
    {
        return InvokeNonNullable<WarpMode>("SpaceCenter", "get_WarpMode");
    }

    /// <summary>
    /// Gets the current time warp mode. Returns <see cref="F:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.WarpMode.None" /> if time
    /// warp is not active, <see cref="F:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.WarpMode.Rails" /> if regular "on-rails" time warp
    /// is active, or <see cref="F:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.WarpMode.Physics" /> if physical time warp is active.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_WarpMode")]
    public async Task<WarpMode> GetWarpModeAsync()
    {
        return await InvokeNonNullableAsync<WarpMode>("SpaceCenter", "get_WarpMode");
    }

    /// <summary>
    /// Gets the current warp rate. This is the rate at which time is passing for
    /// either on-rails or physical time warp. For example, a value of 10 means
    /// time is passing 10x faster than normal. Returns 1 if time warp is not
    /// active.
    /// </summary>
    [GetRpc("SpaceCenter", "get_WarpRate")]
    public float GetWarpRate()
    {
        return InvokeNonNullable<float>("SpaceCenter", "get_WarpRate");
    }

    /// <summary>
    /// Gets the current warp rate. This is the rate at which time is passing for
    /// either on-rails or physical time warp. For example, a value of 10 means
    /// time is passing 10x faster than normal. Returns 1 if time warp is not
    /// active.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_WarpRate")]
    public async Task<float> GetWarpRateAsync()
    {
        return await InvokeNonNullableAsync<float>("SpaceCenter", "get_WarpRate");
    }

    /// <summary>
    /// Gets the waypoint manager.
    /// </summary>
    [GetRpc("SpaceCenter", "get_WaypointManager")]
    public WaypointManager GetWaypointManager()
    {
        return InvokeNonNullable<WaypointManager>("SpaceCenter", "get_WaypointManager");
    }

    /// <summary>
    /// Gets the waypoint manager.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "get_WaypointManager")]
    public async Task<WaypointManager> GetWaypointManagerAsync()
    {
        return await InvokeNonNullableAsync<WaypointManager>("SpaceCenter", "get_WaypointManager");
    }
}
