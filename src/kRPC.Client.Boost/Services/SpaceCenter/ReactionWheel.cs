using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A reaction wheel. Obtained by calling <see cref="M:SpaceCenter.Part.ReactionWheel" />.
/// </summary>
public class ReactionWheel : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ReactionWheel (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Whether the reaction wheel is active.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ReactionWheel_get_Active")]
    public bool Active {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ReactionWheel_get_Active", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ReactionWheel_set_Active", args);
        }
    }

    /// <summary>
    /// The available torque, in Newton meters, that can be produced by this reaction wheel,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// Returns zero if the reaction wheel is inactive or broken.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ReactionWheel_get_AvailableTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableTorque {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "ReactionWheel_get_AvailableTorque", args);
        }
    }

    /// <summary>
    /// Whether the reaction wheel is broken.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ReactionWheel_get_Broken")]
    public bool Broken {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ReactionWheel_get_Broken", args);
        }
    }

    /// <summary>
    /// The maximum torque, in Newton meters, that can be produced by this reaction wheel,
    /// when it is active, in the positive and negative pitch, roll and yaw axes of the vessel.
    /// These axes correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ReactionWheel_get_MaxTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> MaxTorque {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "ReactionWheel_get_MaxTorque", args);
        }
    }

    /// <summary>
    /// The part object for this reaction wheel.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ReactionWheel_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "ReactionWheel_get_Part", args);
        }
    }
}
