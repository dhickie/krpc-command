using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Extensions;
using KrpcCommand.Manoeuvres.Parameters;
using KrpcCommand.Utilities;

namespace KrpcCommand.Manoeuvres;

/// <summary>
/// Performs a suicide burn landing on an airless body. The manoeuvre targets a specific
/// latitude/longitude on the surface and executes a precisely timed retrograde burn so
/// that the vessel reaches zero velocity at the moment it touches down.
///
/// The burn calculation accounts for changing thrust-to-weight ratio as fuel is consumed,
/// planetary rotation beneath the lander, and extends landing gear during final approach.
/// </summary>
public class SuicideBurnLandingManoeuvre(ManoeuvreLogger logger, ManoeuvreContext context) : IManoeuvre
{
    /// <inheritdoc />
    public string Name => "Suicide Burn Landing";

    /// <inheritdoc />
    public string Description => "Land on an airless body using a suicide burn targeted at a specific location.";

    private readonly DoubleManoeuvreParameter _targetLatitude = new("targetLatitude", "Target latitude (degrees)", 0.0);
    private readonly DoubleManoeuvreParameter _targetLongitude = new("targetLongitude", "Target longitude (degrees)", 0.0);

    /// <inheritdoc />
    public IReadOnlyList<ManoeuvreParameter> Parameters => [_targetLatitude, _targetLongitude];

    // Altitude at which to deploy landing gear (meters)
    private const double GearDeployAltitude = 500.0;

    // Altitude at which to cut engines and let the vessel settle (meters)
    private const double TouchdownAltitude = 8.0;

    // Target vertical speed for final descent (m/s, negative = downward)
    private const double TouchdownSpeed = -1.0;

    // Polling interval for the control loops (ms)
    private const int ControlLoopInterval = 50;

    /// <inheritdoc />
    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var mj = context.MechJeb;

        logger.Log("Ensuring MechJeb API is ready.");
        await mj.EnsureApiReadyAsync(cancellationToken);

        var vessel = context.ActiveVessel;
        var body = vessel.Orbit.Body;
        var targetLat = _targetLatitude.Value;
        var targetLng = _targetLongitude.Value;

        logger.Log($"Target: {targetLat:F4}°, {targetLng:F4}° on {body.Name}");
        logger.Log($"Surface gravity (sea level): {body.SurfaceGravity:F2} m/s²");

        var targetSurfaceHeight = body.SurfaceHeight(targetLat, targetLng);
        var targetRadius = body.EquatorialRadius + targetSurfaceHeight;
        logger.Log($"Target surface elevation: {targetSurfaceHeight:F0} m");

        // Phase 1: Adjust inclination so the ground track can reach the target latitude.
        // This must happen before the deorbit burn, because changing the orbital plane
        // after lowering periapsis would move the periapsis away from the landing site.
        await AdjustInclinationForTarget(targetLat, targetLng, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();

        // Phase 2: Deorbit - lower periapsis to skim the surface near the target
        await PerformDeorbitBurn(targetRadius, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();

        // Phase 3: Kill lateral velocity above the landing site
        await KillLateralVelocityAboveSite(targetLat, targetLng, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();

        // Phase 4: Orient for the burn and wait until it's time
        await WaitForSuicideBurn(body, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();

        // Phase 5: Execute the suicide burn
        await PerformSuicideBurn(body, cancellationToken);

        logger.Log("Landing complete.");
        var flight = vessel.Flight(body.ReferenceFrame);
        logger.Log($"Final position: {flight.Latitude:F4}°, {flight.Longitude:F4}°");
    }

    /// <summary>
    /// Lowers periapsis to just above the target surface radius so the vessel will descend
    /// toward the landing site.
    /// </summary>
    private async Task PerformDeorbitBurn(double targetRadius, CancellationToken cancellationToken)
    {
        var vessel = context.ActiveVessel;
        var body = vessel.Orbit.Body;

        // Target a periapsis that skims just above the surface (10km above target elevation)
        var deorbitPeriapsis = targetRadius - body.EquatorialRadius + 10000;

        // Only deorbit if periapsis is significantly above the target
        var currentPeriapsis = vessel.Orbit.PeriapsisAltitude;
        if (currentPeriapsis <= deorbitPeriapsis + 1000)
        {
            logger.Log("Periapsis already near surface, skipping deorbit burn.");
            return;
        }

        logger.Log($"Lowering periapsis to {deorbitPeriapsis / 1000:F1} km...");

        var planner = context.MechJeb.ManeuverPlanner;
        var operation = planner.OperationPeriapsis;
        operation.NewPeriapsis = deorbitPeriapsis;
        operation.TimeSelector.TimeReference = KRPC.Client.Services.MechJeb.TimeReference.Apoapsis;

        try
        {
            operation.MakeNode();
        }
        catch (Exception ex)
        {
            logger.Log($"Failed to create deorbit node: {ex.Message}");
            throw;
        }

        logger.Log("Executing deorbit burn...");
        var executor = context.MechJeb.NodeExecutor;
        await executor.ExecuteNodeAsync(cancellationToken);

        logger.Log($"Deorbit complete. Periapsis: {vessel.Orbit.PeriapsisAltitude / 1000:F1} km");
    }

    /// <summary>
    /// Adjusts the orbital inclination so the ground track passes over the target latitude.
    /// Burns at the point 90° before the target longitude to rotate the orbital plane.
    /// </summary>
    private async Task AdjustInclinationForTarget(double targetLat, double targetLng, CancellationToken cancellationToken)
    {
        var vessel = context.ActiveVessel;
        var body = vessel.Orbit.Body;

        // We need to change inclination to reach the target latitude.
        // The minimum inclination needed is abs(targetLat).
        var currentInclination = MathUtil.RadToDeg(vessel.Orbit.Inclination);
        var requiredInclination = Math.Abs(targetLat);
        var inclinationDelta = requiredInclination - currentInclination;

        if (Math.Abs(inclinationDelta) < 0.1)
        {
            logger.Log("Orbital inclination already sufficient to reach target latitude.");
            return;
        }

        logger.Log($"Adjusting inclination from {currentInclination:F2}° to {requiredInclination:F2}°...");

        // Calculate the burn: we need to burn at the node 90° before the target longitude.
        // The burn location is at the equator, at (targetLng - 90°).
        var nodeLng = NormalizeLongitude(targetLng - 90.0);

        // Calculate eta to pass over this longitude
        var eta = CalculateEtaToLongitude(vessel, body, nodeLng);

        // Calculate the velocity at the burn point
        var ut = context.UT + eta;
        var velAtNode = vessel.Orbit.OrbitalSpeedAt(eta);

        // The delta-v for a plane change is: 2 * v * sin(deltaAngle / 2)
        // We decompose this into normal and prograde components
        var deltaAngleRad = inclinationDelta * Math.PI / 180.0;

        // For a simple inclination change, the burn is purely in the normal direction
        // relative to the orbital plane at the ascending/descending node
        var normalDv = velAtNode * Math.Sin(deltaAngleRad);
        var progradeDv = velAtNode * (Math.Cos(deltaAngleRad) - 1.0);

        // Create a manoeuvre node
        var control = vessel.Control;
        control.AddNode(ut, prograde: (float)progradeDv, normal: (float)normalDv);

        logger.Log("Executing inclination adjustment burn...");
        var executor = context.MechJeb.NodeExecutor;
        await executor.ExecuteNodeAsync(cancellationToken);

        var newInclination = vessel.Orbit.Inclination * (180.0 / Math.PI);
        logger.Log($"Inclination adjustment complete. New inclination: {newInclination:F2}°");
    }

    /// <summary>
    /// Kills lateral (horizontal) velocity relative to the surface when passing above
    /// the landing site, leaving only a vertical descent.
    /// </summary>
    private async Task KillLateralVelocityAboveSite(double targetLat, double targetLng, CancellationToken cancellationToken)
    {
        var vessel = context.ActiveVessel;
        var body = vessel.Orbit.Body;

        logger.Log("Warping to landing site...");

        // Calculate when we'll pass over the target
        var eta = CalculateEtaToLongitude(vessel, body, targetLng);

        // Warp to near the flyover point (leave some time for the burn)
        var warpTo = context.UT + eta - 60;
        if (warpTo > context.UT + 10)
        {
            context.SpaceCenter.WarpTo(warpTo);
            await WaitForWarpComplete(cancellationToken);
        }

        // Now refine: wait until we're close to the target longitude
        logger.Log("Fine-tuning approach to landing site...");
        var bodyRef = body.ReferenceFrame;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var flight = vessel.Flight(bodyRef);
            var lngDiff = Math.Abs(NormalizeLongitude(flight.Longitude - targetLng));
            if (lngDiff < 1.0)
                break;

            await Task.Delay(100, CancellationToken.None);
        }

        // Now kill horizontal velocity relative to the surface
        logger.Log("Killing lateral velocity...");

        var surfVelocity = vessel.Velocity(bodyRef);
        var vx = surfVelocity.Item1;
        var vy = surfVelocity.Item2;
        var vz = surfVelocity.Item3;

        // Get the radial (up) direction at the vessel's position
        var vesselPos = vessel.Position(bodyRef);
        var posR = Math.Sqrt(vesselPos.Item1 * vesselPos.Item1 +
                                vesselPos.Item2 * vesselPos.Item2 +
                                vesselPos.Item3 * vesselPos.Item3);
        var upX = vesselPos.Item1 / posR;
        var upY = vesselPos.Item2 / posR;
        var upZ = vesselPos.Item3 / posR;

        // Radial (vertical) component of velocity
        var vRadial = vx * upX + vy * upY + vz * upZ;

        // Lateral velocity is total minus radial
        var latVx = vx - vRadial * upX;
        var latVy = vy - vRadial * upY;
        var latVz = vz - vRadial * upZ;
        var lateralSpeed = Math.Sqrt(latVx * latVx + latVy * latVy + latVz * latVz);

        if (lateralSpeed < 1.0)
        {
            logger.Log("Lateral velocity already negligible.");
            return;
        }

        logger.Log($"Lateral velocity: {lateralSpeed:F1} m/s. Burning to kill...");

        // Point retrograde relative to surface and burn
        var autopilot = vessel.AutoPilot;
        autopilot.ReferenceFrame = vessel.SurfaceVelocityReferenceFrame;
        autopilot.TargetDirection = new Tuple<double, double, double>(0, -1, 0); // Retrograde
        autopilot.Engage();

        // Wait for the vessel to align
        await WaitForAlignment(autopilot, 5.0, cancellationToken);

        // Burn until horizontal speed is negligible
        var control = vessel.Control;
        control.Throttle = 1.0f;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var vel = vessel.Velocity(bodyRef);
            var pos = vessel.Position(bodyRef);
            var r = Math.Sqrt(pos.Item1 * pos.Item1 + pos.Item2 * pos.Item2 + pos.Item3 * pos.Item3);
            var ux = pos.Item1 / r;
            var uy = pos.Item2 / r;
            var uz = pos.Item3 / r;

            var vRad = vel.Item1 * ux + vel.Item2 * uy + vel.Item3 * uz;
            var lx = vel.Item1 - vRad * ux;
            var ly = vel.Item2 - vRad * uy;
            var lz = vel.Item3 - vRad * uz;
            var hSpeed = Math.Sqrt(lx * lx + ly * ly + lz * lz);

            if (hSpeed < 2.0)
            {
                // Throttle down proportionally for precision
                control.Throttle = (float)Math.Max(0.05, hSpeed / 10.0);
            }

            if (hSpeed < 0.5)
                break;

            await Task.Delay(ControlLoopInterval, CancellationToken.None);
        }

        control.Throttle = 0.0f;
        autopilot.Disengage();

        logger.Log("Lateral velocity eliminated. Entering free-fall toward surface.");
    }

    /// <summary>
    /// Orients the vessel for retrograde burn and waits until the calculated stopping
    /// distance equals the current altitude — the point at which the burn must begin.
    /// </summary>
    private async Task WaitForSuicideBurn(CelestialBody body, CancellationToken cancellationToken)
    {
        var vessel = context.ActiveVessel;

        logger.Log("Orienting surface retrograde for suicide burn...");

        // Point surface retrograde
        var autopilot = vessel.AutoPilot;
        autopilot.ReferenceFrame = vessel.SurfaceVelocityReferenceFrame;
        autopilot.TargetDirection = new Tuple<double, double, double>(0, -1, 0);
        autopilot.Engage();

        await WaitForAlignment(autopilot, 5.0, cancellationToken);

        logger.Log("Aligned. Waiting for suicide burn start...");

        // Continuously compute required throttle and wait until it reaches 1.0
        var bodyRef = body.ReferenceFrame;
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var requiredThrottle = CalculateRequiredThrottle(vessel, body, bodyRef);

            if (requiredThrottle >= 0.95)
            {
                logger.Log("Suicide burn start point reached!");
                break;
            }

            // Warp during the waiting period if we're high up, otherwise just wait
            var flight = vessel.Flight(bodyRef);
            var altitude = flight.SurfaceAltitude;
            if (altitude > 50000 && requiredThrottle < 0.1)
            {
                // Use physics warp for faster descent
                context.SpaceCenter.PhysicsWarpFactor = 3;
            }
            else if (altitude > 10000 && requiredThrottle < 0.3)
            {
                context.SpaceCenter.PhysicsWarpFactor = 2;
            }
            else
            {
                context.SpaceCenter.PhysicsWarpFactor = 0;
            }

            await Task.Delay(ControlLoopInterval, CancellationToken.None);
        }

        // Ensure no warp during the burn
        context.SpaceCenter.PhysicsWarpFactor = 0;
    }

    /// <summary>
    /// Executes the suicide burn. Continuously adjusts throttle based on the required
    /// deceleration to hit zero velocity at the surface. Deploys landing gear at low altitude.
    /// </summary>
    private async Task PerformSuicideBurn(CelestialBody body, CancellationToken cancellationToken)
    {
        var vessel = context.ActiveVessel;
        var control = vessel.Control;
        var bodyRef = body.ReferenceFrame;

        logger.Log("Executing suicide burn...");

        // Keep steering surface retrograde
        var autopilot = vessel.AutoPilot;
        autopilot.ReferenceFrame = vessel.SurfaceVelocityReferenceFrame;
        autopilot.TargetDirection = new Tuple<double, double, double>(0, -1, 0);
        autopilot.Engage();

        var gearDeployed = false;
        control.Throttle = 1.0f;

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var flight = vessel.Flight(bodyRef);
            var altitude = flight.SurfaceAltitude;
            var verticalSpeed = flight.VerticalSpeed;

            // Deploy landing gear at low altitude
            if (!gearDeployed && altitude < GearDeployAltitude)
            {
                logger.Log("Deploying landing gear.");
                control.Gear = true;
                control.Legs = true;
                gearDeployed = true;
            }

            // Calculate required throttle to stop at the surface
            var requiredThrottle = CalculateRequiredThrottle(vessel, body, bodyRef);

            // Near touchdown, switch to a gentler descent
            if (altitude < TouchdownAltitude * 3 && Math.Abs(verticalSpeed) < 5.0)
            {
                // Final descent - maintain a gentle touchdown speed
                var gravAccel = body.SurfaceGravity;
                var maxAccel = vessel.AvailableThrust / vessel.Mass;
                if (maxAccel > 0)
                {
                    // Throttle to hover minus a slight descent rate
                    var desiredAccel = gravAccel + (verticalSpeed - TouchdownSpeed) * 0.5;
                    control.Throttle = (float)Math.Clamp(desiredAccel / maxAccel, 0, 1);
                }
            }
            else
            {
                control.Throttle = (float)Math.Clamp(requiredThrottle, 0.01, 1.0);
            }

            // Check if we've landed
            if (altitude < TouchdownAltitude && Math.Abs(verticalSpeed) < 2.0)
            {
                control.Throttle = 0.0f;
                logger.Log("Touchdown!");
                break;
            }

            // Safety: if we're moving upward unexpectedly during the burn, cut throttle
            if (verticalSpeed > 5.0 && altitude < 1000)
            {
                control.Throttle = 0.0f;
            }

            await Task.Delay(ControlLoopInterval, CancellationToken.None);
        }

        control.Throttle = 0.0f;
        autopilot.Disengage();

        // Stabilize with SAS
        control.SAS = true;

        logger.Log("Engines cut. Landing complete.");
    }

    /// <summary>
    /// Calculates the throttle fraction (0-1) required to bring the vessel to a stop at the
    /// surface. A value of 1 or greater means full throttle is needed immediately.
    /// This accounts for fuel consumption during the burn using the Tsiolkovsky equation.
    /// </summary>
    private double CalculateRequiredThrottle(Vessel vessel, CelestialBody body, ReferenceFrame bodyRef)
    {
        var flight = vessel.Flight(bodyRef);
        var altitude = flight.SurfaceAltitude;
        var speed = flight.Speed;
        var verticalSpeed = flight.VerticalSpeed;

        // If we're barely moving or already very close, return high throttle to enter burn phase
        if (altitude < 100 && speed < 5)
            return 1.0;

        var mass = vessel.Mass;
        var maxThrust = vessel.AvailableThrust;

        if (maxThrust <= 0)
            return 1.0; // No thrust available, signal immediate action needed

        var gravity = body.GravitationalParameter / Math.Pow(body.EquatorialRadius + altitude, 2);
        var isp = vessel.VacuumSpecificImpulse;

        // Calculate stopping distance using the rocket equation with gravity
        // The deceleration available is: a(t) = (maxThrust / m(t)) - g
        // where m(t) = m0 - (maxThrust / (isp * g0)) * t  (mass decreases as fuel burns)
        //
        // Using the Tsiolkovsky equation, the delta-v to stop is equal to current speed.
        // The stopping distance with variable mass and constant gravity is:
        //
        // We integrate numerically for accuracy.
        var stoppingDistance = CalculateStoppingDistance(speed, mass, maxThrust, isp, gravity);

        // The throttle required is the ratio of stopping distance to current altitude
        // We use altitude as the distance to surface (simplified - assumes vertical descent)
        // For non-vertical descent, project onto the velocity vector
        var effectiveAltitude = altitude;

        // If we have significant horizontal velocity, use the total distance along the velocity vector
        if (speed > 1.0 && verticalSpeed < -0.5)
        {
            // Ratio of downward speed to total speed gives us the vertical component
            var verticalFraction = Math.Abs(verticalSpeed) / speed;
            if (verticalFraction > 0.01)
            {
                effectiveAltitude = altitude / verticalFraction;
            }
        }

        if (effectiveAltitude <= 0)
            return 1.0;

        return stoppingDistance / effectiveAltitude;
    }

    /// <summary>
    /// Numerically integrates the stopping distance accounting for fuel mass loss during the burn.
    /// Uses small time steps to simulate the deceleration with decreasing mass.
    /// </summary>
    private static double CalculateStoppingDistance(double speed, double mass, double maxThrust, double isp, double gravity)
    {
        var g0 = 9.80665;
        var fuelFlowRate = maxThrust / (isp * g0); // kg/s
        var dt = 0.1; // Time step in seconds
        var remainingSpeed = speed;
        var totalDistance = 0.0;
        var currentMass = mass;

        while (remainingSpeed > 0.1 && currentMass > 0)
        {
            var currentAccel = (maxThrust / currentMass) - gravity;

            if (currentAccel <= 0)
            {
                // Cannot decelerate against gravity - return a very large distance
                return double.MaxValue;
            }

            var speedReduction = currentAccel * dt;
            if (speedReduction > remainingSpeed)
            {
                // Partial time step for the final bit
                var partialDt = remainingSpeed / currentAccel;
                totalDistance += remainingSpeed * partialDt - 0.5 * currentAccel * partialDt * partialDt;
                remainingSpeed = 0;
            }
            else
            {
                totalDistance += remainingSpeed * dt - 0.5 * currentAccel * dt * dt;
                remainingSpeed -= speedReduction;
                currentMass -= fuelFlowRate * dt;
            }
        }

        return Math.Max(0, totalDistance);
    }

    /// <summary>
    /// Calculates the time until the vessel passes over a given longitude, accounting
    /// for both the vessel's orbital motion and the body's rotation.
    /// </summary>
    private double CalculateEtaToLongitude(Vessel vessel, CelestialBody body, double targetLng)
    {
        var bodyRef = body.ReferenceFrame;
        var flight = vessel.Flight(bodyRef);

        var currentLng = flight.Longitude;
        var angularDiff = NormalizeLongitude(targetLng - currentLng);

        if (angularDiff < 0)
            angularDiff += 360.0;

        // The vessel's angular velocity over the surface is its orbital angular velocity
        // minus the body's rotational angular velocity
        var orbitalPeriod = vessel.Orbit.Period;
        var orbitalAngularVelocity = 360.0 / orbitalPeriod; // degrees per second

        var bodyRotationPeriod = body.RotationalPeriod;
        var bodyAngularVelocity = 360.0 / bodyRotationPeriod; // degrees per second

        var relativeAngularVelocity = orbitalAngularVelocity - bodyAngularVelocity;

        if (relativeAngularVelocity <= 0)
        {
            // The body rotates faster than the vessel orbits (unlikely but handle it)
            relativeAngularVelocity = orbitalAngularVelocity;
        }

        return angularDiff / relativeAngularVelocity;
    }

    /// <summary>
    /// Waits until the autopilot is aligned within the specified error tolerance.
    /// </summary>
    private static async Task WaitForAlignment(AutoPilot autopilot, double toleranceDegrees, CancellationToken cancellationToken)
    {
        while (autopilot.Error > toleranceDegrees)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(100, CancellationToken.None);
        }
    }

    /// <summary>
    /// Waits until time warp has completed (warp rate back to 1x).
    /// </summary>
    private async Task WaitForWarpComplete(CancellationToken cancellationToken)
    {
        while (context.SpaceCenter.WarpRate > 1)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(500, CancellationToken.None);
        }
    }

    /// <summary>
    /// Normalizes a longitude value to the range [-180, 180].
    /// </summary>
    private static double NormalizeLongitude(double lng)
    {
        while (lng > 180) lng -= 360;
        while (lng < -180) lng += 360;
        return lng;
    }
}
