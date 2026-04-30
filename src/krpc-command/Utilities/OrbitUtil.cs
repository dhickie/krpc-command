using KRPC.Client.Services.SpaceCenter;

namespace KrpcCommand.Utilities;

public static class OrbitUtil
{
    /// <summary>
    /// Calculates the mean anomaly that corresponds to the provided true anomaly for the provided orbit
    /// </summary>
    /// <param name="orbit">The orbit to calculate the mean anomaly for</param>
    /// <param name="trueAnomaly">The true anomaly to calculate the mean anomaly of in radians</param>
    /// <returns>The mean anomaly in radians</returns>
    public static double MeanAnomalyFromTrueAnomaly(Orbit orbit, double trueAnomaly)
    {
        var e = orbit.Eccentricity;
        var ta = trueAnomaly;

        var ea = EccentricAnomalyFromTrueAnomaly(orbit, trueAnomaly);
        var ma = ea - e * Math.Sin(ea);

        return ma;
    }

    /// <summary>
    /// Calculate the eccentric anomaly that corresponds to the provided true anomaly for the provided orbit
    /// </summary>
    /// <param name="orbit">The orbit to calculate the eccentric anomaly for</param>
    /// <param name="trueAnomaly">The true anomaly to calculate the mean anomaly of in radians</param>
    /// <returns>The eccentric anomaly in radians</returns>
    public static double EccentricAnomalyFromTrueAnomaly(Orbit orbit, double trueAnomaly)
    {
        var e = orbit.Eccentricity;
        // ReSharper disable once InlineTemporaryVariable
        var ta = trueAnomaly;

        var radians = Math.Atan(Math.Sqrt((1 - e) / (1 + e)) * Math.Tan(ta / 2)) * 2;
        return radians;
    }
}