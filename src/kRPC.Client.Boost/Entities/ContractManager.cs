using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseContractManager = KRPC.Client.Services.SpaceCenter.ContractManager;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter ContractManager object.
/// </summary>
public class ContractManager
{
    internal BaseContractManager Internal { get; }

    internal ContractManager(BaseContractManager contractManager)
    {
        Internal = contractManager;
    }
    public IList<Contract> ActiveContracts
        => Internal.ActiveContracts.Select(item => new Contract(item)).ToList();
    public IList<Contract> AllContracts
        => Internal.AllContracts.Select(item => new Contract(item)).ToList();
    public IList<Contract> CompletedContracts
        => Internal.CompletedContracts.Select(item => new Contract(item)).ToList();
    public IList<Contract> FailedContracts
        => Internal.FailedContracts.Select(item => new Contract(item)).ToList();
    public IList<Contract> OfferedContracts
        => Internal.OfferedContracts.Select(item => new Contract(item)).ToList();
    public ISet<string> Types
        => Internal.Types;
}
