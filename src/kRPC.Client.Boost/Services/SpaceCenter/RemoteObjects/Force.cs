using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;
using MathNet.Spatial.Euclidean;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

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
    /// Remove the force.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Force_Remove")]
    public async Task RemoveAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Force_Remove", args);
    }

    /// <summary>
    /// Gets the force vector, in Newtons.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [Rpc("SpaceCenter", "Force_get_ForceVector")]
    public Vector3D GetForceVector()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Force_get_ForceVector", args);
    }

    /// <summary>
    /// Gets the force vector, in Newtons.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>A vector pointing in the direction that the force acts,
    /// with its magnitude equal to the strength of the force in Newtons.</returns>
    [Rpc("SpaceCenter", "Force_get_ForceVector")]
    public async Task<Vector3D> GetForceVectorAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Force_get_ForceVector", args);
    }

    /// <summary>
    /// Sets the force vector, in Newtons.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Force_set_ForceVector")]
    public void SetForceVector(Vector3D value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Force_set_ForceVector", args);
    }

    /// <summary>
    /// Sets the force vector, in Newtons.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Force_set_ForceVector")]
    public async Task SetForceVectorAsync(Vector3D value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Force_set_ForceVector", args);
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
    /// Gets the part that this force is applied to.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Force_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Force_get_Part", args);
    }

    /// <summary>
    /// Gets the position at which the force acts, in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    [Rpc("SpaceCenter", "Force_get_Position")]
    public Vector3D GetPosition()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Force_get_Position", args);
    }

    /// <summary>
    /// Gets the position at which the force acts, in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    [Rpc("SpaceCenter", "Force_get_Position")]
    public async Task<Vector3D> GetPositionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Force_get_Position", args);
    }

    /// <summary>
    /// Sets the position at which the force acts, in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Force_set_Position")]
    public void SetPosition(Vector3D value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Force_set_Position", args);
    }

    /// <summary>
    /// Sets the position at which the force acts, in reference frame <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Force_set_Position")]
    public async Task SetPositionAsync(Vector3D value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Force_set_Position", args);
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
    /// Gets the reference frame of the force vector and position.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Force_get_ReferenceFrame")]
    public async Task<ReferenceFrame> GetReferenceFrameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ReferenceFrame>("SpaceCenter", "Force_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Sets the reference frame of the force vector and position.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Force_set_ReferenceFrame")]
    public void SetReferenceFrame(ReferenceFrame value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Force_set_ReferenceFrame", args);
    }

    /// <summary>
    /// Sets the reference frame of the force vector and position.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Force_set_ReferenceFrame")]
    public async Task SetReferenceFrameAsync(ReferenceFrame value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Force_set_ReferenceFrame", args);
    }
}
