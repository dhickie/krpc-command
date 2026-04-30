using MathNet.Spatial.Euclidean;

namespace kRPC.Client.Boost.Extensions;

public static class TupleExtensions
{
    public static Vector3D ToVector3D(this Tuple<double, double, double> tuple)
    {
        return new Vector3D(tuple.Item1, tuple.Item2, tuple.Item3);
    }

    public static Tuple<Vector3D, Vector3D> ToTupleVector3D(
        this Tuple<Tuple<double, double, double>, Tuple<double, double, double>> tuple)
    {
        return new Tuple<Vector3D, Vector3D>(tuple.Item1.ToVector3D(), tuple.Item2.ToVector3D());
    }

    public static UnitVector3D ToUnitVector3D(this Tuple<double, double, double> tuple)
    {
        return tuple.ToVector3D().Normalize();
    }

    public static Quaternion ToQuaternion(this Tuple<double, double, double, double> tuple)
    {
        return new Quaternion(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
    }
}