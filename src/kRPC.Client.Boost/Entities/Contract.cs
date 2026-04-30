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
    internal BaseContract Internal { get; }

    internal Contract(BaseContract contract)
    {
        Internal = contract;
    }
    public bool Active
        => Internal.Active;
    public bool CanBeCanceled
        => Internal.CanBeCanceled;
    public bool CanBeDeclined
        => Internal.CanBeDeclined;
    public bool CanBeFailed
        => Internal.CanBeFailed;
    public string Description
        => Internal.Description;
    public bool Failed
        => Internal.Failed;
    public double FundsAdvance
        => Internal.FundsAdvance;
    public double FundsCompletion
        => Internal.FundsCompletion;
    public double FundsFailure
        => Internal.FundsFailure;
    public IList<string> Keywords
        => Internal.Keywords;
    public string Notes
        => Internal.Notes;
    public IList<ContractParameter> Parameters
        => Internal.Parameters.Select(item => new ContractParameter(item)).ToList();
    public bool Read
        => Internal.Read;
    public double ReputationCompletion
        => Internal.ReputationCompletion;
    public double ReputationFailure
        => Internal.ReputationFailure;
    public double ScienceCompletion
        => Internal.ScienceCompletion;
    public bool Seen
        => Internal.Seen;
    public ContractState State
        => Internal.State;
    public string Synopsis
        => Internal.Synopsis;
    public string Title
        => Internal.Title;
    public string Type
        => Internal.Type;
    public void Accept()
        => Internal.Accept();
    public void Cancel()
        => Internal.Cancel();
    public void Decline()
        => Internal.Decline();
}
