using KRPC.Client.Services.MechJeb;
using KrpcCommand.Extensions;
using KrpcCommand.Manoeuvres.Parameters;

namespace KrpcCommand.Manoeuvres;

/// <summary>
/// Circularizes the vessel's orbit at either apoapsis or periapsis using MechJeb's
/// ManeuverPlanner and NodeExecutor.
/// </summary>
public class CircularizeManoeuvre(ManoeuvreLogger logger, ManoeuvreContext context) : IManoeuvre
{
    public string Name => "Circularize";
    public string Description => "Circularize orbit at apoapsis or periapsis.";

    private readonly BoolManoeuvreParameter _atApoapsis = new("atApoapsis", "At apoapsis? (true/false)", true);

    public IReadOnlyList<ManoeuvreParameter> Parameters => [_atApoapsis];

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var mj = context.MechJeb;

        // Check MechJeb API is ready
        logger.Log("Ensuring MechJeb API is ready.");
        await mj.EnsureApiReadyAsync(cancellationToken);

        CreateManoeuvreNode();
        cancellationToken.ThrowIfCancellationRequested();

        // Execute the node using MechJeb's NodeExecutor
        logger.Log("Starting node execution. Waiting for completion...");
        var executor = mj.NodeExecutor;
        await executor.ExecuteNodeAsync(cancellationToken);

        logger.Log("Circularization complete.");

        // Report final orbit parameters
        var orbit = context.ActiveVessel.Orbit;
        logger.Log($"Final orbit: {orbit.ApoapsisAltitude / 1000:F1} km x {orbit.PeriapsisAltitude / 1000:F1} km");
    }

    private void CreateManoeuvreNode()
    {
        bool atApoapsis = _atApoapsis.Value;
        string location = atApoapsis ? "apoapsis" : "periapsis";
        logger.Log($"Planning circularization at {location}...");

        // Configure the circularization operation
        var planner = context.MechJeb.ManeuverPlanner;
        var operation = planner.OperationCircularize;
        operation.TimeSelector.TimeReference = atApoapsis
            ? TimeReference.Apoapsis
            : TimeReference.Periapsis;

        // Create the manoeuvre node
        logger.Log("Creating manoeuvre node...");
        try
        {
            operation.MakeNode();
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to create node: {ex.Message}");
            var errorMsg = operation.ErrorMessage;
            if (!string.IsNullOrEmpty(errorMsg))
                logger.Log($"MechJeb error: {errorMsg}");
            return;
        }

        logger.Log("Manoeuvre node created.");
    }
}
