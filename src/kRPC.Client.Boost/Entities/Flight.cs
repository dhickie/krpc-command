using System;
using System.Collections.Generic;
using System.Linq;
using KRPC.Client;
using KRPC.Client.Services.SpaceCenter;
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

    public Tuple<double, double, double> AerodynamicForce
        => Wrapped.AerodynamicForce;

    public float AngleOfAttack
        => Wrapped.AngleOfAttack;

    public Tuple<double, double, double> AntiNormal
        => Wrapped.AntiNormal;

    public Tuple<double, double, double> AntiRadial
        => Wrapped.AntiRadial;

    public float AtmosphereDensity
        => Wrapped.AtmosphereDensity;

    public float BallisticCoefficient
        => Wrapped.BallisticCoefficient;

    public double BedrockAltitude
        => Wrapped.BedrockAltitude;

    public Tuple<double, double, double> CenterOfMass
        => Wrapped.CenterOfMass;

    public Tuple<double, double, double> Direction
        => Wrapped.Direction;

    public Tuple<double, double, double> Drag
        => Wrapped.Drag;

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

    public Tuple<double, double, double> Lift
        => Wrapped.Lift;

    public float LiftCoefficient
        => Wrapped.LiftCoefficient;

    public double Longitude
        => Wrapped.Longitude;

    public float Mach
        => Wrapped.Mach;

    public double MeanAltitude
        => Wrapped.MeanAltitude;

    public Tuple<double, double, double> Normal
        => Wrapped.Normal;

    public float Pitch
        => Wrapped.Pitch;

    public Tuple<double, double, double> Prograde
        => Wrapped.Prograde;

    public Tuple<double, double, double> Radial
        => Wrapped.Radial;

    public Tuple<double, double, double> Retrograde
        => Wrapped.Retrograde;

    public float ReynoldsNumber
        => Wrapped.ReynoldsNumber;

    public float Roll
        => Wrapped.Roll;

    public Tuple<double, double, double, double> Rotation
        => Wrapped.Rotation;

    public float SideslipAngle
        => Wrapped.SideslipAngle;

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

    public Tuple<double, double, double> Velocity
        => Wrapped.Velocity;

    public double VerticalSpeed
        => Wrapped.VerticalSpeed;

    public Tuple<double, double, double> SimulateAerodynamicForceAt(CelestialBody body, Tuple<double, double, double> position, Tuple<double, double, double> velocity)
        => Wrapped.SimulateAerodynamicForceAt(body.Wrapped, position, velocity);
}
