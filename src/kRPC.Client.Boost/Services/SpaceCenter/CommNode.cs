using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a communication node in the network. For example, a vessel or the KSC.
/// </summary>
public class CommNode : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CommNode (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the communication node is a control point, for example a manned vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "CommNode_get_IsControlPoint")]
    public bool GetIsControlPoint ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CommNode_get_IsControlPoint", args);
    }

    /// <summary>
    /// Whether the communication node is on Kerbin.
    /// </summary>
    [Rpc ("SpaceCenter", "CommNode_get_IsHome")]
    public bool GetIsHome ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CommNode_get_IsHome", args);
    }

    /// <summary>
    /// Whether the communication node is a vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "CommNode_get_IsVessel")]
    public bool GetIsVessel ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CommNode_get_IsVessel", args);
    }

    /// <summary>
    /// Name of the communication node.
    /// </summary>
    [Rpc ("SpaceCenter", "CommNode_get_Name")]
    public string GetName ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "CommNode_get_Name", args);
    }

    /// <summary>
    /// The vessel for this communication node.
    /// </summary>
    [Rpc ("SpaceCenter", "CommNode_get_Vessel")]
    public Vessel GetVessel ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Vessel> ("SpaceCenter", "CommNode_get_Vessel", args);
    }
}
