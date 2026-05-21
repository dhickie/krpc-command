using Google.Protobuf;
using kRPC.Client.Boost.Connection;
using systemAlias = System;

namespace kRPC.Client.Boost.Services;

/// <summary>
/// SpaceCenter service.
/// </summary>
public class SpaceCenterService
{
    ConnectionMultiplexer connection;

    internal SpaceCenterService (ConnectionMultiplexer serverConnection)
    {
        connection = serverConnection;
    }

    /// <summary>
    /// Returns <c>true</c> if regular "on-rails" time warp can be used, at the specified warp
    /// <paramref name="factor" />. The maximum time warp rate is limited by various things,
    /// including how close the active vessel is to a planet. See
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">the KSP wiki</a>
    /// for details.
    /// </summary>
    /// <param name="factor">The warp factor to check.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CanRailsWarpAt")]
    public bool CanRailsWarpAt (int factor = 1)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (factor, typeof(int))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CanRailsWarpAt", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Whether the current flight can be reverted to launch.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CanRevertToLaunch")]
    public bool CanRevertToLaunch ()
    {
        ByteString _data = connection.Invoke ("SpaceCenter", "CanRevertToLaunch");
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Clears the current target.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ClearTarget")]
    public void ClearTarget ()
    {
        connection.Invoke ("SpaceCenter", "ClearTarget");
    }

    /// <summary>
    /// Creates a Kerbal.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="job"></param>
    /// <param name="male"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CreateKerbal")]
    public void CreateKerbal (string name, string job, bool male)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (name, typeof(string)),
            global::KRPC.Client.Encoder.Encode (job, typeof(string)),
            global::KRPC.Client.Encoder.Encode (male, typeof(bool))
        };
        connection.Invoke ("SpaceCenter", "CreateKerbal", _args);
    }

    /// <summary>
    /// Find a Kerbal by name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns><c>null</c> if no Kerbal with the given name exists.</returns>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "GetKerbal")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember GetKerbal (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "GetKerbal", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember), connection);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchVessel")]
    public void LaunchVessel (string craftDirectory, string name, string launchSite, bool recover = true, global::System.Collections.Generic.IList<string> crew = null, string flagUrl = "")
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (craftDirectory, typeof(string)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string)),
            global::KRPC.Client.Encoder.Encode (launchSite, typeof(string)),
            global::KRPC.Client.Encoder.Encode (recover, typeof(bool)),
            global::KRPC.Client.Encoder.Encode (crew ?? null, typeof(global::System.Collections.Generic.IList<string>)),
            global::KRPC.Client.Encoder.Encode (flagUrl, typeof(string))
        };
        connection.Invoke ("SpaceCenter", "LaunchVessel", _args);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchVesselFromSPH")]
    public void LaunchVesselFromSPH (string name, bool recover = true)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (name, typeof(string)),
            global::KRPC.Client.Encoder.Encode (recover, typeof(bool))
        };
        connection.Invoke ("SpaceCenter", "LaunchVesselFromSPH", _args);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchVesselFromVAB")]
    public void LaunchVesselFromVAB (string name, bool recover = true)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (name, typeof(string)),
            global::KRPC.Client.Encoder.Encode (recover, typeof(bool))
        };
        connection.Invoke ("SpaceCenter", "LaunchVesselFromVAB", _args);
    }

    /// <summary>
    /// Returns a list of vessels from the given <paramref name="craftDirectory" />
    /// that can be launched.
    /// </summary>
    /// <param name="craftDirectory">Name of the directory in the current saves
    /// "Ships" directory. For example <c>"VAB"</c> or <c>"SPH"</c>.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchableVessels")]
    public global::System.Collections.Generic.IList<string> LaunchableVessels (string craftDirectory)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (craftDirectory, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "LaunchableVessels", _args);
        return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
    }

    /// <summary>
    /// Load the game with the given name.
    /// This will create a load a save file called <c>name.sfs</c> from the folder of the
    /// current save game.
    /// </summary>
    /// <param name="name">Name of the save.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Load")]
    public void Load (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        connection.Invoke ("SpaceCenter", "Load", _args);
    }

    /// <summary>
    /// Switch to the space center view.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LoadSpaceCenter")]
    public void LoadSpaceCenter ()
    {
        connection.Invoke ("SpaceCenter", "LoadSpaceCenter");
    }

    /// <summary>
    /// Load a quicksave.
    /// </summary>
    /// <remarks>
    /// This is the same as calling <see cref="M:SpaceCenter.Load" /> with the name "quicksave".
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Quickload")]
    public void Quickload ()
    {
        connection.Invoke ("SpaceCenter", "Quickload");
    }

    /// <summary>
    /// Save a quicksave.
    /// </summary>
    /// <remarks>
    /// This is the same as calling <see cref="M:SpaceCenter.Save" /> with the name "quicksave".
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Quicksave")]
    public void Quicksave ()
    {
        connection.Invoke ("SpaceCenter", "Quicksave");
    }

    /// <summary>
    /// Cast a ray from a given position in a given direction, and return the distance to the hit point.
    /// If no hit occurs, returns infinity.
    /// </summary>
    /// <param name="position">Position, as a vector, of the origin of the ray.</param>
    /// <param name="direction">Direction of the ray, as a unit vector.</param>
    /// <param name="referenceFrame">The reference frame that the position and direction are in.</param>
    /// <returns>The distance to the hit, in meters, or infinity if there was no hit.</returns>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RaycastDistance")]
    public double RaycastDistance (systemAlias::Tuple<double,double,double> position, systemAlias::Tuple<double,double,double> direction, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (direction, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "RaycastDistance", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// Cast a ray from a given position in a given direction, and return the part that it hits.
    /// If no hit occurs, returns <c>null</c>.
    /// </summary>
    /// <param name="position">Position, as a vector, of the origin of the ray.</param>
    /// <param name="direction">Direction of the ray, as a unit vector.</param>
    /// <param name="referenceFrame">The reference frame that the position and direction are in.</param>
    /// <returns>The part that was hit or <c>null</c> if there was no hit.</returns>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RaycastPart")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part RaycastPart (systemAlias::Tuple<double,double,double> position, systemAlias::Tuple<double,double,double> direction, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (direction, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "RaycastPart", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
    }

    /// <summary>
    /// Revert the current flight to launch.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RevertToLaunch")]
    public void RevertToLaunch ()
    {
        connection.Invoke ("SpaceCenter", "RevertToLaunch");
    }

    /// <summary>
    /// Save the game with a given name.
    /// This will create a save file called <c>name.sfs</c> in the folder of the
    /// current save game.
    /// </summary>
    /// <param name="name">Name of the save.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Save")]
    public void Save (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        connection.Invoke ("SpaceCenter", "Save", _args);
    }

    /// <summary>
    /// Saves a screenshot.
    /// </summary>
    /// <param name="filePath">The path of the file to save.</param>
    /// <param name="scale">Resolution scaling factor</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Screenshot")]
    public void Screenshot (string filePath, int scale = 1)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (filePath, typeof(string)),
            global::KRPC.Client.Encoder.Encode (scale, typeof(int))
        };
        connection.Invoke ("SpaceCenter", "Screenshot", _args);
    }

    /// <summary>
    /// Transfers a crew member to a different part.
    /// </summary>
    /// <param name="crewMember">The crew member to transfer.</param>
    /// <param name="targetPart">The part to move them to.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "TransferCrew")]
    public void TransferCrew (global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember crewMember, global::kRPC.Client.Boost.Services.SpaceCenter.Part targetPart)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (crewMember, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember)),
            global::KRPC.Client.Encoder.Encode (targetPart, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
        };
        connection.Invoke ("SpaceCenter", "TransferCrew", _args);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "TransformDirection")]
    public systemAlias::Tuple<double,double,double> TransformDirection (systemAlias::Tuple<double,double,double> direction, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame from, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame to)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (direction, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (from, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)),
            global::KRPC.Client.Encoder.Encode (to, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "TransformDirection", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "TransformPosition")]
    public systemAlias::Tuple<double,double,double> TransformPosition (systemAlias::Tuple<double,double,double> position, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame from, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame to)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (from, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)),
            global::KRPC.Client.Encoder.Encode (to, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "TransformPosition", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "TransformRotation")]
    public systemAlias::Tuple<double,double,double,double> TransformRotation (systemAlias::Tuple<double,double,double,double> rotation, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame from, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame to)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (rotation, typeof(systemAlias::Tuple<double,double,double,double>)),
            global::KRPC.Client.Encoder.Encode (from, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)),
            global::KRPC.Client.Encoder.Encode (to, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "TransformRotation", _args);
        return (systemAlias::Tuple<double,double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double,double>), connection);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "TransformVelocity")]
    public systemAlias::Tuple<double,double,double> TransformVelocity (systemAlias::Tuple<double,double,double> position, systemAlias::Tuple<double,double,double> velocity, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame from, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame to)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (velocity, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (from, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)),
            global::KRPC.Client.Encoder.Encode (to, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "TransformVelocity", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "WarpTo")]
    public void WarpTo (double ut, float maxRailsRate = 100000.0f, float maxPhysicsRate = 2.0f)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (ut, typeof(double)),
            global::KRPC.Client.Encoder.Encode (maxRailsRate, typeof(float)),
            global::KRPC.Client.Encoder.Encode (maxPhysicsRate, typeof(float))
        };
        connection.Invoke ("SpaceCenter", "WarpTo", _args);
    }

    /// <summary>
    /// The currently active vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_ActiveVessel")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Vessel ActiveVessel {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_ActiveVessel");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            connection.Invoke ("SpaceCenter", "set_ActiveVessel", _args);
        }
    }

    /// <summary>
    /// The alarm manager.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_AlarmManager")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.AlarmManager AlarmManager {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_AlarmManager");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.AlarmManager)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AlarmManager), connection);
        }
    }

    /// <summary>
    /// A dictionary of all celestial bodies (planets, moons, etc.) in the game,
    /// keyed by the name of the body.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_Bodies")]
    public global::System.Collections.Generic.IDictionary<string,global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody> Bodies {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_Bodies");
            return (global::System.Collections.Generic.IDictionary<string,global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody>), connection);
        }
    }

    /// <summary>
    /// An object that can be used to control the camera.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_Camera")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Camera Camera {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_Camera");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Camera)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Camera), connection);
        }
    }

    /// <summary>
    /// The contract manager.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_ContractManager")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ContractManager ContractManager {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_ContractManager");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ContractManager)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ContractManager), connection);
        }
    }

    /// <summary>
    /// Whether <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a> is installed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_FARAvailable")]
    public bool FARAvailable {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_FARAvailable");
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The current amount of funds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_Funds")]
    public double Funds {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_Funds");
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The value of the <a href="https://en.wikipedia.org/wiki/Gravitational_constant">
    /// gravitational constant</a> G in <math>N(m/kg)^2</math>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_G")]
    public double G {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_G");
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The current mode the game is in.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_GameMode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.GameMode GameMode {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_GameMode");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.GameMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.GameMode), connection);
        }
    }

    /// <summary>
    /// A list of available launch sites.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_LaunchSites")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.LaunchSite> LaunchSites {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_LaunchSites");
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.LaunchSite>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.LaunchSite>), connection);
        }
    }

    /// <summary>
    /// The visible objects in map mode.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_MapFilter")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.MapFilterType MapFilter {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_MapFilter");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.MapFilterType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.MapFilterType), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.MapFilterType))
            };
            connection.Invoke ("SpaceCenter", "set_MapFilter", _args);
        }
    }

    /// <summary>
    /// The current maximum regular "on-rails" warp factor that can be set.
    /// A value between 0 and 7 inclusive. See
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">the KSP wiki</a>
    /// for details.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_MaximumRailsWarpFactor")]
    public int MaximumRailsWarpFactor {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_MaximumRailsWarpFactor");
            return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
        }
    }

    /// <summary>
    /// Whether the navball is visible.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_Navball")]
    public bool Navball {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_Navball");
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "set_Navball", _args);
        }
    }

    /// <summary>
    /// The physical time warp rate. A value between 0 and 3 inclusive. 0 means
    /// no time warp. Returns 0 if regular "on-rails" time warp is active.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_PhysicsWarpFactor")]
    public int PhysicsWarpFactor {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_PhysicsWarpFactor");
            return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (value, typeof(int))
            };
            connection.Invoke ("SpaceCenter", "set_PhysicsWarpFactor", _args);
        }
    }

    /// <summary>
    /// The time warp rate, using regular "on-rails" time warp. A value between
    /// 0 and 7 inclusive. 0 means no time warp. Returns 0 if physical time warp
    /// is active.
    ///
    /// If requested time warp factor cannot be set, it will be set to the next
    /// lowest possible value. For example, if the vessel is too close to a
    /// planet. See <a href="https://wiki.kerbalspaceprogram.com/wiki/Time_warp">
    /// the KSP wiki</a> for details.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_RailsWarpFactor")]
    public int RailsWarpFactor {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_RailsWarpFactor");
            return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (value, typeof(int))
            };
            connection.Invoke ("SpaceCenter", "set_RailsWarpFactor", _args);
        }
    }

    /// <summary>
    /// The current amount of reputation.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_Reputation")]
    public float Reputation {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_Reputation");
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The current amount of science.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_Science")]
    public float Science {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_Science");
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The currently targeted celestial body.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_TargetBody")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody TargetBody {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_TargetBody");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            connection.Invoke ("SpaceCenter", "set_TargetBody", _args);
        }
    }

    /// <summary>
    /// The currently targeted docking port.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_TargetDockingPort")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort TargetDockingPort {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_TargetDockingPort");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort))
            };
            connection.Invoke ("SpaceCenter", "set_TargetDockingPort", _args);
        }
    }

    /// <summary>
    /// The currently targeted vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_TargetVessel")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Vessel TargetVessel {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_TargetVessel");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            connection.Invoke ("SpaceCenter", "set_TargetVessel", _args);
        }
    }

    /// <summary>
    /// Whether the UI is visible.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_UIVisible")]
    public bool UIVisible {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_UIVisible");
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "set_UIVisible", _args);
        }
    }

    /// <summary>
    /// The current universal time in seconds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_UT")]
    public double UT {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_UT");
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// A list of all the vessels in the game.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_Vessels")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Vessel> Vessels {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_Vessels");
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Vessel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Vessel>), connection);
        }
    }

    /// <summary>
    /// The current warp factor. This is the index of the rate at which time
    /// is passing for either regular "on-rails" or physical time warp. Returns 0
    /// if time warp is not active. When in on-rails time warp, this is equal to
    /// <see cref="M:SpaceCenter.RailsWarpFactor" />, and in physics time warp, this is equal to
    /// <see cref="M:SpaceCenter.PhysicsWarpFactor" />.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_WarpFactor")]
    public float WarpFactor {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_WarpFactor");
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The current time warp mode. Returns <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.WarpMode.None" /> if time
    /// warp is not active, <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.WarpMode.Rails" /> if regular "on-rails" time warp
    /// is active, or <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.WarpMode.Physics" /> if physical time warp is active.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_WarpMode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.WarpMode WarpMode {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_WarpMode");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.WarpMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.WarpMode), connection);
        }
    }

    /// <summary>
    /// The current warp rate. This is the rate at which time is passing for
    /// either on-rails or physical time warp. For example, a value of 10 means
    /// time is passing 10x faster than normal. Returns 1 if time warp is not
    /// active.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_WarpRate")]
    public float WarpRate {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_WarpRate");
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The waypoint manager.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_WaypointManager")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.WaypointManager WaypointManager {
        get {
            ByteString _data = connection.Invoke ("SpaceCenter", "get_WaypointManager");
            return (global::kRPC.Client.Boost.Services.SpaceCenter.WaypointManager)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.WaypointManager), connection);
        }
    }
}
