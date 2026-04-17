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
}