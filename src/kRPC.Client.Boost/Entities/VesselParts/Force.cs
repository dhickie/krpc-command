using kRPC.Client.Boost.Extensions;
using MathNet.Spatial.Euclidean;
using BaseForce = KRPC.Client.Services.SpaceCenter.Force;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Force object.
/// </summary>
public class Force
{
    internal readonly BaseForce Wrapped;

    internal Force(BaseForce force)
    {
        Wrapped = force;
    }

    public Vector3D ForceVector
    {
        get => Wrapped.ForceVector.ToVector3D();
        set => Wrapped.ForceVector = value.ToTuple();
    }

    public Part Part
        => new Part(Wrapped.Part);

    public Vector3D Position
    {
        get => Wrapped.Position.ToVector3D();
        set => Wrapped.Position = value.ToTuple();
    }

    public ReferenceFrame ReferenceFrame
    {
        get => new ReferenceFrame(Wrapped.ReferenceFrame);
        set => Wrapped.ReferenceFrame = value.Wrapped;
    }

    public void Remove()
        => Wrapped.Remove();
}
