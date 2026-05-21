using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using MathNet.Spatial.Euclidean;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Represents a maneuver node. Can be created using <see cref="M:SpaceCenter.Control.AddNode" />.
/// </summary>
public class Node : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Node(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Returns the burn vector for the maneuver node.
    /// </summary>
    /// <param name="referenceFrame">The reference frame that the returned vector is in.
    /// Defaults to <see cref="M:SpaceCenter.Vessel.GetOrbitalReferenceFrame" />.</param>
    /// <returns>A vector whose direction is the direction of the maneuver node burn, and
    /// magnitude is the delta-v of the burn in meters per second.
    /// </returns>
    /// <remarks>
    /// Does not change when executing the maneuver node. See <see cref="M:SpaceCenter.Node.RemainingBurnVector" />.
    /// </remarks>
    [Rpc("SpaceCenter", "Node_BurnVector")]
    public Vector3D BurnVector(ReferenceFrame? referenceFrame = null)
    {
        var args = new object?[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Node_BurnVector", args);
    }

    /// <summary>
    /// Returns the burn vector for the maneuver node.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="referenceFrame">The reference frame that the returned vector is in.
    /// Defaults to <see cref="M:SpaceCenter.Vessel.GetOrbitalReferenceFrame" />.</param>
    /// <returns>A vector whose direction is the direction of the maneuver node burn, and
    /// magnitude is the delta-v of the burn in meters per second.
    /// </returns>
    /// <remarks>
    /// Does not change when executing the maneuver node. See <see cref="M:SpaceCenter.Node.RemainingBurnVector" />.
    /// </remarks>
    [Rpc("SpaceCenter", "Node_BurnVector")]
    public async Task<Vector3D> BurnVectorAsync(ReferenceFrame? referenceFrame = null)
    {
        var args = new object?[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Node_BurnVector", args);
    }

    /// <summary>
    /// The direction of the maneuver nodes burn.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [Rpc("SpaceCenter", "Node_Direction")]
    public Vector3D Direction(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Node_Direction", args);
    }

    /// <summary>
    /// The direction of the maneuver nodes burn.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [Rpc("SpaceCenter", "Node_Direction")]
    public async Task<Vector3D> DirectionAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Node_Direction", args);
    }

    /// <summary>
    /// The position vector of the maneuver node in the given reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [Rpc("SpaceCenter", "Node_Position")]
    public Vector3D Position(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Node_Position", args);
    }

    /// <summary>
    /// The position vector of the maneuver node in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [Rpc("SpaceCenter", "Node_Position")]
    public async Task<Vector3D> PositionAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Node_Position", args);
    }

    /// <summary>
    /// Returns the remaining burn vector for the maneuver node.
    /// </summary>
    /// <param name="referenceFrame">The reference frame that the returned vector is in.
    /// Defaults to <see cref="M:SpaceCenter.Vessel.GetOrbitalReferenceFrame" />.</param>
    /// <returns>A vector whose direction is the direction of the maneuver node burn, and
    /// magnitude is the delta-v of the burn in meters per second.
    /// </returns>
    /// <remarks>
    /// Changes as the maneuver node is executed. See <see cref="M:SpaceCenter.Node.BurnVector" />.
    /// </remarks>
    [Rpc("SpaceCenter", "Node_RemainingBurnVector")]
    public Vector3D RemainingBurnVector(ReferenceFrame? referenceFrame = null)
    {
        var args = new object?[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Node_RemainingBurnVector", args);
    }

    /// <summary>
    /// Returns the remaining burn vector for the maneuver node.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="referenceFrame">The reference frame that the returned vector is in.
    /// Defaults to <see cref="M:SpaceCenter.Vessel.GetOrbitalReferenceFrame" />.</param>
    /// <returns>A vector whose direction is the direction of the maneuver node burn, and
    /// magnitude is the delta-v of the burn in meters per second.
    /// </returns>
    /// <remarks>
    /// Changes as the maneuver node is executed. See <see cref="M:SpaceCenter.Node.BurnVector" />.
    /// </remarks>
    [Rpc("SpaceCenter", "Node_RemainingBurnVector")]
    public async Task<Vector3D> RemainingBurnVectorAsync(ReferenceFrame? referenceFrame = null)
    {
        var args = new object?[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Node_RemainingBurnVector", args);
    }

    /// <summary>
    /// Removes the maneuver node.
    /// </summary>
    [Rpc("SpaceCenter", "Node_Remove")]
    public void Remove()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Node_Remove", args);
    }

    /// <summary>
    /// Removes the maneuver node.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_Remove")]
    public async Task RemoveAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Node_Remove", args);
    }

    /// <summary>
    /// Gets the delta-v of the maneuver node, in meters per second.
    /// </summary>
    /// <remarks>
    /// Does not change when executing the maneuver node. See <see cref="M:SpaceCenter.Node.GetRemainingDeltaV" />.
    /// </remarks>
    [Rpc("SpaceCenter", "Node_get_DeltaV")]
    public double GetDeltaV()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Node_get_DeltaV", args);
    }

    /// <summary>
    /// Gets the delta-v of the maneuver node, in meters per second.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// Does not change when executing the maneuver node. See <see cref="M:SpaceCenter.Node.GetRemainingDeltaV" />.
    /// </remarks>
    [Rpc("SpaceCenter", "Node_get_DeltaV")]
    public async Task<double> GetDeltaVAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Node_get_DeltaV", args);
    }

    /// <summary>
    /// Sets the delta-v of the maneuver node, in meters per second.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_DeltaV")]
    public void SetDeltaV(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Node_set_DeltaV", args);
    }

    /// <summary>
    /// Sets the delta-v of the maneuver node, in meters per second.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_DeltaV")]
    public async Task SetDeltaVAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Node_set_DeltaV", args);
    }

    /// <summary>
    /// Gets the magnitude of the maneuver nodes delta-v in the normal direction,
    /// in meters per second.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_Normal")]
    public double GetNormal()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Node_get_Normal", args);
    }

    /// <summary>
    /// Gets the magnitude of the maneuver nodes delta-v in the normal direction,
    /// in meters per second.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_Normal")]
    public async Task<double> GetNormalAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Node_get_Normal", args);
    }

    /// <summary>
    /// Sets the magnitude of the maneuver nodes delta-v in the normal direction,
    /// in meters per second.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_Normal")]
    public void SetNormal(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Node_set_Normal", args);
    }

    /// <summary>
    /// Sets the magnitude of the maneuver nodes delta-v in the normal direction,
    /// in meters per second.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_Normal")]
    public async Task SetNormalAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Node_set_Normal", args);
    }

    /// <summary>
    /// Gets the orbit that results from executing the maneuver node.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_Orbit")]
    public Orbit GetOrbit()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Orbit>("SpaceCenter", "Node_get_Orbit", args);
    }

    /// <summary>
    /// Gets the orbit that results from executing the maneuver node.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_Orbit")]
    public async Task<Orbit> GetOrbitAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Orbit>("SpaceCenter", "Node_get_Orbit", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the maneuver node, and
    /// orientated with the orbital prograde/normal/radial directions of the
    /// original orbit at the maneuver node's position.
    /// <list type="bullet"><item><description>The origin is at the position of the maneuver node.</description></item><item><description>The x-axis points in the orbital anti-radial direction of the original
    /// orbit, at the position of the maneuver node.</description></item><item><description>The y-axis points in the orbital prograde direction of the original
    /// orbit, at the position of the maneuver node.</description></item><item><description>The z-axis points in the orbital normal direction of the original orbit,
    /// at the position of the maneuver node.</description></item></list>
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_OrbitalReferenceFrame")]
    public ReferenceFrame GetOrbitalReferenceFrame()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ReferenceFrame>("SpaceCenter", "Node_get_OrbitalReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the maneuver node, and
    /// orientated with the orbital prograde/normal/radial directions of the
    /// original orbit at the maneuver node's position.
    /// <list type="bullet"><item><description>The origin is at the position of the maneuver node.</description></item><item><description>The x-axis points in the orbital anti-radial direction of the original
    /// orbit, at the position of the maneuver node.</description></item><item><description>The y-axis points in the orbital prograde direction of the original
    /// orbit, at the position of the maneuver node.</description></item><item><description>The z-axis points in the orbital normal direction of the original orbit,
    /// at the position of the maneuver node.</description></item></list>
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_OrbitalReferenceFrame")]
    public async Task<ReferenceFrame> GetOrbitalReferenceFrameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ReferenceFrame>("SpaceCenter", "Node_get_OrbitalReferenceFrame", args);
    }

    /// <summary>
    /// Gets the magnitude of the maneuver nodes delta-v in the prograde direction,
    /// in meters per second.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_Prograde")]
    public double GetPrograde()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Node_get_Prograde", args);
    }

    /// <summary>
    /// Gets the magnitude of the maneuver nodes delta-v in the prograde direction,
    /// in meters per second.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_Prograde")]
    public async Task<double> GetProgradeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Node_get_Prograde", args);
    }

    /// <summary>
    /// Sets the magnitude of the maneuver nodes delta-v in the prograde direction,
    /// in meters per second.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_Prograde")]
    public void SetPrograde(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Node_set_Prograde", args);
    }

    /// <summary>
    /// Sets the magnitude of the maneuver nodes delta-v in the prograde direction,
    /// in meters per second.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_Prograde")]
    public async Task SetProgradeAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Node_set_Prograde", args);
    }

    /// <summary>
    /// Gets the magnitude of the maneuver nodes delta-v in the radial direction,
    /// in meters per second.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_Radial")]
    public double GetRadial()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Node_get_Radial", args);
    }

    /// <summary>
    /// Gets the magnitude of the maneuver nodes delta-v in the radial direction,
    /// in meters per second.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_Radial")]
    public async Task<double> GetRadialAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Node_get_Radial", args);
    }

    /// <summary>
    /// Sets the magnitude of the maneuver nodes delta-v in the radial direction,
    /// in meters per second.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_Radial")]
    public void SetRadial(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Node_set_Radial", args);
    }

    /// <summary>
    /// Sets the magnitude of the maneuver nodes delta-v in the radial direction,
    /// in meters per second.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_Radial")]
    public async Task SetRadialAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Node_set_Radial", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the maneuver node's burn.
    /// <list type="bullet"><item><description>The origin is at the position of the maneuver node.</description></item><item><description>The y-axis points in the direction of the burn.</description></item><item><description>The x-axis and z-axis point in arbitrary but fixed directions.</description></item></list>
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_ReferenceFrame")]
    public ReferenceFrame GetReferenceFrame()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ReferenceFrame>("SpaceCenter", "Node_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the maneuver node's burn.
    /// <list type="bullet"><item><description>The origin is at the position of the maneuver node.</description></item><item><description>The y-axis points in the direction of the burn.</description></item><item><description>The x-axis and z-axis point in arbitrary but fixed directions.</description></item></list>
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_ReferenceFrame")]
    public async Task<ReferenceFrame> GetReferenceFrameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ReferenceFrame>("SpaceCenter", "Node_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets the remaining delta-v of the maneuver node, in meters per second. Changes as the
    /// node is executed. This is equivalent to the delta-v reported in-game.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_RemainingDeltaV")]
    public double GetRemainingDeltaV()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Node_get_RemainingDeltaV", args);
    }

    /// <summary>
    /// Gets the remaining delta-v of the maneuver node, in meters per second. Changes as the
    /// node is executed. This is equivalent to the delta-v reported in-game.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_RemainingDeltaV")]
    public async Task<double> GetRemainingDeltaVAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Node_get_RemainingDeltaV", args);
    }

    /// <summary>
    /// Gets the time until the maneuver node will be encountered, in seconds.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_TimeTo")]
    public double GetTimeTo()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Node_get_TimeTo", args);
    }

    /// <summary>
    /// Gets the time until the maneuver node will be encountered, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_TimeTo")]
    public async Task<double> GetTimeToAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Node_get_TimeTo", args);
    }

    /// <summary>
    /// Gets the universal time at which the maneuver will occur, in seconds.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_UT")]
    public double GetUT()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Node_get_UT", args);
    }

    /// <summary>
    /// Gets the universal time at which the maneuver will occur, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Node_get_UT")]
    public async Task<double> GetUTAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Node_get_UT", args);
    }

    /// <summary>
    /// Sets the universal time at which the maneuver will occur, in seconds.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_UT")]
    public void SetUT(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Node_set_UT", args);
    }

    /// <summary>
    /// Sets the universal time at which the maneuver will occur, in seconds.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "Node_set_UT")]
    public async Task SetUTAsync(double value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Node_set_UT", args);
    }
}
