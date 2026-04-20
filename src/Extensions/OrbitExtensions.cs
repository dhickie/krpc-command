using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Utilities;

namespace KrpcCommand.Extensions;

public static class OrbitExtensions
{
    /// <summary>
    /// Calculates the time in seconds until the orbit reaches the given mean anomaly (radians).
    /// The result is always non-negative — if the anomaly is behind the current position
    /// the returned time spans the remainder of the current orbit plus the lead-in.
    /// </summary>
    /// <param name="orbit">The orbit for which to calculate the time</param>
    /// <param name="meanAnomaly">The mean anomaly to determine the ETA of, in radians</param>
    /// <returns>The time until the orbit reaches the target mean anomaly, in seconds</returns>
    public static double TimeToMeanAnomaly(this Orbit orbit, double meanAnomaly)
    {
        // How much mean anomaly must elapse to reach the target?
        var delta = meanAnomaly - orbit.MeanAnomaly;

        delta %= 2 * Math.PI; // Defensive code - cope with values larger than 2 PI
        
        // Normalise to [0, 2π] so we always look forward in time
        if (delta < 0)
            delta += 2 * Math.PI;

        // Mean anomaly advances uniformly at 2π per orbital period
        return delta / (2 * Math.PI) * orbit.Period;
    }

    /// <summary>
    /// Calculates the time in seconds until the orbit reaches the given true anomaly (radians).
    /// The result is always non-negative — if the anomaly is behind the current position
    /// the returned time spans the remainder of the current orbit plus the lead-in.
    /// </summary>
    /// <param name="orbit">The orbit for which to calculate the time</param>
    /// <param name="trueAnomaly">The true anomaly to determine the ETA of, in radians</param>
    /// <returns>The time until the orbit reaches the target true anomaly, in seconds</returns>
    public static double TimeToTrueAnomaly(this Orbit orbit, double trueAnomaly)
    {
        var ma = OrbitUtil.MeanAnomalyFromTrueAnomaly(orbit, trueAnomaly);
        return orbit.TimeToMeanAnomaly(ma);
    }

    /// <summary>
    /// Returns the eccentricity vector of the orbit, given the orbital state vectors at a consistent point in time.
    /// Assumes that all vectors, both arguments and return value, are in the non-rotating reference frame of the
    /// orbit's body.
    /// https://en.wikipedia.org/wiki/Eccentricity_vector
    /// </summary>
    /// <param name="orbit">The orbit to get the eccentricity vector of</param>
    /// <param name="position">The position of the orbiting object at a point in time</param>
    /// <param name="velocity">The velocity of the orbiting object at a point in time</param>
    /// <returns>The eccentricity vector, in the orbit's body's non-rotating reference frame</returns>
    public static Tuple<double, double, double> EccentricityVector(this Orbit orbit,
        Tuple<double, double, double> position,
        Tuple<double, double, double> velocity)
    {
        var r = position.ToVector3D();
        var rMag = r.Length;
        var v = velocity.ToVector3D();
        var vMag = v.Length;
        var mu = orbit.Body.GravitationalParameter;

        var e = ((Math.Pow(vMag, 2) / mu) - (1 / rMag)) * r;
        e -= (r.DotProduct(v) / mu) * v;

        return e.ToTuple();
    }
}