using KRPC.Client.Services.SpaceCenter;
using BaseResource = KRPC.Client.Services.SpaceCenter.Resource;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Resource object.
/// </summary>
public class Resource
{
    internal BaseResource Internal { get; }

    internal Resource(BaseResource resource)
    {
        Internal = resource;
    }
    public float Amount
        => Internal.Amount;
    public float Density
        => Internal.Density;
    public bool Enabled
    {
        get => Internal.Enabled;
        set => Internal.Enabled = value;
    }
    public ResourceFlowMode FlowMode
        => Internal.FlowMode;
    public float Max
        => Internal.Max;
    public string Name
        => Internal.Name;
    public Part Part
        => new Part(Internal.Part);
}
