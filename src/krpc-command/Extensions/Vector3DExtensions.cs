using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Extensions;

public static class Vector3DExtensions
{
    public static Tuple<double, double, double> ToTuple(this Vector3D vector)
    {
        return new Tuple<double, double, double>(vector.X, vector.Y, vector.Z);
    }
}