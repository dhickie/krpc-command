using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NET35
using systemAlias = global::KRPC.Client.Compatibility;
using genericCollectionsAlias = global::KRPC.Client.Compatibility;
#else
using systemAlias = global::System;
using genericCollectionsAlias = global::System.Collections.Generic;
#endif

namespace KRPC.Client.Services.SpaceCenter
{
    /// <summary>
    /// Extension methods for SpaceCenter service.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Create an instance of the SpaceCenter service.
        /// </summary>
        public static global::KRPC.Client.Services.SpaceCenter.Service SpaceCenter (this global::KRPC.Client.IConnection connection)
        {
            return new global::KRPC.Client.Services.SpaceCenter.Service (connection);
        }
    }

    /// <summary>
    /// SpaceCenter service.
    /// </summary>
    public class Service
    {
        global::KRPC.Client.IConnection connection;

        internal Service (global::KRPC.Client.IConnection serverConnection)
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
        public global::KRPC.Client.Services.SpaceCenter.CrewMember GetKerbal (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "GetKerbal", _args);
            return (global::KRPC.Client.Services.SpaceCenter.CrewMember)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CrewMember), connection);
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
        public double RaycastDistance (systemAlias::Tuple<double,double,double> position, systemAlias::Tuple<double,double,double> direction, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (direction, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
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
        public global::KRPC.Client.Services.SpaceCenter.Part RaycastPart (systemAlias::Tuple<double,double,double> position, systemAlias::Tuple<double,double,double> direction, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (direction, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RaycastPart", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
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
        public void TransferCrew (global::KRPC.Client.Services.SpaceCenter.CrewMember crewMember, global::KRPC.Client.Services.SpaceCenter.Part targetPart)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (crewMember, typeof(global::KRPC.Client.Services.SpaceCenter.CrewMember)),
                global::KRPC.Client.Encoder.Encode (targetPart, typeof(global::KRPC.Client.Services.SpaceCenter.Part))
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
        public systemAlias::Tuple<double,double,double> TransformDirection (systemAlias::Tuple<double,double,double> direction, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame from, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame to)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (direction, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (from, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)),
                global::KRPC.Client.Encoder.Encode (to, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
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
        public systemAlias::Tuple<double,double,double> TransformPosition (systemAlias::Tuple<double,double,double> position, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame from, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame to)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (from, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)),
                global::KRPC.Client.Encoder.Encode (to, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
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
        public systemAlias::Tuple<double,double,double,double> TransformRotation (systemAlias::Tuple<double,double,double,double> rotation, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame from, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame to)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (rotation, typeof(systemAlias::Tuple<double,double,double,double>)),
                global::KRPC.Client.Encoder.Encode (from, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)),
                global::KRPC.Client.Encoder.Encode (to, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
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
        public systemAlias::Tuple<double,double,double> TransformVelocity (systemAlias::Tuple<double,double,double> position, systemAlias::Tuple<double,double,double> velocity, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame from, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame to)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (velocity, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (from, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)),
                global::KRPC.Client.Encoder.Encode (to, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
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
        public global::KRPC.Client.Services.SpaceCenter.Vessel ActiveVessel {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_ActiveVessel");
                return (global::KRPC.Client.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel))
                };
                connection.Invoke ("SpaceCenter", "set_ActiveVessel", _args);
            }
        }

        /// <summary>
        /// The alarm manager.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_AlarmManager")]
        public global::KRPC.Client.Services.SpaceCenter.AlarmManager AlarmManager {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_AlarmManager");
                return (global::KRPC.Client.Services.SpaceCenter.AlarmManager)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.AlarmManager), connection);
            }
        }

        /// <summary>
        /// A dictionary of all celestial bodies (planets, moons, etc.) in the game,
        /// keyed by the name of the body.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_Bodies")]
        public global::System.Collections.Generic.IDictionary<string,global::KRPC.Client.Services.SpaceCenter.CelestialBody> Bodies {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_Bodies");
                return (global::System.Collections.Generic.IDictionary<string,global::KRPC.Client.Services.SpaceCenter.CelestialBody>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,global::KRPC.Client.Services.SpaceCenter.CelestialBody>), connection);
            }
        }

        /// <summary>
        /// An object that can be used to control the camera.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_Camera")]
        public global::KRPC.Client.Services.SpaceCenter.Camera Camera {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_Camera");
                return (global::KRPC.Client.Services.SpaceCenter.Camera)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Camera), connection);
            }
        }

        /// <summary>
        /// The contract manager.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_ContractManager")]
        public global::KRPC.Client.Services.SpaceCenter.ContractManager ContractManager {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_ContractManager");
                return (global::KRPC.Client.Services.SpaceCenter.ContractManager)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ContractManager), connection);
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
        public global::KRPC.Client.Services.SpaceCenter.GameMode GameMode {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_GameMode");
                return (global::KRPC.Client.Services.SpaceCenter.GameMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.GameMode), connection);
            }
        }

        /// <summary>
        /// A list of available launch sites.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_LaunchSites")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.LaunchSite> LaunchSites {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_LaunchSites");
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.LaunchSite>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.LaunchSite>), connection);
            }
        }

        /// <summary>
        /// The visible objects in map mode.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_MapFilter")]
        public global::KRPC.Client.Services.SpaceCenter.MapFilterType MapFilter {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_MapFilter");
                return (global::KRPC.Client.Services.SpaceCenter.MapFilterType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.MapFilterType), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.MapFilterType))
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
        public global::KRPC.Client.Services.SpaceCenter.CelestialBody TargetBody {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_TargetBody");
                return (global::KRPC.Client.Services.SpaceCenter.CelestialBody)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody))
                };
                connection.Invoke ("SpaceCenter", "set_TargetBody", _args);
            }
        }

        /// <summary>
        /// The currently targeted docking port.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_TargetDockingPort")]
        public global::KRPC.Client.Services.SpaceCenter.DockingPort TargetDockingPort {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_TargetDockingPort");
                return (global::KRPC.Client.Services.SpaceCenter.DockingPort)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.DockingPort), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.DockingPort))
                };
                connection.Invoke ("SpaceCenter", "set_TargetDockingPort", _args);
            }
        }

        /// <summary>
        /// The currently targeted vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_TargetVessel")]
        public global::KRPC.Client.Services.SpaceCenter.Vessel TargetVessel {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_TargetVessel");
                return (global::KRPC.Client.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel))
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
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Vessel> Vessels {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_Vessels");
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Vessel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Vessel>), connection);
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
        /// The current time warp mode. Returns <see cref="M:SpaceCenter.WarpMode.None" /> if time
        /// warp is not active, <see cref="M:SpaceCenter.WarpMode.Rails" /> if regular "on-rails" time warp
        /// is active, or <see cref="M:SpaceCenter.WarpMode.Physics" /> if physical time warp is active.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "get_WarpMode")]
        public global::KRPC.Client.Services.SpaceCenter.WarpMode WarpMode {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_WarpMode");
                return (global::KRPC.Client.Services.SpaceCenter.WarpMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.WarpMode), connection);
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
        public global::KRPC.Client.Services.SpaceCenter.WaypointManager WaypointManager {
            get {
                ByteString _data = connection.Invoke ("SpaceCenter", "get_WaypointManager");
                return (global::KRPC.Client.Services.SpaceCenter.WaypointManager)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.WaypointManager), connection);
            }
        }
    }

    /// <summary>
    /// The state of an antenna. See <see cref="M:SpaceCenter.Antenna.State" />.
    /// </summary>
    [Serializable]
    public enum AntennaState
    {
        /// <summary>
        /// Antenna is fully deployed.
        /// </summary>
        Deployed = 0,
        /// <summary>
        /// Antenna is fully retracted.
        /// </summary>
        Retracted = 1,
        /// <summary>
        /// Antenna is being deployed.
        /// </summary>
        Deploying = 2,
        /// <summary>
        /// Antenna is being retracted.
        /// </summary>
        Retracting = 3,
        /// <summary>
        /// Antenna is broken.
        /// </summary>
        Broken = 4
    }

    /// <summary>
    /// The state of an auto-strut. <see cref="M:SpaceCenter.Part.AutoStrutMode" /></summary>
    [Serializable]
    public enum AutoStrutMode
    {
        /// <summary>
        /// Off
        /// </summary>
        Off = 0,
        /// <summary>
        /// Root
        /// </summary>
        Root = 1,
        /// <summary>
        /// Heaviest
        /// </summary>
        Heaviest = 2,
        /// <summary>
        /// Grandparent
        /// </summary>
        Grandparent = 3,
        /// <summary>
        /// ForceRoot
        /// </summary>
        ForceRoot = 4,
        /// <summary>
        /// ForceHeaviest
        /// </summary>
        ForceHeaviest = 5,
        /// <summary>
        /// ForceGrandparent
        /// </summary>
        ForceGrandparent = 6
    }

    /// <summary>
    /// See <see cref="M:SpaceCenter.Camera.Mode" />.
    /// </summary>
    [Serializable]
    public enum CameraMode
    {
        /// <summary>
        /// The camera is showing the active vessel, in "auto" mode.
        /// </summary>
        Automatic = 0,
        /// <summary>
        /// The camera is showing the active vessel, in "free" mode.
        /// </summary>
        Free = 1,
        /// <summary>
        /// The camera is showing the active vessel, in "chase" mode.
        /// </summary>
        Chase = 2,
        /// <summary>
        /// The camera is showing the active vessel, in "locked" mode.
        /// </summary>
        Locked = 3,
        /// <summary>
        /// The camera is showing the active vessel, in "orbital" mode.
        /// </summary>
        Orbital = 4,
        /// <summary>
        /// The Intra-Vehicular Activity view is being shown.
        /// </summary>
        IVA = 5,
        /// <summary>
        /// The map view is being shown.
        /// </summary>
        Map = 6
    }

    /// <summary>
    /// The state of a cargo bay. See <see cref="M:SpaceCenter.CargoBay.State" />.
    /// </summary>
    [Serializable]
    public enum CargoBayState
    {
        /// <summary>
        /// Cargo bay is fully open.
        /// </summary>
        Open = 0,
        /// <summary>
        /// Cargo bay closed and locked.
        /// </summary>
        Closed = 1,
        /// <summary>
        /// Cargo bay is opening.
        /// </summary>
        Opening = 2,
        /// <summary>
        /// Cargo bay is closing.
        /// </summary>
        Closing = 3
    }

    /// <summary>
    /// The type of a communication link.
    /// See <see cref="M:SpaceCenter.CommLink.Type" />.
    /// </summary>
    [Serializable]
    public enum CommLinkType
    {
        /// <summary>
        /// Link is to a base station on Kerbin.
        /// </summary>
        Home = 0,
        /// <summary>
        /// Link is to a control source, for example a manned spacecraft.
        /// </summary>
        Control = 1,
        /// <summary>
        /// Link is to a relay satellite.
        /// </summary>
        Relay = 2
    }

    /// <summary>
    /// The state of a contract. See <see cref="M:SpaceCenter.Contract.State" />.
    /// </summary>
    [Serializable]
    public enum ContractState
    {
        /// <summary>
        /// The contract is active.
        /// </summary>
        Active = 0,
        /// <summary>
        /// The contract has been canceled.
        /// </summary>
        Canceled = 1,
        /// <summary>
        /// The contract has been completed.
        /// </summary>
        Completed = 2,
        /// <summary>
        /// The deadline for the contract has expired.
        /// </summary>
        DeadlineExpired = 3,
        /// <summary>
        /// The contract has been declined.
        /// </summary>
        Declined = 4,
        /// <summary>
        /// The contract has been failed.
        /// </summary>
        Failed = 5,
        /// <summary>
        /// The contract has been generated.
        /// </summary>
        Generated = 6,
        /// <summary>
        /// The contract has been offered to the player.
        /// </summary>
        Offered = 7,
        /// <summary>
        /// The contract was offered to the player, but the offer expired.
        /// </summary>
        OfferExpired = 8,
        /// <summary>
        /// The contract has been withdrawn.
        /// </summary>
        Withdrawn = 9
    }

    /// <summary>
    /// See <see cref="M:SpaceCenter.Control.InputMode" />.
    /// </summary>
    [Serializable]
    public enum ControlInputMode
    {
        /// <summary>
        /// Control inputs are added to the vessels current control inputs.
        /// </summary>
        Additive = 0,
        /// <summary>
        /// Control inputs (when they are non-zero) override the vessels current control inputs.
        /// </summary>
        Override = 1
    }

    /// <summary>
    /// The control source of a vessel.
    /// See <see cref="M:SpaceCenter.Control.Source" />.
    /// </summary>
    [Serializable]
    public enum ControlSource
    {
        /// <summary>
        /// Vessel is controlled by a Kerbal.
        /// </summary>
        Kerbal = 0,
        /// <summary>
        /// Vessel is controlled by a probe core.
        /// </summary>
        Probe = 1,
        /// <summary>
        /// Vessel is not controlled.
        /// </summary>
        None = 2
    }

    /// <summary>
    /// The control state of a vessel.
    /// See <see cref="M:SpaceCenter.Control.State" />.
    /// </summary>
    [Serializable]
    public enum ControlState
    {
        /// <summary>
        /// Full controllable.
        /// </summary>
        Full = 0,
        /// <summary>
        /// Partially controllable.
        /// </summary>
        Partial = 1,
        /// <summary>
        /// Not controllable.
        /// </summary>
        None = 2
    }

    /// <summary>
    /// A crew member's gender.
    /// See <see cref="M:SpaceCenter.CrewMember.Gender" />.
    /// </summary>
    [Serializable]
    public enum CrewMemberGender
    {
        /// <summary>
        /// Male.
        /// </summary>
        Male = 0,
        /// <summary>
        /// Female.
        /// </summary>
        Female = 1
    }

    /// <summary>
    /// The type of a crew member.
    /// See <see cref="M:SpaceCenter.CrewMember.Type" />.
    /// </summary>
    [Serializable]
    public enum CrewMemberType
    {
        /// <summary>
        /// An applicant for crew.
        /// </summary>
        Applicant = 0,
        /// <summary>
        /// Rocket crew.
        /// </summary>
        Crew = 1,
        /// <summary>
        /// A tourist.
        /// </summary>
        Tourist = 2,
        /// <summary>
        /// An unowned crew member.
        /// </summary>
        Unowned = 3
    }

    /// <summary>
    /// The state of a docking port. See <see cref="M:SpaceCenter.DockingPort.State" />.
    /// </summary>
    [Serializable]
    public enum DockingPortState
    {
        /// <summary>
        /// The docking port is ready to dock to another docking port.
        /// </summary>
        Ready = 0,
        /// <summary>
        /// The docking port is docked to another docking port, or docked to
        /// another part (from the VAB/SPH).
        /// </summary>
        Docked = 1,
        /// <summary>
        /// The docking port is very close to another docking port,
        /// but has not docked. It is using magnetic force to acquire a solid dock.
        /// </summary>
        Docking = 2,
        /// <summary>
        /// The docking port has just been undocked from another docking port,
        /// and is disabled until it moves away by a sufficient distance
        /// (<see cref="M:SpaceCenter.DockingPort.ReengageDistance" />).
        /// </summary>
        Undocking = 3,
        /// <summary>
        /// The docking port has a shield, and the shield is closed.
        /// </summary>
        Shielded = 4,
        /// <summary>
        /// The docking ports shield is currently opening/closing.
        /// </summary>
        Moving = 5
    }

    /// <summary>
    /// Resource drain mode.
    /// See <see cref="M:SpaceCenter.ResourceDrain.DrainMode" />.
    /// </summary>
    [Serializable]
    public enum DrainMode
    {
        /// <summary>
        /// Drains from the parent part.
        /// </summary>
        Part = 0,
        /// <summary>
        /// Drains from all available parts.
        /// </summary>
        Vessel = 1
    }

    /// <summary>
    /// Editor facility.
    /// See <see cref="M:SpaceCenter.LaunchSite.EditorFacility" />.
    /// </summary>
    [Serializable]
    public enum EditorFacility
    {
        /// <summary>
        /// Vehicle Assembly Building.
        /// </summary>
        VAB = 1,
        /// <summary>
        /// Space Plane Hanger.
        /// </summary>
        SPH = 2,
        /// <summary>
        /// None.
        /// </summary>
        None = 0
    }

    /// <summary>
    /// The game mode.
    /// Returned by <see cref="T:SpaceCenter.GameMode" /></summary>
    [Serializable]
    public enum GameMode
    {
        /// <summary>
        /// Sandbox mode.
        /// </summary>
        Sandbox = 0,
        /// <summary>
        /// Career mode.
        /// </summary>
        Career = 1,
        /// <summary>
        /// Science career mode.
        /// </summary>
        Science = 2,
        /// <summary>
        /// Science sandbox mode.
        /// </summary>
        ScienceSandbox = 3,
        /// <summary>
        /// Mission mode.
        /// </summary>
        Mission = 4,
        /// <summary>
        /// Mission builder mode.
        /// </summary>
        MissionBuilder = 5,
        /// <summary>
        /// Scenario mode.
        /// </summary>
        Scenario = 6,
        /// <summary>
        /// Scenario mode that cannot be resumed.
        /// </summary>
        ScenarioNonResumable = 7
    }

    /// <summary>
    /// The state of a landing leg. See <see cref="M:SpaceCenter.Leg.State" />.
    /// </summary>
    [Serializable]
    public enum LegState
    {
        /// <summary>
        /// Landing leg is fully deployed.
        /// </summary>
        Deployed = 0,
        /// <summary>
        /// Landing leg is fully retracted.
        /// </summary>
        Retracted = 1,
        /// <summary>
        /// Landing leg is being deployed.
        /// </summary>
        Deploying = 2,
        /// <summary>
        /// Landing leg is being retracted.
        /// </summary>
        Retracting = 3,
        /// <summary>
        /// Landing leg is broken.
        /// </summary>
        Broken = 4
    }

    /// <summary>
    /// The set of things that are visible in map mode.
    /// These may be combined with bitwise logic.
    /// </summary>
    [Serializable]
    public enum MapFilterType
    {
        /// <summary>
        /// Everything.
        /// </summary>
        All = -1,
        /// <summary>
        /// Nothing.
        /// </summary>
        None = 0,
        /// <summary>
        /// Debris.
        /// </summary>
        Debris = 1,
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 2,
        /// <summary>
        /// SpaceObjects.
        /// </summary>
        SpaceObjects = 4,
        /// <summary>
        /// Probes.
        /// </summary>
        Probes = 8,
        /// <summary>
        /// Rovers.
        /// </summary>
        Rovers = 16,
        /// <summary>
        /// Landers.
        /// </summary>
        Landers = 32,
        /// <summary>
        /// Ships.
        /// </summary>
        Ships = 64,
        /// <summary>
        /// Stations.
        /// </summary>
        Stations = 128,
        /// <summary>
        /// Bases.
        /// </summary>
        Bases = 256,
        /// <summary>
        /// EVAs.
        /// </summary>
        EVAs = 512,
        /// <summary>
        /// Flags.
        /// </summary>
        Flags = 1024,
        /// <summary>
        /// Planes.
        /// </summary>
        Plane = 2048,
        /// <summary>
        /// Relays.
        /// </summary>
        Relay = 4096,
        /// <summary>
        /// Launch Sites.
        /// </summary>
        Site = 8192,
        /// <summary>
        /// Deployed Science Controllers.
        /// </summary>
        DeployedScienceController = 16384
    }

    /// <summary>
    /// The state of the motor on a powered wheel. See <see cref="M:SpaceCenter.Wheel.MotorState" />.
    /// </summary>
    [Serializable]
    public enum MotorState
    {
        /// <summary>
        /// The motor is idle.
        /// </summary>
        Idle = 0,
        /// <summary>
        /// The motor is running.
        /// </summary>
        Running = 1,
        /// <summary>
        /// The motor is disabled.
        /// </summary>
        Disabled = 2,
        /// <summary>
        /// The motor is inoperable.
        /// </summary>
        Inoperable = 3,
        /// <summary>
        /// The motor does not have enough resources to run.
        /// </summary>
        NotEnoughResources = 4
    }

    /// <summary>
    /// The state of a parachute. See <see cref="M:SpaceCenter.Parachute.State" />.
    /// </summary>
    [Serializable]
    public enum ParachuteState
    {
        /// <summary>
        /// The parachute is safely tucked away inside its housing.
        /// </summary>
        Stowed = 0,
        /// <summary>
        /// The parachute is armed for deployment.
        /// </summary>
        Armed = 1,
        /// <summary>
        /// The parachute has been deployed and is providing some drag,
        /// but is not fully deployed yet. (Stock parachutes only)
        /// </summary>
        SemiDeployed = 2,
        /// <summary>
        /// The parachute is fully deployed.
        /// </summary>
        Deployed = 3,
        /// <summary>
        /// The parachute has been cut.
        /// </summary>
        Cut = 4
    }

    /// <summary>
    /// The state of a radiator. <see cref="M:SpaceCenter.Radiator.State" /></summary>
    [Serializable]
    public enum RadiatorState
    {
        /// <summary>
        /// Radiator is fully extended.
        /// </summary>
        Extended = 0,
        /// <summary>
        /// Radiator is fully retracted.
        /// </summary>
        Retracted = 1,
        /// <summary>
        /// Radiator is being extended.
        /// </summary>
        Extending = 2,
        /// <summary>
        /// Radiator is being retracted.
        /// </summary>
        Retracting = 3,
        /// <summary>
        /// Radiator is broken.
        /// </summary>
        Broken = 4
    }

    /// <summary>
    /// The state of a resource converter. See <see cref="M:SpaceCenter.ResourceConverter.State" />.
    /// </summary>
    [Serializable]
    public enum ResourceConverterState
    {
        /// <summary>
        /// Converter is running.
        /// </summary>
        Running = 0,
        /// <summary>
        /// Converter is idle.
        /// </summary>
        Idle = 1,
        /// <summary>
        /// Converter is missing a required resource.
        /// </summary>
        MissingResource = 2,
        /// <summary>
        /// No available storage for output resource.
        /// </summary>
        StorageFull = 3,
        /// <summary>
        /// At preset resource capacity.
        /// </summary>
        Capacity = 4,
        /// <summary>
        /// Unknown state. Possible with modified resource converters.
        /// In this case, check <see cref="M:SpaceCenter.ResourceConverter.StatusInfo" /> for more information.
        /// </summary>
        Unknown = 5
    }

    /// <summary>
    /// The way in which a resource flows between parts. See <see cref="M:SpaceCenter.Resources.FlowMode" />.
    /// </summary>
    [Serializable]
    public enum ResourceFlowMode
    {
        /// <summary>
        /// The resource flows to any part in the vessel. For example, electric charge.
        /// </summary>
        Vessel = 0,
        /// <summary>
        /// The resource flows from parts in the first stage, followed by the second,
        /// and so on. For example, mono-propellant.
        /// </summary>
        Stage = 1,
        /// <summary>
        /// The resource flows between adjacent parts within the vessel. For example,
        /// liquid fuel or oxidizer.
        /// </summary>
        Adjacent = 2,
        /// <summary>
        /// The resource does not flow. For example, solid fuel.
        /// </summary>
        None = 3
    }

    /// <summary>
    /// The state of a resource harvester. See <see cref="M:SpaceCenter.ResourceHarvester.State" />.
    /// </summary>
    [Serializable]
    public enum ResourceHarvesterState
    {
        /// <summary>
        /// The drill is deploying.
        /// </summary>
        Deploying = 0,
        /// <summary>
        /// The drill is deployed and ready.
        /// </summary>
        Deployed = 1,
        /// <summary>
        /// The drill is retracting.
        /// </summary>
        Retracting = 2,
        /// <summary>
        /// The drill is retracted.
        /// </summary>
        Retracted = 3,
        /// <summary>
        /// The drill is running.
        /// </summary>
        Active = 4
    }

    /// <summary>
    /// A crew member's roster status.
    /// See <see cref="M:SpaceCenter.CrewMember.RosterStatus" />.
    /// </summary>
    [Serializable]
    public enum RosterStatus
    {
        /// <summary>
        /// Available.
        /// </summary>
        Available = 0,
        /// <summary>
        /// Assigned.
        /// </summary>
        Assigned = 1,
        /// <summary>
        /// Dead.
        /// </summary>
        Dead = 2,
        /// <summary>
        /// Missing.
        /// </summary>
        Missing = 3
    }

    /// <summary>
    /// The behavior of the SAS auto-pilot. See <see cref="M:SpaceCenter.AutoPilot.SASMode" />.
    /// </summary>
    [Serializable]
    public enum SASMode
    {
        /// <summary>
        /// Stability assist mode. Dampen out any rotation.
        /// </summary>
        StabilityAssist = 0,
        /// <summary>
        /// Point in the burn direction of the next maneuver node.
        /// </summary>
        Maneuver = 1,
        /// <summary>
        /// Point in the prograde direction.
        /// </summary>
        Prograde = 2,
        /// <summary>
        /// Point in the retrograde direction.
        /// </summary>
        Retrograde = 3,
        /// <summary>
        /// Point in the orbit normal direction.
        /// </summary>
        Normal = 4,
        /// <summary>
        /// Point in the orbit anti-normal direction.
        /// </summary>
        AntiNormal = 5,
        /// <summary>
        /// Point in the orbit radial direction.
        /// </summary>
        Radial = 6,
        /// <summary>
        /// Point in the orbit anti-radial direction.
        /// </summary>
        AntiRadial = 7,
        /// <summary>
        /// Point in the direction of the current target.
        /// </summary>
        Target = 8,
        /// <summary>
        /// Point away from the current target.
        /// </summary>
        AntiTarget = 9
    }

    /// <summary>
    /// The state of a solar panel. See <see cref="M:SpaceCenter.SolarPanel.State" />.
    /// </summary>
    [Serializable]
    public enum SolarPanelState
    {
        /// <summary>
        /// Solar panel is fully extended.
        /// </summary>
        Extended = 0,
        /// <summary>
        /// Solar panel is fully retracted.
        /// </summary>
        Retracted = 1,
        /// <summary>
        /// Solar panel is being extended.
        /// </summary>
        Extending = 2,
        /// <summary>
        /// Solar panel is being retracted.
        /// </summary>
        Retracting = 3,
        /// <summary>
        /// Solar panel is broken.
        /// </summary>
        Broken = 4
    }

    /// <summary>
    /// The mode of the speed reported in the navball.
    /// See <see cref="M:SpaceCenter.Control.SpeedMode" />.
    /// </summary>
    [Serializable]
    public enum SpeedMode
    {
        /// <summary>
        /// Speed is relative to the vessel's orbit.
        /// </summary>
        Orbit = 0,
        /// <summary>
        /// Speed is relative to the surface of the body being orbited.
        /// </summary>
        Surface = 1,
        /// <summary>
        /// Speed is relative to the current target.
        /// </summary>
        Target = 2
    }

    /// <summary>
    /// A crew member's suit type.
    /// See <see cref="M:SpaceCenter.CrewMember.SuitType" />.
    /// </summary>
    [Serializable]
    public enum SuitType
    {
        /// <summary>
        /// Default.
        /// </summary>
        Default = 0,
        /// <summary>
        /// Vintage.
        /// </summary>
        Vintage = 1,
        /// <summary>
        /// Future.
        /// </summary>
        Future = 2,
        /// <summary>
        /// Slim.
        /// </summary>
        Slim = 3
    }

    /// <summary>
    /// The situation a vessel is in.
    /// See <see cref="M:SpaceCenter.Vessel.Situation" />.
    /// </summary>
    [Serializable]
    public enum VesselSituation
    {
        /// <summary>
        /// Vessel is awaiting launch.
        /// </summary>
        PreLaunch = 0,
        /// <summary>
        /// Vessel is orbiting a body.
        /// </summary>
        Orbiting = 1,
        /// <summary>
        /// Vessel is on a sub-orbital trajectory.
        /// </summary>
        SubOrbital = 2,
        /// <summary>
        /// Escaping.
        /// </summary>
        Escaping = 3,
        /// <summary>
        /// Vessel is flying through an atmosphere.
        /// </summary>
        Flying = 4,
        /// <summary>
        /// Vessel is landed on the surface of a body.
        /// </summary>
        Landed = 5,
        /// <summary>
        /// Vessel has splashed down in an ocean.
        /// </summary>
        Splashed = 6,
        /// <summary>
        /// Vessel is docked to another.
        /// </summary>
        Docked = 7
    }

    /// <summary>
    /// The type of a vessel.
    /// See <see cref="M:SpaceCenter.Vessel.Type" />.
    /// </summary>
    [Serializable]
    public enum VesselType
    {
        /// <summary>
        /// Base.
        /// </summary>
        Base = 0,
        /// <summary>
        /// Debris.
        /// </summary>
        Debris = 1,
        /// <summary>
        /// Lander.
        /// </summary>
        Lander = 2,
        /// <summary>
        /// Plane.
        /// </summary>
        Plane = 3,
        /// <summary>
        /// Probe.
        /// </summary>
        Probe = 4,
        /// <summary>
        /// Relay.
        /// </summary>
        Relay = 5,
        /// <summary>
        /// Rover.
        /// </summary>
        Rover = 6,
        /// <summary>
        /// Ship.
        /// </summary>
        Ship = 7,
        /// <summary>
        /// Station.
        /// </summary>
        Station = 8,
        /// <summary>
        /// SpaceObject.
        /// </summary>
        SpaceObject = 9,
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 10,
        /// <summary>
        /// EVA.
        /// </summary>
        EVA = 11,
        /// <summary>
        /// Flag.
        /// </summary>
        Flag = 12,
        /// <summary>
        /// DeployedScienceController.
        /// </summary>
        DeployedScienceController = 13,
        /// <summary>
        /// DeploedSciencePart.
        /// </summary>
        DeployedSciencePart = 14,
        /// <summary>
        /// DroppedPart.
        /// </summary>
        DroppedPart = 15,
        /// <summary>
        /// DeployedGroundPart.
        /// </summary>
        DeployedGroundPart = 16
    }

    /// <summary>
    /// The time warp mode.
    /// Returned by <see cref="T:SpaceCenter.WarpMode" /></summary>
    [Serializable]
    public enum WarpMode
    {
        /// <summary>
        /// Time warp is active, and in regular "on-rails" mode.
        /// </summary>
        Rails = 0,
        /// <summary>
        /// Time warp is active, and in physical time warp mode.
        /// </summary>
        Physics = 1,
        /// <summary>
        /// Time warp is not active.
        /// </summary>
        None = 2
    }

    /// <summary>
    /// The state of a wheel. See <see cref="M:SpaceCenter.Wheel.State" />.
    /// </summary>
    [Serializable]
    public enum WheelState
    {
        /// <summary>
        /// Wheel is fully deployed.
        /// </summary>
        Deployed = 0,
        /// <summary>
        /// Wheel is fully retracted.
        /// </summary>
        Retracted = 1,
        /// <summary>
        /// Wheel is being deployed.
        /// </summary>
        Deploying = 2,
        /// <summary>
        /// Wheel is being retracted.
        /// </summary>
        Retracting = 3,
        /// <summary>
        /// Wheel is broken.
        /// </summary>
        Broken = 4
    }

    /// <summary>
    /// An alarm. Can be accessed using <see cref="M:SpaceCenter.AlarmManager" />.
    /// </summary>
    public class Alarm : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Alarm (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Description of the alarm.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Alarm_get_Description")]
        public string Description {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Alarm))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Description", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// Seconds between the alarm going off and the event it references.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Alarm_get_EventOffset")]
        public double EventOffset {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Alarm))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_EventOffset", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Unique identifier of the alarm.
        /// KSP destroys and recreates an alarm when it is edited.
        /// This id will remain constant between the old and new alarms.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Alarm_get_ID")]
        public uint ID {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Alarm))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_ID", _args);
                return (uint)global::KRPC.Client.Encoder.Decode (_data, typeof(uint), connection);
            }
        }

        /// <summary>
        /// Time the alarm will trigger.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Alarm_get_Time")]
        public double Time {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Alarm))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Time", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Time until the alarm triggers.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Alarm_get_TimeUntil")]
        public double TimeUntil {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Alarm))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_TimeUntil", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Title of the alarm
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Alarm_get_Title")]
        public string Title {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Alarm))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Title", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// Type of alarm
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Alarm_get_Type")]
        public string Type {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Alarm))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Type", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// Vessel the alarm references. <c>null</c> if it does not reference a vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Alarm_get_Vessel")]
        public global::KRPC.Client.Services.SpaceCenter.Vessel Vessel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Alarm))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Alarm_get_Vessel", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel), connection);
            }
        }
    }

    /// <summary>
    /// Alarm manager.
    /// Obtained by calling <see cref="M:SpaceCenter.AlarmManager" />.
    /// </summary>
    public class AlarmManager : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public AlarmManager (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Create an alarm.
        /// </summary>
        /// <param name="time">Number of seconds from now that the alarm should trigger.</param>
        /// <param name="title">Title for the alarm.</param>
        /// <param name="description">Description for the alarm.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddAlarm")]
        public static global::KRPC.Client.Services.SpaceCenter.Alarm AddAlarm (IConnection connection, double time, string title = "Alarm", string description = "")
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (time, typeof(double)),
                global::KRPC.Client.Encoder.Encode (title, typeof(string)),
                global::KRPC.Client.Encoder.Encode (description, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddAlarm", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Alarm), connection);
        }

        /// <summary>
        /// Create an alarm for the given vessel's next apoapsis.
        /// </summary>
        /// <param name="vessel">The vessel.</param>
        /// <param name="offset">Time in seconds to offset the alarm by.</param>
        /// <param name="title">Title for the alarm.</param>
        /// <param name="description">Description for the alarm.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm")]
        public static global::KRPC.Client.Services.SpaceCenter.Alarm AddApoapsisAlarm (IConnection connection, global::KRPC.Client.Services.SpaceCenter.Vessel vessel, double offset = 60.0, string title = "Apoapsis Alarm", string description = "")
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (vessel, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (offset, typeof(double)),
                global::KRPC.Client.Encoder.Encode (title, typeof(string)),
                global::KRPC.Client.Encoder.Encode (description, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddApoapsisAlarm", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Alarm), connection);
        }

        /// <summary>
        /// Create an alarm for the given vessel and maneuver node.
        /// </summary>
        /// <param name="vessel">The vessel.</param>
        /// <param name="node">The maneuver node.</param>
        /// <param name="offset">Time in seconds to offset the alarm by.</param>
        /// <param name="addBurnTime">Whether the node's burn time should be included in the alarm.</param>
        /// <param name="title">Title for the alarm.</param>
        /// <param name="description">Description for the alarm.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm")]
        public static global::KRPC.Client.Services.SpaceCenter.Alarm AddManeuverNodeAlarm (IConnection connection, global::KRPC.Client.Services.SpaceCenter.Vessel vessel, global::KRPC.Client.Services.SpaceCenter.Node node, double offset = 60.0, bool addBurnTime = true, string title = "Maneuver Node Alarm", string description = "")
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (vessel, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (node, typeof(global::KRPC.Client.Services.SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (offset, typeof(double)),
                global::KRPC.Client.Encoder.Encode (addBurnTime, typeof(bool)),
                global::KRPC.Client.Encoder.Encode (title, typeof(string)),
                global::KRPC.Client.Encoder.Encode (description, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddManeuverNodeAlarm", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Alarm), connection);
        }

        /// <summary>
        /// Create an alarm for the given vessel's next periapsis.
        /// </summary>
        /// <param name="vessel">The vessel.</param>
        /// <param name="offset">Time in seconds to offset the alarm by.</param>
        /// <param name="title">Title for the alarm.</param>
        /// <param name="description">Description for the alarm.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm")]
        public static global::KRPC.Client.Services.SpaceCenter.Alarm AddPeriapsisAlarm (IConnection connection, global::KRPC.Client.Services.SpaceCenter.Vessel vessel, double offset = 60.0, string title = "Periapsis Alarm", string description = "")
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (vessel, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (offset, typeof(double)),
                global::KRPC.Client.Encoder.Encode (title, typeof(string)),
                global::KRPC.Client.Encoder.Encode (description, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddPeriapsisAlarm", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Alarm), connection);
        }

        /// <summary>
        /// Create an alarm for the given vessel's next sphere of influence change.
        /// </summary>
        /// <param name="vessel">The vessel.</param>
        /// <param name="offset">Time in seconds to offset the alarm by.</param>
        /// <param name="title">Title for the alarm.</param>
        /// <param name="description">Description for the alarm.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddSOIAlarm")]
        public static global::KRPC.Client.Services.SpaceCenter.Alarm AddSOIAlarm (IConnection connection, global::KRPC.Client.Services.SpaceCenter.Vessel vessel, double offset = 60.0, string title = "SOI Change Alarm", string description = "")
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (vessel, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (offset, typeof(double)),
                global::KRPC.Client.Encoder.Encode (title, typeof(string)),
                global::KRPC.Client.Encoder.Encode (description, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddSOIAlarm", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Alarm), connection);
        }

        /// <summary>
        /// Create an alarm linked to a vessel.
        /// </summary>
        /// <param name="time">Number of seconds from now that the alarm should trigger.</param>
        /// <param name="vessel">Vessel to link the alarm to.</param>
        /// <param name="title">Title for the alarm.</param>
        /// <param name="description">Description for the alarm.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_static_AddVesselAlarm")]
        public static global::KRPC.Client.Services.SpaceCenter.Alarm AddVesselAlarm (IConnection connection, double time, global::KRPC.Client.Services.SpaceCenter.Vessel vessel, string title = "Vessel Alarm", string description = "")
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (time, typeof(double)),
                global::KRPC.Client.Encoder.Encode (vessel, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (title, typeof(string)),
                global::KRPC.Client.Encoder.Encode (description, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_static_AddVesselAlarm", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Alarm)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Alarm), connection);
        }

        /// <summary>
        /// A list of all alarms.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AlarmManager_get_Alarms")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Alarm> Alarms {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AlarmManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AlarmManager_get_Alarms", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Alarm>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Alarm>), connection);
            }
        }
    }

    /// <summary>
    /// An antenna. Obtained by calling <see cref="M:SpaceCenter.Part.Antenna" />.
    /// </summary>
    public class Antenna : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Antenna (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Cancel current transmission of data.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_Cancel")]
        public void Cancel ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
            };
            connection.Invoke ("SpaceCenter", "Antenna_Cancel", _args);
        }

        /// <summary>
        /// Transmit data.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_Transmit")]
        public void Transmit ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
            };
            connection.Invoke ("SpaceCenter", "Antenna_Transmit", _args);
        }

        /// <summary>
        /// Whether partial data transmission is permitted.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_AllowPartial")]
        public bool AllowPartial {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_AllowPartial", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Antenna_set_AllowPartial", _args);
            }
        }

        /// <summary>
        /// Whether data can be transmitted by this antenna.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_CanTransmit")]
        public bool CanTransmit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_CanTransmit", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the antenna can be combined with other antennae on the vessel
        /// to boost the power.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_Combinable")]
        public bool Combinable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_Combinable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Exponent used to calculate the combined power of multiple antennae on a vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_CombinableExponent")]
        public double CombinableExponent {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_CombinableExponent", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Whether the antenna is deployable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_Deployable")]
        public bool Deployable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_Deployable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the antenna is deployed.
        /// </summary>
        /// <remarks>
        /// Fixed antennas are always deployed.
        /// Returns an error if you try to deploy a fixed antenna.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_Deployed")]
        public bool Deployed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_Deployed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Antenna_set_Deployed", _args);
            }
        }

        /// <summary>
        /// Interval between sending packets in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_PacketInterval")]
        public float PacketInterval {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_PacketInterval", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Units of electric charge consumed per packet sent.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_PacketResourceCost")]
        public double PacketResourceCost {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_PacketResourceCost", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Amount of data sent per packet in Mits.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_PacketSize")]
        public float PacketSize {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_PacketSize", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The part object for this antenna.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The power of the antenna.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_Power")]
        public double Power {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_Power", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The current state of the antenna.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Antenna_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.AntennaState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Antenna))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Antenna_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.AntennaState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.AntennaState), connection);
            }
        }
    }

    /// <summary>
    /// Provides basic auto-piloting utilities for a vessel.
    /// Created by calling <see cref="M:SpaceCenter.Vessel.AutoPilot" />.
    /// </summary>
    /// <remarks>
    /// If a client engages the auto-pilot and then closes its connection to the server,
    /// the auto-pilot will be disengaged and its target reference frame, direction and roll
    /// reset to default.
    /// </remarks>
    public class AutoPilot : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public AutoPilot (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Disengage the auto-pilot.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_Disengage")]
        public void Disengage ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_Disengage", _args);
        }

        /// <summary>
        /// Engage the auto-pilot.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_Engage")]
        public void Engage ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_Engage", _args);
        }

        /// <summary>
        /// Set target pitch and heading angles.
        /// </summary>
        /// <param name="pitch">Target pitch angle, in degrees between -90° and +90°.</param>
        /// <param name="heading">Target heading angle, in degrees between 0° and 360°.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_TargetPitchAndHeading")]
        public void TargetPitchAndHeading (float pitch, float heading)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                global::KRPC.Client.Encoder.Encode (pitch, typeof(float)),
                global::KRPC.Client.Encoder.Encode (heading, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_TargetPitchAndHeading", _args);
        }

        /// <summary>
        /// Blocks until the vessel is pointing in the target direction and has
        /// the target roll (if set). Throws an exception if the auto-pilot has not been engaged.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_Wait")]
        public void Wait ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
            };
            connection.Invoke ("SpaceCenter", "AutoPilot_Wait", _args);
        }

        /// <summary>
        /// The angle at which the autopilot considers the vessel to be pointing
        /// close to the target.
        /// This determines the midpoint of the target velocity attenuation function.
        /// A vector of three angles, in degrees, one for each of the pitch, roll and yaw axes.
        /// Defaults to 1° for each axis.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_AttenuationAngle")]
        public systemAlias::Tuple<double,double,double> AttenuationAngle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_AttenuationAngle", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_AttenuationAngle", _args);
            }
        }

        /// <summary>
        /// Whether the rotation rate controllers PID parameters should be automatically tuned
        /// using the vessels moment of inertia and available torque. Defaults to <c>true</c>.
        /// See <see cref="M:SpaceCenter.AutoPilot.TimeToPeak" /> and <see cref="M:SpaceCenter.AutoPilot.Overshoot" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_AutoTune")]
        public bool AutoTune {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_AutoTune", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_AutoTune", _args);
            }
        }

        /// <summary>
        /// The time the vessel should take to come to a stop pointing in the target direction.
        /// This determines the angular acceleration used to decelerate the vessel.
        /// A vector of three times, in seconds, one for each of the pitch, roll and yaw axes.
        /// Defaults to 5 seconds for each axis.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_DecelerationTime")]
        public systemAlias::Tuple<double,double,double> DecelerationTime {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_DecelerationTime", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_DecelerationTime", _args);
            }
        }

        /// <summary>
        /// The error, in degrees, between the direction the ship has been asked
        /// to point in and the direction it is pointing in. Throws an exception if the auto-pilot
        /// has not been engaged and SAS is not enabled or is in stability assist mode.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_Error")]
        public float Error {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_Error", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The error, in degrees, between the vessels current and target heading.
        /// Throws an exception if the auto-pilot has not been engaged.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_HeadingError")]
        public float HeadingError {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_HeadingError", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The target overshoot percentage used to autotune the PID controllers.
        /// A vector of three values, between 0 and 1, for each of the pitch, roll and yaw axes.
        /// Defaults to 0.01 for each axis.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_Overshoot")]
        public systemAlias::Tuple<double,double,double> Overshoot {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_Overshoot", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_Overshoot", _args);
            }
        }

        /// <summary>
        /// The error, in degrees, between the vessels current and target pitch.
        /// Throws an exception if the auto-pilot has not been engaged.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_PitchError")]
        public float PitchError {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_PitchError", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Gains for the pitch PID controller.
        /// </summary>
        /// <remarks>
        /// When <see cref="M:SpaceCenter.AutoPilot.AutoTune" /> is true, these values are updated automatically,
        /// which will overwrite any manual changes.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_PitchPIDGains")]
        public systemAlias::Tuple<double,double,double> PitchPIDGains {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_PitchPIDGains", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_PitchPIDGains", _args);
            }
        }

        /// <summary>
        /// The reference frame for the target direction (<see cref="M:SpaceCenter.AutoPilot.TargetDirection" />).
        /// </summary>
        /// <remarks>
        /// An error will be thrown if this property is set to a reference frame that rotates with
        /// the vessel being controlled, as it is impossible to rotate the vessel in such a
        /// reference frame.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_ReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_ReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_ReferenceFrame", _args);
            }
        }

        /// <summary>
        /// The error, in degrees, between the vessels current and target roll.
        /// Throws an exception if the auto-pilot has not been engaged or no target roll is set.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_RollError")]
        public float RollError {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_RollError", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Gains for the roll PID controller.
        /// </summary>
        /// <remarks>
        /// When <see cref="M:SpaceCenter.AutoPilot.AutoTune" /> is true, these values are updated automatically,
        /// which will overwrite any manual changes.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_RollPIDGains")]
        public systemAlias::Tuple<double,double,double> RollPIDGains {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_RollPIDGains", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_RollPIDGains", _args);
            }
        }

        /// <summary>
        /// The threshold at which the autopilot will try to match the target roll angle, if any.
        /// Defaults to 5 degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_RollThreshold")]
        public double RollThreshold {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_RollThreshold", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_RollThreshold", _args);
            }
        }

        /// <summary>
        /// The state of SAS.
        /// </summary>
        /// <remarks>Equivalent to <see cref="M:SpaceCenter.Control.SAS" /></remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_SAS")]
        public bool SAS {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_SAS", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_SAS", _args);
            }
        }

        /// <summary>
        /// The current <see cref="T:SpaceCenter.SASMode" />.
        /// These modes are equivalent to the mode buttons to the left of the navball that appear
        /// when SAS is enabled.
        /// </summary>
        /// <remarks>Equivalent to <see cref="M:SpaceCenter.Control.SASMode" /></remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_SASMode")]
        public global::KRPC.Client.Services.SpaceCenter.SASMode SASMode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_SASMode", _args);
                return (global::KRPC.Client.Services.SpaceCenter.SASMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.SASMode), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.SASMode))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_SASMode", _args);
            }
        }

        /// <summary>
        /// The maximum amount of time that the vessel should need to come to a complete stop.
        /// This determines the maximum angular velocity of the vessel.
        /// A vector of three stopping times, in seconds, one for each of the pitch, roll
        /// and yaw axes. Defaults to 0.5 seconds for each axis.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_StoppingTime")]
        public systemAlias::Tuple<double,double,double> StoppingTime {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_StoppingTime", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_StoppingTime", _args);
            }
        }

        /// <summary>
        /// Direction vector corresponding to the target pitch and heading.
        /// This is in the reference frame specified by <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TargetDirection")]
        public systemAlias::Tuple<double,double,double> TargetDirection {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TargetDirection", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_TargetDirection", _args);
            }
        }

        /// <summary>
        /// The target heading, in degrees, between 0° and 360°.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TargetHeading")]
        public float TargetHeading {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TargetHeading", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_TargetHeading", _args);
            }
        }

        /// <summary>
        /// The target pitch, in degrees, between -90° and +90°.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TargetPitch")]
        public float TargetPitch {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TargetPitch", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_TargetPitch", _args);
            }
        }

        /// <summary>
        /// The target roll, in degrees. <c>NaN</c> if no target roll is set.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TargetRoll")]
        public float TargetRoll {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TargetRoll", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_TargetRoll", _args);
            }
        }

        /// <summary>
        /// The target time to peak used to autotune the PID controllers.
        /// A vector of three times, in seconds, for each of the pitch, roll and yaw axes.
        /// Defaults to 3 seconds for each axis.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_TimeToPeak")]
        public systemAlias::Tuple<double,double,double> TimeToPeak {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_TimeToPeak", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_TimeToPeak", _args);
            }
        }

        /// <summary>
        /// Gains for the yaw PID controller.
        /// </summary>
        /// <remarks>
        /// When <see cref="M:SpaceCenter.AutoPilot.AutoTune" /> is true, these values are updated automatically,
        /// which will overwrite any manual changes.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "AutoPilot_get_YawPIDGains")]
        public systemAlias::Tuple<double,double,double> YawPIDGains {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "AutoPilot_get_YawPIDGains", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.AutoPilot)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "AutoPilot_set_YawPIDGains", _args);
            }
        }
    }

    /// <summary>
    /// Controls the game's camera.
    /// Obtained by calling <see cref="M:SpaceCenter.Camera" />.
    /// </summary>
    public class Camera : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Camera (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Default distance from the camera to the subject, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_DefaultDistance")]
        public float DefaultDistance {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_DefaultDistance", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The distance from the camera to the subject, in meters.
        /// A value between <see cref="M:SpaceCenter.Camera.MinDistance" /> and <see cref="M:SpaceCenter.Camera.MaxDistance" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_Distance")]
        public float Distance {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_Distance", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Camera_set_Distance", _args);
            }
        }

        /// <summary>
        /// In map mode, the celestial body that the camera is focussed on.
        /// Returns <c>null</c> if the camera is not focussed on a celestial body.
        /// Returns an error is the camera is not in map mode.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_FocussedBody")]
        public global::KRPC.Client.Services.SpaceCenter.CelestialBody FocussedBody {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_FocussedBody", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CelestialBody)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody))
                };
                connection.Invoke ("SpaceCenter", "Camera_set_FocussedBody", _args);
            }
        }

        /// <summary>
        /// In map mode, the maneuver node that the camera is focussed on.
        /// Returns <c>null</c> if the camera is not focussed on a maneuver node.
        /// Returns an error is the camera is not in map mode.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_FocussedNode")]
        public global::KRPC.Client.Services.SpaceCenter.Node FocussedNode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_FocussedNode", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Node)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Node), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.Node))
                };
                connection.Invoke ("SpaceCenter", "Camera_set_FocussedNode", _args);
            }
        }

        /// <summary>
        /// In map mode, the vessel that the camera is focussed on.
        /// Returns <c>null</c> if the camera is not focussed on a vessel.
        /// Returns an error is the camera is not in map mode.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_FocussedVessel")]
        public global::KRPC.Client.Services.SpaceCenter.Vessel FocussedVessel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_FocussedVessel", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel))
                };
                connection.Invoke ("SpaceCenter", "Camera_set_FocussedVessel", _args);
            }
        }

        /// <summary>
        /// The heading of the camera, in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_Heading")]
        public float Heading {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_Heading", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Camera_set_Heading", _args);
            }
        }

        /// <summary>
        /// Maximum distance from the camera to the subject, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_MaxDistance")]
        public float MaxDistance {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_MaxDistance", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The maximum pitch of the camera.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_MaxPitch")]
        public float MaxPitch {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_MaxPitch", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Minimum distance from the camera to the subject, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_MinDistance")]
        public float MinDistance {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_MinDistance", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The minimum pitch of the camera.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_MinPitch")]
        public float MinPitch {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_MinPitch", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The current mode of the camera.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_Mode")]
        public global::KRPC.Client.Services.SpaceCenter.CameraMode Mode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_Mode", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CameraMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CameraMode), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.CameraMode))
                };
                connection.Invoke ("SpaceCenter", "Camera_set_Mode", _args);
            }
        }

        /// <summary>
        /// The pitch of the camera, in degrees.
        /// A value between <see cref="M:SpaceCenter.Camera.MinPitch" /> and <see cref="M:SpaceCenter.Camera.MaxPitch" /></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Camera_get_Pitch")]
        public float Pitch {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Camera_get_Pitch", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Camera)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Camera_set_Pitch", _args);
            }
        }
    }

    /// <summary>
    /// A cargo bay. Obtained by calling <see cref="M:SpaceCenter.Part.CargoBay" />.
    /// </summary>
    public class CargoBay : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public CargoBay (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the cargo bay is open.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CargoBay_get_Open")]
        public bool Open {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CargoBay))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CargoBay_get_Open", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CargoBay)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "CargoBay_set_Open", _args);
            }
        }

        /// <summary>
        /// The part object for this cargo bay.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CargoBay_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CargoBay))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CargoBay_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The state of the cargo bay.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CargoBay_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.CargoBayState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CargoBay))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CargoBay_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CargoBayState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CargoBayState), connection);
            }
        }
    }

    /// <summary>
    /// Represents a celestial body (such as a planet or moon).
    /// See <see cref="M:SpaceCenter.Bodies" />.
    /// </summary>
    public class CelestialBody : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public CelestialBody (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// The altitude, in meters, of the given position in the given reference frame.
        /// </summary>
        /// <param name="position">Position as a vector.</param>
        /// <param name="referenceFrame">Reference frame for the position vector.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_AltitudeAtPosition")]
        public double AltitudeAtPosition (systemAlias::Tuple<double,double,double> position, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_AltitudeAtPosition", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The angular velocity of the body in the specified reference frame.
        /// </summary>
        /// <returns>The angular velocity as a vector. The magnitude of the vector is the rotational
        /// speed of the body, in radians per second. The direction of the vector indicates the axis
        /// of rotation, using the right-hand rule.</returns>
        /// <param name="referenceFrame">The reference frame the returned
        /// angular velocity is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_AngularVelocity")]
        public systemAlias::Tuple<double,double,double> AngularVelocity (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_AngularVelocity", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The atmospheric density at the given position, in <math>kg/m^3</math>,
        /// in the given reference frame.
        /// </summary>
        /// <param name="position">The position vector at which to measure the density.</param>
        /// <param name="referenceFrame">Reference frame that the position vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition")]
        public double AtmosphericDensityAtPosition (systemAlias::Tuple<double,double,double> position, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The height of the surface relative to mean sea level, in meters,
        /// at the given position. When over water, this is the height
        /// of the sea-bed and is therefore  negative value.
        /// </summary>
        /// <param name="latitude">Latitude in degrees.</param>
        /// <param name="longitude">Longitude in degrees.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_BedrockHeight")]
        public double BedrockHeight (double latitude, double longitude)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (longitude, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_BedrockHeight", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The position of the surface at the given latitude and longitude, in the given
        /// reference frame. When over water, this is the position at the bottom of the sea-bed.
        /// </summary>
        /// <returns>Position as a vector.</returns>
        /// <param name="latitude">Latitude in degrees.</param>
        /// <param name="longitude">Longitude in degrees.</param>
        /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_BedrockPosition")]
        public systemAlias::Tuple<double,double,double> BedrockPosition (double latitude, double longitude, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_BedrockPosition", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The biome at the given latitude and longitude, in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_BiomeAt")]
        public string BiomeAt (double latitude, double longitude)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (longitude, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_BiomeAt", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }

        /// <summary>
        /// Gets the air density, in <math>kg/m^3</math>, for the specified
        /// altitude above sea level, in meters.
        /// </summary>
        /// <remarks>
        /// This is an approximation, because actual calculations, taking sun exposure into account
        /// to compute air temperature, require us to know the exact point on the body where the
        /// density is to be computed (knowing the altitude is not enough).
        /// However, the difference is small for high altitudes, so it makes very little difference
        /// for trajectory prediction.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_DensityAt")]
        public double DensityAt (double altitude)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (altitude, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_DensityAt", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The direction in which the north pole of the celestial body is pointing,
        /// in the specified reference frame.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// direction is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_Direction")]
        public systemAlias::Tuple<double,double,double> Direction (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_Direction", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The latitude of the given position, in the given reference frame.
        /// </summary>
        /// <param name="position">Position as a vector.</param>
        /// <param name="referenceFrame">Reference frame for the position vector.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_LatitudeAtPosition")]
        public double LatitudeAtPosition (systemAlias::Tuple<double,double,double> position, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_LatitudeAtPosition", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The longitude of the given position, in the given reference frame.
        /// </summary>
        /// <param name="position">Position as a vector.</param>
        /// <param name="referenceFrame">Reference frame for the position vector.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_LongitudeAtPosition")]
        public double LongitudeAtPosition (systemAlias::Tuple<double,double,double> position, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_LongitudeAtPosition", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The position at mean sea level at the given latitude and longitude,
        /// in the given reference frame.
        /// </summary>
        /// <returns>Position as a vector.</returns>
        /// <param name="latitude">Latitude in degrees.</param>
        /// <param name="longitude">Longitude in degrees.</param>
        /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_MSLPosition")]
        public systemAlias::Tuple<double,double,double> MSLPosition (double latitude, double longitude, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_MSLPosition", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The position of the center of the body, in the specified reference frame.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_Position")]
        public systemAlias::Tuple<double,double,double> Position (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_Position", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The position at the given latitude, longitude and altitude, in the given reference frame.
        /// </summary>
        /// <returns>Position as a vector.</returns>
        /// <param name="latitude">Latitude in degrees.</param>
        /// <param name="longitude">Longitude in degrees.</param>
        /// <param name="altitude">Altitude in meters above sea level.</param>
        /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_PositionAtAltitude")]
        public systemAlias::Tuple<double,double,double> PositionAtAltitude (double latitude, double longitude, double altitude, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (altitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_PositionAtAltitude", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// Gets the air pressure, in Pascals, for the specified
        /// altitude above sea level, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_PressureAt")]
        public double PressureAt (double altitude)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (altitude, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_PressureAt", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The rotation of the body, in the specified reference frame.
        /// </summary>
        /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// rotation is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_Rotation")]
        public systemAlias::Tuple<double,double,double,double> Rotation (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_Rotation", _args);
            return (systemAlias::Tuple<double,double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double,double>), connection);
        }

        /// <summary>
        /// The height of the surface relative to mean sea level, in meters,
        /// at the given position. When over water this is equal to 0.
        /// </summary>
        /// <param name="latitude">Latitude in degrees.</param>
        /// <param name="longitude">Longitude in degrees.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_SurfaceHeight")]
        public double SurfaceHeight (double latitude, double longitude)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (longitude, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_SurfaceHeight", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The position of the surface at the given latitude and longitude, in the given
        /// reference frame. When over water, this is the position of the surface of the water.
        /// </summary>
        /// <returns>Position as a vector.</returns>
        /// <param name="latitude">Latitude in degrees.</param>
        /// <param name="longitude">Longitude in degrees.</param>
        /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_SurfacePosition")]
        public systemAlias::Tuple<double,double,double> SurfacePosition (double latitude, double longitude, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_SurfacePosition", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The temperature on the body at the given position, in the given reference frame.
        /// </summary>
        /// <param name="position">Position as a vector.</param>
        /// <param name="referenceFrame">The reference frame that the position is in.</param>
        /// <remarks>
        /// This calculation is performed using the bodies current position, which means that
        /// the value could be wrong if you want to know the temperature in the far future.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_TemperatureAt")]
        public double TemperatureAt (systemAlias::Tuple<double,double,double> position, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_TemperatureAt", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The linear velocity of the body, in the specified reference frame.
        /// </summary>
        /// <returns>The velocity as a vector. The vector points in the direction of travel,
        /// and its magnitude is the speed of the body in meters per second.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// velocity vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_Velocity")]
        public systemAlias::Tuple<double,double,double> Velocity (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_Velocity", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The depth of the atmosphere, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_AtmosphereDepth")]
        public double AtmosphereDepth {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_AtmosphereDepth", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The biomes present on this body.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Biomes")]
        public genericCollectionsAlias::ISet<string> Biomes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Biomes", _args);
                return (genericCollectionsAlias::ISet<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(genericCollectionsAlias::ISet<string>), connection);
            }
        }

        /// <summary>
        /// The equatorial radius of the body, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_EquatorialRadius")]
        public double EquatorialRadius {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_EquatorialRadius", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The altitude, in meters, above which a vessel is considered to be
        /// flying "high" when doing science.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold")]
        public float FlyingHighAltitudeThreshold {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Standard_gravitational_parameter">standard
        /// gravitational parameter</a> of the body in <math>m^3s^{-2}</math>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_GravitationalParameter")]
        public double GravitationalParameter {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_GravitationalParameter", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary><c>true</c> if the body has an atmosphere.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_HasAtmosphere")]
        public bool HasAtmosphere {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_HasAtmosphere", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary><c>true</c> if there is oxygen in the atmosphere, required for air-breathing engines.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen")]
        public bool HasAtmosphericOxygen {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether or not the body has a solid surface.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_HasSolidSurface")]
        public bool HasSolidSurface {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_HasSolidSurface", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The initial rotation angle of the body (at UT 0), in radians.
        /// A value between 0 and <math>2\pi</math></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_InitialRotation")]
        public double InitialRotation {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_InitialRotation", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Whether or not the body is a star.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_IsStar")]
        public bool IsStar {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_IsStar", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The mass of the body, in kilograms.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Mass")]
        public double Mass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Mass", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The name of the body.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to this celestial body, and
        /// orientated in a fixed direction (it does not rotate with the body).
        /// <list type="bullet"><item><description>The origin is at the center of the body.</description></item><item><description>The axes do not rotate.</description></item><item><description>The x-axis points in an arbitrary direction through the
        /// equator.</description></item><item><description>The y-axis points from the center of the body towards
        /// the north pole.</description></item><item><description>The z-axis points in an arbitrary direction through the
        /// equator.</description></item></list></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame NonRotatingReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// The orbit of the body.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Orbit")]
        public global::KRPC.Client.Services.SpaceCenter.Orbit Orbit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Orbit", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Orbit)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to this celestial body, but
        /// orientated with the body's orbital prograde/normal/radial directions.
        /// <list type="bullet"><item><description>The origin is at the center of the body.
        /// </description></item><item><description>The axes rotate with the orbital prograde/normal/radial
        /// directions.</description></item><item><description>The x-axis points in the orbital anti-radial direction.
        /// </description></item><item><description>The y-axis points in the orbital prograde direction.
        /// </description></item><item><description>The z-axis points in the orbital normal direction.
        /// </description></item></list></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame OrbitalReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to the celestial body.
        /// <list type="bullet"><item><description>The origin is at the center of the body.
        /// </description></item><item><description>The axes rotate with the body.</description></item><item><description>The x-axis points from the center of the body
        /// towards the intersection of the prime meridian and equator (the
        /// position at 0° longitude, 0° latitude).</description></item><item><description>The y-axis points from the center of the body
        /// towards the north pole.</description></item><item><description>The z-axis points from the center of the body
        /// towards the equator at 90°E longitude.</description></item></list></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_ReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_ReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// The current rotation angle of the body, in radians.
        /// A value between 0 and <math>2\pi</math></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_RotationAngle")]
        public double RotationAngle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_RotationAngle", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The sidereal rotational period of the body, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_RotationalPeriod")]
        public double RotationalPeriod {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_RotationalPeriod", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The rotational speed of the body, in radians per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_RotationalSpeed")]
        public double RotationalSpeed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_RotationalSpeed", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// A list of celestial bodies that are in orbit around this celestial body.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Satellites")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CelestialBody> Satellites {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Satellites", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CelestialBody>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CelestialBody>), connection);
            }
        }

        /// <summary>
        /// The altitude, in meters, above which a vessel is considered to be
        /// in "high" space when doing science.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold")]
        public float SpaceHighAltitudeThreshold {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The radius of the sphere of influence of the body, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_SphereOfInfluence")]
        public double SphereOfInfluence {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_SphereOfInfluence", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The acceleration due to gravity at sea level (mean altitude) on the body,
        /// in <math>m/s^2</math>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_SurfaceGravity")]
        public double SurfaceGravity {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CelestialBody))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_SurfaceGravity", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }
    }

    /// <summary>
    /// Represents a communication node in the network. For example, a vessel or the KSC.
    /// </summary>
    public class CommLink : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public CommLink (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Start point of the link.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommLink_get_End")]
        public global::KRPC.Client.Services.SpaceCenter.CommNode End {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CommLink))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CommLink_get_End", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CommNode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CommNode), connection);
            }
        }

        /// <summary>
        /// Signal strength of the link.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommLink_get_SignalStrength")]
        public double SignalStrength {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CommLink))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CommLink_get_SignalStrength", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Start point of the link.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommLink_get_Start")]
        public global::KRPC.Client.Services.SpaceCenter.CommNode Start {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CommLink))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CommLink_get_Start", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CommNode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CommNode), connection);
            }
        }

        /// <summary>
        /// The type of link.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommLink_get_Type")]
        public global::KRPC.Client.Services.SpaceCenter.CommLinkType Type {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CommLink))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CommLink_get_Type", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CommLinkType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CommLinkType), connection);
            }
        }
    }

    /// <summary>
    /// Represents a communication node in the network. For example, a vessel or the KSC.
    /// </summary>
    public class CommNode : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public CommNode (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the communication node is a control point, for example a manned vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_IsControlPoint")]
        public bool IsControlPoint {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CommNode))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_IsControlPoint", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the communication node is on Kerbin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_IsHome")]
        public bool IsHome {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CommNode))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_IsHome", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the communication node is a vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_IsVessel")]
        public bool IsVessel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CommNode))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_IsVessel", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Name of the communication node.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CommNode))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// The vessel for this communication node.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CommNode_get_Vessel")]
        public global::KRPC.Client.Services.SpaceCenter.Vessel Vessel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CommNode))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CommNode_get_Vessel", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel), connection);
            }
        }
    }

    /// <summary>
    /// Used to interact with CommNet for a given vessel.
    /// Obtained by calling <see cref="M:SpaceCenter.Vessel.Comms" />.
    /// </summary>
    public class Comms : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Comms (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the vessel can communicate with KSC.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Comms_get_CanCommunicate")]
        public bool CanCommunicate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Comms))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Comms_get_CanCommunicate", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the vessel can transmit science data to KSC.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Comms_get_CanTransmitScience")]
        public bool CanTransmitScience {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Comms))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Comms_get_CanTransmitScience", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The communication path used to control the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Comms_get_ControlPath")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CommLink> ControlPath {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Comms))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Comms_get_ControlPath", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CommLink>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CommLink>), connection);
            }
        }

        /// <summary>
        /// The combined power of all active antennae on the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Comms_get_Power")]
        public double Power {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Comms))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Comms_get_Power", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Signal delay to KSC in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Comms_get_SignalDelay")]
        public double SignalDelay {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Comms))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Comms_get_SignalDelay", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Signal strength to KSC.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Comms_get_SignalStrength")]
        public double SignalStrength {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Comms))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Comms_get_SignalStrength", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }
    }

    /// <summary>
    /// A contract. Can be accessed using <see cref="M:SpaceCenter.ContractManager" />.
    /// </summary>
    public class Contract : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Contract (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Accept an offered contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_Accept")]
        public void Accept ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
            };
            connection.Invoke ("SpaceCenter", "Contract_Accept", _args);
        }

        /// <summary>
        /// Cancel an active contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_Cancel")]
        public void Cancel ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
            };
            connection.Invoke ("SpaceCenter", "Contract_Cancel", _args);
        }

        /// <summary>
        /// Decline an offered contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_Decline")]
        public void Decline ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
            };
            connection.Invoke ("SpaceCenter", "Contract_Decline", _args);
        }

        /// <summary>
        /// Whether the contract is active.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Active")]
        public bool Active {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Active", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the contract can be canceled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_CanBeCanceled")]
        public bool CanBeCanceled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_CanBeCanceled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the contract can be declined.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_CanBeDeclined")]
        public bool CanBeDeclined {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_CanBeDeclined", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the contract can be failed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_CanBeFailed")]
        public bool CanBeFailed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_CanBeFailed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Description of the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Description")]
        public string Description {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Description", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// Whether the contract has been failed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Failed")]
        public bool Failed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Failed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Funds received when accepting the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_FundsAdvance")]
        public double FundsAdvance {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_FundsAdvance", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Funds received on completion of the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_FundsCompletion")]
        public double FundsCompletion {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_FundsCompletion", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Funds lost if the contract is failed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_FundsFailure")]
        public double FundsFailure {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_FundsFailure", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Keywords for the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Keywords")]
        public global::System.Collections.Generic.IList<string> Keywords {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Keywords", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// Notes for the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Notes")]
        public string Notes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Notes", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// Parameters for the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Parameters")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ContractParameter> Parameters {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Parameters", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ContractParameter>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ContractParameter>), connection);
            }
        }

        /// <summary>
        /// Whether the contract has been read.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Read")]
        public bool Read {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Read", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Reputation gained on completion of the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_ReputationCompletion")]
        public double ReputationCompletion {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_ReputationCompletion", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Reputation lost if the contract is failed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_ReputationFailure")]
        public double ReputationFailure {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_ReputationFailure", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Science gained on completion of the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_ScienceCompletion")]
        public double ScienceCompletion {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_ScienceCompletion", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Whether the contract has been seen.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Seen")]
        public bool Seen {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Seen", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// State of the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.ContractState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ContractState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ContractState), connection);
            }
        }

        /// <summary>
        /// Synopsis for the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Synopsis")]
        public string Synopsis {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Synopsis", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// Title of the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Title")]
        public string Title {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Title", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// Type of the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Type")]
        public string Type {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Contract))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Type", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }
    }

    /// <summary>
    /// Contracts manager.
    /// Obtained by calling <see cref="M:SpaceCenter.ContractManager" />.
    /// </summary>
    public class ContractManager : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ContractManager (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// A list of all active contracts.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_ActiveContracts")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract> ActiveContracts {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_ActiveContracts", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>), connection);
            }
        }

        /// <summary>
        /// A list of all contracts.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_AllContracts")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract> AllContracts {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_AllContracts", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>), connection);
            }
        }

        /// <summary>
        /// A list of all completed contracts.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_CompletedContracts")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract> CompletedContracts {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_CompletedContracts", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>), connection);
            }
        }

        /// <summary>
        /// A list of all failed contracts.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_FailedContracts")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract> FailedContracts {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_FailedContracts", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>), connection);
            }
        }

        /// <summary>
        /// A list of all offered, but unaccepted, contracts.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_OfferedContracts")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract> OfferedContracts {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_OfferedContracts", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Contract>), connection);
            }
        }

        /// <summary>
        /// A list of all contract types.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_Types")]
        public genericCollectionsAlias::ISet<string> Types {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_Types", _args);
                return (genericCollectionsAlias::ISet<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(genericCollectionsAlias::ISet<string>), connection);
            }
        }
    }

    /// <summary>
    /// A contract parameter. See <see cref="M:SpaceCenter.Contract.Parameters" />.
    /// </summary>
    public class ContractParameter : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ContractParameter (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Child contract parameters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_Children")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ContractParameter> Children {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_Children", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ContractParameter>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ContractParameter>), connection);
            }
        }

        /// <summary>
        /// Whether the parameter has been completed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_Completed")]
        public bool Completed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_Completed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the parameter has been failed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_Failed")]
        public bool Failed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_Failed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Funds received on completion of the contract parameter.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_FundsCompletion")]
        public double FundsCompletion {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_FundsCompletion", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Funds lost if the contract parameter is failed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_FundsFailure")]
        public double FundsFailure {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_FundsFailure", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Notes for the parameter.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_Notes")]
        public string Notes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_Notes", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// Whether the contract parameter is optional.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_Optional")]
        public bool Optional {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_Optional", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Reputation gained on completion of the contract parameter.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_ReputationCompletion")]
        public double ReputationCompletion {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_ReputationCompletion", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Reputation lost if the contract parameter is failed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_ReputationFailure")]
        public double ReputationFailure {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_ReputationFailure", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Science gained on completion of the contract parameter.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_ScienceCompletion")]
        public double ScienceCompletion {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_ScienceCompletion", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Title of the parameter.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractParameter_get_Title")]
        public string Title {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ContractParameter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ContractParameter_get_Title", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }
    }

    /// <summary>
    /// Used to manipulate the controls of a vessel. This includes adjusting the
    /// throttle, enabling/disabling systems such as SAS and RCS, or altering the
    /// direction in which the vessel is pointing.
    /// Obtained by calling <see cref="M:SpaceCenter.Vessel.Control" />.
    /// </summary>
    /// <remarks>
    /// Control inputs (such as pitch, yaw and roll) are zeroed when all clients
    /// that have set one or more of these inputs are no longer connected.
    /// </remarks>
    public class Control : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Control (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Activates the next stage. Equivalent to pressing the space bar in-game.
        /// </summary>
        /// <returns>A list of vessel objects that are jettisoned from the active vessel.</returns>
        /// <remarks>
        /// When called, the active vessel may change. It is therefore possible that,
        /// after calling this function, the object(s) returned by previous call(s) to
        /// <see cref="M:SpaceCenter.ActiveVessel" /> no longer refer to the active vessel.
        /// Throws an exception if staging is locked.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_ActivateNextStage")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Vessel> ActivateNextStage ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_ActivateNextStage", _args);
            return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Vessel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Vessel>), connection);
        }

        /// <summary>
        /// Creates a maneuver node at the given universal time, and returns a
        /// <see cref="T:SpaceCenter.Node" /> object that can be used to modify it.
        /// Optionally sets the magnitude of the delta-v for the maneuver node
        /// in the prograde, normal and radial directions.
        /// </summary>
        /// <param name="ut">Universal time of the maneuver node.</param>
        /// <param name="prograde">Delta-v in the prograde direction.</param>
        /// <param name="normal">Delta-v in the normal direction.</param>
        /// <param name="radial">Delta-v in the radial direction.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_AddNode")]
        public global::KRPC.Client.Services.SpaceCenter.Node AddNode (double ut, float prograde = 0.0f, float normal = 0.0f, float radial = 0.0f)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (ut, typeof(double)),
                global::KRPC.Client.Encoder.Encode (prograde, typeof(float)),
                global::KRPC.Client.Encoder.Encode (normal, typeof(float)),
                global::KRPC.Client.Encoder.Encode (radial, typeof(float))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_AddNode", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Node)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Node), connection);
        }

        /// <summary>
        /// Returns <c>true</c> if the given action group is enabled.
        /// </summary>
        /// <param name="group">
        /// A number between 0 and 9 inclusive,
        /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
        /// </param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_GetActionGroup")]
        public bool GetActionGroup (uint group)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (group, typeof(uint))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Control_GetActionGroup", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// Remove all maneuver nodes.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_RemoveNodes")]
        public void RemoveNodes ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
            };
            connection.Invoke ("SpaceCenter", "Control_RemoveNodes", _args);
        }

        /// <summary>
        /// Sets the state of the given action group.
        /// </summary>
        /// <param name="group">
        /// A number between 0 and 9 inclusive,
        /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
        /// </param>
        /// <param name="state"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_SetActionGroup")]
        public void SetActionGroup (uint group, bool state)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (group, typeof(uint)),
                global::KRPC.Client.Encoder.Encode (state, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Control_SetActionGroup", _args);
        }

        /// <summary>
        /// Toggles the state of the given action group.
        /// </summary>
        /// <param name="group">
        /// A number between 0 and 9 inclusive,
        /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
        /// </param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_ToggleActionGroup")]
        public void ToggleActionGroup (uint group)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                global::KRPC.Client.Encoder.Encode (group, typeof(uint))
            };
            connection.Invoke ("SpaceCenter", "Control_ToggleActionGroup", _args);
        }

        /// <summary>
        /// The state of the abort action group.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Abort")]
        public bool Abort {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Abort", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Abort", _args);
            }
        }

        /// <summary>
        /// Returns whether all antennas on the vessel are deployed,
        /// and sets the deployment state of all antennas.
        /// See <see cref="M:SpaceCenter.Antenna.Deployed" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Antennas")]
        public bool Antennas {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Antennas", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Antennas", _args);
            }
        }

        /// <summary>
        /// The state of the wheel brakes.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Brakes")]
        public bool Brakes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Brakes", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Brakes", _args);
            }
        }

        /// <summary>
        /// Returns whether any of the cargo bays on the vessel are open,
        /// and sets the open state of all cargo bays.
        /// See <see cref="M:SpaceCenter.CargoBay.Open" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CargoBays")]
        public bool CargoBays {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CargoBays", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_CargoBays", _args);
            }
        }

        /// <summary>
        /// The current stage of the vessel. Corresponds to the stage number in
        /// the in-game UI.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CurrentStage")]
        public int CurrentStage {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CurrentStage", _args);
                return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
            }
        }

        /// <summary>
        /// The state of CustomAxis01.
        /// A value between -1 and 1.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CustomAxis01")]
        public float CustomAxis01 {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CustomAxis01", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_CustomAxis01", _args);
            }
        }

        /// <summary>
        /// The state of CustomAxis02.
        /// A value between -1 and 1.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CustomAxis02")]
        public float CustomAxis02 {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CustomAxis02", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_CustomAxis02", _args);
            }
        }

        /// <summary>
        /// The state of CustomAxis03.
        /// A value between -1 and 1.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CustomAxis03")]
        public float CustomAxis03 {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CustomAxis03", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_CustomAxis03", _args);
            }
        }

        /// <summary>
        /// The state of CustomAxis04.
        /// A value between -1 and 1.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_CustomAxis04")]
        public float CustomAxis04 {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_CustomAxis04", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_CustomAxis04", _args);
            }
        }

        /// <summary>
        /// The state of the forward translational control.
        /// A value between -1 and 1.
        /// Equivalent to the h and n keys.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Forward")]
        public float Forward {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Forward", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Forward", _args);
            }
        }

        /// <summary>
        /// The state of the landing gear/legs.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Gear")]
        public bool Gear {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Gear", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Gear", _args);
            }
        }

        /// <summary>
        /// Sets the behavior of the pitch, yaw, roll and translation control inputs.
        /// When set to additive, these inputs are added to the vessels current inputs.
        /// This mode is the default.
        /// When set to override, these inputs (if non-zero) override the vessels inputs.
        /// This mode prevents keyboard control, or SAS, from interfering with the controls when
        /// they are set.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_InputMode")]
        public global::KRPC.Client.Services.SpaceCenter.ControlInputMode InputMode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_InputMode", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ControlInputMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ControlInputMode), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.ControlInputMode))
                };
                connection.Invoke ("SpaceCenter", "Control_set_InputMode", _args);
            }
        }

        /// <summary>
        /// Returns whether all of the air intakes on the vessel are open,
        /// and sets the open state of all air intakes.
        /// See <see cref="M:SpaceCenter.Intake.Open" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Intakes")]
        public bool Intakes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Intakes", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Intakes", _args);
            }
        }

        /// <summary>
        /// Returns whether all landing legs on the vessel are deployed,
        /// and sets the deployment state of all landing legs.
        /// Does not include wheels (for example landing gear).
        /// See <see cref="M:SpaceCenter.Leg.Deployed" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Legs")]
        public bool Legs {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Legs", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Legs", _args);
            }
        }

        /// <summary>
        /// The state of the lights.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Lights")]
        public bool Lights {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Lights", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Lights", _args);
            }
        }

        /// <summary>
        /// Returns a list of all existing maneuver nodes, ordered by time from first to last.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Nodes")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Node> Nodes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Nodes", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Node>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Node>), connection);
            }
        }

        /// <summary>
        /// Returns whether all parachutes on the vessel are deployed,
        /// and sets the deployment state of all parachutes.
        /// Cannot be set to <c>false</c>.
        /// See <see cref="M:SpaceCenter.Parachute.Deployed" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Parachutes")]
        public bool Parachutes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Parachutes", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Parachutes", _args);
            }
        }

        /// <summary>
        /// The state of the pitch control.
        /// A value between -1 and 1.
        /// Equivalent to the w and s keys.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Pitch")]
        public float Pitch {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Pitch", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Pitch", _args);
            }
        }

        /// <summary>
        /// The state of RCS.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_RCS")]
        public bool RCS {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_RCS", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_RCS", _args);
            }
        }

        /// <summary>
        /// Returns whether all radiators on the vessel are deployed,
        /// and sets the deployment state of all radiators.
        /// See <see cref="M:SpaceCenter.Radiator.Deployed" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Radiators")]
        public bool Radiators {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Radiators", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Radiators", _args);
            }
        }

        /// <summary>
        /// Returns whether all reactive wheels on the vessel are active,
        /// and sets the active state of all reaction wheels.
        /// See <see cref="M:SpaceCenter.ReactionWheel.Active" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_ReactionWheels")]
        public bool ReactionWheels {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_ReactionWheels", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_ReactionWheels", _args);
            }
        }

        /// <summary>
        /// Returns whether all of the resource harvesters on the vessel are deployed,
        /// and sets the deployment state of all resource harvesters.
        /// See <see cref="M:SpaceCenter.ResourceHarvester.Deployed" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_ResourceHarvesters")]
        public bool ResourceHarvesters {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_ResourceHarvesters", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_ResourceHarvesters", _args);
            }
        }

        /// <summary>
        /// Returns whether any of the resource harvesters on the vessel are active,
        /// and sets the active state of all resource harvesters.
        /// See <see cref="M:SpaceCenter.ResourceHarvester.Active" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_ResourceHarvestersActive")]
        public bool ResourceHarvestersActive {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_ResourceHarvestersActive", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_ResourceHarvestersActive", _args);
            }
        }

        /// <summary>
        /// The state of the right translational control.
        /// A value between -1 and 1.
        /// Equivalent to the j and l keys.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Right")]
        public float Right {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Right", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Right", _args);
            }
        }

        /// <summary>
        /// The state of the roll control.
        /// A value between -1 and 1.
        /// Equivalent to the q and e keys.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Roll")]
        public float Roll {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Roll", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Roll", _args);
            }
        }

        /// <summary>
        /// The state of SAS.
        /// </summary>
        /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.SAS" /></remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_SAS")]
        public bool SAS {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_SAS", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_SAS", _args);
            }
        }

        /// <summary>
        /// The current <see cref="T:SpaceCenter.SASMode" />.
        /// These modes are equivalent to the mode buttons to
        /// the left of the navball that appear when SAS is enabled.
        /// </summary>
        /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.SASMode" /></remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_SASMode")]
        public global::KRPC.Client.Services.SpaceCenter.SASMode SASMode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_SASMode", _args);
                return (global::KRPC.Client.Services.SpaceCenter.SASMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.SASMode), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.SASMode))
                };
                connection.Invoke ("SpaceCenter", "Control_set_SASMode", _args);
            }
        }

        /// <summary>
        /// Returns whether all solar panels on the vessel are deployed,
        /// and sets the deployment state of all solar panels.
        /// See <see cref="M:SpaceCenter.SolarPanel.Deployed" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_SolarPanels")]
        public bool SolarPanels {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_SolarPanels", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_SolarPanels", _args);
            }
        }

        /// <summary>
        /// The source of the vessels control, for example by a kerbal or a probe core.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Source")]
        public global::KRPC.Client.Services.SpaceCenter.ControlSource Source {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Source", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ControlSource)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ControlSource), connection);
            }
        }

        /// <summary>
        /// The current <see cref="T:SpaceCenter.SpeedMode" /> of the navball.
        /// This is the mode displayed next to the speed at the top of the navball.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_SpeedMode")]
        public global::KRPC.Client.Services.SpaceCenter.SpeedMode SpeedMode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_SpeedMode", _args);
                return (global::KRPC.Client.Services.SpaceCenter.SpeedMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.SpeedMode), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.SpeedMode))
                };
                connection.Invoke ("SpaceCenter", "Control_set_SpeedMode", _args);
            }
        }

        /// <summary>
        /// Whether staging is locked on the vessel.
        /// </summary>
        /// <remarks>
        /// This is equivalent to locking the staging using Alt+L
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_StageLock")]
        public bool StageLock {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_StageLock", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_StageLock", _args);
            }
        }

        /// <summary>
        /// The control state of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.ControlState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ControlState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ControlState), connection);
            }
        }

        /// <summary>
        /// The state of the throttle. A value between 0 and 1.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Throttle")]
        public float Throttle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Throttle", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Throttle", _args);
            }
        }

        /// <summary>
        /// The state of the up translational control.
        /// A value between -1 and 1.
        /// Equivalent to the i and k keys.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Up")]
        public float Up {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Up", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Up", _args);
            }
        }

        /// <summary>
        /// The state of the wheel steering.
        /// A value between -1 and 1.
        /// A value of 1 steers to the left, and a value of -1 steers to the right.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_WheelSteering")]
        public float WheelSteering {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_WheelSteering", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_WheelSteering", _args);
            }
        }

        /// <summary>
        /// The state of the wheel throttle.
        /// A value between -1 and 1.
        /// A value of 1 rotates the wheels forwards, a value of -1 rotates
        /// the wheels backwards.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_WheelThrottle")]
        public float WheelThrottle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_WheelThrottle", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_WheelThrottle", _args);
            }
        }

        /// <summary>
        /// Returns whether all wheels on the vessel are deployed,
        /// and sets the deployment state of all wheels.
        /// Does not include landing legs.
        /// See <see cref="M:SpaceCenter.Wheel.Deployed" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Wheels")]
        public bool Wheels {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Wheels", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Wheels", _args);
            }
        }

        /// <summary>
        /// The state of the yaw control.
        /// A value between -1 and 1.
        /// Equivalent to the a and d keys.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Control_get_Yaw")]
        public float Yaw {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Control_get_Yaw", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Control)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Control_set_Yaw", _args);
            }
        }
    }

    /// <summary>
    /// An aerodynamic control surface. Obtained by calling <see cref="M:SpaceCenter.Part.ControlSurface" />.
    /// </summary>
    public class ControlSurface : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ControlSurface (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// The authority limiter for the control surface, which controls how far the
        /// control surface will move.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_AuthorityLimiter")]
        public float AuthorityLimiter {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_AuthorityLimiter", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "ControlSurface_set_AuthorityLimiter", _args);
            }
        }

        /// <summary>
        /// The available torque, in Newton meters, that can be produced by this control surface,
        /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
        /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_AvailableTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_AvailableTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// Whether the control surface has been fully deployed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_Deployed")]
        public bool Deployed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_Deployed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "ControlSurface_set_Deployed", _args);
            }
        }

        /// <summary>
        /// Whether the control surface movement is inverted.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_Inverted")]
        public bool Inverted {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_Inverted", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "ControlSurface_set_Inverted", _args);
            }
        }

        /// <summary>
        /// The part object for this control surface.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Whether the control surface has pitch control enabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_PitchEnabled")]
        public bool PitchEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_PitchEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "ControlSurface_set_PitchEnabled", _args);
            }
        }

        /// <summary>
        /// Whether the control surface has roll control enabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_RollEnabled")]
        public bool RollEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_RollEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "ControlSurface_set_RollEnabled", _args);
            }
        }

        /// <summary>
        /// Surface area of the control surface in <math>m^2</math>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_SurfaceArea")]
        public float SurfaceArea {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_SurfaceArea", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the control surface has yaw control enabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ControlSurface_get_YawEnabled")]
        public bool YawEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ControlSurface_get_YawEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ControlSurface)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "ControlSurface_set_YawEnabled", _args);
            }
        }
    }

    /// <summary>
    /// Represents crew in a vessel. Can be obtained using <see cref="M:SpaceCenter.Vessel.Crew" />.
    /// </summary>
    public class CrewMember : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public CrewMember (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the crew member is a badass.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_Badass")]
        public bool Badass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Badass", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "CrewMember_set_Badass", _args);
            }
        }

        /// <summary>
        /// The flight IDs for each entry in the career flight log.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_CareerLogFlights")]
        public global::System.Collections.Generic.IList<int> CareerLogFlights {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_CareerLogFlights", _args);
                return (global::System.Collections.Generic.IList<int>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<int>), connection);
            }
        }

        /// <summary>
        /// The body name for each entry in the career flight log.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_CareerLogTargets")]
        public global::System.Collections.Generic.IList<string> CareerLogTargets {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_CareerLogTargets", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// The type for each entry in the career flight log.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_CareerLogTypes")]
        public global::System.Collections.Generic.IList<string> CareerLogTypes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_CareerLogTypes", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// The crew members courage.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_Courage")]
        public float Courage {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Courage", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "CrewMember_set_Courage", _args);
            }
        }

        /// <summary>
        /// The crew members experience.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_Experience")]
        public float Experience {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Experience", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "CrewMember_set_Experience", _args);
            }
        }

        /// <summary>
        /// The crew member's gender.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_Gender")]
        public global::KRPC.Client.Services.SpaceCenter.CrewMemberGender Gender {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Gender", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CrewMemberGender)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CrewMemberGender), connection);
            }
        }

        /// <summary>
        /// The crew members name.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(string))
                };
                connection.Invoke ("SpaceCenter", "CrewMember_set_Name", _args);
            }
        }

        /// <summary>
        /// Whether the crew member is on a mission.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_OnMission")]
        public bool OnMission {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_OnMission", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The crew member's current roster status.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_RosterStatus")]
        public global::KRPC.Client.Services.SpaceCenter.RosterStatus RosterStatus {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_RosterStatus", _args);
                return (global::KRPC.Client.Services.SpaceCenter.RosterStatus)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.RosterStatus), connection);
            }
        }

        /// <summary>
        /// The crew members stupidity.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_Stupidity")]
        public float Stupidity {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Stupidity", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "CrewMember_set_Stupidity", _args);
            }
        }

        /// <summary>
        /// The crew member's suit type.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_SuitType")]
        public global::KRPC.Client.Services.SpaceCenter.SuitType SuitType {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_SuitType", _args);
                return (global::KRPC.Client.Services.SpaceCenter.SuitType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.SuitType), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.SuitType))
                };
                connection.Invoke ("SpaceCenter", "CrewMember_set_SuitType", _args);
            }
        }

        /// <summary>
        /// The crew member's job.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_Trait")]
        public string Trait {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Trait", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// The type of crew member.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_Type")]
        public global::KRPC.Client.Services.SpaceCenter.CrewMemberType Type {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Type", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CrewMemberType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CrewMemberType), connection);
            }
        }

        /// <summary>
        /// Whether the crew member is a veteran.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CrewMember_get_Veteran")]
        public bool Veteran {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "CrewMember_get_Veteran", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.CrewMember)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "CrewMember_set_Veteran", _args);
            }
        }
    }

    /// <summary>
    /// A decoupler. Obtained by calling <see cref="M:SpaceCenter.Part.Decoupler" /></summary>
    public class Decoupler : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Decoupler (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Fires the decoupler. Returns the new vessel created when the decoupler fires.
        /// Throws an exception if the decoupler has already fired.
        /// </summary>
        /// <remarks>
        /// When called, the active vessel may change. It is therefore possible that,
        /// after calling this function, the object(s) returned by previous call(s) to
        /// <see cref="M:SpaceCenter.ActiveVessel" /> no longer refer to the active vessel.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_Decouple")]
        public global::KRPC.Client.Services.SpaceCenter.Vessel Decouple ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Decoupler))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_Decouple", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel), connection);
        }

        /// <summary>
        /// The part attached to this decoupler's explosive node.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_AttachedPart")]
        public global::KRPC.Client.Services.SpaceCenter.Part AttachedPart {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Decoupler))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_AttachedPart", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Whether the decoupler has fired.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_Decoupled")]
        public bool Decoupled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Decoupler))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_Decoupled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The impulse that the decoupler imparts when it is fired, in Newton seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_Impulse")]
        public float Impulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Decoupler))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_Impulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the decoupler is an omni-decoupler (e.g. stack separator)
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_IsOmniDecoupler")]
        public bool IsOmniDecoupler {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Decoupler))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_IsOmniDecoupler", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The part object for this decoupler.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Decoupler))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Whether the decoupler is enabled in the staging sequence.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Decoupler_get_Staged")]
        public bool Staged {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Decoupler))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Decoupler_get_Staged", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }
    }

    /// <summary>
    /// A docking port. Obtained by calling <see cref="M:SpaceCenter.Part.DockingPort" /></summary>
    public class DockingPort : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public DockingPort (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// The direction that docking port points in, in the given reference frame.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// direction is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_Direction")]
        public systemAlias::Tuple<double,double,double> Direction (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_Direction", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The position of the docking port, in the given reference frame.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_Position")]
        public systemAlias::Tuple<double,double,double> Position (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_Position", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The rotation of the docking port, in the given reference frame.
        /// </summary>
        /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// rotation is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_Rotation")]
        public systemAlias::Tuple<double,double,double,double> Rotation (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_Rotation", _args);
            return (systemAlias::Tuple<double,double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double,double>), connection);
        }

        /// <summary>
        /// Undocks the docking port and returns the new <see cref="T:SpaceCenter.Vessel" /> that is created.
        /// This method can be called for either docking port in a docked pair.
        /// Throws an exception if the docking port is not docked to anything.
        /// </summary>
        /// <remarks>
        /// When called, the active vessel may change. It is therefore possible that,
        /// after calling this function, the object(s) returned by previous call(s) to
        /// <see cref="M:SpaceCenter.ActiveVessel" /> no longer refer to the active vessel.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_Undock")]
        public global::KRPC.Client.Services.SpaceCenter.Vessel Undock ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_Undock", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel), connection);
        }

        /// <summary>
        /// Whether the docking port can be commanded to rotate while docked.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_CanRotate")]
        public bool CanRotate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_CanRotate", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The part that this docking port is docked to. Returns <c>null</c> if this
        /// docking port is not docked to anything.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_DockedPart")]
        public global::KRPC.Client.Services.SpaceCenter.Part DockedPart {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_DockedPart", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Whether the docking port has a shield.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_HasShield")]
        public bool HasShield {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_HasShield", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Maximum rotation angle in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_MaximumRotation")]
        public float MaximumRotation {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_MaximumRotation", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Minimum rotation angle in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_MinimumRotation")]
        public float MinimumRotation {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_MinimumRotation", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The part object for this docking port.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The distance a docking port must move away when it undocks before it
        /// becomes ready to dock with another port, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_ReengageDistance")]
        public float ReengageDistance {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_ReengageDistance", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to this docking port, and
        /// oriented with the port.
        /// <list type="bullet"><item><description>The origin is at the position of the docking port.
        /// </description></item><item><description>The axes rotate with the docking port.</description></item><item><description>The x-axis points out to the right side of the docking port.
        /// </description></item><item><description>The y-axis points in the direction the docking port is facing.
        /// </description></item><item><description>The z-axis points out of the bottom off the docking port.
        /// </description></item></list></summary>
        /// <remarks>
        /// This reference frame is not necessarily equivalent to the reference frame
        /// for the part, returned by <see cref="M:SpaceCenter.Part.ReferenceFrame" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_ReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_ReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// Lock rotation. When locked, allows auto-strut to work across the joint.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_RotationLocked")]
        public bool RotationLocked {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_RotationLocked", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "DockingPort_set_RotationLocked", _args);
            }
        }

        /// <summary>
        /// Rotation target angle in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_RotationTarget")]
        public float RotationTarget {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_RotationTarget", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "DockingPort_set_RotationTarget", _args);
            }
        }

        /// <summary>
        /// The state of the docking ports shield, if it has one.
        ///
        /// Returns <c>true</c> if the docking port has a shield, and the shield is
        /// closed. Otherwise returns <c>false</c>. When set to <c>true</c>, the shield is
        /// closed, and when set to <c>false</c> the shield is opened. If the docking
        /// port does not have a shield, setting this attribute has no effect.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_Shielded")]
        public bool Shielded {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_Shielded", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "DockingPort_set_Shielded", _args);
            }
        }

        /// <summary>
        /// The current state of the docking port.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "DockingPort_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.DockingPortState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.DockingPort))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "DockingPort_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.DockingPortState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.DockingPortState), connection);
            }
        }
    }

    /// <summary>
    /// An engine, including ones of various types.
    /// For example liquid fuelled gimballed engines, solid rocket boosters and jet engines.
    /// Obtained by calling <see cref="M:SpaceCenter.Part.Engine" />.
    /// </summary>
    /// <remarks>
    /// For RCS thrusters <see cref="M:SpaceCenter.Part.RCS" />.
    /// </remarks>
    public class Engine : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Engine (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// The amount of thrust, in Newtons, that would be produced by the engine
        /// when activated and with its throttle set to 100%.
        /// Returns zero if the engine does not have any fuel.
        /// Takes the given pressure into account.
        /// </summary>
        /// <param name="pressure">Atmospheric pressure in atmospheres</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_AvailableThrustAt")]
        public float AvailableThrustAt (double pressure)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (pressure, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_AvailableThrustAt", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }

        /// <summary>
        /// The amount of thrust, in Newtons, that would be produced by the engine
        /// when activated and fueled, with its throttle and throttle limiter set to 100%.
        /// Takes the given pressure into account.
        /// </summary>
        /// <param name="pressure">Atmospheric pressure in atmospheres</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_MaxThrustAt")]
        public float MaxThrustAt (double pressure)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (pressure, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_MaxThrustAt", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }

        /// <summary>
        /// The specific impulse of the engine under the given pressure, in seconds. Returns zero
        /// if the engine is not active.
        /// </summary>
        /// <param name="pressure">Atmospheric pressure in atmospheres</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_SpecificImpulseAt")]
        public float SpecificImpulseAt (double pressure)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                global::KRPC.Client.Encoder.Encode (pressure, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Engine_SpecificImpulseAt", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }

        /// <summary>
        /// Toggle the current engine mode.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_ToggleMode")]
        public void ToggleMode ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
            };
            connection.Invoke ("SpaceCenter", "Engine_ToggleMode", _args);
        }

        /// <summary>
        /// Whether the engine is active. Setting this attribute may have no effect,
        /// depending on <see cref="M:SpaceCenter.Engine.CanShutdown" /> and <see cref="M:SpaceCenter.Engine.CanRestart" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Active")]
        public bool Active {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Active", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Engine_set_Active", _args);
            }
        }

        /// <summary>
        /// Whether the engine will automatically switch modes.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_AutoModeSwitch")]
        public bool AutoModeSwitch {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_AutoModeSwitch", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Engine_set_AutoModeSwitch", _args);
            }
        }

        /// <summary>
        /// The amount of thrust, in Newtons, that would be produced by the engine
        /// when activated and with its throttle set to 100%.
        /// Returns zero if the engine does not have any fuel.
        /// Takes the engine's current <see cref="M:SpaceCenter.Engine.ThrustLimit" /> and atmospheric conditions
        /// into account.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_AvailableThrust")]
        public float AvailableThrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_AvailableThrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The available torque, in Newton meters, that can be produced by this engine,
        /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
        /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
        /// Returns zero if the engine is inactive, or not gimballed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_AvailableTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_AvailableTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// Whether the engine can be restarted once shutdown. If the engine cannot be shutdown,
        /// returns <c>false</c>. For example, this is <c>true</c> for liquid fueled rockets
        /// and <c>false</c> for solid rocket boosters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_CanRestart")]
        public bool CanRestart {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_CanRestart", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the engine can be shutdown once activated. For example, this is
        /// <c>true</c> for liquid fueled rockets and <c>false</c> for solid rocket boosters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_CanShutdown")]
        public bool CanShutdown {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_CanShutdown", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The gimbal limiter of the engine. A value between 0 and 1.
        /// Returns 0 if the gimbal is locked.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_GimbalLimit")]
        public float GimbalLimit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_GimbalLimit", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Engine_set_GimbalLimit", _args);
            }
        }

        /// <summary>
        /// Whether the engines gimbal is locked in place. Setting this attribute has
        /// no effect if the engine is not gimballed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_GimbalLocked")]
        public bool GimbalLocked {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_GimbalLocked", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Engine_set_GimbalLocked", _args);
            }
        }

        /// <summary>
        /// The range over which the gimbal can move, in degrees.
        /// Returns 0 if the engine is not gimballed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_GimbalRange")]
        public float GimbalRange {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_GimbalRange", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the engine is gimballed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Gimballed")]
        public bool Gimballed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Gimballed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the engine has any fuel available.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_HasFuel")]
        public bool HasFuel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_HasFuel", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the engine has multiple modes of operation.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_HasModes")]
        public bool HasModes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_HasModes", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the independent throttle is enabled for the engine.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_IndependentThrottle")]
        public bool IndependentThrottle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_IndependentThrottle", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Engine_set_IndependentThrottle", _args);
            }
        }

        /// <summary>
        /// The specific impulse of the engine at sea level on Kerbin, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_KerbinSeaLevelSpecificImpulse")]
        public float KerbinSeaLevelSpecificImpulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_KerbinSeaLevelSpecificImpulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The amount of thrust, in Newtons, that would be produced by the engine
        /// when activated and fueled, with its throttle and throttle limiter set to 100%.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_MaxThrust")]
        public float MaxThrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_MaxThrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The maximum amount of thrust that can be produced by the engine in a
        /// vacuum, in Newtons. This is the amount of thrust produced by the engine
        /// when activated, <see cref="M:SpaceCenter.Engine.ThrustLimit" /> is set to 100%, the main
        /// vessel's throttle is set to 100% and the engine is in a vacuum.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_MaxVacuumThrust")]
        public float MaxVacuumThrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_MaxVacuumThrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The name of the current engine mode.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Mode")]
        public string Mode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Mode", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(string))
                };
                connection.Invoke ("SpaceCenter", "Engine_set_Mode", _args);
            }
        }

        /// <summary>
        /// The available modes for the engine.
        /// A dictionary mapping mode names to <see cref="T:SpaceCenter.Engine" /> objects.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Modes")]
        public global::System.Collections.Generic.IDictionary<string,global::KRPC.Client.Services.SpaceCenter.Engine> Modes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Modes", _args);
                return (global::System.Collections.Generic.IDictionary<string,global::KRPC.Client.Services.SpaceCenter.Engine>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,global::KRPC.Client.Services.SpaceCenter.Engine>), connection);
            }
        }

        /// <summary>
        /// The part object for this engine.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The names of the propellants that the engine consumes.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_PropellantNames")]
        public global::System.Collections.Generic.IList<string> PropellantNames {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_PropellantNames", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// The ratio of resources that the engine consumes. A dictionary mapping resource names
        /// to the ratio at which they are consumed by the engine.
        /// </summary>
        /// <remarks>
        /// For example, if the ratios are 0.6 for LiquidFuel and 0.4 for Oxidizer, then for every
        /// 0.6 units of LiquidFuel that the engine burns, it will burn 0.4 units of Oxidizer.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_PropellantRatios")]
        public global::System.Collections.Generic.IDictionary<string,float> PropellantRatios {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_PropellantRatios", _args);
                return (global::System.Collections.Generic.IDictionary<string,float>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,float>), connection);
            }
        }

        /// <summary>
        /// The propellants that the engine consumes.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Propellants")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Propellant> Propellants {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Propellants", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Propellant>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Propellant>), connection);
            }
        }

        /// <summary>
        /// The current specific impulse of the engine, in seconds. Returns zero
        /// if the engine is not active.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_SpecificImpulse")]
        public float SpecificImpulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_SpecificImpulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The current throttle setting for the engine. A value between 0 and 1.
        /// This is not necessarily the same as the vessel's main throttle
        /// setting, as some engines take time to adjust their throttle
        /// (such as jet engines), or independent throttle may be enabled.
        ///
        /// When the engine's independent throttle is enabled
        /// (see <see cref="M:SpaceCenter.Engine.IndependentThrottle" />), can be used to set the throttle percentage.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Throttle")]
        public float Throttle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Throttle", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Engine_set_Throttle", _args);
            }
        }

        /// <summary>
        /// Whether the <see cref="M:SpaceCenter.Control.Throttle" /> affects the engine. For example,
        /// this is <c>true</c> for liquid fueled rockets, and <c>false</c> for solid rocket
        /// boosters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_ThrottleLocked")]
        public bool ThrottleLocked {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_ThrottleLocked", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The current amount of thrust being produced by the engine, in Newtons.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Thrust")]
        public float Thrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Thrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The thrust limiter of the engine. A value between 0 and 1. Setting this
        /// attribute may have no effect, for example the thrust limit for a solid
        /// rocket booster cannot be changed in flight.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_ThrustLimit")]
        public float ThrustLimit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_ThrustLimit", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Engine_set_ThrustLimit", _args);
            }
        }

        /// <summary>
        /// The components of the engine that generate thrust.
        /// </summary>
        /// <remarks>
        /// For example, this corresponds to the rocket nozzel on a solid rocket booster,
        /// or the individual nozzels on a RAPIER engine.
        /// The overall thrust produced by the engine, as reported by <see cref="M:SpaceCenter.Engine.AvailableThrust" />,
        /// <see cref="M:SpaceCenter.Engine.MaxThrust" /> and others, is the sum of the thrust generated by each thruster.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_Thrusters")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Thruster> Thrusters {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_Thrusters", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Thruster>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Thruster>), connection);
            }
        }

        /// <summary>
        /// The vacuum specific impulse of the engine, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Engine_get_VacuumSpecificImpulse")]
        public float VacuumSpecificImpulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Engine))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Engine_get_VacuumSpecificImpulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }
    }

    /// <summary>
    /// Obtained by calling <see cref="M:SpaceCenter.Part.Experiment" />.
    /// </summary>
    public class Experiment : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Experiment (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Dump the experimental data contained by the experiment.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_Dump")]
        public void Dump ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
            };
            connection.Invoke ("SpaceCenter", "Experiment_Dump", _args);
        }

        /// <summary>
        /// Reset the experiment.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_Reset")]
        public void Reset ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
            };
            connection.Invoke ("SpaceCenter", "Experiment_Reset", _args);
        }

        /// <summary>
        /// Run the experiment.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_Run")]
        public void Run ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
            };
            connection.Invoke ("SpaceCenter", "Experiment_Run", _args);
        }

        /// <summary>
        /// Transmit all experimental data contained by this part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_Transmit")]
        public void Transmit ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
            };
            connection.Invoke ("SpaceCenter", "Experiment_Transmit", _args);
        }

        /// <summary>
        /// Determines if the experiment is available given the current conditions.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Available")]
        public bool Available {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Available", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The name of the biome the experiment is currently in.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Biome")]
        public string Biome {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Biome", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// The data contained in this experiment.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Data")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ScienceData> Data {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Data", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ScienceData>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ScienceData>), connection);
            }
        }

        /// <summary>
        /// Whether the experiment has been deployed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Deployed")]
        public bool Deployed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Deployed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the experiment contains data.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_HasData")]
        public bool HasData {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_HasData", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the experiment is inoperable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Inoperable")]
        public bool Inoperable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Inoperable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Internal name of the experiment, as used in
        /// <a href="https://wiki.kerbalspaceprogram.com/wiki/CFG_File_Documentation">part cfg files</a>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// The part object for this experiment.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Whether the experiment can be re-run.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Rerunnable")]
        public bool Rerunnable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Rerunnable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Containing information on the corresponding specific science result for the current
        /// conditions. Returns <c>null</c> if the experiment is unavailable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_ScienceSubject")]
        public global::KRPC.Client.Services.SpaceCenter.ScienceSubject ScienceSubject {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_ScienceSubject", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ScienceSubject)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ScienceSubject), connection);
            }
        }

        /// <summary>
        /// Title of the experiment, as shown on the in-game UI.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Experiment_get_Title")]
        public string Title {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Experiment))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Experiment_get_Title", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }
    }

    /// <summary>
    /// A fairing. Obtained by calling <see cref="M:SpaceCenter.Part.Fairing" />.
    /// Supports both stock fairings, and those from the ProceduralFairings mod.
    /// </summary>
    public class Fairing : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Fairing (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Jettison the fairing. Has no effect if it has already been jettisoned.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Fairing_Jettison")]
        public void Jettison ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Fairing))
            };
            connection.Invoke ("SpaceCenter", "Fairing_Jettison", _args);
        }

        /// <summary>
        /// Whether the fairing has been jettisoned.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Fairing_get_Jettisoned")]
        public bool Jettisoned {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Fairing))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Fairing_get_Jettisoned", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The part object for this fairing.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Fairing_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Fairing))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Fairing_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }
    }

    /// <summary>
    /// Used to get flight telemetry for a vessel, by calling <see cref="M:SpaceCenter.Vessel.Flight" />.
    /// All of the information returned by this class is given in the reference frame
    /// passed to that method.
    /// Obtained by calling <see cref="M:SpaceCenter.Vessel.Flight" />.
    /// </summary>
    /// <remarks>
    /// To get orbital information, such as the apoapsis or inclination, see <see cref="T:SpaceCenter.Orbit" />.
    /// </remarks>
    public class Flight : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Flight (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Simulate and return the total aerodynamic forces acting on the vessel,
        /// if it where to be traveling with the given velocity at the given position in the
        /// atmosphere of the given celestial body.
        /// </summary>
        /// <returns>A vector pointing in the direction that the force acts,
        /// with its magnitude equal to the strength of the force in Newtons.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_SimulateAerodynamicForceAt")]
        public systemAlias::Tuple<double,double,double> SimulateAerodynamicForceAt (global::KRPC.Client.Services.SpaceCenter.CelestialBody body, systemAlias::Tuple<double,double,double> position, systemAlias::Tuple<double,double,double> velocity)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight)),
                global::KRPC.Client.Encoder.Encode (body, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (velocity, typeof(systemAlias::Tuple<double,double,double>))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Flight_SimulateAerodynamicForceAt", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The total aerodynamic forces acting on the vessel,
        /// in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>A vector pointing in the direction that the force acts,
        /// with its magnitude equal to the strength of the force in Newtons.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_AerodynamicForce")]
        public systemAlias::Tuple<double,double,double> AerodynamicForce {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_AerodynamicForce", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The pitch angle between the orientation of the vessel and its velocity vector,
        /// in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_AngleOfAttack")]
        public float AngleOfAttack {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_AngleOfAttack", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The direction opposite to the normal of the vessels orbit,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_AntiNormal")]
        public systemAlias::Tuple<double,double,double> AntiNormal {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_AntiNormal", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The direction opposite to the radial direction of the vessels orbit,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_AntiRadial")]
        public systemAlias::Tuple<double,double,double> AntiRadial {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_AntiRadial", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The current density of the atmosphere around the vessel, in <math>kg/m^3</math>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_AtmosphereDensity")]
        public float AtmosphereDensity {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_AtmosphereDensity", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Ballistic_coefficient">ballistic coefficient</a>.
        /// </summary>
        /// <remarks>
        /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_BallisticCoefficient")]
        public float BallisticCoefficient {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_BallisticCoefficient", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The altitude above the surface of the body, in meters. When over water, this is the altitude above the sea floor.
        /// Measured from the center of mass of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_BedrockAltitude")]
        public double BedrockAltitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_BedrockAltitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The position of the center of mass of the vessel,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" /></summary>
        /// <returns>The position as a vector.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_CenterOfMass")]
        public systemAlias::Tuple<double,double,double> CenterOfMass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_CenterOfMass", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The direction that the vessel is pointing in,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Direction")]
        public systemAlias::Tuple<double,double,double> Direction {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Direction", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Aerodynamic_force">aerodynamic drag</a> currently acting on the vessel.
        /// </summary>
        /// <returns>A vector pointing in the direction of the force, with its magnitude
        /// equal to the strength of the force in Newtons.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Drag")]
        public systemAlias::Tuple<double,double,double> Drag {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Drag", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The coefficient of drag. This is the amount of drag produced by the vessel.
        /// It depends on air speed, air density and wing area.
        /// </summary>
        /// <remarks>
        /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_DragCoefficient")]
        public float DragCoefficient {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_DragCoefficient", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The dynamic pressure acting on the vessel, in Pascals. This is a measure of the
        /// strength of the aerodynamic forces. It is equal to
        /// <math>\frac{1}{2} . \mbox{air density} . \mbox{velocity}^2</math>.
        /// It is commonly denoted <math>Q</math>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_DynamicPressure")]
        public float DynamicPressure {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_DynamicPressure", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The elevation of the terrain under the vessel, in meters. This is the height of the terrain above sea level,
        /// and is negative when the vessel is over the sea.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Elevation")]
        public double Elevation {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Elevation", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Equivalent_airspeed">equivalent air speed</a>
        /// of the vessel, in meters per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_EquivalentAirSpeed")]
        public float EquivalentAirSpeed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_EquivalentAirSpeed", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The current G force acting on the vessel in <math>g</math>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_GForce")]
        public float GForce {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_GForce", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The heading of the vessel (its angle relative to north), in degrees.
        /// A value between 0° and 360°.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Heading")]
        public float Heading {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Heading", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The horizontal speed of the vessel in meters per second,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_HorizontalSpeed")]
        public double HorizontalSpeed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_HorizontalSpeed", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Latitude">latitude</a> of the vessel for the body being orbited, in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Latitude")]
        public double Latitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Latitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Aerodynamic_force">aerodynamic lift</a>
        /// currently acting on the vessel.
        /// </summary>
        /// <returns>A vector pointing in the direction that the force acts,
        /// with its magnitude equal to the strength of the force in Newtons.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Lift")]
        public systemAlias::Tuple<double,double,double> Lift {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Lift", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The coefficient of lift. This is the amount of lift produced by the vessel, and
        /// depends on air speed, air density and wing area.
        /// </summary>
        /// <remarks>
        /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_LiftCoefficient")]
        public float LiftCoefficient {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_LiftCoefficient", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Longitude">longitude</a> of the vessel for the body being orbited, in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Longitude")]
        public double Longitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Longitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The speed of the vessel, in multiples of the speed of sound.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Mach")]
        public float Mach {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Mach", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The altitude above sea level, in meters.
        /// Measured from the center of mass of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_MeanAltitude")]
        public double MeanAltitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_MeanAltitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The direction normal to the vessels orbit,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Normal")]
        public systemAlias::Tuple<double,double,double> Normal {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Normal", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The pitch of the vessel relative to the horizon, in degrees.
        /// A value between -90° and +90°.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Pitch")]
        public float Pitch {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Pitch", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The prograde direction of the vessels orbit,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Prograde")]
        public systemAlias::Tuple<double,double,double> Prograde {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Prograde", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The radial direction of the vessels orbit,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Radial")]
        public systemAlias::Tuple<double,double,double> Radial {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Radial", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The retrograde direction of the vessels orbit,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Retrograde")]
        public systemAlias::Tuple<double,double,double> Retrograde {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Retrograde", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The vessels Reynolds number.
        /// </summary>
        /// <remarks>
        /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_ReynoldsNumber")]
        public float ReynoldsNumber {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_ReynoldsNumber", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The roll of the vessel relative to the horizon, in degrees.
        /// A value between -180° and +180°.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Roll")]
        public float Roll {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Roll", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The rotation of the vessel, in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" /></summary>
        /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Rotation")]
        public systemAlias::Tuple<double,double,double,double> Rotation {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Rotation", _args);
                return (systemAlias::Tuple<double,double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double,double>), connection);
            }
        }

        /// <summary>
        /// The yaw angle between the orientation of the vessel and its velocity vector, in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_SideslipAngle")]
        public float SideslipAngle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_SideslipAngle", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The speed of the vessel in meters per second,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Speed")]
        public double Speed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Speed", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The speed of sound, in the atmosphere around the vessel, in <math>m/s</math>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_SpeedOfSound")]
        public float SpeedOfSound {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_SpeedOfSound", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The current amount of stall, between 0 and 1. A value greater than 0.005 indicates
        /// a minor stall and a value greater than 0.5 indicates a large-scale stall.
        /// </summary>
        /// <remarks>
        /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_StallFraction")]
        public float StallFraction {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_StallFraction", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Total_air_temperature">static (ambient)
        /// temperature</a> of the atmosphere around the vessel, in Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_StaticAirTemperature")]
        public float StaticAirTemperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_StaticAirTemperature", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The static atmospheric pressure acting on the vessel, in Pascals.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_StaticPressure")]
        public float StaticPressure {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_StaticPressure", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The static atmospheric pressure at mean sea level, in Pascals.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_StaticPressureAtMSL")]
        public float StaticPressureAtMSL {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_StaticPressureAtMSL", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The altitude above the surface of the body or sea level, whichever is closer, in meters.
        /// Measured from the center of mass of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_SurfaceAltitude")]
        public double SurfaceAltitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_SurfaceAltitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// An estimate of the current terminal velocity of the vessel, in meters per second.
        /// This is the speed at which the drag forces cancel out the force of gravity.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_TerminalVelocity")]
        public float TerminalVelocity {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_TerminalVelocity", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The thrust specific fuel consumption for the jet engines on the vessel. This is a
        /// measure of the efficiency of the engines, with a lower value indicating a more
        /// efficient vessel. This value is the number of Newtons of fuel that are burned,
        /// per hour, to produce one newton of thrust.
        /// </summary>
        /// <remarks>
        /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_ThrustSpecificFuelConsumption")]
        public float ThrustSpecificFuelConsumption {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_ThrustSpecificFuelConsumption", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Total_air_temperature">total air temperature</a>
        /// of the atmosphere around the vessel, in Kelvin.
        /// This includes the <see cref="M:SpaceCenter.Flight.StaticAirTemperature" /> and the vessel's kinetic energy.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_TotalAirTemperature")]
        public float TotalAirTemperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_TotalAirTemperature", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/True_airspeed">true air speed</a>
        /// of the vessel, in meters per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_TrueAirSpeed")]
        public float TrueAirSpeed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_TrueAirSpeed", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The velocity of the vessel, in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>The velocity as a vector. The vector points in the direction of travel,
        /// and its magnitude is the speed of the vessel in meters per second.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_Velocity")]
        public systemAlias::Tuple<double,double,double> Velocity {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_Velocity", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The vertical speed of the vessel in meters per second,
        /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Flight_get_VerticalSpeed")]
        public double VerticalSpeed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Flight))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Flight_get_VerticalSpeed", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }
    }

    /// <summary>
    /// Obtained by calling <see cref="M:SpaceCenter.Part.AddForce" />.
    /// </summary>
    public class Force : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Force (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Remove the force.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_Remove")]
        public void Remove ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Force))
            };
            connection.Invoke ("SpaceCenter", "Force_Remove", _args);
        }

        /// <summary>
        /// The force vector, in Newtons.
        /// </summary>
        /// <returns>A vector pointing in the direction that the force acts,
        /// with its magnitude equal to the strength of the force in Newtons.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_get_ForceVector")]
        public systemAlias::Tuple<double,double,double> ForceVector {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Force))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Force_get_ForceVector", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Force)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "Force_set_ForceVector", _args);
            }
        }

        /// <summary>
        /// The part that this force is applied to.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Force))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Force_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The position at which the force acts, in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_get_Position")]
        public systemAlias::Tuple<double,double,double> Position {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Force))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Force_get_Position", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Force)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "Force_set_Position", _args);
            }
        }

        /// <summary>
        /// The reference frame of the force vector and position.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Force_get_ReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Force))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Force_get_ReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Force)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
                };
                connection.Invoke ("SpaceCenter", "Force_set_ReferenceFrame", _args);
            }
        }
    }

    /// <summary>
    /// An air intake. Obtained by calling <see cref="M:SpaceCenter.Part.Intake" />.
    /// </summary>
    public class Intake : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Intake (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// The area of the intake's opening, in square meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Intake_get_Area")]
        public float Area {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Intake))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Intake_get_Area", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The rate of flow into the intake, in units of resource per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Intake_get_Flow")]
        public float Flow {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Intake))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Intake_get_Flow", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the intake is open.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Intake_get_Open")]
        public bool Open {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Intake))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Intake_get_Open", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Intake)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Intake_set_Open", _args);
            }
        }

        /// <summary>
        /// The part object for this intake.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Intake_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Intake))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Intake_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Speed of the flow into the intake, in <math>m/s</math>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Intake_get_Speed")]
        public float Speed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Intake))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Intake_get_Speed", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }
    }

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
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.LaunchClamp))
            };
            connection.Invoke ("SpaceCenter", "LaunchClamp_Release", _args);
        }

        /// <summary>
        /// The part object for this launch clamp.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchClamp_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.LaunchClamp))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "LaunchClamp_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }
    }

    /// <summary>
    /// A place where craft can be launched from.
    /// More of these can be added with mods like Kerbal Konstructs.
    /// </summary>
    public class LaunchSite : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public LaunchSite (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// The celestial body the launch site is on.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchSite_get_Body")]
        public global::KRPC.Client.Services.SpaceCenter.CelestialBody Body {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.LaunchSite))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "LaunchSite_get_Body", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CelestialBody)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody), connection);
            }
        }

        /// <summary>
        /// Which editor is normally used for this launch site.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchSite_get_EditorFacility")]
        public global::KRPC.Client.Services.SpaceCenter.EditorFacility EditorFacility {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.LaunchSite))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "LaunchSite_get_EditorFacility", _args);
                return (global::KRPC.Client.Services.SpaceCenter.EditorFacility)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.EditorFacility), connection);
            }
        }

        /// <summary>
        /// The name of the launch site.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "LaunchSite_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.LaunchSite))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "LaunchSite_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }
    }

    /// <summary>
    /// A landing leg. Obtained by calling <see cref="M:SpaceCenter.Part.Leg" />.
    /// </summary>
    public class Leg : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Leg (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the leg is deployable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Leg_get_Deployable")]
        public bool Deployable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Leg))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_Deployable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the landing leg is deployed.
        /// </summary>
        /// <remarks>
        /// Fixed landing legs are always deployed.
        /// Returns an error if you try to deploy fixed landing gear.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Leg_get_Deployed")]
        public bool Deployed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Leg))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_Deployed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Leg)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Leg_set_Deployed", _args);
            }
        }

        /// <summary>
        /// Returns whether the leg is touching the ground.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Leg_get_IsGrounded")]
        public bool IsGrounded {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Leg))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_IsGrounded", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The part object for this landing leg.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Leg_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Leg))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The current state of the landing leg.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Leg_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.LegState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Leg))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Leg_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.LegState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.LegState), connection);
            }
        }
    }

    /// <summary>
    /// A light. Obtained by calling <see cref="M:SpaceCenter.Part.Light" />.
    /// </summary>
    public class Light : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Light (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the light is switched on.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Light_get_Active")]
        public bool Active {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Light_get_Active", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Light_set_Active", _args);
            }
        }

        /// <summary>
        /// Whether blinking is enabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Light_get_Blink")]
        public bool Blink {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Light_get_Blink", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Light_set_Blink", _args);
            }
        }

        /// <summary>
        /// The blink rate of the light.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Light_get_BlinkRate")]
        public float BlinkRate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Light_get_BlinkRate", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Light_set_BlinkRate", _args);
            }
        }

        /// <summary>
        /// The color of the light, as an RGB triple.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Light_get_Color")]
        public systemAlias::Tuple<float,float,float> Color {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Light_get_Color", _args);
                return (systemAlias::Tuple<float,float,float>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<float,float,float>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<float,float,float>))
                };
                connection.Invoke ("SpaceCenter", "Light_set_Color", _args);
            }
        }

        /// <summary>
        /// The part object for this light.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Light_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Light_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The current power usage, in units of charge per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Light_get_PowerUsage")]
        public float PowerUsage {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Light))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Light_get_PowerUsage", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }
    }

    /// <summary>
    /// This can be used to interact with a specific part module. This includes part modules in
    /// stock KSP, and those added by mods.
    ///
    /// In KSP, each part has zero or more
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/CFG_File_Documentation#MODULES">PartModules</a>
    /// associated with it. Each one contains some of the functionality of the part.
    /// For example, an engine has a "ModuleEngines" part module that contains all the
    /// functionality of an engine.
    /// </summary>
    public class Module : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Module (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Returns the value of a field with the given name.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_GetField")]
        public string GetField (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_GetField", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }

        /// <summary>
        /// Returns the value of a field with the given identifier.
        /// </summary>
        /// <param name="id">Identifier of the field.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_GetFieldById")]
        public string GetFieldById (string id)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_GetFieldById", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }

        /// <summary><c>true</c> if the part has an action with the given name.
        /// </summary>
        /// <param name="name"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasAction")]
        public bool HasAction (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasAction", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary><c>true</c> if the part has an action with the given identifier.
        /// </summary>
        /// <param name="id"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasActionWithId")]
        public bool HasActionWithId (string id)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasActionWithId", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary><c>true</c> if the module has an event with the given name.
        /// </summary>
        /// <param name="name"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasEvent")]
        public bool HasEvent (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasEvent", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary><c>true</c> if the module has an event with the given identifier.
        /// </summary>
        /// <param name="id"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasEventWithId")]
        public bool HasEventWithId (string id)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasEventWithId", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// Returns <c>true</c> if the module has a field with the given name.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasField")]
        public bool HasField (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasField", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// Returns <c>true</c> if the module has a field with the given identifier.
        /// </summary>
        /// <param name="id">Identifier of the field.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasFieldWithId")]
        public bool HasFieldWithId (string id)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasFieldWithId", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// Set the value of a field to its original value.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_ResetField")]
        public void ResetField (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Module_ResetField", _args);
        }

        /// <summary>
        /// Set the value of a field to its original value.
        /// </summary>
        /// <param name="id">Identifier of the field.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_ResetFieldById")]
        public void ResetFieldById (string id)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Module_ResetFieldById", _args);
        }

        /// <summary>
        /// Set the value of an action with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetAction")]
        public void SetAction (string name, bool value = true)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Module_SetAction", _args);
        }

        /// <summary>
        /// Set the value of an action with the given identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetActionById")]
        public void SetActionById (string id, bool value = true)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Module_SetActionById", _args);
        }

        /// <summary>
        /// Set the value of a field to true or false.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        /// <param name="value">Value to set.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldBool")]
        public void SetFieldBool (string name, bool value)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Module_SetFieldBool", _args);
        }

        /// <summary>
        /// Set the value of a field to true or false.
        /// </summary>
        /// <param name="id">Identifier of the field.</param>
        /// <param name="value">Value to set.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldBoolById")]
        public void SetFieldBoolById (string id, bool value)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "Module_SetFieldBoolById", _args);
        }

        /// <summary>
        /// Set the value of a field to the given floating point number.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        /// <param name="value">Value to set.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldFloat")]
        public void SetFieldFloat (string name, float value)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Module_SetFieldFloat", _args);
        }

        /// <summary>
        /// Set the value of a field to the given floating point number.
        /// </summary>
        /// <param name="id">Identifier of the field.</param>
        /// <param name="value">Value to set.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldFloatById")]
        public void SetFieldFloatById (string id, float value)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            connection.Invoke ("SpaceCenter", "Module_SetFieldFloatById", _args);
        }

        /// <summary>
        /// Set the value of a field to the given integer number.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        /// <param name="value">Value to set.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldInt")]
        public void SetFieldInt (string name, int value)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(int))
            };
            connection.Invoke ("SpaceCenter", "Module_SetFieldInt", _args);
        }

        /// <summary>
        /// Set the value of a field to the given integer number.
        /// </summary>
        /// <param name="id">Identifier of the field.</param>
        /// <param name="value">Value to set.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldIntById")]
        public void SetFieldIntById (string id, int value)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(int))
            };
            connection.Invoke ("SpaceCenter", "Module_SetFieldIntById", _args);
        }

        /// <summary>
        /// Set the value of a field to the given string.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        /// <param name="value">Value to set.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldString")]
        public void SetFieldString (string name, string value)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Module_SetFieldString", _args);
        }

        /// <summary>
        /// Set the value of a field to the given string.
        /// </summary>
        /// <param name="id">Identifier of the field.</param>
        /// <param name="value">Value to set.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldStringById")]
        public void SetFieldStringById (string id, string value)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string)),
                global::KRPC.Client.Encoder.Encode (value, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Module_SetFieldStringById", _args);
        }

        /// <summary>
        /// Trigger the named event. Equivalent to clicking the button in the right-click menu
        /// of the part.
        /// </summary>
        /// <param name="name"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_TriggerEvent")]
        public void TriggerEvent (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Module_TriggerEvent", _args);
        }

        /// <summary>
        /// Trigger the event with the given identifier.
        /// Equivalent to clicking the button in the right-click menu of the part.
        /// </summary>
        /// <param name="id"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_TriggerEventById")]
        public void TriggerEventById (string id)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (id, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Module_TriggerEventById", _args);
        }

        /// <summary>
        /// A list of all the names of the modules actions. These are the parts actions that can
        /// be assigned to action groups in the in-game editor.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Actions")]
        public global::System.Collections.Generic.IList<string> Actions {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Actions", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// A list of all the identifiers of the modules actions. These are the parts actions
        /// that can be assigned to action groups in the in-game editor.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_ActionsById")]
        public global::System.Collections.Generic.IList<string> ActionsById {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_ActionsById", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// A list of the names of all of the modules events. Events are the clickable buttons
        /// visible in the right-click menu of the part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Events")]
        public global::System.Collections.Generic.IList<string> Events {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Events", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// A list of the identifiers of all of the modules events. Events are the clickable buttons
        /// visible in the right-click menu of the part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_EventsById")]
        public global::System.Collections.Generic.IList<string> EventsById {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_EventsById", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// The modules field names and their associated values, as a dictionary.
        /// These are the values visible in the right-click menu of the part.
        /// </summary>
        /// <remarks>
        /// Throws an exception if there is more than one field with the same name.
        /// In that case, use <see cref="M:SpaceCenter.Module.FieldsById" /> to get the fields by identifier.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Fields")]
        public global::System.Collections.Generic.IDictionary<string,string> Fields {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Fields", _args);
                return (global::System.Collections.Generic.IDictionary<string,string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,string>), connection);
            }
        }

        /// <summary>
        /// The modules field identifiers and their associated values, as a dictionary.
        /// These are the values visible in the right-click menu of the part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_FieldsById")]
        public global::System.Collections.Generic.IDictionary<string,string> FieldsById {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_FieldsById", _args);
                return (global::System.Collections.Generic.IDictionary<string,string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,string>), connection);
            }
        }

        /// <summary>
        /// Name of the PartModule. For example, "ModuleEngines".
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// The part that contains this module.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Module))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }
    }

    /// <summary>
    /// Represents a maneuver node. Can be created using <see cref="M:SpaceCenter.Control.AddNode" />.
    /// </summary>
    public class Node : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Node (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Returns the burn vector for the maneuver node.
        /// </summary>
        /// <param name="referenceFrame">The reference frame that the returned vector is in.
        /// Defaults to <see cref="M:SpaceCenter.Vessel.OrbitalReferenceFrame" />.</param>
        /// <returns>A vector whose direction is the direction of the maneuver node burn, and
        /// magnitude is the delta-v of the burn in meters per second.
        /// </returns>
        /// <remarks>
        /// Does not change when executing the maneuver node. See <see cref="M:SpaceCenter.Node.RemainingBurnVector" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_BurnVector")]
        public systemAlias::Tuple<double,double,double> BurnVector (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame = null)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_BurnVector", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The direction of the maneuver nodes burn.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// direction is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_Direction")]
        public systemAlias::Tuple<double,double,double> Direction (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_Direction", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The position vector of the maneuver node in the given reference frame.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_Position")]
        public systemAlias::Tuple<double,double,double> Position (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_Position", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// Returns the remaining burn vector for the maneuver node.
        /// </summary>
        /// <param name="referenceFrame">The reference frame that the returned vector is in.
        /// Defaults to <see cref="M:SpaceCenter.Vessel.OrbitalReferenceFrame" />.</param>
        /// <returns>A vector whose direction is the direction of the maneuver node burn, and
        /// magnitude is the delta-v of the burn in meters per second.
        /// </returns>
        /// <remarks>
        /// Changes as the maneuver node is executed. See <see cref="M:SpaceCenter.Node.BurnVector" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_RemainingBurnVector")]
        public systemAlias::Tuple<double,double,double> RemainingBurnVector (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame = null)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Node_RemainingBurnVector", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// Removes the maneuver node.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_Remove")]
        public void Remove ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
            };
            connection.Invoke ("SpaceCenter", "Node_Remove", _args);
        }

        /// <summary>
        /// The delta-v of the maneuver node, in meters per second.
        /// </summary>
        /// <remarks>
        /// Does not change when executing the maneuver node. See <see cref="M:SpaceCenter.Node.RemainingDeltaV" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_DeltaV")]
        public double DeltaV {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_DeltaV", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Node_set_DeltaV", _args);
            }
        }

        /// <summary>
        /// The magnitude of the maneuver nodes delta-v in the normal direction,
        /// in meters per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_Normal")]
        public double Normal {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_Normal", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Node_set_Normal", _args);
            }
        }

        /// <summary>
        /// The orbit that results from executing the maneuver node.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_Orbit")]
        public global::KRPC.Client.Services.SpaceCenter.Orbit Orbit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_Orbit", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Orbit)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to the maneuver node, and
        /// orientated with the orbital prograde/normal/radial directions of the
        /// original orbit at the maneuver node's position.
        /// <list type="bullet"><item><description>The origin is at the position of the maneuver node.</description></item><item><description>The x-axis points in the orbital anti-radial direction of the original
        /// orbit, at the position of the maneuver node.</description></item><item><description>The y-axis points in the orbital prograde direction of the original
        /// orbit, at the position of the maneuver node.</description></item><item><description>The z-axis points in the orbital normal direction of the original orbit,
        /// at the position of the maneuver node.</description></item></list></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_OrbitalReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame OrbitalReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_OrbitalReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// The magnitude of the maneuver nodes delta-v in the prograde direction,
        /// in meters per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_Prograde")]
        public double Prograde {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_Prograde", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Node_set_Prograde", _args);
            }
        }

        /// <summary>
        /// The magnitude of the maneuver nodes delta-v in the radial direction,
        /// in meters per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_Radial")]
        public double Radial {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_Radial", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Node_set_Radial", _args);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to the maneuver node's burn.
        /// <list type="bullet"><item><description>The origin is at the position of the maneuver node.</description></item><item><description>The y-axis points in the direction of the burn.</description></item><item><description>The x-axis and z-axis point in arbitrary but fixed directions.</description></item></list></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_ReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_ReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// Gets the remaining delta-v of the maneuver node, in meters per second. Changes as the
        /// node is executed. This is equivalent to the delta-v reported in-game.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_RemainingDeltaV")]
        public double RemainingDeltaV {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_RemainingDeltaV", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The time until the maneuver node will be encountered, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_TimeTo")]
        public double TimeTo {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_TimeTo", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The universal time at which the maneuver will occur, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Node_get_UT")]
        public double UT {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Node_get_UT", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Node)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Node_set_UT", _args);
            }
        }
    }

    /// <summary>
    /// Describes an orbit. For example, the orbit of a vessel, obtained by calling
    /// <see cref="M:SpaceCenter.Vessel.Orbit" />, or a celestial body, obtained by calling
    /// <see cref="M:SpaceCenter.CelestialBody.Orbit" />.
    /// </summary>
    public class Orbit : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Orbit (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Estimates and returns the distance at closest approach to a target orbit, in meters.
        /// </summary>
        /// <param name="target">Target orbit.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_DistanceAtClosestApproach")]
        public double DistanceAtClosestApproach (global::KRPC.Client.Services.SpaceCenter.Orbit target)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (target, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_DistanceAtClosestApproach", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The eccentric anomaly at the given universal time.
        /// </summary>
        /// <param name="ut">The universal time, in seconds.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_EccentricAnomalyAtUT")]
        public double EccentricAnomalyAtUT (double ut)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (ut, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_EccentricAnomalyAtUT", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// Returns the times at closest approach and corresponding distances, to a target orbit.
        /// </summary>
        /// <returns>
        /// A list of two lists.
        /// The first is a list of times at closest approach, as universal times in seconds.
        /// The second is a list of corresponding distances at closest approach, in meters.
        /// </returns>
        /// <param name="target">Target orbit.</param>
        /// <param name="orbits">The number of future orbits to search.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_ListClosestApproaches")]
        public global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<double>> ListClosestApproaches (global::KRPC.Client.Services.SpaceCenter.Orbit target, int orbits)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (target, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (orbits, typeof(int))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_ListClosestApproaches", _args);
            return (global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<double>>), connection);
        }

        /// <summary>
        /// The mean anomaly at the given time.
        /// </summary>
        /// <param name="ut">The universal time in seconds.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_MeanAnomalyAtUT")]
        public double MeanAnomalyAtUT (double ut)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (ut, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_MeanAnomalyAtUT", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The orbital speed at the given time, in meters per second.
        /// </summary>
        /// <param name="time">Time from now, in seconds.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_OrbitalSpeedAt")]
        public double OrbitalSpeedAt (double time)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (time, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_OrbitalSpeedAt", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The position at a given time, in the specified reference frame.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="ut">The universal time to measure the position at.</param>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_PositionAt")]
        public systemAlias::Tuple<double,double,double> PositionAt (double ut, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (ut, typeof(double)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_PositionAt", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The orbital radius at the given time, in meters.
        /// </summary>
        /// <param name="ut">The universal time to measure the radius at.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_RadiusAt")]
        public double RadiusAt (double ut)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (ut, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_RadiusAt", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The orbital radius at the point in the orbit given by the true anomaly.
        /// </summary>
        /// <param name="trueAnomaly">The true anomaly.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_RadiusAtTrueAnomaly")]
        public double RadiusAtTrueAnomaly (double trueAnomaly)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (trueAnomaly, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_RadiusAtTrueAnomaly", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// Relative inclination of this orbit and the target orbit, in radians.
        /// </summary>
        /// <param name="target">Target orbit.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_RelativeInclination")]
        public double RelativeInclination (global::KRPC.Client.Services.SpaceCenter.Orbit target)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (target, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_RelativeInclination", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// Estimates and returns the time at closest approach to a target orbit.
        /// </summary>
        /// <returns>The universal time at closest approach, in seconds.</returns>
        /// <param name="target">Target orbit.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_TimeOfClosestApproach")]
        public double TimeOfClosestApproach (global::KRPC.Client.Services.SpaceCenter.Orbit target)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (target, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_TimeOfClosestApproach", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The true anomaly of the ascending node with the given target orbit.
        /// </summary>
        /// <param name="target">Target orbit.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_TrueAnomalyAtAN")]
        public double TrueAnomalyAtAN (global::KRPC.Client.Services.SpaceCenter.Orbit target)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (target, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_TrueAnomalyAtAN", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The true anomaly of the descending node with the given target orbit.
        /// </summary>
        /// <param name="target">Target orbit.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_TrueAnomalyAtDN")]
        public double TrueAnomalyAtDN (global::KRPC.Client.Services.SpaceCenter.Orbit target)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (target, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_TrueAnomalyAtDN", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The true anomaly at the given orbital radius.
        /// </summary>
        /// <param name="radius">The orbital radius in meters.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_TrueAnomalyAtRadius")]
        public double TrueAnomalyAtRadius (double radius)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (radius, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_TrueAnomalyAtRadius", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The true anomaly at the given time.
        /// </summary>
        /// <param name="ut">The universal time in seconds.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_TrueAnomalyAtUT")]
        public double TrueAnomalyAtUT (double ut)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (ut, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_TrueAnomalyAtUT", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The universal time, in seconds, corresponding to the given true anomaly.
        /// </summary>
        /// <param name="trueAnomaly">True anomaly.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_UTAtTrueAnomaly")]
        public double UTAtTrueAnomaly (double trueAnomaly)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit)),
                global::KRPC.Client.Encoder.Encode (trueAnomaly, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_UTAtTrueAnomaly", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }

        /// <summary>
        /// The direction from which the orbits longitude of ascending node is measured,
        /// in the given reference frame.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// direction is in.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_static_ReferencePlaneDirection")]
        public static systemAlias::Tuple<double,double,double> ReferencePlaneDirection (IConnection connection, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_static_ReferencePlaneDirection", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The direction that is normal to the orbits reference plane,
        /// in the given reference frame.
        /// The reference plane is the plane from which the orbits inclination is measured.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// direction is in.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_static_ReferencePlaneNormal")]
        public static systemAlias::Tuple<double,double,double> ReferencePlaneNormal (IConnection connection, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_static_ReferencePlaneNormal", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// Gets the apoapsis of the orbit, in meters, from the center of mass
        /// of the body being orbited.
        /// </summary>
        /// <remarks>
        /// For the apoapsis altitude reported on the in-game map view,
        /// use <see cref="M:SpaceCenter.Orbit.ApoapsisAltitude" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_Apoapsis")]
        public double Apoapsis {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_Apoapsis", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The apoapsis of the orbit, in meters, above the sea level of the body being orbited.
        /// </summary>
        /// <remarks>
        /// This is equal to <see cref="M:SpaceCenter.Orbit.Apoapsis" /> minus the equatorial radius of the body.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_ApoapsisAltitude")]
        public double ApoapsisAltitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_ApoapsisAltitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Argument_of_periapsis">argument of
        /// periapsis</a>, in radians.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_ArgumentOfPeriapsis")]
        public double ArgumentOfPeriapsis {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_ArgumentOfPeriapsis", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The celestial body (e.g. planet or moon) around which the object is orbiting.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_Body")]
        public global::KRPC.Client.Services.SpaceCenter.CelestialBody Body {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_Body", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CelestialBody)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Eccentric_anomaly">eccentric anomaly</a>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_EccentricAnomaly")]
        public double EccentricAnomaly {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_EccentricAnomaly", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Orbital_eccentricity">eccentricity</a>
        /// of the orbit.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_Eccentricity")]
        public double Eccentricity {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_Eccentricity", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The time since the epoch (the point at which the
        /// <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly at epoch</a>
        /// was measured, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_Epoch")]
        public double Epoch {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_Epoch", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Orbital_inclination">inclination</a>
        /// of the orbit,
        /// in radians.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_Inclination")]
        public double Inclination {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_Inclination", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Longitude_of_the_ascending_node">longitude of
        /// the ascending node</a>, in radians.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_LongitudeOfAscendingNode")]
        public double LongitudeOfAscendingNode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_LongitudeOfAscendingNode", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly</a>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_MeanAnomaly")]
        public double MeanAnomaly {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_MeanAnomaly", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly at epoch</a>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_MeanAnomalyAtEpoch")]
        public double MeanAnomalyAtEpoch {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_MeanAnomalyAtEpoch", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// If the object is going to change sphere of influence in the future, returns the new
        /// orbit after the change. Otherwise returns <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_NextOrbit")]
        public global::KRPC.Client.Services.SpaceCenter.Orbit NextOrbit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_NextOrbit", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Orbit)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit), connection);
            }
        }

        /// <summary>
        /// The current orbital speed in meters per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_OrbitalSpeed")]
        public double OrbitalSpeed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_OrbitalSpeed", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The periapsis of the orbit, in meters, from the center of mass
        /// of the body being orbited.
        /// </summary>
        /// <remarks>
        /// For the periapsis altitude reported on the in-game map view,
        /// use <see cref="M:SpaceCenter.Orbit.PeriapsisAltitude" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_Periapsis")]
        public double Periapsis {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_Periapsis", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The periapsis of the orbit, in meters, above the sea level of the body being orbited.
        /// </summary>
        /// <remarks>
        /// This is equal to <see cref="M:SpaceCenter.Orbit.Periapsis" /> minus the equatorial radius of the body.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_PeriapsisAltitude")]
        public double PeriapsisAltitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_PeriapsisAltitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The orbital period, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_Period")]
        public double Period {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_Period", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The current radius of the orbit, in meters. This is the distance between the center
        /// of mass of the object in orbit, and the center of mass of the body around which it
        /// is orbiting.
        /// </summary>
        /// <remarks>
        /// This value will change over time if the orbit is elliptical.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_Radius")]
        public double Radius {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_Radius", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The semi-major axis of the orbit, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_SemiMajorAxis")]
        public double SemiMajorAxis {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_SemiMajorAxis", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The semi-minor axis of the orbit, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_SemiMinorAxis")]
        public double SemiMinorAxis {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_SemiMinorAxis", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The current orbital speed of the object in meters per second.
        /// </summary>
        /// <remarks>
        /// This value will change over time if the orbit is elliptical.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_Speed")]
        public double Speed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_Speed", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The time until the object reaches apoapsis, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_TimeToApoapsis")]
        public double TimeToApoapsis {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_TimeToApoapsis", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The time until the object reaches periapsis, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_TimeToPeriapsis")]
        public double TimeToPeriapsis {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_TimeToPeriapsis", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The time until the object changes sphere of influence, in seconds. Returns <c>NaN</c>
        /// if the object is not going to change sphere of influence.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_TimeToSOIChange")]
        public double TimeToSOIChange {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_TimeToSOIChange", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The <a href="https://en.wikipedia.org/wiki/True_anomaly">true anomaly</a>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Orbit_get_TrueAnomaly")]
        public double TrueAnomaly {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Orbit))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Orbit_get_TrueAnomaly", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }
    }

    /// <summary>
    /// A parachute. Obtained by calling <see cref="M:SpaceCenter.Part.Parachute" />.
    /// </summary>
    public class Parachute : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Parachute (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Deploys the parachute. This has no effect if the parachute has already
        /// been armed or deployed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_Arm")]
        public void Arm ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute))
            };
            connection.Invoke ("SpaceCenter", "Parachute_Arm", _args);
        }

        /// <summary>
        /// Cuts the parachute.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_Cut")]
        public void Cut ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute))
            };
            connection.Invoke ("SpaceCenter", "Parachute_Cut", _args);
        }

        /// <summary>
        /// Deploys the parachute. This has no effect if the parachute has already
        /// been deployed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_Deploy")]
        public void Deploy ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute))
            };
            connection.Invoke ("SpaceCenter", "Parachute_Deploy", _args);
        }

        /// <summary>
        /// Whether the parachute has been armed or deployed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_Armed")]
        public bool Armed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_Armed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The altitude at which the parachute will full deploy, in meters.
        /// Only applicable to stock parachutes.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_DeployAltitude")]
        public float DeployAltitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_DeployAltitude", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Parachute_set_DeployAltitude", _args);
            }
        }

        /// <summary>
        /// The minimum pressure at which the parachute will semi-deploy, in atmospheres.
        /// Only applicable to stock parachutes.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_DeployMinPressure")]
        public float DeployMinPressure {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_DeployMinPressure", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Parachute_set_DeployMinPressure", _args);
            }
        }

        /// <summary>
        /// Whether the parachute has been deployed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_Deployed")]
        public bool Deployed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_Deployed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The part object for this parachute.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The current state of the parachute.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parachute_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.ParachuteState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parachute))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parachute_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ParachuteState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ParachuteState), connection);
            }
        }
    }

    /// <summary>
    /// Represents an individual part. Vessels are made up of multiple parts.
    /// Instances of this class can be obtained by several methods in <see cref="T:SpaceCenter.Parts" />.
    /// </summary>
    public class Part : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Part (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Exert a constant force on the part, acting at the given position.
        /// </summary>
        /// <returns>An object that can be used to remove or modify the force.</returns>
        /// <param name="force">A vector pointing in the direction that the force acts,
        /// with its magnitude equal to the strength of the force in Newtons.</param>
        /// <param name="position">The position at which the force acts, as a vector.</param>
        /// <param name="referenceFrame">The reference frame that the
        /// force and position are in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_AddForce")]
        public global::KRPC.Client.Services.SpaceCenter.Force AddForce (systemAlias::Tuple<double,double,double> force, systemAlias::Tuple<double,double,double> position, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (force, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_AddForce", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Force)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Force), connection);
        }

        /// <summary>
        /// The axis-aligned bounding box of the part in the given reference frame.
        /// </summary>
        /// <returns>The positions of the minimum and maximum vertices of the box,
        /// as position vectors.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vectors are in.</param>
        /// <remarks>
        /// This is computed from the collision mesh of the part.
        /// If the part is not collidable, the box has zero volume and is centered on
        /// the <see cref="M:SpaceCenter.Part.Position" /> of the part.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_BoundingBox")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> BoundingBox (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_BoundingBox", _args);
            return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
        }

        /// <summary>
        /// The position of the parts center of mass in the given reference frame.
        /// If the part is physicsless, this is equivalent to <see cref="M:SpaceCenter.Part.Position" />.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_CenterOfMass")]
        public systemAlias::Tuple<double,double,double> CenterOfMass (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_CenterOfMass", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The direction the part points in, in the given reference frame.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// direction is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_Direction")]
        public systemAlias::Tuple<double,double,double> Direction (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_Direction", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// Exert an instantaneous force on the part, acting at the given position.
        /// </summary>
        /// <param name="force">A vector pointing in the direction that the force acts,
        /// with its magnitude equal to the strength of the force in Newtons.</param>
        /// <param name="position">The position at which the force acts, as a vector.</param>
        /// <param name="referenceFrame">The reference frame that the
        /// force and position are in.</param>
        /// <remarks>The force is applied instantaneously in a single physics update.</remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_InstantaneousForce")]
        public void InstantaneousForce (systemAlias::Tuple<double,double,double> force, systemAlias::Tuple<double,double,double> position, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (force, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            connection.Invoke ("SpaceCenter", "Part_InstantaneousForce", _args);
        }

        /// <summary>
        /// The position of the part in the given reference frame.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        /// <remarks>
        /// This is a fixed position in the part, defined by the parts model.
        /// It s not necessarily the same as the parts center of mass.
        /// Use <see cref="M:SpaceCenter.Part.CenterOfMass" /> to get the parts center of mass.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_Position")]
        public systemAlias::Tuple<double,double,double> Position (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_Position", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The rotation of the part, in the given reference frame.
        /// </summary>
        /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// rotation is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_Rotation")]
        public systemAlias::Tuple<double,double,double,double> Rotation (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_Rotation", _args);
            return (systemAlias::Tuple<double,double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double,double>), connection);
        }

        /// <summary>
        /// The linear velocity of the part in the given reference frame.
        /// </summary>
        /// <returns>The velocity as a vector. The vector points in the direction of travel,
        /// and its magnitude is the speed of the body in meters per second.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// velocity vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_Velocity")]
        public systemAlias::Tuple<double,double,double> Velocity (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_Velocity", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// An <see cref="T:SpaceCenter.Antenna" /> if the part is an antenna, otherwise <c>null</c>.
        /// </summary>
        /// <remarks>
        /// If RemoteTech is installed, this will always return <c>null</c>.
        /// To interact with RemoteTech antennas, use the RemoteTech service APIs.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Antenna")]
        public global::KRPC.Client.Services.SpaceCenter.Antenna Antenna {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Antenna", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Antenna)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Antenna), connection);
            }
        }

        /// <summary>
        /// Auto-strut mode.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_AutoStrutMode")]
        public global::KRPC.Client.Services.SpaceCenter.AutoStrutMode AutoStrutMode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_AutoStrutMode", _args);
                return (global::KRPC.Client.Services.SpaceCenter.AutoStrutMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.AutoStrutMode), connection);
            }
        }

        /// <summary>
        /// How many open seats the part has.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_AvailableSeats")]
        public uint AvailableSeats {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_AvailableSeats", _args);
                return (uint)global::KRPC.Client.Encoder.Decode (_data, typeof(uint), connection);
            }
        }

        /// <summary>
        /// Whether the part is axially attached to its parent, i.e. on the top
        /// or bottom of its parent. If the part has no parent, returns <c>false</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_AxiallyAttached")]
        public bool AxiallyAttached {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_AxiallyAttached", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.CargoBay" /> if the part is a cargo bay, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_CargoBay")]
        public global::KRPC.Client.Services.SpaceCenter.CargoBay CargoBay {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_CargoBay", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CargoBay)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CargoBay), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to this part, and centered on its
        /// center of mass.
        /// <list type="bullet"><item><description>The origin is at the center of mass of the part, as returned by
        /// <see cref="M:SpaceCenter.Part.CenterOfMass" />.</description></item><item><description>The axes rotate with the part.</description></item><item><description>The x, y and z axis directions depend on the design of the part.
        /// </description></item></list></summary>
        /// <remarks>
        /// For docking port parts, this reference frame is not necessarily equivalent to the
        /// reference frame for the docking port, returned by
        /// <see cref="M:SpaceCenter.DockingPort.ReferenceFrame" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_CenterOfMassReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame CenterOfMassReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_CenterOfMassReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// The parts children. Returns an empty list if the part has no children.
        /// This, in combination with <see cref="M:SpaceCenter.Part.Parent" />, can be used to traverse the vessels
        /// parts tree.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Children")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> Children {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Children", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.ControlSurface" /> if the part is an aerodynamic control surface,
        /// otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ControlSurface")]
        public global::KRPC.Client.Services.SpaceCenter.ControlSurface ControlSurface {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ControlSurface", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ControlSurface)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ControlSurface), connection);
            }
        }

        /// <summary>
        /// The cost of the part, in units of funds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Cost")]
        public double Cost {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Cost", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Whether this part is crossfeed capable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Crossfeed")]
        public bool Crossfeed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Crossfeed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The stage in which this part will be decoupled. Returns -1 if the part is never
        /// decoupled from the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_DecoupleStage")]
        public int DecoupleStage {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_DecoupleStage", _args);
                return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Decoupler" /> if the part is a decoupler, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Decoupler")]
        public global::KRPC.Client.Services.SpaceCenter.Decoupler Decoupler {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Decoupler", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Decoupler)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Decoupler), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.DockingPort" /> if the part is a docking port, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_DockingPort")]
        public global::KRPC.Client.Services.SpaceCenter.DockingPort DockingPort {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_DockingPort", _args);
                return (global::KRPC.Client.Services.SpaceCenter.DockingPort)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.DockingPort), connection);
            }
        }

        /// <summary>
        /// The mass of the part, not including any resources it contains, in kilograms.
        /// Returns zero if the part is massless.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_DryMass")]
        public double DryMass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_DryMass", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The dynamic pressure acting on the part, in Pascals.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_DynamicPressure")]
        public float DynamicPressure {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_DynamicPressure", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// An <see cref="T:SpaceCenter.Engine" /> if the part is an engine, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Engine")]
        public global::KRPC.Client.Services.SpaceCenter.Engine Engine {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Engine", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Engine)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Engine), connection);
            }
        }

        /// <summary>
        /// An <see cref="T:SpaceCenter.Experiment" /> if the part contains a
        /// single science experiment, otherwise <c>null</c>.
        /// </summary>
        /// <remarks>
        /// Throws an exception if the part contains more than one experiment.
        /// In that case, use <see cref="M:SpaceCenter.Part.Experiments" /> to get the list of experiments in the part.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Experiment")]
        public global::KRPC.Client.Services.SpaceCenter.Experiment Experiment {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Experiment", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Experiment)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Experiment), connection);
            }
        }

        /// <summary>
        /// A list of <see cref="T:SpaceCenter.Experiment" /> objects that the part contains.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Experiments")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Experiment> Experiments {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Experiments", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Experiment>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Experiment>), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Fairing" /> if the part is a fairing, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Fairing")]
        public global::KRPC.Client.Services.SpaceCenter.Fairing Fairing {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Fairing", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Fairing)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Fairing), connection);
            }
        }

        /// <summary>
        /// The asset URL for the part's flag.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_FlagURL")]
        public string FlagURL {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_FlagURL", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(string))
                };
                connection.Invoke ("SpaceCenter", "Part_set_FlagURL", _args);
            }
        }

        /// <summary>
        /// The parts that are connected to this part via fuel lines, where the direction of the
        /// fuel line is into this part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_FuelLinesFrom")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> FuelLinesFrom {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_FuelLinesFrom", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
            }
        }

        /// <summary>
        /// The parts that are connected to this part via fuel lines, where the direction of the
        /// fuel line is out of this part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_FuelLinesTo")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> FuelLinesTo {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_FuelLinesTo", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
            }
        }

        /// <summary>
        /// Whether the part is glowing.
        /// </summary>
        public bool Glow {
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Part_set_Glow", _args);
            }
        }

        /// <summary>
        /// The color used to highlight the part, as an RGB triple.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_HighlightColor")]
        public systemAlias::Tuple<double,double,double> HighlightColor {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_HighlightColor", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(systemAlias::Tuple<double,double,double>))
                };
                connection.Invoke ("SpaceCenter", "Part_set_HighlightColor", _args);
            }
        }

        /// <summary>
        /// Whether the part is highlighted.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Highlighted")]
        public bool Highlighted {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Highlighted", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Part_set_Highlighted", _args);
            }
        }

        /// <summary>
        /// The impact tolerance of the part, in meters per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ImpactTolerance")]
        public double ImpactTolerance {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ImpactTolerance", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The inertia tensor of the part in the parts reference frame
        /// (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// Returns the 3x3 matrix as a list of elements, in row-major order.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_InertiaTensor")]
        public global::System.Collections.Generic.IList<double> InertiaTensor {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_InertiaTensor", _args);
                return (global::System.Collections.Generic.IList<double>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<double>), connection);
            }
        }

        /// <summary>
        /// An <see cref="T:SpaceCenter.Intake" /> if the part is an intake, otherwise <c>null</c>.
        /// </summary>
        /// <remarks>
        /// This includes any part that generates thrust. This covers many different types
        /// of engine, including liquid fuel rockets, solid rocket boosters and jet engines.
        /// For RCS thrusters see <see cref="T:SpaceCenter.RCS" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Intake")]
        public global::KRPC.Client.Services.SpaceCenter.Intake Intake {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Intake", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Intake)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Intake), connection);
            }
        }

        /// <summary>
        /// Whether this part is a fuel line.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_IsFuelLine")]
        public bool IsFuelLine {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_IsFuelLine", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.LaunchClamp" /> if the part is a launch clamp, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_LaunchClamp")]
        public global::KRPC.Client.Services.SpaceCenter.LaunchClamp LaunchClamp {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_LaunchClamp", _args);
                return (global::KRPC.Client.Services.SpaceCenter.LaunchClamp)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.LaunchClamp), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Leg" /> if the part is a landing leg, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Leg")]
        public global::KRPC.Client.Services.SpaceCenter.Leg Leg {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Leg", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Leg)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Leg), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Light" /> if the part is a light, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Light")]
        public global::KRPC.Client.Services.SpaceCenter.Light Light {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Light", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Light)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Light), connection);
            }
        }

        /// <summary>
        /// The current mass of the part, including resources it contains, in kilograms.
        /// Returns zero if the part is massless.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Mass")]
        public double Mass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Mass", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Whether the part is
        /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Massless_part">massless</a>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Massless")]
        public bool Massless {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Massless", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Maximum temperature that the skin of the part can survive, in Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_MaxSkinTemperature")]
        public double MaxSkinTemperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_MaxSkinTemperature", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// Maximum temperature that the part can survive, in Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_MaxTemperature")]
        public double MaxTemperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_MaxTemperature", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The modules for this part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Modules")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Module> Modules {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Modules", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Module>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Module>), connection);
            }
        }

        /// <summary>
        /// The moment of inertia of the part in <math>kg.m^2</math> around its center of mass
        /// in the parts reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_MomentOfInertia")]
        public systemAlias::Tuple<double,double,double> MomentOfInertia {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_MomentOfInertia", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// Internal name of the part, as used in
        /// <a href="https://wiki.kerbalspaceprogram.com/wiki/CFG_File_Documentation">part cfg files</a>.
        /// For example "Mark1-2Pod".
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Parachute" /> if the part is a parachute, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Parachute")]
        public global::KRPC.Client.Services.SpaceCenter.Parachute Parachute {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Parachute", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Parachute)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Parachute), connection);
            }
        }

        /// <summary>
        /// The parts parent. Returns <c>null</c> if the part does not have a parent.
        /// This, in combination with <see cref="M:SpaceCenter.Part.Children" />, can be used to traverse the vessels
        /// parts tree.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Parent")]
        public global::KRPC.Client.Services.SpaceCenter.Part Parent {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Parent", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.RCS" /> if the part is an RCS block/thruster, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RCS")]
        public global::KRPC.Client.Services.SpaceCenter.RCS RCS {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RCS", _args);
                return (global::KRPC.Client.Services.SpaceCenter.RCS)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.RCS), connection);
            }
        }

        /// <summary>
        /// Whether the part is radially attached to its parent, i.e. on the side of its parent.
        /// If the part has no parent, returns <c>false</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RadiallyAttached")]
        public bool RadiallyAttached {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RadiallyAttached", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Radiator" /> if the part is a radiator, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Radiator")]
        public global::KRPC.Client.Services.SpaceCenter.Radiator Radiator {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Radiator", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Radiator)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Radiator), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.ReactionWheel" /> if the part is a reaction wheel, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ReactionWheel")]
        public global::KRPC.Client.Services.SpaceCenter.ReactionWheel ReactionWheel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ReactionWheel", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReactionWheel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReactionWheel), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to this part, and centered on a fixed
        /// position within the part, defined by the parts model.
        /// <list type="bullet"><item><description>The origin is at the position of the part, as returned by
        /// <see cref="M:SpaceCenter.Part.Position" />.</description></item><item><description>The axes rotate with the part.</description></item><item><description>The x, y and z axis directions depend on the design of the part.
        /// </description></item></list></summary>
        /// <remarks>
        /// For docking port parts, this reference frame is not necessarily equivalent to the
        /// reference frame for the docking port, returned by
        /// <see cref="M:SpaceCenter.DockingPort.ReferenceFrame" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.ResourceConverter" /> if the part is a resource converter,
        /// otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ResourceConverter")]
        public global::KRPC.Client.Services.SpaceCenter.ResourceConverter ResourceConverter {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ResourceConverter", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ResourceConverter)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ResourceConverter), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.ResourceDrain" /> if the part is a resource drain, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ResourceDrain")]
        public global::KRPC.Client.Services.SpaceCenter.ResourceDrain ResourceDrain {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ResourceDrain", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ResourceDrain)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ResourceDrain), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.ResourceHarvester" /> if the part is a resource harvester,
        /// otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ResourceHarvester")]
        public global::KRPC.Client.Services.SpaceCenter.ResourceHarvester ResourceHarvester {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ResourceHarvester", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ResourceHarvester)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ResourceHarvester), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Resources" /> object for the part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Resources")]
        public global::KRPC.Client.Services.SpaceCenter.Resources Resources {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Resources", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Resources)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Resources), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.RoboticController" /> if the part is a robotic controller,
        /// otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticController")]
        public global::KRPC.Client.Services.SpaceCenter.RoboticController RoboticController {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticController", _args);
                return (global::KRPC.Client.Services.SpaceCenter.RoboticController)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.RoboticController), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.RoboticHinge" /> if the part is a robotic hinge, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticHinge")]
        public global::KRPC.Client.Services.SpaceCenter.RoboticHinge RoboticHinge {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticHinge", _args);
                return (global::KRPC.Client.Services.SpaceCenter.RoboticHinge)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.RoboticHinge), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.RoboticPiston" /> if the part is a robotic piston, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticPiston")]
        public global::KRPC.Client.Services.SpaceCenter.RoboticPiston RoboticPiston {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticPiston", _args);
                return (global::KRPC.Client.Services.SpaceCenter.RoboticPiston)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.RoboticPiston), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.RoboticRotation" /> if the part is a robotic rotation servo, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticRotation")]
        public global::KRPC.Client.Services.SpaceCenter.RoboticRotation RoboticRotation {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticRotation", _args);
                return (global::KRPC.Client.Services.SpaceCenter.RoboticRotation)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.RoboticRotation), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.RoboticRotor" /> if the part is a robotic rotor, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticRotor")]
        public global::KRPC.Client.Services.SpaceCenter.RoboticRotor RoboticRotor {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticRotor", _args);
                return (global::KRPC.Client.Services.SpaceCenter.RoboticRotor)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.RoboticRotor), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Sensor" /> if the part is a sensor, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Sensor")]
        public global::KRPC.Client.Services.SpaceCenter.Sensor Sensor {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Sensor", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Sensor)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Sensor), connection);
            }
        }

        /// <summary>
        /// Whether the part is shielded from the exterior of the vessel, for example by a fairing.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Shielded")]
        public bool Shielded {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Shielded", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Temperature of the skin of the part, in Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_SkinTemperature")]
        public double SkinTemperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_SkinTemperature", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.SolarPanel" /> if the part is a solar panel, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_SolarPanel")]
        public global::KRPC.Client.Services.SpaceCenter.SolarPanel SolarPanel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_SolarPanel", _args);
                return (global::KRPC.Client.Services.SpaceCenter.SolarPanel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.SolarPanel), connection);
            }
        }

        /// <summary>
        /// The stage in which this part will be activated. Returns -1 if the part is not
        /// activated by staging.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Stage")]
        public int Stage {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Stage", _args);
                return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
            }
        }

        /// <summary>
        /// The name tag for the part. Can be set to a custom string using the
        /// in-game user interface.
        /// </summary>
        /// <remarks>
        /// This string is shared with
        /// <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/61827-/">kOS</a>
        /// if it is installed.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Tag")]
        public string Tag {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Tag", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(string))
                };
                connection.Invoke ("SpaceCenter", "Part_set_Tag", _args);
            }
        }

        /// <summary>
        /// Temperature of the part, in Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Temperature")]
        public double Temperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Temperature", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The rate at which heat energy is conducting into or out of the part via contact with
        /// other parts. Measured in energy per unit time, or power, in Watts.
        /// A positive value means the part is gaining heat energy, and negative means it is
        /// losing heat energy.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ThermalConductionFlux")]
        public float ThermalConductionFlux {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ThermalConductionFlux", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The rate at which heat energy is convecting into or out of the part from the
        /// surrounding atmosphere. Measured in energy per unit time, or power, in Watts.
        /// A positive value means the part is gaining heat energy, and negative means it is
        /// losing heat energy.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ThermalConvectionFlux")]
        public float ThermalConvectionFlux {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ThermalConvectionFlux", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The rate at which heat energy is begin generated by the part.
        /// For example, some engines generate heat by combusting fuel.
        /// Measured in energy per unit time, or power, in Watts.
        /// A positive value means the part is gaining heat energy, and negative means it is losing
        /// heat energy.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ThermalInternalFlux")]
        public float ThermalInternalFlux {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ThermalInternalFlux", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// A measure of how much energy it takes to increase the internal temperature of the part,
        /// in Joules per Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ThermalMass")]
        public float ThermalMass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ThermalMass", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The rate at which heat energy is radiating into or out of the part from the surrounding
        /// environment. Measured in energy per unit time, or power, in Watts.
        /// A positive value means the part is gaining heat energy, and negative means it is
        /// losing heat energy.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ThermalRadiationFlux")]
        public float ThermalRadiationFlux {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ThermalRadiationFlux", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// A measure of how much energy it takes to increase the temperature of the resources
        /// contained in the part, in Joules per Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ThermalResourceMass")]
        public float ThermalResourceMass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ThermalResourceMass", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// A measure of how much energy it takes to increase the skin temperature of the part,
        /// in Joules per Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ThermalSkinMass")]
        public float ThermalSkinMass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ThermalSkinMass", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The rate at which heat energy is transferring between the part's skin and its internals.
        /// Measured in energy per unit time, or power, in Watts.
        /// A positive value means the part's internals are gaining heat energy,
        /// and negative means its skin is gaining heat energy.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ThermalSkinToInternalFlux")]
        public float ThermalSkinToInternalFlux {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ThermalSkinToInternalFlux", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Title of the part, as shown when the part is right clicked in-game. For example "Mk1-2 Command Pod".
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Title")]
        public string Title {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Title", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// The vessel that contains this part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Vessel")]
        public global::KRPC.Client.Services.SpaceCenter.Vessel Vessel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Vessel", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Vessel), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Wheel" /> if the part is a wheel, otherwise <c>null</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Wheel")]
        public global::KRPC.Client.Services.SpaceCenter.Wheel Wheel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Part))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Wheel", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Wheel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Wheel), connection);
            }
        }
    }

    /// <summary>
    /// Instances of this class are used to interact with the parts of a vessel.
    /// An instance can be obtained by calling <see cref="M:SpaceCenter.Vessel.Parts" />.
    /// </summary>
    public class Parts : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Parts (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// A list of all parts that are decoupled in the given <paramref name="stage" />.
        /// </summary>
        /// <param name="stage"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_InDecoupleStage")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> InDecoupleStage (int stage)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts)),
                global::KRPC.Client.Encoder.Encode (stage, typeof(int))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_InDecoupleStage", _args);
            return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
        }

        /// <summary>
        /// A list of all parts that are activated in the given <paramref name="stage" />.
        /// </summary>
        /// <param name="stage"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_InStage")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> InStage (int stage)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts)),
                global::KRPC.Client.Encoder.Encode (stage, typeof(int))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_InStage", _args);
            return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
        }

        /// <summary>
        /// A list of modules (combined across all parts in the vessel) whose
        /// <see cref="M:SpaceCenter.Module.Name" /> is <paramref name="moduleName" />.
        /// </summary>
        /// <param name="moduleName"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_ModulesWithName")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Module> ModulesWithName (string moduleName)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts)),
                global::KRPC.Client.Encoder.Encode (moduleName, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_ModulesWithName", _args);
            return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Module>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Module>), connection);
        }

        /// <summary>
        /// A list of all parts that contain a <see cref="T:SpaceCenter.Module" /> whose
        /// <see cref="M:SpaceCenter.Module.Name" /> is <paramref name="moduleName" />.
        /// </summary>
        /// <param name="moduleName"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_WithModule")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> WithModule (string moduleName)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts)),
                global::KRPC.Client.Encoder.Encode (moduleName, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_WithModule", _args);
            return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
        }

        /// <summary>
        /// A list of parts whose <see cref="M:SpaceCenter.Part.Name" /> is <paramref name="name" />.
        /// </summary>
        /// <param name="name"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_WithName")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> WithName (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_WithName", _args);
            return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
        }

        /// <summary>
        /// A list of all parts whose <see cref="M:SpaceCenter.Part.Tag" /> is <paramref name="tag" />.
        /// </summary>
        /// <param name="tag"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_WithTag")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> WithTag (string tag)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts)),
                global::KRPC.Client.Encoder.Encode (tag, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_WithTag", _args);
            return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
        }

        /// <summary>
        /// A list of all parts whose <see cref="M:SpaceCenter.Part.Title" /> is <paramref name="title" />.
        /// </summary>
        /// <param name="title"></param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_WithTitle")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> WithTitle (string title)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts)),
                global::KRPC.Client.Encoder.Encode (title, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_WithTitle", _args);
            return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
        }

        /// <summary>
        /// A list of all of the vessels parts.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_All")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part> All {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_All", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Part>), connection);
            }
        }

        /// <summary>
        /// A list of all antennas in the vessel.
        /// </summary>
        /// <remarks>
        /// If RemoteTech is installed, this will always return an empty list.
        /// To interact with RemoteTech antennas, use the RemoteTech service APIs.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Antennas")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Antenna> Antennas {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Antennas", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Antenna>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Antenna>), connection);
            }
        }

        /// <summary>
        /// A list of all cargo bays in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_CargoBays")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CargoBay> CargoBays {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_CargoBays", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CargoBay>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CargoBay>), connection);
            }
        }

        /// <summary>
        /// A list of all control surfaces in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ControlSurfaces")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ControlSurface> ControlSurfaces {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ControlSurfaces", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ControlSurface>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ControlSurface>), connection);
            }
        }

        /// <summary>
        /// The part from which the vessel is controlled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Controlling")]
        public global::KRPC.Client.Services.SpaceCenter.Part Controlling {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Controlling", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.Part))
                };
                connection.Invoke ("SpaceCenter", "Parts_set_Controlling", _args);
            }
        }

        /// <summary>
        /// A list of all decouplers in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Decouplers")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Decoupler> Decouplers {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Decouplers", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Decoupler>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Decoupler>), connection);
            }
        }

        /// <summary>
        /// A list of all docking ports in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_DockingPorts")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.DockingPort> DockingPorts {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_DockingPorts", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.DockingPort>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.DockingPort>), connection);
            }
        }

        /// <summary>
        /// A list of all engines in the vessel.
        /// </summary>
        /// <remarks>
        /// This includes any part that generates thrust. This covers many different types
        /// of engine, including liquid fuel rockets, solid rocket boosters, jet engines and
        /// RCS thrusters.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Engines")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Engine> Engines {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Engines", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Engine>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Engine>), connection);
            }
        }

        /// <summary>
        /// A list of all science experiments in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Experiments")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Experiment> Experiments {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Experiments", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Experiment>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Experiment>), connection);
            }
        }

        /// <summary>
        /// A list of all fairings in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Fairings")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Fairing> Fairings {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Fairings", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Fairing>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Fairing>), connection);
            }
        }

        /// <summary>
        /// A list of all intakes in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Intakes")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Intake> Intakes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Intakes", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Intake>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Intake>), connection);
            }
        }

        /// <summary>
        /// A list of all launch clamps attached to the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_LaunchClamps")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.LaunchClamp> LaunchClamps {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_LaunchClamps", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.LaunchClamp>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.LaunchClamp>), connection);
            }
        }

        /// <summary>
        /// A list of all landing legs attached to the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Legs")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Leg> Legs {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Legs", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Leg>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Leg>), connection);
            }
        }

        /// <summary>
        /// A list of all lights in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Lights")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Light> Lights {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Lights", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Light>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Light>), connection);
            }
        }

        /// <summary>
        /// A list of all parachutes in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Parachutes")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Parachute> Parachutes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Parachutes", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Parachute>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Parachute>), connection);
            }
        }

        /// <summary>
        /// A list of all RCS blocks/thrusters in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RCS")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RCS> RCS {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RCS", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RCS>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RCS>), connection);
            }
        }

        /// <summary>
        /// A list of all radiators in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Radiators")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Radiator> Radiators {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Radiators", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Radiator>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Radiator>), connection);
            }
        }

        /// <summary>
        /// A list of all reaction wheels in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ReactionWheels")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ReactionWheel> ReactionWheels {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ReactionWheels", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ReactionWheel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ReactionWheel>), connection);
            }
        }

        /// <summary>
        /// A list of all resource converters in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ResourceConverters")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ResourceConverter> ResourceConverters {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ResourceConverters", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ResourceConverter>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ResourceConverter>), connection);
            }
        }

        /// <summary>
        /// A list of all resource drains in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ResourceDrains")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ResourceDrain> ResourceDrains {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ResourceDrains", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ResourceDrain>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ResourceDrain>), connection);
            }
        }

        /// <summary>
        /// A list of all resource harvesters in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ResourceHarvesters")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ResourceHarvester> ResourceHarvesters {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ResourceHarvesters", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ResourceHarvester>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.ResourceHarvester>), connection);
            }
        }

        /// <summary>
        /// A list of all robotic hinges in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RoboticHinges")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticHinge> RoboticHinges {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RoboticHinges", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticHinge>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticHinge>), connection);
            }
        }

        /// <summary>
        /// A list of all robotic pistons in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RoboticPistons")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticPiston> RoboticPistons {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RoboticPistons", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticPiston>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticPiston>), connection);
            }
        }

        /// <summary>
        /// A list of all robotic rotations in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RoboticRotations")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticRotation> RoboticRotations {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RoboticRotations", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticRotation>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticRotation>), connection);
            }
        }

        /// <summary>
        /// A list of all robotic rotors in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RoboticRotors")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticRotor> RoboticRotors {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RoboticRotors", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticRotor>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.RoboticRotor>), connection);
            }
        }

        /// <summary>
        /// The vessels root part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Root")]
        public global::KRPC.Client.Services.SpaceCenter.Part Root {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Root", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// A list of all sensors in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Sensors")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Sensor> Sensors {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Sensors", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Sensor>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Sensor>), connection);
            }
        }

        /// <summary>
        /// A list of all solar panels in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_SolarPanels")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.SolarPanel> SolarPanels {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_SolarPanels", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.SolarPanel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.SolarPanel>), connection);
            }
        }

        /// <summary>
        /// A list of all wheels in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Wheels")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Wheel> Wheels {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Parts))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Wheels", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Wheel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Wheel>), connection);
            }
        }
    }

    /// <summary>
    /// A propellant for an engine. Obtains by calling <see cref="M:SpaceCenter.Engine.Propellants" />.
    /// </summary>
    public class Propellant : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Propellant (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// The current amount of propellant.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_CurrentAmount")]
        public double CurrentAmount {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_CurrentAmount", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The required amount of propellant.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_CurrentRequirement")]
        public double CurrentRequirement {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_CurrentRequirement", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// If this propellant has a stack gauge or not.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_DrawStackGauge")]
        public bool DrawStackGauge {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_DrawStackGauge", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// If this propellant should be ignored when calculating required mass flow
        /// given specific impulse.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_IgnoreForIsp")]
        public bool IgnoreForIsp {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_IgnoreForIsp", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// If this propellant should be ignored for thrust curve calculations.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_IgnoreForThrustCurve")]
        public bool IgnoreForThrustCurve {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_IgnoreForThrustCurve", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// If this propellant is deprived.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_IsDeprived")]
        public bool IsDeprived {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_IsDeprived", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The name of the propellant.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// The propellant ratio.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_Ratio")]
        public float Ratio {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_Ratio", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The total amount of the underlying resource currently reachable given
        /// resource flow rules.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_TotalResourceAvailable")]
        public double TotalResourceAvailable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_TotalResourceAvailable", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The total vehicle capacity for the underlying propellant resource,
        /// restricted by resource flow rules.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Propellant_get_TotalResourceCapacity")]
        public double TotalResourceCapacity {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Propellant))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Propellant_get_TotalResourceCapacity", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }
    }

    /// <summary>
    /// An RCS block or thruster. Obtained by calling <see cref="M:SpaceCenter.Part.RCS" />.
    /// </summary>
    public class RCS : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public RCS (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the RCS thrusters are active.
        /// An RCS thruster is inactive if the RCS action group is disabled
        /// (<see cref="M:SpaceCenter.Control.RCS" />), the RCS thruster itself is not enabled
        /// (<see cref="M:SpaceCenter.RCS.Enabled" />) or it is covered by a fairing (<see cref="M:SpaceCenter.Part.Shielded" />).
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Active")]
        public bool Active {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Active", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The available force, in Newtons, that can be produced by this RCS,
        /// in the positive and negative x, y and z axes of the vessel. These axes
        /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
        /// Returns zero if RCS is disabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_AvailableForce")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableForce {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_AvailableForce", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// The amount of thrust, in Newtons, that would be produced by the thruster when activated.
        /// Returns zero if the thruster does not have any fuel.
        /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.ThrustLimit" /> and atmospheric conditions
        /// into account.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_AvailableThrust")]
        public float AvailableThrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_AvailableThrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The available torque, in Newton meters, that can be produced by this RCS,
        /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
        /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
        /// Returns zero if RCS is disable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_AvailableTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_AvailableTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// Whether the RCS thrusters are enabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Enabled")]
        public bool Enabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Enabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RCS_set_Enabled", _args);
            }
        }

        /// <summary>
        /// Whether the RCS thruster will fire when pitch control input is given.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_ForwardEnabled")]
        public bool ForwardEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_ForwardEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RCS_set_ForwardEnabled", _args);
            }
        }

        /// <summary>
        /// Whether the RCS has fuel available.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_HasFuel")]
        public bool HasFuel {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_HasFuel", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The specific impulse of the RCS at sea level on Kerbin, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse")]
        public float KerbinSeaLevelSpecificImpulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The maximum amount of thrust that can be produced by the RCS thrusters when active,
        /// in Newtons.
        /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.ThrustLimit" /> and atmospheric conditions
        /// into account.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_MaxThrust")]
        public float MaxThrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_MaxThrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The maximum amount of thrust that can be produced by the RCS thrusters when active
        /// in a vacuum, in Newtons.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_MaxVacuumThrust")]
        public float MaxVacuumThrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_MaxVacuumThrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The part object for this RCS.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Whether the RCS thruster will fire when pitch control input is given.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_PitchEnabled")]
        public bool PitchEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_PitchEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RCS_set_PitchEnabled", _args);
            }
        }

        /// <summary>
        /// The ratios of resources that the RCS consumes. A dictionary mapping resource names
        /// to the ratios at which they are consumed by the RCS.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_PropellantRatios")]
        public global::System.Collections.Generic.IDictionary<string,float> PropellantRatios {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_PropellantRatios", _args);
                return (global::System.Collections.Generic.IDictionary<string,float>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,float>), connection);
            }
        }

        /// <summary>
        /// The names of resources that the RCS consumes.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Propellants")]
        public global::System.Collections.Generic.IList<string> Propellants {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Propellants", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// Whether the RCS thruster will fire when roll control input is given.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_RightEnabled")]
        public bool RightEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_RightEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RCS_set_RightEnabled", _args);
            }
        }

        /// <summary>
        /// Whether the RCS thruster will fire when roll control input is given.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_RollEnabled")]
        public bool RollEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_RollEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RCS_set_RollEnabled", _args);
            }
        }

        /// <summary>
        /// The current specific impulse of the RCS, in seconds. Returns zero
        /// if the RCS is not active.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_SpecificImpulse")]
        public float SpecificImpulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_SpecificImpulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The thrust limiter of the thruster. A value between 0 and 1.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_ThrustLimit")]
        public float ThrustLimit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_ThrustLimit", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RCS_set_ThrustLimit", _args);
            }
        }

        /// <summary>
        /// A list of thrusters, one of each nozzel in the RCS part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_Thrusters")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Thruster> Thrusters {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_Thrusters", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Thruster>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Thruster>), connection);
            }
        }

        /// <summary>
        /// Whether the RCS thruster will fire when yaw control input is given.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_UpEnabled")]
        public bool UpEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_UpEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RCS_set_UpEnabled", _args);
            }
        }

        /// <summary>
        /// The vacuum specific impulse of the RCS, in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_VacuumSpecificImpulse")]
        public float VacuumSpecificImpulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_VacuumSpecificImpulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the RCS thruster will fire when yaw control input is given.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RCS_get_YawEnabled")]
        public bool YawEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RCS_get_YawEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RCS)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RCS_set_YawEnabled", _args);
            }
        }
    }

    /// <summary>
    /// A radiator. Obtained by calling <see cref="M:SpaceCenter.Part.Radiator" />.
    /// </summary>
    public class Radiator : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Radiator (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the radiator is deployable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Radiator_get_Deployable")]
        public bool Deployable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Radiator))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Radiator_get_Deployable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// For a deployable radiator, <c>true</c> if the radiator is extended.
        /// If the radiator is not deployable, this is always <c>true</c>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Radiator_get_Deployed")]
        public bool Deployed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Radiator))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Radiator_get_Deployed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Radiator)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Radiator_set_Deployed", _args);
            }
        }

        /// <summary>
        /// The part object for this radiator.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Radiator_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Radiator))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Radiator_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The current state of the radiator.
        /// </summary>
        /// <remarks>
        /// A fixed radiator is always <see cref="M:SpaceCenter.RadiatorState.Extended" />.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Radiator_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.RadiatorState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Radiator))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Radiator_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.RadiatorState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.RadiatorState), connection);
            }
        }
    }

    /// <summary>
    /// A reaction wheel. Obtained by calling <see cref="M:SpaceCenter.Part.ReactionWheel" />.
    /// </summary>
    public class ReactionWheel : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ReactionWheel (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the reaction wheel is active.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_Active")]
        public bool Active {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ReactionWheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_Active", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ReactionWheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "ReactionWheel_set_Active", _args);
            }
        }

        /// <summary>
        /// The available torque, in Newton meters, that can be produced by this reaction wheel,
        /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
        /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
        /// Returns zero if the reaction wheel is inactive or broken.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_AvailableTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ReactionWheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_AvailableTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// Whether the reaction wheel is broken.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_Broken")]
        public bool Broken {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ReactionWheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_Broken", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The maximum torque, in Newton meters, that can be produced by this reaction wheel,
        /// when it is active, in the positive and negative pitch, roll and yaw axes of the vessel.
        /// These axes correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_MaxTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> MaxTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ReactionWheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_MaxTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// The part object for this reaction wheel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReactionWheel_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ReactionWheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ReactionWheel_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }
    }

    /// <summary>
    /// Represents a reference frame for positions, rotations and
    /// velocities. Contains:
    /// <list type="bullet"><item><description>The position of the origin.</description></item><item><description>The directions of the x, y and z axes.</description></item><item><description>The linear velocity of the frame.</description></item><item><description>The angular velocity of the frame.</description></item></list></summary>
    /// <remarks>
    /// This class does not contain any properties or methods. It is only
    /// used as a parameter to other functions.
    /// </remarks>
    public class ReferenceFrame : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ReferenceFrame (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Create a hybrid reference frame. This is a custom reference frame
        /// whose components inherited from other reference frames.
        /// </summary>
        /// <param name="position">The reference frame providing the position of the origin.</param>
        /// <param name="rotation">The reference frame providing the rotation of the frame.</param>
        /// <param name="velocity">The reference frame providing the linear velocity of the frame.
        /// </param>
        /// <param name="angularVelocity">The reference frame providing the angular velocity
        /// of the frame.</param>
        /// <remarks>
        /// The <paramref name="position" /> reference frame is required but all other
        /// reference frames are optional. If omitted, they are set to the
        /// <paramref name="position" /> reference frame.
        /// </remarks>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReferenceFrame_static_CreateHybrid")]
        public static global::KRPC.Client.Services.SpaceCenter.ReferenceFrame CreateHybrid (IConnection connection, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame position, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame rotation = null, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame velocity = null, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame angularVelocity = null)
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (position, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)),
                global::KRPC.Client.Encoder.Encode (rotation, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)),
                global::KRPC.Client.Encoder.Encode (velocity, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)),
                global::KRPC.Client.Encoder.Encode (angularVelocity, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ReferenceFrame_static_CreateHybrid", _args);
            return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
        }

        /// <summary>
        /// Create a relative reference frame. This is a custom reference frame
        /// whose components offset the components of a parent reference frame.
        /// </summary>
        /// <param name="referenceFrame">The parent reference frame on which to
        /// base this reference frame.</param>
        /// <param name="position">The offset of the position of the origin,
        /// as a position vector. Defaults to <math>(0, 0, 0)</math></param>
        /// <param name="rotation">The rotation to apply to the parent frames rotation,
        /// as a quaternion of the form <math>(x, y, z, w)</math>.
        /// Defaults to <math>(0, 0, 0, 1)</math> (i.e. no rotation)</param>
        /// <param name="velocity">The linear velocity to offset the parent frame by,
        /// as a vector pointing in the direction of travel, whose magnitude is the speed in
        /// meters per second. Defaults to <math>(0, 0, 0)</math>.</param>
        /// <param name="angularVelocity">The angular velocity to offset the parent frame by,
        /// as a vector. This vector points in the direction of the axis of rotation,
        /// and its magnitude is the speed of the rotation in radians per second.
        /// Defaults to <math>(0, 0, 0)</math>.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReferenceFrame_static_CreateRelative")]
        public static global::KRPC.Client.Services.SpaceCenter.ReferenceFrame CreateRelative (IConnection connection, global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame, systemAlias::Tuple<double,double,double> position = null, systemAlias::Tuple<double,double,double,double> rotation = null, systemAlias::Tuple<double,double,double> velocity = null, systemAlias::Tuple<double,double,double> angularVelocity = null)
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)),
                global::KRPC.Client.Encoder.Encode (position ?? new systemAlias::Tuple<double,double,double> (0.0, 0.0, 0.0), typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (rotation ?? new systemAlias::Tuple<double,double,double,double> (0.0, 0.0, 0.0, 1.0), typeof(systemAlias::Tuple<double,double,double,double>)),
                global::KRPC.Client.Encoder.Encode (velocity ?? new systemAlias::Tuple<double,double,double> (0.0, 0.0, 0.0), typeof(systemAlias::Tuple<double,double,double>)),
                global::KRPC.Client.Encoder.Encode (angularVelocity ?? new systemAlias::Tuple<double,double,double> (0.0, 0.0, 0.0), typeof(systemAlias::Tuple<double,double,double>))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ReferenceFrame_static_CreateRelative", _args);
            return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// An individual resource stored within a part.
    /// Created using methods in the <see cref="T:SpaceCenter.Resources" /> class.
    /// </summary>
    public class Resource : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Resource (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// The amount of the resource that is currently stored in the part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resource_get_Amount")]
        public float Amount {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resource))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Amount", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The density of the resource, in <math>kg/l</math>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resource_get_Density")]
        public float Density {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resource))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Density", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether use of this resource is enabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resource_get_Enabled")]
        public bool Enabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resource))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Enabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resource)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Resource_set_Enabled", _args);
            }
        }

        /// <summary>
        /// The flow mode of the resource.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resource_get_FlowMode")]
        public global::KRPC.Client.Services.SpaceCenter.ResourceFlowMode FlowMode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resource))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_FlowMode", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ResourceFlowMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ResourceFlowMode), connection);
            }
        }

        /// <summary>
        /// The total amount of the resource that can be stored in the part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resource_get_Max")]
        public float Max {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resource))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Max", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The name of the resource.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resource_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resource))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// The part containing the resource.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resource_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resource))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resource_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }
    }

    /// <summary>
    /// A resource converter. Obtained by calling <see cref="M:SpaceCenter.Part.ResourceConverter" />.
    /// </summary>
    public class ResourceConverter : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ResourceConverter (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// True if the specified converter is active.
        /// </summary>
        /// <param name="index">Index of the converter.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_Active")]
        public bool Active (int index)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter)),
                global::KRPC.Client.Encoder.Encode (index, typeof(int))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_Active", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// List of the names of resources consumed by the specified converter.
        /// </summary>
        /// <param name="index">Index of the converter.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_Inputs")]
        public global::System.Collections.Generic.IList<string> Inputs (int index)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter)),
                global::KRPC.Client.Encoder.Encode (index, typeof(int))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_Inputs", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }

        /// <summary>
        /// The name of the specified converter.
        /// </summary>
        /// <param name="index">Index of the converter.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_Name")]
        public string Name (int index)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter)),
                global::KRPC.Client.Encoder.Encode (index, typeof(int))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }

        /// <summary>
        /// List of the names of resources produced by the specified converter.
        /// </summary>
        /// <param name="index">Index of the converter.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_Outputs")]
        public global::System.Collections.Generic.IList<string> Outputs (int index)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter)),
                global::KRPC.Client.Encoder.Encode (index, typeof(int))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_Outputs", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }

        /// <summary>
        /// Start the specified converter.
        /// </summary>
        /// <param name="index">Index of the converter.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_Start")]
        public void Start (int index)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter)),
                global::KRPC.Client.Encoder.Encode (index, typeof(int))
            };
            connection.Invoke ("SpaceCenter", "ResourceConverter_Start", _args);
        }

        /// <summary>
        /// The state of the specified converter.
        /// </summary>
        /// <param name="index">Index of the converter.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_State")]
        public global::KRPC.Client.Services.SpaceCenter.ResourceConverterState State (int index)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter)),
                global::KRPC.Client.Encoder.Encode (index, typeof(int))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_State", _args);
            return (global::KRPC.Client.Services.SpaceCenter.ResourceConverterState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ResourceConverterState), connection);
        }

        /// <summary>
        /// Status information for the specified converter.
        /// This is the full status message shown in the in-game UI.
        /// </summary>
        /// <param name="index">Index of the converter.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_StatusInfo")]
        public string StatusInfo (int index)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter)),
                global::KRPC.Client.Encoder.Encode (index, typeof(int))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_StatusInfo", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }

        /// <summary>
        /// Stop the specified converter.
        /// </summary>
        /// <param name="index">Index of the converter.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_Stop")]
        public void Stop (int index)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter)),
                global::KRPC.Client.Encoder.Encode (index, typeof(int))
            };
            connection.Invoke ("SpaceCenter", "ResourceConverter_Stop", _args);
        }

        /// <summary>
        /// The core temperature of the converter, in Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_get_CoreTemperature")]
        public float CoreTemperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_CoreTemperature", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The number of converters in the part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_get_Count")]
        public int Count {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_Count", _args);
                return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
            }
        }

        /// <summary>
        /// The core temperature at which the converter will operate with peak efficiency, in Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature")]
        public float OptimumCoreTemperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_OptimumCoreTemperature", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The part object for this converter.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The thermal efficiency of the converter, as a percentage of its maximum.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceConverter_get_ThermalEfficiency")]
        public float ThermalEfficiency {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceConverter))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceConverter_get_ThermalEfficiency", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }
    }

    /// <summary>
    /// A resource drain. Obtained by calling <see cref="M:SpaceCenter.Part.ResourceDrain" />.
    /// </summary>
    public class ResourceDrain : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ResourceDrain (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the provided resource is enabled for draining.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_CheckResource")]
        public bool CheckResource (global::KRPC.Client.Services.SpaceCenter.Resource resource)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain)),
                global::KRPC.Client.Encoder.Encode (resource, typeof(global::KRPC.Client.Services.SpaceCenter.Resource))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_CheckResource", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// Whether the given resource should be drained.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_SetResource")]
        public void SetResource (global::KRPC.Client.Services.SpaceCenter.Resource resource, bool enabled)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain)),
                global::KRPC.Client.Encoder.Encode (resource, typeof(global::KRPC.Client.Services.SpaceCenter.Resource)),
                global::KRPC.Client.Encoder.Encode (enabled, typeof(bool))
            };
            connection.Invoke ("SpaceCenter", "ResourceDrain_SetResource", _args);
        }

        /// <summary>
        /// Activates resource draining for all enabled parts.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_Start")]
        public void Start ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain))
            };
            connection.Invoke ("SpaceCenter", "ResourceDrain_Start", _args);
        }

        /// <summary>
        /// Turns off resource draining.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_Stop")]
        public void Stop ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain))
            };
            connection.Invoke ("SpaceCenter", "ResourceDrain_Stop", _args);
        }

        /// <summary>
        /// List of available resources.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_AvailableResources")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Resource> AvailableResources {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_AvailableResources", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Resource>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Resource>), connection);
            }
        }

        /// <summary>
        /// The drain mode.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_DrainMode")]
        public global::KRPC.Client.Services.SpaceCenter.DrainMode DrainMode {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_DrainMode", _args);
                return (global::KRPC.Client.Services.SpaceCenter.DrainMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.DrainMode), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.DrainMode))
                };
                connection.Invoke ("SpaceCenter", "ResourceDrain_set_DrainMode", _args);
            }
        }

        /// <summary>
        /// Maximum possible drain rate.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_MaxRate")]
        public float MaxRate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_MaxRate", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Minimum possible drain rate
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_MinRate")]
        public float MinRate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_MinRate", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The part object for this resource drain.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Current drain rate.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceDrain_get_Rate")]
        public float Rate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceDrain_get_Rate", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceDrain)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "ResourceDrain_set_Rate", _args);
            }
        }
    }

    /// <summary>
    /// A resource harvester (drill). Obtained by calling <see cref="M:SpaceCenter.Part.ResourceHarvester" />.
    /// </summary>
    public class ResourceHarvester : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ResourceHarvester (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the harvester is actively drilling.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_Active")]
        public bool Active {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_Active", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "ResourceHarvester_set_Active", _args);
            }
        }

        /// <summary>
        /// The core temperature of the drill, in Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_CoreTemperature")]
        public float CoreTemperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_CoreTemperature", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the harvester is deployed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_Deployed")]
        public bool Deployed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_Deployed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "ResourceHarvester_set_Deployed", _args);
            }
        }

        /// <summary>
        /// The rate at which the drill is extracting ore, in units per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_ExtractionRate")]
        public float ExtractionRate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_ExtractionRate", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The core temperature at which the drill will operate with peak efficiency, in Kelvin.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature")]
        public float OptimumCoreTemperature {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_OptimumCoreTemperature", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The part object for this harvester.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The state of the harvester.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.ResourceHarvesterState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ResourceHarvesterState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ResourceHarvesterState), connection);
            }
        }

        /// <summary>
        /// The thermal efficiency of the drill, as a percentage of its maximum.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency")]
        public float ThermalEfficiency {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceHarvester))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceHarvester_get_ThermalEfficiency", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }
    }

    /// <summary>
    /// Transfer resources between parts.
    /// </summary>
    public class ResourceTransfer : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ResourceTransfer (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Start transferring a resource transfer between a pair of parts. The transfer will move
        /// at most <paramref name="maxAmount" /> units of the resource, depending on how much of
        /// the resource is available in the source part and how much storage is available in the
        /// destination part.
        /// Use <see cref="M:SpaceCenter.ResourceTransfer.Complete" /> to check if the transfer is complete.
        /// Use <see cref="M:SpaceCenter.ResourceTransfer.Amount" /> to see how much of the resource has been transferred.
        /// </summary>
        /// <param name="fromPart">The part to transfer to.</param>
        /// <param name="toPart">The part to transfer from.</param>
        /// <param name="resource">The name of the resource to transfer.</param>
        /// <param name="maxAmount">The maximum amount of resource to transfer.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceTransfer_static_Start")]
        public static global::KRPC.Client.Services.SpaceCenter.ResourceTransfer Start (IConnection connection, global::KRPC.Client.Services.SpaceCenter.Part fromPart, global::KRPC.Client.Services.SpaceCenter.Part toPart, string resource, float maxAmount)
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (fromPart, typeof(global::KRPC.Client.Services.SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (toPart, typeof(global::KRPC.Client.Services.SpaceCenter.Part)),
                global::KRPC.Client.Encoder.Encode (resource, typeof(string)),
                global::KRPC.Client.Encoder.Encode (maxAmount, typeof(float))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceTransfer_static_Start", _args);
            return (global::KRPC.Client.Services.SpaceCenter.ResourceTransfer)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ResourceTransfer), connection);
        }

        /// <summary>
        /// The amount of the resource that has been transferred.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceTransfer_get_Amount")]
        public float Amount {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceTransfer))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceTransfer_get_Amount", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the transfer has completed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ResourceTransfer_get_Complete")]
        public bool Complete {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ResourceTransfer))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ResourceTransfer_get_Complete", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }
    }

    /// <summary>
    /// Represents the collection of resources stored in a vessel, stage or part.
    /// Created by calling <see cref="M:SpaceCenter.Vessel.Resources" />,
    /// <see cref="M:SpaceCenter.Vessel.ResourcesInDecoupleStage" /> or
    /// <see cref="M:SpaceCenter.Part.Resources" />.
    /// </summary>
    public class Resources : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Resources (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Returns the amount of a resource that is currently stored.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_Amount")]
        public float Amount (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resources)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resources_Amount", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }

        /// <summary>
        /// Check whether the named resource can be stored.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_HasResource")]
        public bool HasResource (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resources)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resources_HasResource", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// Returns the amount of a resource that can be stored.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_Max")]
        public float Max (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resources)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resources_Max", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }

        /// <summary>
        /// All the individual resources with the given name that can be stored.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_WithResource")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Resource> WithResource (string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resources)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resources_WithResource", _args);
            return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Resource>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Resource>), connection);
        }

        /// <summary>
        /// Returns the density of a resource, in <math>kg/l</math>.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_static_Density")]
        public static float Density (IConnection connection, string name)
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resources_static_Density", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }

        /// <summary>
        /// Returns the flow mode of a resource.
        /// </summary>
        /// <param name="name">The name of the resource.</param>
        /// <param name="connection">A connection object.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_static_FlowMode")]
        public static global::KRPC.Client.Services.SpaceCenter.ResourceFlowMode FlowMode (IConnection connection, string name)
        {
            if (connection == null)
                throw new ArgumentNullException (nameof (connection));
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Resources_static_FlowMode", _args);
            return (global::KRPC.Client.Services.SpaceCenter.ResourceFlowMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ResourceFlowMode), connection);
        }

        /// <summary>
        /// All the individual resources that can be stored.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_get_All")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Resource> All {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resources))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resources_get_All", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Resource>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Resource>), connection);
            }
        }

        /// <summary>
        /// Whether use of all the resources are enabled.
        /// </summary>
        /// <remarks>
        /// This is <c>true</c> if all of the resources are enabled.
        /// If any of the resources are not enabled, this is <c>false</c>.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_get_Enabled")]
        public bool Enabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resources))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resources_get_Enabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resources)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Resources_set_Enabled", _args);
            }
        }

        /// <summary>
        /// A list of resource names that can be stored.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Resources_get_Names")]
        public global::System.Collections.Generic.IList<string> Names {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Resources))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Resources_get_Names", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }
    }

    /// <summary>
    /// A robotic controller. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticController" />.
    /// </summary>
    public class RoboticController : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public RoboticController (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Add an axis to the controller.
        /// </summary>
        /// <returns>Returns <c>true</c> if the axis is added successfully.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticController_AddAxis")]
        public bool AddAxis (global::KRPC.Client.Services.SpaceCenter.Module module, string fieldName)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticController)),
                global::KRPC.Client.Encoder.Encode (module, typeof(global::KRPC.Client.Services.SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (fieldName, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_AddAxis", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// Add key frame value for controller axis.
        /// </summary>
        /// <returns>Returns <c>true</c> if the key frame is added successfully.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticController_AddKeyFrame")]
        public bool AddKeyFrame (global::KRPC.Client.Services.SpaceCenter.Module module, string fieldName, float time, float value)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticController)),
                global::KRPC.Client.Encoder.Encode (module, typeof(global::KRPC.Client.Services.SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (fieldName, typeof(string)),
                global::KRPC.Client.Encoder.Encode (time, typeof(float)),
                global::KRPC.Client.Encoder.Encode (value, typeof(float))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_AddKeyFrame", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// The axes for the controller.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticController_Axes")]
        public global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<string>> Axes ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticController))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_Axes", _args);
            return (global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<string>>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<string>>), connection);
        }

        /// <summary>
        /// Clear axis.
        /// </summary>
        /// <returns>Returns <c>true</c> if the axis is cleared successfully.</returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticController_ClearAxis")]
        public bool ClearAxis (global::KRPC.Client.Services.SpaceCenter.Module module, string fieldName)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticController)),
                global::KRPC.Client.Encoder.Encode (module, typeof(global::KRPC.Client.Services.SpaceCenter.Module)),
                global::KRPC.Client.Encoder.Encode (fieldName, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_ClearAxis", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// Whether the controller has a part.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticController_HasPart")]
        public bool HasPart (global::KRPC.Client.Services.SpaceCenter.Part part)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticController)),
                global::KRPC.Client.Encoder.Encode (part, typeof(global::KRPC.Client.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_HasPart", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }

        /// <summary>
        /// The part object for this controller.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticController_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticController))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }
    }

    /// <summary>
    /// A robotic hinge. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticHinge" />.
    /// </summary>
    public class RoboticHinge : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public RoboticHinge (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Move hinge to it's built position.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticHinge_MoveHome")]
        public void MoveHome ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge))
            };
            connection.Invoke ("SpaceCenter", "RoboticHinge_MoveHome", _args);
        }

        /// <summary>
        /// Current angle.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticHinge_get_CurrentAngle")]
        public float CurrentAngle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticHinge_get_CurrentAngle", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Damping percentage.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticHinge_get_Damping")]
        public float Damping {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticHinge_get_Damping", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticHinge_set_Damping", _args);
            }
        }

        /// <summary>
        /// Lock movement.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticHinge_get_Locked")]
        public bool Locked {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticHinge_get_Locked", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RoboticHinge_set_Locked", _args);
            }
        }

        /// <summary>
        /// Whether the motor is engaged.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticHinge_get_MotorEngaged")]
        public bool MotorEngaged {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticHinge_get_MotorEngaged", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RoboticHinge_set_MotorEngaged", _args);
            }
        }

        /// <summary>
        /// The part object for this robotic hinge.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticHinge_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticHinge_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Target movement rate in degrees per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticHinge_get_Rate")]
        public float Rate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticHinge_get_Rate", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticHinge_set_Rate", _args);
            }
        }

        /// <summary>
        /// Target angle.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticHinge_get_TargetAngle")]
        public float TargetAngle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticHinge_get_TargetAngle", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticHinge)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticHinge_set_TargetAngle", _args);
            }
        }
    }

    /// <summary>
    /// A robotic piston part. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticPiston" />.
    /// </summary>
    public class RoboticPiston : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public RoboticPiston (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Move piston to it's built position.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_MoveHome")]
        public void MoveHome ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston))
            };
            connection.Invoke ("SpaceCenter", "RoboticPiston_MoveHome", _args);
        }

        /// <summary>
        /// Current extension of the piston.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_CurrentExtension")]
        public float CurrentExtension {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_CurrentExtension", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Damping percentage.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_Damping")]
        public float Damping {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_Damping", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticPiston_set_Damping", _args);
            }
        }

        /// <summary>
        /// Lock movement.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_Locked")]
        public bool Locked {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_Locked", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RoboticPiston_set_Locked", _args);
            }
        }

        /// <summary>
        /// Whether the motor is engaged.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_MotorEngaged")]
        public bool MotorEngaged {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_MotorEngaged", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RoboticPiston_set_MotorEngaged", _args);
            }
        }

        /// <summary>
        /// The part object for this robotic piston.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Target movement rate in degrees per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_Rate")]
        public float Rate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_Rate", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticPiston_set_Rate", _args);
            }
        }

        /// <summary>
        /// Target extension of the piston.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticPiston_get_TargetExtension")]
        public float TargetExtension {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticPiston_get_TargetExtension", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticPiston)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticPiston_set_TargetExtension", _args);
            }
        }
    }

    /// <summary>
    /// A robotic rotation servo. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticRotation" />.
    /// </summary>
    public class RoboticRotation : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public RoboticRotation (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Move rotation servo to it's built position.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotation_MoveHome")]
        public void MoveHome ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation))
            };
            connection.Invoke ("SpaceCenter", "RoboticRotation_MoveHome", _args);
        }

        /// <summary>
        /// Current angle.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotation_get_CurrentAngle")]
        public float CurrentAngle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_CurrentAngle", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Damping percentage.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotation_get_Damping")]
        public float Damping {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_Damping", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotation_set_Damping", _args);
            }
        }

        /// <summary>
        /// Lock Movement
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotation_get_Locked")]
        public bool Locked {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_Locked", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotation_set_Locked", _args);
            }
        }

        /// <summary>
        /// Whether the motor is engaged.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotation_get_MotorEngaged")]
        public bool MotorEngaged {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_MotorEngaged", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotation_set_MotorEngaged", _args);
            }
        }

        /// <summary>
        /// The part object for this robotic rotation servo.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotation_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Target movement rate in degrees per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotation_get_Rate")]
        public float Rate {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_Rate", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotation_set_Rate", _args);
            }
        }

        /// <summary>
        /// Target angle.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotation_get_TargetAngle")]
        public float TargetAngle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotation_get_TargetAngle", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotation)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotation_set_TargetAngle", _args);
            }
        }
    }

    /// <summary>
    /// A robotic rotor. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticRotor" />.
    /// </summary>
    public class RoboticRotor : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public RoboticRotor (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Current RPM.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_CurrentRPM")]
        public float CurrentRPM {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_CurrentRPM", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the rotor direction is inverted.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_Inverted")]
        public bool Inverted {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_Inverted", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotor_set_Inverted", _args);
            }
        }

        /// <summary>
        /// Lock movement.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_Locked")]
        public bool Locked {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_Locked", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotor_set_Locked", _args);
            }
        }

        /// <summary>
        /// Whether the motor is engaged.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_MotorEngaged")]
        public bool MotorEngaged {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_MotorEngaged", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotor_set_MotorEngaged", _args);
            }
        }

        /// <summary>
        /// The part object for this robotic rotor.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Target RPM.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_TargetRPM")]
        public float TargetRPM {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_TargetRPM", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotor_set_TargetRPM", _args);
            }
        }

        /// <summary>
        /// Torque limit percentage.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "RoboticRotor_get_TorqueLimit")]
        public float TorqueLimit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "RoboticRotor_get_TorqueLimit", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.RoboticRotor)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "RoboticRotor_set_TorqueLimit", _args);
            }
        }
    }

    /// <summary>
    /// Obtained by calling <see cref="M:SpaceCenter.Experiment.Data" />.
    /// </summary>
    public class ScienceData : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ScienceData (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Data amount.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceData_get_DataAmount")]
        public float DataAmount {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceData))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceData_get_DataAmount", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Science value.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceData_get_ScienceValue")]
        public float ScienceValue {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceData))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceData_get_ScienceValue", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Transmit value.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceData_get_TransmitValue")]
        public float TransmitValue {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceData))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceData_get_TransmitValue", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }
    }

    /// <summary>
    /// Obtained by calling <see cref="M:SpaceCenter.Experiment.ScienceSubject" />.
    /// </summary>
    public class ScienceSubject : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public ScienceSubject (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Multiply science value by this to determine data amount in mits.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_DataScale")]
        public float DataScale {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceSubject))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_DataScale", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the experiment has been completed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_IsComplete")]
        public bool IsComplete {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceSubject))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_IsComplete", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Amount of science already earned from this subject, not updated until after
        /// transmission/recovery.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_Science")]
        public float Science {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceSubject))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_Science", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Total science allowable for this subject.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_ScienceCap")]
        public float ScienceCap {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceSubject))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_ScienceCap", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Diminishing value multiplier for decreasing the science value returned from repeated
        /// experiments.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_ScientificValue")]
        public float ScientificValue {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceSubject))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_ScientificValue", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Multiplier for specific Celestial Body/Experiment Situation combination.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_SubjectValue")]
        public float SubjectValue {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceSubject))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_SubjectValue", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Title of science subject, displayed in science archives
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ScienceSubject_get_Title")]
        public string Title {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.ScienceSubject))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "ScienceSubject_get_Title", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }
    }

    /// <summary>
    /// A sensor, such as a thermometer. Obtained by calling <see cref="M:SpaceCenter.Part.Sensor" />.
    /// </summary>
    public class Sensor : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Sensor (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the sensor is active.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Sensor_get_Active")]
        public bool Active {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Sensor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Sensor_get_Active", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Sensor)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Sensor_set_Active", _args);
            }
        }

        /// <summary>
        /// The part object for this sensor.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Sensor_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Sensor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Sensor_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The current value of the sensor.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Sensor_get_Value")]
        public string Value {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Sensor))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Sensor_get_Value", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }
    }

    /// <summary>
    /// A solar panel. Obtained by calling <see cref="M:SpaceCenter.Part.SolarPanel" />.
    /// </summary>
    public class SolarPanel : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public SolarPanel (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether the solar panel is deployable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "SolarPanel_get_Deployable")]
        public bool Deployable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.SolarPanel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "SolarPanel_get_Deployable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the solar panel is extended.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "SolarPanel_get_Deployed")]
        public bool Deployed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.SolarPanel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "SolarPanel_get_Deployed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.SolarPanel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "SolarPanel_set_Deployed", _args);
            }
        }

        /// <summary>
        /// The current amount of energy being generated by the solar panel, in
        /// units of charge per second.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "SolarPanel_get_EnergyFlow")]
        public float EnergyFlow {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.SolarPanel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "SolarPanel_get_EnergyFlow", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The part object for this solar panel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "SolarPanel_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.SolarPanel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "SolarPanel_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// The current state of the solar panel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "SolarPanel_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.SolarPanelState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.SolarPanel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "SolarPanel_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.SolarPanelState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.SolarPanelState), connection);
            }
        }

        /// <summary>
        /// The current amount of sunlight that is incident on the solar panel,
        /// as a percentage. A value between 0 and 1.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "SolarPanel_get_SunExposure")]
        public float SunExposure {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.SolarPanel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "SolarPanel_get_SunExposure", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }
    }

    /// <summary>
    /// The component of an <see cref="T:SpaceCenter.Engine" /> or <see cref="T:SpaceCenter.RCS" /> part that generates thrust.
    /// Can obtained by calling <see cref="M:SpaceCenter.Engine.Thrusters" /> or <see cref="M:SpaceCenter.RCS.Thrusters" />.
    /// </summary>
    /// <remarks>
    /// Engines can consist of multiple thrusters.
    /// For example, the S3 KS-25x4 "Mammoth" has four rocket nozzels, and so consists of
    /// four thrusters.
    /// </remarks>
    public class Thruster : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Thruster (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Position around which the gimbal pivots.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Thruster_GimbalPosition")]
        public systemAlias::Tuple<double,double,double> GimbalPosition (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Thruster)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Thruster_GimbalPosition", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The direction of the force generated by the thruster, when the engine is in its
        /// initial position (no gimballing), in the given reference frame.
        /// This is opposite to the direction in which the thruster expels propellant.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// direction is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Thruster_InitialThrustDirection")]
        public systemAlias::Tuple<double,double,double> InitialThrustDirection (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Thruster)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Thruster_InitialThrustDirection", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The position at which the thruster generates thrust, when the engine is in its
        /// initial position (no gimballing), in the given reference frame.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        /// <remarks>
        /// This position can move when the gimbal rotates. This is because the thrust position and
        /// gimbal position are not necessarily the same.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Thruster_InitialThrustPosition")]
        public systemAlias::Tuple<double,double,double> InitialThrustPosition (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Thruster)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Thruster_InitialThrustPosition", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The direction of the force generated by the thruster, in the given reference frame.
        /// This is opposite to the direction in which the thruster expels propellant.
        /// For gimballed engines, this takes into account the current rotation of the gimbal.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// direction is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Thruster_ThrustDirection")]
        public systemAlias::Tuple<double,double,double> ThrustDirection (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Thruster)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Thruster_ThrustDirection", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The position at which the thruster generates thrust, in the given reference frame.
        /// For gimballed engines, this takes into account the current rotation of the gimbal.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Thruster_ThrustPosition")]
        public systemAlias::Tuple<double,double,double> ThrustPosition (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Thruster)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Thruster_ThrustPosition", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// The current gimbal angle in the pitch, roll and yaw axes, in degrees.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Thruster_get_GimbalAngle")]
        public systemAlias::Tuple<double,double,double> GimbalAngle {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Thruster))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Thruster_get_GimbalAngle", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// Whether the thruster is gimballed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Thruster_get_Gimballed")]
        public bool Gimballed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Thruster))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Thruster_get_Gimballed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The <see cref="T:SpaceCenter.Part" /> that contains this thruster.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Thruster_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Thruster))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Thruster_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// A reference frame that is fixed relative to the thruster and orientated with
        /// its thrust direction (<see cref="M:SpaceCenter.Thruster.ThrustDirection" />).
        /// For gimballed engines, this takes into account the current rotation of the gimbal.
        /// <list type="bullet"><item><description>
        /// The origin is at the position of thrust for this thruster
        /// (<see cref="M:SpaceCenter.Thruster.ThrustPosition" />).</description></item><item><description>
        /// The axes rotate with the thrust direction.
        /// This is the direction in which the thruster expels propellant, including any gimballing.
        /// </description></item><item><description>The y-axis points along the thrust direction.</description></item><item><description>The x-axis and z-axis are perpendicular to the thrust direction.
        /// </description></item></list></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Thruster_get_ThrustReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame ThrustReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Thruster))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Thruster_get_ThrustReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }
    }

    /// <summary>
    /// These objects are used to interact with vessels in KSP. This includes getting
    /// orbital and flight data, manipulating control inputs and managing resources.
    /// Created using <see cref="M:SpaceCenter.ActiveVessel" /> or <see cref="M:SpaceCenter.Vessels" />.
    /// </summary>
    public class Vessel : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Vessel (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// The angular velocity of the vessel, in the given reference frame.
        /// </summary>
        /// <returns>The angular velocity as a vector. The magnitude of the vector is the rotational
        /// speed of the vessel, in radians per second. The direction of the vector indicates the
        /// axis of rotation, using the right-hand rule.</returns>
        /// <param name="referenceFrame">The reference frame the returned
        /// angular velocity is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_AngularVelocity")]
        public systemAlias::Tuple<double,double,double> AngularVelocity (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_AngularVelocity", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// Gets the total available thrust that can be produced by the vessel's
        /// active engines, in Newtons. This is computed by summing
        /// <see cref="M:SpaceCenter.Engine.AvailableThrustAt" /> for every active engine in the vessel.
        /// Takes the given pressure into account.
        /// </summary>
        /// <param name="pressure">Atmospheric pressure in atmospheres</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_AvailableThrustAt")]
        public float AvailableThrustAt (double pressure)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (pressure, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_AvailableThrustAt", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }

        /// <summary>
        /// The axis-aligned bounding box of the vessel in the given reference frame.
        /// </summary>
        /// <returns>The positions of the minimum and maximum vertices of the box,
        /// as position vectors.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vectors are in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_BoundingBox")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> BoundingBox (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_BoundingBox", _args);
            return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
        }

        /// <summary>
        /// The direction in which the vessel is pointing, in the given reference frame.
        /// </summary>
        /// <returns>The direction as a unit vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// direction is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_Direction")]
        public systemAlias::Tuple<double,double,double> Direction (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_Direction", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// Returns a <see cref="T:SpaceCenter.Flight" /> object that can be used to get flight
        /// telemetry for the vessel, in the specified reference frame.
        /// </summary>
        /// <param name="referenceFrame">
        /// Reference frame. Defaults to the vessel's surface reference frame
        /// (<see cref="M:SpaceCenter.Vessel.SurfaceReferenceFrame" />).
        /// </param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_Flight")]
        public global::KRPC.Client.Services.SpaceCenter.Flight Flight (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame = null)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_Flight", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Flight)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Flight), connection);
        }

        /// <summary>
        /// The total maximum thrust that can be produced by the vessel's active
        /// engines, in Newtons. This is computed by summing
        /// <see cref="M:SpaceCenter.Engine.MaxThrustAt" /> for every active engine.
        /// Takes the given pressure into account.
        /// </summary>
        /// <param name="pressure">Atmospheric pressure in atmospheres</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_MaxThrustAt")]
        public float MaxThrustAt (double pressure)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (pressure, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_MaxThrustAt", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }

        /// <summary>
        /// The position of the center of mass of the vessel, in the given reference frame.
        /// </summary>
        /// <returns>The position as a vector.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// position vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_Position")]
        public systemAlias::Tuple<double,double,double> Position (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_Position", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// Recover the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_Recover")]
        public void Recover ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
            };
            connection.Invoke ("SpaceCenter", "Vessel_Recover", _args);
        }

        /// <summary>
        /// Returns a <see cref="T:SpaceCenter.Resources" /> object, that can used to get
        /// information about resources stored in a given <paramref name="stage" />.
        /// </summary>
        /// <param name="stage">Get resources for parts that are decoupled in this stage.</param>
        /// <param name="cumulative">When <c>false</c>, returns the resources for parts
        /// decoupled in just the given stage. When <c>true</c> returns the resources decoupled in
        /// the given stage and all subsequent stages combined.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_ResourcesInDecoupleStage")]
        public global::KRPC.Client.Services.SpaceCenter.Resources ResourcesInDecoupleStage (int stage, bool cumulative = true)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (stage, typeof(int)),
                global::KRPC.Client.Encoder.Encode (cumulative, typeof(bool))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_ResourcesInDecoupleStage", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Resources)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Resources), connection);
        }

        /// <summary>
        /// The rotation of the vessel, in the given reference frame.
        /// </summary>
        /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// rotation is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_Rotation")]
        public systemAlias::Tuple<double,double,double,double> Rotation (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_Rotation", _args);
            return (systemAlias::Tuple<double,double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double,double>), connection);
        }

        /// <summary>
        /// The combined specific impulse of all active engines, in seconds. This is computed using the formula
        /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
        /// Takes the given pressure into account.
        /// </summary>
        /// <param name="pressure">Atmospheric pressure in atmospheres</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_SpecificImpulseAt")]
        public float SpecificImpulseAt (double pressure)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (pressure, typeof(double))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_SpecificImpulseAt", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }

        /// <summary>
        /// The velocity of the center of mass of the vessel, in the given reference frame.
        /// </summary>
        /// <returns>The velocity as a vector. The vector points in the direction of travel,
        /// and its magnitude is the speed of the body in meters per second.</returns>
        /// <param name="referenceFrame">The reference frame that the returned
        /// velocity vector is in.</param>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_Velocity")]
        public systemAlias::Tuple<double,double,double> Velocity (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame referenceFrame)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_Velocity", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }

        /// <summary>
        /// An <see cref="T:SpaceCenter.AutoPilot" /> object, that can be used to perform
        /// simple auto-piloting of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AutoPilot")]
        public global::KRPC.Client.Services.SpaceCenter.AutoPilot AutoPilot {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AutoPilot", _args);
                return (global::KRPC.Client.Services.SpaceCenter.AutoPilot)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.AutoPilot), connection);
            }
        }

        /// <summary>
        /// The maximum torque that the aerodynamic control surfaces can generate.
        /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
        /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AvailableControlSurfaceTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableControlSurfaceTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AvailableControlSurfaceTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// The maximum torque that the currently active and gimballed engines can generate.
        /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
        /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AvailableEngineTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableEngineTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AvailableEngineTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// The maximum torque that parts (excluding reaction wheels, gimballed engines,
        /// RCS and control surfaces) can generate.
        /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
        /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AvailableOtherTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableOtherTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AvailableOtherTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// The maximum force that the currently active RCS thrusters can generate.
        /// Returns the forces in <math>N</math> along each of the coordinate axes of the
        /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// These axes are equivalent to the right, forward and bottom directions of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AvailableRCSForce")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableRCSForce {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AvailableRCSForce", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// The maximum torque that the currently active RCS thrusters can generate.
        /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
        /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AvailableRCSTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableRCSTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AvailableRCSTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// The maximum torque that the currently active and powered reaction wheels can generate.
        /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
        /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AvailableReactionWheelTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableReactionWheelTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AvailableReactionWheelTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// Gets the total available thrust that can be produced by the vessel's
        /// active engines, in Newtons. This is computed by summing
        /// <see cref="M:SpaceCenter.Engine.AvailableThrust" /> for every active engine in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AvailableThrust")]
        public float AvailableThrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AvailableThrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The maximum torque that the vessel generates. Includes contributions from
        /// reaction wheels, RCS, gimballed engines and aerodynamic control surfaces.
        /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
        /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AvailableTorque")]
        public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> AvailableTorque {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AvailableTorque", _args);
                return (systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>>), connection);
            }
        }

        /// <summary>
        /// The name of the biome the vessel is currently in.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Biome")]
        public string Biome {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Biome", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
        }

        /// <summary>
        /// Returns a <see cref="T:SpaceCenter.Comms" /> object that can be used to interact
        /// with CommNet for this vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Comms")]
        public global::KRPC.Client.Services.SpaceCenter.Comms Comms {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Comms", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Comms)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Comms), connection);
            }
        }

        /// <summary>
        /// Returns a <see cref="T:SpaceCenter.Control" /> object that can be used to manipulate
        /// the vessel's control inputs. For example, its pitch/yaw/roll controls,
        /// RCS and thrust.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Control")]
        public global::KRPC.Client.Services.SpaceCenter.Control Control {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Control", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Control)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Control), connection);
            }
        }

        /// <summary>
        /// The crew in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Crew")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CrewMember> Crew {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Crew", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CrewMember>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.CrewMember>), connection);
            }
        }

        /// <summary>
        /// The number of crew that can occupy the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_CrewCapacity")]
        public int CrewCapacity {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_CrewCapacity", _args);
                return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
            }
        }

        /// <summary>
        /// The number of crew that are occupying the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_CrewCount")]
        public int CrewCount {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_CrewCount", _args);
                return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
            }
        }

        /// <summary>
        /// The total mass of the vessel, excluding resources, in kg.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_DryMass")]
        public float DryMass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_DryMass", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The inertia tensor of the vessel around its center of mass,
        /// in the vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// Returns the 3x3 matrix as a list of elements, in row-major order.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_InertiaTensor")]
        public global::System.Collections.Generic.IList<double> InertiaTensor {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_InertiaTensor", _args);
                return (global::System.Collections.Generic.IList<double>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<double>), connection);
            }
        }

        /// <summary>
        /// The combined specific impulse of all active engines at sea level on Kerbin, in seconds.
        /// This is computed using the formula
        /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_KerbinSeaLevelSpecificImpulse")]
        public float KerbinSeaLevelSpecificImpulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_KerbinSeaLevelSpecificImpulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The mission elapsed time in seconds.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_MET")]
        public double MET {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_MET", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
        }

        /// <summary>
        /// The total mass of the vessel, including resources, in kg.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Mass")]
        public float Mass {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Mass", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The total maximum thrust that can be produced by the vessel's active
        /// engines, in Newtons. This is computed by summing
        /// <see cref="M:SpaceCenter.Engine.MaxThrust" /> for every active engine.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_MaxThrust")]
        public float MaxThrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_MaxThrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The total maximum thrust that can be produced by the vessel's active
        /// engines when the vessel is in a vacuum, in Newtons. This is computed by
        /// summing <see cref="M:SpaceCenter.Engine.MaxVacuumThrust" /> for every active engine.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_MaxVacuumThrust")]
        public float MaxVacuumThrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_MaxVacuumThrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The moment of inertia of the vessel around its center of mass in <math>kg.m^2</math>.
        /// The inertia values in the returned 3-tuple are around the
        /// pitch, roll and yaw directions respectively.
        /// This corresponds to the vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_MomentOfInertia")]
        public systemAlias::Tuple<double,double,double> MomentOfInertia {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_MomentOfInertia", _args);
                return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
            }
        }

        /// <summary>
        /// The name of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(string))
                };
                connection.Invoke ("SpaceCenter", "Vessel_set_Name", _args);
            }
        }

        /// <summary>
        /// The current orbit of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Orbit")]
        public global::KRPC.Client.Services.SpaceCenter.Orbit Orbit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Orbit", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Orbit)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Orbit), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to the vessel,
        /// and orientated with the vessels orbital prograde/normal/radial directions.
        /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the orbital prograde/normal/radial directions.</description></item><item><description>The x-axis points in the orbital anti-radial direction.</description></item><item><description>The y-axis points in the orbital prograde direction.</description></item><item><description>The z-axis points in the orbital normal direction.</description></item></list></summary>
        /// <remarks>
        /// Be careful not to confuse this with 'orbit' mode on the navball.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_OrbitalReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame OrbitalReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_OrbitalReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Parts" /> object, that can used to interact with the parts that make up this vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Parts")]
        public global::KRPC.Client.Services.SpaceCenter.Parts Parts {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Parts", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Parts)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Parts), connection);
            }
        }

        /// <summary>
        /// Whether the vessel is recoverable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Recoverable")]
        public bool Recoverable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Recoverable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to the vessel,
        /// and orientated with the vessel.
        /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the vessel.</description></item><item><description>The x-axis points out to the right of the vessel.</description></item><item><description>The y-axis points in the forward direction of the vessel.</description></item><item><description>The z-axis points out of the bottom off the vessel.</description></item></list></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_ReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_ReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// A <see cref="T:SpaceCenter.Resources" /> object, that can used to get information
        /// about resources stored in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Resources")]
        public global::KRPC.Client.Services.SpaceCenter.Resources Resources {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Resources", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Resources)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Resources), connection);
            }
        }

        /// <summary>
        /// The situation the vessel is in.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Situation")]
        public global::KRPC.Client.Services.SpaceCenter.VesselSituation Situation {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Situation", _args);
                return (global::KRPC.Client.Services.SpaceCenter.VesselSituation)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.VesselSituation), connection);
            }
        }

        /// <summary>
        /// The combined specific impulse of all active engines, in seconds. This is computed using the formula
        /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_SpecificImpulse")]
        public float SpecificImpulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_SpecificImpulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to the vessel,
        /// and orientated with the surface of the body being orbited.
        /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the north and up directions on the surface of the body.</description></item><item><description>The x-axis points in the <a href="https://en.wikipedia.org/wiki/Zenith">zenith</a>
        /// direction (upwards, normal to the body being orbited, from the center of the body towards the center of
        /// mass of the vessel).</description></item><item><description>The y-axis points northwards towards the
        /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a> (north, and tangential to the
        /// surface of the body -- the direction in which a compass would point when on the surface).</description></item><item><description>The z-axis points eastwards towards the
        /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a> (east, and tangential to the
        /// surface of the body -- east on a compass when on the surface).</description></item></list></summary>
        /// <remarks>
        /// Be careful not to confuse this with 'surface' mode on the navball.
        /// </remarks>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_SurfaceReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame SurfaceReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_SurfaceReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// The reference frame that is fixed relative to the vessel,
        /// and orientated with the velocity vector of the vessel relative
        /// to the surface of the body being orbited.
        /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the vessel's velocity vector.</description></item><item><description>The y-axis points in the direction of the vessel's velocity vector,
        /// relative to the surface of the body being orbited.</description></item><item><description>The z-axis is in the plane of the
        /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a>.</description></item><item><description>The x-axis is orthogonal to the other two axes.</description></item></list></summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_SurfaceVelocityReferenceFrame")]
        public global::KRPC.Client.Services.SpaceCenter.ReferenceFrame SurfaceVelocityReferenceFrame {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_SurfaceVelocityReferenceFrame", _args);
                return (global::KRPC.Client.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.ReferenceFrame), connection);
            }
        }

        /// <summary>
        /// The total thrust currently being produced by the vessel's engines, in
        /// Newtons. This is computed by summing <see cref="M:SpaceCenter.Engine.Thrust" /> for
        /// every engine in the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Thrust")]
        public float Thrust {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Thrust", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The type of the vessel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Type")]
        public global::KRPC.Client.Services.SpaceCenter.VesselType Type {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Type", _args);
                return (global::KRPC.Client.Services.SpaceCenter.VesselType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.VesselType), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.VesselType))
                };
                connection.Invoke ("SpaceCenter", "Vessel_set_Type", _args);
            }
        }

        /// <summary>
        /// The combined vacuum specific impulse of all active engines, in seconds. This is computed using the formula
        /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_VacuumSpecificImpulse")]
        public float VacuumSpecificImpulse {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Vessel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_VacuumSpecificImpulse", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }
    }

    /// <summary>
    /// Represents a waypoint. Can be created using <see cref="M:SpaceCenter.WaypointManager.AddWaypoint" />.
    /// </summary>
    public class Waypoint : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Waypoint (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Removes the waypoint.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_Remove")]
        public void Remove ()
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
            };
            connection.Invoke ("SpaceCenter", "Waypoint_Remove", _args);
        }

        /// <summary>
        /// The altitude of the waypoint above the surface of the body, in meters.
        /// When over water, this is the altitude above the sea floor.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_BedrockAltitude")]
        public double BedrockAltitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_BedrockAltitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Waypoint_set_BedrockAltitude", _args);
            }
        }

        /// <summary>
        /// The celestial body the waypoint is attached to.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Body")]
        public global::KRPC.Client.Services.SpaceCenter.CelestialBody Body {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Body", _args);
                return (global::KRPC.Client.Services.SpaceCenter.CelestialBody)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody))
                };
                connection.Invoke ("SpaceCenter", "Waypoint_set_Body", _args);
            }
        }

        /// <summary><c>true</c> if this waypoint is part of a set of clustered waypoints with greek letter
        /// names appended (Alpha, Beta, Gamma, etc).
        /// If <c>true</c>, there is a one-to-one correspondence with the greek letter name and
        /// the <see cref="M:SpaceCenter.Waypoint.Index" />.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Clustered")]
        public bool Clustered {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Clustered", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The seed of the icon color. See <see cref="M:SpaceCenter.WaypointManager.Colors" /> for example colors.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Color")]
        public int Color {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Color", _args);
                return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(int))
                };
                connection.Invoke ("SpaceCenter", "Waypoint_set_Color", _args);
            }
        }

        /// <summary>
        /// The associated contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Contract")]
        public global::KRPC.Client.Services.SpaceCenter.Contract Contract {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Contract", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Contract)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Contract), connection);
            }
        }

        /// <summary><c>true</c> if the waypoint is attached to the ground.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Grounded")]
        public bool Grounded {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Grounded", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the waypoint belongs to a contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_HasContract")]
        public bool HasContract {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_HasContract", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The icon of the waypoint.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Icon")]
        public string Icon {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Icon", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(string))
                };
                connection.Invoke ("SpaceCenter", "Waypoint_set_Icon", _args);
            }
        }

        /// <summary>
        /// The integer index of this waypoint within its cluster of sibling waypoints.
        /// In other words, when you have a cluster of waypoints called "Somewhere Alpha",
        /// "Somewhere Beta" and "Somewhere Gamma", the alpha site has index 0, the beta
        /// site has index 1 and the gamma site has index 2.
        /// When <see cref="M:SpaceCenter.Waypoint.Clustered" /> is <c>false</c>, this is zero.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Index")]
        public int Index {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Index", _args);
                return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
            }
        }

        /// <summary>
        /// The latitude of the waypoint.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Latitude")]
        public double Latitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Latitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Waypoint_set_Latitude", _args);
            }
        }

        /// <summary>
        /// The longitude of the waypoint.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Longitude")]
        public double Longitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Longitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Waypoint_set_Longitude", _args);
            }
        }

        /// <summary>
        /// The altitude of the waypoint above sea level, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_MeanAltitude")]
        public double MeanAltitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_MeanAltitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Waypoint_set_MeanAltitude", _args);
            }
        }

        /// <summary>
        /// The name of the waypoint as it appears on the map and the contract.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_Name")]
        public string Name {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_Name", _args);
                return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(string))
                };
                connection.Invoke ("SpaceCenter", "Waypoint_set_Name", _args);
            }
        }

        /// <summary><c>true</c> if the waypoint is near to the surface of a body.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_NearSurface")]
        public bool NearSurface {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_NearSurface", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The altitude of the waypoint above the surface of the body or sea level,
        /// whichever is closer, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Waypoint_get_SurfaceAltitude")]
        public double SurfaceAltitude {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Waypoint_get_SurfaceAltitude", _args);
                return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Waypoint)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(double))
                };
                connection.Invoke ("SpaceCenter", "Waypoint_set_SurfaceAltitude", _args);
            }
        }
    }

    /// <summary>
    /// Waypoints are the location markers you can see on the map view showing you where contracts are targeted for.
    /// With this structure, you can obtain coordinate data for the locations of these waypoints.
    /// Obtained by calling <see cref="M:SpaceCenter.WaypointManager" />.
    /// </summary>
    public class WaypointManager : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public WaypointManager (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Creates a waypoint at the given position at ground level, and returns a
        /// <see cref="T:SpaceCenter.Waypoint" /> object that can be used to modify it.
        /// </summary>
        /// <param name="latitude">Latitude of the waypoint.</param>
        /// <param name="longitude">Longitude of the waypoint.</param>
        /// <param name="body">Celestial body the waypoint is attached to.</param>
        /// <param name="name">Name of the waypoint.</param>
        /// <returns></returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "WaypointManager_AddWaypoint")]
        public global::KRPC.Client.Services.SpaceCenter.Waypoint AddWaypoint (double latitude, double longitude, global::KRPC.Client.Services.SpaceCenter.CelestialBody body, string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.WaypointManager)),
                global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (body, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_AddWaypoint", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Waypoint)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Waypoint), connection);
        }

        /// <summary>
        /// Creates a waypoint at the given position and altitude, and returns a
        /// <see cref="T:SpaceCenter.Waypoint" /> object that can be used to modify it.
        /// </summary>
        /// <param name="latitude">Latitude of the waypoint.</param>
        /// <param name="longitude">Longitude of the waypoint.</param>
        /// <param name="altitude">Altitude (above sea level) of the waypoint.</param>
        /// <param name="body">Celestial body the waypoint is attached to.</param>
        /// <param name="name">Name of the waypoint.</param>
        /// <returns></returns>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "WaypointManager_AddWaypointAtAltitude")]
        public global::KRPC.Client.Services.SpaceCenter.Waypoint AddWaypointAtAltitude (double latitude, double longitude, double altitude, global::KRPC.Client.Services.SpaceCenter.CelestialBody body, string name)
        {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.WaypointManager)),
                global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (altitude, typeof(double)),
                global::KRPC.Client.Encoder.Encode (body, typeof(global::KRPC.Client.Services.SpaceCenter.CelestialBody)),
                global::KRPC.Client.Encoder.Encode (name, typeof(string))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_AddWaypointAtAltitude", _args);
            return (global::KRPC.Client.Services.SpaceCenter.Waypoint)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Waypoint), connection);
        }

        /// <summary>
        /// An example map of known color - seed pairs.
        /// Any other integers may be used as seed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "WaypointManager_get_Colors")]
        public global::System.Collections.Generic.IDictionary<string,int> Colors {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.WaypointManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_get_Colors", _args);
                return (global::System.Collections.Generic.IDictionary<string,int>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,int>), connection);
            }
        }

        /// <summary>
        /// Returns all available icons (from "GameData/Squad/Contracts/Icons/").
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "WaypointManager_get_Icons")]
        public global::System.Collections.Generic.IList<string> Icons {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.WaypointManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_get_Icons", _args);
                return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
            }
        }

        /// <summary>
        /// A list of all existing waypoints.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "WaypointManager_get_Waypoints")]
        public global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Waypoint> Waypoints {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.WaypointManager))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "WaypointManager_get_Waypoints", _args);
                return (global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Waypoint>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::KRPC.Client.Services.SpaceCenter.Waypoint>), connection);
            }
        }
    }

    /// <summary>
    /// A wheel. Includes landing gear and rover wheels.
    /// Obtained by calling <see cref="M:SpaceCenter.Part.Wheel" />.
    /// Can be used to control the motors, steering and deployment of wheels, among other things.
    /// </summary>
    public class Wheel : global::KRPC.Client.RemoteObject
    {
        /// <summary>
        /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
        /// </summary>
        public Wheel (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
        {
        }

        /// <summary>
        /// Whether automatic friction control is enabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_AutoFrictionControl")]
        public bool AutoFrictionControl {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_AutoFrictionControl", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_AutoFrictionControl", _args);
            }
        }

        /// <summary>
        /// The braking force, as a percentage of maximum, when the brakes are applied.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Brakes")]
        public float Brakes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Brakes", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_Brakes", _args);
            }
        }

        /// <summary>
        /// Whether the wheel is broken.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Broken")]
        public bool Broken {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Broken", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Current deflection of the wheel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Deflection")]
        public float Deflection {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Deflection", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the wheel is deployable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Deployable")]
        public bool Deployable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Deployable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the wheel is deployed.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Deployed")]
        public bool Deployed {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Deployed", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_Deployed", _args);
            }
        }

        /// <summary>
        /// Manual setting for the motor limiter.
        /// Only takes effect if the wheel has automatic traction control disabled.
        /// A value between 0 and 100 inclusive.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_DriveLimiter")]
        public float DriveLimiter {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_DriveLimiter", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_DriveLimiter", _args);
            }
        }

        /// <summary>
        /// Whether the wheel is touching the ground.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Grounded")]
        public bool Grounded {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Grounded", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the wheel has brakes.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_HasBrakes")]
        public bool HasBrakes {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_HasBrakes", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Whether the wheel has suspension.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_HasSuspension")]
        public bool HasSuspension {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_HasSuspension", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Manual friction control value. Only has an effect if automatic friction control is disabled.
        /// A value between 0 and 5 inclusive.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_ManualFrictionControl")]
        public float ManualFrictionControl {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_ManualFrictionControl", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_ManualFrictionControl", _args);
            }
        }

        /// <summary>
        /// Whether the motor is enabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_MotorEnabled")]
        public bool MotorEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_MotorEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_MotorEnabled", _args);
            }
        }

        /// <summary>
        /// Whether the direction of the motor is inverted.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_MotorInverted")]
        public bool MotorInverted {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_MotorInverted", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_MotorInverted", _args);
            }
        }

        /// <summary>
        /// The output of the motor. This is the torque currently being generated, in Newton meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_MotorOutput")]
        public float MotorOutput {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_MotorOutput", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the direction of the motor is inverted.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_MotorState")]
        public global::KRPC.Client.Services.SpaceCenter.MotorState MotorState {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_MotorState", _args);
                return (global::KRPC.Client.Services.SpaceCenter.MotorState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.MotorState), connection);
            }
        }

        /// <summary>
        /// The part object for this wheel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Part")]
        public global::KRPC.Client.Services.SpaceCenter.Part Part {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Part", _args);
                return (global::KRPC.Client.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.Part), connection);
            }
        }

        /// <summary>
        /// Whether the wheel is powered by a motor.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Powered")]
        public bool Powered {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Powered", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Radius of the wheel, in meters.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Radius")]
        public float Radius {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Radius", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Whether the wheel is repairable.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Repairable")]
        public bool Repairable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Repairable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// Current slip of the wheel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Slip")]
        public float Slip {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Slip", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// The current state of the wheel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_State")]
        public global::KRPC.Client.Services.SpaceCenter.WheelState State {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_State", _args);
                return (global::KRPC.Client.Services.SpaceCenter.WheelState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::KRPC.Client.Services.SpaceCenter.WheelState), connection);
            }
        }

        /// <summary>
        /// Whether the wheel has steering.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Steerable")]
        public bool Steerable {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Steerable", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
        }

        /// <summary>
        /// The steering angle limit.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SteeringAngleLimit")]
        public float SteeringAngleLimit {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SteeringAngleLimit", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_SteeringAngleLimit", _args);
            }
        }

        /// <summary>
        /// Whether the wheel steering is enabled.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SteeringEnabled")]
        public bool SteeringEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SteeringEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_SteeringEnabled", _args);
            }
        }

        /// <summary>
        /// Whether the wheel steering is inverted.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SteeringInverted")]
        public bool SteeringInverted {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SteeringInverted", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_SteeringInverted", _args);
            }
        }

        /// <summary>
        /// Steering response time.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SteeringResponseTime")]
        public float SteeringResponseTime {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SteeringResponseTime", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_SteeringResponseTime", _args);
            }
        }

        /// <summary>
        /// Current stress on the wheel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_Stress")]
        public float Stress {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_Stress", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Current stress on the wheel as a percentage of its stress tolerance.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_StressPercentage")]
        public float StressPercentage {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_StressPercentage", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Stress tolerance of the wheel.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_StressTolerance")]
        public float StressTolerance {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_StressTolerance", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Suspension damper strength, as set in the editor.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SuspensionDamperStrength")]
        public float SuspensionDamperStrength {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SuspensionDamperStrength", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Suspension spring strength, as set in the editor.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_SuspensionSpringStrength")]
        public float SuspensionSpringStrength {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_SuspensionSpringStrength", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
        }

        /// <summary>
        /// Setting for the traction control.
        /// Only takes effect if the wheel has automatic traction control enabled.
        /// A value between 0 and 5 inclusive.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_TractionControl")]
        public float TractionControl {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_TractionControl", _args);
                return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(float))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_TractionControl", _args);
            }
        }

        /// <summary>
        /// Whether automatic traction control is enabled.
        /// A wheel only has traction control if it is powered.
        /// </summary>
        [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Wheel_get_TractionControlEnabled")]
        public bool TractionControlEnabled {
            get {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel))
                };
                ByteString _data = connection.Invoke ("SpaceCenter", "Wheel_get_TractionControlEnabled", _args);
                return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
            }
            set {
                var _args = new ByteString[] {
                    global::KRPC.Client.Encoder.Encode (this, typeof(SpaceCenter.Wheel)),
                    global::KRPC.Client.Encoder.Encode (value, typeof(bool))
                };
                connection.Invoke ("SpaceCenter", "Wheel_set_TractionControlEnabled", _args);
            }
        }
    }
}
