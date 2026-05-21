using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Instances of this class are used to interact with the parts of a vessel.
/// An instance can be obtained by calling <see cref="M:SpaceCenter.Vessel.Parts" />.
/// </summary>
public class Parts : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Parts (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// A list of all parts that are decoupled in the given <paramref name="stage" />.
    /// </summary>
    /// <param name="stage"></param>
    [Rpc ("SpaceCenter", "Parts_InDecoupleStage")]
    public IList<Part> InDecoupleStage (int stage)
    {
        var args = new object[] {
            this,
            stage
        };
        return Connection.Invoke<IList<Part>> ("SpaceCenter", "Parts_InDecoupleStage", args);
    }

    /// <summary>
    /// A list of all parts that are activated in the given <paramref name="stage" />.
    /// </summary>
    /// <param name="stage"></param>
    [Rpc ("SpaceCenter", "Parts_InStage")]
    public IList<Part> InStage (int stage)
    {
        var args = new object[] {
            this,
            stage
        };
        return Connection.Invoke<IList<Part>> ("SpaceCenter", "Parts_InStage", args);
    }

    /// <summary>
    /// A list of modules (combined across all parts in the vessel) whose
    /// <see cref="M:SpaceCenter.Module.Name" /> is <paramref name="moduleName" />.
    /// </summary>
    /// <param name="moduleName"></param>
    [Rpc ("SpaceCenter", "Parts_ModulesWithName")]
    public IList<Module> ModulesWithName (string moduleName)
    {
        var args = new object[] {
            this,
            moduleName
        };
        return Connection.Invoke<IList<Module>> ("SpaceCenter", "Parts_ModulesWithName", args);
    }

    /// <summary>
    /// A list of all parts that contain a <see cref="T:SpaceCenter.Module" /> whose
    /// <see cref="M:SpaceCenter.Module.Name" /> is <paramref name="moduleName" />.
    /// </summary>
    /// <param name="moduleName"></param>
    [Rpc ("SpaceCenter", "Parts_WithModule")]
    public IList<Part> WithModule (string moduleName)
    {
        var args = new object[] {
            this,
            moduleName
        };
        return Connection.Invoke<IList<Part>> ("SpaceCenter", "Parts_WithModule", args);
    }

    /// <summary>
    /// A list of parts whose <see cref="M:SpaceCenter.Part.Name" /> is <paramref name="name" />.
    /// </summary>
    /// <param name="name"></param>
    [Rpc ("SpaceCenter", "Parts_WithName")]
    public IList<Part> WithName (string name)
    {
        var args = new object[] {
            this,
            name
        };
        return Connection.Invoke<IList<Part>> ("SpaceCenter", "Parts_WithName", args);
    }

    /// <summary>
    /// A list of all parts whose <see cref="M:SpaceCenter.Part.Tag" /> is <paramref name="tag" />.
    /// </summary>
    /// <param name="tag"></param>
    [Rpc ("SpaceCenter", "Parts_WithTag")]
    public IList<Part> WithTag (string tag)
    {
        var args = new object[] {
            this,
            tag
        };
        return Connection.Invoke<IList<Part>> ("SpaceCenter", "Parts_WithTag", args);
    }

    /// <summary>
    /// A list of all parts whose <see cref="M:SpaceCenter.Part.Title" /> is <paramref name="title" />.
    /// </summary>
    /// <param name="title"></param>
    [Rpc ("SpaceCenter", "Parts_WithTitle")]
    public IList<Part> WithTitle (string title)
    {
        var args = new object[] {
            this,
            title
        };
        return Connection.Invoke<IList<Part>> ("SpaceCenter", "Parts_WithTitle", args);
    }

    /// <summary>
    /// A list of all of the vessels parts.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_All")]
    public IList<Part> All {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Part>> ("SpaceCenter", "Parts_get_All", args);
        }
    }

    /// <summary>
    /// A list of all antennas in the vessel.
    /// </summary>
    /// <remarks>
    /// If RemoteTech is installed, this will always return an empty list.
    /// To interact with RemoteTech antennas, use the RemoteTech service APIs.
    /// </remarks>
    [Rpc ("SpaceCenter", "Parts_get_Antennas")]
    public IList<Antenna> Antennas {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Antenna>> ("SpaceCenter", "Parts_get_Antennas", args);
        }
    }

    /// <summary>
    /// A list of all cargo bays in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_CargoBays")]
    public IList<CargoBay> CargoBays {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<CargoBay>> ("SpaceCenter", "Parts_get_CargoBays", args);
        }
    }

    /// <summary>
    /// A list of all control surfaces in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_ControlSurfaces")]
    public IList<ControlSurface> ControlSurfaces {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<ControlSurface>> ("SpaceCenter", "Parts_get_ControlSurfaces", args);
        }
    }

    /// <summary>
    /// The part from which the vessel is controlled.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Controlling")]
    public Part Controlling {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Parts_get_Controlling", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Parts_set_Controlling", args);
        }
    }

    /// <summary>
    /// A list of all decouplers in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Decouplers")]
    public IList<Decoupler> Decouplers {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Decoupler>> ("SpaceCenter", "Parts_get_Decouplers", args);
        }
    }

    /// <summary>
    /// A list of all docking ports in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_DockingPorts")]
    public IList<DockingPort> DockingPorts {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<DockingPort>> ("SpaceCenter", "Parts_get_DockingPorts", args);
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
    [Rpc ("SpaceCenter", "Parts_get_Engines")]
    public IList<Engine> Engines {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Engine>> ("SpaceCenter", "Parts_get_Engines", args);
        }
    }

    /// <summary>
    /// A list of all science experiments in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Experiments")]
    public IList<Experiment> Experiments {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Experiment>> ("SpaceCenter", "Parts_get_Experiments", args);
        }
    }

    /// <summary>
    /// A list of all fairings in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Fairings")]
    public IList<Fairing> Fairings {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Fairing>> ("SpaceCenter", "Parts_get_Fairings", args);
        }
    }

    /// <summary>
    /// A list of all intakes in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Intakes")]
    public IList<Intake> Intakes {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Intake>> ("SpaceCenter", "Parts_get_Intakes", args);
        }
    }

    /// <summary>
    /// A list of all launch clamps attached to the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_LaunchClamps")]
    public IList<LaunchClamp> LaunchClamps {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<LaunchClamp>> ("SpaceCenter", "Parts_get_LaunchClamps", args);
        }
    }

    /// <summary>
    /// A list of all landing legs attached to the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Legs")]
    public IList<Leg> Legs {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Leg>> ("SpaceCenter", "Parts_get_Legs", args);
        }
    }

    /// <summary>
    /// A list of all lights in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Lights")]
    public IList<Light> Lights {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Light>> ("SpaceCenter", "Parts_get_Lights", args);
        }
    }

    /// <summary>
    /// A list of all parachutes in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Parachutes")]
    public IList<Parachute> Parachutes {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Parachute>> ("SpaceCenter", "Parts_get_Parachutes", args);
        }
    }

    /// <summary>
    /// A list of all RCS blocks/thrusters in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_RCS")]
    public IList<RCS> RCS {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<RCS>> ("SpaceCenter", "Parts_get_RCS", args);
        }
    }

    /// <summary>
    /// A list of all radiators in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Radiators")]
    public IList<Radiator> Radiators {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Radiator>> ("SpaceCenter", "Parts_get_Radiators", args);
        }
    }

    /// <summary>
    /// A list of all reaction wheels in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_ReactionWheels")]
    public IList<ReactionWheel> ReactionWheels {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<ReactionWheel>> ("SpaceCenter", "Parts_get_ReactionWheels", args);
        }
    }

    /// <summary>
    /// A list of all resource converters in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_ResourceConverters")]
    public IList<ResourceConverter> ResourceConverters {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<ResourceConverter>> ("SpaceCenter", "Parts_get_ResourceConverters", args);
        }
    }

    /// <summary>
    /// A list of all resource drains in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_ResourceDrains")]
    public IList<ResourceDrain> ResourceDrains {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<ResourceDrain>> ("SpaceCenter", "Parts_get_ResourceDrains", args);
        }
    }

    /// <summary>
    /// A list of all resource harvesters in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_ResourceHarvesters")]
    public IList<ResourceHarvester> ResourceHarvesters {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<ResourceHarvester>> ("SpaceCenter", "Parts_get_ResourceHarvesters", args);
        }
    }

    /// <summary>
    /// A list of all robotic hinges in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_RoboticHinges")]
    public IList<RoboticHinge> RoboticHinges {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<RoboticHinge>> ("SpaceCenter", "Parts_get_RoboticHinges", args);
        }
    }

    /// <summary>
    /// A list of all robotic pistons in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_RoboticPistons")]
    public IList<RoboticPiston> RoboticPistons {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<RoboticPiston>> ("SpaceCenter", "Parts_get_RoboticPistons", args);
        }
    }

    /// <summary>
    /// A list of all robotic rotations in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_RoboticRotations")]
    public IList<RoboticRotation> RoboticRotations {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<RoboticRotation>> ("SpaceCenter", "Parts_get_RoboticRotations", args);
        }
    }

    /// <summary>
    /// A list of all robotic rotors in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_RoboticRotors")]
    public IList<RoboticRotor> RoboticRotors {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<RoboticRotor>> ("SpaceCenter", "Parts_get_RoboticRotors", args);
        }
    }

    /// <summary>
    /// The vessels root part.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Root")]
    public Part Root {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Parts_get_Root", args);
        }
    }

    /// <summary>
    /// A list of all sensors in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Sensors")]
    public IList<Sensor> Sensors {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Sensor>> ("SpaceCenter", "Parts_get_Sensors", args);
        }
    }

    /// <summary>
    /// A list of all solar panels in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_SolarPanels")]
    public IList<SolarPanel> SolarPanels {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<SolarPanel>> ("SpaceCenter", "Parts_get_SolarPanels", args);
        }
    }

    /// <summary>
    /// A list of all wheels in the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Parts_get_Wheels")]
    public IList<Wheel> Wheels {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Wheel>> ("SpaceCenter", "Parts_get_Wheels", args);
        }
    }
}
