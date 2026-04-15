using KRPC.Client.Services.SpaceCenter;

namespace KrpcCommand.Extensions;

public static class OrbitExtensions
{
    /// <summary>
    /// Returns the time in seconds until the orbit reaches the given mean anomaly (radians).
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
}