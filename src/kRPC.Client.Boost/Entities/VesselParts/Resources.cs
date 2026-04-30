using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseResources = KRPC.Client.Services.SpaceCenter.Resources;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Resources object.
/// </summary>
public class Resources
{
    internal readonly BaseResources Wrapped;

    internal Resources(BaseResources resources)
    {
        Wrapped = resources;
    }

    public IList<Resource> All
        => Wrapped.All.Select(item => new Resource(item)).ToList();

    public bool Enabled
    {
        get => Wrapped.Enabled;
        set => Wrapped.Enabled = value;
    }

    public IList<string> Names
        => Wrapped.Names;

    public float Amount(string name)
        => Wrapped.Amount(name);

    public bool HasResource(string name)
        => Wrapped.HasResource(name);

    public float Max(string name)
        => Wrapped.Max(name);

    public IList<Resource> WithResource(string name)
        => Wrapped.WithResource(name).Select(item => new Resource(item)).ToList();

    public static float Density(IConnection connection, string name)
        => BaseResources.Density(connection, name);

    public static ResourceFlowMode FlowMode(IConnection connection, string name)
        => BaseResources.FlowMode(connection, name);
}
