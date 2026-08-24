using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Describes an orbit. For example, the orbit of a vessel, obtained by calling
/// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Vessel.GetOrbit" />, or a celestial body, obtained by calling
/// <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.CelestialBody.GetOrbit" />.
/// </summary>
public class Orbit : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal Orbit(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Estimates and returns the distance at closest approach to a target orbit, in meters.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [GetRpc("SpaceCenter", "Orbit_DistanceAtClosestApproach")]
    public double GetDistanceAtClosestApproach(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_DistanceAtClosestApproach", args);
    }

    /// <summary>
    /// Estimates and returns the distance at closest approach to a target orbit, in meters.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [GetRpc("SpaceCenter", "Orbit_DistanceAtClosestApproach")]
    public async Task<double> GetDistanceAtClosestApproachAsync(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_DistanceAtClosestApproach", args);
    }

    /// <summary>
    /// The eccentric anomaly at the given universal time.
    /// </summary>
    /// <param name="ut">The universal time, in seconds.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_EccentricAnomalyAtUT")]
    public Angle GetEccentricAnomalyAtUT(double ut)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_EccentricAnomalyAtUT", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The eccentric anomaly at the given universal time.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="ut">The universal time, in seconds.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_EccentricAnomalyAtUT")]
    public async Task<Angle> GetEccentricAnomalyAtUTAsync(double ut)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_EccentricAnomalyAtUT", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Returns the times at closest approach and corresponding distances, to a target orbit.
    /// </summary>
    /// <returns>
    /// A list of two lists.
    /// The first is a list of times at closest approach, as universal times in seconds.
    /// The second is a list of corresponding distances at closest approach, in meters.
    /// </returns>
    /// <param name="target">Target orbit.</param>
    /// <param name="orbits">The number of future orbits to search.</param>
    [GetRpc("SpaceCenter", "Orbit_ListClosestApproaches")]
    public List<List<double>> GetListClosestApproaches(Orbit target, int orbits)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target,
            orbits
        };
        return InvokeNonNullable<List<List<double>>>("SpaceCenter", "Orbit_ListClosestApproaches", args);
    }

    /// <summary>
    /// Returns the times at closest approach and corresponding distances, to a target orbit.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>
    /// A list of two lists.
    /// The first is a list of times at closest approach, as universal times in seconds.
    /// The second is a list of corresponding distances at closest approach, in meters.
    /// </returns>
    /// <param name="target">Target orbit.</param>
    /// <param name="orbits">The number of future orbits to search.</param>
    [GetRpc("SpaceCenter", "Orbit_ListClosestApproaches")]
    public async Task<List<List<double>>> GetListClosestApproachesAsync(Orbit target, int orbits)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target,
            orbits
        };
        return await InvokeNonNullableAsync<List<List<double>>>("SpaceCenter", "Orbit_ListClosestApproaches", args);
    }

    /// <summary>
    /// The mean anomaly at the given time.
    /// </summary>
    /// <param name="ut">The universal time in seconds.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_MeanAnomalyAtUT")]
    public Angle GetMeanAnomalyAtUT(double ut)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_MeanAnomalyAtUT", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The mean anomaly at the given time.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="ut">The universal time in seconds.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_MeanAnomalyAtUT")]
    public async Task<Angle> GetMeanAnomalyAtUTAsync(double ut)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_MeanAnomalyAtUT", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The orbital speed at the given time, in meters per second.
    /// </summary>
    /// <param name="time">Time from now, in seconds.</param>
    [GetRpc("SpaceCenter", "Orbit_OrbitalSpeedAt")]
    public double GetOrbitalSpeedAt(double time)
    {
        var args = new ProcedureArgument[]
        {
            this,
            time
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_OrbitalSpeedAt", args);
    }

    /// <summary>
    /// The orbital speed at the given time, in meters per second.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="time">Time from now, in seconds.</param>
    [GetRpc("SpaceCenter", "Orbit_OrbitalSpeedAt")]
    public async Task<double> GetOrbitalSpeedAtAsync(double time)
    {
        var args = new ProcedureArgument[]
        {
            this,
            time
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_OrbitalSpeedAt", args);
    }

    /// <summary>
    /// The position at a given time, in the specified reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="ut">The universal time to measure the position at.</param>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [GetRpc("SpaceCenter", "Orbit_PositionAt")]
    public Vector3D GetPositionAt(double ut, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut,
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "Orbit_PositionAt", args);
    }

    /// <summary>
    /// The position at a given time, in the specified reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="ut">The universal time to measure the position at.</param>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [GetRpc("SpaceCenter", "Orbit_PositionAt")]
    public async Task<Vector3D> GetPositionAtAsync(double ut, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "Orbit_PositionAt", args);
    }

    /// <summary>
    /// The orbital radius at the given time, in meters.
    /// </summary>
    /// <param name="ut">The universal time to measure the radius at.</param>
    [GetRpc("SpaceCenter", "Orbit_RadiusAt")]
    public double GetRadiusAt(double ut)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_RadiusAt", args);
    }

    /// <summary>
    /// The orbital radius at the given time, in meters.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="ut">The universal time to measure the radius at.</param>
    [GetRpc("SpaceCenter", "Orbit_RadiusAt")]
    public async Task<double> GetRadiusAtAsync(double ut)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_RadiusAt", args);
    }

    /// <summary>
    /// The orbital radius at the point in the orbit given by the true anomaly.
    /// </summary>
    /// <param name="trueAnomaly">The true anomaly.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_RadiusAtTrueAnomaly")]
    public double GetRadiusAtTrueAnomaly(Angle trueAnomaly)
    {
        var args = new ProcedureArgument[]
        {
            this,
            trueAnomaly.Radians
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_RadiusAtTrueAnomaly", args);
    }

    /// <summary>
    /// The orbital radius at the point in the orbit given by the true anomaly.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="trueAnomaly">The true anomaly.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_RadiusAtTrueAnomaly")]
    public async Task<double> GetRadiusAtTrueAnomalyAsync(Angle trueAnomaly)
    {
        var args = new ProcedureArgument[]
        {
            this,
            trueAnomaly.Radians
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_RadiusAtTrueAnomaly", args);
    }

    /// <summary>
    /// Relative inclination of this orbit and the target orbit.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_RelativeInclination")]
    public Angle GetRelativeInclination(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_RelativeInclination", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Relative inclination of this orbit and the target orbit.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_RelativeInclination")]
    public async Task<Angle> GetRelativeInclinationAsync(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_RelativeInclination", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Estimates and returns the time at closest approach to a target orbit.
    /// </summary>
    /// <returns>The universal time at closest approach, in seconds.</returns>
    /// <param name="target">Target orbit.</param>
    [GetRpc("SpaceCenter", "Orbit_TimeOfClosestApproach")]
    public double GetTimeOfClosestApproach(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_TimeOfClosestApproach", args);
    }

    /// <summary>
    /// Estimates and returns the time at closest approach to a target orbit.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The universal time at closest approach, in seconds.</returns>
    /// <param name="target">Target orbit.</param>
    [GetRpc("SpaceCenter", "Orbit_TimeOfClosestApproach")]
    public async Task<double> GetTimeOfClosestApproachAsync(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_TimeOfClosestApproach", args);
    }

    /// <summary>
    /// The true anomaly of the ascending node with the given target orbit.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_TrueAnomalyAtAN")]
    public Angle GetTrueAnomalyAtAN(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_TrueAnomalyAtAN", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The true anomaly of the ascending node with the given target orbit.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_TrueAnomalyAtAN")]
    public async Task<Angle> GetTrueAnomalyAtANAsync(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_TrueAnomalyAtAN", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The true anomaly of the descending node with the given target orbit.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_TrueAnomalyAtDN")]
    public Angle GetTrueAnomalyAtDN(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_TrueAnomalyAtDN", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The true anomaly of the descending node with the given target orbit.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_TrueAnomalyAtDN")]
    public async Task<Angle> GetTrueAnomalyAtDNAsync(Orbit target)
    {
        var args = new ProcedureArgument[]
        {
            this,
            target
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_TrueAnomalyAtDN", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The true anomaly at the given orbital radius.
    /// </summary>
    /// <param name="radius">The orbital radius in meters.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_TrueAnomalyAtRadius")]
    public Angle GetTrueAnomalyAtRadius(double radius)
    {
        var args = new ProcedureArgument[]
        {
            this,
            radius
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_TrueAnomalyAtRadius", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The true anomaly at the given orbital radius.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="radius">The orbital radius in meters.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_TrueAnomalyAtRadius")]
    public async Task<Angle> GetTrueAnomalyAtRadiusAsync(double radius)
    {
        var args = new ProcedureArgument[]
        {
            this,
            radius
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_TrueAnomalyAtRadius", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The true anomaly at the given time.
    /// </summary>
    /// <param name="ut">The universal time in seconds.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_TrueAnomalyAtUT")]
    public Angle GetTrueAnomalyAtUT(double ut)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_TrueAnomalyAtUT", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The true anomaly at the given time.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="ut">The universal time in seconds.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_TrueAnomalyAtUT")]
    public async Task<Angle> GetTrueAnomalyAtUTAsync(double ut)
    {
        var args = new ProcedureArgument[]
        {
            this,
            ut
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_TrueAnomalyAtUT", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// The universal time, in seconds, corresponding to the given true anomaly.
    /// </summary>
    /// <param name="trueAnomaly">True anomaly.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_UTAtTrueAnomaly")]
    public double GetUTAtTrueAnomaly(Angle trueAnomaly)
    {
        var args = new ProcedureArgument[]
        {
            this,
            trueAnomaly.Radians
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_UTAtTrueAnomaly", args);
    }

    /// <summary>
    /// The universal time, in seconds, corresponding to the given true anomaly.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="trueAnomaly">True anomaly.</param>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_UTAtTrueAnomaly")]
    public async Task<double> GetUTAtTrueAnomalyAsync(Angle trueAnomaly)
    {
        var args = new ProcedureArgument[]
        {
            this,
            trueAnomaly.Radians
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_UTAtTrueAnomaly", args);
    }

    /// <summary>
    /// The direction from which the orbits longitude of ascending node is measured,
    /// in the given reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [StaticRpc("SpaceCenter", "Orbit_static_ReferencePlaneDirection")]
    public Vector3D GetReferencePlaneDirection(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "Orbit_static_ReferencePlaneDirection", args);
    }

    /// <summary>
    /// The direction from which the orbits longitude of ascending node is measured,
    /// in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [StaticRpc("SpaceCenter", "Orbit_static_ReferencePlaneDirection")]
    public async Task<Vector3D> GetReferencePlaneDirectionAsync(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "Orbit_static_ReferencePlaneDirection", args);
    }

    /// <summary>
    /// The direction that is normal to the orbits reference plane,
    /// in the given reference frame.
    /// The reference plane is the plane from which the orbits inclination is measured.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [StaticRpc("SpaceCenter", "Orbit_static_ReferencePlaneNormal")]
    public Vector3D GetReferencePlaneNormal(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "Orbit_static_ReferencePlaneNormal", args);
    }

    /// <summary>
    /// The direction that is normal to the orbits reference plane,
    /// in the given reference frame.
    /// The reference plane is the plane from which the orbits inclination is measured.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [StaticRpc("SpaceCenter", "Orbit_static_ReferencePlaneNormal")]
    public async Task<Vector3D> GetReferencePlaneNormalAsync(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "Orbit_static_ReferencePlaneNormal", args);
    }

    /// <summary>
    /// Gets the apoapsis of the orbit, in meters, from the center of mass
    /// of the body being orbited.
    /// </summary>
    /// <remarks>
    /// For the apoapsis altitude reported on the in-game map view,
    /// use <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Orbit.GetApoapsisAltitude" />.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_Apoapsis")]
    public double GetApoapsis()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_Apoapsis", args);
    }

    /// <summary>
    /// Gets the apoapsis of the orbit, in meters, from the center of mass
    /// of the body being orbited.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// For the apoapsis altitude reported on the in-game map view,
    /// use <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Orbit.GetApoapsisAltitude" />.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_Apoapsis")]
    public async Task<double> GetApoapsisAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_Apoapsis", args);
    }

    /// <summary>
    /// Gets the apoapsis of the orbit, in meters, above the sea level of the body being orbited.
    /// </summary>
    /// <remarks>
    /// This is equal to <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Orbit.GetApoapsis" /> minus the equatorial radius of the body.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_ApoapsisAltitude")]
    public double GetApoapsisAltitude()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_ApoapsisAltitude", args);
    }

    /// <summary>
    /// Gets the apoapsis of the orbit, in meters, above the sea level of the body being orbited.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This is equal to <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Orbit.GetApoapsis" /> minus the equatorial radius of the body.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_ApoapsisAltitude")]
    public async Task<double> GetApoapsisAltitudeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_ApoapsisAltitude", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Argument_of_periapsis">argument of
    /// periapsis</a>.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_ArgumentOfPeriapsis")]
    public Angle GetArgumentOfPeriapsis()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_get_ArgumentOfPeriapsis", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Argument_of_periapsis">argument of
    /// periapsis</a>.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_ArgumentOfPeriapsis")]
    public async Task<Angle> GetArgumentOfPeriapsisAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_ArgumentOfPeriapsis", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the celestial body (e.g. planet or moon) around which the object is orbiting.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_Body")]
    public CelestialBody GetBody()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<CelestialBody>("SpaceCenter", "Orbit_get_Body", args);
    }

    /// <summary>
    /// Gets the celestial body (e.g. planet or moon) around which the object is orbiting.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_Body")]
    public async Task<CelestialBody> GetBodyAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<CelestialBody>("SpaceCenter", "Orbit_get_Body", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Eccentric_anomaly">eccentric anomaly</a>.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_EccentricAnomaly")]
    public Angle GetEccentricAnomaly()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_get_EccentricAnomaly", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Eccentric_anomaly">eccentric anomaly</a>.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_EccentricAnomaly")]
    public async Task<Angle> GetEccentricAnomalyAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_EccentricAnomaly", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Orbital_eccentricity">eccentricity</a>
    /// of the orbit.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_Eccentricity")]
    public double GetEccentricity()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_Eccentricity", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Orbital_eccentricity">eccentricity</a>
    /// of the orbit.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_Eccentricity")]
    public async Task<double> GetEccentricityAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_Eccentricity", args);
    }

    /// <summary>
    /// Gets the time since the epoch (the point at which the
    /// <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly at epoch</a>
    /// was measured, in seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_Epoch")]
    public double GetEpoch()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_Epoch", args);
    }

    /// <summary>
    /// Gets the time since the epoch (the point at which the
    /// <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly at epoch</a>
    /// was measured, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_Epoch")]
    public async Task<double> GetEpochAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_Epoch", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Orbital_inclination">inclination</a>
    /// of the orbit.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_Inclination")]
    public Angle GetInclination()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_get_Inclination", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Orbital_inclination">inclination</a>
    /// of the orbit.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_Inclination")]
    public async Task<Angle> GetInclinationAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_Inclination", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Longitude_of_the_ascending_node">longitude of
    /// the ascending node</a>.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_LongitudeOfAscendingNode")]
    public Angle GetLongitudeOfAscendingNode()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_get_LongitudeOfAscendingNode", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Longitude_of_the_ascending_node">longitude of
    /// the ascending node</a>.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_LongitudeOfAscendingNode")]
    public async Task<Angle> GetLongitudeOfAscendingNodeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_LongitudeOfAscendingNode", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly</a>.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_MeanAnomaly")]
    public Angle GetMeanAnomaly()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_get_MeanAnomaly", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly</a>.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_MeanAnomaly")]
    public async Task<Angle> GetMeanAnomalyAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_MeanAnomaly", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly at epoch</a>.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_MeanAnomalyAtEpoch")]
    public Angle GetMeanAnomalyAtEpoch()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_get_MeanAnomalyAtEpoch", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly at epoch</a>.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_MeanAnomalyAtEpoch")]
    public async Task<Angle> GetMeanAnomalyAtEpochAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_MeanAnomalyAtEpoch", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// If the object is going to change sphere of influence in the future, returns the new
    /// orbit after the change. Otherwise returns <c>null</c>.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_NextOrbit")]
    public Orbit? GetNextOrbit()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNullable<Orbit>("SpaceCenter", "Orbit_get_NextOrbit", args);
    }

    /// <summary>
    /// If the object is going to change sphere of influence in the future, returns the new
    /// orbit after the change. Otherwise returns <c>null</c>.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_NextOrbit")]
    public async Task<Orbit?> GetNextOrbitAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNullableAsync<Orbit>("SpaceCenter", "Orbit_get_NextOrbit", args);
    }

    /// <summary>
    /// Gets the current orbital speed in meters per second.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_OrbitalSpeed")]
    public double GetOrbitalSpeed()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_OrbitalSpeed", args);
    }

    /// <summary>
    /// Gets the current orbital speed in meters per second.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_OrbitalSpeed")]
    public async Task<double> GetOrbitalSpeedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_OrbitalSpeed", args);
    }

    /// <summary>
    /// Gets the periapsis of the orbit, in meters, from the center of mass
    /// of the body being orbited.
    /// </summary>
    /// <remarks>
    /// For the periapsis altitude reported on the in-game map view,
    /// use <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Orbit.GetPeriapsisAltitude" />.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_Periapsis")]
    public double GetPeriapsis()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_Periapsis", args);
    }

    /// <summary>
    /// Gets the periapsis of the orbit, in meters, from the center of mass
    /// of the body being orbited.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// For the periapsis altitude reported on the in-game map view,
    /// use <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Orbit.GetPeriapsisAltitude" />.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_Periapsis")]
    public async Task<double> GetPeriapsisAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_Periapsis", args);
    }

    /// <summary>
    /// Gets the periapsis of the orbit, in meters, above the sea level of the body being orbited.
    /// </summary>
    /// <remarks>
    /// This is equal to <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Orbit.GetPeriapsis" /> minus the equatorial radius of the body.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_PeriapsisAltitude")]
    public double GetPeriapsisAltitude()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_PeriapsisAltitude", args);
    }

    /// <summary>
    /// Gets the periapsis of the orbit, in meters, above the sea level of the body being orbited.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This is equal to <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Orbit.GetPeriapsis" /> minus the equatorial radius of the body.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_PeriapsisAltitude")]
    public async Task<double> GetPeriapsisAltitudeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_PeriapsisAltitude", args);
    }

    /// <summary>
    /// Gets the orbital period, in seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_Period")]
    public double GetPeriod()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_Period", args);
    }

    /// <summary>
    /// Gets the orbital period, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_Period")]
    public async Task<double> GetPeriodAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_Period", args);
    }

    /// <summary>
    /// Gets the current radius of the orbit, in meters. This is the distance between the center
    /// of mass of the object in orbit, and the center of mass of the body around which it
    /// is orbiting.
    /// </summary>
    /// <remarks>
    /// This value will change over time if the orbit is elliptical.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_Radius")]
    public double GetRadius()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_Radius", args);
    }

    /// <summary>
    /// Gets the current radius of the orbit, in meters. This is the distance between the center
    /// of mass of the object in orbit, and the center of mass of the body around which it
    /// is orbiting.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This value will change over time if the orbit is elliptical.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_Radius")]
    public async Task<double> GetRadiusAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_Radius", args);
    }

    /// <summary>
    /// Gets the semi-major axis of the orbit, in meters.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_SemiMajorAxis")]
    public double GetSemiMajorAxis()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_SemiMajorAxis", args);
    }

    /// <summary>
    /// Gets the semi-major axis of the orbit, in meters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_SemiMajorAxis")]
    public async Task<double> GetSemiMajorAxisAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_SemiMajorAxis", args);
    }

    /// <summary>
    /// Gets the semi-minor axis of the orbit, in meters.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_SemiMinorAxis")]
    public double GetSemiMinorAxis()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_SemiMinorAxis", args);
    }

    /// <summary>
    /// Gets the semi-minor axis of the orbit, in meters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_SemiMinorAxis")]
    public async Task<double> GetSemiMinorAxisAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_SemiMinorAxis", args);
    }

    /// <summary>
    /// Gets the current orbital speed of the object in meters per second.
    /// </summary>
    /// <remarks>
    /// This value will change over time if the orbit is elliptical.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_Speed")]
    public double GetSpeed()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_Speed", args);
    }

    /// <summary>
    /// Gets the current orbital speed of the object in meters per second.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This value will change over time if the orbit is elliptical.
    /// </remarks>
    [GetRpc("SpaceCenter", "Orbit_get_Speed")]
    public async Task<double> GetSpeedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_Speed", args);
    }

    /// <summary>
    /// Gets the time until the object reaches apoapsis, in seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_TimeToApoapsis")]
    public double GetTimeToApoapsis()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_TimeToApoapsis", args);
    }

    /// <summary>
    /// Gets the time until the object reaches apoapsis, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_TimeToApoapsis")]
    public async Task<double> GetTimeToApoapsisAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_TimeToApoapsis", args);
    }

    /// <summary>
    /// Gets the time until the object reaches periapsis, in seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_TimeToPeriapsis")]
    public double GetTimeToPeriapsis()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_TimeToPeriapsis", args);
    }

    /// <summary>
    /// Gets the time until the object reaches periapsis, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_TimeToPeriapsis")]
    public async Task<double> GetTimeToPeriapsisAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_TimeToPeriapsis", args);
    }

    /// <summary>
    /// Gets the time until the object changes sphere of influence, in seconds. Returns <c>NaN</c>
    /// if the object is not going to change sphere of influence.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_TimeToSOIChange")]
    public double GetTimeToSOIChange()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "Orbit_get_TimeToSOIChange", args);
    }

    /// <summary>
    /// Gets the time until the object changes sphere of influence, in seconds. Returns <c>NaN</c>
    /// if the object is not going to change sphere of influence.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Orbit_get_TimeToSOIChange")]
    public async Task<double> GetTimeToSOIChangeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_TimeToSOIChange", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/True_anomaly">true anomaly</a>.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_TrueAnomaly")]
    public Angle GetTrueAnomaly()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "Orbit_get_TrueAnomaly", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/True_anomaly">true anomaly</a>.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "Orbit_get_TrueAnomaly")]
    public async Task<Angle> GetTrueAnomalyAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "Orbit_get_TrueAnomaly", args);
        return Angle.FromRadians(result);
    }
}
