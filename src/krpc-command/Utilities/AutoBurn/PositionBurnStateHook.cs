using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Extensions;
using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Utilities.AutoBurn;

/// <summary>
/// Defines a hook to be executed during an autoburn, when the ship's position fulfils the provided condition.
/// Each hook can only execute once.
/// </summary>
/// <param name="condition">The condition function that dictates whether the hook should fire</param>
/// <param name="action">The action to perform on the ship when the hook fires</param>
/// <param name="referenceFrame">The reference frame the position vector should be in</param>
public class PositionBurnStateHook(Func<Vector3D, bool> condition, Action<Vessel> action, ReferenceFrame referenceFrame)
{
    private Stream<Tuple<double, double, double>>? _stream;
    private bool _fired;

    /// <summary>
    /// Set up the telemetry stream needed for the hook.
    /// </summary>
    /// <param name="connection">The kRPC connection</param>
    public void SetupStream(Connection connection)
    {
        var sc = connection.SpaceCenter();
        _stream = connection.AddStream(() => sc.ActiveVessel.Velocity(referenceFrame));
    }

    /// <summary>
    /// Teardown the telemetry stream for the hook.
    /// </summary>
    public void TeardownStream()
    {
        _stream!.Remove();
    }

    /// <summary>
    /// Whether the hook should fire based on the ship's current position.
    /// </summary>
    /// <returns>True if the hook should fire, otherwise false</returns>
    public bool ShouldFire()
    {
        return !_fired && condition(_stream!.Get().ToVector3D());
    }

    /// <summary>
    /// Fire the hook.
    /// </summary>
    /// <param name="ship">The ship to fire the hook for.</param>
    public void Fire(Vessel ship)
    {
        action(ship);
        _fired = true;
    }

    /// <summary>
    /// Validate the telemetry stream needed by the hook.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the steam is invalid</exception>
    public void ValidateStream()
    {
        if (_stream == null)
            throw new InvalidOperationException("Cannot proceed with null telemetry stream");
    }
}