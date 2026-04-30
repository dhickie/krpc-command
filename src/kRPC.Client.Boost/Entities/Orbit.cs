using KRPC.Client;
using kRPC.Client.Boost.Extensions;
using MathNet.Spatial.Euclidean;
using BaseOrbit = KRPC.Client.Services.SpaceCenter.Orbit;

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

    public double ArgumentOfPeriapsis
        => Wrapped.ArgumentOfPeriapsis;

    public CelestialBody Body
        => new CelestialBody(Wrapped.Body);

    public double EccentricAnomaly
        => Wrapped.EccentricAnomaly;

    public double Eccentricity
        => Wrapped.Eccentricity;

    public double Epoch
        => Wrapped.Epoch;

    public double Inclination
        => Wrapped.Inclination;

    public double LongitudeOfAscendingNode
        => Wrapped.LongitudeOfAscendingNode;

    public double MeanAnomaly
        => Wrapped.MeanAnomaly;

    public double MeanAnomalyAtEpoch
        => Wrapped.MeanAnomalyAtEpoch;

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

    public double TrueAnomaly
        => Wrapped.TrueAnomaly;

    public double DistanceAtClosestApproach(Orbit target)
        => Wrapped.DistanceAtClosestApproach(target.Wrapped);

    public double EccentricAnomalyAtUT(double ut)
        => Wrapped.EccentricAnomalyAtUT(ut);

    public IList<IList<double>> ListClosestApproaches(Orbit target, int orbits)
        => Wrapped.ListClosestApproaches(target.Wrapped, orbits);

    public double MeanAnomalyAtUT(double ut)
        => Wrapped.MeanAnomalyAtUT(ut);

    public double OrbitalSpeedAt(double time)
        => Wrapped.OrbitalSpeedAt(time);

    public Vector3D PositionAt(double ut, ReferenceFrame referenceFrame)
        => Wrapped.PositionAt(ut, referenceFrame.Wrapped).ToVector3D();

    public double RadiusAt(double ut)
        => Wrapped.RadiusAt(ut);

    public double RadiusAtTrueAnomaly(double trueAnomaly)
        => Wrapped.RadiusAtTrueAnomaly(trueAnomaly);

    public double RelativeInclination(Orbit target)
        => Wrapped.RelativeInclination(target.Wrapped);

    public double TimeOfClosestApproach(Orbit target)
        => Wrapped.TimeOfClosestApproach(target.Wrapped);

    public double TrueAnomalyAtAN(Orbit target)
        => Wrapped.TrueAnomalyAtAN(target.Wrapped);

    public double TrueAnomalyAtDN(Orbit target)
        => Wrapped.TrueAnomalyAtDN(target.Wrapped);

    public double TrueAnomalyAtRadius(double radius)
        => Wrapped.TrueAnomalyAtRadius(radius);

    public double TrueAnomalyAtUT(double ut)
        => Wrapped.TrueAnomalyAtUT(ut);

    public double UTAtTrueAnomaly(double trueAnomaly)
        => Wrapped.UTAtTrueAnomaly(trueAnomaly);

    public static Vector3D ReferencePlaneDirection(IConnection connection, ReferenceFrame referenceFrame)
        => BaseOrbit.ReferencePlaneDirection(connection, referenceFrame.Wrapped).ToVector3D();

    public static Vector3D ReferencePlaneNormal(IConnection connection, ReferenceFrame referenceFrame)
        => BaseOrbit.ReferencePlaneNormal(connection, referenceFrame.Wrapped).ToVector3D();
}
