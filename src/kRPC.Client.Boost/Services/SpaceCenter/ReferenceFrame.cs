using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using KRPC.Client;
using System;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a reference frame for positions, rotations and
/// velocities. Contains:
/// <list type="bullet"><item><description>The position of the origin.</description></item><item><description>The directions of the x, y and z axes.</description></item><item><description>The linear velocity of the frame.</description></item><item><description>The angular velocity of the frame.</description></item></list></summary>
/// <remarks>
/// This class does not contain any properties or methods. It is only
/// used as a parameter to other functions.
/// </remarks>
public class ReferenceFrame : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ReferenceFrame(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Create a hybrid reference frame. This is a custom reference frame
    /// whose components inherited from other reference frames.
    /// </summary>
    /// <param name="position">The reference frame providing the position of the origin.</param>
    /// <param name="rotation">The reference frame providing the rotation of the frame.</param>
    /// <param name="velocity">The reference frame providing the linear velocity of the frame.
    /// </param>
    /// <param name="angularVelocity">The reference frame providing the angular velocity
    /// of the frame.</param>
    /// <remarks>
    /// The <paramref name="position" /> reference frame is required but all other
    /// reference frames are optional. If omitted, they are set to the
    /// <paramref name="position" /> reference frame.
    /// </remarks>
    /// <param name="connection">A connection object.</param>
    [Rpc("SpaceCenter", "ReferenceFrame_static_CreateHybrid")]
    public static ReferenceFrame CreateHybrid(ConnectionMultiplexer connection, ReferenceFrame position, ReferenceFrame rotation = null, ReferenceFrame velocity = null, ReferenceFrame angularVelocity = null)
    {
        if (connection == null)
            throw new ArgumentNullException(nameof(connection));
        var args = new object[]
        {
            position,
            rotation,
            velocity,
            angularVelocity
        };
        return connection.Invoke<ReferenceFrame>("SpaceCenter", "ReferenceFrame_static_CreateHybrid", args);
    }

    /// <summary>
    /// Create a relative reference frame. This is a custom reference frame
    /// whose components offset the components of a parent reference frame.
    /// </summary>
    /// <param name="referenceFrame">The parent reference frame on which to
    /// base this reference frame.</param>
    /// <param name="position">The offset of the position of the origin,
    /// as a position vector. Defaults to <math>(0, 0, 0)</math></param>
    /// <param name="rotation">The rotation to apply to the parent frames rotation,
    /// as a quaternion of the form <math>(x, y, z, w)</math>.
    /// Defaults to <math>(0, 0, 0, 1)</math> (i.e. no rotation)</param>
    /// <param name="velocity">The linear velocity to offset the parent frame by,
    /// as a vector pointing in the direction of travel, whose magnitude is the speed in
    /// meters per second. Defaults to <math>(0, 0, 0)</math>.</param>
    /// <param name="angularVelocity">The angular velocity to offset the parent frame by,
    /// as a vector. This vector points in the direction of the axis of rotation,
    /// and its magnitude is the speed of the rotation in radians per second.
    /// Defaults to <math>(0, 0, 0)</math>.</param>
    /// <param name="connection">A connection object.</param>
    [Rpc("SpaceCenter", "ReferenceFrame_static_CreateRelative")]
    public static ReferenceFrame CreateRelative(ConnectionMultiplexer connection, ReferenceFrame referenceFrame, Tuple<double,double,double> position = null, Tuple<double,double,double,double> rotation = null, Tuple<double,double,double> velocity = null, Tuple<double,double,double> angularVelocity = null)
    {
        if (connection == null)
            throw new ArgumentNullException(nameof(connection));
        var args = new object[]
        {
            referenceFrame,
            position ?? new Tuple<double,double,double>(0.0, 0.0, 0.0),
            rotation ?? new Tuple<double,double,double,double>(0.0, 0.0, 0.0, 1.0),
            velocity ?? new Tuple<double,double,double>(0.0, 0.0, 0.0),
            angularVelocity ?? new Tuple<double,double,double>(0.0, 0.0, 0.0)
        };
        return connection.Invoke<ReferenceFrame>("SpaceCenter", "ReferenceFrame_static_CreateRelative", args);
    }
}
