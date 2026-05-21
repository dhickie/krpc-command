using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using MathNet.Spatial.Euclidean;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A reaction wheel. Obtained by calling <see cref="M:SpaceCenter.Part.GetReactionWheel" />.
/// </summary>
public class ReactionWheel : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public ReactionWheel(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the reaction wheel is active.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_Active")]
    public bool GetActive()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ReactionWheel_get_Active", args);
    }

    /// <summary>
    /// Gets whether the reaction wheel is active.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_Active")]
    public async Task<bool> GetActiveAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "ReactionWheel_get_Active", args);
    }

    /// <summary>
    /// Sets whether the reaction wheel is active.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ReactionWheel_set_Active")]
    public void SetActive(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "ReactionWheel_set_Active", args);
    }

    /// <summary>
    /// Sets whether the reaction wheel is active.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [Rpc("SpaceCenter", "ReactionWheel_set_Active")]
    public async Task SetActiveAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "ReactionWheel_set_Active", args);
    }

    /// <summary>
    /// Gets the available torque, in Newton meters, that can be produced by this reaction wheel,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// Returns zero if the reaction wheel is inactive or broken.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_AvailableTorque")]
    public Tuple<Vector3D,Vector3D> GetAvailableTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "ReactionWheel_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets the available torque, in Newton meters, that can be produced by this reaction wheel,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// Returns zero if the reaction wheel is inactive or broken.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_AvailableTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "ReactionWheel_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets whether the reaction wheel is broken.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_Broken")]
    public bool GetBroken()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "ReactionWheel_get_Broken", args);
    }

    /// <summary>
    /// Gets whether the reaction wheel is broken.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_Broken")]
    public async Task<bool> GetBrokenAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "ReactionWheel_get_Broken", args);
    }

    /// <summary>
    /// Gets the maximum torque, in Newton meters, that can be produced by this reaction wheel,
    /// when it is active, in the positive and negative pitch, roll and yaw axes of the vessel.
    /// These axes correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_MaxTorque")]
    public Tuple<Vector3D,Vector3D> GetMaxTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "ReactionWheel_get_MaxTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque, in Newton meters, that can be produced by this reaction wheel,
    /// when it is active, in the positive and negative pitch, roll and yaw axes of the vessel.
    /// These axes correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_MaxTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetMaxTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "ReactionWheel_get_MaxTorque", args);
    }

    /// <summary>
    /// Gets the part object for this reaction wheel.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "ReactionWheel_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this reaction wheel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "ReactionWheel_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "ReactionWheel_get_Part", args);
    }
}
