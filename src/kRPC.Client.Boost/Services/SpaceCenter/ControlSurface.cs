using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An aerodynamic control surface. Obtained by calling <see cref="M:SpaceCenter.Part.GetControlSurface" />.
/// </summary>
public class ControlSurface : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ControlSurface(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets the authority limiter for the control surface, which controls how far the
    /// control surface will move.
    /// </summary>
    [Rpc("SpaceCenter", "ControlSurface_get_AuthorityLimiter")]
    public float GetAuthorityLimiter()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ControlSurface_get_AuthorityLimiter", args);
    }

    /// <summary>
    /// Sets the authority limiter for the control surface, which controls how far the
    /// control surface will move.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetAuthorityLimiter(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ControlSurface_set_AuthorityLimiter", args);
    }

    /// <summary>
    /// Gets the available torque, in Newton meters, that can be produced by this control surface,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// </summary>
    [Rpc("SpaceCenter", "ControlSurface_get_AvailableTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> GetAvailableTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>>("SpaceCenter", "ControlSurface_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets whether the control surface has been fully deployed.
    /// </summary>
    [Rpc("SpaceCenter", "ControlSurface_get_Deployed")]
    public bool GetDeployed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ControlSurface_get_Deployed", args);
    }

    /// <summary>
    /// Sets whether the control surface has been fully deployed.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetDeployed(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ControlSurface_set_Deployed", args);
    }

    /// <summary>
    /// Gets whether the control surface movement is inverted.
    /// </summary>
    [Rpc("SpaceCenter", "ControlSurface_get_Inverted")]
    public bool GetInverted()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ControlSurface_get_Inverted", args);
    }

    /// <summary>
    /// Sets whether the control surface movement is inverted.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetInverted(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ControlSurface_set_Inverted", args);
    }

    /// <summary>
    /// Gets the part object for this control surface.
    /// </summary>
    [Rpc("SpaceCenter", "ControlSurface_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "ControlSurface_get_Part", args);
    }

    /// <summary>
    /// Gets whether the control surface has pitch control enabled.
    /// </summary>
    [Rpc("SpaceCenter", "ControlSurface_get_PitchEnabled")]
    public bool GetPitchEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ControlSurface_get_PitchEnabled", args);
    }

    /// <summary>
    /// Sets whether the control surface has pitch control enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetPitchEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ControlSurface_set_PitchEnabled", args);
    }

    /// <summary>
    /// Gets whether the control surface has roll control enabled.
    /// </summary>
    [Rpc("SpaceCenter", "ControlSurface_get_RollEnabled")]
    public bool GetRollEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ControlSurface_get_RollEnabled", args);
    }

    /// <summary>
    /// Sets whether the control surface has roll control enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRollEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ControlSurface_set_RollEnabled", args);
    }

    /// <summary>
    /// Surface area of the control surface in <math>m^2</math>.
    /// </summary>
    [Rpc("SpaceCenter", "ControlSurface_get_SurfaceArea")]
    public float GetSurfaceArea()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "ControlSurface_get_SurfaceArea", args);
    }

    /// <summary>
    /// Gets whether the control surface has yaw control enabled.
    /// </summary>
    [Rpc("SpaceCenter", "ControlSurface_get_YawEnabled")]
    public bool GetYawEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ControlSurface_get_YawEnabled", args);
    }

    /// <summary>
    /// Sets whether the control surface has yaw control enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetYawEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ControlSurface_set_YawEnabled", args);
    }
}
