using BaseSensor = KRPC.Client.Services.SpaceCenter.Sensor;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Sensor object.
/// </summary>
public class Sensor
{
    internal BaseSensor Internal { get; }

    internal Sensor(BaseSensor sensor)
    {
        Internal = sensor;
    }
    public bool Active
    {
        get => Internal.Active;
        set => Internal.Active = value;
    }
    public Part Part
        => new Part(Internal.Part);
    public string Value
        => Internal.Value;
}
