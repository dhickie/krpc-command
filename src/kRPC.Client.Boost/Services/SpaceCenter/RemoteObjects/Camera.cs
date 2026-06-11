using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;
using MathNet.Spatial.Units;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// Controls the game's camera.
/// Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.SpaceCenter.GetCamera" />.
/// </summary>
public class Camera : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal Camera(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Default distance from the camera to the subject, in meters.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_DefaultDistance")]
    public float GetDefaultDistance()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "Camera_get_DefaultDistance", args);
    }

    /// <summary>
    /// Default distance from the camera to the subject, in meters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_DefaultDistance")]
    public async Task<float> GetDefaultDistanceAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "Camera_get_DefaultDistance", args);
    }

    /// <summary>
    /// Gets the distance from the camera to the subject, in meters.
    /// A value between <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMinDistance" /> and <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMaxDistance" />.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_Distance")]
    public float GetDistance()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "Camera_get_Distance", args);
    }

    /// <summary>
    /// Gets the distance from the camera to the subject, in meters.
    /// A value between <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMinDistance" /> and <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMaxDistance" />.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_Distance")]
    public async Task<float> GetDistanceAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "Camera_get_Distance", args);
    }

    /// <summary>
    /// Sets the distance from the camera to the subject, in meters.
    /// A value between <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMinDistance" /> and <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMaxDistance" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_Distance")]
    public void SetDistance(float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "Camera_set_Distance", args);
    }

    /// <summary>
    /// Sets the distance from the camera to the subject, in meters.
    /// A value between <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMinDistance" /> and <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMaxDistance" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_Distance")]
    public async Task SetDistanceAsync(float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "Camera_set_Distance", args);
    }

    /// <summary>
    /// In map mode, the celestial body that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a celestial body.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_FocussedBody")]
    public CelestialBody? GetFocussedBody()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNullable<CelestialBody>("SpaceCenter", "Camera_get_FocussedBody", args);
    }

    /// <summary>
    /// In map mode, the celestial body that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a celestial body.
    /// Returns an error is the camera is not in map mode.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_FocussedBody")]
    public async Task<CelestialBody?> GetFocussedBodyAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNullableAsync<CelestialBody>("SpaceCenter", "Camera_get_FocussedBody", args);
    }

    /// <summary>
    /// Sets in map mode, the celestial body that the camera is focussed on.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_FocussedBody")]
    public void SetFocussedBody(CelestialBody value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "Camera_set_FocussedBody", args);
    }

    /// <summary>
    /// Sets in map mode, the celestial body that the camera is focussed on.
    /// Returns an error is the camera is not in map mode.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_FocussedBody")]
    public async Task SetFocussedBodyAsync(CelestialBody value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "Camera_set_FocussedBody", args);
    }

    /// <summary>
    /// In map mode, the maneuver node that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a maneuver node.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_FocussedNode")]
    public Node? GetFocussedNode()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNullable<Node>("SpaceCenter", "Camera_get_FocussedNode", args);
    }

    /// <summary>
    /// In map mode, the maneuver node that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a maneuver node.
    /// Returns an error is the camera is not in map mode.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_FocussedNode")]
    public async Task<Node?> GetFocussedNodeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNullableAsync<Node>("SpaceCenter", "Camera_get_FocussedNode", args);
    }

    /// <summary>
    /// Sets in map mode, the maneuver node that the camera is focussed on.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_FocussedNode")]
    public void SetFocussedNode(Node value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "Camera_set_FocussedNode", args);
    }

    /// <summary>
    /// Sets in map mode, the maneuver node that the camera is focussed on.
    /// Returns an error is the camera is not in map mode.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_FocussedNode")]
    public async Task SetFocussedNodeAsync(Node value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "Camera_set_FocussedNode", args);
    }

    /// <summary>
    /// In map mode, the vessel that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a vessel.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_FocussedVessel")]
    public Vessel? GetFocussedVessel()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNullable<Vessel>("SpaceCenter", "Camera_get_FocussedVessel", args);
    }

    /// <summary>
    /// In map mode, the vessel that the camera is focussed on.
    /// Returns <c>null</c> if the camera is not focussed on a vessel.
    /// Returns an error is the camera is not in map mode.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_FocussedVessel")]
    public async Task<Vessel?> GetFocussedVesselAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNullableAsync<Vessel>("SpaceCenter", "Camera_get_FocussedVessel", args);
    }

    /// <summary>
    /// Sets in map mode, the vessel that the camera is focussed on.
    /// Returns an error is the camera is not in map mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_FocussedVessel")]
    public void SetFocussedVessel(Vessel value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "Camera_set_FocussedVessel", args);
    }

    /// <summary>
    /// Sets in map mode, the vessel that the camera is focussed on.
    /// Returns an error is the camera is not in map mode.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_FocussedVessel")]
    public async Task SetFocussedVesselAsync(Vessel value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "Camera_set_FocussedVessel", args);
    }

    /// <summary>
    /// Gets the heading of the camera.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_Heading")]
    public Angle GetHeading()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<float>("SpaceCenter", "Camera_get_Heading", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the heading of the camera.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_Heading")]
    public async Task<Angle> GetHeadingAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<float>("SpaceCenter", "Camera_get_Heading", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Sets the heading of the camera.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_Heading")]
    public void SetHeading(Angle value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            (float)value.Degrees
        };
        InvokeVoid("SpaceCenter", "Camera_set_Heading", args);
    }

    /// <summary>
    /// Sets the heading of the camera.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_Heading")]
    public async Task SetHeadingAsync(Angle value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            (float)value.Degrees
        };
        await InvokeVoidAsync("SpaceCenter", "Camera_set_Heading", args);
    }

    /// <summary>
    /// Gets the maximum distance from the camera to the subject, in meters.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_MaxDistance")]
    public float GetMaxDistance()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "Camera_get_MaxDistance", args);
    }

    /// <summary>
    /// Gets the maximum distance from the camera to the subject, in meters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_MaxDistance")]
    public async Task<float> GetMaxDistanceAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "Camera_get_MaxDistance", args);
    }

    /// <summary>
    /// Gets the maximum pitch of the camera.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_MaxPitch")]
    public Angle GetMaxPitch()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<float>("SpaceCenter", "Camera_get_MaxPitch", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the maximum pitch of the camera.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_MaxPitch")]
    public async Task<Angle> GetMaxPitchAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<float>("SpaceCenter", "Camera_get_MaxPitch", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the minimum distance from the camera to the subject, in meters.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_MinDistance")]
    public float GetMinDistance()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "Camera_get_MinDistance", args);
    }

    /// <summary>
    /// Gets the minimum distance from the camera to the subject, in meters.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_MinDistance")]
    public async Task<float> GetMinDistanceAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "Camera_get_MinDistance", args);
    }

    /// <summary>
    /// Gets the minimum pitch of the camera.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_MinPitch")]
    public Angle GetMinPitch()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<float>("SpaceCenter", "Camera_get_MinPitch", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the minimum pitch of the camera.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_MinPitch")]
    public async Task<Angle> GetMinPitchAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<float>("SpaceCenter", "Camera_get_MinPitch", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the current mode of the camera.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_Mode")]
    public CameraMode GetMode()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<CameraMode>("SpaceCenter", "Camera_get_Mode", args);
    }

    /// <summary>
    /// Gets the current mode of the camera.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_Mode")]
    public async Task<CameraMode> GetModeAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<CameraMode>("SpaceCenter", "Camera_get_Mode", args);
    }

    /// <summary>
    /// Sets the current mode of the camera.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_Mode")]
    public void SetMode(CameraMode value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "Camera_set_Mode", args);
    }

    /// <summary>
    /// Sets the current mode of the camera.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_Mode")]
    public async Task SetModeAsync(CameraMode value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "Camera_set_Mode", args);
    }

    /// <summary>
    /// Gets the pitch of the camera.
    /// A value between <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMinPitch" /> and <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMaxPitch" />
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_Pitch")]
    public Angle GetPitch()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = InvokeNonNullable<float>("SpaceCenter", "Camera_get_Pitch", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the pitch of the camera.
    /// A value between <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMinPitch" /> and <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMaxPitch" />
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "Camera_get_Pitch")]
    public async Task<Angle> GetPitchAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        var result = await InvokeNonNullableAsync<float>("SpaceCenter", "Camera_get_Pitch", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Sets the pitch of the camera.
    /// A value between <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMinPitch" /> and <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMaxPitch" />
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_Pitch")]
    public void SetPitch(Angle value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            (float)value.Degrees
        };
        InvokeVoid("SpaceCenter", "Camera_set_Pitch", args);
    }

    /// <summary>
    /// Sets the pitch of the camera.
    /// A value between <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMinPitch" /> and <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Camera.GetMaxPitch" />
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "Camera_set_Pitch")]
    public async Task SetPitchAsync(Angle value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            (float)value.Degrees
        };
        await InvokeVoidAsync("SpaceCenter", "Camera_set_Pitch", args);
    }
}
