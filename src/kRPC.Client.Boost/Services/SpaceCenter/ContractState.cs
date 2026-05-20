namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// The state of a contract. See <see cref="M:SpaceCenter.Contract.State" />.
/// </summary>
[Serializable]
public enum ContractState
{
    /// <summary>
    /// The contract is active.
    /// </summary>
    Active = 0,
    /// <summary>
    /// The contract has been canceled.
    /// </summary>
    Canceled = 1,
    /// <summary>
    /// The contract has been completed.
    /// </summary>
    Completed = 2,
    /// <summary>
    /// The deadline for the contract has expired.
    /// </summary>
    DeadlineExpired = 3,
    /// <summary>
    /// The contract has been declined.
    /// </summary>
    Declined = 4,
    /// <summary>
    /// The contract has been failed.
    /// </summary>
    Failed = 5,
    /// <summary>
    /// The contract has been generated.
    /// </summary>
    Generated = 6,
    /// <summary>
    /// The contract has been offered to the player.
    /// </summary>
    Offered = 7,
    /// <summary>
    /// The contract was offered to the player, but the offer expired.
    /// </summary>
    OfferExpired = 8,
    /// <summary>
    /// The contract has been withdrawn.
    /// </summary>
    Withdrawn = 9
}