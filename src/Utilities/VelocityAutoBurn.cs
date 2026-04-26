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
public class VelocityAutoBurn(Connection connection) : AutoBurn(connection)
{
    private Func<Vector3D, double>? _remainingBurn; // How much delta v remains until the burn is done

    /// <summary>
    /// Sets the function the autopilot should use to determine how much deltaV remains on the burn.
    /// </summary>
    /// <param name="remainingBurn">The remaining burn function, which receives the ship's current velocity vector and returns the remaining deltaV in m/s</param>
    public void SetRemainingBurn(Func<Vector3D, double> remainingBurn)
    {
        _remainingBurn = remainingBurn;
    }

    /// <inheritdoc/>
    protected override bool IsBurnComplete()
    {
        var remainingBurn = _remainingBurn!(V!.Get().ToVector3D());
        return remainingBurn < AutoBurnUtil.CompletionTolerance;
    }

    /// <inheritdoc/>
    protected override float CalculateThrottle()
    {
        var maxT = MaxThrust!.Get();
        var m = Mass!.Get();
        var remainingBurn = _remainingBurn!(V!.Get().ToVector3D());
        
        return AutoBurnUtil.CalculateVelocityBurnThrottle(maxT, m, remainingBurn);
    }
    
    /// <inheritdoc/>
    protected override void SetupTelemetry()
    {
    }

    /// <inheritdoc/>
    protected override void TearDownTelemetry()
    {
    }
    
    /// <inheritdoc/>
    protected override void ValidateProperties()
    {
        // Constructor properties
        if (_remainingBurn == null)
            Throw("Remaining burn function");
    }

    /// <inheritdoc/>
    protected override void ValidateStreams()
    {
    }
}