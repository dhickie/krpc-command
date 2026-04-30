using kRPC.Client.Boost.Extensions;
using KRPC.Client.Services.SpaceCenter;
using MathNet.Spatial.Euclidean;
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

    public Vector3D HighlightColor
    {
        get => Wrapped.HighlightColor.ToVector3D();
        set => Wrapped.HighlightColor = value.ToTuple();
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

    public Vector3D MomentOfInertia
        => Wrapped.MomentOfInertia.ToVector3D();

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
        => new(Wrapped.Vessel);

    public Wheel Wheel
        => new(Wrapped.Wheel);

    public Force AddForce(Vector3D force, Vector3D position, ReferenceFrame referenceFrame)
        => new(Wrapped.AddForce(force.ToTuple(), position.ToTuple(), referenceFrame.Wrapped));

    public Tuple<Vector3D, Vector3D> BoundingBox(ReferenceFrame referenceFrame)
        => Wrapped.BoundingBox(referenceFrame.Wrapped).ToTupleVector3D();

    public Vector3D CenterOfMass(ReferenceFrame referenceFrame)
        => Wrapped.CenterOfMass(referenceFrame.Wrapped).ToVector3D();

    public Vector3D Direction(ReferenceFrame referenceFrame)
        => Wrapped.Direction(referenceFrame.Wrapped).ToVector3D();

    public void InstantaneousForce(Vector3D force, Vector3D position, ReferenceFrame referenceFrame)
        => Wrapped.InstantaneousForce(force.ToTuple(), position.ToTuple(), referenceFrame.Wrapped);

    public Vector3D Position(ReferenceFrame referenceFrame)
        => Wrapped.Position(referenceFrame.Wrapped).ToVector3D();

    public Quaternion Rotation(ReferenceFrame referenceFrame)
        => Wrapped.Rotation(referenceFrame.Wrapped).ToQuaternion();

    public Vector3D Velocity(ReferenceFrame referenceFrame)
        => Wrapped.Velocity(referenceFrame.Wrapped).ToVector3D();
}
