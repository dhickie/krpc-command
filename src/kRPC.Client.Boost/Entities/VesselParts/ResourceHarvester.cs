using KRPC.Client.Services.SpaceCenter;
using BaseResourceHarvester = KRPC.Client.Services.SpaceCenter.ResourceHarvester;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ResourceHarvester object.
/// </summary>
public class ResourceHarvester
{
    internal BaseResourceHarvester Internal { get; }

    internal ResourceHarvester(BaseResourceHarvester resourceHarvester)
    {
        Internal = resourceHarvester;
    }
    public bool Active
    {
        get => Internal.Active;
        set => Internal.Active = value;
    }
    public float CoreTemperature
        => Internal.CoreTemperature;
    public bool Deployed
    {
        get => Internal.Deployed;
        set => Internal.Deployed = value;
    }
    public float ExtractionRate
        => Internal.ExtractionRate;
    public float OptimumCoreTemperature
        => Internal.OptimumCoreTemperature;
    public Part Part
        => new Part(Internal.Part);
    public ResourceHarvesterState State
        => Internal.State;
    public float ThermalEfficiency
        => Internal.ThermalEfficiency;
}
