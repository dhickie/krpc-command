using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a communication node in the network. For example, a vessel or the KSC.
/// </summary>
public class CommLink : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CommLink(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Start point of the link.
    /// </summary>
    [Rpc("SpaceCenter", "CommLink_get_End")]
    public CommNode GetEnd()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<CommNode>("SpaceCenter", "CommLink_get_End", args);
    }

    /// <summary>
    /// Start point of the link.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CommLink_get_End")]
    public async Task<CommNode> GetEndAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<CommNode>("SpaceCenter", "CommLink_get_End", args);
    }

    /// <summary>
    /// Signal strength of the link.
    /// </summary>
    [Rpc("SpaceCenter", "CommLink_get_SignalStrength")]
    public double GetSignalStrength()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "CommLink_get_SignalStrength", args);
    }

    /// <summary>
    /// Signal strength of the link.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CommLink_get_SignalStrength")]
    public async Task<double> GetSignalStrengthAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "CommLink_get_SignalStrength", args);
    }

    /// <summary>
    /// Start point of the link.
    /// </summary>
    [Rpc("SpaceCenter", "CommLink_get_Start")]
    public CommNode GetStart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<CommNode>("SpaceCenter", "CommLink_get_Start", args);
    }

    /// <summary>
    /// Start point of the link.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CommLink_get_Start")]
    public async Task<CommNode> GetStartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<CommNode>("SpaceCenter", "CommLink_get_Start", args);
    }

    /// <summary>
    /// Gets the type of link.
    /// </summary>
    [Rpc("SpaceCenter", "CommLink_get_Type")]
    public CommLinkType GetComLinkType()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<CommLinkType>("SpaceCenter", "CommLink_get_Type", args);
    }

    /// <summary>
    /// Gets the type of link.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "CommLink_get_Type")]
    public async Task<CommLinkType> GetComLinkTypeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<CommLinkType>("SpaceCenter", "CommLink_get_Type", args);
    }
}
