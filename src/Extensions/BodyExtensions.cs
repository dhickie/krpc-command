using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Utilities;
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
            body.PositionAtAltitude(latitude, longitude, altitude, body.NonRotatingReferenceFrame);
        
        // Get the axis of rotation for the body
        var axis = body.SurfacePosition(90, 0, body.NonRotatingReferenceFrame)
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
    /// <param name="ut">The uniersal time at which to calculate the rotation in seconds</param>
    /// <returns>The rotation in radians, between 0 and 2 Pi</returns>
    public static double RotationAngleAt(this CelestialBody body, double ut)
    {
        var initialRot = body.InitialRotation;
        var rotSpeed = body.RotationalSpeed;

        var finalRot = initialRot + (rotSpeed * ut);
        return MathUtil.Wrap(finalRot, 0, 2 * Math.PI);
    }
}