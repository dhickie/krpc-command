using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a communication node in the network. For example, a vessel or the KSC.
/// </summary>
public class CommLink : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CommLink (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Start point of the link.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CommLink_get_End")]
    public CommNode End {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<CommNode> ("SpaceCenter", "CommLink_get_End", _args);
        }
    }

    /// <summary>
    /// Signal strength of the link.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CommLink_get_SignalStrength")]
    public double SignalStrength {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "CommLink_get_SignalStrength", _args);
        }
    }

    /// <summary>
    /// Start point of the link.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CommLink_get_Start")]
    public CommNode Start {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<CommNode> ("SpaceCenter", "CommLink_get_Start", _args);
        }
    }

    /// <summary>
    /// The type of link.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "CommLink_get_Type")]
    public CommLinkType Type {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<CommLinkType> ("SpaceCenter", "CommLink_get_Type", _args);
        }
    }
}
