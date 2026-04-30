using BaseParts = KRPC.Client.Services.SpaceCenter.Parts;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Parts object.
/// </summary>
public class Parts
{
    internal BaseParts Internal { get; }

    internal Parts(BaseParts parts)
    {
        Internal = parts;
    }
    public IList<Part> All
        => Internal.All.Select(item => new Part(item)).ToList();
    public IList<Antenna> Antennas
        => Internal.Antennas.Select(item => new Antenna(item)).ToList();
    public IList<CargoBay> CargoBays
        => Internal.CargoBays.Select(item => new CargoBay(item)).ToList();
    public IList<ControlSurface> ControlSurfaces
        => Internal.ControlSurfaces.Select(item => new ControlSurface(item)).ToList();
    public Part Controlling
    {
        get => new Part(Internal.Controlling);
        set => Internal.Controlling = value.Internal;
    }
    public IList<Decoupler> Decouplers
        => Internal.Decouplers.Select(item => new Decoupler(item)).ToList();
    public IList<DockingPort> DockingPorts
        => Internal.DockingPorts.Select(item => new DockingPort(item)).ToList();
    public IList<Engine> Engines
        => Internal.Engines.Select(item => new Engine(item)).ToList();
    public IList<Experiment> Experiments
        => Internal.Experiments.Select(item => new Experiment(item)).ToList();
    public IList<Fairing> Fairings
        => Internal.Fairings.Select(item => new Fairing(item)).ToList();
    public IList<Intake> Intakes
        => Internal.Intakes.Select(item => new Intake(item)).ToList();
    public IList<LaunchClamp> LaunchClamps
        => Internal.LaunchClamps.Select(item => new LaunchClamp(item)).ToList();
    public IList<Leg> Legs
        => Internal.Legs.Select(item => new Leg(item)).ToList();
    public IList<Light> Lights
        => Internal.Lights.Select(item => new Light(item)).ToList();
    public IList<Parachute> Parachutes
        => Internal.Parachutes.Select(item => new Parachute(item)).ToList();
    public IList<RCS> RCS
        => Internal.RCS.Select(item => new RCS(item)).ToList();
    public IList<Radiator> Radiators
        => Internal.Radiators.Select(item => new Radiator(item)).ToList();
    public IList<ReactionWheel> ReactionWheels
        => Internal.ReactionWheels.Select(item => new ReactionWheel(item)).ToList();
    public IList<ResourceConverter> ResourceConverters
        => Internal.ResourceConverters.Select(item => new ResourceConverter(item)).ToList();
    public IList<ResourceDrain> ResourceDrains
        => Internal.ResourceDrains.Select(item => new ResourceDrain(item)).ToList();
    public IList<ResourceHarvester> ResourceHarvesters
        => Internal.ResourceHarvesters.Select(item => new ResourceHarvester(item)).ToList();
    public IList<RoboticHinge> RoboticHinges
        => Internal.RoboticHinges.Select(item => new RoboticHinge(item)).ToList();
    public IList<RoboticPiston> RoboticPistons
        => Internal.RoboticPistons.Select(item => new RoboticPiston(item)).ToList();
    public IList<RoboticRotation> RoboticRotations
        => Internal.RoboticRotations.Select(item => new RoboticRotation(item)).ToList();
    public IList<RoboticRotor> RoboticRotors
        => Internal.RoboticRotors.Select(item => new RoboticRotor(item)).ToList();
    public Part Root
        => new Part(Internal.Root);
    public IList<Sensor> Sensors
        => Internal.Sensors.Select(item => new Sensor(item)).ToList();
    public IList<SolarPanel> SolarPanels
        => Internal.SolarPanels.Select(item => new SolarPanel(item)).ToList();
    public IList<Wheel> Wheels
        => Internal.Wheels.Select(item => new Wheel(item)).ToList();
    public IList<Part> InDecoupleStage(int stage)
        => Internal.InDecoupleStage(stage).Select(item => new Part(item)).ToList();
    public IList<Part> InStage(int stage)
        => Internal.InStage(stage).Select(item => new Part(item)).ToList();
    public IList<Module> ModulesWithName(string moduleName)
        => Internal.ModulesWithName(moduleName).Select(item => new Module(item)).ToList();
    public IList<Part> WithModule(string moduleName)
        => Internal.WithModule(moduleName).Select(item => new Part(item)).ToList();
    public IList<Part> WithName(string name)
        => Internal.WithName(name).Select(item => new Part(item)).ToList();
    public IList<Part> WithTag(string tag)
        => Internal.WithTag(tag).Select(item => new Part(item)).ToList();
    public IList<Part> WithTitle(string title)
        => Internal.WithTitle(title).Select(item => new Part(item)).ToList();
}
