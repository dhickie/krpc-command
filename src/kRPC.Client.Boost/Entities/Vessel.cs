using kRPC.Client.Boost.Extensions;
using KRPC.Client.Services.SpaceCenter;
using MathNet.Spatial.Euclidean;
using BaseVessel = KRPC.Client.Services.SpaceCenter.Vessel;
using Parts = kRPC.Client.Boost.Entities.VesselParts.Parts;
using Resources = kRPC.Client.Boost.Entities.VesselParts.Resources;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Vessel object.
/// </summary>
public class Vessel
{
    internal readonly BaseVessel Wrapped;

    internal Vessel(BaseVessel vessel)
    {
        Wrapped = vessel;
    }

    public AutoPilot AutoPilot
        => new AutoPilot(Wrapped.AutoPilot);

    public Tuple<Vector3D, Vector3D> AvailableControlSurfaceTorque
        => Wrapped.AvailableControlSurfaceTorque.ToTupleVector3D();

    public Tuple<Vector3D, Vector3D> AvailableEngineTorque
        => Wrapped.AvailableEngineTorque.ToTupleVector3D();

    public Tuple<Vector3D, Vector3D> AvailableOtherTorque
        => Wrapped.AvailableOtherTorque.ToTupleVector3D();

    public Tuple<Vector3D, Vector3D> AvailableRCSForce
        => Wrapped.AvailableRCSForce.ToTupleVector3D();

    public Tuple<Vector3D, Vector3D> AvailableRCSTorque
        => Wrapped.AvailableRCSTorque.ToTupleVector3D();

    public Tuple<Vector3D, Vector3D> AvailableReactionWheelTorque
        => Wrapped.AvailableReactionWheelTorque.ToTupleVector3D();

    public float AvailableThrust
        => Wrapped.AvailableThrust;

    public Tuple<Vector3D, Vector3D> AvailableTorque
        => Wrapped.AvailableTorque.ToTupleVector3D();

    public string Biome
        => Wrapped.Biome;

    public Comms Comms
        => new Comms(Wrapped.Comms);

    public Control Control
        => new Control(Wrapped.Control);

    public IList<CrewMember> Crew
        => Wrapped.Crew.Select(item => new CrewMember(item)).ToList();

    public int CrewCapacity
        => Wrapped.CrewCapacity;

    public int CrewCount
        => Wrapped.CrewCount;

    public float DryMass
        => Wrapped.DryMass;

    public IList<double> InertiaTensor
        => Wrapped.InertiaTensor;

    public float KerbinSeaLevelSpecificImpulse
        => Wrapped.KerbinSeaLevelSpecificImpulse;

    public double MET
        => Wrapped.MET;

    public float Mass
        => Wrapped.Mass;

    public float MaxThrust
        => Wrapped.MaxThrust;

    public float MaxVacuumThrust
        => Wrapped.MaxVacuumThrust;

    public Vector3D MomentOfInertia
        => Wrapped.MomentOfInertia.ToVector3D();

    public string Name
    {
        get => Wrapped.Name;
        set => Wrapped.Name = value;
    }

    public Orbit Orbit
        => new Orbit(Wrapped.Orbit);

    public ReferenceFrame OrbitalReferenceFrame
        => new ReferenceFrame(Wrapped.OrbitalReferenceFrame);

    public Parts Parts
        => new Parts(Wrapped.Parts);

    public bool Recoverable
        => Wrapped.Recoverable;

    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Wrapped.ReferenceFrame);

    public Resources Resources
        => new Resources(Wrapped.Resources);

    public VesselSituation Situation
        => Wrapped.Situation;

    public float SpecificImpulse
        => Wrapped.SpecificImpulse;

    public ReferenceFrame SurfaceReferenceFrame
        => new ReferenceFrame(Wrapped.SurfaceReferenceFrame);

    public ReferenceFrame SurfaceVelocityReferenceFrame
        => new ReferenceFrame(Wrapped.SurfaceVelocityReferenceFrame);

    public float Thrust
        => Wrapped.Thrust;

    public VesselType Type
    {
        get => Wrapped.Type;
        set => Wrapped.Type = value;
    }

    public float VacuumSpecificImpulse
        => Wrapped.VacuumSpecificImpulse;

    public Vector3D AngularVelocity(ReferenceFrame referenceFrame)
        => Wrapped.AngularVelocity(referenceFrame.Wrapped).ToVector3D();

    public float AvailableThrustAt(double pressure)
        => Wrapped.AvailableThrustAt(pressure);

    public Tuple<Vector3D, Vector3D> BoundingBox(ReferenceFrame referenceFrame)
        => Wrapped.BoundingBox(referenceFrame.Wrapped).ToTupleVector3D();

    public Vector3D Direction(ReferenceFrame referenceFrame)
        => Wrapped.Direction(referenceFrame.Wrapped).ToVector3D();

    public Flight Flight(ReferenceFrame referenceFrame = null)
        => new Flight(Wrapped.Flight(referenceFrame?.Wrapped));

    public float MaxThrustAt(double pressure)
        => Wrapped.MaxThrustAt(pressure);

    public Vector3D Position(ReferenceFrame referenceFrame)
        => Wrapped.Position(referenceFrame.Wrapped).ToVector3D();

    public void Recover()
        => Wrapped.Recover();

    public Resources ResourcesInDecoupleStage(int stage, bool cumulative = true)
        => new Resources(Wrapped.ResourcesInDecoupleStage(stage, cumulative));

    public Quaternion Rotation(ReferenceFrame referenceFrame)
        => Wrapped.Rotation(referenceFrame.Wrapped).ToQuaternion();

    public float SpecificImpulseAt(double pressure)
        => Wrapped.SpecificImpulseAt(pressure);

    public Vector3D Velocity(ReferenceFrame referenceFrame)
        => Wrapped.Velocity(referenceFrame.Wrapped).ToVector3D();
}
