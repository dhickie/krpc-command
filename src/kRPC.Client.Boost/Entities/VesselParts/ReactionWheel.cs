using kRPC.Client.Boost.Extensions;
using MathNet.Spatial.Euclidean;
using BaseReactionWheel = kRPC.Client.Boost.Services.SpaceCenter.ReactionWheel;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ReactionWheel object.
/// </summary>
public class ReactionWheel
{
    internal readonly BaseReactionWheel Wrapped;

    internal ReactionWheel(BaseReactionWheel reactionWheel)
    {
        Wrapped = reactionWheel;
    }

    public bool Active
    {
        get => Wrapped.Active;
        set => Wrapped.Active = value;
    }

    public Tuple<Vector3D, Vector3D> AvailableTorque
        => Wrapped.AvailableTorque.ToTupleVector3D();

    public bool Broken
        => Wrapped.Broken;

    public Tuple<Vector3D, Vector3D> MaxTorque
        => Wrapped.MaxTorque.ToTupleVector3D();

    public Part Part
        => new Part(Wrapped.Part);
}
