using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Contracts manager.
/// Obtained by calling <see cref="M:SpaceCenter.ContractManager" />.
/// </summary>
public class ContractManager : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ContractManager (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// A list of all active contracts.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractManager_get_ActiveContracts")]
    public IList<Contract> ActiveContracts {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Contract>> ("SpaceCenter", "ContractManager_get_ActiveContracts", args);
        }
    }

    /// <summary>
    /// A list of all contracts.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractManager_get_AllContracts")]
    public IList<Contract> AllContracts {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Contract>> ("SpaceCenter", "ContractManager_get_AllContracts", args);
        }
    }

    /// <summary>
    /// A list of all completed contracts.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractManager_get_CompletedContracts")]
    public IList<Contract> CompletedContracts {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Contract>> ("SpaceCenter", "ContractManager_get_CompletedContracts", args);
        }
    }

    /// <summary>
    /// A list of all failed contracts.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractManager_get_FailedContracts")]
    public IList<Contract> FailedContracts {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Contract>> ("SpaceCenter", "ContractManager_get_FailedContracts", args);
        }
    }

    /// <summary>
    /// A list of all offered, but unaccepted, contracts.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractManager_get_OfferedContracts")]
    public IList<Contract> OfferedContracts {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<Contract>> ("SpaceCenter", "ContractManager_get_OfferedContracts", args);
        }
    }

    /// <summary>
    /// A list of all contract types.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractManager_get_Types")]
    public ISet<string> Types {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ISet<string>> ("SpaceCenter", "ContractManager_get_Types", args);
        }
    }
}
