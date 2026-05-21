using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A contract parameter. See <see cref="M:SpaceCenter.Contract.GetParameters" />.
/// </summary>
public class ContractParameter : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ContractParameter (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Child contract parameters.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_Children")]
    public IList<ContractParameter> GetChildren ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<ContractParameter>> ("SpaceCenter", "ContractParameter_get_Children", args);
    }

    /// <summary>
    /// Gets whether the parameter has been completed.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_Completed")]
    public bool GetCompleted ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "ContractParameter_get_Completed", args);
    }

    /// <summary>
    /// Gets whether the parameter has been failed.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_Failed")]
    public bool GetFailed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "ContractParameter_get_Failed", args);
    }

    /// <summary>
    /// Funds received on completion of the contract parameter.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_FundsCompletion")]
    public double GetFundsCompletion ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_FundsCompletion", args);
    }

    /// <summary>
    /// Funds lost if the contract parameter is failed.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_FundsFailure")]
    public double GetFundsFailure ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_FundsFailure", args);
    }

    /// <summary>
    /// Notes for the parameter.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_Notes")]
    public string GetNotes ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "ContractParameter_get_Notes", args);
    }

    /// <summary>
    /// Gets whether the contract parameter is optional.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_Optional")]
    public bool GetOptional ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "ContractParameter_get_Optional", args);
    }

    /// <summary>
    /// Reputation gained on completion of the contract parameter.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_ReputationCompletion")]
    public double GetReputationCompletion ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_ReputationCompletion", args);
    }

    /// <summary>
    /// Reputation lost if the contract parameter is failed.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_ReputationFailure")]
    public double GetReputationFailure ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_ReputationFailure", args);
    }

    /// <summary>
    /// Science gained on completion of the contract parameter.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_ScienceCompletion")]
    public double GetScienceCompletion ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_ScienceCompletion", args);
    }

    /// <summary>
    /// Title of the parameter.
    /// </summary>
    [Rpc ("SpaceCenter", "ContractParameter_get_Title")]
    public string GetTitle ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "ContractParameter_get_Title", args);
    }
}
