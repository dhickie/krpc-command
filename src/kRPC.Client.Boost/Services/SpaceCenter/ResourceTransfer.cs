using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using KRPC.Client;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Transfer resources between parts.
/// </summary>
public class ResourceTransfer : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ResourceTransfer (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Start transferring a resource transfer between a pair of parts. The transfer will move
    /// at most <paramref name="maxAmount" /> units of the resource, depending on how much of
    /// the resource is available in the source part and how much storage is available in the
    /// destination part.
    /// Use <see cref="M:SpaceCenter.ResourceTransfer.Complete" /> to check if the transfer is complete.
    /// Use <see cref="M:SpaceCenter.ResourceTransfer.Amount" /> to see how much of the resource has been transferred.
    /// </summary>
    /// <param name="fromPart">The part to transfer to.</param>
    /// <param name="toPart">The part to transfer from.</param>
    /// <param name="resource">The name of the resource to transfer.</param>
    /// <param name="maxAmount">The maximum amount of resource to transfer.</param>
    /// <param name="connection">A connection object.</param>
    [RpcAttribute ("SpaceCenter", "ResourceTransfer_static_Start")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.ResourceTransfer Start (IConnection connection, global::kRPC.Client.Boost.Services.SpaceCenter.Part fromPart, global::kRPC.Client.Boost.Services.SpaceCenter.Part toPart, string resource, float maxAmount)
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (fromPart, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (toPart, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part)),
            global::KRPC.Client.Encoder.Encode (resource, typeof(string)),
            global::KRPC.Client.Encoder.Encode (maxAmount, typeof(float))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ResourceTransfer_static_Start", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.ResourceTransfer)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceTransfer), connection);
    }

    /// <summary>
    /// The amount of the resource that has been transferred.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceTransfer_get_Amount")]
    public float Amount {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceTransfer))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceTransfer_get_Amount", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// Whether the transfer has completed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ResourceTransfer_get_Complete")]
    public bool Complete {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ResourceTransfer))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ResourceTransfer_get_Complete", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }
}
