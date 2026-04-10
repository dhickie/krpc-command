namespace KrpcCommand.Manoeuvres;

/// <summary>
/// Base interface for all manoeuvres that can be executed by the application.
/// Each manoeuvre provides a name, configurable parameters, and an async execution method.
/// </summary>
public interface IManoeuvre
{
    /// <summary>
    /// Display name shown in the manoeuvre selection list.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Description of what this manoeuvre does.
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Configuration parameters that the user can set before execution.
    /// These are rendered as input fields in the UI.
    /// </summary>
    IReadOnlyList<ManoeuvreParameterBase> Parameters { get; }

    /// <summary>
    /// Execute the manoeuvre. This method should periodically check the cancellation token
    /// and log progress via the logger.
    /// </summary>
    /// <param name="context">Access to kRPC services.</param>
    /// <param name="logger">Logger for reporting progress to the UI.</param>
    /// <param name="cancellationToken">Token to support cancellation.</param>
    Task ExecuteAsync(ManoeuvreContext context, ManoeuvreLogger logger, CancellationToken cancellationToken);
}
