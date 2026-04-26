using System.Diagnostics;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Extensions;
using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Utilities;

/// <summary>
/// AutoBurn is a base class for types of automated burn that use the active vessel's autopilot to achieve a particular
/// goal.
/// </summary>
/// <param name="connection">The kRPC connection</param>
public abstract class AutoBurn(Connection connection)
{
    private readonly TimeSpan _controlLoop = TimeSpan.FromMilliseconds(10);
    
    private readonly Vessel _ship = connection.SpaceCenter().ActiveVessel;
    
    private Func<Vector3D, Vector3D>? _target; // Where to point based on current velocity
    private ReferenceFrame? _referenceFrame; // What reference frame the target vector is in
    private double _burnStart; // When to start the burn
    
    // Telemetry
    protected Stream<double>? UT;
    protected Stream<Tuple<double, double, double>>? V;
    protected Stream<float>? Mass;
    protected Stream<float>? MaxThrust;

    /// <summary>
    /// Sets the function the autopilot should use to determine the current target direction.
    /// </summary>
    /// <param name="target">The target direction function, which receives the ship's current velocity vector and returns a direction vector</param>
    /// <param name="referenceFrame">The reference frame that all direction and velocity vectors should use</param>
    public void LockTarget(Func<Vector3D, Vector3D> target, ReferenceFrame referenceFrame)
    {
        _target = target;
        _referenceFrame = referenceFrame;
    }

    /// <summary>
    /// Tells the autopilot when to perform the burn.
    /// </summary>
    /// <param name="ut">The universal timestamp at which to perform the burn</param>
    public void BurnAt(double ut)
    {
        _burnStart = ut;
    }

    /// <summary>
    /// Engages the autopilot until the burn is complete.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the burn early</param>
    /// <returns>A task that can be awaited to wait until the burn is complete</returns>
    public async Task Engage(CancellationToken cancellationToken)
    {
        ValidateBaseProperties();
        ValidateProperties();
        SetupBaseTelemetry();
        SetupTelemetry();
        ValidateBaseStreams();
        ValidateStreams();
        
        var ap = _ship.AutoPilot;
        ap.ReferenceFrame = _referenceFrame;
        ap.TargetDirection = _target!(V!.Get().ToVector3D()).ToTuple();
        ap.Engage();

        var utPrev = UT!.Get();
        var sw = new Stopwatch();
        sw.Start();
        try
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // TODO do a better job of warping to near the burn start if its ages away
                var start = sw.Elapsed;
                var utNew = UT.Get();
                if (utNew > utPrev && utNew > _burnStart)
                {
                    // Only take action if we're in a different physics tick from the previous iteration
                    // Decide whether the burn is finished
                    if (IsBurnComplete())
                    {
                        break;
                    }

                    // Set course and throttle
                    ap.TargetDirection = _target(V.Get().ToVector3D()).ToTuple();
                    _ship.Control.Throttle = CalculateThrottle();
                }

                utPrev = utNew;
                var waitTime = _controlLoop - (sw.Elapsed - start);
                await Task.Delay(waitTime, cancellationToken);
            }
        }
        finally
        {
            ap.Disengage();
            TearDownBaseTelemetry();
            TearDownTelemetry();
        }
    }

    /// <summary>
    /// Decides whether the current burn is complete.
    /// </summary>
    /// <returns>True if the burn is complete, otherwise false</returns>
    protected abstract bool IsBurnComplete();

    /// <summary>
    /// Calculates the throttle that should be applied during a burn, so that it doesn't overshoot between physics ticks
    /// </summary>
    /// <returns>The throttle that should be used, as a value between 0 and 1</returns>
    protected abstract float CalculateThrottle();
    
    /// <summary>
    /// Sets up any telemetry required by the burn.
    /// </summary>
    protected abstract void SetupTelemetry();
    
    /// <summary>
    /// Tears down the burn's telemetry streams once it's complete.
    /// </summary>
    protected abstract void TearDownTelemetry();
    
    /// <summary>
    /// Validates that the provided properties for the burn are valid.
    /// </summary>
    protected abstract void ValidateProperties();

    /// <summary>
    /// Validates that the telemetry streams for the burn are valid.
    /// </summary>
    protected abstract void ValidateStreams();
    
    private void SetupBaseTelemetry()
    {
        var spaceCentre = connection.SpaceCenter();
        UT = connection.AddStream(() => spaceCentre.UT);
        V = connection.AddStream(() => _ship.Velocity(_referenceFrame));
        Mass = connection.AddStream(() => _ship.Mass);
        MaxThrust = connection.AddStream(() => _ship.MaxThrust);
    }

    private void TearDownBaseTelemetry()
    {
        UT!.Remove();
        V!.Remove();
        Mass!.Remove();
        MaxThrust!.Remove();
    }
    
    private void ValidateBaseProperties()
    {
        // Constructor properties
        if (_target == null)
            Throw("Target function");
        if (_referenceFrame == null)
            Throw("Reference frame");
    }

    private void ValidateBaseStreams()
    {
        if (UT == null)
            Throw("UT stream");
        if (V == null)
            Throw("Ship velocity stream");
        if (Mass == null)
            Throw("Ship mass stream");
        if (MaxThrust == null)
            Throw("Max thrust stream");
    }

    protected static void Throw(string propertyName)
    {
        throw new InvalidOperationException($"{propertyName} cannot be null");
    }
}