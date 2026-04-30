using KrpcCommand.Models;
using KrpcCommand.Utilities.AutoBurn;
using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Utilities;

/// <summary>
/// Creates a simulator for simulating a burn based on a set of provided parameters.
/// </summary>
/// <param name="dt">The time step to use for the simulation. Smaller means more accuracy but longer computation time</param>
/// <param name="initialState">The initial state vectors of the ship's orbit and starting timestamp</param>
/// <param name="simulationParameters">The parameters governing the simulation</param>
/// <param name="remainingBurnCalculator">Function that is called to calculate how much burn remains</param>
public class BurnSimulator(
    TimeSpan dt,
    SimulationState initialState,
    SimulationParameters simulationParameters,
    Func<SimulationState, Vector3D> remainingBurnCalculator)
{
    private readonly double _dt = dt.TotalSeconds; // How much we step forward in time per iteration
    private readonly SimulationState _initialState = initialState; // The current state of the sim
    private readonly SimulationParameters _simulationParameters = simulationParameters;
    private readonly Func<SimulationState, Vector3D> _remainingBurnCalculator = remainingBurnCalculator;

    /// <summary>
    /// Runs the simulation until the provided completion function returns true.
    /// </summary>
    /// <returns>The state of the simulation at the point it completed</returns>
    public SimulationState Run(CancellationToken cancellationToken)
    {
        // Previous state variables
        var mPrev = _simulationParameters.InitialMass;
        var xPrev = _initialState.ShipPosition;
        var vPrev = _initialState.ShipVelocity;
        var tPrev = _initialState.UT;
        var aGravPrev = CalculateGravityAcceleration(xPrev);
        
        // Simulate changes in velocity using Velocity Verlet integration for better accuracy
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            // Calculate what thrust acceleration is going to be applied during this tick
            var (aThrustStart, throttle) = 
                CalculateThrustAcceleration(mPrev, tPrev, xPrev, vPrev);
            var aStart = aThrustStart + aGravPrev;
            
            var tNext = tPrev + _dt;
            var xNext = xPrev + _dt * xPrev + 0.5 * Math.Pow(_dt, 2) * aStart;
            var mNext = CalculateNewMass(mPrev, throttle);
            
            // It's ok to calculate the thrust acceleration at the end of the step using the previous velocity etc.
            // because autopilot won't adjust the throttle or steering in the middle of a physics tick.
            // We just want to know how the reduction in mass will affect acceleration
            var (aThrustEnd, _) = CalculateThrustAcceleration(mNext, tPrev, xPrev, vPrev);
            var aGravNext = CalculateGravityAcceleration(xNext);
            var aEnd = aThrustEnd + aGravNext;
            var vNext = vPrev + (_dt * ((aStart + aEnd) / 2));

            mPrev = mNext;
            xPrev = xNext;
            vPrev = vNext;
            tPrev = tNext;
            aGravPrev = aGravNext;
            
            // Check whether we're done
            var state = new SimulationState(tNext, xNext, vNext);
            var remainingBurn = _remainingBurnCalculator(state);
            if (remainingBurn.Length < AutoBurnUtil.CompletionTolerance)
            {
                break;
            }
        }

        return new SimulationState(tPrev, xPrev, vPrev);
    }
    
    private Vector3D CalculateGravityAcceleration(Vector3D pos)
    {
        var mu = _simulationParameters.BodyGravitationalParameter;
        var aGrav = (mu / Math.Pow(pos.Length, 2)) * (-pos).Normalize();
        
        return aGrav;
    }

    private (Vector3D a, float throttle) CalculateThrustAcceleration(double mass, double ut, Vector3D pos, Vector3D vel)
    {
        var maxThrust = _simulationParameters.Thrust;
        var state = new SimulationState(ut, pos, vel);
        var remainingBurn = _remainingBurnCalculator(state);
        var throttle = 
            AutoBurnUtil.CalculateVelocityBurnThrottle(remainingBurn.Length, maxThrust, mass);
        var aThrust = ((throttle * maxThrust) / mass) * remainingBurn.Normalize();
        return (aThrust, throttle);
    }

    private double CalculateNewMass(double initialMass, float throttle)
    {
        return initialMass - (throttle * _simulationParameters.FuelBurnRate * _dt);
    }
}