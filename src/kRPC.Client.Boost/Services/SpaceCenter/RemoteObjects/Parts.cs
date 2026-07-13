using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Instances of this class are used to interact with the parts of a vessel.
/// An instance can be obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Vessel.GetParts" />.
/// </summary>
public class Parts : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal Parts(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// A list of all parts that are decoupled in the given <paramref name="stage" />.
    /// </summary>
    /// <param name="stage"></param>
    [GetRpc("SpaceCenter", "Parts_InDecoupleStage")]
    public List<Part> GetPartsInDecoupleStage(int stage)
    {
        var args = new ProcedureArgument[]
        {
            this,
            stage
        };
        return InvokeNonNullable<List<Part>>("SpaceCenter", "Parts_InDecoupleStage", args);
    }

    /// <summary>
    /// A list of all parts that are decoupled in the given <paramref name="stage" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="stage"></param>
    [GetRpc("SpaceCenter", "Parts_InDecoupleStage")]
    public async Task<List<Part>> GetPartsInDecoupleStageAsync(int stage)
    {
        var args = new ProcedureArgument[]
        {
            this,
            stage
        };
        return await InvokeNonNullableAsync<List<Part>>("SpaceCenter", "Parts_InDecoupleStage", args);
    }

    /// <summary>
    /// A list of all parts that are activated in the given <paramref name="stage" />.
    /// </summary>
    /// <param name="stage"></param>
    [GetRpc("SpaceCenter", "Parts_InStage")]
    public List<Part> GetPartsInStage(int stage)
    {
        var args = new ProcedureArgument[]
        {
            this,
            stage
        };
        return InvokeNonNullable<List<Part>>("SpaceCenter", "Parts_InStage", args);
    }

    /// <summary>
    /// A list of all parts that are activated in the given <paramref name="stage" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="stage"></param>
    [GetRpc("SpaceCenter", "Parts_InStage")]
    public async Task<List<Part>> GetPartsInStageAsync(int stage)
    {
        var args = new ProcedureArgument[]
        {
            this,
            stage
        };
        return await InvokeNonNullableAsync<List<Part>>("SpaceCenter", "Parts_InStage", args);
    }

    /// <summary>
    /// A list of modules (combined across all parts in the vessel) whose
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Module.GetName" /> is <paramref name="moduleName" />.
    /// </summary>
    /// <param name="moduleName"></param>
    [GetRpc("SpaceCenter", "Parts_ModulesWithName")]
    public List<Module> GetModulesWithName(string moduleName)
    {
        var args = new ProcedureArgument[]
        {
            this,
            moduleName
        };
        return InvokeNonNullable<List<Module>>("SpaceCenter", "Parts_ModulesWithName", args);
    }

    /// <summary>
    /// A list of modules (combined across all parts in the vessel) whose
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Module.GetName" /> is <paramref name="moduleName" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="moduleName"></param>
    [GetRpc("SpaceCenter", "Parts_ModulesWithName")]
    public async Task<List<Module>> GetModulesWithNameAsync(string moduleName)
    {
        var args = new ProcedureArgument[]
        {
            this,
            moduleName
        };
        return await InvokeNonNullableAsync<List<Module>>("SpaceCenter", "Parts_ModulesWithName", args);
    }

    /// <summary>
    /// A list of all parts that contain a <see cref="T:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Module" /> whose
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Module.GetName" /> is <paramref name="moduleName" />.
    /// </summary>
    /// <param name="moduleName"></param>
    [GetRpc("SpaceCenter", "Parts_WithModule")]
    public List<Part> GetPartsWithModule(string moduleName)
    {
        var args = new ProcedureArgument[]
        {
            this,
            moduleName
        };
        return InvokeNonNullable<List<Part>>("SpaceCenter", "Parts_WithModule", args);
    }

    /// <summary>
    /// A list of all parts that contain a <see cref="T:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Module" /> whose
    /// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Module.GetName" /> is <paramref name="moduleName" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="moduleName"></param>
    [GetRpc("SpaceCenter", "Parts_WithModule")]
    public async Task<List<Part>> GetPartsWithModuleAsync(string moduleName)
    {
        var args = new ProcedureArgument[]
        {
            this,
            moduleName
        };
        return await InvokeNonNullableAsync<List<Part>>("SpaceCenter", "Parts_WithModule", args);
    }

    /// <summary>
    /// A list of parts whose <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetName" /> is <paramref name="name" />.
    /// </summary>
    /// <param name="name"></param>
    [GetRpc("SpaceCenter", "Parts_WithName")]
    public List<Part> GetPartsWithName(string name)
    {
        var args = new ProcedureArgument[]
        {
            this,
            name
        };
        return InvokeNonNullable<List<Part>>("SpaceCenter", "Parts_WithName", args);
    }

    /// <summary>
    /// A list of parts whose <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetName" /> is <paramref name="name" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name"></param>
    [GetRpc("SpaceCenter", "Parts_WithName")]
    public async Task<List<Part>> GetPartsWithNameAsync(string name)
    {
        var args = new ProcedureArgument[]
        {
            this,
            name
        };
        return await InvokeNonNullableAsync<List<Part>>("SpaceCenter", "Parts_WithName", args);
    }

    /// <summary>
    /// A list of all parts whose <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetTag" /> is <paramref name="tag" />.
    /// </summary>
    /// <param name="tag"></param>
    [GetRpc("SpaceCenter", "Parts_WithTag")]
    public List<Part> GetPartsWithTag(string tag)
    {
        var args = new ProcedureArgument[]
        {
            this,
            tag
        };
        return InvokeNonNullable<List<Part>>("SpaceCenter", "Parts_WithTag", args);
    }

    /// <summary>
    /// A list of all parts whose <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetTag" /> is <paramref name="tag" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="tag"></param>
    [GetRpc("SpaceCenter", "Parts_WithTag")]
    public async Task<List<Part>> GetPartsWithTagAsync(string tag)
    {
        var args = new ProcedureArgument[]
        {
            this,
            tag
        };
        return await InvokeNonNullableAsync<List<Part>>("SpaceCenter", "Parts_WithTag", args);
    }

    /// <summary>
    /// A list of all parts whose <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetTitle" /> is <paramref name="title" />.
    /// </summary>
    /// <param name="title"></param>
    [GetRpc("SpaceCenter", "Parts_WithTitle")]
    public List<Part> GetPartsWithTitle(string title)
    {
        var args = new ProcedureArgument[]
        {
            this,
            title
        };
        return InvokeNonNullable<List<Part>>("SpaceCenter", "Parts_WithTitle", args);
    }

    /// <summary>
    /// A list of all parts whose <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetTitle" /> is <paramref name="title" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="title"></param>
    [GetRpc("SpaceCenter", "Parts_WithTitle")]
    public async Task<List<Part>> GetPartsWithTitleAsync(string title)
    {
        var args = new ProcedureArgument[]
        {
            this,
            title
        };
        return await InvokeNonNullableAsync<List<Part>>("SpaceCenter", "Parts_WithTitle", args);
    }

    /// <summary>
    /// Gets a list of all of the vessels parts.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_All")]
    public List<Part> GetAll()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Part>>("SpaceCenter", "Parts_get_All", args);
    }

    /// <summary>
    /// Gets a list of all of the vessels parts.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_All")]
    public async Task<List<Part>> GetAllAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Part>>("SpaceCenter", "Parts_get_All", args);
    }

    /// <summary>
    /// Gets a list of all antennas in the vessel.
    /// </summary>
    /// <remarks>
    /// If RemoteTech is installed, this will always return an empty list.
    /// To interact with RemoteTech antennas, use the RemoteTech service APIs.
    /// </remarks>
    [GetRpc("SpaceCenter", "Parts_get_Antennas")]
    public List<Antenna> GetAntennas()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Antenna>>("SpaceCenter", "Parts_get_Antennas", args);
    }

    /// <summary>
    /// Gets a list of all antennas in the vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// If RemoteTech is installed, this will always return an empty list.
    /// To interact with RemoteTech antennas, use the RemoteTech service APIs.
    /// </remarks>
    [GetRpc("SpaceCenter", "Parts_get_Antennas")]
    public async Task<List<Antenna>> GetAntennasAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Antenna>>("SpaceCenter", "Parts_get_Antennas", args);
    }

    /// <summary>
    /// Gets a list of all cargo bays in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_CargoBays")]
    public List<CargoBay> GetCargoBays()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<CargoBay>>("SpaceCenter", "Parts_get_CargoBays", args);
    }

    /// <summary>
    /// Gets a list of all cargo bays in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_CargoBays")]
    public async Task<List<CargoBay>> GetCargoBaysAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<CargoBay>>("SpaceCenter", "Parts_get_CargoBays", args);
    }

    /// <summary>
    /// Gets a list of all control surfaces in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ControlSurfaces")]
    public List<ControlSurface> GetControlSurfaces()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<ControlSurface>>("SpaceCenter", "Parts_get_ControlSurfaces", args);
    }

    /// <summary>
    /// Gets a list of all control surfaces in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ControlSurfaces")]
    public async Task<List<ControlSurface>> GetControlSurfacesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<ControlSurface>>("SpaceCenter", "Parts_get_ControlSurfaces", args);
    }

    /// <summary>
    /// Gets the part from which the vessel is controlled.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Controlling")]
    public Part GetControlling()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "Parts_get_Controlling", args);
    }

    /// <summary>
    /// Gets the part from which the vessel is controlled.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Controlling")]
    public async Task<Part> GetControllingAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "Parts_get_Controlling", args);
    }

    /// <summary>
    /// Sets the part from which the vessel is controlled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Parts_set_Controlling")]
    public void SetControlling(Part value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "Parts_set_Controlling", args);
    }

    /// <summary>
    /// Sets the part from which the vessel is controlled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Parts_set_Controlling")]
    public async Task SetControllingAsync(Part value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "Parts_set_Controlling", args);
    }

    /// <summary>
    /// Gets a list of all decouplers in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Decouplers")]
    public List<Decoupler> GetDecouplers()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Decoupler>>("SpaceCenter", "Parts_get_Decouplers", args);
    }

    /// <summary>
    /// Gets a list of all decouplers in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Decouplers")]
    public async Task<List<Decoupler>> GetDecouplersAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Decoupler>>("SpaceCenter", "Parts_get_Decouplers", args);
    }

    /// <summary>
    /// Gets a list of all docking ports in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_DockingPorts")]
    public List<DockingPort> GetDockingPorts()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<DockingPort>>("SpaceCenter", "Parts_get_DockingPorts", args);
    }

    /// <summary>
    /// Gets a list of all docking ports in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_DockingPorts")]
    public async Task<List<DockingPort>> GetDockingPortsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<DockingPort>>("SpaceCenter", "Parts_get_DockingPorts", args);
    }

    /// <summary>
    /// Gets a list of all engines in the vessel.
    /// </summary>
    /// <remarks>
    /// This includes any part that generates thrust. This covers many different types
    /// of engine, including liquid fuel rockets, solid rocket boosters, jet engines and
    /// RCS thrusters.
    /// </remarks>
    [GetRpc("SpaceCenter", "Parts_get_Engines")]
    public List<Engine> GetEngines()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Engine>>("SpaceCenter", "Parts_get_Engines", args);
    }

    /// <summary>
    /// Gets a list of all engines in the vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This includes any part that generates thrust. This covers many different types
    /// of engine, including liquid fuel rockets, solid rocket boosters, jet engines and
    /// RCS thrusters.
    /// </remarks>
    [GetRpc("SpaceCenter", "Parts_get_Engines")]
    public async Task<List<Engine>> GetEnginesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Engine>>("SpaceCenter", "Parts_get_Engines", args);
    }

    /// <summary>
    /// Gets a list of all science experiments in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Experiments")]
    public List<Experiment> GetExperiments()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Experiment>>("SpaceCenter", "Parts_get_Experiments", args);
    }

    /// <summary>
    /// Gets a list of all science experiments in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Experiments")]
    public async Task<List<Experiment>> GetExperimentsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Experiment>>("SpaceCenter", "Parts_get_Experiments", args);
    }

    /// <summary>
    /// Gets a list of all fairings in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Fairings")]
    public List<Fairing> GetFairings()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Fairing>>("SpaceCenter", "Parts_get_Fairings", args);
    }

    /// <summary>
    /// Gets a list of all fairings in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Fairings")]
    public async Task<List<Fairing>> GetFairingsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Fairing>>("SpaceCenter", "Parts_get_Fairings", args);
    }

    /// <summary>
    /// Gets a list of all intakes in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Intakes")]
    public List<Intake> GetIntakes()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Intake>>("SpaceCenter", "Parts_get_Intakes", args);
    }

    /// <summary>
    /// Gets a list of all intakes in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Intakes")]
    public async Task<List<Intake>> GetIntakesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Intake>>("SpaceCenter", "Parts_get_Intakes", args);
    }

    /// <summary>
    /// Gets a list of all launch clamps attached to the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_LaunchClamps")]
    public List<LaunchClamp> GetLaunchClamps()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<LaunchClamp>>("SpaceCenter", "Parts_get_LaunchClamps", args);
    }

    /// <summary>
    /// Gets a list of all launch clamps attached to the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_LaunchClamps")]
    public async Task<List<LaunchClamp>> GetLaunchClampsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<LaunchClamp>>("SpaceCenter", "Parts_get_LaunchClamps", args);
    }

    /// <summary>
    /// Gets a list of all landing legs attached to the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Legs")]
    public List<Leg> GetLegs()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Leg>>("SpaceCenter", "Parts_get_Legs", args);
    }

    /// <summary>
    /// Gets a list of all landing legs attached to the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Legs")]
    public async Task<List<Leg>> GetLegsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Leg>>("SpaceCenter", "Parts_get_Legs", args);
    }

    /// <summary>
    /// Gets a list of all lights in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Lights")]
    public List<Light> GetLights()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Light>>("SpaceCenter", "Parts_get_Lights", args);
    }

    /// <summary>
    /// Gets a list of all lights in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Lights")]
    public async Task<List<Light>> GetLightsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Light>>("SpaceCenter", "Parts_get_Lights", args);
    }

    /// <summary>
    /// Gets a list of all parachutes in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Parachutes")]
    public List<Parachute> GetParachutes()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Parachute>>("SpaceCenter", "Parts_get_Parachutes", args);
    }

    /// <summary>
    /// Gets a list of all parachutes in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Parachutes")]
    public async Task<List<Parachute>> GetParachutesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Parachute>>("SpaceCenter", "Parts_get_Parachutes", args);
    }

    /// <summary>
    /// Gets a list of all RCS blocks/thrusters in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RCS")]
    public List<RCS> GetRCS()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<RCS>>("SpaceCenter", "Parts_get_RCS", args);
    }

    /// <summary>
    /// Gets a list of all RCS blocks/thrusters in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RCS")]
    public async Task<List<RCS>> GetRCSAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<RCS>>("SpaceCenter", "Parts_get_RCS", args);
    }

    /// <summary>
    /// Gets a list of all radiators in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Radiators")]
    public List<Radiator> GetRadiators()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Radiator>>("SpaceCenter", "Parts_get_Radiators", args);
    }

    /// <summary>
    /// Gets a list of all radiators in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Radiators")]
    public async Task<List<Radiator>> GetRadiatorsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Radiator>>("SpaceCenter", "Parts_get_Radiators", args);
    }

    /// <summary>
    /// Gets a list of all reaction wheels in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ReactionWheels")]
    public List<ReactionWheel> GetReactionWheels()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<ReactionWheel>>("SpaceCenter", "Parts_get_ReactionWheels", args);
    }

    /// <summary>
    /// Gets a list of all reaction wheels in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ReactionWheels")]
    public async Task<List<ReactionWheel>> GetReactionWheelsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<ReactionWheel>>("SpaceCenter", "Parts_get_ReactionWheels", args);
    }

    /// <summary>
    /// Gets a list of all resource converters in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ResourceConverters")]
    public List<ResourceConverter> GetResourceConverters()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<ResourceConverter>>("SpaceCenter", "Parts_get_ResourceConverters", args);
    }

    /// <summary>
    /// Gets a list of all resource converters in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ResourceConverters")]
    public async Task<List<ResourceConverter>> GetResourceConvertersAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<ResourceConverter>>("SpaceCenter", "Parts_get_ResourceConverters", args);
    }

    /// <summary>
    /// Gets a list of all resource drains in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ResourceDrains")]
    public List<ResourceDrain> GetResourceDrains()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<ResourceDrain>>("SpaceCenter", "Parts_get_ResourceDrains", args);
    }

    /// <summary>
    /// Gets a list of all resource drains in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ResourceDrains")]
    public async Task<List<ResourceDrain>> GetResourceDrainsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<ResourceDrain>>("SpaceCenter", "Parts_get_ResourceDrains", args);
    }

    /// <summary>
    /// Gets a list of all resource harvesters in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ResourceHarvesters")]
    public List<ResourceHarvester> GetResourceHarvesters()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<ResourceHarvester>>("SpaceCenter", "Parts_get_ResourceHarvesters", args);
    }

    /// <summary>
    /// Gets a list of all resource harvesters in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_ResourceHarvesters")]
    public async Task<List<ResourceHarvester>> GetResourceHarvestersAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<ResourceHarvester>>("SpaceCenter", "Parts_get_ResourceHarvesters", args);
    }

    /// <summary>
    /// Gets a list of all robotic hinges in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RoboticHinges")]
    public List<RoboticHinge> GetRoboticHinges()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<RoboticHinge>>("SpaceCenter", "Parts_get_RoboticHinges", args);
    }

    /// <summary>
    /// Gets a list of all robotic hinges in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RoboticHinges")]
    public async Task<List<RoboticHinge>> GetRoboticHingesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<RoboticHinge>>("SpaceCenter", "Parts_get_RoboticHinges", args);
    }

    /// <summary>
    /// Gets a list of all robotic pistons in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RoboticPistons")]
    public List<RoboticPiston> GetRoboticPistons()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<RoboticPiston>>("SpaceCenter", "Parts_get_RoboticPistons", args);
    }

    /// <summary>
    /// Gets a list of all robotic pistons in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RoboticPistons")]
    public async Task<List<RoboticPiston>> GetRoboticPistonsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<RoboticPiston>>("SpaceCenter", "Parts_get_RoboticPistons", args);
    }

    /// <summary>
    /// Gets a list of all robotic rotations in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RoboticRotations")]
    public List<RoboticRotation> GetRoboticRotations()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<RoboticRotation>>("SpaceCenter", "Parts_get_RoboticRotations", args);
    }

    /// <summary>
    /// Gets a list of all robotic rotations in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RoboticRotations")]
    public async Task<List<RoboticRotation>> GetRoboticRotationsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<RoboticRotation>>("SpaceCenter", "Parts_get_RoboticRotations", args);
    }

    /// <summary>
    /// Gets a list of all robotic rotors in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RoboticRotors")]
    public List<RoboticRotor> GetRoboticRotors()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<RoboticRotor>>("SpaceCenter", "Parts_get_RoboticRotors", args);
    }

    /// <summary>
    /// Gets a list of all robotic rotors in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_RoboticRotors")]
    public async Task<List<RoboticRotor>> GetRoboticRotorsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<RoboticRotor>>("SpaceCenter", "Parts_get_RoboticRotors", args);
    }

    /// <summary>
    /// Gets the vessels root part.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Root")]
    public Part GetRoot()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "Parts_get_Root", args);
    }

    /// <summary>
    /// Gets the vessels root part.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Root")]
    public async Task<Part> GetRootAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "Parts_get_Root", args);
    }

    /// <summary>
    /// Gets a list of all sensors in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Sensors")]
    public List<Sensor> GetSensors()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Sensor>>("SpaceCenter", "Parts_get_Sensors", args);
    }

    /// <summary>
    /// Gets a list of all sensors in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Sensors")]
    public async Task<List<Sensor>> GetSensorsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Sensor>>("SpaceCenter", "Parts_get_Sensors", args);
    }

    /// <summary>
    /// Gets a list of all solar panels in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_SolarPanels")]
    public List<SolarPanel> GetSolarPanels()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<SolarPanel>>("SpaceCenter", "Parts_get_SolarPanels", args);
    }

    /// <summary>
    /// Gets a list of all solar panels in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_SolarPanels")]
    public async Task<List<SolarPanel>> GetSolarPanelsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<SolarPanel>>("SpaceCenter", "Parts_get_SolarPanels", args);
    }

    /// <summary>
    /// Gets a list of all wheels in the vessel.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Wheels")]
    public List<Wheel> GetWheels()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Wheel>>("SpaceCenter", "Parts_get_Wheels", args);
    }

    /// <summary>
    /// Gets a list of all wheels in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Parts_get_Wheels")]
    public async Task<List<Wheel>> GetWheelsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Wheel>>("SpaceCenter", "Parts_get_Wheels", args);
    }
}
