using KRPC.Client;
using kRPC.Client.Boost.Extensions;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using BaseOrbit = kRPC.Client.Boost.Services.SpaceCenter.Orbit;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Orbit object.
/// </summary>
public class Orbit
{
    internal readonly BaseOrbit Wrapped;

    internal Orbit(BaseOrbit orbit)
    {
        Wrapped = orbit;
    }

    public double Apoapsis
        => Wrapped.Apoapsis;

    public double ApoapsisAltitude
        => Wrapped.ApoapsisAltitude;

    public Angle ArgumentOfPeriapsis
        => Angle.FromRadians(Wrapped.ArgumentOfPeriapsis);

    public CelestialBody Body
        => new CelestialBody(Wrapped.Body);

    public Angle EccentricAnomaly
        => Angle.FromRadians(Wrapped.EccentricAnomaly);

    public double Eccentricity
        => Wrapped.Eccentricity;

    public double Epoch
        => Wrapped.Epoch;

    public Angle Inclination
        => Angle.FromRadians(Wrapped.Inclination);

    public Angle LongitudeOfAscendingNode
        => Angle.FromRadians(Wrapped.LongitudeOfAscendingNode);

    public Angle MeanAnomaly
        => Angle.FromRadians(Wrapped.MeanAnomaly);

    public Angle MeanAnomalyAtEpoch
        => Angle.FromRadians(Wrapped.MeanAnomalyAtEpoch);

    public Orbit NextOrbit
        => new Orbit(Wrapped.NextOrbit);

    public double OrbitalSpeed
        => Wrapped.OrbitalSpeed;

    public double Periapsis
        => Wrapped.Periapsis;

    public double PeriapsisAltitude
        => Wrapped.PeriapsisAltitude;

    public double Period
        => Wrapped.Period;

    public double Radius
        => Wrapped.Radius;

    public double SemiMajorAxis
        => Wrapped.SemiMajorAxis;

    public double SemiMinorAxis
        => Wrapped.SemiMinorAxis;

    public double Speed
        => Wrapped.Speed;

    public double TimeToApoapsis
        => Wrapped.TimeToApoapsis;

    public double TimeToPeriapsis
        => Wrapped.TimeToPeriapsis;

    public double TimeToSOIChange
        => Wrapped.TimeToSOIChange;

    public Angle TrueAnomaly
        => Angle.FromRadians(Wrapped.TrueAnomaly);

    public double DistanceAtClosestApproach(Orbit target)
        => Wrapped.DistanceAtClosestApproach(target.Wrapped);

    public Angle EccentricAnomalyAtUT(double ut)
        => Angle.FromRadians(Wrapped.EccentricAnomalyAtUT(ut));

    public IList<IList<double>> ListClosestApproaches(Orbit target, int orbits)
        => Wrapped.ListClosestApproaches(target.Wrapped, orbits);

    public Angle MeanAnomalyAtUT(double ut)
        => Angle.FromRadians(Wrapped.MeanAnomalyAtUT(ut));

    public double OrbitalSpeedAt(double time)
        => Wrapped.OrbitalSpeedAt(time);

    public Vector3D PositionAt(double ut, ReferenceFrame referenceFrame)
        => Wrapped.PositionAt(ut, referenceFrame.Wrapped).ToVector3D();

    public double RadiusAt(double ut)
        => Wrapped.RadiusAt(ut);

    public double RadiusAtTrueAnomaly(double trueAnomaly)
        => Wrapped.RadiusAtTrueAnomaly(trueAnomaly);

    public Angle RelativeInclination(Orbit target)
        => Angle.FromRadians(Wrapped.RelativeInclination(target.Wrapped));

    public double TimeOfClosestApproach(Orbit target)
        => Wrapped.TimeOfClosestApproach(target.Wrapped);

    public Angle TrueAnomalyAtAN(Orbit target)
        => Angle.FromRadians(Wrapped.TrueAnomalyAtAN(target.Wrapped));

    public Angle TrueAnomalyAtDN(Orbit target)
        => Angle.FromRadians(Wrapped.TrueAnomalyAtDN(target.Wrapped));

    public Angle TrueAnomalyAtRadius(double radius)
        => Angle.FromRadians(Wrapped.TrueAnomalyAtRadius(radius));

    public Angle TrueAnomalyAtUT(double ut)
        => Angle.FromRadians(Wrapped.TrueAnomalyAtUT(ut));

    public double UTAtTrueAnomaly(double trueAnomaly)
        => Wrapped.UTAtTrueAnomaly(trueAnomaly);

    public static Vector3D ReferencePlaneDirection(IConnection connection, ReferenceFrame referenceFrame)
        => BaseOrbit.ReferencePlaneDirection(connection, referenceFrame.Wrapped).ToVector3D();

    public static Vector3D ReferencePlaneNormal(IConnection connection, ReferenceFrame referenceFrame)
        => BaseOrbit.ReferencePlaneNormal(connection, referenceFrame.Wrapped).ToVector3D();
}
