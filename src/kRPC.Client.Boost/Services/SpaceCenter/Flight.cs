using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Used to get flight telemetry for a vessel, by calling <see cref="M:SpaceCenter.Vessel.Flight" />.
/// All of the information returned by this class is given in the reference frame
/// passed to that method.
/// Obtained by calling <see cref="M:SpaceCenter.Vessel.Flight" />.
/// </summary>
/// <remarks>
/// To get orbital information, such as the apoapsis or inclination, see <see cref="T:SpaceCenter.Orbit" />.
/// </remarks>
public class Flight : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Flight (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Simulate and return the total aerodynamic forces acting on the vessel,
    /// if it where to be traveling with the given velocity at the given position in the
    /// atmosphere of the given celestial body.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [Rpc ("SpaceCenter", "Flight_SimulateAerodynamicForceAt")]
    public Tuple<double,double,double> SimulateAerodynamicForceAt (CelestialBody body, Tuple<double,double,double> position, Tuple<double,double,double> velocity)
    {
        var args = new object[] {
            this,
            body,
            position,
            velocity
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_SimulateAerodynamicForceAt", args);
    }

    /// <summary>
    /// The total aerodynamic forces acting on the vessel,
    /// in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [Rpc ("SpaceCenter", "Flight_get_AerodynamicForce")]
    public Tuple<double,double,double> AerodynamicForce {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_AerodynamicForce", args);
        }
    }

    /// <summary>
    /// The pitch angle between the orientation of the vessel and its velocity vector,
    /// in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_AngleOfAttack")]
    public float AngleOfAttack {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_AngleOfAttack", args);
        }
    }

    /// <summary>
    /// The direction opposite to the normal of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_AntiNormal")]
    public Tuple<double,double,double> AntiNormal {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_AntiNormal", args);
        }
    }

    /// <summary>
    /// The direction opposite to the radial direction of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_AntiRadial")]
    public Tuple<double,double,double> AntiRadial {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_AntiRadial", args);
        }
    }

    /// <summary>
    /// The current density of the atmosphere around the vessel, in <math>kg/m^3</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_AtmosphereDensity")]
    public float AtmosphereDensity {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_AtmosphereDensity", args);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Ballistic_coefficient">ballistic coefficient</a>.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_BallisticCoefficient")]
    public float BallisticCoefficient {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_BallisticCoefficient", args);
        }
    }

    /// <summary>
    /// The altitude above the surface of the body, in meters. When over water, this is the altitude above the sea floor.
    /// Measured from the center of mass of the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_BedrockAltitude")]
    public double BedrockAltitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Flight_get_BedrockAltitude", args);
        }
    }

    /// <summary>
    /// The position of the center of mass of the vessel,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" /></summary>
    /// <returns>The position as a vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_CenterOfMass")]
    public Tuple<double,double,double> CenterOfMass {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_CenterOfMass", args);
        }
    }

    /// <summary>
    /// The direction that the vessel is pointing in,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Direction")]
    public Tuple<double,double,double> Direction {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Direction", args);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Aerodynamic_force">aerodynamic drag</a> currently acting on the vessel.
    /// </summary>
    /// <returns>A vector pointing in the direction of the force, with its magnitude
    /// equal to the strength of the force in Newtons.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Drag")]
    public Tuple<double,double,double> Drag {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Drag", args);
        }
    }

    /// <summary>
    /// The coefficient of drag. This is the amount of drag produced by the vessel.
    /// It depends on air speed, air density and wing area.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_DragCoefficient")]
    public float DragCoefficient {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_DragCoefficient", args);
        }
    }

    /// <summary>
    /// The dynamic pressure acting on the vessel, in Pascals. This is a measure of the
    /// strength of the aerodynamic forces. It is equal to
    /// <math>\frac{1}{2} . \mbox{air density} . \mbox{velocity}^2</math>.
    /// It is commonly denoted <math>Q</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_DynamicPressure")]
    public float DynamicPressure {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_DynamicPressure", args);
        }
    }

    /// <summary>
    /// The elevation of the terrain under the vessel, in meters. This is the height of the terrain above sea level,
    /// and is negative when the vessel is over the sea.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Elevation")]
    public double Elevation {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Flight_get_Elevation", args);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Equivalent_airspeed">equivalent air speed</a>
    /// of the vessel, in meters per second.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_EquivalentAirSpeed")]
    public float EquivalentAirSpeed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_EquivalentAirSpeed", args);
        }
    }

    /// <summary>
    /// The current G force acting on the vessel in <math>g</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_GForce")]
    public float GForce {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_GForce", args);
        }
    }

    /// <summary>
    /// The heading of the vessel (its angle relative to north), in degrees.
    /// A value between 0° and 360°.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Heading")]
    public float Heading {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_Heading", args);
        }
    }

    /// <summary>
    /// The horizontal speed of the vessel in meters per second,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_HorizontalSpeed")]
    public double HorizontalSpeed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Flight_get_HorizontalSpeed", args);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Latitude">latitude</a> of the vessel for the body being orbited, in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Latitude")]
    public double Latitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Flight_get_Latitude", args);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Aerodynamic_force">aerodynamic lift</a>
    /// currently acting on the vessel.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Lift")]
    public Tuple<double,double,double> Lift {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Lift", args);
        }
    }

    /// <summary>
    /// The coefficient of lift. This is the amount of lift produced by the vessel, and
    /// depends on air speed, air density and wing area.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_LiftCoefficient")]
    public float LiftCoefficient {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_LiftCoefficient", args);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Longitude">longitude</a> of the vessel for the body being orbited, in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Longitude")]
    public double Longitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Flight_get_Longitude", args);
        }
    }

    /// <summary>
    /// The speed of the vessel, in multiples of the speed of sound.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Mach")]
    public float Mach {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_Mach", args);
        }
    }

    /// <summary>
    /// The altitude above sea level, in meters.
    /// Measured from the center of mass of the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_MeanAltitude")]
    public double MeanAltitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Flight_get_MeanAltitude", args);
        }
    }

    /// <summary>
    /// The direction normal to the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Normal")]
    public Tuple<double,double,double> Normal {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Normal", args);
        }
    }

    /// <summary>
    /// The pitch of the vessel relative to the horizon, in degrees.
    /// A value between -90° and +90°.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Pitch")]
    public float Pitch {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_Pitch", args);
        }
    }

    /// <summary>
    /// The prograde direction of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Prograde")]
    public Tuple<double,double,double> Prograde {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Prograde", args);
        }
    }

    /// <summary>
    /// The radial direction of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Radial")]
    public Tuple<double,double,double> Radial {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Radial", args);
        }
    }

    /// <summary>
    /// The retrograde direction of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Retrograde")]
    public Tuple<double,double,double> Retrograde {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Retrograde", args);
        }
    }

    /// <summary>
    /// The vessels Reynolds number.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_ReynoldsNumber")]
    public float ReynoldsNumber {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_ReynoldsNumber", args);
        }
    }

    /// <summary>
    /// The roll of the vessel relative to the horizon, in degrees.
    /// A value between -180° and +180°.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Roll")]
    public float Roll {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_Roll", args);
        }
    }

    /// <summary>
    /// The rotation of the vessel, in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" /></summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Rotation")]
    public Tuple<double,double,double,double> Rotation {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double,double>> ("SpaceCenter", "Flight_get_Rotation", args);
        }
    }

    /// <summary>
    /// The yaw angle between the orientation of the vessel and its velocity vector, in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_SideslipAngle")]
    public float SideslipAngle {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_SideslipAngle", args);
        }
    }

    /// <summary>
    /// The speed of the vessel in meters per second,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Speed")]
    public double Speed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Flight_get_Speed", args);
        }
    }

    /// <summary>
    /// The speed of sound, in the atmosphere around the vessel, in <math>m/s</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_SpeedOfSound")]
    public float SpeedOfSound {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_SpeedOfSound", args);
        }
    }

    /// <summary>
    /// The current amount of stall, between 0 and 1. A value greater than 0.005 indicates
    /// a minor stall and a value greater than 0.5 indicates a large-scale stall.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_StallFraction")]
    public float StallFraction {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_StallFraction", args);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Total_air_temperature">static (ambient)
    /// temperature</a> of the atmosphere around the vessel, in Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_StaticAirTemperature")]
    public float StaticAirTemperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_StaticAirTemperature", args);
        }
    }

    /// <summary>
    /// The static atmospheric pressure acting on the vessel, in Pascals.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_StaticPressure")]
    public float StaticPressure {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_StaticPressure", args);
        }
    }

    /// <summary>
    /// The static atmospheric pressure at mean sea level, in Pascals.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_StaticPressureAtMSL")]
    public float StaticPressureAtMSL {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_StaticPressureAtMSL", args);
        }
    }

    /// <summary>
    /// The altitude above the surface of the body or sea level, whichever is closer, in meters.
    /// Measured from the center of mass of the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_SurfaceAltitude")]
    public double SurfaceAltitude {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Flight_get_SurfaceAltitude", args);
        }
    }

    /// <summary>
    /// An estimate of the current terminal velocity of the vessel, in meters per second.
    /// This is the speed at which the drag forces cancel out the force of gravity.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_TerminalVelocity")]
    public float TerminalVelocity {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_TerminalVelocity", args);
        }
    }

    /// <summary>
    /// The thrust specific fuel consumption for the jet engines on the vessel. This is a
    /// measure of the efficiency of the engines, with a lower value indicating a more
    /// efficient vessel. This value is the number of Newtons of fuel that are burned,
    /// per hour, to produce one newton of thrust.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_ThrustSpecificFuelConsumption")]
    public float ThrustSpecificFuelConsumption {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_ThrustSpecificFuelConsumption", args);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Total_air_temperature">total air temperature</a>
    /// of the atmosphere around the vessel, in Kelvin.
    /// This includes the <see cref="M:SpaceCenter.Flight.StaticAirTemperature" /> and the vessel's kinetic energy.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_TotalAirTemperature")]
    public float TotalAirTemperature {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_TotalAirTemperature", args);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/True_airspeed">true air speed</a>
    /// of the vessel, in meters per second.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_TrueAirSpeed")]
    public float TrueAirSpeed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Flight_get_TrueAirSpeed", args);
        }
    }

    /// <summary>
    /// The velocity of the vessel, in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the vessel in meters per second.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Velocity")]
    public Tuple<double,double,double> Velocity {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Velocity", args);
        }
    }

    /// <summary>
    /// The vertical speed of the vessel in meters per second,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_VerticalSpeed")]
    public double VerticalSpeed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<double> ("SpaceCenter", "Flight_get_VerticalSpeed", args);
        }
    }
}
