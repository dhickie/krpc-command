using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using KRPC.Client;
using System;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Describes an orbit. For example, the orbit of a vessel, obtained by calling
/// <see cref="M:SpaceCenter.Vessel.Orbit" />, or a celestial body, obtained by calling
/// <see cref="M:SpaceCenter.CelestialBody.Orbit" />.
/// </summary>
public class Orbit : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Orbit (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Estimates and returns the distance at closest approach to a target orbit, in meters.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [Rpc ("SpaceCenter", "Orbit_DistanceAtClosestApproach")]
    public double DistanceAtClosestApproach (Orbit target)
    {
        var args = new object[] {
            this,
            target
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_DistanceAtClosestApproach", args);
    }

    /// <summary>
    /// The eccentric anomaly at the given universal time.
    /// </summary>
    /// <param name="ut">The universal time, in seconds.</param>
    [Rpc ("SpaceCenter", "Orbit_EccentricAnomalyAtUT")]
    public double EccentricAnomalyAtUT (double ut)
    {
        var args = new object[] {
            this,
            ut
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_EccentricAnomalyAtUT", args);
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
    [Rpc ("SpaceCenter", "Orbit_ListClosestApproaches")]
    public IList<IList<double>> ListClosestApproaches (Orbit target, int orbits)
    {
        var args = new object[] {
            this,
            target,
            orbits
        };
        return Connection.Invoke<IList<IList<double>>> ("SpaceCenter", "Orbit_ListClosestApproaches", args);
    }

    /// <summary>
    /// The mean anomaly at the given time.
    /// </summary>
    /// <param name="ut">The universal time in seconds.</param>
    [Rpc ("SpaceCenter", "Orbit_MeanAnomalyAtUT")]
    public double MeanAnomalyAtUT (double ut)
    {
        var args = new object[] {
            this,
            ut
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_MeanAnomalyAtUT", args);
    }

    /// <summary>
    /// The orbital speed at the given time, in meters per second.
    /// </summary>
    /// <param name="time">Time from now, in seconds.</param>
    [Rpc ("SpaceCenter", "Orbit_OrbitalSpeedAt")]
    public double OrbitalSpeedAt (double time)
    {
        var args = new object[] {
            this,
            time
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_OrbitalSpeedAt", args);
    }

    /// <summary>
    /// The position at a given time, in the specified reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="ut">The universal time to measure the position at.</param>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [Rpc ("SpaceCenter", "Orbit_PositionAt")]
    public Tuple<double,double,double> PositionAt (double ut, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            ut,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Orbit_PositionAt", args);
    }

    /// <summary>
    /// The orbital radius at the given time, in meters.
    /// </summary>
    /// <param name="ut">The universal time to measure the radius at.</param>
    [Rpc ("SpaceCenter", "Orbit_RadiusAt")]
    public double RadiusAt (double ut)
    {
        var args = new object[] {
            this,
            ut
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_RadiusAt", args);
    }

    /// <summary>
    /// The orbital radius at the point in the orbit given by the true anomaly.
    /// </summary>
    /// <param name="trueAnomaly">The true anomaly.</param>
    [Rpc ("SpaceCenter", "Orbit_RadiusAtTrueAnomaly")]
    public double RadiusAtTrueAnomaly (double trueAnomaly)
    {
        var args = new object[] {
            this,
            trueAnomaly
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_RadiusAtTrueAnomaly", args);
    }

    /// <summary>
    /// Relative inclination of this orbit and the target orbit, in radians.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [Rpc ("SpaceCenter", "Orbit_RelativeInclination")]
    public double RelativeInclination (Orbit target)
    {
        var args = new object[] {
            this,
            target
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_RelativeInclination", args);
    }

    /// <summary>
    /// Estimates and returns the time at closest approach to a target orbit.
    /// </summary>
    /// <returns>The universal time at closest approach, in seconds.</returns>
    /// <param name="target">Target orbit.</param>
    [Rpc ("SpaceCenter", "Orbit_TimeOfClosestApproach")]
    public double TimeOfClosestApproach (Orbit target)
    {
        var args = new object[] {
            this,
            target
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_TimeOfClosestApproach", args);
    }

    /// <summary>
    /// The true anomaly of the ascending node with the given target orbit.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [Rpc ("SpaceCenter", "Orbit_TrueAnomalyAtAN")]
    public double TrueAnomalyAtAN (Orbit target)
    {
        var args = new object[] {
            this,
            target
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_TrueAnomalyAtAN", args);
    }

    /// <summary>
    /// The true anomaly of the descending node with the given target orbit.
    /// </summary>
    /// <param name="target">Target orbit.</param>
    [Rpc ("SpaceCenter", "Orbit_TrueAnomalyAtDN")]
    public double TrueAnomalyAtDN (Orbit target)
    {
        var args = new object[] {
            this,
            target
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_TrueAnomalyAtDN", args);
    }

    /// <summary>
    /// The true anomaly at the given orbital radius.
    /// </summary>
    /// <param name="radius">The orbital radius in meters.</param>
    [Rpc ("SpaceCenter", "Orbit_TrueAnomalyAtRadius")]
    public double TrueAnomalyAtRadius (double radius)
    {
        var args = new object[] {
            this,
            radius
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_TrueAnomalyAtRadius", args);
    }

    /// <summary>
    /// The true anomaly at the given time.
    /// </summary>
    /// <param name="ut">The universal time in seconds.</param>
    [Rpc ("SpaceCenter", "Orbit_TrueAnomalyAtUT")]
    public double TrueAnomalyAtUT (double ut)
    {
        var args = new object[] {
            this,
            ut
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_TrueAnomalyAtUT", args);
    }

    /// <summary>
    /// The universal time, in seconds, corresponding to the given true anomaly.
    /// </summary>
    /// <param name="trueAnomaly">True anomaly.</param>
    [Rpc ("SpaceCenter", "Orbit_UTAtTrueAnomaly")]
    public double UTAtTrueAnomaly (double trueAnomaly)
    {
        var args = new object[] {
            this,
            trueAnomaly
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_UTAtTrueAnomaly", args);
    }

    /// <summary>
    /// The direction from which the orbits longitude of ascending node is measured,
    /// in the given reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    /// <param name="connection">A connection object.</param>
    [Rpc ("SpaceCenter", "Orbit_static_ReferencePlaneDirection")]
    public static Tuple<double,double,double> ReferencePlaneDirection (ConnectionMultiplexer connection, ReferenceFrame referenceFrame)
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            referenceFrame
        };
        return connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Orbit_static_ReferencePlaneDirection", args);
    }

    /// <summary>
    /// The direction that is normal to the orbits reference plane,
    /// in the given reference frame.
    /// The reference plane is the plane from which the orbits inclination is measured.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    /// <param name="connection">A connection object.</param>
    [Rpc ("SpaceCenter", "Orbit_static_ReferencePlaneNormal")]
    public static Tuple<double,double,double> ReferencePlaneNormal (ConnectionMultiplexer connection, ReferenceFrame referenceFrame)
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var args = new object[] {
            referenceFrame
        };
        return connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Orbit_static_ReferencePlaneNormal", args);
    }

    /// <summary>
    /// Gets the apoapsis of the orbit, in meters, from the center of mass
    /// of the body being orbited.
    /// </summary>
    /// <remarks>
    /// For the apoapsis altitude reported on the in-game map view,
    /// use <see cref="M:SpaceCenter.Orbit.ApoapsisAltitude" />.
    /// </remarks>
    [Rpc ("SpaceCenter", "Orbit_get_Apoapsis")]
    public double GetApoapsis ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_Apoapsis", args);
    }

    /// <summary>
    /// The apoapsis of the orbit, in meters, above the sea level of the body being orbited.
    /// </summary>
    /// <remarks>
    /// This is equal to <see cref="M:SpaceCenter.Orbit.Apoapsis" /> minus the equatorial radius of the body.
    /// </remarks>
    [Rpc ("SpaceCenter", "Orbit_get_ApoapsisAltitude")]
    public double GetApoapsisAltitude ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_ApoapsisAltitude", args);
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Argument_of_periapsis">argument of
    /// periapsis</a>, in radians.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_ArgumentOfPeriapsis")]
    public double GetArgumentOfPeriapsis ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_ArgumentOfPeriapsis", args);
    }

    /// <summary>
    /// The celestial body (e.g. planet or moon) around which the object is orbiting.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_Body")]
    public CelestialBody GetBody ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<CelestialBody> ("SpaceCenter", "Orbit_get_Body", args);
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Eccentric_anomaly">eccentric anomaly</a>.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_EccentricAnomaly")]
    public double GetEccentricAnomaly ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_EccentricAnomaly", args);
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Orbital_eccentricity">eccentricity</a>
    /// of the orbit.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_Eccentricity")]
    public double GetEccentricity ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_Eccentricity", args);
    }

    /// <summary>
    /// The time since the epoch (the point at which the
    /// <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly at epoch</a>
    /// was measured, in seconds.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_Epoch")]
    public double GetEpoch ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_Epoch", args);
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Orbital_inclination">inclination</a>
    /// of the orbit,
    /// in radians.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_Inclination")]
    public double GetInclination ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_Inclination", args);
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Longitude_of_the_ascending_node">longitude of
    /// the ascending node</a>, in radians.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_LongitudeOfAscendingNode")]
    public double GetLongitudeOfAscendingNode ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_LongitudeOfAscendingNode", args);
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly</a>.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_MeanAnomaly")]
    public double GetMeanAnomaly ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_MeanAnomaly", args);
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Mean_anomaly">mean anomaly at epoch</a>.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_MeanAnomalyAtEpoch")]
    public double GetMeanAnomalyAtEpoch ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_MeanAnomalyAtEpoch", args);
    }

    /// <summary>
    /// If the object is going to change sphere of influence in the future, returns the new
    /// orbit after the change. Otherwise returns <c>null</c>.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_NextOrbit")]
    public Orbit GetNextOrbit ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Orbit> ("SpaceCenter", "Orbit_get_NextOrbit", args);
    }

    /// <summary>
    /// The current orbital speed in meters per second.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_OrbitalSpeed")]
    public double GetOrbitalSpeed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_OrbitalSpeed", args);
    }

    /// <summary>
    /// The periapsis of the orbit, in meters, from the center of mass
    /// of the body being orbited.
    /// </summary>
    /// <remarks>
    /// For the periapsis altitude reported on the in-game map view,
    /// use <see cref="M:SpaceCenter.Orbit.PeriapsisAltitude" />.
    /// </remarks>
    [Rpc ("SpaceCenter", "Orbit_get_Periapsis")]
    public double GetPeriapsis ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_Periapsis", args);
    }

    /// <summary>
    /// The periapsis of the orbit, in meters, above the sea level of the body being orbited.
    /// </summary>
    /// <remarks>
    /// This is equal to <see cref="M:SpaceCenter.Orbit.Periapsis" /> minus the equatorial radius of the body.
    /// </remarks>
    [Rpc ("SpaceCenter", "Orbit_get_PeriapsisAltitude")]
    public double GetPeriapsisAltitude ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_PeriapsisAltitude", args);
    }

    /// <summary>
    /// The orbital period, in seconds.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_Period")]
    public double GetPeriod ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_Period", args);
    }

    /// <summary>
    /// The current radius of the orbit, in meters. This is the distance between the center
    /// of mass of the object in orbit, and the center of mass of the body around which it
    /// is orbiting.
    /// </summary>
    /// <remarks>
    /// This value will change over time if the orbit is elliptical.
    /// </remarks>
    [Rpc ("SpaceCenter", "Orbit_get_Radius")]
    public double GetRadius ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_Radius", args);
    }

    /// <summary>
    /// The semi-major axis of the orbit, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_SemiMajorAxis")]
    public double GetSemiMajorAxis ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_SemiMajorAxis", args);
    }

    /// <summary>
    /// The semi-minor axis of the orbit, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_SemiMinorAxis")]
    public double GetSemiMinorAxis ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_SemiMinorAxis", args);
    }

    /// <summary>
    /// The current orbital speed of the object in meters per second.
    /// </summary>
    /// <remarks>
    /// This value will change over time if the orbit is elliptical.
    /// </remarks>
    [Rpc ("SpaceCenter", "Orbit_get_Speed")]
    public double GetSpeed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_Speed", args);
    }

    /// <summary>
    /// The time until the object reaches apoapsis, in seconds.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_TimeToApoapsis")]
    public double GetTimeToApoapsis ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_TimeToApoapsis", args);
    }

    /// <summary>
    /// The time until the object reaches periapsis, in seconds.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_TimeToPeriapsis")]
    public double GetTimeToPeriapsis ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_TimeToPeriapsis", args);
    }

    /// <summary>
    /// The time until the object changes sphere of influence, in seconds. Returns <c>NaN</c>
    /// if the object is not going to change sphere of influence.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_TimeToSOIChange")]
    public double GetTimeToSOIChange ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_TimeToSOIChange", args);
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/True_anomaly">true anomaly</a>.
    /// </summary>
    [Rpc ("SpaceCenter", "Orbit_get_TrueAnomaly")]
    public double GetTrueAnomaly ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Orbit_get_TrueAnomaly", args);
    }
}
