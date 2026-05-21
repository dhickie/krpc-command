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
    [Rpc ("SpaceCenter", "Part_AddForce")]
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
    [Rpc ("SpaceCenter", "Part_BoundingBox")]
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
    [Rpc ("SpaceCenter", "Part_CenterOfMass")]
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
    [Rpc ("SpaceCenter", "Part_Direction")]
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
    [Rpc ("SpaceCenter", "Part_InstantaneousForce")]
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
    [Rpc ("SpaceCenter", "Part_Position")]
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
    [Rpc ("SpaceCenter", "Part_Rotation")]
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
    [Rpc ("SpaceCenter", "Part_Velocity")]
    public Tuple<double,double,double> Velocity (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Part_Velocity", args);
    }

    /// <summary>
    /// Gets an <see cref="T:SpaceCenter.Antenna" /> if the part is an antenna, otherwise <c>null</c>.
    /// </summary>
    /// <remarks>
    /// If RemoteTech is installed, this will always return <c>null</c>.
    /// To interact with RemoteTech antennas, use the RemoteTech service APIs.
    /// </remarks>
    [Rpc ("SpaceCenter", "Part_get_Antenna")]
    public Antenna GetAntenna ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Antenna> ("SpaceCenter", "Part_get_Antenna", args);
    }

    /// <summary>
    /// Auto-strut mode.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_AutoStrutMode")]
    public AutoStrutMode GetAutoStrutMode ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<AutoStrutMode> ("SpaceCenter", "Part_get_AutoStrutMode", args);
    }

    /// <summary>
    /// How many open seats the part has.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_AvailableSeats")]
    public uint GetAvailableSeats ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<uint> ("SpaceCenter", "Part_get_AvailableSeats", args);
    }

    /// <summary>
    /// Gets whether the part is axially attached to its parent, i.e. on the top
    /// or bottom of its parent. If the part has no parent, returns <c>false</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_AxiallyAttached")]
    public bool GetAxiallyAttached ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Part_get_AxiallyAttached", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.CargoBay" /> if the part is a cargo bay, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_CargoBay")]
    public CargoBay GetCargoBay ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<CargoBay> ("SpaceCenter", "Part_get_CargoBay", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to this part, and centered on its
    /// center of mass.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the part, as returned by
    /// <see cref="M:SpaceCenter.Part.CenterOfMass" />.</description></item><item><description>The axes rotate with the part.</description></item><item><description>The x, y and z axis directions depend on the design of the part.
    /// </description></item></list>
    /// </summary>
    /// <remarks>
    /// For docking port parts, this reference frame is not necessarily equivalent to the
    /// reference frame for the docking port, returned by
    /// <see cref="M:SpaceCenter.DockingPort.GetReferenceFrame" />.
    /// </remarks>
    [Rpc ("SpaceCenter", "Part_get_CenterOfMassReferenceFrame")]
    public ReferenceFrame GetCenterOfMassReferenceFrame ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "Part_get_CenterOfMassReferenceFrame", args);
    }

    /// <summary>
    /// Gets the parts children. Returns an empty list if the part has no children.
    /// This, in combination with <see cref="M:SpaceCenter.Part.GetParent" />, can be used to traverse the vessels
    /// parts tree.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Children")]
    public IList<Part> GetChildren ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<Part>> ("SpaceCenter", "Part_get_Children", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.ControlSurface" /> if the part is an aerodynamic control surface,
    /// otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ControlSurface")]
    public ControlSurface GetControlSurface ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ControlSurface> ("SpaceCenter", "Part_get_ControlSurface", args);
    }

    /// <summary>
    /// Gets the cost of the part, in units of funds.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Cost")]
    public double GetCost ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Part_get_Cost", args);
    }

    /// <summary>
    /// Gets whether this part is crossfeed capable.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Crossfeed")]
    public bool GetCrossfeed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Part_get_Crossfeed", args);
    }

    /// <summary>
    /// Gets the stage in which this part will be decoupled. Returns -1 if the part is never
    /// decoupled from the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_DecoupleStage")]
    public int GetDecoupleStage ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<int> ("SpaceCenter", "Part_get_DecoupleStage", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Decoupler" /> if the part is a decoupler, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Decoupler")]
    public Decoupler GetDecoupler ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Decoupler> ("SpaceCenter", "Part_get_Decoupler", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.DockingPort" /> if the part is a docking port, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_DockingPort")]
    public DockingPort GetDockingPort ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<DockingPort> ("SpaceCenter", "Part_get_DockingPort", args);
    }

    /// <summary>
    /// Gets the mass of the part, not including any resources it contains, in kilograms.
    /// Returns zero if the part is massless.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_DryMass")]
    public double GetDryMass ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Part_get_DryMass", args);
    }

    /// <summary>
    /// Gets the dynamic pressure acting on the part, in Pascals.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_DynamicPressure")]
    public float GetDynamicPressure ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Part_get_DynamicPressure", args);
    }

    /// <summary>
    /// Gets an <see cref="T:SpaceCenter.Engine" /> if the part is an engine, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Engine")]
    public Engine GetEngine ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Engine> ("SpaceCenter", "Part_get_Engine", args);
    }

    /// <summary>
    /// Gets an <see cref="T:SpaceCenter.Experiment" /> if the part contains a
    /// single science experiment, otherwise <c>null</c>.
    /// </summary>
    /// <remarks>
    /// Throws an exception if the part contains more than one experiment.
    /// In that case, use <see cref="M:SpaceCenter.Part.GetExperiments" /> to get the list of experiments in the part.
    /// </remarks>
    [Rpc ("SpaceCenter", "Part_get_Experiment")]
    public Experiment GetExperiment ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Experiment> ("SpaceCenter", "Part_get_Experiment", args);
    }

    /// <summary>
    /// Gets a list of <see cref="T:SpaceCenter.Experiment" /> objects that the part contains.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Experiments")]
    public IList<Experiment> GetExperiments ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<Experiment>> ("SpaceCenter", "Part_get_Experiments", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Fairing" /> if the part is a fairing, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Fairing")]
    public Fairing GetFairing ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Fairing> ("SpaceCenter", "Part_get_Fairing", args);
    }

    /// <summary>
    /// Gets the asset URL for the part's flag.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_FlagURL")]
    public string GetFlagURL ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "Part_get_FlagURL", args);
    }

    /// <summary>
    /// Sets the asset URL for the part's flag.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetFlagURL (string value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Part_set_FlagURL", args);
    }

    /// <summary>
    /// Gets the parts that are connected to this part via fuel lines, where the direction of the
    /// fuel line is into this part.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_FuelLinesFrom")]
    public IList<Part> GetFuelLinesFrom ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<Part>> ("SpaceCenter", "Part_get_FuelLinesFrom", args);
    }

    /// <summary>
    /// Gets the parts that are connected to this part via fuel lines, where the direction of the
    /// fuel line is out of this part.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_FuelLinesTo")]
    public IList<Part> GetFuelLinesTo ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<Part>> ("SpaceCenter", "Part_get_FuelLinesTo", args);
    }

    /// <summary>
    /// Whether the part is glowing.
    /// </summary>
    public void SetGlow (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Part_set_Glow", args);
    }

    /// <summary>
    /// Gets the color used to highlight the part, as an RGB triple.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_HighlightColor")]
    public Tuple<double,double,double> GetHighlightColor ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Part_get_HighlightColor", args);
    }

    /// <summary>
    /// Sets the color used to highlight the part, as an RGB triple.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetHighlightColor (Tuple<double,double,double> value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Part_set_HighlightColor", args);
    }

    /// <summary>
    /// Gets whether the part is highlighted.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Highlighted")]
    public bool GetHighlighted ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Part_get_Highlighted", args);
    }

    /// <summary>
    /// Sets whether the part is highlighted.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetHighlighted (bool value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Part_set_Highlighted", args);
    }

    /// <summary>
    /// Gets the impact tolerance of the part, in meters per second.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ImpactTolerance")]
    public double GetImpactTolerance ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Part_get_ImpactTolerance", args);
    }

    /// <summary>
    /// Gets the inertia tensor of the part in the parts reference frame
    /// (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// Returns the 3x3 matrix as a list of elements, in row-major order.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_InertiaTensor")]
    public IList<double> GetInertiaTensor ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<double>> ("SpaceCenter", "Part_get_InertiaTensor", args);
    }

    /// <summary>
    /// Gets an <see cref="T:SpaceCenter.Intake" /> if the part is an intake, otherwise <c>null</c>.
    /// </summary>
    /// <remarks>
    /// This includes any part that generates thrust. This covers many different types
    /// of engine, including liquid fuel rockets, solid rocket boosters and jet engines.
    /// For RCS thrusters see <see cref="T:SpaceCenter.RCS" />.
    /// </remarks>
    [Rpc ("SpaceCenter", "Part_get_Intake")]
    public Intake GetIntake ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Intake> ("SpaceCenter", "Part_get_Intake", args);
    }

    /// <summary>
    /// Gets whether this part is a fuel line.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_IsFuelLine")]
    public bool GetIsFuelLine ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Part_get_IsFuelLine", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.LaunchClamp" /> if the part is a launch clamp, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_LaunchClamp")]
    public LaunchClamp GetLaunchClamp ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<LaunchClamp> ("SpaceCenter", "Part_get_LaunchClamp", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Leg" /> if the part is a landing leg, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Leg")]
    public Leg GetLeg ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Leg> ("SpaceCenter", "Part_get_Leg", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Light" /> if the part is a light, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Light")]
    public Light GetLight ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Light> ("SpaceCenter", "Part_get_Light", args);
    }

    /// <summary>
    /// Gets the current mass of the part, including resources it contains, in kilograms.
    /// Returns zero if the part is massless.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Mass")]
    public double GetMass ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Part_get_Mass", args);
    }

    /// <summary>
    /// Gets whether the part is
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Massless_part">massless</a>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Massless")]
    public bool GetMassless ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Part_get_Massless", args);
    }

    /// <summary>
    /// Gets the maximum temperature that the skin of the part can survive, in Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_MaxSkinTemperature")]
    public double GetMaxSkinTemperature ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Part_get_MaxSkinTemperature", args);
    }

    /// <summary>
    /// Gets the maximum temperature that the part can survive, in Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_MaxTemperature")]
    public double GetMaxTemperature ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Part_get_MaxTemperature", args);
    }

    /// <summary>
    /// Gets the modules for this part.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Modules")]
    public IList<Module> GetModules ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<Module>> ("SpaceCenter", "Part_get_Modules", args);
    }

    /// <summary>
    /// Gets the moment of inertia of the part in <math>kg.m^2</math> around its center of mass
    /// in the parts reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_MomentOfInertia")]
    public Tuple<double,double,double> GetMomentOfInertia ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Part_get_MomentOfInertia", args);
    }

    /// <summary>
    /// Internal name of the part, as used in
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/CFG_File_Documentation">part cfg files</a>.
    /// For example "Mark1-2Pod".
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Name")]
    public string GetName ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "Part_get_Name", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Parachute" /> if the part is a parachute, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Parachute")]
    public Parachute GetParachute ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Parachute> ("SpaceCenter", "Part_get_Parachute", args);
    }

    /// <summary>
    /// Gets the parts parent. Returns <c>null</c> if the part does not have a parent.
    /// This, in combination with <see cref="M:SpaceCenter.Part.GetChildren" />, can be used to traverse the vessels
    /// parts tree.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Parent")]
    public Part GetParent ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Part> ("SpaceCenter", "Part_get_Parent", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.RCS" /> if the part is an RCS block/thruster, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_RCS")]
    public RCS GetRCS ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<RCS> ("SpaceCenter", "Part_get_RCS", args);
    }

    /// <summary>
    /// Gets whether the part is radially attached to its parent, i.e. on the side of its parent.
    /// If the part has no parent, returns <c>false</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_RadiallyAttached")]
    public bool GetRadiallyAttached ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Part_get_RadiallyAttached", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Radiator" /> if the part is a radiator, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Radiator")]
    public Radiator GetRadiator ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Radiator> ("SpaceCenter", "Part_get_Radiator", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.ReactionWheel" /> if the part is a reaction wheel, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ReactionWheel")]
    public ReactionWheel GetReactionWheel ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ReactionWheel> ("SpaceCenter", "Part_get_ReactionWheel", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to this part, and centered on a fixed
    /// position within the part, defined by the parts model.
    /// <list type="bullet"><item><description>The origin is at the position of the part, as returned by
    /// <see cref="M:SpaceCenter.Part.Position" />.</description></item><item><description>The axes rotate with the part.</description></item><item><description>The x, y and z axis directions depend on the design of the part.
    /// </description></item></list>
    /// </summary>
    /// <remarks>
    /// For docking port parts, this reference frame is not necessarily equivalent to the
    /// reference frame for the docking port, returned by
    /// <see cref="M:SpaceCenter.DockingPort.GetReferenceFrame" />.
    /// </remarks>
    [Rpc ("SpaceCenter", "Part_get_ReferenceFrame")]
    public ReferenceFrame GetReferenceFrame ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "Part_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.ResourceConverter" /> if the part is a resource converter,
    /// otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ResourceConverter")]
    public ResourceConverter GetResourceConverter ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ResourceConverter> ("SpaceCenter", "Part_get_ResourceConverter", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.ResourceDrain" /> if the part is a resource drain, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ResourceDrain")]
    public ResourceDrain GetResourceDrain ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ResourceDrain> ("SpaceCenter", "Part_get_ResourceDrain", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.ResourceHarvester" /> if the part is a resource harvester,
    /// otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ResourceHarvester")]
    public ResourceHarvester GetResourceHarvester ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ResourceHarvester> ("SpaceCenter", "Part_get_ResourceHarvester", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Resources" /> object for the part.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Resources")]
    public Resources GetResources ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Resources> ("SpaceCenter", "Part_get_Resources", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.RoboticController" /> if the part is a robotic controller,
    /// otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_RoboticController")]
    public RoboticController GetRoboticController ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<RoboticController> ("SpaceCenter", "Part_get_RoboticController", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.RoboticHinge" /> if the part is a robotic hinge, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_RoboticHinge")]
    public RoboticHinge GetRoboticHinge ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<RoboticHinge> ("SpaceCenter", "Part_get_RoboticHinge", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.RoboticPiston" /> if the part is a robotic piston, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_RoboticPiston")]
    public RoboticPiston GetRoboticPiston ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<RoboticPiston> ("SpaceCenter", "Part_get_RoboticPiston", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.RoboticRotation" /> if the part is a robotic rotation servo, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_RoboticRotation")]
    public RoboticRotation GetRoboticRotation ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<RoboticRotation> ("SpaceCenter", "Part_get_RoboticRotation", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.RoboticRotor" /> if the part is a robotic rotor, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_RoboticRotor")]
    public RoboticRotor GetRoboticRotor ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<RoboticRotor> ("SpaceCenter", "Part_get_RoboticRotor", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Sensor" /> if the part is a sensor, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Sensor")]
    public Sensor GetSensor ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Sensor> ("SpaceCenter", "Part_get_Sensor", args);
    }

    /// <summary>
    /// Gets whether the part is shielded from the exterior of the vessel, for example by a fairing.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Shielded")]
    public bool GetShielded ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Part_get_Shielded", args);
    }

    /// <summary>
    /// Temperature of the skin of the part, in Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_SkinTemperature")]
    public double GetSkinTemperature ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Part_get_SkinTemperature", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.SolarPanel" /> if the part is a solar panel, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_SolarPanel")]
    public SolarPanel GetSolarPanel ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<SolarPanel> ("SpaceCenter", "Part_get_SolarPanel", args);
    }

    /// <summary>
    /// Gets the stage in which this part will be activated. Returns -1 if the part is not
    /// activated by staging.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Stage")]
    public int GetStage ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<int> ("SpaceCenter", "Part_get_Stage", args);
    }

    /// <summary>
    /// Gets the name tag for the part. Can be set to a custom string using the
    /// in-game user interface.
    /// </summary>
    /// <remarks>
    /// This string is shared with
    /// <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/61827-/">kOS</a>
    /// if it is installed.
    /// </remarks>
    [Rpc ("SpaceCenter", "Part_get_Tag")]
    public string GetTag ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "Part_get_Tag", args);
    }

    /// <summary>
    /// Sets the name tag for the part. Can be set to a custom string using the
    /// in-game user interface.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTag (string value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Part_set_Tag", args);
    }

    /// <summary>
    /// Temperature of the part, in Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Temperature")]
    public double GetTemperature ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Part_get_Temperature", args);
    }

    /// <summary>
    /// Gets the rate at which heat energy is conducting into or out of the part via contact with
    /// other parts. Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part is gaining heat energy, and negative means it is
    /// losing heat energy.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ThermalConductionFlux")]
    public float GetThermalConductionFlux ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalConductionFlux", args);
    }

    /// <summary>
    /// Gets the rate at which heat energy is convecting into or out of the part from the
    /// surrounding atmosphere. Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part is gaining heat energy, and negative means it is
    /// losing heat energy.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ThermalConvectionFlux")]
    public float GetThermalConvectionFlux ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalConvectionFlux", args);
    }

    /// <summary>
    /// Gets the rate at which heat energy is begin generated by the part.
    /// For example, some engines generate heat by combusting fuel.
    /// Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part is gaining heat energy, and negative means it is losing
    /// heat energy.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ThermalInternalFlux")]
    public float GetThermalInternalFlux ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalInternalFlux", args);
    }

    /// <summary>
    /// Gets a measure of how much energy it takes to increase the internal temperature of the part,
    /// in Joules per Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ThermalMass")]
    public float GetThermalMass ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalMass", args);
    }

    /// <summary>
    /// Gets the rate at which heat energy is radiating into or out of the part from the surrounding
    /// environment. Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part is gaining heat energy, and negative means it is
    /// losing heat energy.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ThermalRadiationFlux")]
    public float GetThermalRadiationFlux ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalRadiationFlux", args);
    }

    /// <summary>
    /// Gets a measure of how much energy it takes to increase the temperature of the resources
    /// contained in the part, in Joules per Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ThermalResourceMass")]
    public float GetThermalResourceMass ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalResourceMass", args);
    }

    /// <summary>
    /// Gets a measure of how much energy it takes to increase the skin temperature of the part,
    /// in Joules per Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ThermalSkinMass")]
    public float GetThermalSkinMass ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalSkinMass", args);
    }

    /// <summary>
    /// Gets the rate at which heat energy is transferring between the part's skin and its internals.
    /// Measured in energy per unit time, or power, in Watts.
    /// A positive value means the part's internals are gaining heat energy,
    /// and negative means its skin is gaining heat energy.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_ThermalSkinToInternalFlux")]
    public float GetThermalSkinToInternalFlux ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Part_get_ThermalSkinToInternalFlux", args);
    }

    /// <summary>
    /// Title of the part, as shown when the part is right clicked in-game. For example "Mk1-2 Command Pod".
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Title")]
    public string GetTitle ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "Part_get_Title", args);
    }

    /// <summary>
    /// Gets the vessel that contains this part.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Vessel")]
    public Vessel GetVessel ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Vessel> ("SpaceCenter", "Part_get_Vessel", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Wheel" /> if the part is a wheel, otherwise <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Part_get_Wheel")]
    public Wheel GetWheel ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Wheel> ("SpaceCenter", "Part_get_Wheel", args);
    }
}
