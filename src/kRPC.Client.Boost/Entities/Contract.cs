using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseContract = KRPC.Client.Services.SpaceCenter.Contract;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Contract object.
/// </summary>
public class Contract
{
    internal readonly BaseContract Wrapped;

    internal Contract(BaseContract contract)
    {
        Wrapped = contract;
    }

    public bool Active
        => Wrapped.Active;

    public bool CanBeCanceled
        => Wrapped.CanBeCanceled;

    public bool CanBeDeclined
        => Wrapped.CanBeDeclined;

    public bool CanBeFailed
        => Wrapped.CanBeFailed;

    public string Description
        => Wrapped.Description;

    public bool Failed
        => Wrapped.Failed;

    public double FundsAdvance
        => Wrapped.FundsAdvance;

    public double FundsCompletion
        => Wrapped.FundsCompletion;

    public double FundsFailure
        => Wrapped.FundsFailure;

    public IList<string> Keywords
        => Wrapped.Keywords;

    public string Notes
        => Wrapped.Notes;

    public IList<ContractParameter> Parameters
        => Wrapped.Parameters.Select(item => new ContractParameter(item)).ToList();

    public bool Read
        => Wrapped.Read;

    public double ReputationCompletion
        => Wrapped.ReputationCompletion;

    public double ReputationFailure
        => Wrapped.ReputationFailure;

    public double ScienceCompletion
        => Wrapped.ScienceCompletion;

    public bool Seen
        => Wrapped.Seen;

    public ContractState State
        => Wrapped.State;

    public string Synopsis
        => Wrapped.Synopsis;

    public string Title
        => Wrapped.Title;

    public string Type
        => Wrapped.Type;

    public void Accept()
        => Wrapped.Accept();

    public void Cancel()
        => Wrapped.Cancel();

    public void Decline()
        => Wrapped.Decline();
}
