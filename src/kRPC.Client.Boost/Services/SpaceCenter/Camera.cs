using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Controls the game's camera.
/// Obtained by calling <see cref="M:SpaceCenter.Camera" />.
/// </summary>
public class Camera : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Camera (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Default distance from the camera to the subject, in meters.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_DefaultDistance")]
    public float DefaultDistance {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_DefaultDistance", _args);
        }
    }

    /// <summary>
    /// The distance from the camera to the subject, in meters.
    /// A value between <see cref="M:SpaceCenter.Camera.MinDistance" /> and <see cref="M:SpaceCenter.Camera.MaxDistance" />.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_Distance")]
    public float Distance {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_Distance", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_Distance", _args);
        }
    }

    /// <summary>
    /// In map mode, the celestial body that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a celestial body.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_FocussedBody")]
    public CelestialBody FocussedBody {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<CelestialBody> ("SpaceCenter", "Camera_get_FocussedBody", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_FocussedBody", _args);
        }
    }

    /// <summary>
    /// In map mode, the maneuver node that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a maneuver node.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_FocussedNode")]
    public Node FocussedNode {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Node> ("SpaceCenter", "Camera_get_FocussedNode", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_FocussedNode", _args);
        }
    }

    /// <summary>
    /// In map mode, the vessel that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a vessel.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_FocussedVessel")]
    public Vessel FocussedVessel {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Vessel> ("SpaceCenter", "Camera_get_FocussedVessel", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_FocussedVessel", _args);
        }
    }

    /// <summary>
    /// The heading of the camera, in degrees.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_Heading")]
    public float Heading {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_Heading", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_Heading", _args);
        }
    }

    /// <summary>
    /// Maximum distance from the camera to the subject, in meters.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_MaxDistance")]
    public float MaxDistance {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MaxDistance", _args);
        }
    }

    /// <summary>
    /// The maximum pitch of the camera.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_MaxPitch")]
    public float MaxPitch {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MaxPitch", _args);
        }
    }

    /// <summary>
    /// Minimum distance from the camera to the subject, in meters.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_MinDistance")]
    public float MinDistance {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MinDistance", _args);
        }
    }

    /// <summary>
    /// The minimum pitch of the camera.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_MinPitch")]
    public float MinPitch {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MinPitch", _args);
        }
    }

    /// <summary>
    /// The current mode of the camera.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_Mode")]
    public CameraMode Mode {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<CameraMode> ("SpaceCenter", "Camera_get_Mode", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_Mode", _args);
        }
    }

    /// <summary>
    /// The pitch of the camera, in degrees.
    /// A value between <see cref="M:SpaceCenter.Camera.MinPitch" /> and <see cref="M:SpaceCenter.Camera.MaxPitch" /></summary>
    [RpcAttribute ("SpaceCenter", "Camera_get_Pitch")]
    public float Pitch {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_Pitch", _args);
        }
        set {
            var _args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_Pitch", _args);
        }
    }
}
