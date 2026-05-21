using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An aerodynamic control surface. Obtained by calling <see cref="M:SpaceCenter.Part.ControlSurface" />.
/// </summary>
public class ControlSurface : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ControlSurface (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// The authority limiter for the control surface, which controls how far the
    /// control surface will move.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ControlSurface_get_AuthorityLimiter")]
    public float AuthorityLimiter {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ControlSurface_get_AuthorityLimiter", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ControlSurface_set_AuthorityLimiter", args);
        }
    }

    /// <summary>
    /// The available torque, in Newton meters, that can be produced by this control surface,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.ReferenceFrame" />.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ControlSurface_get_AvailableTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> AvailableTorque {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> ("SpaceCenter", "ControlSurface_get_AvailableTorque", args);
        }
    }

    /// <summary>
    /// Whether the control surface has been fully deployed.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ControlSurface_get_Deployed")]
    public bool Deployed {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ControlSurface_get_Deployed", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ControlSurface_set_Deployed", args);
        }
    }

    /// <summary>
    /// Whether the control surface movement is inverted.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ControlSurface_get_Inverted")]
    public bool Inverted {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ControlSurface_get_Inverted", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ControlSurface_set_Inverted", args);
        }
    }

    /// <summary>
    /// The part object for this control surface.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ControlSurface_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "ControlSurface_get_Part", args);
        }
    }

    /// <summary>
    /// Whether the control surface has pitch control enabled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ControlSurface_get_PitchEnabled")]
    public bool PitchEnabled {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ControlSurface_get_PitchEnabled", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ControlSurface_set_PitchEnabled", args);
        }
    }

    /// <summary>
    /// Whether the control surface has roll control enabled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ControlSurface_get_RollEnabled")]
    public bool RollEnabled {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ControlSurface_get_RollEnabled", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ControlSurface_set_RollEnabled", args);
        }
    }

    /// <summary>
    /// Surface area of the control surface in <math>m^2</math>.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ControlSurface_get_SurfaceArea")]
    public float SurfaceArea {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "ControlSurface_get_SurfaceArea", args);
        }
    }

    /// <summary>
    /// Whether the control surface has yaw control enabled.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "ControlSurface_get_YawEnabled")]
    public bool YawEnabled {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<bool> ("SpaceCenter", "ControlSurface_get_YawEnabled", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "ControlSurface_set_YawEnabled", args);
        }
    }
}
