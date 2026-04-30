using BaseParts = KRPC.Client.Services.SpaceCenter.Parts;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Parts object.
/// </summary>
public class Parts
{
    internal readonly BaseParts Wrapped;

    internal Parts(BaseParts parts)
    {
        Wrapped = parts;
    }

    public IList<Part> All
        => Wrapped.All.Select(item => new Part(item)).ToList();

    public IList<Antenna> Antennas
        => Wrapped.Antennas.Select(item => new Antenna(item)).ToList();

    public IList<CargoBay> CargoBays
        => Wrapped.CargoBays.Select(item => new CargoBay(item)).ToList();

    public IList<ControlSurface> ControlSurfaces
        => Wrapped.ControlSurfaces.Select(item => new ControlSurface(item)).ToList();

    public Part Controlling
    {
        get => new Part(Wrapped.Controlling);
        set => Wrapped.Controlling = value.Wrapped;
    }

    public IList<Decoupler> Decouplers
        => Wrapped.Decouplers.Select(item => new Decoupler(item)).ToList();

    public IList<DockingPort> DockingPorts
        => Wrapped.DockingPorts.Select(item => new DockingPort(item)).ToList();

    public IList<Engine> Engines
        => Wrapped.Engines.Select(item => new Engine(item)).ToList();

    public IList<Experiment> Experiments
        => Wrapped.Experiments.Select(item => new Experiment(item)).ToList();

    public IList<Fairing> Fairings
        => Wrapped.Fairings.Select(item => new Fairing(item)).ToList();

    public IList<Intake> Intakes
        => Wrapped.Intakes.Select(item => new Intake(item)).ToList();

    public IList<LaunchClamp> LaunchClamps
        => Wrapped.LaunchClamps.Select(item => new LaunchClamp(item)).ToList();

    public IList<Leg> Legs
        => Wrapped.Legs.Select(item => new Leg(item)).ToList();

    public IList<Light> Lights
        => Wrapped.Lights.Select(item => new Light(item)).ToList();

    public IList<Parachute> Parachutes
        => Wrapped.Parachutes.Select(item => new Parachute(item)).ToList();

    public IList<RCS> RCS
        => Wrapped.RCS.Select(item => new RCS(item)).ToList();

    public IList<Radiator> Radiators
        => Wrapped.Radiators.Select(item => new Radiator(item)).ToList();

    public IList<ReactionWheel> ReactionWheels
        => Wrapped.ReactionWheels.Select(item => new ReactionWheel(item)).ToList();

    public IList<ResourceConverter> ResourceConverters
        => Wrapped.ResourceConverters.Select(item => new ResourceConverter(item)).ToList();

    public IList<ResourceDrain> ResourceDrains
        => Wrapped.ResourceDrains.Select(item => new ResourceDrain(item)).ToList();

    public IList<ResourceHarvester> ResourceHarvesters
        => Wrapped.ResourceHarvesters.Select(item => new ResourceHarvester(item)).ToList();

    public IList<RoboticHinge> RoboticHinges
        => Wrapped.RoboticHinges.Select(item => new RoboticHinge(item)).ToList();

    public IList<RoboticPiston> RoboticPistons
        => Wrapped.RoboticPistons.Select(item => new RoboticPiston(item)).ToList();

    public IList<RoboticRotation> RoboticRotations
        => Wrapped.RoboticRotations.Select(item => new RoboticRotation(item)).ToList();

    public IList<RoboticRotor> RoboticRotors
        => Wrapped.RoboticRotors.Select(item => new RoboticRotor(item)).ToList();

    public Part Root
        => new Part(Wrapped.Root);

    public IList<Sensor> Sensors
        => Wrapped.Sensors.Select(item => new Sensor(item)).ToList();

    public IList<SolarPanel> SolarPanels
        => Wrapped.SolarPanels.Select(item => new SolarPanel(item)).ToList();

    public IList<Wheel> Wheels
        => Wrapped.Wheels.Select(item => new Wheel(item)).ToList();

    public IList<Part> InDecoupleStage(int stage)
        => Wrapped.InDecoupleStage(stage).Select(item => new Part(item)).ToList();

    public IList<Part> InStage(int stage)
        => Wrapped.InStage(stage).Select(item => new Part(item)).ToList();

    public IList<Module> ModulesWithName(string moduleName)
        => Wrapped.ModulesWithName(moduleName).Select(item => new Module(item)).ToList();

    public IList<Part> WithModule(string moduleName)
        => Wrapped.WithModule(moduleName).Select(item => new Part(item)).ToList();

    public IList<Part> WithName(string name)
        => Wrapped.WithName(name).Select(item => new Part(item)).ToList();

    public IList<Part> WithTag(string tag)
        => Wrapped.WithTag(tag).Select(item => new Part(item)).ToList();

    public IList<Part> WithTitle(string title)
        => Wrapped.WithTitle(title).Select(item => new Part(item)).ToList();
}
