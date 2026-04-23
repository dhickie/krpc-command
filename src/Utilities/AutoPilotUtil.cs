using System.Diagnostics;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Extensions;
using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Utilities;

/// <summary>
/// AutoPilotUtil uses the active vessel's autopilot to perform an automated burn with a variable target until
/// a particular goal is achieved.
/// </summary>
/// <param name="connection">The kRPC connection</param>
public class AutoPilotUtil(Connection connection)
{
    private readonly TimeSpan _controlLoop = TimeSpan.FromMilliseconds(10);
    
    private readonly Vessel _ship = connection.SpaceCenter().ActiveVessel;
    
    private Func<Vector3D, Vector3D>? _target; // Where to point based on current velocity
    private ReferenceFrame? _referenceFrame; // What reference frame the target vector is in
    private Func<Vector3D, double>? _remainingBurn; // How much delta v remains until the burn is done
    private double? _burnStart; // When to start the burn
    
    // Telemetry
    private Stream<double>? _ut;
    private Stream<Tuple<double, double, double>>? _v;
    private Stream<float>? _mass;
    private Stream<float>? _maxThrust;

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
    /// Sets the function the autopilot should use to determine how much deltaV remains on the burn.
    /// </summary>
    /// <param name="remainingBurn">The remaining burn function, which receives the ship's current velocity vector and returns the remaining deltaV in m/s</param>
    public void SetRemainingBurn(Func<Vector3D, double> remainingBurn)
    {
        _remainingBurn = remainingBurn;
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
        ValidateProperties();
        SetupTelemetry();
        ValidateStreams();
        
        var ap = _ship.AutoPilot;
        ap.ReferenceFrame = _referenceFrame;
        ap.TargetDirection = _target!(_v!.Get().ToVector3D()).ToTuple();
        ap.Engage();

        var utPrev = _ut!.Get();
        var sw = new Stopwatch();
        sw.Start();
        try
        {
            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // TODO do a better job of warping to near the burn start if its ages away
                var start = sw.Elapsed;
                var utNew = _ut.Get();
                if (utNew > utPrev)
                {
                    // Only take action if we're in a different physics tick from the previous iteration
                    // Decide whether the burn is finished
                    var remainingBurn = _remainingBurn!(_v.Get().ToVector3D());
                    if (remainingBurn < 0.1)
                    {
                        break;
                    }

                    // Set course and throttle
                    ap.TargetDirection = _target(_v.Get().ToVector3D()).ToTuple();
                    _ship.Control.Throttle = CalculateThrottle(remainingBurn);
                }

                utPrev = utNew;
                var waitTime = _controlLoop - (sw.Elapsed - start);
                await Task.Delay(waitTime, cancellationToken);
            }
        }
        finally
        {
            ap.Disengage();
            TearDownTelemetry();
        }
    }

    private float CalculateThrottle(double remainingBurn)
    {
        // If we haven't hit burn start yet, then don't burn
        if (_ut!.Get() < _burnStart)
        {
            return 0;
        }
        
        // Work out how long it would take to hit 0 on the remaining burn given the ship's current thrust and mass
        var maxAccel = _maxThrust!.Get() / _mass!.Get();;
        var timeToZero = remainingBurn / maxAccel;
        
        // It would take one tick to receive the next update, another to send the command to adjust the throttle,
        // and potentially a third before the command is actioned. We also need to accomodate any spikes in latency
        // between the client and the server. To try and account for all of this, aim to hit 0 velocity 10 ticks into
        // the future, capped at some minimum thrust.
        var tickHz = 60;
        var tickTimeMs = TimeSpan.FromSeconds(1) / tickHz;
        var frameBuffer = 10;
        var bufferTime = tickTimeMs * frameBuffer;
        var minThrottle = 0.02;

        if (bufferTime.TotalSeconds < timeToZero)
        {
            return 1;
        }
        
        // Aim to hit zero bufferTime into the future
        var targetAccel = remainingBurn / bufferTime.TotalSeconds;
        var targetThrust = targetAccel * _mass.Get();
        var targetThrottle = targetThrust / _maxThrust.Get();
        
        return (float)Math.Max(targetThrottle, minThrottle);
    }
    
    private void SetupTelemetry()
    {
        var spaceCentre = connection.SpaceCenter();
        _ut = connection.AddStream(() => spaceCentre.UT);
        _v = connection.AddStream(() => _ship.Velocity(_referenceFrame));
        _mass = connection.AddStream(() => _ship.Mass);
        _maxThrust = connection.AddStream(() => _ship.MaxThrust);
    }

    private void TearDownTelemetry()
    {
        _ut!.Remove();
        _v!.Remove();
        _mass!.Remove();
        _maxThrust!.Remove();
    }
    
    private void ValidateProperties()
    {
        // Constructor properties
        if (_target == null)
            Throw("Target function");
        if (_remainingBurn == null)
            Throw("Remaining burn function");
        if (_referenceFrame == null)
            Throw("Reference frame");
        if (_burnStart == null)
            Throw("Burn start time");
    }

    private void ValidateStreams()
    {
        if (_ut == null)
            Throw("UT stream");
        if (_v == null)
            Throw("Ship velocity stream");
        if (_mass == null)
            Throw("Ship mass stream");
        if (_maxThrust == null)
            Throw("Max thrust stream");
    }

    private void Throw(string propertyName)
    {
        throw new InvalidOperationException($"{propertyName} cannot be null");
    }
}