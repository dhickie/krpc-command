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

    public Tuple<double, double, double> ForceVector
    {
        get => Wrapped.ForceVector;
        set => Wrapped.ForceVector = value;
    }

    public Part Part
        => new Part(Wrapped.Part);

    public Tuple<double, double, double> Position
    {
        get => Wrapped.Position;
        set => Wrapped.Position = value;
    }

    public ReferenceFrame ReferenceFrame
    {
        get => new ReferenceFrame(Wrapped.ReferenceFrame);
        set => Wrapped.ReferenceFrame = value.Wrapped;
    }

    public void Remove()
        => Wrapped.Remove();
}
