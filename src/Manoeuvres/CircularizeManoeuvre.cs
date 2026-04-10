using KRPC.Client.Services.MechJeb;

namespace KrpcCommand.Manoeuvres;

/// <summary>
/// Circularizes the vessel's orbit at either apoapsis or periapsis using MechJeb's
/// ManeuverPlanner and NodeExecutor.
/// </summary>
public class CircularizeManoeuvre : IManoeuvre
{
    public string Name => "Circularize";
    public string Description => "Circularize orbit at apoapsis or periapsis.";

    private readonly ManoeuvreParameter<bool> _atApoapsis = new("atApoapsis", "At apoapsis? (true/false)", true);

    public IReadOnlyList<ManoeuvreParameterBase> Parameters => [_atApoapsis];

    public async Task ExecuteAsync(ManoeuvreContext context, ManoeuvreLogger logger, CancellationToken cancellationToken)
    {
        var mj = context.MechJeb;

        // Check MechJeb API is ready
        if (!mj.APIReady)
        {
            logger.Log("Waiting for MechJeb API to become ready...");
            while (!mj.APIReady)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(500, cancellationToken);
            }
        }
        logger.Log("MechJeb API is ready.");

        bool atApoapsis = _atApoapsis.Value;
        string location = atApoapsis ? "apoapsis" : "periapsis";
        logger.Log($"Planning circularization at {location}...");

        // Configure the circularization operation
        var planner = mj.ManeuverPlanner;
        var operation = planner.OperationCircularize;
        operation.TimeSelector.TimeReference = atApoapsis
            ? TimeReference.Apoapsis
            : TimeReference.Periapsis;

        // Create the manoeuvre node
        logger.Log("Creating manoeuvre node...");
        try
        {
            operation.MakeNodes();
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
        cancellationToken.ThrowIfCancellationRequested();

        // Execute the node using MechJeb's NodeExecutor
        var executor = mj.NodeExecutor;
        executor.Autowarp = true;
        executor.ExecuteOneNode();
        logger.Log("Node execution started. Waiting for completion...");

        // Poll until execution completes
        while (executor.Enabled)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(1000, cancellationToken);
        }

        logger.Log("Circularization complete.");

        // Report final orbit parameters
        var orbit = context.ActiveVessel.Orbit;
        logger.Log($"Final orbit: {orbit.ApoapsisAltitude / 1000:F1} km x {orbit.PeriapsisAltitude / 1000:F1} km");
    }
}
