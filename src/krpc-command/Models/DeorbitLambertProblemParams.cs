using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Models;

public class DeorbitLambertProblemParams(
    double burnUt,
    double timeOfFlight,
    double flyoverAltitude,
    Vector3D deorbitBurnPosition)
{
    public double BurnUt { get; set; } = burnUt;
    public double TimeOfFlight { get; set; } = timeOfFlight;
    public double FlyoverAltitude { get; set; } = flyoverAltitude;
    public Vector3D DeorbitBurnPosition { get; set; } = deorbitBurnPosition;
}