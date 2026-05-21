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
    /// Gets the total aerodynamic forces acting on the vessel,
    /// in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [Rpc ("SpaceCenter", "Flight_get_AerodynamicForce")]
    public Tuple<double,double,double> GetAerodynamicForce ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_AerodynamicForce", args);
    }

    /// <summary>
    /// Gets the pitch angle between the orientation of the vessel and its velocity vector,
    /// in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_AngleOfAttack")]
    public float GetAngleOfAttack ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_AngleOfAttack", args);
    }

    /// <summary>
    /// Gets the direction opposite to the normal of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_AntiNormal")]
    public Tuple<double,double,double> GetAntiNormal ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_AntiNormal", args);
    }

    /// <summary>
    /// Gets the direction opposite to the radial direction of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_AntiRadial")]
    public Tuple<double,double,double> GetAntiRadial ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_AntiRadial", args);
    }

    /// <summary>
    /// Gets the current density of the atmosphere around the vessel, in <math>kg/m^3</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_AtmosphereDensity")]
    public float GetAtmosphereDensity ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_AtmosphereDensity", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Ballistic_coefficient">ballistic coefficient</a>.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_BallisticCoefficient")]
    public float GetBallisticCoefficient ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_BallisticCoefficient", args);
    }

    /// <summary>
    /// Gets the altitude above the surface of the body, in meters. When over water, this is the altitude above the sea floor.
    /// Measured from the center of mass of the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_BedrockAltitude")]
    public double GetBedrockAltitude ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Flight_get_BedrockAltitude", args);
    }

    /// <summary>
    /// Gets the position of the center of mass of the vessel,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />
    /// </summary>
    /// <returns>The position as a vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_CenterOfMass")]
    public Tuple<double,double,double> GetCenterOfMass ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_CenterOfMass", args);
    }

    /// <summary>
    /// Gets the direction that the vessel is pointing in,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Direction")]
    public Tuple<double,double,double> GetDirection ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Direction", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Aerodynamic_force">aerodynamic drag</a> currently acting on the vessel.
    /// </summary>
    /// <returns>A vector pointing in the direction of the force, with its magnitude
    /// equal to the strength of the force in Newtons.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Drag")]
    public Tuple<double,double,double> GetDrag ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Drag", args);
    }

    /// <summary>
    /// Gets the coefficient of drag. This is the amount of drag produced by the vessel.
    /// It depends on air speed, air density and wing area.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_DragCoefficient")]
    public float GetDragCoefficient ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_DragCoefficient", args);
    }

    /// <summary>
    /// Gets the dynamic pressure acting on the vessel, in Pascals. This is a measure of the
    /// strength of the aerodynamic forces. It is equal to
    /// <math>\frac{1}{2} . \mbox{air density} . \mbox{velocity}^2</math>.
    /// It is commonly denoted <math>Q</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_DynamicPressure")]
    public float GetDynamicPressure ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_DynamicPressure", args);
    }

    /// <summary>
    /// Gets the elevation of the terrain under the vessel, in meters. This is the height of the terrain above sea level,
    /// and is negative when the vessel is over the sea.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Elevation")]
    public double GetElevation ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Flight_get_Elevation", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Equivalent_airspeed">equivalent air speed</a>
    /// of the vessel, in meters per second.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_EquivalentAirSpeed")]
    public float GetEquivalentAirSpeed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_EquivalentAirSpeed", args);
    }

    /// <summary>
    /// Gets the current G force acting on the vessel in <math>g</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_GForce")]
    public float GetGForce ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_GForce", args);
    }

    /// <summary>
    /// Gets the heading of the vessel (its angle relative to north), in degrees.
    /// A value between 0° and 360°.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Heading")]
    public float GetHeading ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_Heading", args);
    }

    /// <summary>
    /// Gets the horizontal speed of the vessel in meters per second,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_HorizontalSpeed")]
    public double GetHorizontalSpeed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Flight_get_HorizontalSpeed", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Latitude">latitude</a> of the vessel for the body being orbited, in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Latitude")]
    public double GetLatitude ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Flight_get_Latitude", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Aerodynamic_force">aerodynamic lift</a>
    /// currently acting on the vessel.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Lift")]
    public Tuple<double,double,double> GetLift ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Lift", args);
    }

    /// <summary>
    /// Gets the coefficient of lift. This is the amount of lift produced by the vessel, and
    /// depends on air speed, air density and wing area.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_LiftCoefficient")]
    public float GetLiftCoefficient ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_LiftCoefficient", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Longitude">longitude</a> of the vessel for the body being orbited, in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Longitude")]
    public double GetLongitude ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Flight_get_Longitude", args);
    }

    /// <summary>
    /// Gets the speed of the vessel, in multiples of the speed of sound.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Mach")]
    public float GetMach ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_Mach", args);
    }

    /// <summary>
    /// Gets the altitude above sea level, in meters.
    /// Measured from the center of mass of the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_MeanAltitude")]
    public double GetMeanAltitude ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Flight_get_MeanAltitude", args);
    }

    /// <summary>
    /// Gets the direction normal to the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Normal")]
    public Tuple<double,double,double> GetNormal ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Normal", args);
    }

    /// <summary>
    /// Gets the pitch of the vessel relative to the horizon, in degrees.
    /// A value between -90° and +90°.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Pitch")]
    public float GetPitch ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_Pitch", args);
    }

    /// <summary>
    /// Gets the prograde direction of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Prograde")]
    public Tuple<double,double,double> GetPrograde ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Prograde", args);
    }

    /// <summary>
    /// Gets the radial direction of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Radial")]
    public Tuple<double,double,double> GetRadial ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Radial", args);
    }

    /// <summary>
    /// Gets the retrograde direction of the vessels orbit,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Retrograde")]
    public Tuple<double,double,double> GetRetrograde ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Retrograde", args);
    }

    /// <summary>
    /// Gets the vessels Reynolds number.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_ReynoldsNumber")]
    public float GetReynoldsNumber ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_ReynoldsNumber", args);
    }

    /// <summary>
    /// Gets the roll of the vessel relative to the horizon, in degrees.
    /// A value between -180° and +180°.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Roll")]
    public float GetRoll ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_Roll", args);
    }

    /// <summary>
    /// Gets the rotation of the vessel, in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Rotation")]
    public Tuple<double,double,double,double> GetRotation ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double,double>> ("SpaceCenter", "Flight_get_Rotation", args);
    }

    /// <summary>
    /// Gets the yaw angle between the orientation of the vessel and its velocity vector, in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_SideslipAngle")]
    public float GetSideslipAngle ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_SideslipAngle", args);
    }

    /// <summary>
    /// Gets the speed of the vessel in meters per second,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_Speed")]
    public double GetSpeed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Flight_get_Speed", args);
    }

    /// <summary>
    /// Gets the speed of sound, in the atmosphere around the vessel, in <math>m/s</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_SpeedOfSound")]
    public float GetSpeedOfSound ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_SpeedOfSound", args);
    }

    /// <summary>
    /// Gets the current amount of stall, between 0 and 1. A value greater than 0.005 indicates
    /// a minor stall and a value greater than 0.5 indicates a large-scale stall.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_StallFraction")]
    public float GetStallFraction ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_StallFraction", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Total_air_temperature">static (ambient)
    /// temperature</a> of the atmosphere around the vessel, in Kelvin.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_StaticAirTemperature")]
    public float GetStaticAirTemperature ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_StaticAirTemperature", args);
    }

    /// <summary>
    /// Gets the static atmospheric pressure acting on the vessel, in Pascals.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_StaticPressure")]
    public float GetStaticPressure ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_StaticPressure", args);
    }

    /// <summary>
    /// Gets the static atmospheric pressure at mean sea level, in Pascals.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_StaticPressureAtMSL")]
    public float GetStaticPressureAtMSL ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_StaticPressureAtMSL", args);
    }

    /// <summary>
    /// Gets the altitude above the surface of the body or sea level, whichever is closer, in meters.
    /// Measured from the center of mass of the vessel.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_SurfaceAltitude")]
    public double GetSurfaceAltitude ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Flight_get_SurfaceAltitude", args);
    }

    /// <summary>
    /// Gets an estimate of the current terminal velocity of the vessel, in meters per second.
    /// This is the speed at which the drag forces cancel out the force of gravity.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_TerminalVelocity")]
    public float GetTerminalVelocity ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_TerminalVelocity", args);
    }

    /// <summary>
    /// Gets the thrust specific fuel consumption for the jet engines on the vessel. This is a
    /// measure of the efficiency of the engines, with a lower value indicating a more
    /// efficient vessel. This value is the number of Newtons of fuel that are burned,
    /// per hour, to produce one newton of thrust.
    /// </summary>
    /// <remarks>
    /// Requires <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/19321-130-ferram-aerospace-research-v0159-liebe-82117/">Ferram Aerospace Research</a>.
    /// </remarks>
    [Rpc ("SpaceCenter", "Flight_get_ThrustSpecificFuelConsumption")]
    public float GetThrustSpecificFuelConsumption ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_ThrustSpecificFuelConsumption", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Total_air_temperature">total air temperature</a>
    /// of the atmosphere around the vessel, in Kelvin.
    /// This includes the <see cref="M:SpaceCenter.Flight.GetStaticAirTemperature" /> and the vessel's kinetic energy.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_TotalAirTemperature")]
    public float GetTotalAirTemperature ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_TotalAirTemperature", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/True_airspeed">true air speed</a>
    /// of the vessel, in meters per second.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_TrueAirSpeed")]
    public float GetTrueAirSpeed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Flight_get_TrueAirSpeed", args);
    }

    /// <summary>
    /// Gets the velocity of the vessel, in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the vessel in meters per second.</returns>
    [Rpc ("SpaceCenter", "Flight_get_Velocity")]
    public Tuple<double,double,double> GetVelocity ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Flight_get_Velocity", args);
    }

    /// <summary>
    /// Gets the vertical speed of the vessel in meters per second,
    /// in the reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Flight_get_VerticalSpeed")]
    public double GetVerticalSpeed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "Flight_get_VerticalSpeed", args);
    }
}
