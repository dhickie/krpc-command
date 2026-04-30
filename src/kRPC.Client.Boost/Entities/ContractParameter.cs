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
    internal BaseContractParameter Internal { get; }

    internal ContractParameter(BaseContractParameter contractParameter)
    {
        Internal = contractParameter;
    }
    public IList<ContractParameter> Children
        => Internal.Children.Select(item => new ContractParameter(item)).ToList();
    public bool Completed
        => Internal.Completed;
    public bool Failed
        => Internal.Failed;
    public double FundsCompletion
        => Internal.FundsCompletion;
    public double FundsFailure
        => Internal.FundsFailure;
    public string Notes
        => Internal.Notes;
    public bool Optional
        => Internal.Optional;
    public double ReputationCompletion
        => Internal.ReputationCompletion;
    public double ReputationFailure
        => Internal.ReputationFailure;
    public double ScienceCompletion
        => Internal.ScienceCompletion;
    public string Title
        => Internal.Title;
}
