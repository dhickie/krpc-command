using MathNet.Spatial.Euclidean;

namespace kRPC.Client.Boost.Extensions;

public static class QuaternionExtensions
{
    public static Tuple<double, double, double, double> ToTuple(this Quaternion q)
    {
        return new Tuple<double, double, double, double>(q.Real, q.ImagX, q.ImagY, q.ImagZ);
    }
}