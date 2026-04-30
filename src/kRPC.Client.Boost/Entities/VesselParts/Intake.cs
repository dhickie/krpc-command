using BaseIntake = KRPC.Client.Services.SpaceCenter.Intake;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Intake object.
/// </summary>
public class Intake
{
    internal readonly BaseIntake Wrapped;

    internal Intake(BaseIntake intake)
    {
        Wrapped = intake;
    }

    public float Area
        => Wrapped.Area;

    public float Flow
        => Wrapped.Flow;

    public bool Open
    {
        get => Wrapped.Open;
        set => Wrapped.Open = value;
    }

    public Part Part
        => new Part(Wrapped.Part);

    public float Speed
        => Wrapped.Speed;
}
