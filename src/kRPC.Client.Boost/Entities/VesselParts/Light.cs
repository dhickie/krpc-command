using BaseLight = KRPC.Client.Services.SpaceCenter.Light;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Light object.
/// </summary>
public class Light
{
    internal BaseLight Internal { get; }

    internal Light(BaseLight light)
    {
        Internal = light;
    }
    public bool Active
    {
        get => Internal.Active;
        set => Internal.Active = value;
    }
    public bool Blink
    {
        get => Internal.Blink;
        set => Internal.Blink = value;
    }
    public float BlinkRate
    {
        get => Internal.BlinkRate;
        set => Internal.BlinkRate = value;
    }
    public Tuple<float, float, float> Color
    {
        get => Internal.Color;
        set => Internal.Color = value;
    }
    public Part Part
        => new Part(Internal.Part);
    public float PowerUsage
        => Internal.PowerUsage;
}
