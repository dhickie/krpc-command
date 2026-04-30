using BaseLight = KRPC.Client.Services.SpaceCenter.Light;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Light object.
/// </summary>
public class Light
{
    internal readonly BaseLight Wrapped;

    internal Light(BaseLight light)
    {
        Wrapped = light;
    }

    public bool Active
    {
        get => Wrapped.Active;
        set => Wrapped.Active = value;
    }

    public bool Blink
    {
        get => Wrapped.Blink;
        set => Wrapped.Blink = value;
    }

    public float BlinkRate
    {
        get => Wrapped.BlinkRate;
        set => Wrapped.BlinkRate = value;
    }

    public Tuple<float, float, float> Color
    {
        get => Wrapped.Color;
        set => Wrapped.Color = value;
    }

    public Part Part
        => new Part(Wrapped.Part);

    public float PowerUsage
        => Wrapped.PowerUsage;
}
