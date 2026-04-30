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
    internal BaseCelestialBody Internal { get; }

    internal CelestialBody(BaseCelestialBody celestialBody)
    {
        Internal = celestialBody;
    }
    public double AtmosphereDepth
        => Internal.AtmosphereDepth;
    public ISet<string> Biomes
        => Internal.Biomes;
    public double EquatorialRadius
        => Internal.EquatorialRadius;
    public float FlyingHighAltitudeThreshold
        => Internal.FlyingHighAltitudeThreshold;
    public double GravitationalParameter
        => Internal.GravitationalParameter;
    public bool HasAtmosphere
        => Internal.HasAtmosphere;
    public bool HasAtmosphericOxygen
        => Internal.HasAtmosphericOxygen;
    public bool HasSolidSurface
        => Internal.HasSolidSurface;
    public double InitialRotation
        => Internal.InitialRotation;
    public bool IsStar
        => Internal.IsStar;
    public double Mass
        => Internal.Mass;
    public string Name
        => Internal.Name;
    public ReferenceFrame NonRotatingReferenceFrame
        => new ReferenceFrame(Internal.NonRotatingReferenceFrame);
    public Orbit Orbit
        => new Orbit(Internal.Orbit);
    public ReferenceFrame OrbitalReferenceFrame
        => new ReferenceFrame(Internal.OrbitalReferenceFrame);
    public ReferenceFrame ReferenceFrame
        => new ReferenceFrame(Internal.ReferenceFrame);
    public double RotationAngle
        => Internal.RotationAngle;
    public double RotationalPeriod
        => Internal.RotationalPeriod;
    public double RotationalSpeed
        => Internal.RotationalSpeed;
    public IList<CelestialBody> Satellites
        => Internal.Satellites.Select(item => new CelestialBody(item)).ToList();
    public float SpaceHighAltitudeThreshold
        => Internal.SpaceHighAltitudeThreshold;
    public double SphereOfInfluence
        => Internal.SphereOfInfluence;
    public double SurfaceGravity
        => Internal.SurfaceGravity;
    public double AltitudeAtPosition(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Internal.AltitudeAtPosition(position, referenceFrame.Internal);
    public Tuple<double, double, double> AngularVelocity(ReferenceFrame referenceFrame)
        => Internal.AngularVelocity(referenceFrame.Internal);
    public double AtmosphericDensityAtPosition(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Internal.AtmosphericDensityAtPosition(position, referenceFrame.Internal);
    public double BedrockHeight(double latitude, double longitude)
        => Internal.BedrockHeight(latitude, longitude);
    public Tuple<double, double, double> BedrockPosition(double latitude, double longitude, ReferenceFrame referenceFrame)
        => Internal.BedrockPosition(latitude, longitude, referenceFrame.Internal);
    public string BiomeAt(double latitude, double longitude)
        => Internal.BiomeAt(latitude, longitude);
    public double DensityAt(double altitude)
        => Internal.DensityAt(altitude);
    public Tuple<double, double, double> Direction(ReferenceFrame referenceFrame)
        => Internal.Direction(referenceFrame.Internal);
    public double LatitudeAtPosition(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Internal.LatitudeAtPosition(position, referenceFrame.Internal);
    public double LongitudeAtPosition(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Internal.LongitudeAtPosition(position, referenceFrame.Internal);
    public Tuple<double, double, double> MSLPosition(double latitude, double longitude, ReferenceFrame referenceFrame)
        => Internal.MSLPosition(latitude, longitude, referenceFrame.Internal);
    public Tuple<double, double, double> Position(ReferenceFrame referenceFrame)
        => Internal.Position(referenceFrame.Internal);
    public Tuple<double, double, double> PositionAtAltitude(double latitude, double longitude, double altitude, ReferenceFrame referenceFrame)
        => Internal.PositionAtAltitude(latitude, longitude, altitude, referenceFrame.Internal);
    public double PressureAt(double altitude)
        => Internal.PressureAt(altitude);
    public Tuple<double, double, double, double> Rotation(ReferenceFrame referenceFrame)
        => Internal.Rotation(referenceFrame.Internal);
    public double SurfaceHeight(double latitude, double longitude)
        => Internal.SurfaceHeight(latitude, longitude);
    public Tuple<double, double, double> SurfacePosition(double latitude, double longitude, ReferenceFrame referenceFrame)
        => Internal.SurfacePosition(latitude, longitude, referenceFrame.Internal);
    public double TemperatureAt(Tuple<double, double, double> position, ReferenceFrame referenceFrame)
        => Internal.TemperatureAt(position, referenceFrame.Internal);
    public Tuple<double, double, double> Velocity(ReferenceFrame referenceFrame)
        => Internal.Velocity(referenceFrame.Internal);
}
