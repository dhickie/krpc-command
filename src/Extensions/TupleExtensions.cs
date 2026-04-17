using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Extensions;

public static class TupleExtensions
{
    public static Vector3D ToVector3D(this Tuple<double, double, double> tuple)
    {
        return new Vector3D(tuple.Item1, tuple.Item2, tuple.Item3);
    }

    public static UnitVector3D ToUnitVector3D(this Tuple<double, double, double> tuple)
    {
        return tuple.ToVector3D().Normalize();
    }
}