using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseResources = KRPC.Client.Services.SpaceCenter.Resources;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Resources object.
/// </summary>
public class Resources
{
    internal BaseResources Internal { get; }

    internal Resources(BaseResources resources)
    {
        Internal = resources;
    }
    public IList<Resource> All
        => Internal.All.Select(item => new Resource(item)).ToList();
    public bool Enabled
    {
        get => Internal.Enabled;
        set => Internal.Enabled = value;
    }
    public IList<string> Names
        => Internal.Names;
    public float Amount(string name)
        => Internal.Amount(name);
    public bool HasResource(string name)
        => Internal.HasResource(name);
    public float Max(string name)
        => Internal.Max(name);
    public IList<Resource> WithResource(string name)
        => Internal.WithResource(name).Select(item => new Resource(item)).ToList();
    public static float Density(IConnection connection, string name)
        => BaseResources.Density(connection, name);
    public static ResourceFlowMode FlowMode(IConnection connection, string name)
        => BaseResources.FlowMode(connection, name);
}
