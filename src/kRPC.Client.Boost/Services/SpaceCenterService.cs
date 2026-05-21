using kRPC.Client.Boost.Connection;
using System;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;
using kRPC.Client.Boost.Services.SpaceCenter;

namespace kRPC.Client.Boost.Services;

/// <summary>
/// SpaceCenter service.
/// </summary>
public class SpaceCenterService
{
    private readonly ConnectionMultiplexer _connection;

    internal SpaceCenterService(ConnectionMultiplexer serverConnection)
    {
        _connection = serverConnection;
    }

    /// <summary>
    /// Returns <c>true</c> if regular "on-rails" time warp can be used, at the specified warp
    /// <paramref name="factor" />. The maximum time warp rate is limited by various things,
    /// including how close the active vessel is to a planet. See
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">the KSP wiki</a>
    /// for details.
    /// </summary>
    /// <param name="factor">The warp factor to check.</param>
    [RpcAttribute("SpaceCenter", "CanRailsWarpAt")]
    public bool CanRailsWarpAt(int factor = 1)
    {
        var _args = new object[]
        {
            factor
        };
        return _connection.Invoke<bool>("SpaceCenter", "CanRailsWarpAt", _args);
    }

    /// <summary>
    /// Whether the current flight can be reverted to launch.
    /// </summary>
    [RpcAttribute("SpaceCenter", "CanRevertToLaunch")]
    public bool CanRevertToLaunch()
    {
        return _connection.Invoke<bool>("SpaceCenter", "CanRevertToLaunch");
    }

    /// <summary>
    /// Clears the current target.
    /// </summary>
    [RpcAttribute("SpaceCenter", "ClearTarget")]
    public void ClearTarget()
    {
        _connection.Invoke("SpaceCenter", "ClearTarget");
    }

    /// <summary>
    /// Creates a Kerbal.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="job"></param>
    /// <param name="male"></param>
    [RpcAttribute("SpaceCenter", "CreateKerbal")]
    public void CreateKerbal(string name, string job, bool male)
    {
        var _args = new object[]
        {
            name,
            job,
            male
        };
        _connection.Invoke("SpaceCenter", "CreateKerbal", _args);
    }

    /// <summary>
    /// Find a Kerbal by name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns><c>null</c> if no Kerbal with the given name exists.</returns>
    [RpcAttribute("SpaceCenter", "GetKerbal")]
    public CrewMember GetKerbal(string name)
    {
        var _args = new object[]
        {
            name
        };
        return _connection.Invoke<CrewMember>("SpaceCenter", "GetKerbal", _args);
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
    [RpcAttribute("SpaceCenter", "LaunchVessel")]
    public void LaunchVessel(string craftDirectory, string name, string launchSite, bool recover = true, IList<string> crew = null, string flagUrl = "")
    {
        var _args = new object[]
        {
            craftDirectory,
            name,
            launchSite,
            recover,
            crew ?? null,
            flagUrl
        };
        _connection.Invoke("SpaceCenter", "LaunchVessel", _args);
    }

    /// <summary>
    /// Launch a new vessel from the SPH onto the runway.
    /// </summary>
    /// <param name="name">Name of the vessel to launch.</param>
    /// <param name="recover">If true and there is a vessel on the runway,
    /// recover it before launching.</param>
    /// <remarks>
    /// This is equivalent to calling <see cref="M:SpaceCenter.LaunchVessel" /> with the craft directory
    /// set to "SPH" and the launch site set to "Runway".
    /// Throws an exception if any of the games pre-flight checks fail.
    /// </remarks>
    [RpcAttribute("SpaceCenter", "LaunchVesselFromSPH")]
    public void LaunchVesselFromSPH(string name, bool recover = true)
    {
        var _args = new object[]
        {
            name,
            recover
        };
        _connection.Invoke("SpaceCenter", "LaunchVesselFromSPH", _args);
    }

    /// <summary>
    /// Launch a new vessel from the VAB onto the launchpad.
    /// </summary>
    /// <param name="name">Name of the vessel to launch.</param>
    /// <param name="recover">If true and there is a vessel on the launch pad,
    /// recover it before launching.</param>
    /// <remarks>
    /// This is equivalent to calling <see cref="M:SpaceCenter.LaunchVessel" /> with the craft directory
    /// set to "VAB" and the launch site set to "LaunchPad".
    /// Throws an exception if any of the games pre-flight checks fail.
    /// </remarks>
    [RpcAttribute("SpaceCenter", "LaunchVesselFromVAB")]
    public void LaunchVesselFromVAB(string name, bool recover = true)
    {
        var _args = new object[]
        {
            name,
            recover
        };
        _connection.Invoke("SpaceCenter", "LaunchVesselFromVAB", _args);
    }

    /// <summary>
    /// Returns a list of vessels from the given <paramref name="craftDirectory" />
    /// that can be launched.
    /// </summary>
    /// <param name="craftDirectory">Name of the directory in the current saves
    /// "Ships" directory. For example <c>"VAB"</c> or <c>"SPH"</c>.</param>
    [RpcAttribute("SpaceCenter", "LaunchableVessels")]
    public IList<string> LaunchableVessels(string craftDirectory)
    {
        var _args = new object[]
        {
            craftDirectory
        };
        return _connection.Invoke<IList<string>>("SpaceCenter", "LaunchableVessels", _args);
    }

    /// <summary>
    /// Load the game with the given name.
    /// This will create a load a save file called <c>name.sfs</c> from the folder of the
    /// current save game.
    /// </summary>
    /// <param name="name">Name of the save.</param>
    [RpcAttribute("SpaceCenter", "Load")]
    public void Load(string name)
    {
        var _args = new object[]
        {
            name
        };
        _connection.Invoke("SpaceCenter", "Load", _args);
    }

    /// <summary>
    /// Switch to the space center view.
    /// </summary>
    [RpcAttribute("SpaceCenter", "LoadSpaceCenter")]
    public void LoadSpaceCenter()
    {
        _connection.Invoke("SpaceCenter", "LoadSpaceCenter");
    }

    /// <summary>
    /// Load a quicksave.
    /// </summary>
    /// <remarks>
    /// This is the same as calling <see cref="M:SpaceCenter.Load" /> with the name "quicksave".
    /// </remarks>
    [RpcAttribute("SpaceCenter", "Quickload")]
    public void Quickload()
    {
        _connection.Invoke("SpaceCenter", "Quickload");
    }

    /// <summary>
    /// Save a quicksave.
    /// </summary>
    /// <remarks>
    /// This is the same as calling <see cref="M:SpaceCenter.Save" /> with the name "quicksave".
    /// </remarks>
    [RpcAttribute("SpaceCenter", "Quicksave")]
    public void Quicksave()
    {
        _connection.Invoke("SpaceCenter", "Quicksave");
    }

    /// <summary>
    /// Cast a ray from a given position in a given direction, and return the distance to the hit point.
    /// If no hit occurs, returns infinity.
    /// </summary>
    /// <param name="position">Position, as a vector, of the origin of the ray.</param>
    /// <param name="direction">Direction of the ray, as a unit vector.</param>
    /// <param name="referenceFrame">The reference frame that the position and direction are in.</param>
    /// <returns>The distance to the hit, in meters, or infinity if there was no hit.</returns>
    [RpcAttribute("SpaceCenter", "RaycastDistance")]
    public double RaycastDistance(Tuple<double,double,double> position, Tuple<double,double,double> direction, ReferenceFrame referenceFrame)
    {
        var _args = new object[]
        {
            position,
            direction,
            referenceFrame
        };
        return _connection.Invoke<double>("SpaceCenter", "RaycastDistance", _args);
    }

    /// <summary>
    /// Cast a ray from a given position in a given direction, and return the part that it hits.
    /// If no hit occurs, returns <c>null</c>.
    /// </summary>
    /// <param name="position">Position, as a vector, of the origin of the ray.</param>
    /// <param name="direction">Direction of the ray, as a unit vector.</param>
    /// <param name="referenceFrame">The reference frame that the position and direction are in.</param>
    /// <returns>The part that was hit or <c>null</c> if there was no hit.</returns>
    [RpcAttribute("SpaceCenter", "RaycastPart")]
    public Part RaycastPart(Tuple<double,double,double> position, Tuple<double,double,double> direction, ReferenceFrame referenceFrame)
    {
        var _args = new object[]
        {
            position,
            direction,
            referenceFrame
        };
        return _connection.Invoke<Part>("SpaceCenter", "RaycastPart", _args);
    }

    /// <summary>
    /// Revert the current flight to launch.
    /// </summary>
    [RpcAttribute("SpaceCenter", "RevertToLaunch")]
    public void RevertToLaunch()
    {
        _connection.Invoke("SpaceCenter", "RevertToLaunch");
    }

    /// <summary>
    /// Save the game with a given name.
    /// This will create a save file called <c>name.sfs</c> in the folder of the
    /// current save game.
    /// </summary>
    /// <param name="name">Name of the save.</param>
    [RpcAttribute("SpaceCenter", "Save")]
    public void Save(string name)
    {
        var _args = new object[]
        {
            name
        };
        _connection.Invoke("SpaceCenter", "Save", _args);
    }

    /// <summary>
    /// Saves a screenshot.
    /// </summary>
    /// <param name="filePath">The path of the file to save.</param>
    /// <param name="scale">Resolution scaling factor</param>
    [RpcAttribute("SpaceCenter", "Screenshot")]
    public void Screenshot(string filePath, int scale = 1)
    {
        var _args = new object[]
        {
            filePath,
            scale
        };
        _connection.Invoke("SpaceCenter", "Screenshot", _args);
    }

    /// <summary>
    /// Transfers a crew member to a different part.
    /// </summary>
    /// <param name="crewMember">The crew member to transfer.</param>
    /// <param name="targetPart">The part to move them to.</param>
    [RpcAttribute("SpaceCenter", "TransferCrew")]
    public void TransferCrew(CrewMember crewMember, Part targetPart)
    {
        var _args = new object[]
        {
            crewMember,
            targetPart
        };
        _connection.Invoke("SpaceCenter", "TransferCrew", _args);
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
    [RpcAttribute("SpaceCenter", "TransformDirection")]
    public Tuple<double,double,double> TransformDirection(Tuple<double,double,double> direction, ReferenceFrame from, ReferenceFrame to)
    {
        var _args = new object[]
        {
            direction,
            from,
            to
        };
        return _connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "TransformDirection", _args);
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
    [RpcAttribute("SpaceCenter", "TransformPosition")]
    public Tuple<double,double,double> TransformPosition(Tuple<double,double,double> position, ReferenceFrame from, ReferenceFrame to)
    {
        var _args = new object[]
        {
            position,
            from,
            to
        };
        return _connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "TransformPosition", _args);
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
    [RpcAttribute("SpaceCenter", "TransformRotation")]
    public Tuple<double,double,double,double> TransformRotation(Tuple<double,double,double,double> rotation, ReferenceFrame from, ReferenceFrame to)
    {
        var _args = new object[]
        {
            rotation,
            from,
            to
        };
        return _connection.Invoke<Tuple<double,double,double,double>>("SpaceCenter", "TransformRotation", _args);
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
    [RpcAttribute("SpaceCenter", "TransformVelocity")]
    public Tuple<double,double,double> TransformVelocity(Tuple<double,double,double> position, Tuple<double,double,double> velocity, ReferenceFrame from, ReferenceFrame to)
    {
        var _args = new object[]
        {
            position,
            velocity,
            from,
            to
        };
        return _connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "TransformVelocity", _args);
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
    [RpcAttribute("SpaceCenter", "WarpTo")]
    public void WarpTo(double ut, float maxRailsRate = 100000.0f, float maxPhysicsRate = 2.0f)
    {
        var _args = new object[]
        {
            ut,
            maxRailsRate,
            maxPhysicsRate
        };
        _connection.Invoke("SpaceCenter", "WarpTo", _args);
    }

    /// <summary>
    /// Gets the currently active vessel.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_ActiveVessel")]
    public Vessel GetActiveVessel()
    {
        return _connection.Invoke<Vessel>("SpaceCenter", "get_ActiveVessel");
    }

    /// <summary>
    /// Sets the currently active vessel.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetActiveVessel(Vessel value)
    {
        var _args = new object[]
        {
            value
        };
        _connection.Invoke("SpaceCenter", "set_ActiveVessel", _args);
    }

    /// <summary>
    /// Gets the alarm manager.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_AlarmManager")]
    public AlarmManager GetAlarmManager()
    {
        return _connection.Invoke<AlarmManager>("SpaceCenter", "get_AlarmManager");
    }

    /// <summary>
    /// Gets a dictionary of all celestial bodies (planets, moons, etc.) in the game,
    /// keyed by the name of the body.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_Bodies")]
    public IDictionary<string,CelestialBody> GetBodies()
    {
        return _connection.Invoke<IDictionary<string,CelestialBody>>("SpaceCenter", "get_Bodies");
    }

    /// <summary>
    /// Gets an object that can be used to control the camera.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_Camera")]
    public Camera GetCamera()
    {
        return _connection.Invoke<Camera>("SpaceCenter", "get_Camera");
    }

    /// <summary>
    /// Gets the contract manager.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_ContractManager")]
    public ContractManager GetContractManager()
    {
        return _connection.Invoke<ContractManager>("SpaceCenter", "get_ContractManager");
    }

    /// <summary>
    /// Gets whether <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a> is installed.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_FARAvailable")]
    public bool GetFARAvailable()
    {
        return _connection.Invoke<bool>("SpaceCenter", "get_FARAvailable");
    }

    /// <summary>
    /// Gets the current amount of funds.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_Funds")]
    public double GetFunds()
    {
        return _connection.Invoke<double>("SpaceCenter", "get_Funds");
    }

    /// <summary>
    /// Gets the value of the <a href="https://en.wikipedia.org/wiki/Gravitational_constant">
    /// gravitational constant</a> G in <math>N(m/kg)^2</math>.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_G")]
    public double GetG()
    {
        return _connection.Invoke<double>("SpaceCenter", "get_G");
    }

    /// <summary>
    /// Gets the current mode the game is in.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_GameMode")]
    public GameMode GetGameMode()
    {
        return _connection.Invoke<GameMode>("SpaceCenter", "get_GameMode");
    }

    /// <summary>
    /// Gets a list of available launch sites.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_LaunchSites")]
    public IList<LaunchSite> GetLaunchSites()
    {
        return _connection.Invoke<IList<LaunchSite>>("SpaceCenter", "get_LaunchSites");
    }

    /// <summary>
    /// Gets the visible objects in map mode.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_MapFilter")]
    public MapFilterType GetMapFilter()
    {
        return _connection.Invoke<MapFilterType>("SpaceCenter", "get_MapFilter");
    }

    /// <summary>
    /// Sets the visible objects in map mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetMapFilter(MapFilterType value)
    {
        var _args = new object[]
        {
            value
        };
        _connection.Invoke("SpaceCenter", "set_MapFilter", _args);
    }

    /// <summary>
    /// Gets the current maximum regular "on-rails" warp factor that can be set.
    /// A value between 0 and 7 inclusive. See
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">the KSP wiki</a>
    /// for details.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_MaximumRailsWarpFactor")]
    public int GetMaximumRailsWarpFactor()
    {
        return _connection.Invoke<int>("SpaceCenter", "get_MaximumRailsWarpFactor");
    }

    /// <summary>
    /// Gets whether the navball is visible.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_Navball")]
    public bool GetNavball()
    {
        return _connection.Invoke<bool>("SpaceCenter", "get_Navball");
    }

    /// <summary>
    /// Sets whether the navball is visible.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetNavball(bool value)
    {
        var _args = new object[]
        {
            value
        };
        _connection.Invoke("SpaceCenter", "set_Navball", _args);
    }

    /// <summary>
    /// Gets the physical time warp rate. A value between 0 and 3 inclusive. 0 means
    /// no time warp. Returns 0 if regular "on-rails" time warp is active.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_PhysicsWarpFactor")]
    public int GetPhysicsWarpFactor()
    {
        return _connection.Invoke<int>("SpaceCenter", "get_PhysicsWarpFactor");
    }

    /// <summary>
    /// Sets the physical time warp rate. A value between 0 and 3 inclusive. 0 means
    /// no time warp. Returns 0 if regular "on-rails" time warp is active.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetPhysicsWarpFactor(int value)
    {
        var _args = new object[]
        {
            value
        };
        _connection.Invoke("SpaceCenter", "set_PhysicsWarpFactor", _args);
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
    [RpcAttribute("SpaceCenter", "get_RailsWarpFactor")]
    public int GetRailsWarpFactor()
    {
        return _connection.Invoke<int>("SpaceCenter", "get_RailsWarpFactor");
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
    public void SetRailsWarpFactor(int value)
    {
        var _args = new object[]
        {
            value
        };
        _connection.Invoke("SpaceCenter", "set_RailsWarpFactor", _args);
    }

    /// <summary>
    /// Gets the current amount of reputation.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_Reputation")]
    public float GetReputation()
    {
        return _connection.Invoke<float>("SpaceCenter", "get_Reputation");
    }

    /// <summary>
    /// Gets the current amount of science.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_Science")]
    public float GetScience()
    {
        return _connection.Invoke<float>("SpaceCenter", "get_Science");
    }

    /// <summary>
    /// Gets the currently targeted celestial body.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_TargetBody")]
    public CelestialBody GetTargetBody()
    {
        return _connection.Invoke<CelestialBody>("SpaceCenter", "get_TargetBody");
    }

    /// <summary>
    /// Sets the currently targeted celestial body.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetBody(CelestialBody value)
    {
        var _args = new object[]
        {
            value
        };
        _connection.Invoke("SpaceCenter", "set_TargetBody", _args);
    }

    /// <summary>
    /// Gets the currently targeted docking port.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_TargetDockingPort")]
    public DockingPort GetTargetDockingPort()
    {
        return _connection.Invoke<DockingPort>("SpaceCenter", "get_TargetDockingPort");
    }

    /// <summary>
    /// Sets the currently targeted docking port.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetDockingPort(DockingPort value)
    {
        var _args = new object[]
        {
            value
        };
        _connection.Invoke("SpaceCenter", "set_TargetDockingPort", _args);
    }

    /// <summary>
    /// Gets the currently targeted vessel.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_TargetVessel")]
    public Vessel GetTargetVessel()
    {
        return _connection.Invoke<Vessel>("SpaceCenter", "get_TargetVessel");
    }

    /// <summary>
    /// Sets the currently targeted vessel.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetVessel(Vessel value)
    {
        var _args = new object[]
        {
            value
        };
        _connection.Invoke("SpaceCenter", "set_TargetVessel", _args);
    }

    /// <summary>
    /// Gets whether the UI is visible.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_UIVisible")]
    public bool GetUIVisible()
    {
        return _connection.Invoke<bool>("SpaceCenter", "get_UIVisible");
    }

    /// <summary>
    /// Sets whether the UI is visible.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetUIVisible(bool value)
    {
        var _args = new object[]
        {
            value
        };
        _connection.Invoke("SpaceCenter", "set_UIVisible", _args);
    }

    /// <summary>
    /// Gets the current universal time in seconds.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_UT")]
    public double GetUT()
    {
        return _connection.Invoke<double>("SpaceCenter", "get_UT");
    }

    /// <summary>
    /// Gets a list of all the vessels in the game.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_Vessels")]
    public IList<Vessel> GetVessels()
    {
        return _connection.Invoke<IList<Vessel>>("SpaceCenter", "get_Vessels");
    }

    /// <summary>
    /// Gets the current warp factor. This is the index of the rate at which time
    /// is passing for either regular "on-rails" or physical time warp. Returns 0
    /// if time warp is not active. When in on-rails time warp, this is equal to
    /// <see cref="M:SpaceCenter.GetRailsWarpFactor" />, and in physics time warp, this is equal to
    /// <see cref="M:SpaceCenter.GetPhysicsWarpFactor" />.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_WarpFactor")]
    public float GetWarpFactor()
    {
        return _connection.Invoke<float>("SpaceCenter", "get_WarpFactor");
    }

    /// <summary>
    /// Gets the current time warp mode. Returns <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.WarpMode.None" /> if time
    /// warp is not active, <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.WarpMode.Rails" /> if regular "on-rails" time warp
    /// is active, or <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.WarpMode.Physics" /> if physical time warp is active.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_WarpMode")]
    public WarpMode GetWarpMode()
    {
        return _connection.Invoke<WarpMode>("SpaceCenter", "get_WarpMode");
    }

    /// <summary>
    /// Gets the current warp rate. This is the rate at which time is passing for
    /// either on-rails or physical time warp. For example, a value of 10 means
    /// time is passing 10x faster than normal. Returns 1 if time warp is not
    /// active.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_WarpRate")]
    public float GetWarpRate()
    {
        return _connection.Invoke<float>("SpaceCenter", "get_WarpRate");
    }

    /// <summary>
    /// Gets the waypoint manager.
    /// </summary>
    [RpcAttribute("SpaceCenter", "get_WaypointManager")]
    public WaypointManager GetWaypointManager()
    {
        return _connection.Invoke<WaypointManager>("SpaceCenter", "get_WaypointManager");
    }
}
