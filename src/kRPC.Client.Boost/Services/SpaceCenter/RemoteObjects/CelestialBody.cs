using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Represents a celestial body (such as a planet or moon).
/// See <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetBodies" />.
/// </summary>
public class CelestialBody : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal CelestialBody(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// The altitude, in meters, of the given position in the given reference frame.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [GetRpc("SpaceCenter", "CelestialBody_AltitudeAtPosition")]
    public double GetAltitudeAtPosition(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_AltitudeAtPosition", args);
    }

    /// <summary>
    /// The altitude, in meters, of the given position in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [GetRpc("SpaceCenter", "CelestialBody_AltitudeAtPosition")]
    public async Task<double> GetAltitudeAtPositionAsync(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_AltitudeAtPosition", args);
    }

    /// <summary>
    /// The angular velocity of the body in the specified reference frame.
    /// </summary>
    /// <returns>The angular velocity as a vector. The magnitude of the vector is the rotational
    /// speed of the body, in radians per second. The direction of the vector indicates the axis
    /// of rotation, using the right-hand rule.</returns>
    /// <param name="referenceFrame">The reference frame the returned
    /// angular velocity is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_AngularVelocity")]
    public Vector3D GetAngularVelocity(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "CelestialBody_AngularVelocity", args);
    }

    /// <summary>
    /// The angular velocity of the body in the specified reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The angular velocity as a vector. The magnitude of the vector is the rotational
    /// speed of the body, in radians per second. The direction of the vector indicates the axis
    /// of rotation, using the right-hand rule.</returns>
    /// <param name="referenceFrame">The reference frame the returned
    /// angular velocity is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_AngularVelocity")]
    public async Task<Vector3D> GetAngularVelocityAsync(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "CelestialBody_AngularVelocity", args);
    }

    /// <summary>
    /// The atmospheric density at the given position, in <math>kg/m^3</math>,
    /// in the given reference frame.
    /// </summary>
    /// <param name="position">The position vector at which to measure the density.</param>
    /// <param name="referenceFrame">Reference frame that the position vector is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition")]
    public double GetAtmosphericDensityAtPosition(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition", args);
    }

    /// <summary>
    /// The atmospheric density at the given position, in <math>kg/m^3</math>,
    /// in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="position">The position vector at which to measure the density.</param>
    /// <param name="referenceFrame">Reference frame that the position vector is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition")]
    public async Task<double> GetAtmosphericDensityAtPositionAsync(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_AtmosphericDensityAtPosition", args);
    }

    /// <summary>
    /// The height of the surface relative to mean sea level, in meters,
    /// at the given position. When over water, this is the height
    /// of the sea-bed and is therefore  negative value.
    /// </summary>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_BedrockHeight")]
    public double GetBedrockHeight(Angle latitude, Angle longitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_BedrockHeight", args);
    }

    /// <summary>
    /// The height of the surface relative to mean sea level, in meters,
    /// at the given position. When over water, this is the height
    /// of the sea-bed and is therefore  negative value.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_BedrockHeight")]
    public async Task<double> GetBedrockHeightAsync(Angle latitude, Angle longitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_BedrockHeight", args);
    }

    /// <summary>
    /// The position of the surface at the given latitude and longitude, in the given
    /// reference frame. When over water, this is the position at the bottom of the sea-bed.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_BedrockPosition")]
    public Vector3D GetBedrockPosition(Angle latitude, Angle longitude, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "CelestialBody_BedrockPosition", args);
    }

    /// <summary>
    /// The position of the surface at the given latitude and longitude, in the given
    /// reference frame. When over water, this is the position at the bottom of the sea-bed.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_BedrockPosition")]
    public async Task<Vector3D> GetBedrockPositionAsync(Angle latitude, Angle longitude, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "CelestialBody_BedrockPosition", args);
    }

    /// <summary>
    /// The biome at the given latitude and longitude.
    /// </summary>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_BiomeAt")]
    public string GetBiomeAt(Angle latitude, Angle longitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees
        };
        return InvokeNonNullable<string>("SpaceCenter", "CelestialBody_BiomeAt", args);
    }

    /// <summary>
    /// The biome at the given latitude and longitude.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_BiomeAt")]
    public async Task<string> GetBiomeAtAsync(Angle latitude, Angle longitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees
        };
        return await InvokeNonNullableAsync<string>("SpaceCenter", "CelestialBody_BiomeAt", args);
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
    [GetRpc("SpaceCenter", "CelestialBody_DensityAt")]
    public double GetDensityAt(double altitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            altitude
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_DensityAt", args);
    }

    /// <summary>
    /// Gets the air density, in <math>kg/m^3</math>, for the specified
    /// altitude above sea level, in meters.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This is an approximation, because actual calculations, taking sun exposure into account
    /// to compute air temperature, require us to know the exact point on the body where the
    /// density is to be computed (knowing the altitude is not enough).
    /// However, the difference is small for high altitudes, so it makes very little difference
    /// for trajectory prediction.
    /// </remarks>
    [GetRpc("SpaceCenter", "CelestialBody_DensityAt")]
    public async Task<double> GetDensityAtAsync(double altitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            altitude
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_DensityAt", args);
    }

    /// <summary>
    /// The direction in which the north pole of the celestial body is pointing,
    /// in the specified reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_Direction")]
    public Vector3D GetDirection(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "CelestialBody_Direction", args);
    }

    /// <summary>
    /// The direction in which the north pole of the celestial body is pointing,
    /// in the specified reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_Direction")]
    public async Task<Vector3D> GetDirectionAsync(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "CelestialBody_Direction", args);
    }

    /// <summary>
    /// The latitude of the given position, in the given reference frame.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_LatitudeAtPosition")]
    public Angle GetLatitudeAtPosition(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "CelestialBody_LatitudeAtPosition", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// The latitude of the given position, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_LatitudeAtPosition")]
    public async Task<Angle> GetLatitudeAtPositionAsync(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_LatitudeAtPosition", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// The longitude of the given position, in the given reference frame.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_LongitudeAtPosition")]
    public Angle GetLongitudeAtPosition(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "CelestialBody_LongitudeAtPosition", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// The longitude of the given position, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">Reference frame for the position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_LongitudeAtPosition")]
    public async Task<Angle> GetLongitudeAtPositionAsync(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_LongitudeAtPosition", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// The position at mean sea level at the given latitude and longitude,
    /// in the given reference frame.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_MSLPosition")]
    public Vector3D GetMSLPosition(Angle latitude, Angle longitude, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "CelestialBody_MSLPosition", args);
    }

    /// <summary>
    /// The position at mean sea level at the given latitude and longitude,
    /// in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_MSLPosition")]
    public async Task<Vector3D> GetMSLPositionAsync(Angle latitude, Angle longitude, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "CelestialBody_MSLPosition", args);
    }

    /// <summary>
    /// The position of the center of the body, in the specified reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_Position")]
    public Vector3D GetPosition(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "CelestialBody_Position", args);
    }

    /// <summary>
    /// The position of the center of the body, in the specified reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_Position")]
    public async Task<Vector3D> GetPositionAsync(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "CelestialBody_Position", args);
    }

    /// <summary>
    /// The position at the given latitude, longitude and altitude, in the given reference frame.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    /// <param name="altitude">Altitude in meters above sea level.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_PositionAtAltitude")]
    public Vector3D GetPositionAtAltitude(Angle latitude, Angle longitude, double altitude, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            altitude,
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "CelestialBody_PositionAtAltitude", args);
    }

    /// <summary>
    /// The position at the given latitude, longitude and altitude, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    /// <param name="altitude">Altitude in meters above sea level.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_PositionAtAltitude")]
    public async Task<Vector3D> GetPositionAtAltitudeAsync(Angle latitude, Angle longitude, double altitude, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            altitude,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "CelestialBody_PositionAtAltitude", args);
    }

    /// <summary>
    /// Gets the air pressure, in Pascals, for the specified
    /// altitude above sea level, in meters.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_PressureAt")]
    public double GetPressureAt(double altitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            altitude
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_PressureAt", args);
    }

    /// <summary>
    /// Gets the air pressure, in Pascals, for the specified
    /// altitude above sea level, in meters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_PressureAt")]
    public async Task<double> GetPressureAtAsync(double altitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            altitude
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_PressureAt", args);
    }

    /// <summary>
    /// The rotation of the body, in the specified reference frame.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_Rotation")]
    public Quaternion GetRotation(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return InvokeNonNullable<Quaternion>("SpaceCenter", "CelestialBody_Rotation", args);
    }

    /// <summary>
    /// The rotation of the body, in the specified reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_Rotation")]
    public async Task<Quaternion> GetRotationAsync(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Quaternion>("SpaceCenter", "CelestialBody_Rotation", args);
    }

    /// <summary>
    /// The height of the surface relative to mean sea level, in meters,
    /// at the given position. When over water this is equal to 0.
    /// </summary>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_SurfaceHeight")]
    public double GetSurfaceHeight(Angle latitude, Angle longitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_SurfaceHeight", args);
    }

    /// <summary>
    /// The height of the surface relative to mean sea level, in meters,
    /// at the given position. When over water this is equal to 0.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_SurfaceHeight")]
    public async Task<double> GetSurfaceHeightAsync(Angle latitude, Angle longitude)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_SurfaceHeight", args);
    }

    /// <summary>
    /// The position of the surface at the given latitude and longitude, in the given
    /// reference frame. When over water, this is the position of the surface of the water.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_SurfacePosition")]
    public Vector3D GetSurfacePosition(Angle latitude, Angle longitude, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "CelestialBody_SurfacePosition", args);
    }

    /// <summary>
    /// The position of the surface at the given latitude and longitude, in the given
    /// reference frame. When over water, this is the position of the surface of the water.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>Position as a vector.</returns>
    /// <param name="latitude">Latitude.</param>
    /// <param name="longitude">Longitude.</param>
    /// <param name="referenceFrame">Reference frame for the returned position vector.</param>
    [AngleConversion(AngleType.Degrees, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_SurfacePosition")]
    public async Task<Vector3D> GetSurfacePositionAsync(Angle latitude, Angle longitude, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            latitude.Degrees,
            longitude.Degrees,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "CelestialBody_SurfacePosition", args);
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
    [GetRpc("SpaceCenter", "CelestialBody_TemperatureAt")]
    public double GetTemperatureAt(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_TemperatureAt", args);
    }

    /// <summary>
    /// The temperature on the body at the given position, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="position">Position as a vector.</param>
    /// <param name="referenceFrame">The reference frame that the position is in.</param>
    /// <remarks>
    /// This calculation is performed using the bodies current position, which means that
    /// the value could be wrong if you want to know the temperature in the far future.
    /// </remarks>
    [GetRpc("SpaceCenter", "CelestialBody_TemperatureAt")]
    public async Task<double> GetTemperatureAtAsync(Vector3D position, ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            position,
            referenceFrame
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_TemperatureAt", args);
    }

    /// <summary>
    /// The linear velocity of the body, in the specified reference frame.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the body in meters per second.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// velocity vector is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_Velocity")]
    public Vector3D GetVelocity(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return InvokeNonNullable<Vector3D>("SpaceCenter", "CelestialBody_Velocity", args);
    }

    /// <summary>
    /// The linear velocity of the body, in the specified reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the body in meters per second.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// velocity vector is in.</param>
    [GetRpc("SpaceCenter", "CelestialBody_Velocity")]
    public async Task<Vector3D> GetVelocityAsync(ReferenceFrame referenceFrame)
    {
        var args = new ProcedureArgument[]
        {
            this,
            referenceFrame
        };
        return await InvokeNonNullableAsync<Vector3D>("SpaceCenter", "CelestialBody_Velocity", args);
    }

    /// <summary>
    /// Gets the depth of the atmosphere, in meters.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_AtmosphereDepth")]
    public double GetAtmosphereDepth()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_AtmosphereDepth", args);
    }

    /// <summary>
    /// Gets the depth of the atmosphere, in meters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_AtmosphereDepth")]
    public async Task<double> GetAtmosphereDepthAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_AtmosphereDepth", args);
    }

    /// <summary>
    /// Gets the biomes present on this body.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Biomes")]
    public ISet<string> GetBiomes()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<HashSet<string>>("SpaceCenter", "CelestialBody_get_Biomes", args);
    }

    /// <summary>
    /// Gets the biomes present on this body.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Biomes")]
    public async Task<ISet<string>> GetBiomesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<HashSet<string>>("SpaceCenter", "CelestialBody_get_Biomes", args);
    }

    /// <summary>
    /// Gets the equatorial radius of the body, in meters.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_EquatorialRadius")]
    public double GetEquatorialRadius()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_EquatorialRadius", args);
    }

    /// <summary>
    /// Gets the equatorial radius of the body, in meters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_EquatorialRadius")]
    public async Task<double> GetEquatorialRadiusAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_EquatorialRadius", args);
    }

    /// <summary>
    /// Gets the altitude, in meters, above which a vessel is considered to be
    /// flying "high" when doing science.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold")]
    public float GetFlyingHighAltitudeThreshold()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold", args);
    }

    /// <summary>
    /// Gets the altitude, in meters, above which a vessel is considered to be
    /// flying "high" when doing science.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold")]
    public async Task<float> GetFlyingHighAltitudeThresholdAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "CelestialBody_get_FlyingHighAltitudeThreshold", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Standard_gravitational_parameter">standard
    /// gravitational parameter</a> of the body in <math>m^3s^{-2}</math>.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_GravitationalParameter")]
    public double GetGravitationalParameter()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_GravitationalParameter", args);
    }

    /// <summary>
    /// Gets the <a href="https://en.wikipedia.org/wiki/Standard_gravitational_parameter">standard
    /// gravitational parameter</a> of the body in <math>m^3s^{-2}</math>.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_GravitationalParameter")]
    public async Task<double> GetGravitationalParameterAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_GravitationalParameter", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the body has an atmosphere.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_HasAtmosphere")]
    public bool GetHasAtmosphere()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "CelestialBody_get_HasAtmosphere", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the body has an atmosphere.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_HasAtmosphere")]
    public async Task<bool> GetHasAtmosphereAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "CelestialBody_get_HasAtmosphere", args);
    }

    /// <summary>
    /// Returns <c>true</c> if there is oxygen in the atmosphere, required for air-breathing engines.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen")]
    public bool GetHasAtmosphericOxygen()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen", args);
    }

    /// <summary>
    /// Returns <c>true</c> if there is oxygen in the atmosphere, required for air-breathing engines.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen")]
    public async Task<bool> GetHasAtmosphericOxygenAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "CelestialBody_get_HasAtmosphericOxygen", args);
    }

    /// <summary>
    /// Gets whether or not the body has a solid surface.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_HasSolidSurface")]
    public bool GetHasSolidSurface()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "CelestialBody_get_HasSolidSurface", args);
    }

    /// <summary>
    /// Gets whether or not the body has a solid surface.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_HasSolidSurface")]
    public async Task<bool> GetHasSolidSurfaceAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "CelestialBody_get_HasSolidSurface", args);
    }

    /// <summary>
    /// Gets the initial rotation angle of the body (at UT 0).
    /// A value between 0 and <math>2\pi</math>
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_get_InitialRotation")]
    public Angle GetInitialRotation()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_InitialRotation", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the initial rotation angle of the body (at UT 0).
    /// A value between 0 and <math>2\pi</math>
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_get_InitialRotation")]
    public async Task<Angle> GetInitialRotationAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_InitialRotation", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets whether or not the body is a star.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_IsStar")]
    public bool GetIsStar()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "CelestialBody_get_IsStar", args);
    }

    /// <summary>
    /// Gets whether or not the body is a star.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_IsStar")]
    public async Task<bool> GetIsStarAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "CelestialBody_get_IsStar", args);
    }

    /// <summary>
    /// Gets the mass of the body, in kilograms.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Mass")]
    public double GetMass()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_Mass", args);
    }

    /// <summary>
    /// Gets the mass of the body, in kilograms.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Mass")]
    public async Task<double> GetMassAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_Mass", args);
    }

    /// <summary>
    /// Gets the name of the body.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Name")]
    public string GetName()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<string>("SpaceCenter", "CelestialBody_get_Name", args);
    }

    /// <summary>
    /// Gets the name of the body.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Name")]
    public async Task<string> GetNameAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<string>("SpaceCenter", "CelestialBody_get_Name", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to this celestial body, and
    /// orientated in a fixed direction (it does not rotate with the body).
    /// <list type="bullet"><item><description>The origin is at the center of the body.</description></item><item><description>The axes do not rotate.</description></item><item><description>The x-axis points in an arbitrary direction through the
    /// equator.</description></item><item><description>The y-axis points from the center of the body towards
    /// the north pole.</description></item><item><description>The z-axis points in an arbitrary direction through the
    /// equator.</description></item></list>
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame")]
    public ReferenceFrame GetNonRotatingReferenceFrame()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<ReferenceFrame>("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to this celestial body, and
    /// orientated in a fixed direction (it does not rotate with the body).
    /// <list type="bullet"><item><description>The origin is at the center of the body.</description></item><item><description>The axes do not rotate.</description></item><item><description>The x-axis points in an arbitrary direction through the
    /// equator.</description></item><item><description>The y-axis points from the center of the body towards
    /// the north pole.</description></item><item><description>The z-axis points in an arbitrary direction through the
    /// equator.</description></item></list>
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame")]
    public async Task<ReferenceFrame> GetNonRotatingReferenceFrameAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<ReferenceFrame>("SpaceCenter", "CelestialBody_get_NonRotatingReferenceFrame", args);
    }

    /// <summary>
    /// Gets the orbit of the body.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Orbit")]
    public Orbit GetOrbit()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Orbit>("SpaceCenter", "CelestialBody_get_Orbit", args);
    }

    /// <summary>
    /// Gets the orbit of the body.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Orbit")]
    public async Task<Orbit> GetOrbitAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Orbit>("SpaceCenter", "CelestialBody_get_Orbit", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to this celestial body, but
    /// orientated with the body's orbital prograde/normal/radial directions.
    /// <list type="bullet"><item><description>The origin is at the center of the body.
    /// </description></item><item><description>The axes rotate with the orbital prograde/normal/radial
    /// directions.</description></item><item><description>The x-axis points in the orbital anti-radial direction.
    /// </description></item><item><description>The y-axis points in the orbital prograde direction.
    /// </description></item><item><description>The z-axis points in the orbital normal direction.
    /// </description></item></list>
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame")]
    public ReferenceFrame GetOrbitalReferenceFrame()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<ReferenceFrame>("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to this celestial body, but
    /// orientated with the body's orbital prograde/normal/radial directions.
    /// <list type="bullet"><item><description>The origin is at the center of the body.
    /// </description></item><item><description>The axes rotate with the orbital prograde/normal/radial
    /// directions.</description></item><item><description>The x-axis points in the orbital anti-radial direction.
    /// </description></item><item><description>The y-axis points in the orbital prograde direction.
    /// </description></item><item><description>The z-axis points in the orbital normal direction.
    /// </description></item></list>
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame")]
    public async Task<ReferenceFrame> GetOrbitalReferenceFrameAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<ReferenceFrame>("SpaceCenter", "CelestialBody_get_OrbitalReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the celestial body.
    /// <list type="bullet"><item><description>The origin is at the center of the body.
    /// </description></item><item><description>The axes rotate with the body.</description></item><item><description>The x-axis points from the center of the body
    /// towards the intersection of the prime meridian and equator (the
    /// position at 0° longitude, 0° latitude).</description></item><item><description>The y-axis points from the center of the body
    /// towards the north pole.</description></item><item><description>The z-axis points from the center of the body
    /// towards the equator at 90°E longitude.</description></item></list>
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_ReferenceFrame")]
    public ReferenceFrame GetReferenceFrame()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<ReferenceFrame>("SpaceCenter", "CelestialBody_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the celestial body.
    /// <list type="bullet"><item><description>The origin is at the center of the body.
    /// </description></item><item><description>The axes rotate with the body.</description></item><item><description>The x-axis points from the center of the body
    /// towards the intersection of the prime meridian and equator (the
    /// position at 0° longitude, 0° latitude).</description></item><item><description>The y-axis points from the center of the body
    /// towards the north pole.</description></item><item><description>The z-axis points from the center of the body
    /// towards the equator at 90°E longitude.</description></item></list>
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_ReferenceFrame")]
    public async Task<ReferenceFrame> GetReferenceFrameAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<ReferenceFrame>("SpaceCenter", "CelestialBody_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets the current rotation angle of the body.
    /// A value between 0 and <math>2\pi</math>
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_get_RotationAngle")]
    public Angle GetRotationAngle()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_RotationAngle", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the current rotation angle of the body.
    /// A value between 0 and <math>2\pi</math>
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_get_RotationAngle")]
    public async Task<Angle> GetRotationAngleAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_RotationAngle", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the sidereal rotational period of the body, in seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_RotationalPeriod")]
    public double GetRotationalPeriod()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_RotationalPeriod", args);
    }

    /// <summary>
    /// Gets the sidereal rotational period of the body, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_RotationalPeriod")]
    public async Task<double> GetRotationalPeriodAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_RotationalPeriod", args);
    }

    /// <summary>
    /// Gets the rotational speed of the body as an angle per second.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_get_RotationalSpeed")]
    public Angle GetRotationalSpeed()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_RotationalSpeed", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets the rotational speed of the body as an angle per second.
    /// Executes asynchronously.
    /// </summary>
    [AngleConversion(AngleType.Radians, typeof(double))]
    [GetRpc("SpaceCenter", "CelestialBody_get_RotationalSpeed")]
    public async Task<Angle> GetRotationalSpeedAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_RotationalSpeed", args);
        return Angle.FromRadians(result);
    }

    /// <summary>
    /// Gets a list of celestial bodies that are in orbit around this celestial body.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Satellites")]
    public IList<CelestialBody> GetSatellites()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<CelestialBody>>("SpaceCenter", "CelestialBody_get_Satellites", args);
    }

    /// <summary>
    /// Gets a list of celestial bodies that are in orbit around this celestial body.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_Satellites")]
    public async Task<IList<CelestialBody>> GetSatellitesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<CelestialBody>>("SpaceCenter", "CelestialBody_get_Satellites", args);
    }

    /// <summary>
    /// Gets the altitude, in meters, above which a vessel is considered to be
    /// in "high" space when doing science.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold")]
    public float GetSpaceHighAltitudeThreshold()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold", args);
    }

    /// <summary>
    /// Gets the altitude, in meters, above which a vessel is considered to be
    /// in "high" space when doing science.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold")]
    public async Task<float> GetSpaceHighAltitudeThresholdAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "CelestialBody_get_SpaceHighAltitudeThreshold", args);
    }

    /// <summary>
    /// Gets the radius of the sphere of influence of the body, in meters.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_SphereOfInfluence")]
    public double GetSphereOfInfluence()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_SphereOfInfluence", args);
    }

    /// <summary>
    /// Gets the radius of the sphere of influence of the body, in meters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_SphereOfInfluence")]
    public async Task<double> GetSphereOfInfluenceAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_SphereOfInfluence", args);
    }

    /// <summary>
    /// Gets the acceleration due to gravity at sea level (mean altitude) on the body,
    /// in <math>m/s^2</math>.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_SurfaceGravity")]
    public double GetSurfaceGravity()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<double>("SpaceCenter", "CelestialBody_get_SurfaceGravity", args);
    }

    /// <summary>
    /// Gets the acceleration due to gravity at sea level (mean altitude) on the body,
    /// in <math>m/s^2</math>.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "CelestialBody_get_SurfaceGravity")]
    public async Task<double> GetSurfaceGravityAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<double>("SpaceCenter", "CelestialBody_get_SurfaceGravity", args);
    }
}
