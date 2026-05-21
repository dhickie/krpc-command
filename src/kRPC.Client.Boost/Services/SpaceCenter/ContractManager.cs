using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Contracts manager.
/// Obtained by calling <see cref="M:SpaceCenter.GetContractManager" />.
/// </summary>
public class ContractManager : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ContractManager(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets a list of all active contracts.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_ActiveContracts")]
    public IList<Contract> GetActiveContracts()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Contract>>("SpaceCenter", "ContractManager_get_ActiveContracts", args);
    }

    /// <summary>
    /// Gets a list of all active contracts.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_ActiveContracts")]
    public async Task<IList<Contract>> GetActiveContractsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Contract>>("SpaceCenter", "ContractManager_get_ActiveContracts", args);
    }

    /// <summary>
    /// Gets a list of all contracts.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_AllContracts")]
    public IList<Contract> GetAllContracts()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Contract>>("SpaceCenter", "ContractManager_get_AllContracts", args);
    }

    /// <summary>
    /// Gets a list of all contracts.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_AllContracts")]
    public async Task<IList<Contract>> GetAllContractsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Contract>>("SpaceCenter", "ContractManager_get_AllContracts", args);
    }

    /// <summary>
    /// Gets a list of all completed contracts.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_CompletedContracts")]
    public IList<Contract> GetCompletedContracts()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Contract>>("SpaceCenter", "ContractManager_get_CompletedContracts", args);
    }

    /// <summary>
    /// Gets a list of all completed contracts.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_CompletedContracts")]
    public async Task<IList<Contract>> GetCompletedContractsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Contract>>("SpaceCenter", "ContractManager_get_CompletedContracts", args);
    }

    /// <summary>
    /// Gets a list of all failed contracts.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_FailedContracts")]
    public IList<Contract> GetFailedContracts()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Contract>>("SpaceCenter", "ContractManager_get_FailedContracts", args);
    }

    /// <summary>
    /// Gets a list of all failed contracts.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_FailedContracts")]
    public async Task<IList<Contract>> GetFailedContractsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Contract>>("SpaceCenter", "ContractManager_get_FailedContracts", args);
    }

    /// <summary>
    /// Gets a list of all offered, but unaccepted, contracts.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_OfferedContracts")]
    public IList<Contract> GetOfferedContracts()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Contract>>("SpaceCenter", "ContractManager_get_OfferedContracts", args);
    }

    /// <summary>
    /// Gets a list of all offered, but unaccepted, contracts.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_OfferedContracts")]
    public async Task<IList<Contract>> GetOfferedContractsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Contract>>("SpaceCenter", "ContractManager_get_OfferedContracts", args);
    }

    /// <summary>
    /// Gets a list of all contract types.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_Types")]
    public ISet<string> GetTypes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ISet<string>>("SpaceCenter", "ContractManager_get_Types", args);
    }

    /// <summary>
    /// Gets a list of all contract types.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ContractManager_get_Types")]
    public async Task<ISet<string>> GetTypesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ISet<string>>("SpaceCenter", "ContractManager_get_Types", args);
    }
}
