using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a celestial body (such as a planet or moon).
/// See <see cref="M:SpaceCenter.Bodies" />.
/// </summary>
public class CelestialBody : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public CelestialBody (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// The altitude, in meters, of the given position in the given reference frame.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [Rpc ("SpaceCenter", "CelestialBody_AltitudeAtPosition")]
    public double AltitudeAtPosition (Tuple<double,double,double> position, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            position,
            referenceFrame
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_AltitudeAtPosition", args);
    }

    /// <summary>
    /// The angular velocity of the body in the specified reference frame.
    /// </summary>
    /// <returns>The angular velocity as a vector. The magnitude of the vector is the rotational
    /// speed of the body, in radians per second. The direction of the vector indicates the axis
    /// of rotation, using the right-hand rule.</returns>
    /// <param name="referenceFrame">The reference frame the returned
    /// angular velocity is in.</param>
    [Rpc ("SpaceCenter", "CelestialBody_AngularVelocity")]
    public Tuple<double,double,double> AngularVelocity (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "CelestialBody_AngularVelocity", args);
    }

    /// <summary>
    /// The atmospheric density at the given position, in <math>kg/m^3</math>,
    /// in the given reference frame.
    /// </summary>
    /// <param name="position">The position vector at which to measure the density.</param>
    /// <param name="referenceFrame">Reference frame that the position vector is in.</param>
    [Rpc ("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition")]
    public double AtmosphericDensityAtPosition (Tuple<double,double,double> position, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            position,
            referenceFrame
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition", args);
    }

    /// <summary>
    /// The height of the surface relative to mean sea level, in meters,
    /// at the given position. When over water, this is the height
    /// of the sea-bed and is therefore  negative value.
    /// </summary>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    [Rpc ("SpaceCenter", "CelestialBody_BedrockHeight")]
    public double BedrockHeight (double latitude, double longitude)
    {
        var args = new object[] {
            this,
            latitude,
            longitude
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_BedrockHeight", args);
    }

    /// <summary>
    /// The position of the surface at the given latitude and longitude, in the given
    /// reference frame. When over water, this is the position at the bottom of the sea-bed.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [Rpc ("SpaceCenter", "CelestialBody_BedrockPosition")]
    public Tuple<double,double,double> BedrockPosition (double latitude, double longitude, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            latitude,
            longitude,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "CelestialBody_BedrockPosition", args);
    }

    /// <summary>
    /// The biome at the given latitude and longitude, in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_BiomeAt")]
    public string BiomeAt (double latitude, double longitude)
    {
        var args = new object[] {
            this,
            latitude,
            longitude
        };
        return Connection.Invoke<string> ("SpaceCenter", "CelestialBody_BiomeAt", args);
    }

    /// <summary>
    /// Gets the air density, in <math>kg/m^3</math>, for the specified
    /// altitude above sea level, in meters.
    /// </summary>
    /// <remarks>
    /// This is an approximation, because actual calculations, taking sun exposure into account
    /// to compute air temperature, require us to know the exact point on the body where the
    /// density is to be computed (knowing the altitude is not enough).
    /// However, the difference is small for high altitudes, so it makes very little difference
    /// for trajectory prediction.
    /// </remarks>
    [Rpc ("SpaceCenter", "CelestialBody_DensityAt")]
    public double DensityAt (double altitude)
    {
        var args = new object[] {
            this,
            altitude
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_DensityAt", args);
    }

    /// <summary>
    /// The direction in which the north pole of the celestial body is pointing,
    /// in the specified reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [Rpc ("SpaceCenter", "CelestialBody_Direction")]
    public Tuple<double,double,double> Direction (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "CelestialBody_Direction", args);
    }

    /// <summary>
    /// The latitude of the given position, in the given reference frame.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [Rpc ("SpaceCenter", "CelestialBody_LatitudeAtPosition")]
    public double LatitudeAtPosition (Tuple<double,double,double> position, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            position,
            referenceFrame
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_LatitudeAtPosition", args);
    }

    /// <summary>
    /// The longitude of the given position, in the given reference frame.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [Rpc ("SpaceCenter", "CelestialBody_LongitudeAtPosition")]
    public double LongitudeAtPosition (Tuple<double,double,double> position, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            position,
            referenceFrame
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_LongitudeAtPosition", args);
    }

    /// <summary>
    /// The position at mean sea level at the given latitude and longitude,
    /// in the given reference frame.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [Rpc ("SpaceCenter", "CelestialBody_MSLPosition")]
    public Tuple<double,double,double> MSLPosition (double latitude, double longitude, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            latitude,
            longitude,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "CelestialBody_MSLPosition", args);
    }

    /// <summary>
    /// The position of the center of the body, in the specified reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [Rpc ("SpaceCenter", "CelestialBody_Position")]
    public Tuple<double,double,double> Position (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "CelestialBody_Position", args);
    }

    /// <summary>
    /// The position at the given latitude, longitude and altitude, in the given reference frame.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    /// <param name="altitude">Altitude in meters above sea level.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [Rpc ("SpaceCenter", "CelestialBody_PositionAtAltitude")]
    public Tuple<double,double,double> PositionAtAltitude (double latitude, double longitude, double altitude, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            latitude,
            longitude,
            altitude,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "CelestialBody_PositionAtAltitude", args);
    }

    /// <summary>
    /// Gets the air pressure, in Pascals, for the specified
    /// altitude above sea level, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_PressureAt")]
    public double PressureAt (double altitude)
    {
        var args = new object[] {
            this,
            altitude
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_PressureAt", args);
    }

    /// <summary>
    /// The rotation of the body, in the specified reference frame.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [Rpc ("SpaceCenter", "CelestialBody_Rotation")]
    public Tuple<double,double,double,double> Rotation (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double,double>> ("SpaceCenter", "CelestialBody_Rotation", args);
    }

    /// <summary>
    /// The height of the surface relative to mean sea level, in meters,
    /// at the given position. When over water this is equal to 0.
    /// </summary>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    [Rpc ("SpaceCenter", "CelestialBody_SurfaceHeight")]
    public double SurfaceHeight (double latitude, double longitude)
    {
        var args = new object[] {
            this,
            latitude,
            longitude
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_SurfaceHeight", args);
    }

    /// <summary>
    /// The position of the surface at the given latitude and longitude, in the given
    /// reference frame. When over water, this is the position of the surface of the water.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [Rpc ("SpaceCenter", "CelestialBody_SurfacePosition")]
    public Tuple<double,double,double> SurfacePosition (double latitude, double longitude, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            latitude,
            longitude,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "CelestialBody_SurfacePosition", args);
    }

    /// <summary>
    /// The temperature on the body at the given position, in the given reference frame.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">The reference frame that the position is in.</param>
    /// <remarks>
    /// This calculation is performed using the bodies current position, which means that
    /// the value could be wrong if you want to know the temperature in the far future.
    /// </remarks>
    [Rpc ("SpaceCenter", "CelestialBody_TemperatureAt")]
    public double TemperatureAt (Tuple<double,double,double> position, ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            position,
            referenceFrame
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_TemperatureAt", args);
    }

    /// <summary>
    /// The linear velocity of the body, in the specified reference frame.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the body in meters per second.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// velocity vector is in.</param>
    [Rpc ("SpaceCenter", "CelestialBody_Velocity")]
    public Tuple<double,double,double> Velocity (ReferenceFrame referenceFrame)
    {
        var args = new object[] {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "CelestialBody_Velocity", args);
    }

    /// <summary>
    /// The depth of the atmosphere, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_AtmosphereDepth")]
    public double GetAtmosphereDepth ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_AtmosphereDepth", args);
    }

    /// <summary>
    /// The biomes present on this body.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_Biomes")]
    public ISet<string> GetBiomes ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ISet<string>> ("SpaceCenter", "CelestialBody_get_Biomes", args);
    }

    /// <summary>
    /// The equatorial radius of the body, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_EquatorialRadius")]
    public double GetEquatorialRadius ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_EquatorialRadius", args);
    }

    /// <summary>
    /// The altitude, in meters, above which a vessel is considered to be
    /// flying "high" when doing science.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold")]
    public float GetFlyingHighAltitudeThreshold ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold", args);
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Standard_gravitational_parameter">standard
    /// gravitational parameter</a> of the body in <math>m^3s^{-2}</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_GravitationalParameter")]
    public double GetGravitationalParameter ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_GravitationalParameter", args);
    }

    /// <summary><c>true</c> if the body has an atmosphere.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_HasAtmosphere")]
    public bool GetHasAtmosphere ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CelestialBody_get_HasAtmosphere", args);
    }

    /// <summary><c>true</c> if there is oxygen in the atmosphere, required for air-breathing engines.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen")]
    public bool GetHasAtmosphericOxygen ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen", args);
    }

    /// <summary>
    /// Whether or not the body has a solid surface.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_HasSolidSurface")]
    public bool GetHasSolidSurface ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CelestialBody_get_HasSolidSurface", args);
    }

    /// <summary>
    /// The initial rotation angle of the body (at UT 0), in radians.
    /// A value between 0 and <math>2\pi</math></summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_InitialRotation")]
    public double GetInitialRotation ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_InitialRotation", args);
    }

    /// <summary>
    /// Whether or not the body is a star.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_IsStar")]
    public bool GetIsStar ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<bool> ("SpaceCenter", "CelestialBody_get_IsStar", args);
    }

    /// <summary>
    /// The mass of the body, in kilograms.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_Mass")]
    public double GetMass ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_Mass", args);
    }

    /// <summary>
    /// The name of the body.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_Name")]
    public string GetName ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<string> ("SpaceCenter", "CelestialBody_get_Name", args);
    }

    /// <summary>
    /// The reference frame that is fixed relative to this celestial body, and
    /// orientated in a fixed direction (it does not rotate with the body).
    /// <list type="bullet"><item><description>The origin is at the center of the body.</description></item><item><description>The axes do not rotate.</description></item><item><description>The x-axis points in an arbitrary direction through the
    /// equator.</description></item><item><description>The y-axis points from the center of the body towards
    /// the north pole.</description></item><item><description>The z-axis points in an arbitrary direction through the
    /// equator.</description></item></list></summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame")]
    public ReferenceFrame GetNonRotatingReferenceFrame ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame", args);
    }

    /// <summary>
    /// The orbit of the body.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_Orbit")]
    public Orbit GetOrbit ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Orbit> ("SpaceCenter", "CelestialBody_get_Orbit", args);
    }

    /// <summary>
    /// The reference frame that is fixed relative to this celestial body, but
    /// orientated with the body's orbital prograde/normal/radial directions.
    /// <list type="bullet"><item><description>The origin is at the center of the body.
    /// </description></item><item><description>The axes rotate with the orbital prograde/normal/radial
    /// directions.</description></item><item><description>The x-axis points in the orbital anti-radial direction.
    /// </description></item><item><description>The y-axis points in the orbital prograde direction.
    /// </description></item><item><description>The z-axis points in the orbital normal direction.
    /// </description></item></list></summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame")]
    public ReferenceFrame GetOrbitalReferenceFrame ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame", args);
    }

    /// <summary>
    /// The reference frame that is fixed relative to the celestial body.
    /// <list type="bullet"><item><description>The origin is at the center of the body.
    /// </description></item><item><description>The axes rotate with the body.</description></item><item><description>The x-axis points from the center of the body
    /// towards the intersection of the prime meridian and equator (the
    /// position at 0° longitude, 0° latitude).</description></item><item><description>The y-axis points from the center of the body
    /// towards the north pole.</description></item><item><description>The z-axis points from the center of the body
    /// towards the equator at 90°E longitude.</description></item></list></summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_ReferenceFrame")]
    public ReferenceFrame GetReferenceFrame ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "CelestialBody_get_ReferenceFrame", args);
    }

    /// <summary>
    /// The current rotation angle of the body, in radians.
    /// A value between 0 and <math>2\pi</math></summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_RotationAngle")]
    public double GetRotationAngle ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_RotationAngle", args);
    }

    /// <summary>
    /// The sidereal rotational period of the body, in seconds.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_RotationalPeriod")]
    public double GetRotationalPeriod ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_RotationalPeriod", args);
    }

    /// <summary>
    /// The rotational speed of the body, in radians per second.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_RotationalSpeed")]
    public double GetRotationalSpeed ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_RotationalSpeed", args);
    }

    /// <summary>
    /// A list of celestial bodies that are in orbit around this celestial body.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_Satellites")]
    public IList<CelestialBody> GetSatellites ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<CelestialBody>> ("SpaceCenter", "CelestialBody_get_Satellites", args);
    }

    /// <summary>
    /// The altitude, in meters, above which a vessel is considered to be
    /// in "high" space when doing science.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold")]
    public float GetSpaceHighAltitudeThreshold ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold", args);
    }

    /// <summary>
    /// The radius of the sphere of influence of the body, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_SphereOfInfluence")]
    public double GetSphereOfInfluence ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_SphereOfInfluence", args);
    }

    /// <summary>
    /// The acceleration due to gravity at sea level (mean altitude) on the body,
    /// in <math>m/s^2</math>.
    /// </summary>
    [Rpc ("SpaceCenter", "CelestialBody_get_SurfaceGravity")]
    public double GetSurfaceGravity ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<double> ("SpaceCenter", "CelestialBody_get_SurfaceGravity", args);
    }
}
