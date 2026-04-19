using System.ComponentModel.Design.Serialization;
using KRPC.Client.Services.SpaceCenter;
using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Extensions;

public static class VesselExtensions
{
    /// <summary>
    /// Returns the normal of the ship's current orbital plane
    /// </summary>
    /// <param name="vessel">The ship to calculate the orbit normal of</param>
    /// <returns>The orbit normal</returns>
    public static Tuple<double, double, double> OrbitNormal(this Vessel vessel)
    {
        var body = vessel.Orbit.Body;
        var velocity = vessel.Velocity(body.NonRotatingReferenceFrame).ToVector3D();
        var position = vessel.Position(body.NonRotatingReferenceFrame).ToVector3D();

        var normal = velocity.CrossProduct(position).Normalize();
        
        return new Tuple<double, double, double>(normal.X, normal.Y, normal.Z);
    }

    /// <summary>
    /// Calculates the velocity of the vessel at the provided timestamp, in the non-rotating reference frame
    /// of the body it is currently orbiting.
    /// Assumes that the vessel is currently in a closed orbit.
    /// </summary>
    /// <param name="vessel">The vessel to calculate the velocity of</param>
    /// <param name="ut">The universal timestamp that corresponds to the target moment</param>
    /// <returns>The velocity vector in the orbit's body's non-rotating reference frame</returns>
    public static Tuple<double, double, double> VelocityAt(this Vessel vessel, double ut)
    {
        // Uses Vis-viva for orbital speed combined with this stackexchange answer:
        // https://space.stackexchange.com/questions/63903/calculate-velocity-vector-of-elliptical-orbit-given-the-position-vector-at-that
        var orbit = vessel.Orbit;
        var body = orbit.Body;
        var rFrame = body.NonRotatingReferenceFrame;
        var e = orbit.Eccentricity;
        var pos = vessel.Position(rFrame);
        var vel = vessel.Velocity(rFrame);
        
        // Position unit vector
        var r = orbit.PositionAt(ut, rFrame).ToVector3D();
        var rHat = r.Normalize();
        
        // Perifocal unit vectors
        var pHat = orbit.EccentricityVector(pos, vel).ToVector3D().Normalize();
        var uHat = pHat.CrossProduct(rHat);
        var jHat = new Vector3D(0, 1, 0); // y is "up" in Unity so we use this instead of the z axis

        var wHat = (-uHat).Normalize();
        if ((uHat.DotProduct(jHat) >= 0 && orbit.Inclination <= Math.PI / 2) ||
            (uHat.DotProduct(jHat) < 0 && orbit.Inclination > Math.PI / 2))
        {
            wHat = (-wHat).Normalize();
        }

        var qHat = wHat.CrossProduct(pHat);
        
        // True anomaly
        var theta = Math.Acos(pHat.DotProduct(rHat));
        if (rHat.DotProduct(qHat) < 0)
        {
            theta = -theta;
        }
        
        // Perifocal velocity angle
        var psi = theta;
        psi -= Math.Atan2(e * Math.Sin(theta), 1 + e * Math.Cos(theta));
        psi += Math.PI / 2;
        
        // Speed (Vis-viva)
        var v = body.GravitationalParameter * ((2 / r.Length) - (1 / orbit.SemiMajorAxis));
        v = Math.Sqrt(v);
        
        // Velocity
        var vHat = (Math.Cos(psi) * pHat) + (Math.Sin(psi) * qHat);
        return (v * vHat).ToTuple();
    }
}