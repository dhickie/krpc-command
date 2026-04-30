using KRPC.Client;
using BaseResourceTransfer = KRPC.Client.Services.SpaceCenter.ResourceTransfer;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter ResourceTransfer object.
/// </summary>
public class ResourceTransfer
{
    internal BaseResourceTransfer Internal { get; }

    internal ResourceTransfer(BaseResourceTransfer resourceTransfer)
    {
        Internal = resourceTransfer;
    }
    public float Amount
        => Internal.Amount;
    public bool Complete
        => Internal.Complete;
    public static ResourceTransfer Start(IConnection connection, Part fromPart, Part toPart, string resource, float maxAmount)
        => new ResourceTransfer(BaseResourceTransfer.Start(connection, fromPart.Internal, toPart.Internal, resource, maxAmount));
}
