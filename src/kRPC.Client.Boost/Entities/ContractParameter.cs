using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseContractParameter = KRPC.Client.Services.SpaceCenter.ContractParameter;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter ContractParameter object.
/// </summary>
public class ContractParameter
{
    internal readonly BaseContractParameter Wrapped;

    internal ContractParameter(BaseContractParameter contractParameter)
    {
        Wrapped = contractParameter;
    }

    public IList<ContractParameter> Children
        => Wrapped.Children.Select(item => new ContractParameter(item)).ToList();

    public bool Completed
        => Wrapped.Completed;

    public bool Failed
        => Wrapped.Failed;

    public double FundsCompletion
        => Wrapped.FundsCompletion;

    public double FundsFailure
        => Wrapped.FundsFailure;

    public string Notes
        => Wrapped.Notes;

    public bool Optional
        => Wrapped.Optional;

    public double ReputationCompletion
        => Wrapped.ReputationCompletion;

    public double ReputationFailure
        => Wrapped.ReputationFailure;

    public double ScienceCompletion
        => Wrapped.ScienceCompletion;

    public string Title
        => Wrapped.Title;
}
