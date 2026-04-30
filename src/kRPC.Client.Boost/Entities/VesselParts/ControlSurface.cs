using BaseControlSurface = KRPC.Client.Services.SpaceCenter.ControlSurface;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ControlSurface object.
/// </summary>
public class ControlSurface
{
    internal readonly BaseControlSurface Wrapped;

    internal ControlSurface(BaseControlSurface controlSurface)
    {
        Wrapped = controlSurface;
    }

    public float AuthorityLimiter
    {
        get => Wrapped.AuthorityLimiter;
        set => Wrapped.AuthorityLimiter = value;
    }

    public Tuple<Tuple<double, double, double>, Tuple<double, double, double>> AvailableTorque
        => Wrapped.AvailableTorque;

    public bool Deployed
    {
        get => Wrapped.Deployed;
        set => Wrapped.Deployed = value;
    }

    public bool Inverted
    {
        get => Wrapped.Inverted;
        set => Wrapped.Inverted = value;
    }

    public Part Part
        => new Part(Wrapped.Part);

    public bool PitchEnabled
    {
        get => Wrapped.PitchEnabled;
        set => Wrapped.PitchEnabled = value;
    }

    public bool RollEnabled
    {
        get => Wrapped.RollEnabled;
        set => Wrapped.RollEnabled = value;
    }

    public float SurfaceArea
        => Wrapped.SurfaceArea;

    public bool YawEnabled
    {
        get => Wrapped.YawEnabled;
        set => Wrapped.YawEnabled = value;
    }
}
