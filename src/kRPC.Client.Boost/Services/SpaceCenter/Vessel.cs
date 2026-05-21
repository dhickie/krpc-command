using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// These objects are used to interact with vessels in KSP. This includes getting
/// orbital and flight data, manipulating control inputs and managing resources.
/// Created using <see cref="M:SpaceCenter.ActiveVessel" /> or <see cref="M:SpaceCenter.Vessels" />.
/// </summary>
public class Vessel : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Vessel (ConnectionMultiplexer connection, ulong id) : base (connection, id)
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
    [RpcAttribute ("SpaceCenter", "Vessel_AngularVelocity")]
    public Tuple<double,double,double> AngularVelocity (ReferenceFrame referenceFrame)
    {
        var _args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Vessel_AngularVelocity", _args);
    }

    /// <summary>
    /// Gets the total available thrust that can be produced by the vessel's
    /// active engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.AvailableThrustAt" /> for every active engine in the vessel.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [RpcAttribute ("SpaceCenter", "Vessel_AvailableThrustAt")]
    public float AvailableThrustAt (double pressure)
    {
        var _args = new object[] {
            this,
            pressure
        };
        return Connection.Invoke<float> ("SpaceCenter", "Vessel_AvailableThrustAt", _args);
    }

    /// <summary>
    /// The axis-aligned bounding box of the vessel in the given reference frame.
    /// </summary>
    /// <returns>The positions of the minimum and maximum vertices of the box,
    /// as position vectors.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vectors are in.</param>
    [RpcAttribute ("SpaceCenter", "Vessel_BoundingBox")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> BoundingBox (ReferenceFrame referenceFrame)
    {
        var _args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "Vessel_BoundingBox", _args);
    }

    /// <summary>
    /// The direction in which the vessel is pointing, in the given reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [RpcAttribute ("SpaceCenter", "Vessel_Direction")]
    public Tuple<double,double,double> Direction (ReferenceFrame referenceFrame)
    {
        var _args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Vessel_Direction", _args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Flight" /> object that can be used to get flight
    /// telemetry for the vessel, in the specified reference frame.
    /// </summary>
    /// <param name="referenceFrame">
    /// Reference frame. Defaults to the vessel's surface reference frame
    /// (<see cref="M:SpaceCenter.Vessel.SurfaceReferenceFrame" />).
    /// </param>
    [RpcAttribute ("SpaceCenter", "Vessel_Flight")]
    public Flight Flight (ReferenceFrame referenceFrame = null)
    {
        var _args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Flight> ("SpaceCenter", "Vessel_Flight", _args);
    }

    /// <summary>
    /// The total maximum thrust that can be produced by the vessel's active
    /// engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.MaxThrustAt" /> for every active engine.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [RpcAttribute ("SpaceCenter", "Vessel_MaxThrustAt")]
    public float MaxThrustAt (double pressure)
    {
        var _args = new object[] {
            this,
            pressure
        };
        return Connection.Invoke<float> ("SpaceCenter", "Vessel_MaxThrustAt", _args);
    }

    /// <summary>
    /// The position of the center of mass of the vessel, in the given reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [RpcAttribute ("SpaceCenter", "Vessel_Position")]
    public Tuple<double,double,double> Position (ReferenceFrame referenceFrame)
    {
        var _args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Vessel_Position", _args);
    }

    /// <summary>
    /// Recover the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_Recover")]
    public void Recover ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Vessel_Recover", _args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Resources" /> object, that can used to get
    /// information about resources stored in a given <paramref name="stage" />.
    /// </summary>
    /// <param name="stage">Get resources for parts that are decoupled in this stage.</param>
    /// <param name="cumulative">When <c>false</c>, returns the resources for parts
    /// decoupled in just the given stage. When <c>true</c> returns the resources decoupled in
    /// the given stage and all subsequent stages combined.</param>
    [RpcAttribute ("SpaceCenter", "Vessel_ResourcesInDecoupleStage")]
    public Resources ResourcesInDecoupleStage (int stage, bool cumulative = true)
    {
        var _args = new object[] {
            this,
            stage,
            cumulative
        };
        return Connection.Invoke<Resources> ("SpaceCenter", "Vessel_ResourcesInDecoupleStage", _args);
    }

    /// <summary>
    /// The rotation of the vessel, in the given reference frame.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [RpcAttribute ("SpaceCenter", "Vessel_Rotation")]
    public Tuple<double,double,double,double> Rotation (ReferenceFrame referenceFrame)
    {
        var _args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double,double>> ("SpaceCenter", "Vessel_Rotation", _args);
    }

    /// <summary>
    /// The combined specific impulse of all active engines, in seconds. This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [RpcAttribute ("SpaceCenter", "Vessel_SpecificImpulseAt")]
    public float SpecificImpulseAt (double pressure)
    {
        var _args = new object[] {
            this,
            pressure
        };
        return Connection.Invoke<float> ("SpaceCenter", "Vessel_SpecificImpulseAt", _args);
    }

    /// <summary>
    /// The velocity of the center of mass of the vessel, in the given reference frame.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the body in meters per second.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// velocity vector is in.</param>
    [RpcAttribute ("SpaceCenter", "Vessel_Velocity")]
    public Tuple<double,double,double> Velocity (ReferenceFrame referenceFrame)
    {
        var _args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Vessel_Velocity", _args);
    }

    /// <summary>
    /// An <see cref="T:SpaceCenter.AutoPilot" /> object, that can be used to perform
    /// simple auto-piloting of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_AutoPilot")]
    public AutoPilot AutoPilot {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<AutoPilot> ("SpaceCenter", "Vessel_get_AutoPilot", _args);
        }
    }

    /// <summary>
    /// The maximum torque that the aerodynamic control surfaces can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_AvailableControlSurfaceTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableControlSurfaceTorque {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "Vessel_get_AvailableControlSurfaceTorque", _args);
        }
    }

    /// <summary>
    /// The maximum torque that the currently active and gimballed engines can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_AvailableEngineTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableEngineTorque {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "Vessel_get_AvailableEngineTorque", _args);
        }
    }

    /// <summary>
    /// The maximum torque that parts (excluding reaction wheels, gimballed engines,
    /// RCS and control surfaces) can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_AvailableOtherTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableOtherTorque {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "Vessel_get_AvailableOtherTorque", _args);
        }
    }

    /// <summary>
    /// The maximum force that the currently active RCS thrusters can generate.
    /// Returns the forces in <math>N</math> along each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the right, forward and bottom directions of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_AvailableRCSForce")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableRCSForce {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "Vessel_get_AvailableRCSForce", _args);
        }
    }

    /// <summary>
    /// The maximum torque that the currently active RCS thrusters can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_AvailableRCSTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableRCSTorque {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "Vessel_get_AvailableRCSTorque", _args);
        }
    }

    /// <summary>
    /// The maximum torque that the currently active and powered reaction wheels can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_AvailableReactionWheelTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableReactionWheelTorque {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "Vessel_get_AvailableReactionWheelTorque", _args);
        }
    }

    /// <summary>
    /// Gets the total available thrust that can be produced by the vessel's
    /// active engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.AvailableThrust" /> for every active engine in the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_AvailableThrust")]
    public float AvailableThrust {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Vessel_get_AvailableThrust", _args);
        }
    }

    /// <summary>
    /// The maximum torque that the vessel generates. Includes contributions from
    /// reaction wheels, RCS, gimballed engines and aerodynamic control surfaces.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_AvailableTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableTorque {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "Vessel_get_AvailableTorque", _args);
        }
    }

    /// <summary>
    /// The name of the biome the vessel is currently in.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Biome")]
    public string Biome {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Vessel_get_Biome", _args);
        }
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Comms" /> object that can be used to interact
    /// with CommNet for this vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Comms")]
    public Comms Comms {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Comms> ("SpaceCenter", "Vessel_get_Comms", _args);
        }
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Control" /> object that can be used to manipulate
    /// the vessel's control inputs. For example, its pitch/yaw/roll controls,
    /// RCS and thrust.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Control")]
    public Control Control {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Control> ("SpaceCenter", "Vessel_get_Control", _args);
        }
    }

    /// <summary>
    /// The crew in the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Crew")]
    public IList<CrewMember> Crew {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<CrewMember>> ("SpaceCenter", "Vessel_get_Crew", _args);
        }
    }

    /// <summary>
    /// The number of crew that can occupy the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_CrewCapacity")]
    public int CrewCapacity {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<int> ("SpaceCenter", "Vessel_get_CrewCapacity", _args);
        }
    }

    /// <summary>
    /// The number of crew that are occupying the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_CrewCount")]
    public int CrewCount {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<int> ("SpaceCenter", "Vessel_get_CrewCount", _args);
        }
    }

    /// <summary>
    /// The total mass of the vessel, excluding resources, in kg.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_DryMass")]
    public float DryMass {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Vessel_get_DryMass", _args);
        }
    }

    /// <summary>
    /// The inertia tensor of the vessel around its center of mass,
    /// in the vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// Returns the 3x3 matrix as a list of elements, in row-major order.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_InertiaTensor")]
    public IList<double> InertiaTensor {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<double>> ("SpaceCenter", "Vessel_get_InertiaTensor", _args);
        }
    }

    /// <summary>
    /// The combined specific impulse of all active engines at sea level on Kerbin, in seconds.
    /// This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_KerbinSeaLevelSpecificImpulse")]
    public float KerbinSeaLevelSpecificImpulse {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Vessel_get_KerbinSeaLevelSpecificImpulse", _args);
        }
    }

    /// <summary>
    /// The mission elapsed time in seconds.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_MET")]
    public double MET {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Vessel_get_MET", _args);
        }
    }

    /// <summary>
    /// The total mass of the vessel, including resources, in kg.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Mass")]
    public float Mass {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Vessel_get_Mass", _args);
        }
    }

    /// <summary>
    /// The total maximum thrust that can be produced by the vessel's active
    /// engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.MaxThrust" /> for every active engine.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_MaxThrust")]
    public float MaxThrust {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Vessel_get_MaxThrust", _args);
        }
    }

    /// <summary>
    /// The total maximum thrust that can be produced by the vessel's active
    /// engines when the vessel is in a vacuum, in Newtons. This is computed by
    /// summing <see cref="M:SpaceCenter.Engine.MaxVacuumThrust" /> for every active engine.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_MaxVacuumThrust")]
    public float MaxVacuumThrust {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Vessel_get_MaxVacuumThrust", _args);
        }
    }

    /// <summary>
    /// The moment of inertia of the vessel around its center of mass in <math>kg.m^2</math>.
    /// The inertia values in the returned 3-tuple are around the
    /// pitch, roll and yaw directions respectively.
    /// This corresponds to the vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_MomentOfInertia")]
    public Tuple<double,double,double> MomentOfInertia {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Vessel_get_MomentOfInertia", _args);
        }
    }

    /// <summary>
    /// The name of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Name")]
    public string Name {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Vessel_get_Name", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Vessel_set_Name", _args);
        }
    }

    /// <summary>
    /// The current orbit of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Orbit")]
    public Orbit Orbit {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Orbit> ("SpaceCenter", "Vessel_get_Orbit", _args);
        }
    }

    /// <summary>
    /// The reference frame that is fixed relative to the vessel,
    /// and orientated with the vessels orbital prograde/normal/radial directions.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the orbital prograde/normal/radial directions.</description></item><item><description>The x-axis points in the orbital anti-radial direction.</description></item><item><description>The y-axis points in the orbital prograde direction.</description></item><item><description>The z-axis points in the orbital normal direction.</description></item></list></summary>
    /// <remarks>
    /// Be careful not to confuse this with 'orbit' mode on the navball.
    /// </remarks>
    [RpcAttribute ("SpaceCenter", "Vessel_get_OrbitalReferenceFrame")]
    public ReferenceFrame OrbitalReferenceFrame {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "Vessel_get_OrbitalReferenceFrame", _args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Parts" /> object, that can used to interact with the parts that make up this vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Parts")]
    public Parts Parts {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Parts> ("SpaceCenter", "Vessel_get_Parts", _args);
        }
    }

    /// <summary>
    /// Whether the vessel is recoverable.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Recoverable")]
    public bool Recoverable {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Vessel_get_Recoverable", _args);
        }
    }

    /// <summary>
    /// The reference frame that is fixed relative to the vessel,
    /// and orientated with the vessel.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the vessel.</description></item><item><description>The x-axis points out to the right of the vessel.</description></item><item><description>The y-axis points in the forward direction of the vessel.</description></item><item><description>The z-axis points out of the bottom off the vessel.</description></item></list></summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_ReferenceFrame")]
    public ReferenceFrame ReferenceFrame {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "Vessel_get_ReferenceFrame", _args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Resources" /> object, that can used to get information
    /// about resources stored in the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Resources")]
    public Resources Resources {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Resources> ("SpaceCenter", "Vessel_get_Resources", _args);
        }
    }

    /// <summary>
    /// The situation the vessel is in.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Situation")]
    public VesselSituation Situation {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<VesselSituation> ("SpaceCenter", "Vessel_get_Situation", _args);
        }
    }

    /// <summary>
    /// The combined specific impulse of all active engines, in seconds. This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_SpecificImpulse")]
    public float SpecificImpulse {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Vessel_get_SpecificImpulse", _args);
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
    [RpcAttribute ("SpaceCenter", "Vessel_get_SurfaceReferenceFrame")]
    public ReferenceFrame SurfaceReferenceFrame {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "Vessel_get_SurfaceReferenceFrame", _args);
        }
    }

    /// <summary>
    /// The reference frame that is fixed relative to the vessel,
    /// and orientated with the velocity vector of the vessel relative
    /// to the surface of the body being orbited.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the vessel's velocity vector.</description></item><item><description>The y-axis points in the direction of the vessel's velocity vector,
    /// relative to the surface of the body being orbited.</description></item><item><description>The z-axis is in the plane of the
    /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a>.</description></item><item><description>The x-axis is orthogonal to the other two axes.</description></item></list></summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_SurfaceVelocityReferenceFrame")]
    public ReferenceFrame SurfaceVelocityReferenceFrame {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "Vessel_get_SurfaceVelocityReferenceFrame", _args);
        }
    }

    /// <summary>
    /// The total thrust currently being produced by the vessel's engines, in
    /// Newtons. This is computed by summing <see cref="M:SpaceCenter.Engine.Thrust" /> for
    /// every engine in the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Thrust")]
    public float Thrust {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Vessel_get_Thrust", _args);
        }
    }

    /// <summary>
    /// The type of the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_Type")]
    public VesselType Type {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<VesselType> ("SpaceCenter", "Vessel_get_Type", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Vessel_set_Type", _args);
        }
    }

    /// <summary>
    /// The combined vacuum specific impulse of all active engines, in seconds. This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Vessel_get_VacuumSpecificImpulse")]
    public float VacuumSpecificImpulse {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Vessel_get_VacuumSpecificImpulse", _args);
        }
    }
}
