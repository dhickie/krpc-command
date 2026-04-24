using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Extensions;
using KrpcCommand.Manoeuvres.Parameters;
using KrpcCommand.Models;
using KrpcCommand.Utilities;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.RootFinding;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using AutoPilot = KRPC.Client.Services.SpaceCenter.AutoPilot;

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

    private readonly DoubleManoeuvreParameter _targetLongitude =
        new("targetLongitude", "Target longitude (degrees)", 0.0);

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

    // Manoeuvre variables that are useful to have across functions
    // ReSharper disable once InconsistentNaming
    private double _lat => _targetLatitude.Value;

    // ReSharper disable InconsistentNaming
    private double _lng => _targetLongitude.Value;
    // ReSharper restore InconsistentNaming

    private Vector3D _flyoverPosition;
    private double _deorbitBurnUt;
    private double _flyoverUt;

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

        // Phase 1: Perform a deorbit burn that adjusts the ship's trajectory so that it passes a short distance above
        // the target landing site. The exact altitude at which it passes over the landing site will differ depending
        // on the ship's initial altitude when the burn begins
        await PerformDeorbitBurn(cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();

        // Phase 2: Halfway to the flyover point, perform a correction burn to ensure we pass over the flyover point
        // at the correct time
        await PerformDeorbitCorrectionBurn(cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();

        // Phase 3: Kill lateral velocity above the landing site
        await KillLateralVelocityAboveSite(cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();

        // Phase 4: Orient for the burn and wait until it's time
        await WaitForSuicideBurn(body, cancellationToken);
        cancellationToken.ThrowIfCancellationRequested();

        // Phase 5: Execute the suicide burn
        await PerformSuicideBurn(body, cancellationToken);

        logger.Log("Landing complete.");
        var flight = vessel.Flight(body.NonRotatingReferenceFrame);
        logger.Log($"Final position: {flight.Latitude:F4}°, {flight.Longitude:F4}°");
    }

    private async Task PerformDeorbitBurn(CancellationToken cancellationToken)
    {
        var ship = context.ActiveVessel;
        var body = ship.Orbit.Body;

        // Calculate the UT at which we will perform the deorbit burn
        var burnUt = CalculateDeorbitUt();
        _deorbitBurnUt = burnUt;

        // Calculate where the ship will be when the burn takes place
        var positionAtBurn =
            ship.Orbit.PositionAt(burnUt, body.NonRotatingReferenceFrame).ToVector3D();

        // Calculate a reasonable upper bound for the flyover altitude over the landing site
        var flyoverAltitude = CalculateWorstCaseLandingBurnAltitude(positionAtBurn);

        // Calculate what the ship's velocity needs to be after the burn to hit the flyover position
        var postBurnVelocity =
            CalculatePostBurnVelocity(positionAtBurn, burnUt, flyoverAltitude);

        // Create the manoeuvre node
        NodeUtil.CreateNodeFromTargetVelocity(ship, burnUt, postBurnVelocity);

        // Perform the burn
        await context.MechJeb.NodeExecutor.ExecuteNodeAsync(cancellationToken);
    }

    private async Task PerformDeorbitCorrectionBurn(CancellationToken cancellationToken)
    {
        const double correctionBurnTolerance = 5;

        var ship = context.ActiveVessel;
        var orbit = ship.Orbit;
        var body = orbit.Body;

        // Calculate the parameters for the Lambert solve
        var tof = (_flyoverUt - _deorbitBurnUt) / 2;
        var burnUt = tof + _deorbitBurnUt;
        var burnPosition = orbit.PositionAt(burnUt, body.NonRotatingReferenceFrame).ToVector3D();

        // Solve Lambert
        var solver = new IzzoLambertSolver();
        var (v1, _) = solver.Solve(
            body.GravitationalParameter,
            burnPosition,
            _flyoverPosition,
            TimeSpan.FromSeconds(tof));

        var burn = ship.VelocityAt(burnUt).ToVector3D() - v1;

        // Skip the correction burn if it's sufficiently small
        if (burn.Length <= correctionBurnTolerance)
        {
            return;
        }

        // Create and execute the node
        NodeUtil.CreateNodeFromTargetVelocity(ship, burnUt, burnPosition);
        await context.MechJeb.NodeExecutor.ExecuteNodeAsync(cancellationToken);
    }

    private double CalculateDeorbitUt()
    {
        var ship = context.ActiveVessel;
        var body = ship.Orbit.Body;
        var ut = context.UT;

        // Calculate the position along the existing orbit that is closest to the landing site
        var orbitNormal = ship.OrbitNormal().ToUnitVector3D();
        var landingPosition =
            body.SurfacePosition(_lat, _lng, body.NonRotatingReferenceFrame)
                .ToVector3D();
        var angle = orbitNormal.AngleTo(landingPosition).Degrees;
        if (angle is 0 or 180)
        {
            // Special case - if the ship's orbit is exactly 90 degrees out the choice of deorbit burn point is
            // arbitrary
            // Just pick a time 10 minutes into the future to give us time to calculate and orient the ship and 
            // accommodate for particularly long deorbit burns
            return ut + 600;
        }

        var closestPosition = body
            .SurfacePosition(_lat, _lng, body.NonRotatingReferenceFrame)
            .ToVector3D()
            .ProjectOn(orbitNormal);

        // Rotate the closest position by 60 degrees retrograde
        var burnPosition = closestPosition.Rotate(orbitNormal, Angle.FromDegrees(-60));

        // Calculate the true anomaly at that point
        var timeToPeriapsis = ship.Orbit.TimeToPeriapsis;
        var periapsisPosition =
            ship.Orbit.PositionAt(timeToPeriapsis + ut, body.NonRotatingReferenceFrame).ToVector3D();
        var trueAnomaly = burnPosition.AngleTo(periapsisPosition);

        var normal = burnPosition.CrossProduct(periapsisPosition);
        if (normal.AngleTo(orbitNormal).Degrees < 90)
        {
            // If the cross product of the burn position to the periapsis points in the same direction as the orbit
            // normal, then that point of the orbit is after the apoapsis. Since the angle given by AngleTo will always
            // be less than 180, we need to get the other part of the orbit
            trueAnomaly = Angle.FromDegrees(360 - trueAnomaly.Degrees);
        }

        return ship.Orbit.TimeToTrueAnomaly(trueAnomaly.Radians) + ut;
    }

    /// <summary>
    /// Calculates the worst case for the altitude of the ship when it has to initiate its landing burn.
    /// Models the worst case as the ship falling with surface gravity, with maximum weight, falling straight down
    /// from the point of the deorbit burn to the landing site, without any initial vertical velocity.
    /// This is a very conservative model that should give a safe upper bound on the required burn altitude.
    /// </summary>
    /// <param name="deorbitBurnPosition">The position of the ship relative to the body when the deorbit burn is performed</param>
    /// <returns>The worst case altitude for when the burn would need to be initialised</returns>
    private double CalculateWorstCaseLandingBurnAltitude(Vector3D deorbitBurnPosition)
    {
        var ship = context.ActiveVessel;
        var body = ship.Orbit.Body;

        var landingSiteAltitude = body.SurfaceHeight(_lat, _lng);
        var fallDistance = deorbitBurnPosition.Length - (body.EquatorialRadius + landingSiteAltitude);
        var g = body.GravitationalParameter / Math.Pow(body.EquatorialRadius, 2);

        var maxBurnHeight = (ship.Mass * g * fallDistance) / ship.AvailableThrust;

        return maxBurnHeight;
    }

    private Vector3D CalculatePostBurnVelocity(Vector3D deorbitBurnPosition,
        double burnUt,
        double flyoverAltitude)
    {
        var ship = context.ActiveVessel;
        var body = ship.Orbit.Body;

        // Calculate a lower bound for the time of flight, as the circular orbit time between the two points at the 
        // same altitude
        var circularOrbitVelocity = Math.Sqrt(body.GravitationalParameter / deorbitBurnPosition.Length);
        var arcAngle = deorbitBurnPosition.AngleTo(
            body.SurfacePosition(
                _lat, _lng, body.NonRotatingReferenceFrame).ToVector3D());
        var t0 = (deorbitBurnPosition.Length * arcAngle.Radians) / circularOrbitVelocity;

        // Calculate a time bracket for the root search, by incrementing the time of flight until the initial
        // radial velocity flips from negative (falling toward the body) to positive (moving away from the body)
        var lambertParams = new DeorbitLambertProblemParams(
            burnUt,
            t0,
            flyoverAltitude,
            deorbitBurnPosition);
        var (tMin, tMax) = FindRootSearchBracket(lambertParams);

        // Use Brent's method to search over the bracket to find the exact velocity that keeps the ship's radial
        // velocity at zero after the deorbit burn
        Func<double, double> func = t =>
        {
            lambertParams.TimeOfFlight = t;
            var (v1, v2) = SolveLambert(lambertParams);
            var radialVelocity = v1.DotProduct(lambertParams.DeorbitBurnPosition.Normalize());
            return radialVelocity;
        };
        var root = Brent.FindRoot(func, tMin, tMax, 1, 100);
        _flyoverUt = burnUt + root; // Store the flyover time & position for the correction burn later
        _flyoverPosition = body.PositionAtAltitudeAt(
            _flyoverUt,
            _lat,
            _lng,
            flyoverAltitude,
            body.NonRotatingReferenceFrame).ToVector3D();

        lambertParams.TimeOfFlight = root;
        return SolveLambert(lambertParams).v1;
    }

    private (double tMin, double tMax) FindRootSearchBracket(DeorbitLambertProblemParams parameters)
    {
        const double timeStep = 60;
        var t0 = parameters.TimeOfFlight;
        var tMin = t0;
        var tMax = 0.0;

        var flipPointFound = false;
        while (!flipPointFound)
        {
            parameters.TimeOfFlight = tMin + timeStep;
            if (!TrySolveLambert(parameters, out (Vector3D v1, Vector3D _) solution))
            {
                // If this has happened after finding an initial viable trajectory, then we can't find the root later
                // so throw an exception to abandon the manoeuvre
                if (tMin > t0)
                {
                    throw new InvalidOperationException(
                        "Impossible to find valid trajectory for provided manoeuvre parameters");
                }

                // Otherwise increment tMin to skip over the unsolvable time of flight
                tMin += timeStep;
                continue;
            }

            var radialVelocity = solution.v1.DotProduct(parameters.DeorbitBurnPosition.Normalize());
            if (radialVelocity > 0)
            {
                flipPointFound = true;
                tMax = tMin + timeStep;
            }
            else
            {
                tMin += timeStep;
            }
        }

        return (tMin, tMax);
    }

    private (Vector3D v1, Vector3D v2) SolveLambert(DeorbitLambertProblemParams parameters)
    {
        if (TrySolveLambert(parameters, out var solution))
        {
            return solution;
        }

        throw new InvalidOperationException("Unable to solve lambert problem for provided parameters.");
    }

    private bool TrySolveLambert(DeorbitLambertProblemParams parameters, out (Vector3D v1, Vector3D v2) solution)
    {
        var body = context.ActiveVessel.Orbit.Body;

        var ut = parameters.BurnUt;
        var tof = parameters.TimeOfFlight;
        var alt = parameters.FlyoverAltitude;
        var pos = parameters.DeorbitBurnPosition;

        // Calculate where the flyover point will be at the end of the trajectory
        var flyPos = body.PositionAtAltitudeAt(
            ut + tof,
            _lat,
            _lng,
            alt,
            body.NonRotatingReferenceFrame).ToVector3D();

        // Solve the Lambert problem for these parameters to get the required post-burn velocity
        var solver = new IzzoLambertSolver();
        return solver.TrySolve(body.GravitationalParameter,
            pos,
            flyPos,
            TimeSpan.FromSeconds(tof),
            out solution);
    }

    /// <summary>
    /// Kills lateral (horizontal) velocity relative to the surface when passing above
    /// the landing site, leaving only a vertical descent.
    /// Assumes that the ship's flyover time is accurate after the correction burn.
    /// </summary>
    private async Task KillLateralVelocityAboveSite(CancellationToken cancellationToken)
    {
        // There are several factors affecting the accuracy of the burn here.
        // If we burn when we hit the flyover point, the ship will overshoot as we shed the lateral velocity
        // If we burn early, the total time of flight will be longer and so the body below will have rotated more
        // by the time we hit the flyover position.
        // So we use a numerical method (BFGS) to calculate the ideal time to start burning that minimises
        // the final distance to the landing site.
        
        // Calculate when to perform the burn
        var burnUt = CalculateLateralBurnUt(cancellationToken);

        // Perform the burn
        Vector3D GetTarget(Vector3D velocity)
        {
            // Vector that takes the lateral components of the ship's velocity relative to the surface
            return new Vector3D(0, -velocity.Y, -velocity.Z);
        }

        double GetRemainingBurn(Vector3D velocity)
        {
            return GetTarget(velocity).Length;
        }

        var ap = new AutoPilotUtil(context.Connection);
        ap.LockTarget(GetTarget, context.ActiveVessel.SurfaceReferenceFrame);
        ap.SetRemainingBurn(GetRemainingBurn);
        ap.BurnAt(burnUt);
        
        await ap.Engage(cancellationToken);
    }

    private double CalculateLateralBurnUt(CancellationToken cancellationToken)
    {
        // Use the flyover time as the initial guess
        var initialGuess = new DenseVector([_flyoverUt]);
        double EvalFunc(Vector<double> x) => SimulateLateralBurn(x[0], cancellationToken);
        Vector<double> GradFunc(Vector<double> x)
        {
            const double epsilon = 0.1; // Perturbation for numerical gradient
            var grad = 
                (SimulateLateralBurn(x[0] + epsilon, cancellationToken) - SimulateLateralBurn(x[0] - epsilon, cancellationToken)) / (2 * epsilon);
            return new DenseVector([grad]);
        }

        var opt = ObjectiveFunction.Gradient(EvalFunc, GradFunc);

        var minimiser = new BfgsMinimizer(1e-5, 1e-5, 1e-5);
        var result = minimiser.FindMinimum(opt, initialGuess);

        return result.MinimizingPoint[0];
    }

    private double SimulateLateralBurn(double burnUt, CancellationToken cancellationToken)
    {
        var ship = context.ActiveVessel;
        var orbit = ship.Orbit;
        var body = orbit.Body;
        var rf = body.NonRotatingReferenceFrame;

        var r = orbit.PositionAt(burnUt, body.NonRotatingReferenceFrame).ToVector3D();
        var v = ship.VelocityAt(burnUt).ToVector3D();

        var initialState = new SimulationState(burnUt, r, v);
        var parameters = new SimulationParameters(ship);

        var simulator = new BurnSimulator(TimeSpan.FromMilliseconds(50), 
            initialState, 
            parameters,
            state => CalculateRemainingBurn(state, body));
        var endState = simulator.Run(cancellationToken);
        
        // Return the distance between the stopping point and the intended landing site in meters
        var lat = body.LatitudeAtPosition(endState.ShipPosition.ToTuple(), rf);
        var lng = body.LongitudeAtPositionAt(endState.UT, endState.ShipPosition.ToTuple(), rf);
        var surfacePos = body.SurfacePosition(lat, lng, rf).ToVector3D();
        var intendedLandingSite = body.SurfacePosition(_lat, _lng, rf).ToVector3D();
        
        return Math.Abs((intendedLandingSite - surfacePos).Length);
    }

    private Vector3D CalculateRemainingBurn(SimulationState state, CelestialBody body)
    {
        var surfaceVelocity = body.SurfaceVelocityBelowAt(state.UT, state.ShipPosition.ToTuple()).ToVector3D();
        return state.ShipVelocity - surfaceVelocity;
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
        var bodyRef = body.NonRotatingReferenceFrame;
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
        var bodyRef = body.NonRotatingReferenceFrame;

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
