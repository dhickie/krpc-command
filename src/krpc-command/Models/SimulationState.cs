using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Models;

public class SimulationState(double ut, Vector3D shipPosition, Vector3D shipVelocity)
{
    // ReSharper disable once InconsistentNaming
    public double UT { get; set; } = ut;
    public Vector3D ShipPosition { get; set; } = shipPosition; // Meters
    public Vector3D ShipVelocity { get; set; } = shipVelocity;  // Meters per second
}