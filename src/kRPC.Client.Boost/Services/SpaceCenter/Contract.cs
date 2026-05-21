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
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Contract_Accept", args);
    }

    /// <summary>
    /// Cancel an active contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_Cancel")]
    public void Cancel ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Contract_Cancel", args);
    }

    /// <summary>
    /// Decline an offered contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_Decline")]
    public void Decline ()
    {
        var args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Contract_Decline", args);
    }

    /// <summary>
    /// Whether the contract is active.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Active")]
    public bool Active {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_Active", args);
        }
    }

    /// <summary>
    /// Whether the contract can be canceled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_CanBeCanceled")]
    public bool CanBeCanceled {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_CanBeCanceled", args);
        }
    }

    /// <summary>
    /// Whether the contract can be declined.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_CanBeDeclined")]
    public bool CanBeDeclined {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_CanBeDeclined", args);
        }
    }

    /// <summary>
    /// Whether the contract can be failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_CanBeFailed")]
    public bool CanBeFailed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_CanBeFailed", args);
        }
    }

    /// <summary>
    /// Description of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Description")]
    public string Description {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Description", args);
        }
    }

    /// <summary>
    /// Whether the contract has been failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Failed")]
    public bool Failed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_Failed", args);
        }
    }

    /// <summary>
    /// Funds received when accepting the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_FundsAdvance")]
    public double FundsAdvance {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_FundsAdvance", args);
        }
    }

    /// <summary>
    /// Funds received on completion of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_FundsCompletion")]
    public double FundsCompletion {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_FundsCompletion", args);
        }
    }

    /// <summary>
    /// Funds lost if the contract is failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_FundsFailure")]
    public double FundsFailure {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_FundsFailure", args);
        }
    }

    /// <summary>
    /// Keywords for the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Keywords")]
    public IList<string> Keywords {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "Contract_get_Keywords", args);
        }
    }

    /// <summary>
    /// Notes for the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Notes")]
    public string Notes {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Notes", args);
        }
    }

    /// <summary>
    /// Parameters for the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Parameters")]
    public IList<ContractParameter> Parameters {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<IList<ContractParameter>> ("SpaceCenter", "Contract_get_Parameters", args);
        }
    }

    /// <summary>
    /// Whether the contract has been read.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Read")]
    public bool Read {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_Read", args);
        }
    }

    /// <summary>
    /// Reputation gained on completion of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_ReputationCompletion")]
    public double ReputationCompletion {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_ReputationCompletion", args);
        }
    }

    /// <summary>
    /// Reputation lost if the contract is failed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_ReputationFailure")]
    public double ReputationFailure {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_ReputationFailure", args);
        }
    }

    /// <summary>
    /// Science gained on completion of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_ScienceCompletion")]
    public double ScienceCompletion {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Contract_get_ScienceCompletion", args);
        }
    }

    /// <summary>
    /// Whether the contract has been seen.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Seen")]
    public bool Seen {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "Contract_get_Seen", args);
        }
    }

    /// <summary>
    /// State of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_State")]
    public ContractState State {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<ContractState> ("SpaceCenter", "Contract_get_State", args);
        }
    }

    /// <summary>
    /// Synopsis for the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Synopsis")]
    public string Synopsis {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Synopsis", args);
        }
    }

    /// <summary>
    /// Title of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Title")]
    public string Title {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Title", args);
        }
    }

    /// <summary>
    /// Type of the contract.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Contract_get_Type")]
    public string Type {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Contract_get_Type", args);
        }
    }
}
