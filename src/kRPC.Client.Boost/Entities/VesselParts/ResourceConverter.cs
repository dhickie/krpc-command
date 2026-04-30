using KRPC.Client.Services.SpaceCenter;
using BaseResourceConverter = KRPC.Client.Services.SpaceCenter.ResourceConverter;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ResourceConverter object.
/// </summary>
public class ResourceConverter
{
    internal BaseResourceConverter Internal { get; }

    internal ResourceConverter(BaseResourceConverter resourceConverter)
    {
        Internal = resourceConverter;
    }
    public float CoreTemperature
        => Internal.CoreTemperature;
    public int Count
        => Internal.Count;
    public float OptimumCoreTemperature
        => Internal.OptimumCoreTemperature;
    public Part Part
        => new Part(Internal.Part);
    public float ThermalEfficiency
        => Internal.ThermalEfficiency;
    public bool Active(int index)
        => Internal.Active(index);
    public IList<string> Inputs(int index)
        => Internal.Inputs(index);
    public string Name(int index)
        => Internal.Name(index);
    public IList<string> Outputs(int index)
        => Internal.Outputs(index);
    public void Start(int index)
        => Internal.Start(index);
    public ResourceConverterState State(int index)
        => Internal.State(index);
    public string StatusInfo(int index)
        => Internal.StatusInfo(index);
    public void Stop(int index)
        => Internal.Stop(index);
}
