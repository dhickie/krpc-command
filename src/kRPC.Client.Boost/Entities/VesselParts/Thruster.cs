using BaseThruster = KRPC.Client.Services.SpaceCenter.Thruster;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Thruster object.
/// </summary>
public class Thruster
{
    internal BaseThruster Internal { get; }

    internal Thruster(BaseThruster thruster)
    {
        Internal = thruster;
    }
    public Tuple<double, double, double> GimbalAngle
        => Internal.GimbalAngle;
    public bool Gimballed
        => Internal.Gimballed;
    public Part Part
        => new Part(Internal.Part);
    public ReferenceFrame ThrustReferenceFrame
        => new ReferenceFrame(Internal.ThrustReferenceFrame);
    public Tuple<double, double, double> GimbalPosition(ReferenceFrame referenceFrame)
        => Internal.GimbalPosition(referenceFrame.Internal);
    public Tuple<double, double, double> InitialThrustDirection(ReferenceFrame referenceFrame)
        => Internal.InitialThrustDirection(referenceFrame.Internal);
    public Tuple<double, double, double> InitialThrustPosition(ReferenceFrame referenceFrame)
        => Internal.InitialThrustPosition(referenceFrame.Internal);
    public Tuple<double, double, double> ThrustDirection(ReferenceFrame referenceFrame)
        => Internal.ThrustDirection(referenceFrame.Internal);
    public Tuple<double, double, double> ThrustPosition(ReferenceFrame referenceFrame)
        => Internal.ThrustPosition(referenceFrame.Internal);
}
