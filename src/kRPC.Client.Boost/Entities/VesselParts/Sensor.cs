using BaseSensor = KRPC.Client.Services.SpaceCenter.Sensor;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Sensor object.
/// </summary>
public class Sensor
{
    internal readonly BaseSensor Wrapped;

    internal Sensor(BaseSensor sensor)
    {
        Wrapped = sensor;
    }

    public bool Active
    {
        get => Wrapped.Active;
        set => Wrapped.Active = value;
    }

    public Part Part
        => new Part(Wrapped.Part);

    public string Value
        => Wrapped.Value;
}
