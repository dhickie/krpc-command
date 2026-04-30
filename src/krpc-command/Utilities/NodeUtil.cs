using KRPC.Client.Services.SpaceCenter;
using KrpcCommand.Extensions;
using MathNet.Spatial.Euclidean;

namespace KrpcCommand.Utilities;

public static class NodeUtil
{
    /// <summary>
    /// Creates a manoeuvre node at the specified universal time for the specified ship, such that the ship's
    /// velocity after the burn is the provided target velocity.
    /// Assumes that the velocity vector is in the non-rotating reference frame of the body being orbited at the time
    /// of the burn.
    /// </summary>
    /// <param name="ship">The ship that will perform the burn</param>
    /// <param name="ut">The universal timestamp at which the burn should be performed</param>
    /// <param name="targetVelocity">The target velocity of the ship after the burn, in the non-rotating reference
    /// frame of the body being orbited at the time of the burn</param>
    public static void CreateNodeFromTargetVelocity(Vessel ship, double ut, Vector3D targetVelocity)
    {
        var body = ship.Orbit.Body;
        
        var preVel = ship.VelocityAt(ut).ToVector3D();
        var burn = targetVelocity - preVel;
        
        var pHat = preVel.Normalize();
        var rHat = ship.Orbit.PositionAt(ut, body.NonRotatingReferenceFrame).ToVector3D().Normalize();
        var nHat = ship.OrbitNormal().ToVector3D().Normalize();

        var prograde = burn.DotProduct(pHat);
        var radial = burn.DotProduct(rHat);
        var normal = burn.DotProduct(nHat);

        ship.Control.AddNode(ut, (float)prograde, (float)normal, (float)radial);
    }
}