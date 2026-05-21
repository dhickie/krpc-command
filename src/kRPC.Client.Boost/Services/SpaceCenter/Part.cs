using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents an individual part. Vessels are made up of multiple parts.
/// Instances of this class can be obtained by several methods in <see cref="T:SpaceCenter.Parts" />.
/// </summary>
public class Part : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Part (ConnectionMultiplexer connection, ulong id) : base (connection, id)
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
    [RpcAttribute ("SpaceCenter", "Part_AddForce")]
    public Force AddForce (Tuple<double,double,double> force, Tuple<double,double,double> position, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            force,
            position,
            referenceFrame
        };
        return Connection.Invoke<Force> ("SpaceCenter", "Part_AddForce", args);
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
    [RpcAttribute ("SpaceCenter", "Part_BoundingBox")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> BoundingBox (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "Part_BoundingBox", args);
    }

    /// <summary>
    /// The position of the parts center of mass in the given reference frame.
    /// If the part is physicsless, this is equivalent to <see cref="M:SpaceCenter.Part.Position" />.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [RpcAttribute ("SpaceCenter", "Part_CenterOfMass")]
    public Tuple<double,double,double> CenterOfMass (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Part_CenterOfMass", args);
    }

    /// <summary>
    /// The direction the part points in, in the given reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [RpcAttribute ("SpaceCenter", "Part_Direction")]
    public Tuple<double,double,double> Direction (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Part_Direction", args);
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
    [RpcAttribute ("SpaceCenter", "Part_InstantaneousForce")]
    public void InstantaneousForce (Tuple<double,double,double> force, Tuple<double,double,double> position, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            force,
            position,
            referenceFrame
        };
        Connection.Invoke ("SpaceCenter", "Part_InstantaneousForce", args);
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
    [RpcAttribute ("SpaceCenter", "Part_Position")]
    public Tuple<double,double,double> Position (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Part_Position", args);
    }

    /// <summary>
    /// The rotation of the part, in the given reference frame.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [RpcAttribute ("SpaceCenter", "Part_Rotation")]
    public Tuple<double,double,double,double> Rotation (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double,double>> ("SpaceCenter", "Part_Rotation", args);
    }

    /// <summary>
    /// The linear velocity of the part in the given reference frame.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the body in meters per second.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// velocity vector is in.</param>
    [RpcAttribute ("SpaceCenter", "Part_Velocity")]
    public Tuple<double,double,double> Velocity (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Part_Velocity", args);
    }

    /// <summary>
    /// An <see cref="T:SpaceCenter.Antenna" /> if the part is an antenna, otherwise <c>null</c>.
    /// </summary>
    /// <remarks>
    /// If RemoteTech is installed, this will always return <c>null</c>.
    /// To interact with RemoteTech antennas, use the RemoteTech service APIs.
    /// </remarks>
    [RpcAttribute ("SpaceCenter", "Part_get_Antenna")]
    public Antenna Antenna {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Antenna> ("SpaceCenter", "Part_get_Antenna", args);
        }
    }

    /// <summary>
    /// Auto-strut mode.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_AutoStrutMode")]
    public AutoStrutMode AutoStrutMode {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<AutoStrutMode> ("SpaceCenter", "Part_get_AutoStrutMode", args);
        }
    }

    /// <summary>
    /// How many open seats the part has.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_AvailableSeats")]
    public uint AvailableSeats {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<uint> ("SpaceCenter", "Part_get_AvailableSeats", args);
        }
    }

    /// <summary>
    /// Whether the part is axially attached to its parent, i.e. on the top
    /// or bottom of its parent. If the part has no parent, returns <c>false</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_AxiallyAttached")]
    public bool AxiallyAttached {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Part_get_AxiallyAttached", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.CargoBay" /> if the part is a cargo bay, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_CargoBay")]
    public CargoBay CargoBay {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<CargoBay> ("SpaceCenter", "Part_get_CargoBay", args);
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
    [RpcAttribute ("SpaceCenter", "Part_get_CenterOfMassReferenceFrame")]
    public ReferenceFrame CenterOfMassReferenceFrame {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "Part_get_CenterOfMassReferenceFrame", args);
        }
    }

    /// <summary>
    /// The parts children. Returns an empty list if the part has no children.
    /// This, in combination with <see cref="M:SpaceCenter.Part.Parent" />, can be used to traverse the vessels
    /// parts tree.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Children")]
    public IList<Part> Children {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Part>> ("SpaceCenter", "Part_get_Children", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ControlSurface" /> if the part is an aerodynamic control surface,
    /// otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ControlSurface")]
    public ControlSurface ControlSurface {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ControlSurface> ("SpaceCenter", "Part_get_ControlSurface", args);
        }
    }

    /// <summary>
    /// The cost of the part, in units of funds.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Cost")]
    public double Cost {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Part_get_Cost", args);
        }
    }

    /// <summary>
    /// Whether this part is crossfeed capable.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Crossfeed")]
    public bool Crossfeed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Part_get_Crossfeed", args);
        }
    }

    /// <summary>
    /// The stage in which this part will be decoupled. Returns -1 if the part is never
    /// decoupled from the vessel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_DecoupleStage")]
    public int DecoupleStage {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<int> ("SpaceCenter", "Part_get_DecoupleStage", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Decoupler" /> if the part is a decoupler, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Decoupler")]
    public Decoupler Decoupler {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Decoupler> ("SpaceCenter", "Part_get_Decoupler", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.DockingPort" /> if the part is a docking port, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_DockingPort")]
    public DockingPort DockingPort {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<DockingPort> ("SpaceCenter", "Part_get_DockingPort", args);
        }
    }

    /// <summary>
    /// The mass of the part, not including any resources it contains, in kilograms.
    /// Returns zero if the part is massless.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_DryMass")]
    public double DryMass {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Part_get_DryMass", args);
        }
    }

    /// <summary>
    /// The dynamic pressure acting on the part, in Pascals.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_DynamicPressure")]
    public float DynamicPressure {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Part_get_DynamicPressure", args);
        }
    }

    /// <summary>
    /// An <see cref="T:SpaceCenter.Engine" /> if the part is an engine, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Engine")]
    public Engine Engine {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Engine> ("SpaceCenter", "Part_get_Engine", args);
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
    [RpcAttribute ("SpaceCenter", "Part_get_Experiment")]
    public Experiment Experiment {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Experiment> ("SpaceCenter", "Part_get_Experiment", args);
        }
    }

    /// <summary>
    /// A list of <see cref="T:SpaceCenter.Experiment" /> objects that the part contains.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Experiments")]
    public IList<Experiment> Experiments {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Experiment>> ("SpaceCenter", "Part_get_Experiments", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Fairing" /> if the part is a fairing, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Fairing")]
    public Fairing Fairing {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Fairing> ("SpaceCenter", "Part_get_Fairing", args);
        }
    }

    /// <summary>
    /// The asset URL for the part's flag.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_FlagURL")]
    public string FlagURL {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Part_get_FlagURL", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Part_set_FlagURL", args);
        }
    }

    /// <summary>
    /// The parts that are connected to this part via fuel lines, where the direction of the
    /// fuel line is into this part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_FuelLinesFrom")]
    public IList<Part> FuelLinesFrom {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Part>> ("SpaceCenter", "Part_get_FuelLinesFrom", args);
        }
    }

    /// <summary>
    /// The parts that are connected to this part via fuel lines, where the direction of the
    /// fuel line is out of this part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_FuelLinesTo")]
    public IList<Part> FuelLinesTo {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Part>> ("SpaceCenter", "Part_get_FuelLinesTo", args);
        }
    }

    /// <summary>
    /// Whether the part is glowing.
    /// </summary>
    public bool Glow {
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Part_set_Glow", args);
        }
    }

    /// <summary>
    /// The color used to highlight the part, as an RGB triple.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_HighlightColor")]
    public Tuple<double,double,double> HighlightColor {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Part_get_HighlightColor", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Part_set_HighlightColor", args);
        }
    }

    /// <summary>
    /// Whether the part is highlighted.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Highlighted")]
    public bool Highlighted {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Part_get_Highlighted", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Part_set_Highlighted", args);
        }
    }

    /// <summary>
    /// The impact tolerance of the part, in meters per second.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ImpactTolerance")]
    public double ImpactTolerance {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Part_get_ImpactTolerance", args);
        }
    }

    /// <summary>
    /// The inertia tensor of the part in the parts reference frame
    /// (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// Returns the 3x3 matrix as a list of elements, in row-major order.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_InertiaTensor")]
    public IList<double> InertiaTensor {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<double>> ("SpaceCenter", "Part_get_InertiaTensor", args);
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
    [RpcAttribute ("SpaceCenter", "Part_get_Intake")]
    public Intake Intake {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Intake> ("SpaceCenter", "Part_get_Intake", args);
        }
    }

    /// <summary>
    /// Whether this part is a fuel line.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_IsFuelLine")]
    public bool IsFuelLine {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Part_get_IsFuelLine", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.LaunchClamp" /> if the part is a launch clamp, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_LaunchClamp")]
    public LaunchClamp LaunchClamp {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<LaunchClamp> ("SpaceCenter", "Part_get_LaunchClamp", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Leg" /> if the part is a landing leg, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Leg")]
    public Leg Leg {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Leg> ("SpaceCenter", "Part_get_Leg", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Light" /> if the part is a light, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Light")]
    public Light Light {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Light> ("SpaceCenter", "Part_get_Light", args);
        }
    }

    /// <summary>
    /// The current mass of the part, including resources it contains, in kilograms.
    /// Returns zero if the part is massless.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Mass")]
    public double Mass {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Part_get_Mass", args);
        }
    }

    /// <summary>
    /// Whether the part is
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Massless_part">massless</a>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Massless")]
    public bool Massless {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Part_get_Massless", args);
        }
    }

    /// <summary>
    /// Maximum temperature that the skin of the part can survive, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_MaxSkinTemperature")]
    public double MaxSkinTemperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Part_get_MaxSkinTemperature", args);
        }
    }

    /// <summary>
    /// Maximum temperature that the part can survive, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_MaxTemperature")]
    public double MaxTemperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Part_get_MaxTemperature", args);
        }
    }

    /// <summary>
    /// The modules for this part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Modules")]
    public IList<Module> Modules {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Module>> ("SpaceCenter", "Part_get_Modules", args);
        }
    }

    /// <summary>
    /// The moment of inertia of the part in <math>kg.m^2</math> around its center of mass
    /// in the parts reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_MomentOfInertia")]
    public Tuple<double,double,double> MomentOfInertia {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Part_get_MomentOfInertia", args);
        }
    }

    /// <summary>
    /// Internal name of the part, as used in
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/CFG_File_Documentation">part cfg files</a>.
    /// For example "Mark1-2Pod".
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Name")]
    public string Name {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Part_get_Name", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Parachute" /> if the part is a parachute, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Parachute")]
    public Parachute Parachute {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Parachute> ("SpaceCenter", "Part_get_Parachute", args);
        }
    }

    /// <summary>
    /// The parts parent. Returns <c>null</c> if the part does not have a parent.
    /// This, in combination with <see cref="M:SpaceCenter.Part.Children" />, can be used to traverse the vessels
    /// parts tree.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Parent")]
    public Part Parent {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Part_get_Parent", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RCS" /> if the part is an RCS block/thruster, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_RCS")]
    public RCS RCS {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<RCS> ("SpaceCenter", "Part_get_RCS", args);
        }
    }

    /// <summary>
    /// Whether the part is radially attached to its parent, i.e. on the side of its parent.
    /// If the part has no parent, returns <c>false</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_RadiallyAttached")]
    public bool RadiallyAttached {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Part_get_RadiallyAttached", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Radiator" /> if the part is a radiator, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Radiator")]
    public Radiator Radiator {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Radiator> ("SpaceCenter", "Part_get_Radiator", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ReactionWheel" /> if the part is a reaction wheel, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ReactionWheel")]
    public ReactionWheel ReactionWheel {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ReactionWheel> ("SpaceCenter", "Part_get_ReactionWheel", args);
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
    [RpcAttribute ("SpaceCenter", "Part_get_ReferenceFrame")]
    public ReferenceFrame ReferenceFrame {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "Part_get_ReferenceFrame", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ResourceConverter" /> if the part is a resource converter,
    /// otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ResourceConverter")]
    public ResourceConverter ResourceConverter {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ResourceConverter> ("SpaceCenter", "Part_get_ResourceConverter", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ResourceDrain" /> if the part is a resource drain, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ResourceDrain")]
    public ResourceDrain ResourceDrain {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ResourceDrain> ("SpaceCenter", "Part_get_ResourceDrain", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.ResourceHarvester" /> if the part is a resource harvester,
    /// otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ResourceHarvester")]
    public ResourceHarvester ResourceHarvester {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ResourceHarvester> ("SpaceCenter", "Part_get_ResourceHarvester", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Resources" /> object for the part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Resources")]
    public Resources Resources {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Resources> ("SpaceCenter", "Part_get_Resources", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticController" /> if the part is a robotic controller,
    /// otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_RoboticController")]
    public RoboticController RoboticController {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<RoboticController> ("SpaceCenter", "Part_get_RoboticController", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticHinge" /> if the part is a robotic hinge, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_RoboticHinge")]
    public RoboticHinge RoboticHinge {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<RoboticHinge> ("SpaceCenter", "Part_get_RoboticHinge", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticPiston" /> if the part is a robotic piston, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_RoboticPiston")]
    public RoboticPiston RoboticPiston {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<RoboticPiston> ("SpaceCenter", "Part_get_RoboticPiston", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticRotation" /> if the part is a robotic rotation servo, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_RoboticRotation")]
    public RoboticRotation RoboticRotation {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<RoboticRotation> ("SpaceCenter", "Part_get_RoboticRotation", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.RoboticRotor" /> if the part is a robotic rotor, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_RoboticRotor")]
    public RoboticRotor RoboticRotor {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<RoboticRotor> ("SpaceCenter", "Part_get_RoboticRotor", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Sensor" /> if the part is a sensor, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Sensor")]
    public Sensor Sensor {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Sensor> ("SpaceCenter", "Part_get_Sensor", args);
        }
    }

    /// <summary>
    /// Whether the part is shielded from the exterior of the vessel, for example by a fairing.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Shielded")]
    public bool Shielded {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Part_get_Shielded", args);
        }
    }

    /// <summary>
    /// Temperature of the skin of the part, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_SkinTemperature")]
    public double SkinTemperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Part_get_SkinTemperature", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.SolarPanel" /> if the part is a solar panel, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_SolarPanel")]
    public SolarPanel SolarPanel {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<SolarPanel> ("SpaceCenter", "Part_get_SolarPanel", args);
        }
    }

    /// <summary>
    /// The stage in which this part will be activated. Returns -1 if the part is not
    /// activated by staging.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Stage")]
    public int Stage {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<int> ("SpaceCenter", "Part_get_Stage", args);
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
    [RpcAttribute ("SpaceCenter", "Part_get_Tag")]
    public string Tag {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Part_get_Tag", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Part_set_Tag", args);
        }
    }

    /// <summary>
    /// Temperature of the part, in Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Temperature")]
    public double Temperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Part_get_Temperature", args);
        }
    }

    /// <summary>
    /// The rate at which heat energy is conducting into or out of the part via contact with
    /// other parts. Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part is gaining heat energy, and negative means it is
    /// losing heat energy.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ThermalConductionFlux")]
    public float ThermalConductionFlux {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalConductionFlux", args);
        }
    }

    /// <summary>
    /// The rate at which heat energy is convecting into or out of the part from the
    /// surrounding atmosphere. Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part is gaining heat energy, and negative means it is
    /// losing heat energy.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ThermalConvectionFlux")]
    public float ThermalConvectionFlux {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalConvectionFlux", args);
        }
    }

    /// <summary>
    /// The rate at which heat energy is begin generated by the part.
    /// For example, some engines generate heat by combusting fuel.
    /// Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part is gaining heat energy, and negative means it is losing
    /// heat energy.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ThermalInternalFlux")]
    public float ThermalInternalFlux {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalInternalFlux", args);
        }
    }

    /// <summary>
    /// A measure of how much energy it takes to increase the internal temperature of the part,
    /// in Joules per Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ThermalMass")]
    public float ThermalMass {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalMass", args);
        }
    }

    /// <summary>
    /// The rate at which heat energy is radiating into or out of the part from the surrounding
    /// environment. Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part is gaining heat energy, and negative means it is
    /// losing heat energy.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ThermalRadiationFlux")]
    public float ThermalRadiationFlux {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalRadiationFlux", args);
        }
    }

    /// <summary>
    /// A measure of how much energy it takes to increase the temperature of the resources
    /// contained in the part, in Joules per Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ThermalResourceMass")]
    public float ThermalResourceMass {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalResourceMass", args);
        }
    }

    /// <summary>
    /// A measure of how much energy it takes to increase the skin temperature of the part,
    /// in Joules per Kelvin.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ThermalSkinMass")]
    public float ThermalSkinMass {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalSkinMass", args);
        }
    }

    /// <summary>
    /// The rate at which heat energy is transferring between the part's skin and its internals.
    /// Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part's internals are gaining heat energy,
    /// and negative means its skin is gaining heat energy.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_ThermalSkinToInternalFlux")]
    public float ThermalSkinToInternalFlux {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalSkinToInternalFlux", args);
        }
    }

    /// <summary>
    /// Title of the part, as shown when the part is right clicked in-game. For example "Mk1-2 Command Pod".
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Title")]
    public string Title {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Part_get_Title", args);
        }
    }

    /// <summary>
    /// The vessel that contains this part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Vessel")]
    public Vessel Vessel {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Vessel> ("SpaceCenter", "Part_get_Vessel", args);
        }
    }

    /// <summary>
    /// A <see cref="T:SpaceCenter.Wheel" /> if the part is a wheel, otherwise <c>null</c>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Part_get_Wheel")]
    public Wheel Wheel {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Wheel> ("SpaceCenter", "Part_get_Wheel", args);
        }
    }
}
