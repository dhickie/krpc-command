using KRPC.Client.Services.SpaceCenter;
using BaseResource = kRPC.Client.Boost.Services.SpaceCenter.Resource;
using ResourceFlowMode = kRPC.Client.Boost.Services.SpaceCenter.ResourceFlowMode;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Resource object.
/// </summary>
public class Resource
{
    internal readonly BaseResource Wrapped;

    internal Resource(BaseResource resource)
    {
        Wrapped = resource;
    }

    public float Amount
        => Wrapped.Amount;

    public float Density
        => Wrapped.Density;

    public bool Enabled
    {
        get => Wrapped.Enabled;
        set => Wrapped.Enabled = value;
    }

    public ResourceFlowMode FlowMode
        => Wrapped.FlowMode;

    public float Max
        => Wrapped.Max;

    public string Name
        => Wrapped.Name;

    public Part Part
        => new Part(Wrapped.Part);
}
