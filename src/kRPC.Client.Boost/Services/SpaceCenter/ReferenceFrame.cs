using Google.Protobuf;
using KRPC.Client;
using systemAlias = System;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a reference frame for positions, rotations and
/// velocities. Contains:
/// <list type="bullet"><item><description>The position of the origin.</description></item><item><description>The directions of the x, y and z axes.</description></item><item><description>The linear velocity of the frame.</description></item><item><description>The angular velocity of the frame.</description></item></list></summary>
/// <remarks>
/// This class does not contain any properties or methods. It is only
/// used as a parameter to other functions.
/// </remarks>
public class ReferenceFrame : global::KRPC.Client.RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ReferenceFrame (global::KRPC.Client.IConnection connection, UInt64 id) : base (connection, id)
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReferenceFrame_static_CreateHybrid")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame CreateHybrid (IConnection connection, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame position, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame rotation = null, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame velocity = null, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame angularVelocity = null)
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (position, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)),
            global::KRPC.Client.Encoder.Encode (rotation, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)),
            global::KRPC.Client.Encoder.Encode (velocity, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)),
            global::KRPC.Client.Encoder.Encode (angularVelocity, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ReferenceFrame_static_CreateHybrid", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
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
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "ReferenceFrame_static_CreateRelative")]
    public static global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame CreateRelative (IConnection connection, global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame referenceFrame, systemAlias::Tuple<double,double,double> position = null, systemAlias::Tuple<double,double,double,double> rotation = null, systemAlias::Tuple<double,double,double> velocity = null, systemAlias::Tuple<double,double,double> angularVelocity = null)
    {
        if (connection == null)
            throw new ArgumentNullException (nameof (connection));
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (referenceFrame, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)),
            global::KRPC.Client.Encoder.Encode (position ?? new systemAlias::Tuple<double,double,double> (0.0, 0.0, 0.0), typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (rotation ?? new systemAlias::Tuple<double,double,double,double> (0.0, 0.0, 0.0, 1.0), typeof(systemAlias::Tuple<double,double,double,double>)),
            global::KRPC.Client.Encoder.Encode (velocity ?? new systemAlias::Tuple<double,double,double> (0.0, 0.0, 0.0), typeof(systemAlias::Tuple<double,double,double>)),
            global::KRPC.Client.Encoder.Encode (angularVelocity ?? new systemAlias::Tuple<double,double,double> (0.0, 0.0, 0.0), typeof(systemAlias::Tuple<double,double,double>))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "ReferenceFrame_static_CreateRelative", _args);
        return (global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.ReferenceFrame), connection);
    }
}