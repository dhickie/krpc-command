using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A contract. Can be accessed using <see cref="M:SpaceCenter.ContractManager" />.
/// </summary>
public class Contract : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Contract (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Accept an offered contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_Accept")]
    public void Accept ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Contract_Accept", _args);
    }

    /// <summary>
    /// Cancel an active contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_Cancel")]
    public void Cancel ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Contract_Cancel", _args);
    }

    /// <summary>
    /// Decline an offered contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_Decline")]
    public void Decline ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Contract_Decline", _args);
    }

    /// <summary>
    /// Whether the contract is active.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Active")]
    public bool Active {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_Active", _args);
        }
    }

    /// <summary>
    /// Whether the contract can be canceled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_CanBeCanceled")]
    public bool CanBeCanceled {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_CanBeCanceled", _args);
        }
    }

    /// <summary>
    /// Whether the contract can be declined.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_CanBeDeclined")]
    public bool CanBeDeclined {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_CanBeDeclined", _args);
        }
    }

    /// <summary>
    /// Whether the contract can be failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_CanBeFailed")]
    public bool CanBeFailed {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_CanBeFailed", _args);
        }
    }

    /// <summary>
    /// Description of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Description")]
    public string Description {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Description", _args);
        }
    }

    /// <summary>
    /// Whether the contract has been failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Failed")]
    public bool Failed {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_Failed", _args);
        }
    }

    /// <summary>
    /// Funds received when accepting the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_FundsAdvance")]
    public double FundsAdvance {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_FundsAdvance", _args);
        }
    }

    /// <summary>
    /// Funds received on completion of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_FundsCompletion")]
    public double FundsCompletion {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_FundsCompletion", _args);
        }
    }

    /// <summary>
    /// Funds lost if the contract is failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_FundsFailure")]
    public double FundsFailure {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_FundsFailure", _args);
        }
    }

    /// <summary>
    /// Keywords for the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Keywords")]
    public IList<string> Keywords {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "Contract_get_Keywords", _args);
        }
    }

    /// <summary>
    /// Notes for the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Notes")]
    public string Notes {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Notes", _args);
        }
    }

    /// <summary>
    /// Parameters for the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Parameters")]
    public IList<ContractParameter> Parameters {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<ContractParameter>> ("SpaceCenter", "Contract_get_Parameters", _args);
        }
    }

    /// <summary>
    /// Whether the contract has been read.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Read")]
    public bool Read {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_Read", _args);
        }
    }

    /// <summary>
    /// Reputation gained on completion of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_ReputationCompletion")]
    public double ReputationCompletion {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_ReputationCompletion", _args);
        }
    }

    /// <summary>
    /// Reputation lost if the contract is failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_ReputationFailure")]
    public double ReputationFailure {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_ReputationFailure", _args);
        }
    }

    /// <summary>
    /// Science gained on completion of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_ScienceCompletion")]
    public double ScienceCompletion {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_ScienceCompletion", _args);
        }
    }

    /// <summary>
    /// Whether the contract has been seen.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Seen")]
    public bool Seen {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_Seen", _args);
        }
    }

    /// <summary>
    /// State of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_State")]
    public ContractState State {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ContractState> ("SpaceCenter", "Contract_get_State", _args);
        }
    }

    /// <summary>
    /// Synopsis for the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Synopsis")]
    public string Synopsis {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Synopsis", _args);
        }
    }

    /// <summary>
    /// Title of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Title")]
    public string Title {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Title", _args);
        }
    }

    /// <summary>
    /// Type of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Type")]
    public string Type {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Type", _args);
        }
    }
}
