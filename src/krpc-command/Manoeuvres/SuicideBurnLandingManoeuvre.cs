using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Extensions;
using KrpcCommand.Manoeuvres.Parameters;
using KrpcCommand.Models;
using KrpcCommand.Utilities;
using KrpcCommand.Utilities.AutoBurn;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.Optimization;
using MathNet.Numerics.RootFinding;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

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
        
        // Phase 4: Perform the suicide burn
        await PerformSuicideBurn(cancellationToken);

        logger.Log("Landing complete.");
        var flight = vessel.Flight(body.NonRotatingReferenceFrame);
        logger.Log($"Final position: {flight.Latitude:F4}°, {flight.Longitude:F4}°");
    }

    private async Task PerformDeorbitBurn(CancellationToken cancellationToken)
    {
        var ship = context.ActiveVessel;
        var body = ship.Orbit.Body;

        // Calculate the UT at which we will perform the deorbit burn
        logger.Log("Calculating deorbit burn...");
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
        logger.Log("Executing deorbit burn...");
        await context.MechJeb.NodeExecutor.ExecuteNodeAsync(cancellationToken);
    }

    private async Task PerformDeorbitCorrectionBurn(CancellationToken cancellationToken)
    {
        const double correctionBurnTolerance = 5;

        var ship = context.ActiveVessel;
        var orbit = ship.Orbit;
        var body = orbit.Body;

        // Calculate the parameters for the Lambert solve
        logger.Log("Calculating deorbit correction burn...");
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
        logger.Log($"Executing correction burn...");
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
        var root = Brent.FindRoot(Func, tMin, tMax, 1);
        _flyoverUt = burnUt + root; // Store the flyover time & position for the correction burn later
        _flyoverPosition = body.PositionAtAltitudeAt(
            _flyoverUt,
            _lat,
            _lng,
            flyoverAltitude,
            body.NonRotatingReferenceFrame).ToVector3D();

        lambertParams.TimeOfFlight = root;
        return SolveLambert(lambertParams).v1;

        double Func(double t)
        {
            lambertParams.TimeOfFlight = t;
            var (v1, _) = SolveLambert(lambertParams);
            var radialVelocity = v1.DotProduct(lambertParams.DeorbitBurnPosition.Normalize());
            return radialVelocity;
        }
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
        logger.Log("Calculating lateral kill burn...");
        var burnUt = CalculateLateralBurnUt(cancellationToken);

        logger.Log("Executing lateral kill burn...");
        var rf = context.ActiveVessel.SurfaceReferenceFrame;
        var ap = new VelocityAutoBurn(context.Connection);
        ap.LockTarget(GetTarget, rf);
        ap.SetRemainingBurn(GetRemainingBurn, rf);
        ap.BurnAt(burnUt);
        
        await ap.Engage(cancellationToken);
        return;

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

        Vector3D CalculateRemainingBurn(SimulationState state, CelestialBody b)
        {
            var surfaceVelocity = b.SurfaceVelocityBelowAt(state.UT, state.ShipPosition.ToTuple()).ToVector3D();
            return state.ShipVelocity - surfaceVelocity;
        }
    }

    private async Task PerformSuicideBurn(CancellationToken cancellationToken)
    {
        var ship = context.ActiveVessel;
        var body = ship.Orbit.Body;
        var surfRf = ship.SurfaceReferenceFrame;
        var bodyRf = body.NonRotatingReferenceFrame;
        var surfVelRf = ship.SurfaceVelocityReferenceFrame;
        
        // Point the ship in the surface retrograde direction and wait for it to turn
        logger.Log("Aligning ship for landing burn...");
        var ap = ship.AutoPilot;
        ap.ReferenceFrame = ship.SurfaceVelocityReferenceFrame;
        ap.TargetDirection = new Tuple<double, double, double>(0, -1, 0);
        ap.Engage();
        ap.Wait();
        
        // Figure out which part will hit the surface first, and how far below the ship's CoM it is
        var bottomPart = ship.FindPart(Comparator);
        var vertices = bottomPart.BoundingBox(ship.ReferenceFrame);
        var bottomVertexPos = 
            vertices.Item1.Item2 < vertices.Item2.Item2 ? vertices.Item1 : vertices.Item2; // Y axis points to top/front of ship
        var comHeight = bottomVertexPos.Item2;
        
        // Set up the burn, ready to go as soon as we need it
        var burn = new PositionAutoBurn(context.Connection);
        burn.LockTarget(v => -v, surfRf);
        burn.SetTargetBody(body);
        burn.SetRemainingDistance(RemainingDistance, bodyRf);
        burn.SetRemainingVelocity(RemainingVelocity, surfVelRf);
        burn.AddPositionHook(ShouldLowerLegs, LowerLegs, bodyRf);
        
        // Wait until we need to start the burn
        logger.Log("Waiting for landing burn start...");
        var altPrev = 0d;
        while (true)
        {
            var alt = CalculateCurrentStoppingHeight(cancellationToken);
            
            // If we're already going to stop below the surface, then obviously start burning now
            if (alt < comHeight)
            {
                break;
            }
            
            // If we think by the time we manage to calculate the stopping altitude again we may have already
            // overshot, then start burning now
            // TODO maybe make this a bit more sophisticated
            if (alt - (altPrev - alt) < comHeight)
            {
                break;
            }

            altPrev = alt;
        }
        
        // Perform the suicide burn
        logger.Log("Performing landing burn...");
        await burn.Engage(cancellationToken);

        bool ShouldLowerLegs(Vector3D pos)
        {
            var x = pos.ToTuple();
            var alt = body.AltitudeAtPosition(x, bodyRf);
            var surfAlt = body.SurfaceAltitudeAtPosition(x, bodyRf);
            return alt - surfAlt < GearDeployAltitude;
        }

        void LowerLegs(Vessel s)
        {
            s.Control.Legs = true;
        }

        double RemainingDistance(Vector3D pos)
        {
            var surfaceAlt = body.SurfaceAltitudeAtPosition(pos.ToTuple(), bodyRf);
            var lowestPointAlt = pos.Length - comHeight;
            return lowestPointAlt - surfaceAlt;
        }

        double RemainingVelocity(Vector3D v)
        {
            return ship.Velocity(surfVelRf).ToVector3D().Length;
        }
        
        Part Comparator(Part p1, Part p2)
        {
            var p1LowestVertex = GetLowestVertex(p1);
            var p2LowestVertex = GetLowestVertex(p2);

            return p1LowestVertex.X < p2LowestVertex.X ? p1 : p2;
        }

        Vector3D GetLowestVertex(Part p)
        {
            var bounds = p.BoundingBox(surfRf);
            if (bounds.Item1.Item1 < bounds.Item2.Item1)
                return bounds.Item1.ToVector3D();
            
            return bounds.Item2.ToVector3D();
        }
    }

    /// <summary>
    /// Calculates what the height of the ship would be above the surface when it reaches 0 velocity relative to the
    /// surface by simulating the suicide burn starting now.
    /// This takes into account the reduction of mass due to burning fuel and the increase in
    /// gravitational acceleration as the ship approaches the body, along with any precision issues in previous
    /// burns that led to the surface velocity and the ship's lateral velocity drifting apart.
    /// </summary>
    private double CalculateCurrentStoppingHeight(CancellationToken cancellationToken)
    {
        var ut = context.UT;
        var ship = context.ActiveVessel;
        var body = ship.Orbit.Body;
        var rf = body.NonRotatingReferenceFrame;

        var simulationParams = new SimulationParameters(ship);
        var initialState = new SimulationState(ut, ship.Position(rf).ToVector3D(), ship.Velocity(rf).ToVector3D());
        var simulator = new BurnSimulator(TimeSpan.FromMilliseconds(1000 / 60), 
            initialState, 
            simulationParams, 
            RemainingBurn);
        var finalState = simulator.Run(cancellationToken);

        return body.SurfaceAltitudeAtPosition(finalState.ShipPosition.ToTuple(), rf);

        Vector3D RemainingBurn(SimulationState state)
        {
            var surfaceVelocity = body.SurfaceVelocityBelowAt(state.UT, state.ShipPosition.ToTuple()).ToVector3D();
            var delta = state.ShipVelocity - surfaceVelocity;
            return -delta;
        }
    }
}
