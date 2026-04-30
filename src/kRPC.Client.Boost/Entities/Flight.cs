using kRPC.Client.Boost.Extensions;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using BaseFlight = KRPC.Client.Services.SpaceCenter.Flight;

namespace kRPC.Client.Boost.Entities;

/// <summary>
/// Wraps a kRPC SpaceCenter Flight object.
/// </summary>
public class Flight
{
    internal readonly BaseFlight Wrapped;

    internal Flight(BaseFlight flight)
    {
        Wrapped = flight;
    }

    public Vector3D AerodynamicForce
        => Wrapped.AerodynamicForce.ToVector3D();

    public Angle AngleOfAttack
        => Angle.FromDegrees(Wrapped.AngleOfAttack);

    public Vector3D AntiNormal
        => Wrapped.AntiNormal.ToVector3D();

    public Vector3D AntiRadial
        => Wrapped.AntiRadial.ToVector3D();

    public float AtmosphereDensity
        => Wrapped.AtmosphereDensity;

    public float BallisticCoefficient
        => Wrapped.BallisticCoefficient;

    public double BedrockAltitude
        => Wrapped.BedrockAltitude;

    public Vector3D CenterOfMass
        => Wrapped.CenterOfMass.ToVector3D();

    public Vector3D Direction
        => Wrapped.Direction.ToVector3D();

    public Vector3D Drag
        => Wrapped.Drag.ToVector3D();

    public float DragCoefficient
        => Wrapped.DragCoefficient;

    public float DynamicPressure
        => Wrapped.DynamicPressure;

    public double Elevation
        => Wrapped.Elevation;

    public float EquivalentAirSpeed
        => Wrapped.EquivalentAirSpeed;

    public float GForce
        => Wrapped.GForce;

    public float Heading
        => Wrapped.Heading;

    public double HorizontalSpeed
        => Wrapped.HorizontalSpeed;

    public double Latitude
        => Wrapped.Latitude;

    public Vector3D Lift
        => Wrapped.Lift.ToVector3D();

    public float LiftCoefficient
        => Wrapped.LiftCoefficient;

    public double Longitude
        => Wrapped.Longitude;

    public float Mach
        => Wrapped.Mach;

    public double MeanAltitude
        => Wrapped.MeanAltitude;

    public Vector3D Normal
        => Wrapped.Normal.ToVector3D();

    public Angle Pitch
        => Angle.FromDegrees(Wrapped.Pitch);

    public Vector3D Prograde
        => Wrapped.Prograde.ToVector3D();

    public Vector3D Radial
        => Wrapped.Radial.ToVector3D();

    public Vector3D Retrograde
        => Wrapped.Retrograde.ToVector3D();

    public float ReynoldsNumber
        => Wrapped.ReynoldsNumber;

    public Angle Roll
        => Angle.FromDegrees(Wrapped.Roll);

    public Quaternion Rotation
        => Wrapped.Rotation.ToQuaternion();

    public Angle SideslipAngle
        => Angle.FromDegrees(Wrapped.SideslipAngle);

    public double Speed
        => Wrapped.Speed;

    public float SpeedOfSound
        => Wrapped.SpeedOfSound;

    public float StallFraction
        => Wrapped.StallFraction;

    public float StaticAirTemperature
        => Wrapped.StaticAirTemperature;

    public float StaticPressure
        => Wrapped.StaticPressure;

    public float StaticPressureAtMSL
        => Wrapped.StaticPressureAtMSL;

    public double SurfaceAltitude
        => Wrapped.SurfaceAltitude;

    public float TerminalVelocity
        => Wrapped.TerminalVelocity;

    public float ThrustSpecificFuelConsumption
        => Wrapped.ThrustSpecificFuelConsumption;

    public float TotalAirTemperature
        => Wrapped.TotalAirTemperature;

    public float TrueAirSpeed
        => Wrapped.TrueAirSpeed;

    public Vector3D Velocity
        => Wrapped.Velocity.ToVector3D();

    public double VerticalSpeed
        => Wrapped.VerticalSpeed;

    public Vector3D SimulateAerodynamicForceAt(CelestialBody body, Vector3D position, Vector3D velocity)
        => Wrapped.SimulateAerodynamicForceAt(body.Wrapped, position.ToTuple(), velocity.ToTuple()).ToVector3D();
}
