using KRPC.Client.Services.SpaceCenter;
using BasePart = KRPC.Client.Services.SpaceCenter.Part;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Part object.
/// </summary>
public class Part
{
    internal readonly BasePart Wrapped;

    internal Part(BasePart part)
    {
        Wrapped = part;
    }

    public Antenna Antenna
        => new Antenna(Wrapped.Antenna);

    public AutoStrutMode AutoStrutMode
        => Wrapped.AutoStrutMode;

    public uint AvailableSeats
        => Wrapped.AvailableSeats;

    public bool AxiallyAttached
        => Wrapped.AxiallyAttached;

    public CargoBay CargoBay
        => new CargoBay(Wrapped.CargoBay);

    public ReferenceFrame CenterOfMassReferenceFrame
        => new ReferenceFrame(Wrapped.CenterOfMassReferenceFrame);

    public IList<Part> Children
        => Wrapped.Children.Select(item => new Part(item)).ToList();

    public ControlSurface ControlSurface
        => new ControlSurface(Wrapped.ControlSurface);

    public double Cost
        => Wrapped.Cost;

    public bool Crossfeed
        => Wrapped.Crossfeed;

    public int DecoupleStage
        => Wrapped.DecoupleStage;

    public Decoupler Decoupler
        => new Decoupler(Wrapped.Decoupler);

    public DockingPort DockingPort
        => new DockingPort(Wrapped.DockingPort);

    public double DryMass
        => Wrapped.DryMass;

    public float DynamicPressure
        => Wrapped.DynamicPressure;

    public Engine Engine
        => new Engine(Wrapped.Engine);

    public Experiment Experiment
        => new Experiment(Wrapped.Experiment);

    public IList<Experiment> Experiments
        => Wrapped.Experiments.Select(item => new Experiment(item)).ToList();

    public Fairing Fairing
        => new Fairing(Wrapped.Fairing);

    public string FlagURL
    {
        get => Wrapped.FlagURL;
        set => Wrapped.FlagURL = value;
    }

    public IList<Part> FuelLinesFrom
        => Wrapped.FuelLinesFrom.Select(item => new Part(item)).ToList();

    public IList<Part> FuelLinesTo
        => Wrapped.FuelLinesTo.Select(item => new Part(item)).ToList();

    public bool Glow
    {
        set => Wrapped.Glow = value;
    }

    public Tuple<double, double, double> HighlightColor
    {
        get => Wrapped.HighlightColor;
        set => Wrapped.HighlightColor = value;
    }

    public bool Highlighted
    {
        get => Wrapped.Highlighted;
        set => Wrapped.Highlighted = value;
    }

    public double ImpactTolerance
        => Wrapped.ImpactTolerance;

    public IList<double> InertiaTensor
        => Wrapped.InertiaTensor;

    public Intake Intake
        => new Intake(Wrapped.Intake);

    public bool IsFuelLine
        => Wrapped.IsFuelLine;

    public LaunchClamp LaunchClamp
        => new LaunchClamp(Wrapped.LaunchClamp);

    public Leg Leg
        => new Leg(Wrapped.Leg);

    public Light Light
        => new Light(Wrapped.Light);

    public double Mass
        => Wrapped.Mass;

    public bool Massless
        => Wrapped.Massless;

    public double MaxSkinTemperature
        => Wrapped.MaxSkinTemperature;

    public double MaxTemperature
        => Wrapped.MaxTemperature;

    public IList<Module> Modules
        => Wrapped.Modules.Select(item => new Module(item)).ToList();

    public Tuple<double, double, double> MomentOfInertia
        => Wrapped.MomentOfInertia;

    public string Name
        => Wrapped.Name;

    public Parachute Parachute
        => new Parachute(Wrapped.Parachute);

    public Part Parent
        => new Part(Wrapped.Parent);

    public RCS RCS
        => new RCS(Wrapped.RCS);

    public bool RadiallyAttached
        => Wrapped.RadiallyAttached;

    public Radiator Radiator
        => new Radiator(Wrapped.Radiator);

    public ReactionWheel ReactionWheel
        => new ReactionWheel(Wrapped.ReactionWheel);

    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Wrapped.ReferenceFrame);

    public ResourceConverter ResourceConverter
        => new ResourceConverter(Wrapped.ResourceConverter);

    public ResourceDrain ResourceDrain
        => new ResourceDrain(Wrapped.ResourceDrain);

    public ResourceHarvester ResourceHarvester
        => new ResourceHarvester(Wrapped.ResourceHarvester);

    public Resources Resources
        => new Resources(Wrapped.Resources);

    public RoboticController RoboticController
        => new RoboticController(Wrapped.RoboticController);

    public RoboticHinge RoboticHinge
        => new RoboticHinge(Wrapped.RoboticHinge);

    public RoboticPiston RoboticPiston
        => new RoboticPiston(Wrapped.RoboticPiston);

    public RoboticRotation RoboticRotation
        => new RoboticRotation(Wrapped.RoboticRotation);

    public RoboticRotor RoboticRotor
        => new RoboticRotor(Wrapped.RoboticRotor);

    public Sensor Sensor
        => new Sensor(Wrapped.Sensor);

    public bool Shielded
        => Wrapped.Shielded;

    public double SkinTemperature
        => Wrapped.SkinTemperature;

    public SolarPanel SolarPanel
        => new SolarPanel(Wrapped.SolarPanel);

    public int Stage
        => Wrapped.Stage;

    public string Tag
    {
        get => Wrapped.Tag;
        set => Wrapped.Tag = value;
    }

    public double Temperature
        => Wrapped.Temperature;

    public float ThermalConductionFlux
        => Wrapped.ThermalConductionFlux;

    public float ThermalConvectionFlux
        => Wrapped.ThermalConvectionFlux;

    public float ThermalInternalFlux
        => Wrapped.ThermalInternalFlux;

    public float ThermalMass
        => Wrapped.ThermalMass;

    public float ThermalRadiationFlux
        => Wrapped.ThermalRadiationFlux;

    public float ThermalResourceMass
        => Wrapped.ThermalResourceMass;

    public float ThermalSkinMass
        => Wrapped.ThermalSkinMass;

    public float ThermalSkinToInternalFlux
        => Wrapped.ThermalSkinToInternalFlux;

    public string Title
        => Wrapped.Title;

    public Vessel Vessel
        => new Vessel(Wrapped.Vessel);

    public Wheel Wheel
        => new Wheel(Wrapped.Wheel);

    public Force AddForce(Tuple<double, double, double> force, Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => new Force(Wrapped.AddForce(force, position, referenceFrame.Wrapped));

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> BoundingBox(ReferenceFrame referenceFrame)
        => Wrapped.BoundingBox(referenceFrame.Wrapped);

    public Tuple<double, double, double> CenterOfMass(ReferenceFrame referenceFrame)
        => Wrapped.CenterOfMass(referenceFrame.Wrapped);

    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Wrapped.Direction(referenceFrame.Wrapped);

    public void InstantaneousForce(Tuple<double, double, double> force, Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Wrapped.InstantaneousForce(force, position, referenceFrame.Wrapped);

    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Wrapped.Position(referenceFrame.Wrapped);

    public Tuple<double, double, double, double> Rotation(ReferenceFrame referenceFrame)
        => Wrapped.Rotation(referenceFrame.Wrapped);

    public Tuple<double, double, double> Velocity(ReferenceFrame referenceFrame)
        => Wrapped.Velocity(referenceFrame.Wrapped);
}
