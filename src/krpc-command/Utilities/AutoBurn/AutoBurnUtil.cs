namespace KrpcCommand.Utilities.AutoBurn;

public static class AutoBurnUtil
{
    public static readonly double CompletionTolerance = 0.01;
    
    /// <summary>
    /// Calculates the throttle that should be applied for a ship executing a burn that aims to achieve a particular
    /// velocity. Assumes that the ship is pointing in exactly the right direction for the burn.
    /// </summary>
    /// <param name="maxThrust">The maximum thrust of the ship executing the burn in Newtons</param>
    /// <param name="mass">The mass of the ship executing the burn in kg</param>
    /// <param name="remainingBurn">The amount of burn remaining in m/s</param>
    /// <returns>The throttle that should be applied, as a value between 0 and 1</returns>
    public static float CalculateVelocityBurnThrottle(double maxThrust, 
        double mass,
        double remainingBurn)
    {
        // Work out how long it would take to hit 0 on the remaining burn given the ship's current thrust and mass
        var maxAccel = maxThrust / mass;
        var timeToZero = remainingBurn / maxAccel;
        
        // It would take one tick to receive the next update, another to send the command to adjust the throttle,
        // and potentially a third before the command is actioned. We also need to accomodate any spikes in latency
        // between the client and the server. To try and account for all of this, aim to hit 0 velocity 10 ticks into
        // the future, capped at some minimum thrust.
        var tickHz = 60;
        var tickTimeMs = TimeSpan.FromSeconds(1) / tickHz;
        var frameBuffer = 10;
        var bufferTime = tickTimeMs * frameBuffer;
        var minThrottle = 0.01;

        if (bufferTime.TotalSeconds < timeToZero)
        {
            return 1;
        }
        
        // Aim to hit zero bufferTime into the future
        var targetAccel = remainingBurn / bufferTime.TotalSeconds;
        var targetThrust = targetAccel * mass;
        var targetThrottle = targetThrust / maxThrust;
        
        return (float)Math.Max(targetThrottle, minThrottle);
    }

    public static float CalculatePositionBurnThrottle(double maxThrust, 
        double mass, 
        double remainingDistance,
        double relativeVelocity,
        double bodyMu)
    {
        // We use basic constant acceleration to calculate the required throttle.
        // This is less accurate the larger the remaining distance. We could use the Tsiolkovsky rocket equation
        // to be more accurate, but while it account mass loss from fuel, it doesn't account for gravity increasing
        // as we approach gravitational bodies so would overshoot if pre-calculating the burn start.
        // For super accurate suicide burns, users of this will need to run numerical integration to work out when to
        // start the burn, in which case this will still work. If they don't do numerical integration, then this
        // also works, but it's just less efficient.
        var thrustAccel = maxThrust / mass;
        var gravAccel = bodyMu / Math.Pow(remainingDistance, 2);
        var netAccel = thrustAccel - gravAccel;

        var requiredAccel = Math.Pow(relativeVelocity, 2) / (2 * remainingDistance);
        return (float)Math.Min(requiredAccel / netAccel, 1);
    }
}