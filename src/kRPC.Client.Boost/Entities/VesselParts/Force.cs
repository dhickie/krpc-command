using BaseForce = KRPC.Client.Services.SpaceCenter.Force;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Force object.
/// </summary>
public class Force
{
    internal BaseForce Internal { get; }

    internal Force(BaseForce force)
    {
        Internal = force;
    }
    public Tuple<double, double, double> ForceVector
    {
        get => Internal.ForceVector;
        set => Internal.ForceVector = value;
    }
    public Part Part
        => new Part(Internal.Part);
    public Tuple<double, double, double> Position
    {
        get => Internal.Position;
        set => Internal.Position = value;
    }
    public ReferenceFrame ReferenceFrame
    {
        get => new ReferenceFrame(Internal.ReferenceFrame);
        set => Internal.ReferenceFrame = value.Internal;
    }
    public void Remove()
        => Internal.Remove();
}
