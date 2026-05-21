using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A contract. Can be accessed using <see cref="M:SpaceCenter.GetContractManager" />.
/// </summary>
public class Contract : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Contract(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Accept an offered contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_Accept")]
    public void Accept()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Contract_Accept", args);
    }

    /// <summary>
    /// Accept an offered contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_Accept")]
    public async Task AcceptAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Contract_Accept", args);
    }

    /// <summary>
    /// Cancel an active contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_Cancel")]
    public void Cancel()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Contract_Cancel", args);
    }

    /// <summary>
    /// Cancel an active contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_Cancel")]
    public async Task CancelAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Contract_Cancel", args);
    }

    /// <summary>
    /// Decline an offered contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_Decline")]
    public void Decline()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Contract_Decline", args);
    }

    /// <summary>
    /// Decline an offered contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_Decline")]
    public async Task DeclineAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Contract_Decline", args);
    }

    /// <summary>
    /// Gets whether the contract is active.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Active")]
    public bool GetActive()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Contract_get_Active", args);
    }

    /// <summary>
    /// Gets whether the contract is active.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Active")]
    public async Task<bool> GetActiveAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Contract_get_Active", args);
    }

    /// <summary>
    /// Gets whether the contract can be canceled.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_CanBeCanceled")]
    public bool GetCanBeCanceled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Contract_get_CanBeCanceled", args);
    }

    /// <summary>
    /// Gets whether the contract can be canceled.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_CanBeCanceled")]
    public async Task<bool> GetCanBeCanceledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Contract_get_CanBeCanceled", args);
    }

    /// <summary>
    /// Gets whether the contract can be declined.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_CanBeDeclined")]
    public bool GetCanBeDeclined()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Contract_get_CanBeDeclined", args);
    }

    /// <summary>
    /// Gets whether the contract can be declined.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_CanBeDeclined")]
    public async Task<bool> GetCanBeDeclinedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Contract_get_CanBeDeclined", args);
    }

    /// <summary>
    /// Gets whether the contract can be failed.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_CanBeFailed")]
    public bool GetCanBeFailed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Contract_get_CanBeFailed", args);
    }

    /// <summary>
    /// Gets whether the contract can be failed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_CanBeFailed")]
    public async Task<bool> GetCanBeFailedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Contract_get_CanBeFailed", args);
    }

    /// <summary>
    /// Description of the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Description")]
    public string GetDescription()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Contract_get_Description", args);
    }

    /// <summary>
    /// Description of the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Description")]
    public async Task<string> GetDescriptionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Contract_get_Description", args);
    }

    /// <summary>
    /// Gets whether the contract has been failed.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Failed")]
    public bool GetFailed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Contract_get_Failed", args);
    }

    /// <summary>
    /// Gets whether the contract has been failed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Failed")]
    public async Task<bool> GetFailedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Contract_get_Failed", args);
    }

    /// <summary>
    /// Funds received when accepting the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_FundsAdvance")]
    public double GetFundsAdvance()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Contract_get_FundsAdvance", args);
    }

    /// <summary>
    /// Funds received when accepting the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_FundsAdvance")]
    public async Task<double> GetFundsAdvanceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Contract_get_FundsAdvance", args);
    }

    /// <summary>
    /// Funds received on completion of the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_FundsCompletion")]
    public double GetFundsCompletion()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Contract_get_FundsCompletion", args);
    }

    /// <summary>
    /// Funds received on completion of the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_FundsCompletion")]
    public async Task<double> GetFundsCompletionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Contract_get_FundsCompletion", args);
    }

    /// <summary>
    /// Funds lost if the contract is failed.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_FundsFailure")]
    public double GetFundsFailure()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Contract_get_FundsFailure", args);
    }

    /// <summary>
    /// Funds lost if the contract is failed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_FundsFailure")]
    public async Task<double> GetFundsFailureAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Contract_get_FundsFailure", args);
    }

    /// <summary>
    /// Keywords for the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Keywords")]
    public IList<string> GetKeywords()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "Contract_get_Keywords", args);
    }

    /// <summary>
    /// Keywords for the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Keywords")]
    public async Task<IList<string>> GetKeywordsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "Contract_get_Keywords", args);
    }

    /// <summary>
    /// Notes for the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Notes")]
    public string GetNotes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Contract_get_Notes", args);
    }

    /// <summary>
    /// Notes for the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Notes")]
    public async Task<string> GetNotesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Contract_get_Notes", args);
    }

    /// <summary>
    /// Parameters for the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Parameters")]
    public IList<ContractParameter> GetParameters()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<ContractParameter>>("SpaceCenter", "Contract_get_Parameters", args);
    }

    /// <summary>
    /// Parameters for the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Parameters")]
    public async Task<IList<ContractParameter>> GetParametersAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<ContractParameter>>("SpaceCenter", "Contract_get_Parameters", args);
    }

    /// <summary>
    /// Gets whether the contract has been read.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Read")]
    public bool GetRead()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Contract_get_Read", args);
    }

    /// <summary>
    /// Gets whether the contract has been read.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Read")]
    public async Task<bool> GetReadAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Contract_get_Read", args);
    }

    /// <summary>
    /// Reputation gained on completion of the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_ReputationCompletion")]
    public double GetReputationCompletion()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Contract_get_ReputationCompletion", args);
    }

    /// <summary>
    /// Reputation gained on completion of the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_ReputationCompletion")]
    public async Task<double> GetReputationCompletionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Contract_get_ReputationCompletion", args);
    }

    /// <summary>
    /// Reputation lost if the contract is failed.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_ReputationFailure")]
    public double GetReputationFailure()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Contract_get_ReputationFailure", args);
    }

    /// <summary>
    /// Reputation lost if the contract is failed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_ReputationFailure")]
    public async Task<double> GetReputationFailureAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Contract_get_ReputationFailure", args);
    }

    /// <summary>
    /// Science gained on completion of the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_ScienceCompletion")]
    public double GetScienceCompletion()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Contract_get_ScienceCompletion", args);
    }

    /// <summary>
    /// Science gained on completion of the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_ScienceCompletion")]
    public async Task<double> GetScienceCompletionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Contract_get_ScienceCompletion", args);
    }

    /// <summary>
    /// Gets whether the contract has been seen.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Seen")]
    public bool GetSeen()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Contract_get_Seen", args);
    }

    /// <summary>
    /// Gets whether the contract has been seen.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Seen")]
    public async Task<bool> GetSeenAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Contract_get_Seen", args);
    }

    /// <summary>
    /// State of the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_State")]
    public ContractState GetState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ContractState>("SpaceCenter", "Contract_get_State", args);
    }

    /// <summary>
    /// State of the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_State")]
    public async Task<ContractState> GetStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ContractState>("SpaceCenter", "Contract_get_State", args);
    }

    /// <summary>
    /// Synopsis for the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Synopsis")]
    public string GetSynopsis()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Contract_get_Synopsis", args);
    }

    /// <summary>
    /// Synopsis for the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Synopsis")]
    public async Task<string> GetSynopsisAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Contract_get_Synopsis", args);
    }

    /// <summary>
    /// Title of the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Title")]
    public string GetTitle()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Contract_get_Title", args);
    }

    /// <summary>
    /// Title of the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Title")]
    public async Task<string> GetTitleAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Contract_get_Title", args);
    }

    /// <summary>
    /// Type of the contract.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Type")]
    public string GetContractType()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Contract_get_Type", args);
    }

    /// <summary>
    /// Type of the contract.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Contract_get_Type")]
    public async Task<string> GetContractTypeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Contract_get_Type", args);
    }
}
