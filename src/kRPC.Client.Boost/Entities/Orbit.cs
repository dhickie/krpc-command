using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
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

    public Tuple<double, double, double> PositionAt(double ut, ReferenceFrame referenceFrame)
        => Wrapped.PositionAt(ut, referenceFrame.Wrapped);

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

    public static Tuple<double, double, double> ReferencePlaneDirection(IConnection connection, ReferenceFrame referenceFrame)
        => BaseOrbit.ReferencePlaneDirection(connection, referenceFrame.Wrapped);

    public static Tuple<double, double, double> ReferencePlaneNormal(IConnection connection, ReferenceFrame referenceFrame)
        => BaseOrbit.ReferencePlaneNormal(connection, referenceFrame.Wrapped);
}
