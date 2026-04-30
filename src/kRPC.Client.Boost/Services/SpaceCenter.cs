using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using kRPC.Client.Boost.Entities;
using kRPC.Client.Boost.Entities.VesselParts;
using BaseService = KRPC.Client.Services.SpaceCenter.Service;
using AntennaState = KRPC.Client.Services.SpaceCenter.AntennaState;
using AutoStrutMode = KRPC.Client.Services.SpaceCenter.AutoStrutMode;
using CameraMode = KRPC.Client.Services.SpaceCenter.CameraMode;
using CargoBayState = KRPC.Client.Services.SpaceCenter.CargoBayState;
using CommLinkType = KRPC.Client.Services.SpaceCenter.CommLinkType;
using ContractState = KRPC.Client.Services.SpaceCenter.ContractState;
using ControlInputMode = KRPC.Client.Services.SpaceCenter.ControlInputMode;
using ControlSource = KRPC.Client.Services.SpaceCenter.ControlSource;
using ControlState = KRPC.Client.Services.SpaceCenter.ControlState;
using CrewMemberGender = KRPC.Client.Services.SpaceCenter.CrewMemberGender;
using CrewMemberType = KRPC.Client.Services.SpaceCenter.CrewMemberType;
using DockingPortState = KRPC.Client.Services.SpaceCenter.DockingPortState;
using DrainMode = KRPC.Client.Services.SpaceCenter.DrainMode;
using EditorFacility = KRPC.Client.Services.SpaceCenter.EditorFacility;
using GameMode = KRPC.Client.Services.SpaceCenter.GameMode;
using LegState = KRPC.Client.Services.SpaceCenter.LegState;
using MapFilterType = KRPC.Client.Services.SpaceCenter.MapFilterType;
using MotorState = KRPC.Client.Services.SpaceCenter.MotorState;
using ParachuteState = KRPC.Client.Services.SpaceCenter.ParachuteState;
using RadiatorState = KRPC.Client.Services.SpaceCenter.RadiatorState;
using ResourceConverterState = KRPC.Client.Services.SpaceCenter.ResourceConverterState;
using ResourceFlowMode = KRPC.Client.Services.SpaceCenter.ResourceFlowMode;
using ResourceHarvesterState = KRPC.Client.Services.SpaceCenter.ResourceHarvesterState;
using RosterStatus = KRPC.Client.Services.SpaceCenter.RosterStatus;
using SASMode = KRPC.Client.Services.SpaceCenter.SASMode;
using SolarPanelState = KRPC.Client.Services.SpaceCenter.SolarPanelState;
using SpeedMode = KRPC.Client.Services.SpaceCenter.SpeedMode;
using SuitType = KRPC.Client.Services.SpaceCenter.SuitType;
using VesselSituation = KRPC.Client.Services.SpaceCenter.VesselSituation;
using VesselType = KRPC.Client.Services.SpaceCenter.VesselType;
using WarpMode = KRPC.Client.Services.SpaceCenter.WarpMode;
using WheelState = KRPC.Client.Services.SpaceCenter.WheelState;

namespace kRPC.Client.Boost.Services;

/// <summary>
/// Wraps the kRPC SpaceCenter service.
/// </summary>
public class SpaceCenter
{
    private readonly BaseService _service;

    internal SpaceCenter(BaseService service)
    {
        _service = service;
    }
    public Vessel ActiveVessel
    {
        get => new Vessel(_service.ActiveVessel);
        set => _service.ActiveVessel = value.Internal;
    }
    public AlarmManager AlarmManager
        => new AlarmManager(_service.AlarmManager);
    public IDictionary<string, CelestialBody> Bodies
        => _service.Bodies.ToDictionary(pair => pair.Key, pair => new CelestialBody(pair.Value));
    public Camera Camera
        => new Camera(_service.Camera);
    public ContractManager ContractManager
        => new ContractManager(_service.ContractManager);
    public bool FARAvailable
        => _service.FARAvailable;
    public double Funds
        => _service.Funds;
    public double G
        => _service.G;
    public GameMode GameMode
        => _service.GameMode;
    public IList<LaunchSite> LaunchSites
        => _service.LaunchSites.Select(item => new LaunchSite(item)).ToList();
    public MapFilterType MapFilter
    {
        get => _service.MapFilter;
        set => _service.MapFilter = value;
    }
    public int MaximumRailsWarpFactor
        => _service.MaximumRailsWarpFactor;
    public bool Navball
    {
        get => _service.Navball;
        set => _service.Navball = value;
    }
    public int PhysicsWarpFactor
    {
        get => _service.PhysicsWarpFactor;
        set => _service.PhysicsWarpFactor = value;
    }
    public int RailsWarpFactor
    {
        get => _service.RailsWarpFactor;
        set => _service.RailsWarpFactor = value;
    }
    public float Reputation
        => _service.Reputation;
    public float Science
        => _service.Science;
    public CelestialBody TargetBody
    {
        get => new CelestialBody(_service.TargetBody);
        set => _service.TargetBody = value.Internal;
    }
    public DockingPort TargetDockingPort
    {
        get => new DockingPort(_service.TargetDockingPort);
        set => _service.TargetDockingPort = value.Internal;
    }
    public Vessel TargetVessel
    {
        get => new Vessel(_service.TargetVessel);
        set => _service.TargetVessel = value.Internal;
    }
    public bool UIVisible
    {
        get => _service.UIVisible;
        set => _service.UIVisible = value;
    }
    public double UT
        => _service.UT;
    public IList<Vessel> Vessels
        => _service.Vessels.Select(item => new Vessel(item)).ToList();
    public float WarpFactor
        => _service.WarpFactor;
    public WarpMode WarpMode
        => _service.WarpMode;
    public float WarpRate
        => _service.WarpRate;
    public WaypointManager WaypointManager
        => new WaypointManager(_service.WaypointManager);
    public bool CanRailsWarpAt(int factor = 1)
        => _service.CanRailsWarpAt(factor);
    public bool CanRevertToLaunch()
        => _service.CanRevertToLaunch();
    public void ClearTarget()
        => _service.ClearTarget();
    public void CreateKerbal(string name, string job, bool male)
        => _service.CreateKerbal(name, job, male);
    public CrewMember GetKerbal(string name)
        => new CrewMember(_service.GetKerbal(name));
    public void LaunchVessel(string craftDirectory, string name, string launchSite, bool recover = true, IList<string> crew = null, string flagUrl = "")
        => _service.LaunchVessel(craftDirectory, name, launchSite, recover, crew, flagUrl);
    public void LaunchVesselFromSPH(string name, bool recover = true)
        => _service.LaunchVesselFromSPH(name, recover);
    public void LaunchVesselFromVAB(string name, bool recover = true)
        => _service.LaunchVesselFromVAB(name, recover);
    public IList<string> LaunchableVessels(string craftDirectory)
        => _service.LaunchableVessels(craftDirectory);
    public void Load(string name)
        => _service.Load(name);
    public void LoadSpaceCenter()
        => _service.LoadSpaceCenter();
    public void Quickload()
        => _service.Quickload();
    public void Quicksave()
        => _service.Quicksave();
    public double RaycastDistance(Tuple<double, double, double> position, Tuple<double, double, double> direction, ReferenceFrame referenceFrame)
        => _service.RaycastDistance(position, direction, referenceFrame.Internal);
    public Part RaycastPart(Tuple<double, double, double> position, Tuple<double, double, double> direction, ReferenceFrame referenceFrame)
        => new Part(_service.RaycastPart(position, direction, referenceFrame.Internal));
    public void RevertToLaunch()
        => _service.RevertToLaunch();
    public void Save(string name)
        => _service.Save(name);
    public void Screenshot(string filePath, int scale = 1)
        => _service.Screenshot(filePath, scale);
    public void TransferCrew(CrewMember crewMember, Part targetPart)
        => _service.TransferCrew(crewMember.Internal, targetPart.Internal);
    public Tuple<double, double, double> TransformDirection(Tuple<double, double, double> direction, ReferenceFrame from, ReferenceFrame to)
        => _service.TransformDirection(direction, from.Internal, to.Internal);
    public Tuple<double, double, double> TransformPosition(Tuple<double, double, double> position, ReferenceFrame from, ReferenceFrame to)
        => _service.TransformPosition(position, from.Internal, to.Internal);
    public Tuple<double, double, double, double> TransformRotation(Tuple<double, double, double, double> rotation, ReferenceFrame from, ReferenceFrame to)
        => _service.TransformRotation(rotation, from.Internal, to.Internal);
    public Tuple<double, double, double> TransformVelocity(Tuple<double, double, double> position, Tuple<double, double, double> velocity, ReferenceFrame from, ReferenceFrame to)
        => _service.TransformVelocity(position, velocity, from.Internal, to.Internal);
    public void WarpTo(double ut, float maxRailsRate = 100000f, float maxPhysicsRate = 2f)
        => _service.WarpTo(ut, maxRailsRate, maxPhysicsRate);
}
