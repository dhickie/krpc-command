using KRPC.Client.Services.SpaceCenter;
using BaseDockingPort = KRPC.Client.Services.SpaceCenter.DockingPort;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter DockingPort object.
/// </summary>
public class DockingPort
{
    internal BaseDockingPort Internal { get; }

    internal DockingPort(BaseDockingPort dockingPort)
    {
        Internal = dockingPort;
    }
    public bool CanRotate
        => Internal.CanRotate;
    public Part DockedPart
        => new Part(Internal.DockedPart);
    public bool HasShield
        => Internal.HasShield;
    public float MaximumRotation
        => Internal.MaximumRotation;
    public float MinimumRotation
        => Internal.MinimumRotation;
    public Part Part
        => new Part(Internal.Part);
    public float ReengageDistance
        => Internal.ReengageDistance;
    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Internal.ReferenceFrame);
    public bool RotationLocked
    {
        get => Internal.RotationLocked;
        set => Internal.RotationLocked = value;
    }
    public float RotationTarget
    {
        get => Internal.RotationTarget;
        set => Internal.RotationTarget = value;
    }
    public bool Shielded
    {
        get => Internal.Shielded;
        set => Internal.Shielded = value;
    }
    public DockingPortState State
        => Internal.State;
    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Internal.Direction(referenceFrame.Internal);
    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Internal.Position(referenceFrame.Internal);
    public Tuple<double, double, double, double> Rotation(ReferenceFrame referenceFrame)
        => Internal.Rotation(referenceFrame.Internal);
    public Vessel Undock()
        => new Vessel(Internal.Undock());
}
