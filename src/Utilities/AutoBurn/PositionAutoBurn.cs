using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Extensions;
using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Utilities.AutoBurn;

/// <summary>
/// PositionAutoBurn is an AutoBurn implementation that burns to hit zero velocity relative to another vessel or body
/// at a particular distance from that vessel or body.
/// </summary>
/// <param name="connection">The kRPC connection</param>
public class PositionAutoBurn(Connection connection) : AutoBurn(connection)
{
    private Stream<Tuple<double, double, double>>? _position;
    private Stream<Tuple<double, double, double>>? _velocity;
    private Func<Vector3D, double>? _remainingDistance; // How much distance remains until the burn is done
    private ReferenceFrame? _positionReferenceFrame; // What reference frame the position vector passed to the remaining distance function should be in
    private Func<Vector3D, double>? _remainingVelocity; // How much velocity remains relative to the target?
    private ReferenceFrame? _velocityReferenceFrame; // What reference frame the velocity vector passed to the remaining velocity function should be in
    private double _bodyGravitationalParameter;

    /// <summary>
    /// Sets the function used to calculate how much distance remains in the burn.
    /// </summary>
    /// <param name="remainingDistance">The function to use to calculate remaining distance</param>
    /// <param name="referenceFrame">The reference frame the position vector provided to the function is in</param>
    public void SetRemainingDistance(Func<Vector3D, double> remainingDistance, ReferenceFrame referenceFrame)
    {
        _remainingDistance = remainingDistance;
        _positionReferenceFrame = referenceFrame;
    }

    /// <summary>
    /// Sets the function used to calculate how much velocity remains until hitting zero.
    /// </summary>
    /// <param name="remainingVelocity">The function used to calculate the remaining velocity</param>
    /// <param name="referenceFrame">The reference frame the velocity vector provided to the function is in</param>
    public void SetRemainingVelocity(Func<Vector3D, double> remainingVelocity, ReferenceFrame referenceFrame)
    {
        _remainingVelocity = remainingVelocity;
        _velocityReferenceFrame = referenceFrame;
    }

    /// <summary>
    /// Sets the target body for the burn. Only call if the target _is_ a body and not a vessel etc.
    /// </summary>
    /// <param name="body">The body to target.</param>
    public void SetTargetBody(CelestialBody body)
    {
        _bodyGravitationalParameter = body.GravitationalParameter;
    }
    
    /// <inheritdoc/>
    protected override bool IsBurnComplete()
    {
        // We decide "completeness" based on the position - we assume the ship isn't carrying too much velocity
        // for the burn to be possible
        var x = _remainingDistance!(_position!.Get().ToVector3D());
        return x < AutoBurnUtil.CompletionTolerance;
    }

    /// <inheritdoc/>
    protected override float CalculateThrottle()
    {
        var th = MaxThrust!.Get();
        var m = Mass!.Get();
        var r = _remainingDistance!(_position!.Get().ToVector3D());
        var v = _remainingVelocity!(_velocity!.Get().ToVector3D());
        var mu = _bodyGravitationalParameter;

        return AutoBurnUtil.CalculatePositionBurnThrottle(th, m, r, v, mu);
    }

    /// <inheritdoc/>
    protected override void SetupTelemetry()
    {
        var ship = connection.SpaceCenter().ActiveVessel;
        _position = connection.AddStream(() => ship.Position(_positionReferenceFrame));
        _velocity = connection.AddStream(() => ship.Velocity(_velocityReferenceFrame));
    }

    /// <inheritdoc/>
    protected override void TearDownTelemetry()
    {
        _position!.Remove();
        _velocity!.Remove();
    }

    /// <inheritdoc/>
    protected override void ValidateProperties()
    {
        if (_remainingDistance == null)
            Throw("Remaining distance function");
        if (_positionReferenceFrame == null)
            Throw("Position reference frame");
        if (_remainingVelocity == null)
            Throw("Remaining velocity function");
        if (_velocityReferenceFrame == null)
            Throw("Velocity reference frame");
    }

    /// <inheritdoc/>
    protected override void ValidateStreams()
    {
        if (_position == null)
            Throw("Position stream");
        if (_velocity == null)
            Throw("Velocity stream");
    }
}