using kRPC.Client.Boost.Extensions;
using MathNet.Spatial.Euclidean;
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

    public Vector3D GimbalAngle
        => Wrapped.GimbalAngle.ToVector3D();

    public bool Gimballed
        => Wrapped.Gimballed;

    public Part Part
        => new Part(Wrapped.Part);

    public ReferenceFrame ThrustReferenceFrame
        => new ReferenceFrame(Wrapped.ThrustReferenceFrame);

    public Vector3D GimbalPosition(ReferenceFrame referenceFrame)
        => Wrapped.GimbalPosition(referenceFrame.Wrapped).ToVector3D();

    public Vector3D InitialThrustDirection(ReferenceFrame referenceFrame)
        => Wrapped.InitialThrustDirection(referenceFrame.Wrapped).ToVector3D();

    public Vector3D InitialThrustPosition(ReferenceFrame referenceFrame)
        => Wrapped.InitialThrustPosition(referenceFrame.Wrapped).ToVector3D();

    public Vector3D ThrustDirection(ReferenceFrame referenceFrame)
        => Wrapped.ThrustDirection(referenceFrame.Wrapped).ToVector3D();

    public Vector3D ThrustPosition(ReferenceFrame referenceFrame)
        => Wrapped.ThrustPosition(referenceFrame.Wrapped).ToVector3D();
}
