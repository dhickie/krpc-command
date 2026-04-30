using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
using BaseCelestialBody = KRPC.Client.Services.SpaceCenter.CelestialBody;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter CelestialBody object.
/// </summary>
public class CelestialBody
{
    internal readonly BaseCelestialBody Wrapped;

    internal CelestialBody(BaseCelestialBody celestialBody)
    {
        Wrapped = celestialBody;
    }

    public double AtmosphereDepth
        => Wrapped.AtmosphereDepth;

    public ISet<string> Biomes
        => Wrapped.Biomes;

    public double EquatorialRadius
        => Wrapped.EquatorialRadius;

    public float FlyingHighAltitudeThreshold
        => Wrapped.FlyingHighAltitudeThreshold;

    public double GravitationalParameter
        => Wrapped.GravitationalParameter;

    public bool HasAtmosphere
        => Wrapped.HasAtmosphere;

    public bool HasAtmosphericOxygen
        => Wrapped.HasAtmosphericOxygen;

    public bool HasSolidSurface
        => Wrapped.HasSolidSurface;

    public double InitialRotation
        => Wrapped.InitialRotation;

    public bool IsStar
        => Wrapped.IsStar;

    public double Mass
        => Wrapped.Mass;

    public string Name
        => Wrapped.Name;

    public ReferenceFrame NonRotatingReferenceFrame
        => new ReferenceFrame(Wrapped.NonRotatingReferenceFrame);

    public Orbit Orbit
        => new Orbit(Wrapped.Orbit);

    public ReferenceFrame OrbitalReferenceFrame
        => new ReferenceFrame(Wrapped.OrbitalReferenceFrame);

    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Wrapped.ReferenceFrame);

    public double RotationAngle
        => Wrapped.RotationAngle;

    public double RotationalPeriod
        => Wrapped.RotationalPeriod;

    public double RotationalSpeed
        => Wrapped.RotationalSpeed;

    public IList<CelestialBody> Satellites
        => Wrapped.Satellites.Select(item => new CelestialBody(item)).ToList();

    public float SpaceHighAltitudeThreshold
        => Wrapped.SpaceHighAltitudeThreshold;

    public double SphereOfInfluence
        => Wrapped.SphereOfInfluence;

    public double SurfaceGravity
        => Wrapped.SurfaceGravity;

    public double AltitudeAtPosition(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Wrapped.AltitudeAtPosition(position, referenceFrame.Wrapped);

    public Tuple<double, double, double> AngularVelocity(ReferenceFrame referenceFrame)
        => Wrapped.AngularVelocity(referenceFrame.Wrapped);

    public double AtmosphericDensityAtPosition(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Wrapped.AtmosphericDensityAtPosition(position, referenceFrame.Wrapped);

    public double BedrockHeight(double latitude, double longitude)
        => Wrapped.BedrockHeight(latitude, longitude);

    public Tuple<double, double, double> BedrockPosition(double latitude, double longitude,
        ReferenceFrame referenceFrame)
        => Wrapped.BedrockPosition(latitude, longitude, referenceFrame.Wrapped);

    public string BiomeAt(double latitude, double longitude)
        => Wrapped.BiomeAt(latitude, longitude);

    public double DensityAt(double altitude)
        => Wrapped.DensityAt(altitude);

    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Wrapped.Direction(referenceFrame.Wrapped);

    public double LatitudeAtPosition(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Wrapped.LatitudeAtPosition(position, referenceFrame.Wrapped);

    public double LongitudeAtPosition(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Wrapped.LongitudeAtPosition(position, referenceFrame.Wrapped);

    public Tuple<double, double, double> MSLPosition(double latitude, double longitude, ReferenceFrame referenceFrame)
        => Wrapped.MSLPosition(latitude, longitude, referenceFrame.Wrapped);

    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Wrapped.Position(referenceFrame.Wrapped);

    public Tuple<double, double, double> PositionAtAltitude(double latitude, double longitude, double altitude, ReferenceFrame referenceFrame)
        => Wrapped.PositionAtAltitude(latitude, longitude, altitude, referenceFrame.Wrapped);

    public double PressureAt(double altitude)
        => Wrapped.PressureAt(altitude);

    public Tuple<double, double, double, double> Rotation(ReferenceFrame referenceFrame)
        => Wrapped.Rotation(referenceFrame.Wrapped);

    public double SurfaceHeight(double latitude, double longitude)
        => Wrapped.SurfaceHeight(latitude, longitude);

    public Tuple<double, double, double> SurfacePosition(double latitude, double longitude, ReferenceFrame referenceFrame)
        => Wrapped.SurfacePosition(latitude, longitude, referenceFrame.Wrapped);

    public double TemperatureAt(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Wrapped.TemperatureAt(position, referenceFrame.Wrapped);

    public Tuple<double, double, double> Velocity(ReferenceFrame referenceFrame)
        => Wrapped.Velocity(referenceFrame.Wrapped);
}
