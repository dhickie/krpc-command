using KRPC.Client.Services.SpaceCenter;
using BaseResourceConverter = KRPC.Client.Services.SpaceCenter.ResourceConverter;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ResourceConverter object.
/// </summary>
public class ResourceConverter
{
    internal readonly BaseResourceConverter Wrapped;

    internal ResourceConverter(BaseResourceConverter resourceConverter)
    {
        Wrapped = resourceConverter;
    }

    public float CoreTemperature
        => Wrapped.CoreTemperature;

    public int Count
        => Wrapped.Count;

    public float OptimumCoreTemperature
        => Wrapped.OptimumCoreTemperature;

    public Part Part
        => new Part(Wrapped.Part);

    public float ThermalEfficiency
        => Wrapped.ThermalEfficiency;

    public bool Active(int index)
        => Wrapped.Active(index);

    public IList<string> Inputs(int index)
        => Wrapped.Inputs(index);

    public string Name(int index)
        => Wrapped.Name(index);

    public IList<string> Outputs(int index)
        => Wrapped.Outputs(index);

    public void Start(int index)
        => Wrapped.Start(index);

    public ResourceConverterState State(int index)
        => Wrapped.State(index);

    public string StatusInfo(int index)
        => Wrapped.StatusInfo(index);

    public void Stop(int index)
        => Wrapped.Stop(index);
}
