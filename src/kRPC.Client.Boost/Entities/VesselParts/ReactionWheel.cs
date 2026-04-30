using BaseReactionWheel = KRPC.Client.Services.SpaceCenter.ReactionWheel;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ReactionWheel object.
/// </summary>
public class ReactionWheel
{
    internal BaseReactionWheel Internal { get; }

    internal ReactionWheel(BaseReactionWheel reactionWheel)
    {
        Internal = reactionWheel;
    }
    public bool Active
    {
        get => Internal.Active;
        set => Internal.Active = value;
    }
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Internal.AvailableTorque;
    public bool Broken
        => Internal.Broken;
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> MaxTorque
        => Internal.MaxTorque;
    public Part Part
        => new Part(Internal.Part);
}
