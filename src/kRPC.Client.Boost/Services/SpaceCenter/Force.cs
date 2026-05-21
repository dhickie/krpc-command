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
    public Force(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Remove the force.
    /// </summary>
    [Rpc("SpaceCenter", "Force_Remove")]
    public void Remove()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Force_Remove", args);
    }

    /// <summary>
    /// Gets the force vector, in Newtons.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [Rpc("SpaceCenter", "Force_get_ForceVector")]
    public Tuple<double,double,double> GetForceVector()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "Force_get_ForceVector", args);
    }

    /// <summary>
    /// Sets the force vector, in Newtons.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetForceVector(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Force_set_ForceVector", args);
    }

    /// <summary>
    /// Gets the part that this force is applied to.
    /// </summary>
    [Rpc("SpaceCenter", "Force_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Force_get_Part", args);
    }

    /// <summary>
    /// Gets the position at which the force acts, in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    [Rpc("SpaceCenter", "Force_get_Position")]
    public Tuple<double,double,double> GetPosition()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "Force_get_Position", args);
    }

    /// <summary>
    /// Sets the position at which the force acts, in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetPosition(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Force_set_Position", args);
    }

    /// <summary>
    /// Gets the reference frame of the force vector and position.
    /// </summary>
    [Rpc("SpaceCenter", "Force_get_ReferenceFrame")]
    public ReferenceFrame GetReferenceFrame()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ReferenceFrame>("SpaceCenter", "Force_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Sets the reference frame of the force vector and position.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetReferenceFrame(ReferenceFrame value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Force_set_ReferenceFrame", args);
    }
}
