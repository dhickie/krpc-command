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
    internal BaseOrbit Internal { get; }

    internal Orbit(BaseOrbit orbit)
    {
        Internal = orbit;
    }
    public double Apoapsis
        => Internal.Apoapsis;
    public double ApoapsisAltitude
        => Internal.ApoapsisAltitude;
    public double ArgumentOfPeriapsis
        => Internal.ArgumentOfPeriapsis;
    public CelestialBody Body
        => new CelestialBody(Internal.Body);
    public double EccentricAnomaly
        => Internal.EccentricAnomaly;
    public double Eccentricity
        => Internal.Eccentricity;
    public double Epoch
        => Internal.Epoch;
    public double Inclination
        => Internal.Inclination;
    public double LongitudeOfAscendingNode
        => Internal.LongitudeOfAscendingNode;
    public double MeanAnomaly
        => Internal.MeanAnomaly;
    public double MeanAnomalyAtEpoch
        => Internal.MeanAnomalyAtEpoch;
    public Orbit NextOrbit
        => new Orbit(Internal.NextOrbit);
    public double OrbitalSpeed
        => Internal.OrbitalSpeed;
    public double Periapsis
        => Internal.Periapsis;
    public double PeriapsisAltitude
        => Internal.PeriapsisAltitude;
    public double Period
        => Internal.Period;
    public double Radius
        => Internal.Radius;
    public double SemiMajorAxis
        => Internal.SemiMajorAxis;
    public double SemiMinorAxis
        => Internal.SemiMinorAxis;
    public double Speed
        => Internal.Speed;
    public double TimeToApoapsis
        => Internal.TimeToApoapsis;
    public double TimeToPeriapsis
        => Internal.TimeToPeriapsis;
    public double TimeToSOIChange
        => Internal.TimeToSOIChange;
    public double TrueAnomaly
        => Internal.TrueAnomaly;
    public double DistanceAtClosestApproach(Orbit target)
        => Internal.DistanceAtClosestApproach(target.Internal);
    public double EccentricAnomalyAtUT(double ut)
        => Internal.EccentricAnomalyAtUT(ut);
    public IList<IList<double>> ListClosestApproaches(Orbit target, int orbits)
        => Internal.ListClosestApproaches(target.Internal, orbits);
    public double MeanAnomalyAtUT(double ut)
        => Internal.MeanAnomalyAtUT(ut);
    public double OrbitalSpeedAt(double time)
        => Internal.OrbitalSpeedAt(time);
    public Tuple<double, double, double> PositionAt(double ut, ReferenceFrame referenceFrame)
        => Internal.PositionAt(ut, referenceFrame.Internal);
    public double RadiusAt(double ut)
        => Internal.RadiusAt(ut);
    public double RadiusAtTrueAnomaly(double trueAnomaly)
        => Internal.RadiusAtTrueAnomaly(trueAnomaly);
    public double RelativeInclination(Orbit target)
        => Internal.RelativeInclination(target.Internal);
    public double TimeOfClosestApproach(Orbit target)
        => Internal.TimeOfClosestApproach(target.Internal);
    public double TrueAnomalyAtAN(Orbit target)
        => Internal.TrueAnomalyAtAN(target.Internal);
    public double TrueAnomalyAtDN(Orbit target)
        => Internal.TrueAnomalyAtDN(target.Internal);
    public double TrueAnomalyAtRadius(double radius)
        => Internal.TrueAnomalyAtRadius(radius);
    public double TrueAnomalyAtUT(double ut)
        => Internal.TrueAnomalyAtUT(ut);
    public double UTAtTrueAnomaly(double trueAnomaly)
        => Internal.UTAtTrueAnomaly(trueAnomaly);
    public static Tuple<double, double, double> ReferencePlaneDirection(IConnection connection, ReferenceFrame referenceFrame)
        => BaseOrbit.ReferencePlaneDirection(connection, referenceFrame.Internal);
    public static Tuple<double, double, double> ReferencePlaneNormal(IConnection connection, ReferenceFrame referenceFrame)
        => BaseOrbit.ReferencePlaneNormal(connection, referenceFrame.Internal);
}
