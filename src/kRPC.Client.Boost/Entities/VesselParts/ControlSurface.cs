using BaseControlSurface = KRPC.Client.Services.SpaceCenter.ControlSurface;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ControlSurface object.
/// </summary>
public class ControlSurface
{
    internal BaseControlSurface Internal { get; }

    internal ControlSurface(BaseControlSurface controlSurface)
    {
        Internal = controlSurface;
    }
    public float AuthorityLimiter
    {
        get => Internal.AuthorityLimiter;
        set => Internal.AuthorityLimiter = value;
    }
    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Internal.AvailableTorque;
    public bool Deployed
    {
        get => Internal.Deployed;
        set => Internal.Deployed = value;
    }
    public bool Inverted
    {
        get => Internal.Inverted;
        set => Internal.Inverted = value;
    }
    public Part Part
        => new Part(Internal.Part);
    public bool PitchEnabled
    {
        get => Internal.PitchEnabled;
        set => Internal.PitchEnabled = value;
    }
    public bool RollEnabled
    {
        get => Internal.RollEnabled;
        set => Internal.RollEnabled = value;
    }
    public float SurfaceArea
        => Internal.SurfaceArea;
    public bool YawEnabled
    {
        get => Internal.YawEnabled;
        set => Internal.YawEnabled = value;
    }
}
