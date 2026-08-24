using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Contracts manager.
/// Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetContractManager" />.
/// </summary>
public class ContractManager : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal ContractManager(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets a list of all active contracts.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_ActiveContracts")]
    public List<Contract> GetActiveContracts()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Contract>>("SpaceCenter", "ContractManager_get_ActiveContracts", args);
    }

    /// <summary>
    /// Gets a list of all active contracts.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_ActiveContracts")]
    public async Task<List<Contract>> GetActiveContractsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Contract>>("SpaceCenter", "ContractManager_get_ActiveContracts", args);
    }

    /// <summary>
    /// Gets a list of all contracts.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_AllContracts")]
    public List<Contract> GetAllContracts()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Contract>>("SpaceCenter", "ContractManager_get_AllContracts", args);
    }

    /// <summary>
    /// Gets a list of all contracts.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_AllContracts")]
    public async Task<List<Contract>> GetAllContractsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Contract>>("SpaceCenter", "ContractManager_get_AllContracts", args);
    }

    /// <summary>
    /// Gets a list of all completed contracts.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_CompletedContracts")]
    public List<Contract> GetCompletedContracts()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Contract>>("SpaceCenter", "ContractManager_get_CompletedContracts", args);
    }

    /// <summary>
    /// Gets a list of all completed contracts.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_CompletedContracts")]
    public async Task<List<Contract>> GetCompletedContractsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Contract>>("SpaceCenter", "ContractManager_get_CompletedContracts", args);
    }

    /// <summary>
    /// Gets a list of all failed contracts.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_FailedContracts")]
    public List<Contract> GetFailedContracts()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Contract>>("SpaceCenter", "ContractManager_get_FailedContracts", args);
    }

    /// <summary>
    /// Gets a list of all failed contracts.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_FailedContracts")]
    public async Task<List<Contract>> GetFailedContractsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Contract>>("SpaceCenter", "ContractManager_get_FailedContracts", args);
    }

    /// <summary>
    /// Gets a list of all offered, but unaccepted, contracts.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_OfferedContracts")]
    public List<Contract> GetOfferedContracts()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Contract>>("SpaceCenter", "ContractManager_get_OfferedContracts", args);
    }

    /// <summary>
    /// Gets a list of all offered, but unaccepted, contracts.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_OfferedContracts")]
    public async Task<List<Contract>> GetOfferedContractsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Contract>>("SpaceCenter", "ContractManager_get_OfferedContracts", args);
    }

    /// <summary>
    /// Gets a list of all contract types.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_Types")]
    public ISet<string> GetTypes()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<HashSet<string>>("SpaceCenter", "ContractManager_get_Types", args);
    }

    /// <summary>
    /// Gets a list of all contract types.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractManager_get_Types")]
    public async Task<ISet<string>> GetTypesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<HashSet<string>>("SpaceCenter", "ContractManager_get_Types", args);
    }
}
