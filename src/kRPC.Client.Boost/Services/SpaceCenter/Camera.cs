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
    [Rpc ("SpaceCenter", "Camera_get_DefaultDistance")]
    public float DefaultDistance {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_DefaultDistance", args);
        }
    }

    /// <summary>
    /// The distance from the camera to the subject, in meters.
    /// A value between <see cref="M:SpaceCenter.Camera.MinDistance" /> and <see cref="M:SpaceCenter.Camera.MaxDistance" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_Distance")]
    public float Distance {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_Distance", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_Distance", args);
        }
    }

    /// <summary>
    /// In map mode, the celestial body that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a celestial body.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_FocussedBody")]
    public CelestialBody FocussedBody {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<CelestialBody> ("SpaceCenter", "Camera_get_FocussedBody", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_FocussedBody", args);
        }
    }

    /// <summary>
    /// In map mode, the maneuver node that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a maneuver node.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_FocussedNode")]
    public Node FocussedNode {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Node> ("SpaceCenter", "Camera_get_FocussedNode", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_FocussedNode", args);
        }
    }

    /// <summary>
    /// In map mode, the vessel that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a vessel.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_FocussedVessel")]
    public Vessel FocussedVessel {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Vessel> ("SpaceCenter", "Camera_get_FocussedVessel", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_FocussedVessel", args);
        }
    }

    /// <summary>
    /// The heading of the camera, in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_Heading")]
    public float Heading {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_Heading", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_Heading", args);
        }
    }

    /// <summary>
    /// Maximum distance from the camera to the subject, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_MaxDistance")]
    public float MaxDistance {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MaxDistance", args);
        }
    }

    /// <summary>
    /// The maximum pitch of the camera.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_MaxPitch")]
    public float MaxPitch {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MaxPitch", args);
        }
    }

    /// <summary>
    /// Minimum distance from the camera to the subject, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_MinDistance")]
    public float MinDistance {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MinDistance", args);
        }
    }

    /// <summary>
    /// The minimum pitch of the camera.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_MinPitch")]
    public float MinPitch {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MinPitch", args);
        }
    }

    /// <summary>
    /// The current mode of the camera.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_Mode")]
    public CameraMode Mode {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<CameraMode> ("SpaceCenter", "Camera_get_Mode", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_Mode", args);
        }
    }

    /// <summary>
    /// The pitch of the camera, in degrees.
    /// A value between <see cref="M:SpaceCenter.Camera.MinPitch" /> and <see cref="M:SpaceCenter.Camera.MaxPitch" /></summary>
    [Rpc ("SpaceCenter", "Camera_get_Pitch")]
    public float Pitch {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<float> ("SpaceCenter", "Camera_get_Pitch", args);
        }
        set {
            var args = new object[] {
                this,
                value
            };
            Connection.Invoke ("SpaceCenter", "Camera_set_Pitch", args);
        }
    }
}
