using BaseThruster = KRPC.Client.Services.SpaceCenter.Thruster;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Thruster object.
/// </summary>
public class Thruster
{
    internal readonly BaseThruster Wrapped;

    internal Thruster(BaseThruster thruster)
    {
        Wrapped = thruster;
    }

    public Tuple<double, double, double> GimbalAngle
        => Wrapped.GimbalAngle;

    public bool Gimballed
        => Wrapped.Gimballed;

    public Part Part
        => new Part(Wrapped.Part);

    public ReferenceFrame ThrustReferenceFrame
        => new ReferenceFrame(Wrapped.ThrustReferenceFrame);

    public Tuple<double, double, double> GimbalPosition(ReferenceFrame referenceFrame)
        => Wrapped.GimbalPosition(referenceFrame.Wrapped);

    public Tuple<double, double, double> InitialThrustDirection(ReferenceFrame referenceFrame)
        => Wrapped.InitialThrustDirection(referenceFrame.Wrapped);

    public Tuple<double, double, double> InitialThrustPosition(ReferenceFrame referenceFrame)
        => Wrapped.InitialThrustPosition(referenceFrame.Wrapped);

    public Tuple<double, double, double> ThrustDirection(ReferenceFrame referenceFrame)
        => Wrapped.ThrustDirection(referenceFrame.Wrapped);

    public Tuple<double, double, double> ThrustPosition(ReferenceFrame referenceFrame)
        => Wrapped.ThrustPosition(referenceFrame.Wrapped);
}
