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
    internal readonly BaseVessel Wrapped;

    internal Vessel(BaseVessel vessel)
    {
        Wrapped = vessel;
    }

    public AutoPilot AutoPilot
        => new AutoPilot(Wrapped.AutoPilot);

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableControlSurfaceTorque
        => Wrapped.AvailableControlSurfaceTorque;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableEngineTorque
        => Wrapped.AvailableEngineTorque;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableOtherTorque
        => Wrapped.AvailableOtherTorque;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableRCSForce
        => Wrapped.AvailableRCSForce;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableRCSTorque
        => Wrapped.AvailableRCSTorque;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableReactionWheelTorque
        => Wrapped.AvailableReactionWheelTorque;

    public float AvailableThrust
        => Wrapped.AvailableThrust;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Wrapped.AvailableTorque;

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

    public Tuple<double, double, double> MomentOfInertia
        => Wrapped.MomentOfInertia;

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

    public Tuple<double, double, double> AngularVelocity(ReferenceFrame referenceFrame)
        => Wrapped.AngularVelocity(referenceFrame.Wrapped);

    public float AvailableThrustAt(double pressure)
        => Wrapped.AvailableThrustAt(pressure);

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> BoundingBox(ReferenceFrame referenceFrame)
        => Wrapped.BoundingBox(referenceFrame.Wrapped);

    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Wrapped.Direction(referenceFrame.Wrapped);

    public Flight Flight(ReferenceFrame referenceFrame = null)
        => new Flight(Wrapped.Flight(referenceFrame?.Wrapped));

    public float MaxThrustAt(double pressure)
        => Wrapped.MaxThrustAt(pressure);

    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Wrapped.Position(referenceFrame.Wrapped);

    public void Recover()
        => Wrapped.Recover();

    public Resources ResourcesInDecoupleStage(int stage, bool cumulative = true)
        => new Resources(Wrapped.ResourcesInDecoupleStage(stage, cumulative));

    public Tuple<double, double, double, double> Rotation(ReferenceFrame referenceFrame)
        => Wrapped.Rotation(referenceFrame.Wrapped);

    public float SpecificImpulseAt(double pressure)
        => Wrapped.SpecificImpulseAt(pressure);

    public Tuple<double, double, double> Velocity(ReferenceFrame referenceFrame)
        => Wrapped.Velocity(referenceFrame.Wrapped);
}
