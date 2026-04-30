using kRPC.Client.Boost.Entities;
using kRPC.Client.Boost.Entities.VesselParts;
using BaseService = KRPC.Client.Services.SpaceCenter.Service;
using GameMode = KRPC.Client.Services.SpaceCenter.GameMode;
using MapFilterType = KRPC.Client.Services.SpaceCenter.MapFilterType;
using WarpMode = KRPC.Client.Services.SpaceCenter.WarpMode;

namespace kRPC.Client.Boost.Services;

/// <summary>
/// Wraps the kRPC SpaceCenter service.
/// </summary>
public class SpaceCenter
{
    internal readonly BaseService Service;

    internal SpaceCenter(BaseService service)
    {
        Service = service;
    }

    public Vessel ActiveVessel
    {
        get => new Vessel(Service.ActiveVessel);
        set => Service.ActiveVessel = value.Wrapped;
    }

    public AlarmManager AlarmManager
        => new AlarmManager(Service.AlarmManager);

    public IDictionary<string, CelestialBody> Bodies
        => Service.Bodies.ToDictionary(pair => pair.Key, pair => new CelestialBody(pair.Value));

    public Camera Camera
        => new Camera(Service.Camera);

    public ContractManager ContractManager
        => new ContractManager(Service.ContractManager);

    public bool FARAvailable
        => Service.FARAvailable;

    public double Funds
        => Service.Funds;

    public double G
        => Service.G;

    public GameMode GameMode
        => Service.GameMode;

    public IList<LaunchSite> LaunchSites
        => Service.LaunchSites.Select(item => new LaunchSite(item)).ToList();

    public MapFilterType MapFilter
    {
        get => Service.MapFilter;
        set => Service.MapFilter = value;
    }

    public int MaximumRailsWarpFactor
        => Service.MaximumRailsWarpFactor;

    public bool Navball
    {
        get => Service.Navball;
        set => Service.Navball = value;
    }

    public int PhysicsWarpFactor
    {
        get => Service.PhysicsWarpFactor;
        set => Service.PhysicsWarpFactor = value;
    }

    public int RailsWarpFactor
    {
        get => Service.RailsWarpFactor;
        set => Service.RailsWarpFactor = value;
    }

    public float Reputation
        => Service.Reputation;

    public float Science
        => Service.Science;

    public CelestialBody TargetBody
    {
        get => new CelestialBody(Service.TargetBody);
        set => Service.TargetBody = value.Wrapped;
    }

    public DockingPort TargetDockingPort
    {
        get => new DockingPort(Service.TargetDockingPort);
        set => Service.TargetDockingPort = value.Wrapped;
    }

    public Vessel TargetVessel
    {
        get => new Vessel(Service.TargetVessel);
        set => Service.TargetVessel = value.Wrapped;
    }

    public bool UIVisible
    {
        get => Service.UIVisible;
        set => Service.UIVisible = value;
    }

    public double UT
        => Service.UT;

    public IList<Vessel> Vessels
        => Service.Vessels.Select(item => new Vessel(item)).ToList();

    public float WarpFactor
        => Service.WarpFactor;

    public WarpMode WarpMode
        => Service.WarpMode;

    public float WarpRate
        => Service.WarpRate;

    public WaypointManager WaypointManager
        => new WaypointManager(Service.WaypointManager);

    public bool CanRailsWarpAt(int factor = 1)
        => Service.CanRailsWarpAt(factor);

    public bool CanRevertToLaunch()
        => Service.CanRevertToLaunch();

    public void ClearTarget()
        => Service.ClearTarget();

    public void CreateKerbal(string name, string job, bool male)
        => Service.CreateKerbal(name, job, male);

    public CrewMember GetKerbal(string name)
        => new CrewMember(Service.GetKerbal(name));

    public void LaunchVessel(string craftDirectory, string name, string launchSite, bool recover = true, IList<string> crew = null, string flagUrl = "")
        => Service.LaunchVessel(craftDirectory, name, launchSite, recover, crew, flagUrl);

    public void LaunchVesselFromSPH(string name, bool recover = true)
        => Service.LaunchVesselFromSPH(name, recover);

    public void LaunchVesselFromVAB(string name, bool recover = true)
        => Service.LaunchVesselFromVAB(name, recover);

    public IList<string> LaunchableVessels(string craftDirectory)
        => Service.LaunchableVessels(craftDirectory);

    public void Load(string name)
        => Service.Load(name);

    public void LoadSpaceCenter()
        => Service.LoadSpaceCenter();

    public void Quickload()
        => Service.Quickload();

    public void Quicksave()
        => Service.Quicksave();

    public double RaycastDistance(Tuple<double, double, double> position, Tuple<double, double, double> direction, ReferenceFrame referenceFrame)
        => Service.RaycastDistance(position, direction, referenceFrame.Wrapped);

    public Part RaycastPart(Tuple<double, double, double> position, Tuple<double, double, double> direction, ReferenceFrame referenceFrame)
        => new Part(Service.RaycastPart(position, direction, referenceFrame.Wrapped));

    public void RevertToLaunch()
        => Service.RevertToLaunch();

    public void Save(string name)
        => Service.Save(name);

    public void Screenshot(string filePath, int scale = 1)
        => Service.Screenshot(filePath, scale);

    public void TransferCrew(CrewMember crewMember, Part targetPart)
        => Service.TransferCrew(crewMember.Wrapped, targetPart.Wrapped);

    public Tuple<double, double, double> TransformDirection(Tuple<double, double, double> direction, ReferenceFrame from, ReferenceFrame to)
        => Service.TransformDirection(direction, from.Wrapped, to.Wrapped);

    public Tuple<double, double, double> TransformPosition(Tuple<double, double, double> position, ReferenceFrame from, ReferenceFrame to)
        => Service.TransformPosition(position, from.Wrapped, to.Wrapped);

    public Tuple<double, double, double, double> TransformRotation(Tuple<double, double, double, double> rotation, ReferenceFrame from, ReferenceFrame to)
        => Service.TransformRotation(rotation, from.Wrapped, to.Wrapped);

    public Tuple<double, double, double> TransformVelocity(Tuple<double, double, double> position, Tuple<double, double, double> velocity, ReferenceFrame from, ReferenceFrame to)
        => Service.TransformVelocity(position, velocity, from.Wrapped, to.Wrapped);

    public void WarpTo(double ut, float maxRailsRate = 100000f, float maxPhysicsRate = 2f)
        => Service.WarpTo(ut, maxRailsRate, maxPhysicsRate);
}
