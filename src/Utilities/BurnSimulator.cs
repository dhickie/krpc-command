using KrpcCommand.Models;
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
    private TimeSpan _dt = dt; // How much we step forward in time per iteration
    private SimulationState _simulationState = initialState; // The current state of the sim
    private SimulationParameters _simulationParameters = simulationParameters;
    private Func<SimulationState, Vector3D> _remainingBurnCalculator = remainingBurnCalculator;

    /// <summary>
    /// Runs the simulation until the provided completion function returns true.
    /// </summary>
    /// <returns>The state of the simulation at the point it completed</returns>
    /// <exception cref="NotImplementedException"></exception>
    public SimulationState Run()
    {
        throw new NotImplementedException();
    }
}