using KRPC.Client.Services.SpaceCenter;
using BasePart = KRPC.Client.Services.SpaceCenter.Part;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Part object.
/// </summary>
public class Part
{
    internal BasePart Internal { get; }

    internal Part(BasePart part)
    {
        Internal = part;
    }
    public Antenna Antenna
        => new Antenna(Internal.Antenna);
    public AutoStrutMode AutoStrutMode
        => Internal.AutoStrutMode;
    public uint AvailableSeats
        => Internal.AvailableSeats;
    public bool AxiallyAttached
        => Internal.AxiallyAttached;
    public CargoBay CargoBay
        => new CargoBay(Internal.CargoBay);
    public ReferenceFrame CenterOfMassReferenceFrame
        => new ReferenceFrame(Internal.CenterOfMassReferenceFrame);
    public IList<Part> Children
        => Internal.Children.Select(item => new Part(item)).ToList();
    public ControlSurface ControlSurface
        => new ControlSurface(Internal.ControlSurface);
    public double Cost
        => Internal.Cost;
    public bool Crossfeed
        => Internal.Crossfeed;
    public int DecoupleStage
        => Internal.DecoupleStage;
    public Decoupler Decoupler
        => new Decoupler(Internal.Decoupler);
    public DockingPort DockingPort
        => new DockingPort(Internal.DockingPort);
    public double DryMass
        => Internal.DryMass;
    public float DynamicPressure
        => Internal.DynamicPressure;
    public Engine Engine
        => new Engine(Internal.Engine);
    public Experiment Experiment
        => new Experiment(Internal.Experiment);
    public IList<Experiment> Experiments
        => Internal.Experiments.Select(item => new Experiment(item)).ToList();
    public Fairing Fairing
        => new Fairing(Internal.Fairing);
    public string FlagURL
    {
        get => Internal.FlagURL;
        set => Internal.FlagURL = value;
    }
    public IList<Part> FuelLinesFrom
        => Internal.FuelLinesFrom.Select(item => new Part(item)).ToList();
    public IList<Part> FuelLinesTo
        => Internal.FuelLinesTo.Select(item => new Part(item)).ToList();
    public bool Glow
    {
        set => Internal.Glow = value;
    }
    public Tuple<double, double, double> HighlightColor
    {
        get => Internal.HighlightColor;
        set => Internal.HighlightColor = value;
    }
    public bool Highlighted
    {
        get => Internal.Highlighted;
        set => Internal.Highlighted = value;
    }
    public double ImpactTolerance
        => Internal.ImpactTolerance;
    public IList<double> InertiaTensor
        => Internal.InertiaTensor;
    public Intake Intake
        => new Intake(Internal.Intake);
    public bool IsFuelLine
        => Internal.IsFuelLine;
    public LaunchClamp LaunchClamp
        => new LaunchClamp(Internal.LaunchClamp);
    public Leg Leg
        => new Leg(Internal.Leg);
    public Light Light
        => new Light(Internal.Light);
    public double Mass
        => Internal.Mass;
    public bool Massless
        => Internal.Massless;
    public double MaxSkinTemperature
        => Internal.MaxSkinTemperature;
    public double MaxTemperature
        => Internal.MaxTemperature;
    public IList<Module> Modules
        => Internal.Modules.Select(item => new Module(item)).ToList();
    public Tuple<double, double, double> MomentOfInertia
        => Internal.MomentOfInertia;
    public string Name
        => Internal.Name;
    public Parachute Parachute
        => new Parachute(Internal.Parachute);
    public Part Parent
        => new Part(Internal.Parent);
    public RCS RCS
        => new RCS(Internal.RCS);
    public bool RadiallyAttached
        => Internal.RadiallyAttached;
    public Radiator Radiator
        => new Radiator(Internal.Radiator);
    public ReactionWheel ReactionWheel
        => new ReactionWheel(Internal.ReactionWheel);
    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Internal.ReferenceFrame);
    public ResourceConverter ResourceConverter
        => new ResourceConverter(Internal.ResourceConverter);
    public ResourceDrain ResourceDrain
        => new ResourceDrain(Internal.ResourceDrain);
    public ResourceHarvester ResourceHarvester
        => new ResourceHarvester(Internal.ResourceHarvester);
    public Resources Resources
        => new Resources(Internal.Resources);
    public RoboticController RoboticController
        => new RoboticController(Internal.RoboticController);
    public RoboticHinge RoboticHinge
        => new RoboticHinge(Internal.RoboticHinge);
    public RoboticPiston RoboticPiston
        => new RoboticPiston(Internal.RoboticPiston);
    public RoboticRotation RoboticRotation
        => new RoboticRotation(Internal.RoboticRotation);
    public RoboticRotor RoboticRotor
        => new RoboticRotor(Internal.RoboticRotor);
    public Sensor Sensor
        => new Sensor(Internal.Sensor);
    public bool Shielded
        => Internal.Shielded;
    public double SkinTemperature
        => Internal.SkinTemperature;
    public SolarPanel SolarPanel
        => new SolarPanel(Internal.SolarPanel);
    public int Stage
        => Internal.Stage;
    public string Tag
    {
        get => Internal.Tag;
        set => Internal.Tag = value;
    }
    public double Temperature
        => Internal.Temperature;
    public float ThermalConductionFlux
        => Internal.ThermalConductionFlux;
    public float ThermalConvectionFlux
        => Internal.ThermalConvectionFlux;
    public float ThermalInternalFlux
        => Internal.ThermalInternalFlux;
    public float ThermalMass
        => Internal.ThermalMass;
    public float ThermalRadiationFlux
        => Internal.ThermalRadiationFlux;
    public float ThermalResourceMass
        => Internal.ThermalResourceMass;
    public float ThermalSkinMass
        => Internal.ThermalSkinMass;
    public float ThermalSkinToInternalFlux
        => Internal.ThermalSkinToInternalFlux;
    public string Title
        => Internal.Title;
    public Vessel Vessel
        => new Vessel(Internal.Vessel);
    public Wheel Wheel
        => new Wheel(Internal.Wheel);
    public Force AddForce(Tuple<double, double, double> force, Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => new Force(Internal.AddForce(force, position, referenceFrame.Internal));
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> BoundingBox(ReferenceFrame referenceFrame)
        => Internal.BoundingBox(referenceFrame.Internal);
    public Tuple<double, double, double> CenterOfMass(ReferenceFrame referenceFrame)
        => Internal.CenterOfMass(referenceFrame.Internal);
    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Internal.Direction(referenceFrame.Internal);
    public void InstantaneousForce(Tuple<double, double, double> force, Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Internal.InstantaneousForce(force, position, referenceFrame.Internal);
    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Internal.Position(referenceFrame.Internal);
    public Tuple<double, double, double, double> Rotation(ReferenceFrame referenceFrame)
        => Internal.Rotation(referenceFrame.Internal);
    public Tuple<double, double, double> Velocity(ReferenceFrame referenceFrame)
        => Internal.Velocity(referenceFrame.Internal);
}
