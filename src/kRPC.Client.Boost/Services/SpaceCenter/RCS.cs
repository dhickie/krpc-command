using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using MathNet.Spatial.Euclidean;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An RCS block or thruster. Obtained by calling <see cref="M:SpaceCenter.Part.GetRCS" />.
/// </summary>
public class RCS : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RCS(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the RCS thrusters are active.
    /// An RCS thruster is inactive if the RCS action group is disabled
    /// (<see cref="M:SpaceCenter.Control.GetRCS" />), the RCS thruster itself is not enabled
    /// (<see cref="M:SpaceCenter.RCS.GetEnabled" />) or it is covered by a fairing (<see cref="M:SpaceCenter.Part.GetShielded" />).
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Active")]
    public bool GetActive()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RCS_get_Active", args);
    }

    /// <summary>
    /// Gets whether the RCS thrusters are active.
    /// An RCS thruster is inactive if the RCS action group is disabled
    /// (<see cref="M:SpaceCenter.Control.GetRCS" />), the RCS thruster itself is not enabled
    /// (<see cref="M:SpaceCenter.RCS.GetEnabled" />) or it is covered by a fairing (<see cref="M:SpaceCenter.Part.GetShielded" />).
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Active")]
    public async Task<bool> GetActiveAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RCS_get_Active", args);
    }

    /// <summary>
    /// Gets the available force, in Newtons, that can be produced by this RCS,
    /// in the positive and negative x, y and z axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// Returns zero if RCS is disabled.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_AvailableForce")]
    public Tuple<Vector3D,Vector3D> GetAvailableForce()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "RCS_get_AvailableForce", args);
    }

    /// <summary>
    /// Gets the available force, in Newtons, that can be produced by this RCS,
    /// in the positive and negative x, y and z axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// Returns zero if RCS is disabled.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_AvailableForce")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableForceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "RCS_get_AvailableForce", args);
    }

    /// <summary>
    /// Gets the amount of thrust, in Newtons, that would be produced by the thruster when activated.
    /// Returns zero if the thruster does not have any fuel.
    /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_AvailableThrust")]
    public float GetAvailableThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RCS_get_AvailableThrust", args);
    }

    /// <summary>
    /// Gets the amount of thrust, in Newtons, that would be produced by the thruster when activated.
    /// Returns zero if the thruster does not have any fuel.
    /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_AvailableThrust")]
    public async Task<float> GetAvailableThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RCS_get_AvailableThrust", args);
    }

    /// <summary>
    /// Gets the available torque, in Newton meters, that can be produced by this RCS,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// Returns zero if RCS is disable.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_AvailableTorque")]
    public Tuple<Vector3D,Vector3D> GetAvailableTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "RCS_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets the available torque, in Newton meters, that can be produced by this RCS,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// Returns zero if RCS is disable.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_AvailableTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "RCS_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets whether the RCS thrusters are enabled.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Enabled")]
    public bool GetEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RCS_get_Enabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thrusters are enabled.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Enabled")]
    public async Task<bool> GetEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RCS_get_Enabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thrusters are enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RCS_set_Enabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thrusters are enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RCS_set_Enabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_ForwardEnabled")]
    public bool GetForwardEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RCS_get_ForwardEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when pitch control input is given.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_ForwardEnabled")]
    public async Task<bool> GetForwardEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RCS_get_ForwardEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetForwardEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RCS_set_ForwardEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when pitch control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetForwardEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RCS_set_ForwardEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS has fuel available.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_HasFuel")]
    public bool GetHasFuel()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RCS_get_HasFuel", args);
    }

    /// <summary>
    /// Gets whether the RCS has fuel available.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_HasFuel")]
    public async Task<bool> GetHasFuelAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RCS_get_HasFuel", args);
    }

    /// <summary>
    /// Gets the specific impulse of the RCS at sea level on Kerbin, in seconds.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse")]
    public float GetKerbinSeaLevelSpecificImpulse()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the specific impulse of the RCS at sea level on Kerbin, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse")]
    public async Task<float> GetKerbinSeaLevelSpecificImpulseAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the RCS thrusters when active,
    /// in Newtons.
    /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_MaxThrust")]
    public float GetMaxThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RCS_get_MaxThrust", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the RCS thrusters when active,
    /// in Newtons.
    /// Takes the thrusters current <see cref="M:SpaceCenter.RCS.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_MaxThrust")]
    public async Task<float> GetMaxThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RCS_get_MaxThrust", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the RCS thrusters when active
    /// in a vacuum, in Newtons.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_MaxVacuumThrust")]
    public float GetMaxVacuumThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RCS_get_MaxVacuumThrust", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the RCS thrusters when active
    /// in a vacuum, in Newtons.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_MaxVacuumThrust")]
    public async Task<float> GetMaxVacuumThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RCS_get_MaxVacuumThrust", args);
    }

    /// <summary>
    /// Gets the part object for this RCS.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "RCS_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this RCS.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "RCS_get_Part", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_PitchEnabled")]
    public bool GetPitchEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RCS_get_PitchEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when pitch control input is given.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_PitchEnabled")]
    public async Task<bool> GetPitchEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RCS_get_PitchEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetPitchEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RCS_set_PitchEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when pitch control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetPitchEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RCS_set_PitchEnabled", args);
    }

    /// <summary>
    /// Gets the ratios of resources that the RCS consumes. A dictionary mapping resource names
    /// to the ratios at which they are consumed by the RCS.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_PropellantRatios")]
    public IDictionary<string,float> GetPropellantRatios()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IDictionary<string,float>>("SpaceCenter", "RCS_get_PropellantRatios", args);
    }

    /// <summary>
    /// Gets the ratios of resources that the RCS consumes. A dictionary mapping resource names
    /// to the ratios at which they are consumed by the RCS.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_PropellantRatios")]
    public async Task<IDictionary<string,float>> GetPropellantRatiosAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IDictionary<string,float>>("SpaceCenter", "RCS_get_PropellantRatios", args);
    }

    /// <summary>
    /// Gets the names of resources that the RCS consumes.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Propellants")]
    public IList<string> GetPropellants()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "RCS_get_Propellants", args);
    }

    /// <summary>
    /// Gets the names of resources that the RCS consumes.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Propellants")]
    public async Task<IList<string>> GetPropellantsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "RCS_get_Propellants", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_RightEnabled")]
    public bool GetRightEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RCS_get_RightEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when roll control input is given.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_RightEnabled")]
    public async Task<bool> GetRightEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RCS_get_RightEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRightEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RCS_set_RightEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when roll control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRightEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RCS_set_RightEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_RollEnabled")]
    public bool GetRollEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RCS_get_RollEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when roll control input is given.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_RollEnabled")]
    public async Task<bool> GetRollEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RCS_get_RollEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRollEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RCS_set_RollEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when roll control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRollEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RCS_set_RollEnabled", args);
    }

    /// <summary>
    /// Gets the current specific impulse of the RCS, in seconds. Returns zero
    /// if the RCS is not active.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_SpecificImpulse")]
    public float GetSpecificImpulse()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RCS_get_SpecificImpulse", args);
    }

    /// <summary>
    /// Gets the current specific impulse of the RCS, in seconds. Returns zero
    /// if the RCS is not active.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_SpecificImpulse")]
    public async Task<float> GetSpecificImpulseAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RCS_get_SpecificImpulse", args);
    }

    /// <summary>
    /// Gets the thrust limiter of the thruster. A value between 0 and 1.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_ThrustLimit")]
    public float GetThrustLimit()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RCS_get_ThrustLimit", args);
    }

    /// <summary>
    /// Gets the thrust limiter of the thruster. A value between 0 and 1.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_ThrustLimit")]
    public async Task<float> GetThrustLimitAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RCS_get_ThrustLimit", args);
    }

    /// <summary>
    /// Sets the thrust limiter of the thruster. A value between 0 and 1.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetThrustLimit(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RCS_set_ThrustLimit", args);
    }

    /// <summary>
    /// Sets the thrust limiter of the thruster. A value between 0 and 1.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetThrustLimitAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RCS_set_ThrustLimit", args);
    }

    /// <summary>
    /// Gets a list of thrusters, one of each nozzel in the RCS part.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Thrusters")]
    public IList<Thruster> GetThrusters()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Thruster>>("SpaceCenter", "RCS_get_Thrusters", args);
    }

    /// <summary>
    /// Gets a list of thrusters, one of each nozzel in the RCS part.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_Thrusters")]
    public async Task<IList<Thruster>> GetThrustersAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Thruster>>("SpaceCenter", "RCS_get_Thrusters", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_UpEnabled")]
    public bool GetUpEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RCS_get_UpEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when yaw control input is given.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_UpEnabled")]
    public async Task<bool> GetUpEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RCS_get_UpEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetUpEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RCS_set_UpEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when yaw control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetUpEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RCS_set_UpEnabled", args);
    }

    /// <summary>
    /// Gets the vacuum specific impulse of the RCS, in seconds.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_VacuumSpecificImpulse")]
    public float GetVacuumSpecificImpulse()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "RCS_get_VacuumSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the vacuum specific impulse of the RCS, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_VacuumSpecificImpulse")]
    public async Task<float> GetVacuumSpecificImpulseAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "RCS_get_VacuumSpecificImpulse", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_YawEnabled")]
    public bool GetYawEnabled()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "RCS_get_YawEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when yaw control input is given.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "RCS_get_YawEnabled")]
    public async Task<bool> GetYawEnabledAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "RCS_get_YawEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetYawEnabled(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "RCS_set_YawEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when yaw control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetYawEnabledAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "RCS_set_YawEnabled", args);
    }
}
