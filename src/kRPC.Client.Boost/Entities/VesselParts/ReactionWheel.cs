using BaseReactionWheel = KRPC.Client.Services.SpaceCenter.ReactionWheel;

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

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Wrapped.AvailableTorque;

    public bool Broken
        => Wrapped.Broken;

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> MaxTorque
        => Wrapped.MaxTorque;

    public Part Part
        => new Part(Wrapped.Part);
}
