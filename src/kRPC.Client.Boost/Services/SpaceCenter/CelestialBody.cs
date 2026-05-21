using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using genericCollectionsAlias = System.Collections.Generic;
using systemAlias = System;

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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_AltitudeAtPosition")]
    public double AltitudeAtPosition (systemAlias::Tuple<double,double,double> position, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_AltitudeAtPosition", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// The angular velocity of the body in the specified reference frame.
    /// </summary>
    /// <returns>The angular velocity as a vector. The magnitude of the vector is the rotational
    /// speed of the body, in radians per second. The direction of the vector indicates the axis
    /// of rotation, using the right-hand rule.</returns>
    /// <param name="referenceFrame">The reference frame the returned
    /// angular velocity is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_AngularVelocity")]
    public systemAlias::Tuple<double,double,double> AngularVelocity (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_AngularVelocity", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The atmospheric density at the given position, in <math>kg/m^3</math>,
    /// in the given reference frame.
    /// </summary>
    /// <param name="position">The position vector at which to measure the density.</param>
    /// <param name="referenceFrame">Reference frame that the position vector is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition")]
    public double AtmosphericDensityAtPosition (systemAlias::Tuple<double,double,double> position, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// The height of the surface relative to mean sea level, in meters,
    /// at the given position. When over water, this is the height
    /// of the sea-bed and is therefore  negative value.
    /// </summary>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_BedrockHeight")]
    public double BedrockHeight (double latitude, double longitude)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (longitude, typeof(double))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_BedrockHeight", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// The position of the surface at the given latitude and longitude, in the given
    /// reference frame. When over water, this is the position at the bottom of the sea-bed.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_BedrockPosition")]
    public systemAlias::Tuple<double,double,double> BedrockPosition (double latitude, double longitude, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_BedrockPosition", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The biome at the given latitude and longitude, in degrees.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_BiomeAt")]
    public string BiomeAt (double latitude, double longitude)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (longitude, typeof(double))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_BiomeAt", _args);
        return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_DensityAt")]
    public double DensityAt (double altitude)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (altitude, typeof(double))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_DensityAt", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// The direction in which the north pole of the celestial body is pointing,
    /// in the specified reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_Direction")]
    public systemAlias::Tuple<double,double,double> Direction (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_Direction", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The latitude of the given position, in the given reference frame.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_LatitudeAtPosition")]
    public double LatitudeAtPosition (systemAlias::Tuple<double,double,double> position, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_LatitudeAtPosition", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// The longitude of the given position, in the given reference frame.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_LongitudeAtPosition")]
    public double LongitudeAtPosition (systemAlias::Tuple<double,double,double> position, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_LongitudeAtPosition", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// The position at mean sea level at the given latitude and longitude,
    /// in the given reference frame.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_MSLPosition")]
    public systemAlias::Tuple<double,double,double> MSLPosition (double latitude, double longitude, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_MSLPosition", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The position of the center of the body, in the specified reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_Position")]
    public systemAlias::Tuple<double,double,double> Position (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_Position", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The position at the given latitude, longitude and altitude, in the given reference frame.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    /// <param name="altitude">Altitude in meters above sea level.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_PositionAtAltitude")]
    public systemAlias::Tuple<double,double,double> PositionAtAltitude (double latitude, double longitude, double altitude, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (altitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_PositionAtAltitude", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// Gets the air pressure, in Pascals, for the specified
    /// altitude above sea level, in meters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_PressureAt")]
    public double PressureAt (double altitude)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (altitude, typeof(double))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_PressureAt", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// The rotation of the body, in the specified reference frame.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_Rotation")]
    public systemAlias::Tuple<double,double,double,double> Rotation (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_Rotation", _args);
        return (systemAlias::Tuple<double,double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double,double>), connection);
    }

    /// <summary>
    /// The height of the surface relative to mean sea level, in meters,
    /// at the given position. When over water this is equal to 0.
    /// </summary>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_SurfaceHeight")]
    public double SurfaceHeight (double latitude, double longitude)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (longitude, typeof(double))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_SurfaceHeight", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// The position of the surface at the given latitude and longitude, in the given
    /// reference frame. When over water, this is the position of the surface of the water.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude in degrees.</param>
    /// <param name="longitude">Longitude in degrees.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_SurfacePosition")]
    public systemAlias::Tuple<double,double,double> SurfacePosition (double latitude, double longitude, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (latitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (longitude, typeof(double)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_SurfacePosition", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_TemperatureAt")]
    public double TemperatureAt (systemAlias::Tuple<double,double,double> position, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (position, typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_TemperatureAt", _args);
        return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
    }

    /// <summary>
    /// The linear velocity of the body, in the specified reference frame.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the body in meters per second.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// velocity vector is in.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_Velocity")]
    public systemAlias::Tuple<double,double,double> Velocity (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody)),
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_Velocity", _args);
        return (systemAlias::Tuple<double,double,double>)global::KRPC.Client.Encoder.Decode (_data, typeof(systemAlias::Tuple<double,double,double>), connection);
    }

    /// <summary>
    /// The depth of the atmosphere, in meters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_AtmosphereDepth")]
    public double AtmosphereDepth {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_AtmosphereDepth", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The biomes present on this body.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Biomes")]
    public genericCollectionsAlias::ISet<string> Biomes {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Biomes", _args);
            return (genericCollectionsAlias::ISet<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(genericCollectionsAlias::ISet<string>), connection);
        }
    }

    /// <summary>
    /// The equatorial radius of the body, in meters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_EquatorialRadius")]
    public double EquatorialRadius {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_EquatorialRadius", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The altitude, in meters, above which a vessel is considered to be
    /// flying "high" when doing science.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold")]
    public float FlyingHighAltitudeThreshold {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The <a href="https://en.wikipedia.org/wiki/Standard_gravitational_parameter">standard
    /// gravitational parameter</a> of the body in <math>m^3s^{-2}</math>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_GravitationalParameter")]
    public double GravitationalParameter {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_GravitationalParameter", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary><c>true</c> if the body has an atmosphere.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_HasAtmosphere")]
    public bool HasAtmosphere {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_HasAtmosphere", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary><c>true</c> if there is oxygen in the atmosphere, required for air-breathing engines.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen")]
    public bool HasAtmosphericOxygen {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// Whether or not the body has a solid surface.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_HasSolidSurface")]
    public bool HasSolidSurface {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_HasSolidSurface", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The initial rotation angle of the body (at UT 0), in radians.
    /// A value between 0 and <math>2\pi</math></summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_InitialRotation")]
    public double InitialRotation {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_InitialRotation", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// Whether or not the body is a star.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_IsStar")]
    public bool IsStar {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_IsStar", _args);
            return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
        }
    }

    /// <summary>
    /// The mass of the body, in kilograms.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Mass")]
    public double Mass {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Mass", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The name of the body.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Name")]
    public string Name {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// The reference frame that is fixed relative to this celestial body, and
    /// orientated in a fixed direction (it does not rotate with the body).
    /// <list type="bullet"><item><description>The origin is at the center of the body.</description></item><item><description>The axes do not rotate.</description></item><item><description>The x-axis points in an arbitrary direction through the
    /// equator.</description></item><item><description>The y-axis points from the center of the body towards
    /// the north pole.</description></item><item><description>The z-axis points in an arbitrary direction through the
    /// equator.</description></item></list></summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame NonRotatingReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// The orbit of the body.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Orbit")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Orbit Orbit {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Orbit", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Orbit)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Orbit), connection);
        }
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame OrbitalReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// The reference frame that is fixed relative to the celestial body.
    /// <list type="bullet"><item><description>The origin is at the center of the body.
    /// </description></item><item><description>The axes rotate with the body.</description></item><item><description>The x-axis points from the center of the body
    /// towards the intersection of the prime meridian and equator (the
    /// position at 0° longitude, 0° latitude).</description></item><item><description>The y-axis points from the center of the body
    /// towards the north pole.</description></item><item><description>The z-axis points from the center of the body
    /// towards the equator at 90°E longitude.</description></item></list></summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_ReferenceFrame")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame ReferenceFrame {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_ReferenceFrame", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
        }
    }

    /// <summary>
    /// The current rotation angle of the body, in radians.
    /// A value between 0 and <math>2\pi</math></summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_RotationAngle")]
    public double RotationAngle {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_RotationAngle", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The sidereal rotational period of the body, in seconds.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_RotationalPeriod")]
    public double RotationalPeriod {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_RotationalPeriod", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The rotational speed of the body, in radians per second.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_RotationalSpeed")]
    public double RotationalSpeed {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_RotationalSpeed", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// A list of celestial bodies that are in orbit around this celestial body.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_Satellites")]
    public global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody> Satellites {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_Satellites", _args);
            return (global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody>), connection);
        }
    }

    /// <summary>
    /// The altitude, in meters, above which a vessel is considered to be
    /// in "high" space when doing science.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold")]
    public float SpaceHighAltitudeThreshold {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold", _args);
            return (float)global::KRPC.Client.Encoder.Decode (_data, typeof(float), connection);
        }
    }

    /// <summary>
    /// The radius of the sphere of influence of the body, in meters.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_SphereOfInfluence")]
    public double SphereOfInfluence {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_SphereOfInfluence", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }

    /// <summary>
    /// The acceleration due to gravity at sea level (mean altitude) on the body,
    /// in <math>m/s^2</math>.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "CelestialBody_get_SurfaceGravity")]
    public double SurfaceGravity {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.CelestialBody))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "CelestialBody_get_SurfaceGravity", _args);
            return (double)global::KRPC.Client.Encoder.Decode (_data, typeof(double), connection);
        }
    }
}
