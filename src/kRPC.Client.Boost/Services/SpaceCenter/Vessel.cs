using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using systemAlias = System;

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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_AngularVelocity")]
    public systemAlias::Tuple<double,double,double> AngularVelocity (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
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
    public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> BoundingBox (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
    public systemAlias::Tuple<double,double,double> Direction (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.Flight Flight (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame = null)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_Flight", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Flight)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Flight), connection);
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
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
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
    public systemAlias::Tuple<double,double,double> Position (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.Resources ResourcesInDecoupleStage (int stage, bool cumulative = true)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (stage, typeof(int)),
            global::KRPC.Client.Encoder.Encode (cumulative, typeof(bool))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_ResourcesInDecoupleStage", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Resources)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources), connection);
    }

    /// <summary>
    /// The rotation of the vessel, in the given reference frame.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_Rotation")]
    public systemAlias::Tuple<double,double,double,double> Rotation (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
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
    public systemAlias::Tuple<double,double,double> Velocity (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_Velocity", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// An <see cref="T:SpaceCenter.AutoPilot" /> object, that can be used to perform
    /// simple auto-piloting of the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_AutoPilot")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot AutoPilot {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_AutoPilot", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoPilot), connection);
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.Comms Comms {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Comms", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Comms)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Comms), connection);
        }
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Control" /> object that can be used to manipulate
    /// the vessel's control inputs. For example, its pitch/yaw/roll controls,
    /// RCS and thrust.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Control")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Control Control {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Control", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Control)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Control), connection);
        }
    }

    /// <summary>
    /// The crew in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Crew")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember> Crew {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Crew", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.CrewMember>), connection);
        }
    }

    /// <summary>
    /// The number of crew that can occupy the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_CrewCapacity")]
    public int CrewCapacity {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(string))
            };
            connection.Invoke ("SpaceCenter", "Vessel_set_Name", _args);
        }
    }

    /// <summary>
    /// The current orbit of the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Orbit")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Orbit Orbit {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Orbit", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Orbit)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Orbit), connection);
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame OrbitalReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_OrbitalReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Parts" /> object, that can used to interact with the parts that make up this vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Parts")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Parts Parts {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Parts", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Parts)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts), connection);
        }
    }

    /// <summary>
    /// Whether the vessel is recoverable.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Recoverable")]
    public bool Recoverable {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_ReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Resources" /> object, that can used to get information
    /// about resources stored in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Resources")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Resources Resources {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Resources", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Resources)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources), connection);
        }
    }

    /// <summary>
    /// The situation the vessel is in.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Situation")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.VesselSituation Situation {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Situation", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.VesselSituation)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.VesselSituation), connection);
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame SurfaceReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_SurfaceReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame SurfaceVelocityReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_SurfaceVelocityReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Thrust", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The type of the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Vessel_get_Type")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.VesselType Type {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_Type", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.VesselType)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.VesselType), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.VesselType))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Vessel_get_VacuumSpecificImpulse", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }
}
