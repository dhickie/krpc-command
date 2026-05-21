using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Obtained by calling <see cref="M:SpaceCenter.Part.AddForce" />.
/// </summary>
public class Force : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Force (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Remove the force.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Force_Remove")]
    public void Remove ()
    {
        var _args = new object[] {
            this
        };
        Connection.Invoke ("SpaceCenter", "Force_Remove", _args);
    }

    /// <summary>
    /// The force vector, in Newtons.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [RpcAttribute ("SpaceCenter", "Force_get_ForceVector")]
    public Tuple<double,double,double> ForceVector {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Force_get_ForceVector", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Force_set_ForceVector", _args);
        }
    }

    /// <summary>
    /// The part that this force is applied to.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Force_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Force_get_Part", _args);
        }
    }

    /// <summary>
    /// The position at which the force acts, in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    [RpcAttribute ("SpaceCenter", "Force_get_Position")]
    public Tuple<double,double,double> Position {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<double,double,double>> ("SpaceCenter", "Force_get_Position", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Force_set_Position", _args);
        }
    }

    /// <summary>
    /// The reference frame of the force vector and position.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Force_get_ReferenceFrame")]
    public ReferenceFrame ReferenceFrame {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<ReferenceFrame> ("SpaceCenter", "Force_get_ReferenceFrame", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Force_set_ReferenceFrame", _args);
        }
    }
}
