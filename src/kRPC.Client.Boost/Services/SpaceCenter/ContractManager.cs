using Google.Protobuf;
using genericCollectionsAlias = System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Contracts manager.
/// Obtained by calling <see cref="M:SpaceCenter.ContractManager" />.
/// </summary>
public class ContractManager : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ContractManager (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
    {
    }

    /// <summary>
    /// A list of all active contracts.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_ActiveContracts")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract> ActiveContracts {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ContractManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_ActiveContracts", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>), connection);
        }
    }

    /// <summary>
    /// A list of all contracts.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_AllContracts")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract> AllContracts {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ContractManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_AllContracts", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>), connection);
        }
    }

    /// <summary>
    /// A list of all completed contracts.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_CompletedContracts")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract> CompletedContracts {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ContractManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_CompletedContracts", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>), connection);
        }
    }

    /// <summary>
    /// A list of all failed contracts.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_FailedContracts")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract> FailedContracts {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ContractManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_FailedContracts", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>), connection);
        }
    }

    /// <summary>
    /// A list of all offered, but unaccepted, contracts.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_OfferedContracts")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract> OfferedContracts {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ContractManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_OfferedContracts", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.Contract>), connection);
        }
    }

    /// <summary>
    /// A list of all contract types.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ContractManager_get_Types")]
    public genericCollectionsAlias::ISet<string> Types {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ContractManager))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "ContractManager_get_Types", _args);
            return (genericCollectionsAlias::ISet<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(genericCollectionsAlias::ISet<string>), connection);
        }
    }
}