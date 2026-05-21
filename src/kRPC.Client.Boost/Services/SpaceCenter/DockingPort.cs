using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A docking port. Obtained by calling <see cref="M:SpaceCenter.Part.GetDockingPort" /></summary>
public class DockingPort : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public DockingPort(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// The direction that docking port points in, in the given reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [Rpc("SpaceCenter", "DockingPort_Direction")]
    public Vector3D Direction(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "DockingPort_Direction", args);
    }

    /// <summary>
    /// The direction that docking port points in, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [Rpc("SpaceCenter", "DockingPort_Direction")]
    public async Task<Vector3D> DirectionAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "DockingPort_Direction", args);
    }

    /// <summary>
    /// The position of the docking port, in the given reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [Rpc("SpaceCenter", "DockingPort_Position")]
    public Vector3D Position(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "DockingPort_Position", args);
    }

    /// <summary>
    /// The position of the docking port, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [Rpc("SpaceCenter", "DockingPort_Position")]
    public async Task<Vector3D> PositionAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "DockingPort_Position", args);
    }

    /// <summary>
    /// The rotation of the docking port, in the given reference frame.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [Rpc("SpaceCenter", "DockingPort_Rotation")]
    public Quaternion Rotation(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Quaternion>("SpaceCenter", "DockingPort_Rotation", args);
    }

    /// <summary>
    /// The rotation of the docking port, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [Rpc("SpaceCenter", "DockingPort_Rotation")]
    public async Task<Quaternion> RotationAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Quaternion>("SpaceCenter", "DockingPort_Rotation", args);
    }

    /// <summary>
    /// Undocks the docking port and returns the new <see cref="T:SpaceCenter.Vessel" /> that is created.
    /// This method can be called for either docking port in a docked pair.
    /// Throws an exception if the docking port is not docked to anything.
    /// </summary>
    /// <remarks>
    /// When called, the active vessel may change. It is therefore possible that,
    /// after calling this function, the object(s) returned by previous call(s) to
    /// <see cref="M:SpaceCenter.GetActiveVessel" /> no longer refer to the active vessel.
    /// </remarks>
    [Rpc("SpaceCenter", "DockingPort_Undock")]
    public Vessel Undock()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Vessel>("SpaceCenter", "DockingPort_Undock", args);
    }

    /// <summary>
    /// Undocks the docking port and returns the new <see cref="T:SpaceCenter.Vessel" /> that is created.
    /// This method can be called for either docking port in a docked pair.
    /// Throws an exception if the docking port is not docked to anything.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// When called, the active vessel may change. It is therefore possible that,
    /// after calling this function, the object(s) returned by previous call(s) to
    /// <see cref="M:SpaceCenter.GetActiveVessel" /> no longer refer to the active vessel.
    /// </remarks>
    [Rpc("SpaceCenter", "DockingPort_Undock")]
    public async Task<Vessel> UndockAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Vessel>("SpaceCenter", "DockingPort_Undock", args);
    }

    /// <summary>
    /// Gets whether the docking port can be commanded to rotate while docked.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_CanRotate")]
    public bool GetCanRotate()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "DockingPort_get_CanRotate", args);
    }

    /// <summary>
    /// Gets whether the docking port can be commanded to rotate while docked.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_CanRotate")]
    public async Task<bool> GetCanRotateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "DockingPort_get_CanRotate", args);
    }

    /// <summary>
    /// Gets the part that this docking port is docked to. Returns <c>null</c> if this
    /// docking port is not docked to anything.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_DockedPart")]
    public Part? GetDockedPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part?>("SpaceCenter", "DockingPort_get_DockedPart", args);
    }

    /// <summary>
    /// Gets the part that this docking port is docked to. Returns <c>null</c> if this
    /// docking port is not docked to anything.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_DockedPart")]
    public async Task<Part?> GetDockedPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part?>("SpaceCenter", "DockingPort_get_DockedPart", args);
    }

    /// <summary>
    /// Gets whether the docking port has a shield.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_HasShield")]
    public bool GetHasShield()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "DockingPort_get_HasShield", args);
    }

    /// <summary>
    /// Gets whether the docking port has a shield.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_HasShield")]
    public async Task<bool> GetHasShieldAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "DockingPort_get_HasShield", args);
    }

    /// <summary>
    /// Gets the maximum rotation angle.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_MaximumRotation")]
    public Angle GetMaximumRotation()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "DockingPort_get_MaximumRotation", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the maximum rotation angle.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_MaximumRotation")]
    public async Task<Angle> GetMaximumRotationAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "DockingPort_get_MaximumRotation", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the minimum rotation angle.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_MinimumRotation")]
    public Angle GetMinimumRotation()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "DockingPort_get_MinimumRotation", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the minimum rotation angle.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_MinimumRotation")]
    public async Task<Angle> GetMinimumRotationAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "DockingPort_get_MinimumRotation", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the part object for this docking port.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "DockingPort_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this docking port.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "DockingPort_get_Part", args);
    }

    /// <summary>
    /// Gets the distance a docking port must move away when it undocks before it
    /// becomes ready to dock with another port, in meters.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_ReengageDistance")]
    public float GetReengageDistance()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "DockingPort_get_ReengageDistance", args);
    }

    /// <summary>
    /// Gets the distance a docking port must move away when it undocks before it
    /// becomes ready to dock with another port, in meters.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_ReengageDistance")]
    public async Task<float> GetReengageDistanceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "DockingPort_get_ReengageDistance", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to this docking port, and
    /// oriented with the port.
    /// <list type="bullet"><item><description>The origin is at the position of the docking port.
    /// </description></item><item><description>The axes rotate with the docking port.</description></item><item><description>The x-axis points out to the right side of the docking port.
    /// </description></item><item><description>The y-axis points in the direction the docking port is facing.
    /// </description></item><item><description>The z-axis points out of the bottom off the docking port.
    /// </description></item></list>
    /// </summary>
    /// <remarks>
    /// This reference frame is not necessarily equivalent to the reference frame
    /// for the part, returned by <see cref="M:SpaceCenter.Part.GetReferenceFrame" />.
    /// </remarks>
    [Rpc("SpaceCenter", "DockingPort_get_ReferenceFrame")]
    public ReferenceFrame GetReferenceFrame()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ReferenceFrame>("SpaceCenter", "DockingPort_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to this docking port, and
    /// oriented with the port.
    /// <list type="bullet"><item><description>The origin is at the position of the docking port.
    /// </description></item><item><description>The axes rotate with the docking port.</description></item><item><description>The x-axis points out to the right side of the docking port.
    /// </description></item><item><description>The y-axis points in the direction the docking port is facing.
    /// </description></item><item><description>The z-axis points out of the bottom off the docking port.
    /// </description></item></list>
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This reference frame is not necessarily equivalent to the reference frame
    /// for the part, returned by <see cref="M:SpaceCenter.Part.GetReferenceFrame" />.
    /// </remarks>
    [Rpc("SpaceCenter", "DockingPort_get_ReferenceFrame")]
    public async Task<ReferenceFrame> GetReferenceFrameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ReferenceFrame>("SpaceCenter", "DockingPort_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Lock rotation. When locked, allows auto-strut to work across the joint.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_RotationLocked")]
    public bool GetRotationLocked()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "DockingPort_get_RotationLocked", args);
    }

    /// <summary>
    /// Lock rotation. When locked, allows auto-strut to work across the joint.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_RotationLocked")]
    public async Task<bool> GetRotationLockedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "DockingPort_get_RotationLocked", args);
    }

    /// <summary>
    /// Sets whether rotation is locked. When locked, allows auto-strut to work across the joint.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "DockingPort_set_RotationLocked")]
    public void SetRotationLocked(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "DockingPort_set_RotationLocked", args);
    }

    /// <summary>
    /// Sets whether rotation is locked. When locked, allows auto-strut to work across the joint.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "DockingPort_set_RotationLocked")]
    public async Task SetRotationLockedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "DockingPort_set_RotationLocked", args);
    }

    /// <summary>
    /// Gets the rotation target angle.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_RotationTarget")]
    public Angle GetRotationTarget()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "DockingPort_get_RotationTarget", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the rotation target angle.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_RotationTarget")]
    public async Task<Angle> GetRotationTargetAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "DockingPort_get_RotationTarget", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Sets the rotation target angle.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "DockingPort_set_RotationTarget")]
    public void SetRotationTarget(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        Connection.Invoke("SpaceCenter", "DockingPort_set_RotationTarget", args);
    }

    /// <summary>
    /// Sets the rotation target angle.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "DockingPort_set_RotationTarget")]
    public async Task SetRotationTargetAsync(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        await Connection.InvokeAsync("SpaceCenter", "DockingPort_set_RotationTarget", args);
    }

    /// <summary>
    /// Gets the state of the docking ports shield, if it has one.
    ///
    /// Returns <c>true</c> if the docking port has a shield, and the shield is
    /// closed. Otherwise returns <c>false</c>. When set to <c>true</c>, the shield is
    /// closed, and when set to <c>false</c> the shield is opened. If the docking
    /// port does not have a shield, setting this attribute has no effect.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_Shielded")]
    public bool GetShielded()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "DockingPort_get_Shielded", args);
    }

    /// <summary>
    /// Gets the state of the docking ports shield, if it has one.
    ///
    /// Returns <c>true</c> if the docking port has a shield, and the shield is
    /// closed. Otherwise returns <c>false</c>. When set to <c>true</c>, the shield is
    /// closed, and when set to <c>false</c> the shield is opened. If the docking
    /// port does not have a shield, setting this attribute has no effect.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_Shielded")]
    public async Task<bool> GetShieldedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "DockingPort_get_Shielded", args);
    }

    /// <summary>
    /// Sets the state of the docking ports shield, if it has one.
    ///
    /// Returns <c>true</c> if the docking port has a shield, and the shield is
    /// closed. Otherwise returns <c>false</c>. When set to <c>true</c>, the shield is
    /// closed, and when set to <c>false</c> the shield is opened. If the docking
    /// port does not have a shield, setting this attribute has no effect.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "DockingPort_set_Shielded")]
    public void SetShielded(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "DockingPort_set_Shielded", args);
    }

    /// <summary>
    /// Sets the state of the docking ports shield, if it has one.
    ///
    /// Returns <c>true</c> if the docking port has a shield, and the shield is
    /// closed. Otherwise returns <c>false</c>. When set to <c>true</c>, the shield is
    /// closed, and when set to <c>false</c> the shield is opened. If the docking
    /// port does not have a shield, setting this attribute has no effect.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "DockingPort_set_Shielded")]
    public async Task SetShieldedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "DockingPort_set_Shielded", args);
    }

    /// <summary>
    /// Gets the current state of the docking port.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_State")]
    public DockingPortState GetState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<DockingPortState>("SpaceCenter", "DockingPort_get_State", args);
    }

    /// <summary>
    /// Gets the current state of the docking port.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "DockingPort_get_State")]
    public async Task<DockingPortState> GetStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<DockingPortState>("SpaceCenter", "DockingPort_get_State", args);
    }
}
