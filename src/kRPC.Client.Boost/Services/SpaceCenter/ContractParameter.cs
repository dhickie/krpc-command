using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A contract parameter. See <see cref="M:SpaceCenter.Contract.Parameters" />.
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
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_Children")]
    public IList<ContractParameter> Children {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<ContractParameter>> ("SpaceCenter", "ContractParameter_get_Children", args);
        }
    }

    /// <summary>
    /// Whether the parameter has been completed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_Completed")]
    public bool Completed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ContractParameter_get_Completed", args);
        }
    }

    /// <summary>
    /// Whether the parameter has been failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_Failed")]
    public bool Failed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ContractParameter_get_Failed", args);
        }
    }

    /// <summary>
    /// Funds received on completion of the contract parameter.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_FundsCompletion")]
    public double FundsCompletion {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_FundsCompletion", args);
        }
    }

    /// <summary>
    /// Funds lost if the contract parameter is failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_FundsFailure")]
    public double FundsFailure {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_FundsFailure", args);
        }
    }

    /// <summary>
    /// Notes for the parameter.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_Notes")]
    public string Notes {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "ContractParameter_get_Notes", args);
        }
    }

    /// <summary>
    /// Whether the contract parameter is optional.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_Optional")]
    public bool Optional {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ContractParameter_get_Optional", args);
        }
    }

    /// <summary>
    /// Reputation gained on completion of the contract parameter.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_ReputationCompletion")]
    public double ReputationCompletion {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_ReputationCompletion", args);
        }
    }

    /// <summary>
    /// Reputation lost if the contract parameter is failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_ReputationFailure")]
    public double ReputationFailure {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_ReputationFailure", args);
        }
    }

    /// <summary>
    /// Science gained on completion of the contract parameter.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_ScienceCompletion")]
    public double ScienceCompletion {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "ContractParameter_get_ScienceCompletion", args);
        }
    }

    /// <summary>
    /// Title of the parameter.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ContractParameter_get_Title")]
    public string Title {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "ContractParameter_get_Title", args);
        }
    }
}
