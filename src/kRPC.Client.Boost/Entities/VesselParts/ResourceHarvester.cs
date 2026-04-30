using KRPC.Client.Services.SpaceCenter;
using BaseResourceHarvester = KRPC.Client.Services.SpaceCenter.ResourceHarvester;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ResourceHarvester object.
/// </summary>
public class ResourceHarvester
{
    internal readonly BaseResourceHarvester Wrapped;

    internal ResourceHarvester(BaseResourceHarvester resourceHarvester)
    {
        Wrapped = resourceHarvester;
    }

    public bool Active
    {
        get => Wrapped.Active;
        set => Wrapped.Active = value;
    }

    public float CoreTemperature
        => Wrapped.CoreTemperature;

    public bool Deployed
    {
        get => Wrapped.Deployed;
        set => Wrapped.Deployed = value;
    }

    public float ExtractionRate
        => Wrapped.ExtractionRate;

    public float OptimumCoreTemperature
        => Wrapped.OptimumCoreTemperature;

    public Part Part
        => new Part(Wrapped.Part);

    public ResourceHarvesterState State
        => Wrapped.State;

    public float ThermalEfficiency
        => Wrapped.ThermalEfficiency;
}
