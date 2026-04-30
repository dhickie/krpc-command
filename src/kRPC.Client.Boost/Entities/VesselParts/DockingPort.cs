using KRPC.Client.Services.SpaceCenter;
using BaseDockingPort = KRPC.Client.Services.SpaceCenter.DockingPort;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter DockingPort object.
/// </summary>
public class DockingPort
{
    internal readonly BaseDockingPort Wrapped;

    internal DockingPort(BaseDockingPort dockingPort)
    {
        Wrapped = dockingPort;
    }

    public bool CanRotate
        => Wrapped.CanRotate;

    public Part DockedPart
        => new Part(Wrapped.DockedPart);

    public bool HasShield
        => Wrapped.HasShield;

    public float MaximumRotation
        => Wrapped.MaximumRotation;

    public float MinimumRotation
        => Wrapped.MinimumRotation;

    public Part Part
        => new Part(Wrapped.Part);

    public float ReengageDistance
        => Wrapped.ReengageDistance;

    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Wrapped.ReferenceFrame);

    public bool RotationLocked
    {
        get => Wrapped.RotationLocked;
        set => Wrapped.RotationLocked = value;
    }

    public float RotationTarget
    {
        get => Wrapped.RotationTarget;
        set => Wrapped.RotationTarget = value;
    }

    public bool Shielded
    {
        get => Wrapped.Shielded;
        set => Wrapped.Shielded = value;
    }

    public DockingPortState State
        => Wrapped.State;

    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Wrapped.Direction(referenceFrame.Wrapped);

    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Wrapped.Position(referenceFrame.Wrapped);

    public Tuple<double, double, double, double> Rotation(ReferenceFrame referenceFrame)
        => Wrapped.Rotation(referenceFrame.Wrapped);

    public Vessel Undock()
        => new Vessel(Wrapped.Undock());
}
