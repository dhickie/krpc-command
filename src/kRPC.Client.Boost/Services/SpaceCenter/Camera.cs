using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Controls the game's camera.
/// Obtained by calling <see cref="M:SpaceCenter.GetCamera" />.
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
    public float GetDefaultDistance ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Camera_get_DefaultDistance", args);
    }

    /// <summary>
    /// Gets the distance from the camera to the subject, in meters.
    /// A value between <see cref="M:SpaceCenter.Camera.GetMinDistance" /> and <see cref="M:SpaceCenter.Camera.GetMaxDistance" />.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_Distance")]
    public float GetDistance ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Camera_get_Distance", args);
    }

    /// <summary>
    /// Sets the distance from the camera to the subject, in meters.
    /// A value between <see cref="M:SpaceCenter.Camera.GetMinDistance" /> and <see cref="M:SpaceCenter.Camera.GetMaxDistance" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetDistance (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Camera_set_Distance", args);
    }

    /// <summary>
    /// In map mode, the celestial body that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a celestial body.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_FocussedBody")]
    public CelestialBody GetFocussedBody ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<CelestialBody> ("SpaceCenter", "Camera_get_FocussedBody", args);
    }

    /// <summary>
    /// Sets in map mode, the celestial body that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a celestial body.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetFocussedBody (CelestialBody value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Camera_set_FocussedBody", args);
    }

    /// <summary>
    /// In map mode, the maneuver node that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a maneuver node.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_FocussedNode")]
    public Node GetFocussedNode ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Node> ("SpaceCenter", "Camera_get_FocussedNode", args);
    }

    /// <summary>
    /// Sets in map mode, the maneuver node that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a maneuver node.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetFocussedNode (Node value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Camera_set_FocussedNode", args);
    }

    /// <summary>
    /// In map mode, the vessel that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a vessel.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_FocussedVessel")]
    public Vessel GetFocussedVessel ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<Vessel> ("SpaceCenter", "Camera_get_FocussedVessel", args);
    }

    /// <summary>
    /// Sets in map mode, the vessel that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a vessel.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetFocussedVessel (Vessel value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Camera_set_FocussedVessel", args);
    }

    /// <summary>
    /// Gets the heading of the camera, in degrees.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_Heading")]
    public float GetHeading ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Camera_get_Heading", args);
    }

    /// <summary>
    /// Sets the heading of the camera, in degrees.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetHeading (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Camera_set_Heading", args);
    }

    /// <summary>
    /// Gets the maximum distance from the camera to the subject, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_MaxDistance")]
    public float GetMaxDistance ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MaxDistance", args);
    }

    /// <summary>
    /// Gets the maximum pitch of the camera.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_MaxPitch")]
    public float GetMaxPitch ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MaxPitch", args);
    }

    /// <summary>
    /// Gets the minimum distance from the camera to the subject, in meters.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_MinDistance")]
    public float GetMinDistance ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MinDistance", args);
    }

    /// <summary>
    /// Gets the minimum pitch of the camera.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_MinPitch")]
    public float GetMinPitch ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Camera_get_MinPitch", args);
    }

    /// <summary>
    /// Gets the current mode of the camera.
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_Mode")]
    public CameraMode GetMode ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<CameraMode> ("SpaceCenter", "Camera_get_Mode", args);
    }

    /// <summary>
    /// Sets the current mode of the camera.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetMode (CameraMode value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Camera_set_Mode", args);
    }

    /// <summary>
    /// Gets the pitch of the camera, in degrees.
    /// A value between <see cref="M:SpaceCenter.Camera.GetMinPitch" /> and <see cref="M:SpaceCenter.Camera.GetMaxPitch" />
    /// </summary>
    [Rpc ("SpaceCenter", "Camera_get_Pitch")]
    public float GetPitch ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<float> ("SpaceCenter", "Camera_get_Pitch", args);
    }

    /// <summary>
    /// Sets the pitch of the camera, in degrees.
    /// A value between <see cref="M:SpaceCenter.Camera.GetMinPitch" /> and <see cref="M:SpaceCenter.Camera.GetMaxPitch" />
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetPitch (float value)
    {
        var args = new object[] {
            this,
            value
        };
        Connection.Invoke ("SpaceCenter", "Camera_set_Pitch", args);
    }
}
