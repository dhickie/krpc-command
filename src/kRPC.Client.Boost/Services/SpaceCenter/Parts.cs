using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

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
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> InDecoupleStage (int stage)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts)),
            global::KRPC.Client.Encoder.Encode (stage, typeof(int))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Parts_InDecoupleStage", _args);
        return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
    }

    /// <summary>
    /// A list of all parts that are activated in the given <paramref name="stage" />.
    /// </summary>
    /// <param name="stage"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_InStage")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> InStage (int stage)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts)),
            global::KRPC.Client.Encoder.Encode (stage, typeof(int))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Parts_InStage", _args);
        return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
    }

    /// <summary>
    /// A list of modules (combined across all parts in the vessel) whose
    /// <see cref="M:SpaceCenter.Module.Name" /> is <paramref name="moduleName" />.
    /// </summary>
    /// <param name="moduleName"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_ModulesWithName")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Module> ModulesWithName (string moduleName)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts)),
            global::KRPC.Client.Encoder.Encode (moduleName, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Parts_ModulesWithName", _args);
        return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Module>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Module>), connection);
    }

    /// <summary>
    /// A list of all parts that contain a <see cref="T:SpaceCenter.Module" /> whose
    /// <see cref="M:SpaceCenter.Module.Name" /> is <paramref name="moduleName" />.
    /// </summary>
    /// <param name="moduleName"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_WithModule")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> WithModule (string moduleName)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts)),
            global::KRPC.Client.Encoder.Encode (moduleName, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Parts_WithModule", _args);
        return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
    }

    /// <summary>
    /// A list of parts whose <see cref="M:SpaceCenter.Part.Name" /> is <paramref name="name" />.
    /// </summary>
    /// <param name="name"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_WithName")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> WithName (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Parts_WithName", _args);
        return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
    }

    /// <summary>
    /// A list of all parts whose <see cref="M:SpaceCenter.Part.Tag" /> is <paramref name="tag" />.
    /// </summary>
    /// <param name="tag"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_WithTag")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> WithTag (string tag)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts)),
            global::KRPC.Client.Encoder.Encode (tag, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Parts_WithTag", _args);
        return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
    }

    /// <summary>
    /// A list of all parts whose <see cref="M:SpaceCenter.Part.Title" /> is <paramref name="title" />.
    /// </summary>
    /// <param name="title"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_WithTitle")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> WithTitle (string title)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts)),
            global::KRPC.Client.Encoder.Encode (title, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Parts_WithTitle", _args);
        return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
    }

    /// <summary>
    /// A list of all of the vessels parts.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_All")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part> All {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_All", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Part>), connection);
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
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Antenna> Antennas {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Antennas", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Antenna>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Antenna>), connection);
        }
    }

    /// <summary>
    /// A list of all cargo bays in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_CargoBays")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.CargoBay> CargoBays {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_CargoBays", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.CargoBay>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.CargoBay>), connection);
        }
    }

    /// <summary>
    /// A list of all control surfaces in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ControlSurfaces")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface> ControlSurfaces {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ControlSurfaces", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ControlSurface>), connection);
        }
    }

    /// <summary>
    /// The part from which the vessel is controlled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Controlling")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Controlling {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Controlling", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
        set {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts)),
                global::KRPC.Client.Encoder.Encode (value, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
            };
            connection.Invoke ("SpaceCenter", "Parts_set_Controlling", _args);
        }
    }

    /// <summary>
    /// A list of all decouplers in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Decouplers")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler> Decouplers {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Decouplers", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Decoupler>), connection);
        }
    }

    /// <summary>
    /// A list of all docking ports in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_DockingPorts")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort> DockingPorts {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_DockingPorts", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.DockingPort>), connection);
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
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Engine> Engines {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Engines", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Engine>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Engine>), connection);
        }
    }

    /// <summary>
    /// A list of all science experiments in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Experiments")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Experiment> Experiments {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Experiments", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Experiment>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Experiment>), connection);
        }
    }

    /// <summary>
    /// A list of all fairings in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Fairings")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Fairing> Fairings {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Fairings", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Fairing>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Fairing>), connection);
        }
    }

    /// <summary>
    /// A list of all intakes in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Intakes")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Intake> Intakes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Intakes", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Intake>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Intake>), connection);
        }
    }

    /// <summary>
    /// A list of all launch clamps attached to the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_LaunchClamps")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.LaunchClamp> LaunchClamps {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_LaunchClamps", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.LaunchClamp>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.LaunchClamp>), connection);
        }
    }

    /// <summary>
    /// A list of all landing legs attached to the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Legs")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Leg> Legs {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Legs", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Leg>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Leg>), connection);
        }
    }

    /// <summary>
    /// A list of all lights in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Lights")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Light> Lights {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Lights", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Light>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Light>), connection);
        }
    }

    /// <summary>
    /// A list of all parachutes in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Parachutes")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Parachute> Parachutes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Parachutes", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Parachute>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Parachute>), connection);
        }
    }

    /// <summary>
    /// A list of all RCS blocks/thrusters in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RCS")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RCS> RCS {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RCS", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RCS>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RCS>), connection);
        }
    }

    /// <summary>
    /// A list of all radiators in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Radiators")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Radiator> Radiators {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Radiators", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Radiator>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Radiator>), connection);
        }
    }

    /// <summary>
    /// A list of all reaction wheels in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ReactionWheels")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel> ReactionWheels {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ReactionWheels", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel>), connection);
        }
    }

    /// <summary>
    /// A list of all resource converters in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ResourceConverters")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter> ResourceConverters {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ResourceConverters", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ResourceConverter>), connection);
        }
    }

    /// <summary>
    /// A list of all resource drains in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ResourceDrains")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain> ResourceDrains {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ResourceDrains", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ResourceDrain>), connection);
        }
    }

    /// <summary>
    /// A list of all resource harvesters in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_ResourceHarvesters")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester> ResourceHarvesters {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_ResourceHarvesters", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ResourceHarvester>), connection);
        }
    }

    /// <summary>
    /// A list of all robotic hinges in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RoboticHinges")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticHinge> RoboticHinges {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RoboticHinges", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticHinge>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticHinge>), connection);
        }
    }

    /// <summary>
    /// A list of all robotic pistons in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RoboticPistons")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston> RoboticPistons {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RoboticPistons", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticPiston>), connection);
        }
    }

    /// <summary>
    /// A list of all robotic rotations in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RoboticRotations")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation> RoboticRotations {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RoboticRotations", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotation>), connection);
        }
    }

    /// <summary>
    /// A list of all robotic rotors in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_RoboticRotors")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor> RoboticRotors {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_RoboticRotors", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.RoboticRotor>), connection);
        }
    }

    /// <summary>
    /// The vessels root part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Root")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Root {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Root", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }

    /// <summary>
    /// A list of all sensors in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Sensors")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Sensor> Sensors {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Sensors", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Sensor>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Sensor>), connection);
        }
    }

    /// <summary>
    /// A list of all solar panels in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_SolarPanels")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.SolarPanel> SolarPanels {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_SolarPanels", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.SolarPanel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.SolarPanel>), connection);
        }
    }

    /// <summary>
    /// A list of all wheels in the vessel.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Parts_get_Wheels")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Wheel> Wheels {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Parts))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Parts_get_Wheels", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Wheel>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Wheel>), connection);
        }
    }
}