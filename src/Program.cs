using KRPC.Client;
using KrpcCommand.Manoeuvres;
using KrpcCommand.UI;

// Register all available manoeuvres
var manoeuvres = new List<IManoeuvre>
{
    new KrpcCommand.Manoeuvres.CircularizeManoeuvre(),
};

Console.WriteLine("krpc-command: Connecting to kRPC server...");

using var connection = new Connection("Mission Control");
Console.WriteLine("Connected to kRPC server.");

using var ui = new UIManager(connection, manoeuvres);
ui.Initialise();
Console.WriteLine("UI initialised. Use the in-game window to select and execute manoeuvres.");
Console.WriteLine("Press Ctrl+C to exit.");

// Main loop - poll for UI interactions
using var cts = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    cts.Cancel();
};

try
{
    while (!cts.Token.IsCancellationRequested)
    {
        ui.Update();
        Thread.Sleep(100); // Poll every 100ms
    }
}
catch (OperationCanceledException)
{
    // Normal shutdown
}

Console.WriteLine("Shutting down...");
