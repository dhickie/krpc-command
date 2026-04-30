using kRPC.Client.Boost.Extensions;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
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

    public Angle RotationAngle
        => Angle.FromRadians(Wrapped.RotationAngle);

    public double RotationalPeriod
        => Wrapped.RotationalPeriod;

    public Angle RotationalSpeed
        => Angle.FromRadians(Wrapped.RotationalSpeed);

    public IList<CelestialBody> Satellites
        => Wrapped.Satellites.Select(item => new CelestialBody(item)).ToList();

    public float SpaceHighAltitudeThreshold
        => Wrapped.SpaceHighAltitudeThreshold;

    public double SphereOfInfluence
        => Wrapped.SphereOfInfluence;

    public double SurfaceGravity
        => Wrapped.SurfaceGravity;

    public double AltitudeAtPosition(Vector3D position, ReferenceFrame referenceFrame)
        => Wrapped.AltitudeAtPosition(position.ToTuple(), referenceFrame.Wrapped);

    public Vector3D AngularVelocity(ReferenceFrame referenceFrame)
        => Wrapped.AngularVelocity(referenceFrame.Wrapped).ToVector3D();

    public double AtmosphericDensityAtPosition(Vector3D position, ReferenceFrame referenceFrame)
        => Wrapped.AtmosphericDensityAtPosition(position.ToTuple(), referenceFrame.Wrapped);

    public double BedrockHeight(double latitude, double longitude)
        => Wrapped.BedrockHeight(latitude, longitude);

    public Vector3D BedrockPosition(double latitude, double longitude, ReferenceFrame referenceFrame)
        => Wrapped.BedrockPosition(latitude, longitude, referenceFrame.Wrapped).ToVector3D();

    public string BiomeAt(double latitude, double longitude)
        => Wrapped.BiomeAt(latitude, longitude);

    public double DensityAt(double altitude)
        => Wrapped.DensityAt(altitude);

    public Vector3D Direction(ReferenceFrame referenceFrame)
        => Wrapped.Direction(referenceFrame.Wrapped).ToVector3D();

    public double LatitudeAtPosition(Vector3D position, ReferenceFrame referenceFrame)
        => Wrapped.LatitudeAtPosition(position.ToTuple(), referenceFrame.Wrapped);

    public double LongitudeAtPosition(Vector3D position, ReferenceFrame referenceFrame)
        => Wrapped.LongitudeAtPosition(position.ToTuple(), referenceFrame.Wrapped);

    public Vector3D MSLPosition(double latitude, double longitude, ReferenceFrame referenceFrame)
        => Wrapped.MSLPosition(latitude, longitude, referenceFrame.Wrapped).ToVector3D();

    public Vector3D Position(ReferenceFrame referenceFrame)
        => Wrapped.Position(referenceFrame.Wrapped).ToVector3D();

    public Vector3D PositionAtAltitude(double latitude, double longitude, double altitude, ReferenceFrame referenceFrame)
        => Wrapped.PositionAtAltitude(latitude, longitude, altitude, referenceFrame.Wrapped).ToVector3D();

    public double PressureAt(double altitude)
        => Wrapped.PressureAt(altitude);

    public Quaternion Rotation(ReferenceFrame referenceFrame)
        => Wrapped.Rotation(referenceFrame.Wrapped).ToQuaternion();

    public double SurfaceHeight(double latitude, double longitude)
        => Wrapped.SurfaceHeight(latitude, longitude);

    public Vector3D SurfacePosition(double latitude, double longitude, ReferenceFrame referenceFrame)
        => Wrapped.SurfacePosition(latitude, longitude, referenceFrame.Wrapped).ToVector3D();

    public double TemperatureAt(Vector3D position, ReferenceFrame referenceFrame)
        => Wrapped.TemperatureAt(position.ToTuple(), referenceFrame.Wrapped);

    public Vector3D Velocity(ReferenceFrame referenceFrame)
        => Wrapped.Velocity(referenceFrame.Wrapped).ToVector3D();
}
