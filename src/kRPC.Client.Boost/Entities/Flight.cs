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
    internal BaseFlight Internal { get; }

    internal Flight(BaseFlight flight)
    {
        Internal = flight;
    }
    public Tuple<double, double, double> AerodynamicForce
        => Internal.AerodynamicForce;
    public float AngleOfAttack
        => Internal.AngleOfAttack;
    public Tuple<double, double, double> AntiNormal
        => Internal.AntiNormal;
    public Tuple<double, double, double> AntiRadial
        => Internal.AntiRadial;
    public float AtmosphereDensity
        => Internal.AtmosphereDensity;
    public float BallisticCoefficient
        => Internal.BallisticCoefficient;
    public double BedrockAltitude
        => Internal.BedrockAltitude;
    public Tuple<double, double, double> CenterOfMass
        => Internal.CenterOfMass;
    public Tuple<double, double, double> Direction
        => Internal.Direction;
    public Tuple<double, double, double> Drag
        => Internal.Drag;
    public float DragCoefficient
        => Internal.DragCoefficient;
    public float DynamicPressure
        => Internal.DynamicPressure;
    public double Elevation
        => Internal.Elevation;
    public float EquivalentAirSpeed
        => Internal.EquivalentAirSpeed;
    public float GForce
        => Internal.GForce;
    public float Heading
        => Internal.Heading;
    public double HorizontalSpeed
        => Internal.HorizontalSpeed;
    public double Latitude
        => Internal.Latitude;
    public Tuple<double, double, double> Lift
        => Internal.Lift;
    public float LiftCoefficient
        => Internal.LiftCoefficient;
    public double Longitude
        => Internal.Longitude;
    public float Mach
        => Internal.Mach;
    public double MeanAltitude
        => Internal.MeanAltitude;
    public Tuple<double, double, double> Normal
        => Internal.Normal;
    public float Pitch
        => Internal.Pitch;
    public Tuple<double, double, double> Prograde
        => Internal.Prograde;
    public Tuple<double, double, double> Radial
        => Internal.Radial;
    public Tuple<double, double, double> Retrograde
        => Internal.Retrograde;
    public float ReynoldsNumber
        => Internal.ReynoldsNumber;
    public float Roll
        => Internal.Roll;
    public Tuple<double, double, double, double> Rotation
        => Internal.Rotation;
    public float SideslipAngle
        => Internal.SideslipAngle;
    public double Speed
        => Internal.Speed;
    public float SpeedOfSound
        => Internal.SpeedOfSound;
    public float StallFraction
        => Internal.StallFraction;
    public float StaticAirTemperature
        => Internal.StaticAirTemperature;
    public float StaticPressure
        => Internal.StaticPressure;
    public float StaticPressureAtMSL
        => Internal.StaticPressureAtMSL;
    public double SurfaceAltitude
        => Internal.SurfaceAltitude;
    public float TerminalVelocity
        => Internal.TerminalVelocity;
    public float ThrustSpecificFuelConsumption
        => Internal.ThrustSpecificFuelConsumption;
    public float TotalAirTemperature
        => Internal.TotalAirTemperature;
    public float TrueAirSpeed
        => Internal.TrueAirSpeed;
    public Tuple<double, double, double> Velocity
        => Internal.Velocity;
    public double VerticalSpeed
        => Internal.VerticalSpeed;
    public Tuple<double, double, double> SimulateAerodynamicForceAt(CelestialBody body, Tuple<double, double, double> position, Tuple<double, double, double> velocity)
        => Internal.SimulateAerodynamicForceAt(body.Internal, position, velocity);
}
