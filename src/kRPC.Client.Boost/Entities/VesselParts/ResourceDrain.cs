using KRPC.Client.Services.SpaceCenter;
using BaseResourceDrain = KRPC.Client.Services.SpaceCenter.ResourceDrain;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ResourceDrain object.
/// </summary>
public class ResourceDrain
{
    internal readonly BaseResourceDrain Wrapped;

    internal ResourceDrain(BaseResourceDrain resourceDrain)
    {
        Wrapped = resourceDrain;
    }

    public IList<Resource> AvailableResources
        => Wrapped.AvailableResources.Select(item => new Resource(item)).ToList();

    public DrainMode DrainMode
    {
        get => Wrapped.DrainMode;
        set => Wrapped.DrainMode = value;
    }

    public float MaxRate
        => Wrapped.MaxRate;

    public float MinRate
        => Wrapped.MinRate;

    public Part Part
        => new Part(Wrapped.Part);

    public float Rate
    {
        get => Wrapped.Rate;
        set => Wrapped.Rate = value;
    }

    public bool CheckResource(Resource resource)
        => Wrapped.CheckResource(resource.Wrapped);

    public void SetResource(Resource resource, bool enabled)
        => Wrapped.SetResource(resource.Wrapped, enabled);

    public void Start()
        => Wrapped.Start();

    public void Stop()
        => Wrapped.Stop();
}
