using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using KRPC.Client;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Transfer resources between parts.
/// </summary>
public class ResourceTransfer : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ResourceTransfer(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Start transferring a resource transfer between a pair of parts. The transfer will move
    /// at most <paramref name="maxAmount" /> units of the resource, depending on how much of
    /// the resource is available in the source part and how much storage is available in the
    /// destination part.
    /// Use <see cref="M:SpaceCenter.ResourceTransfer.GetComplete" /> to check if the transfer is complete.
    /// Use <see cref="M:SpaceCenter.ResourceTransfer.GetAmount" /> to see how much of the resource has been transferred.
    /// </summary>
    /// <param name="fromPart">The part to transfer to.</param>
    /// <param name="toPart">The part to transfer from.</param>
    /// <param name="resource">The name of the resource to transfer.</param>
    /// <param name="maxAmount">The maximum amount of resource to transfer.</param>
    [Rpc("SpaceCenter", "ResourceTransfer_static_Start")]
    public ResourceTransfer Start(Part fromPart, Part toPart, string resource, float maxAmount)
    {
        var args = new object[]
        {
            fromPart,
            toPart,
            resource,
            maxAmount
        };
        return Connection.Invoke<ResourceTransfer>("SpaceCenter", "ResourceTransfer_static_Start", args);
    }

    /// <summary>
    /// Start transferring a resource transfer between a pair of parts. The transfer will move
    /// at most <paramref name="maxAmount" /> units of the resource, depending on how much of
    /// the resource is available in the source part and how much storage is available in the
    /// destination part.
    /// Use <see cref="M:SpaceCenter.ResourceTransfer.GetComplete" /> to check if the transfer is complete.
    /// Use <see cref="M:SpaceCenter.ResourceTransfer.GetAmount" /> to see how much of the resource has been transferred.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="fromPart">The part to transfer to.</param>
    /// <param name="toPart">The part to transfer from.</param>
    /// <param name="resource">The name of the resource to transfer.</param>
    /// <param name="maxAmount">The maximum amount of resource to transfer.</param>
    [Rpc("SpaceCenter", "ResourceTransfer_static_Start")]
    public async Task<ResourceTransfer> StartAsync(Part fromPart, Part toPart, string resource, float maxAmount)
    {
        var args = new object[]
        {
            fromPart,
            toPart,
            resource,
            maxAmount
        };
        return await Connection.InvokeAsync<ResourceTransfer>("SpaceCenter", "ResourceTransfer_static_Start", args);
    }

    /// <summary>
    /// Gets the amount of the resource that has been transferred.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceTransfer_get_Amount")]
    public float GetAmount()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ResourceTransfer_get_Amount", args);
    }

    /// <summary>
    /// Gets the amount of the resource that has been transferred.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceTransfer_get_Amount")]
    public async Task<float> GetAmountAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "ResourceTransfer_get_Amount", args);
    }

    /// <summary>
    /// Gets whether the transfer has completed.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceTransfer_get_Complete")]
    public bool GetComplete()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ResourceTransfer_get_Complete", args);
    }

    /// <summary>
    /// Gets whether the transfer has completed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ResourceTransfer_get_Complete")]
    public async Task<bool> GetCompleteAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "ResourceTransfer_get_Complete", args);
    }
}
