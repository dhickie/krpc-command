using Google.Protobuf;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

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
    public global::kRPC.Client.Boost.Services.SpaceCenter.Force AddForce (systemAlias::Tuple<double,double,double> force, systemAlias::Tuple<double,double,double> position, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (force, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Part_AddForce", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.Force)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Force), connection);
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
    public systemAlias::Tuple<systemAlias::Tuple<double,double,double>,systemAlias::Tuple<double,double,double>> BoundingBox (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
    public systemAlias::Tuple<double,double,double> CenterOfMass (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
    public systemAlias::Tuple<double,double,double> Direction (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
    public void InstantaneousForce (systemAlias::Tuple<double,double,double> force, systemAlias::Tuple<double,double,double> position, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (force, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
    public systemAlias::Tuple<double,double,double> Position (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
    public systemAlias::Tuple<double,double,double,double> Rotation (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
    public systemAlias::Tuple<double,double,double> Velocity (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.Antenna Antenna {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Antenna", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Antenna)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Antenna), connection);
        }
    }

    /// <summary>
    /// Auto-strut mode.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_AutoStrutMode")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.AutoStrutMode AutoStrutMode {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_AutoStrutMode", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.AutoStrutMode)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.AutoStrutMode), connection);
        }
    }

    /// <summary>
    /// How many open seats the part has.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_AvailableSeats")]
    public uint AvailableSeats {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_AxiallyAttached", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.CargoBay" /> if the part is a cargo bay, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_CargoBay")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.CargoBay CargoBay {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_CargoBay", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.CargoBay)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CargoBay), connection);
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame CenterOfMassReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_CenterOfMassReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// The parts children. Returns an empty list if the part has no children.
    /// This, in combination with <see cref="M:SpaceCenter.Part.Parent" />, can be used to traverse the vessels
    /// parts tree.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Children")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> Children {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Children", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ControlSurface" /> if the part is an aerodynamic control surface,
    /// otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ControlSurface")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface ControlSurface {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ControlSurface", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface), connection);
        }
    }

    /// <summary>
    /// The cost of the part, in units of funds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Cost")]
    public double Cost {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_DecoupleStage", _args);
            return (int)global::KRPC.Client.Encoder.Decode (_data, typeof(int), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Decoupler" /> if the part is a decoupler, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Decoupler")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler Decoupler {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Decoupler", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.DockingPort" /> if the part is a docking port, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_DockingPort")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort DockingPort {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_DockingPort", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort), connection);
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_DynamicPressure", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// An <see cref="T:SpaceCenter.Engine" /> if the part is an engine, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Engine")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Engine Engine {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Engine", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Engine)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Engine), connection);
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.Experiment Experiment {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Experiment", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Experiment)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Experiment), connection);
        }
    }

    /// <summary>
    /// A list of <see cref="T:SpaceCenter.Experiment" /> objects that the part contains.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Experiments")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Experiment> Experiments {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Experiments", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Experiment>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Experiment>), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Fairing" /> if the part is a fairing, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Fairing")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Fairing Fairing {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Fairing", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Fairing)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Fairing), connection);
        }
    }

    /// <summary>
    /// The asset URL for the part's flag.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_FlagURL")]
    public string FlagURL {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_FlagURL", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
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
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> FuelLinesFrom {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_FuelLinesFrom", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
        }
    }

    /// <summary>
    /// The parts that are connected to this part via fuel lines, where the direction of the
    /// fuel line is out of this part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_FuelLinesTo")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> FuelLinesTo {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_FuelLinesTo", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
        }
    }

    /// <summary>
    /// Whether the part is glowing.
    /// </summary>
    public bool Glow {
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_HighlightColor", _args);
            return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Highlighted", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.Intake Intake {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Intake", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Intake)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Intake), connection);
        }
    }

    /// <summary>
    /// Whether this part is a fuel line.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_IsFuelLine")]
    public bool IsFuelLine {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_IsFuelLine", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.LaunchClamp" /> if the part is a launch clamp, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_LaunchClamp")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.LaunchClamp LaunchClamp {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_LaunchClamp", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.LaunchClamp)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.LaunchClamp), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Leg" /> if the part is a landing leg, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Leg")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Leg Leg {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Leg", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Leg)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Leg), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Light" /> if the part is a light, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Light")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Light Light {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Light", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Light)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Light), connection);
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_MaxTemperature", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The modules for this part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Modules")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Module> Modules {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Modules", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Module>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Module>), connection);
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Parachute" /> if the part is a parachute, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Parachute")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Parachute Parachute {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Parachute", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Parachute)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parachute), connection);
        }
    }

    /// <summary>
    /// The parts parent. Returns <c>null</c> if the part does not have a parent.
    /// This, in combination with <see cref="M:SpaceCenter.Part.Children" />, can be used to traverse the vessels
    /// parts tree.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Parent")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Parent {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Parent", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RCS" /> if the part is an RCS block/thruster, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RCS")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.RCS RCS {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RCS", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.RCS)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RCS), connection);
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RadiallyAttached", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Radiator" /> if the part is a radiator, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Radiator")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Radiator Radiator {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Radiator", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Radiator)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Radiator), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ReactionWheel" /> if the part is a reaction wheel, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ReactionWheel")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel ReactionWheel {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ReactionWheel", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel), connection);
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
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ResourceConverter" /> if the part is a resource converter,
    /// otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ResourceConverter")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter ResourceConverter {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ResourceConverter", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ResourceDrain" /> if the part is a resource drain, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ResourceDrain")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain ResourceDrain {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ResourceDrain", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ResourceHarvester" /> if the part is a resource harvester,
    /// otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_ResourceHarvester")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester ResourceHarvester {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_ResourceHarvester", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Resources" /> object for the part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Resources")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Resources Resources {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Resources", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Resources)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Resources), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticController" /> if the part is a robotic controller,
    /// otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticController")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.RoboticController RoboticController {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticController", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.RoboticController)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticController), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticHinge" /> if the part is a robotic hinge, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticHinge")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.RoboticHinge RoboticHinge {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticHinge", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.RoboticHinge)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticHinge), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticPiston" /> if the part is a robotic piston, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticPiston")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston RoboticPiston {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticPiston", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticRotation" /> if the part is a robotic rotation servo, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticRotation")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation RoboticRotation {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticRotation", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticRotor" /> if the part is a robotic rotor, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_RoboticRotor")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor RoboticRotor {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_RoboticRotor", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Sensor" /> if the part is a sensor, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Sensor")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Sensor Sensor {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Sensor", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Sensor)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Sensor), connection);
        }
    }

    /// <summary>
    /// Whether the part is shielded from the exterior of the vessel, for example by a fairing.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Shielded")]
    public bool Shielded {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_SkinTemperature", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.SolarPanel" /> if the part is a solar panel, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_SolarPanel")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.SolarPanel SolarPanel {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_SolarPanel", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.SolarPanel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.SolarPanel), connection);
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Tag", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
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
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Title", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// The vessel that contains this part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Vessel")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Vessel Vessel {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Vessel", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Vessel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Vessel), connection);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Wheel" /> if the part is a wheel, otherwise <c>null</c>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Part_get_Wheel")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Wheel Wheel {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Part_get_Wheel", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Wheel)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Wheel), connection);
        }
    }
}