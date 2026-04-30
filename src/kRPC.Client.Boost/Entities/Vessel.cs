using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseVessel = KRPC.Client.Services.SpaceCenter.Vessel;
using Parts = kRPC.Client.Boost.Entities.VesselParts.Parts;
using Resources = kRPC.Client.Boost.Entities.VesselParts.Resources;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Vessel object.
/// </summary>
public class Vessel
{
    internal BaseVessel Internal { get; }

    internal Vessel(BaseVessel vessel)
    {
        Internal = vessel;
    }
    public AutoPilot AutoPilot
        => new AutoPilot(Internal.AutoPilot);
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableControlSurfaceTorque
        => Internal.AvailableControlSurfaceTorque;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableEngineTorque
        => Internal.AvailableEngineTorque;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableOtherTorque
        => Internal.AvailableOtherTorque;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableRCSForce
        => Internal.AvailableRCSForce;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableRCSTorque
        => Internal.AvailableRCSTorque;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableReactionWheelTorque
        => Internal.AvailableReactionWheelTorque;
    public float AvailableThrust
        => Internal.AvailableThrust;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Internal.AvailableTorque;
    public string Biome
        => Internal.Biome;
    public Comms Comms
        => new Comms(Internal.Comms);
    public Control Control
        => new Control(Internal.Control);
    public IList<CrewMember> Crew
        => Internal.Crew.Select(item => new CrewMember(item)).ToList();
    public int CrewCapacity
        => Internal.CrewCapacity;
    public int CrewCount
        => Internal.CrewCount;
    public float DryMass
        => Internal.DryMass;
    public IList<double> InertiaTensor
        => Internal.InertiaTensor;
    public float KerbinSeaLevelSpecificImpulse
        => Internal.KerbinSeaLevelSpecificImpulse;
    public double MET
        => Internal.MET;
    public float Mass
        => Internal.Mass;
    public float MaxThrust
        => Internal.MaxThrust;
    public float MaxVacuumThrust
        => Internal.MaxVacuumThrust;
    public Tuple<double, double, double> MomentOfInertia
        => Internal.MomentOfInertia;
    public string Name
    {
        get => Internal.Name;
        set => Internal.Name = value;
    }
    public Orbit Orbit
        => new Orbit(Internal.Orbit);
    public ReferenceFrame OrbitalReferenceFrame
        => new ReferenceFrame(Internal.OrbitalReferenceFrame);
    public Parts Parts
        => new Parts(Internal.Parts);
    public bool Recoverable
        => Internal.Recoverable;
    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Internal.ReferenceFrame);
    public Resources Resources
        => new Resources(Internal.Resources);
    public VesselSituation Situation
        => Internal.Situation;
    public float SpecificImpulse
        => Internal.SpecificImpulse;
    public ReferenceFrame SurfaceReferenceFrame
        => new ReferenceFrame(Internal.SurfaceReferenceFrame);
    public ReferenceFrame SurfaceVelocityReferenceFrame
        => new ReferenceFrame(Internal.SurfaceVelocityReferenceFrame);
    public float Thrust
        => Internal.Thrust;
    public VesselType Type
    {
        get => Internal.Type;
        set => Internal.Type = value;
    }
    public float VacuumSpecificImpulse
        => Internal.VacuumSpecificImpulse;
    public Tuple<double, double, double> AngularVelocity(ReferenceFrame referenceFrame)
        => Internal.AngularVelocity(referenceFrame.Internal);
    public float AvailableThrustAt(double pressure)
        => Internal.AvailableThrustAt(pressure);
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> BoundingBox(ReferenceFrame referenceFrame)
        => Internal.BoundingBox(referenceFrame.Internal);
    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Internal.Direction(referenceFrame.Internal);
    public Flight Flight(ReferenceFrame referenceFrame = null)
        => new Flight(Internal.Flight(referenceFrame?.Internal));
    public float MaxThrustAt(double pressure)
        => Internal.MaxThrustAt(pressure);
    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Internal.Position(referenceFrame.Internal);
    public void Recover()
        => Internal.Recover();
    public Resources ResourcesInDecoupleStage(int stage, bool cumulative = true)
        => new Resources(Internal.ResourcesInDecoupleStage(stage, cumulative));
    public Tuple<double, double, double, double> Rotation(ReferenceFrame referenceFrame)
        => Internal.Rotation(referenceFrame.Internal);
    public float SpecificImpulseAt(double pressure)
        => Internal.SpecificImpulseAt(pressure);
    public Tuple<double, double, double> Velocity(ReferenceFrame referenceFrame)
        => Internal.Velocity(referenceFrame.Internal);
}
