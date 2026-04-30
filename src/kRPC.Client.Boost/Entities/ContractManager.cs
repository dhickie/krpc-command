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
    internal readonly BaseContractManager Wrapped;

    internal ContractManager(BaseContractManager contractManager)
    {
        Wrapped = contractManager;
    }

    public IList<Contract> ActiveContracts
        => Wrapped.ActiveContracts.Select(item => new Contract(item)).ToList();

    public IList<Contract> AllContracts
        => Wrapped.AllContracts.Select(item => new Contract(item)).ToList();

    public IList<Contract> CompletedContracts
        => Wrapped.CompletedContracts.Select(item => new Contract(item)).ToList();

    public IList<Contract> FailedContracts
        => Wrapped.FailedContracts.Select(item => new Contract(item)).ToList();

    public IList<Contract> OfferedContracts
        => Wrapped.OfferedContracts.Select(item => new Contract(item)).ToList();

    public ISet<string> Types
        => Wrapped.Types;
}
