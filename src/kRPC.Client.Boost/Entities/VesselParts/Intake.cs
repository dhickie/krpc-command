using BaseIntake = KRPC.Client.Services.SpaceCenter.Intake;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Intake object.
/// </summary>
public class Intake
{
    internal BaseIntake Internal { get; }

    internal Intake(BaseIntake intake)
    {
        Internal = intake;
    }
    public float Area
        => Internal.Area;
    public float Flow
        => Internal.Flow;
    public bool Open
    {
        get => Internal.Open;
        set => Internal.Open = value;
    }
    public Part Part
        => new Part(Internal.Part);
    public float Speed
        => Internal.Speed;
}
