using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Utilities;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;

namespace KrpcCommand.Extensions;

public static class BodyExtensions
{
    /// <summary>
    /// Calculates the altitude of a particular position in the given reference frame above the body at a particular
    /// time, taking into account its rotation (if any)
    /// </summary>
    /// <param name="body">The body for which to calculate the altitude</param>
    /// <param name="ut">The universal time at which the altitude is needed</param>
    /// <param name="position">The position to calculate the altitude for</param>
    /// <param name="referenceFrame">The reference frame the position is provided in</param>
    /// <returns>The altitude in meters</returns>
    public static double AltitudeAtPositionAt(this CelestialBody body, 
        double ut, 
        Tuple<double, double, double> position,
        ReferenceFrame referenceFrame)
    {
        // Not sure if this is needed yet
        throw new NotImplementedException();
    }

    /// <summary>
    /// Calculates what the position at the provided altitude above the provided lat/lng will be at the provided time,
    /// taking into account the rotation of the body (if any).
    /// </summary>
    /// <param name="body">The body for which to calculate the position</param>
    /// <param name="ut">The universal timestamp at which to calculate the position, in seconds</param>
    /// <param name="latitude">The latitude for which to calculate the position in degrees</param>
    /// <param name="longitude">The longitude for which to calculate the position in degrees</param>
    /// <param name="altitude">The altitude above the surface for which to calculate the position in meters</param>
    /// <param name="referenceFrame">The reference frame in which to provide the position</param>
    /// <returns></returns>
    public static Tuple<double, double, double> PositionAtAltitudeAt(this CelestialBody body,
        double ut,
        double latitude,
        double longitude,
        double altitude,
        ReferenceFrame referenceFrame)
    {
        // Calculate what the rotation of the body will be at the provided time vs now
        var rotationThen = body.RotationAngleAt(ut);
        var rotationNow = body.RotationAngle;
        var rotationDelta = rotationThen - rotationNow;
        
        // Calculate what position would be right now
        var position = 
            body.PositionAtAltitude(latitude, longitude, altitude, referenceFrame);
        
        // Get the axis of rotation for the body
        var axis = body.SurfacePosition(90, 0, referenceFrame)
            .ToVector3D()
            .Normalize();
        
        // Rotate the position by the rotation delta
        var positionVector = position.ToVector3D().Rotate(axis, Angle.FromRadians(rotationDelta));
        
        return new Tuple<double, double, double>(positionVector.X, positionVector.Y, positionVector.Z);
    }

    /// <summary>
    /// Returns the rotation of the body at the provided universal time
    /// </summary>
    /// <param name="body">The body to calculate the rotation of</param>
    /// <param name="ut">The universal time at which to calculate the rotation in seconds</param>
    /// <returns>The rotation in radians, between 0 and 2 Pi</returns>
    public static double RotationAngleAt(this CelestialBody body, double ut)
    {
        var initialRot = body.InitialRotation;
        var rotSpeed = body.RotationalSpeed;

        var finalRot = initialRot + (rotSpeed * ut);
        return MathUtil.Wrap(finalRot, 0, 2 * Math.PI);
    }

    /// <summary>
    /// Calculates the longitude of the point on the surface of the body directly below a particular position, at
    /// a particular time
    /// </summary>
    /// <param name="body">The body to calculate the longitude for</param>
    /// <param name="ut">The universal timestamp at which to calculate the longitude</param>
    /// <param name="position">The position to calculate the longitude of</param>
    /// <param name="referenceFrame">The reference frame of the position vector</param>
    /// <returns>The longitude of the position at the provided time</returns>
    public static double LongitudeAtPositionAt(this CelestialBody body, double ut,
        Tuple<double, double, double> position,
        ReferenceFrame referenceFrame)
    {
        // Get the current longitude
        var lng = body.LongitudeAtPosition(position, referenceFrame);
        
        // Get the rotation delta between now and then
        var rotationNow = body.RotationAngle;
        var rotationThen = body.RotationAngleAt(ut);
        var rotationDelta = rotationThen - rotationNow;
        
        // Subtract the rotation delta from the longitude to get what it will be then
        var deltaDegrees = MathUtil.RadToDeg(rotationDelta);
        var lngThen = lng - deltaDegrees;
        return MathUtil.Wrap(lngThen, -180, 180);
    }

    /// <summary>
    /// Calculates the velocity of the surface of the body at the point below the provided reference point.
    /// </summary>
    /// <param name="body">The body to calculate ths surface velocity of</param>
    /// <param name="ut">The universal timestamp at which to calculate the surface velocity</param>
    /// <param name="position">The point below which to calculate the surface velocity, in the body's non-rotating reference frame</param>
    /// <returns>The velocity of the surface below, in the body's non-rotating reference frame</returns>
    public static Tuple<double, double, double> SurfaceVelocityBelowAt(this CelestialBody body,
        double ut,
        Tuple<double, double, double> position)
    {
        var rf = body.NonRotatingReferenceFrame;
        // Stock bodies in KSP have no axial tilt, so the latitude remains constant no matter the time
        var lat = body.LatitudeAtPosition(position, rf);
        var lngThen = body.LongitudeAtPositionAt(ut, position, rf);
        
        // Calculate the speed from rotational speed at latitude
        var surfaceAltitudeThen = body.SurfacePosition(lat, lngThen, rf).ToVector3D().Length;
        var angle = MathUtil.DegToRad(90 - Math.Abs(lat));
        var ringRadius = surfaceAltitudeThen * Math.Sin(angle);
        var ringCircumference = 2 * Math.PI * ringRadius;
        var speed = ringCircumference / body.RotationalPeriod;
        
        // Use the _current_ longitude when calculating the surface position for direction
        var lngNow = body.LongitudeAtPosition(position, rf);
        var surfacePos = body.SurfacePosition(lat, lngNow, rf).ToVector3D();
        surfacePos = surfaceAltitudeThen * surfacePos.Normalize();
        
        // Calculate the direction from the surface position,
        // on the basis that velocity is always along lines of latitude due to no axial tilt
        var axisLength = surfacePos.Length * Math.Cos(angle);
        var axis = axisLength * new Vector3D(0, 1, 0); // y is "up" in Unity
        var planeOut = surfacePos - axis;
        var direction = axis.CrossProduct(planeOut).Normalize(); // No stock bodies have retrograde rotation
        
        return (speed * direction).ToTuple();
    }
}