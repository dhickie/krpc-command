using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A contract. Can be accessed using <see cref="M:SpaceCenter.ContractManager" />.
/// </summary>
public class Contract : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Contract (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// Accept an offered contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_Accept")]
    public void Accept ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
        };
        connection.Invoke ("SpaceCenter", "Contract_Accept", _args);
    }

    /// <summary>
    /// Cancel an active contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_Cancel")]
    public void Cancel ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
        };
        connection.Invoke ("SpaceCenter", "Contract_Cancel", _args);
    }

    /// <summary>
    /// Decline an offered contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_Decline")]
    public void Decline ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
        };
        connection.Invoke ("SpaceCenter", "Contract_Decline", _args);
    }

    /// <summary>
    /// Whether the contract is active.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Active")]
    public bool Active {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Active", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the contract can be canceled.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_CanBeCanceled")]
    public bool CanBeCanceled {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_CanBeCanceled", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the contract can be declined.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_CanBeDeclined")]
    public bool CanBeDeclined {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_CanBeDeclined", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether the contract can be failed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_CanBeFailed")]
    public bool CanBeFailed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_CanBeFailed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Description of the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Description")]
    public string Description {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Description", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// Whether the contract has been failed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Failed")]
    public bool Failed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Failed", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Funds received when accepting the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_FundsAdvance")]
    public double FundsAdvance {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_FundsAdvance", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Funds received on completion of the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_FundsCompletion")]
    public double FundsCompletion {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_FundsCompletion", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Funds lost if the contract is failed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_FundsFailure")]
    public double FundsFailure {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_FundsFailure", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Keywords for the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Keywords")]
    public global::System.Collections.Generic.IList<string> Keywords {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Keywords", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// Notes for the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Notes")]
    public string Notes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Notes", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// Parameters for the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Parameters")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ContractParameter> Parameters {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Parameters", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ContractParameter>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.ContractParameter>), connection);
        }
    }

    /// <summary>
    /// Whether the contract has been read.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Read")]
    public bool Read {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Read", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Reputation gained on completion of the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_ReputationCompletion")]
    public double ReputationCompletion {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_ReputationCompletion", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Reputation lost if the contract is failed.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_ReputationFailure")]
    public double ReputationFailure {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_ReputationFailure", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Science gained on completion of the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_ScienceCompletion")]
    public double ScienceCompletion {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_ScienceCompletion", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Whether the contract has been seen.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Seen")]
    public bool Seen {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Seen", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// State of the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_State")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ContractState State {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_State", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ContractState)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ContractState), connection);
        }
    }

    /// <summary>
    /// Synopsis for the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Synopsis")]
    public string Synopsis {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Synopsis", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// Title of the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Title")]
    public string Title {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Title", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// Type of the contract.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Contract_get_Type")]
    public string Type {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Contract))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Contract_get_Type", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }
}