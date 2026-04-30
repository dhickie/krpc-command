using KRPC.Client.Services.SpaceCenter;
using BaseResourceDrain = KRPC.Client.Services.SpaceCenter.ResourceDrain;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ResourceDrain object.
/// </summary>
public class ResourceDrain
{
    internal BaseResourceDrain Internal { get; }

    internal ResourceDrain(BaseResourceDrain resourceDrain)
    {
        Internal = resourceDrain;
    }
    public IList<Resource> AvailableResources
        => Internal.AvailableResources.Select(item => new Resource(item)).ToList();
    public DrainMode DrainMode
    {
        get => Internal.DrainMode;
        set => Internal.DrainMode = value;
    }
    public float MaxRate
        => Internal.MaxRate;
    public float MinRate
        => Internal.MinRate;
    public Part Part
        => new Part(Internal.Part);
    public float Rate
    {
        get => Internal.Rate;
        set => Internal.Rate = value;
    }
    public bool CheckResource(Resource resource)
        => Internal.CheckResource(resource.Internal);
    public void SetResource(Resource resource, bool enabled)
        => Internal.SetResource(resource.Internal, enabled);
    public void Start()
        => Internal.Start();
    public void Stop()
        => Internal.Stop();
}
