using KRPC.Client;
using kRPC.Client.Boost.Extensions;
using MathNet.Spatial.Euclidean;
using BaseReferenceFrame = kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter ReferenceFrame object.
/// </summary>
public class ReferenceFrame
{
    internal readonly BaseReferenceFrame Wrapped;

    internal ReferenceFrame(BaseReferenceFrame referenceFrame)
    {
        Wrapped = referenceFrame;
    }

    public static ReferenceFrame CreateHybrid(IConnection connection, ReferenceFrame position, ReferenceFrame rotation = null, ReferenceFrame velocity = null, ReferenceFrame angularVelocity = null)
        => new ReferenceFrame(BaseReferenceFrame.CreateHybrid(connection, position.Wrapped, rotation?.Wrapped, velocity?.Wrapped, angularVelocity?.Wrapped));

    public static ReferenceFrame CreateRelative(IConnection connection, ReferenceFrame referenceFrame, Vector3D? position = null, Quaternion? rotation = null, Vector3D? velocity = null, Vector3D? angularVelocity = null)
        => new ReferenceFrame(BaseReferenceFrame.CreateRelative(connection, referenceFrame.Wrapped, position?.ToTuple(), rotation?.ToTuple(), velocity?.ToTuple(), angularVelocity?.ToTuple()));
}
