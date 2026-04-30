using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Extensions;
using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Utilities.AutoBurn;

/// <summary>
/// VelocityAutoBurn is an AutoBurn implementation that burns until a particular velocity is reached.
/// </summary>
/// <param name="connection">The kRPC connection</param>
public class VelocityAutoBurn(Connection connection) : AutoBurn(connection)
{
    private Func<Vector3D, double>? _remainingBurn; // How much delta v remains until the burn is done
    private ReferenceFrame? _referenceFrame;
    
    private Stream<Tuple<double, double, double>>? _v;

    /// <summary>
    /// Sets the function the autopilot should use to determine how much deltaV remains on the burn.
    /// </summary>
    /// <param name="remainingBurn">The remaining burn function, which receives the ship's current velocity vector and returns the remaining deltaV in m/s</param>
    /// <param name="referenceFrame">The reference frame that the velocity vector provided to the remaining burn function should be in</param>
    public void SetRemainingBurn(Func<Vector3D, double> remainingBurn, ReferenceFrame referenceFrame)
    {
        _remainingBurn = remainingBurn;
        _referenceFrame = referenceFrame;
    }

    /// <inheritdoc/>
    protected override bool IsBurnComplete()
    {
        var remainingBurn = _remainingBurn!(_v!.Get().ToVector3D());
        return remainingBurn < AutoBurnUtil.CompletionTolerance;
    }

    /// <inheritdoc/>
    protected override float CalculateThrottle()
    {
        var maxT = MaxThrust!.Get();
        var m = Mass!.Get();
        var remainingBurn = _remainingBurn!(_v!.Get().ToVector3D());
        
        return AutoBurnUtil.CalculateVelocityBurnThrottle(maxT, m, remainingBurn);
    }
    
    /// <inheritdoc/>
    protected override void SetupTelemetry()
    {
        var ship = connection.SpaceCenter().ActiveVessel;
        _v = connection.AddStream(() => ship.Velocity(_referenceFrame));
    }

    /// <inheritdoc/>
    protected override void TearDownTelemetry()
    {
        _v!.Remove();
    }
    
    /// <inheritdoc/>
    protected override void ValidateProperties()
    {
        // Constructor properties
        if (_remainingBurn == null)
            Throw("Remaining burn function");
        if (_referenceFrame == null)
            Throw("Remaining burn reference frame");
    }

    /// <inheritdoc/>
    protected override void ValidateStreams()
    {
        if (_v == null)
            Throw("Velocity stream");
    }
}