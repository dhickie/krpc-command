using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A contract parameter. See <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Contract.GetParameters" />.
/// </summary>
public class ContractParameter : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal ContractParameter(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Child contract parameters.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Children")]
    public IList<ContractParameter> GetChildren()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<ContractParameter>>("SpaceCenter", "ContractParameter_get_Children", args);
    }

    /// <summary>
    /// Child contract parameters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Children")]
    public async Task<IList<ContractParameter>> GetChildrenAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<ContractParameter>>("SpaceCenter", "ContractParameter_get_Children", args);
    }

    /// <summary>
    /// Gets whether the parameter has been completed.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Completed")]
    public bool GetCompleted()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "ContractParameter_get_Completed", args);
    }

    /// <summary>
    /// Gets whether the parameter has been completed.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Completed")]
    public async Task<bool> GetCompletedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "ContractParameter_get_Completed", args);
    }

    /// <summary>
    /// Gets whether the parameter has been failed.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Failed")]
    public bool GetFailed()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "ContractParameter_get_Failed", args);
    }

    /// <summary>
    /// Gets whether the parameter has been failed.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Failed")]
    public async Task<bool> GetFailedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "ContractParameter_get_Failed", args);
    }

    /// <summary>
    /// Funds received on completion of the contract parameter.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_FundsCompletion")]
    public double GetFundsCompletion()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "ContractParameter_get_FundsCompletion", args);
    }

    /// <summary>
    /// Funds received on completion of the contract parameter.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_FundsCompletion")]
    public async Task<double> GetFundsCompletionAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "ContractParameter_get_FundsCompletion", args);
    }

    /// <summary>
    /// Funds lost if the contract parameter is failed.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_FundsFailure")]
    public double GetFundsFailure()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "ContractParameter_get_FundsFailure", args);
    }

    /// <summary>
    /// Funds lost if the contract parameter is failed.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_FundsFailure")]
    public async Task<double> GetFundsFailureAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "ContractParameter_get_FundsFailure", args);
    }

    /// <summary>
    /// Notes for the parameter.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Notes")]
    public string GetNotes()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<string>("SpaceCenter", "ContractParameter_get_Notes", args);
    }

    /// <summary>
    /// Notes for the parameter.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Notes")]
    public async Task<string> GetNotesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<string>("SpaceCenter", "ContractParameter_get_Notes", args);
    }

    /// <summary>
    /// Gets whether the contract parameter is optional.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Optional")]
    public bool GetOptional()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "ContractParameter_get_Optional", args);
    }

    /// <summary>
    /// Gets whether the contract parameter is optional.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Optional")]
    public async Task<bool> GetOptionalAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "ContractParameter_get_Optional", args);
    }

    /// <summary>
    /// Reputation gained on completion of the contract parameter.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_ReputationCompletion")]
    public double GetReputationCompletion()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "ContractParameter_get_ReputationCompletion", args);
    }

    /// <summary>
    /// Reputation gained on completion of the contract parameter.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_ReputationCompletion")]
    public async Task<double> GetReputationCompletionAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "ContractParameter_get_ReputationCompletion", args);
    }

    /// <summary>
    /// Reputation lost if the contract parameter is failed.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_ReputationFailure")]
    public double GetReputationFailure()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "ContractParameter_get_ReputationFailure", args);
    }

    /// <summary>
    /// Reputation lost if the contract parameter is failed.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_ReputationFailure")]
    public async Task<double> GetReputationFailureAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "ContractParameter_get_ReputationFailure", args);
    }

    /// <summary>
    /// Science gained on completion of the contract parameter.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_ScienceCompletion")]
    public double GetScienceCompletion()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "ContractParameter_get_ScienceCompletion", args);
    }

    /// <summary>
    /// Science gained on completion of the contract parameter.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_ScienceCompletion")]
    public async Task<double> GetScienceCompletionAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "ContractParameter_get_ScienceCompletion", args);
    }

    /// <summary>
    /// Title of the parameter.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Title")]
    public string GetTitle()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<string>("SpaceCenter", "ContractParameter_get_Title", args);
    }

    /// <summary>
    /// Title of the parameter.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "ContractParameter_get_Title")]
    public async Task<string> GetTitleAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<string>("SpaceCenter", "ContractParameter_get_Title", args);
    }
}
