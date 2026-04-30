using KRPC.Client;
using BaseResourceTransfer = KRPC.Client.Services.SpaceCenter.ResourceTransfer;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ResourceTransfer object.
/// </summary>
public class ResourceTransfer
{
    internal readonly BaseResourceTransfer Wrapped;

    internal ResourceTransfer(BaseResourceTransfer resourceTransfer)
    {
        Wrapped = resourceTransfer;
    }

    public float Amount
        => Wrapped.Amount;

    public bool Complete
        => Wrapped.Complete;

    public static ResourceTransfer Start(IConnection connection, Part fromPart, Part toPart, string resource, float maxAmount)
        => new ResourceTransfer(BaseResourceTransfer.Start(connection, fromPart.Wrapped, toPart.Wrapped, resource, maxAmount));
}
