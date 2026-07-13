using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;
using MathNet.Spatial.Euclidean;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// An RCS block or thruster. Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetRCS" />.
/// </summary>
public class RCS : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal RCS(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Gets whether the RCS thrusters are active.
    /// An RCS thruster is inactive if the RCS action group is disabled
    /// (<see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Control.GetRCS" />), the RCS thruster itself is not enabled
    /// (<see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.RCS.GetEnabled" />) or it is covered by a fairing (<see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetShielded" />).
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Active")]
    public bool GetActive()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RCS_get_Active", args);
    }

    /// <summary>
    /// Gets whether the RCS thrusters are active.
    /// An RCS thruster is inactive if the RCS action group is disabled
    /// (<see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Control.GetRCS" />), the RCS thruster itself is not enabled
    /// (<see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.RCS.GetEnabled" />) or it is covered by a fairing (<see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetShielded" />).
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Active")]
    public async Task<bool> GetActiveAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RCS_get_Active", args);
    }

    /// <summary>
    /// Gets the available force, in Newtons, that can be produced by this RCS,
    /// in the positive and negative x, y and z axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Vessel.GetReferenceFrame" />.
    /// Returns zero if RCS is disabled.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_AvailableForce")]
    public Tuple<Vector3D,Vector3D> GetAvailableForce()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Tuple<Vector3D,Vector3D>>("SpaceCenter", "RCS_get_AvailableForce", args);
    }

    /// <summary>
    /// Gets the available force, in Newtons, that can be produced by this RCS,
    /// in the positive and negative x, y and z axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Vessel.GetReferenceFrame" />.
    /// Returns zero if RCS is disabled.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_AvailableForce")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableForceAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "RCS_get_AvailableForce", args);
    }

    /// <summary>
    /// Gets the amount of thrust, in Newtons, that would be produced by the thruster when activated.
    /// Returns zero if the thruster does not have any fuel.
    /// Takes the thrusters current <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.RCS.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_AvailableThrust")]
    public float GetAvailableThrust()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "RCS_get_AvailableThrust", args);
    }

    /// <summary>
    /// Gets the amount of thrust, in Newtons, that would be produced by the thruster when activated.
    /// Returns zero if the thruster does not have any fuel.
    /// Takes the thrusters current <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.RCS.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_AvailableThrust")]
    public async Task<float> GetAvailableThrustAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "RCS_get_AvailableThrust", args);
    }

    /// <summary>
    /// Gets the available torque, in Newton meters, that can be produced by this RCS,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Vessel.GetReferenceFrame" />.
    /// Returns zero if RCS is disable.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_AvailableTorque")]
    public Tuple<Vector3D,Vector3D> GetAvailableTorque()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Tuple<Vector3D,Vector3D>>("SpaceCenter", "RCS_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets the available torque, in Newton meters, that can be produced by this RCS,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Vessel.GetReferenceFrame" />.
    /// Returns zero if RCS is disable.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_AvailableTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableTorqueAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "RCS_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets whether the RCS thrusters are enabled.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Enabled")]
    public bool GetEnabled()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RCS_get_Enabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thrusters are enabled.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Enabled")]
    public async Task<bool> GetEnabledAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RCS_get_Enabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thrusters are enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_Enabled")]
    public void SetEnabled(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RCS_set_Enabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thrusters are enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_Enabled")]
    public async Task SetEnabledAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RCS_set_Enabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_ForwardEnabled")]
    public bool GetForwardEnabled()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RCS_get_ForwardEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when pitch control input is given.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_ForwardEnabled")]
    public async Task<bool> GetForwardEnabledAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RCS_get_ForwardEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_ForwardEnabled")]
    public void SetForwardEnabled(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RCS_set_ForwardEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when pitch control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_ForwardEnabled")]
    public async Task SetForwardEnabledAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RCS_set_ForwardEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS has fuel available.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_HasFuel")]
    public bool GetHasFuel()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RCS_get_HasFuel", args);
    }

    /// <summary>
    /// Gets whether the RCS has fuel available.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_HasFuel")]
    public async Task<bool> GetHasFuelAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RCS_get_HasFuel", args);
    }

    /// <summary>
    /// Gets the specific impulse of the RCS at sea level on Kerbin, in seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse")]
    public float GetKerbinSeaLevelSpecificImpulse()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the specific impulse of the RCS at sea level on Kerbin, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse")]
    public async Task<float> GetKerbinSeaLevelSpecificImpulseAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "RCS_get_KerbinSeaLevelSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the RCS thrusters when active,
    /// in Newtons.
    /// Takes the thrusters current <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.RCS.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_MaxThrust")]
    public float GetMaxThrust()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "RCS_get_MaxThrust", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the RCS thrusters when active,
    /// in Newtons.
    /// Takes the thrusters current <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.RCS.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_MaxThrust")]
    public async Task<float> GetMaxThrustAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "RCS_get_MaxThrust", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the RCS thrusters when active
    /// in a vacuum, in Newtons.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_MaxVacuumThrust")]
    public float GetMaxVacuumThrust()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "RCS_get_MaxVacuumThrust", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the RCS thrusters when active
    /// in a vacuum, in Newtons.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_MaxVacuumThrust")]
    public async Task<float> GetMaxVacuumThrustAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "RCS_get_MaxVacuumThrust", args);
    }

    /// <summary>
    /// Gets the part object for this RCS.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Part")]
    public Part GetPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "RCS_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this RCS.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "RCS_get_Part", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_PitchEnabled")]
    public bool GetPitchEnabled()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RCS_get_PitchEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when pitch control input is given.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_PitchEnabled")]
    public async Task<bool> GetPitchEnabledAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RCS_get_PitchEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when pitch control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_PitchEnabled")]
    public void SetPitchEnabled(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RCS_set_PitchEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when pitch control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_PitchEnabled")]
    public async Task SetPitchEnabledAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RCS_set_PitchEnabled", args);
    }

    /// <summary>
    /// Gets the ratios of resources that the RCS consumes. A dictionary mapping resource names
    /// to the ratios at which they are consumed by the RCS.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_PropellantRatios")]
    public IDictionary<string,float> GetPropellantRatios()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<IDictionary<string,float>>("SpaceCenter", "RCS_get_PropellantRatios", args);
    }

    /// <summary>
    /// Gets the ratios of resources that the RCS consumes. A dictionary mapping resource names
    /// to the ratios at which they are consumed by the RCS.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_PropellantRatios")]
    public async Task<IDictionary<string,float>> GetPropellantRatiosAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<IDictionary<string,float>>("SpaceCenter", "RCS_get_PropellantRatios", args);
    }

    /// <summary>
    /// Gets the names of resources that the RCS consumes.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Propellants")]
    public List<string> GetPropellants()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<string>>("SpaceCenter", "RCS_get_Propellants", args);
    }

    /// <summary>
    /// Gets the names of resources that the RCS consumes.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Propellants")]
    public async Task<List<string>> GetPropellantsAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<string>>("SpaceCenter", "RCS_get_Propellants", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_RightEnabled")]
    public bool GetRightEnabled()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RCS_get_RightEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when roll control input is given.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_RightEnabled")]
    public async Task<bool> GetRightEnabledAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RCS_get_RightEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_RightEnabled")]
    public void SetRightEnabled(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RCS_set_RightEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when roll control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_RightEnabled")]
    public async Task SetRightEnabledAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RCS_set_RightEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_RollEnabled")]
    public bool GetRollEnabled()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RCS_get_RollEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when roll control input is given.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_RollEnabled")]
    public async Task<bool> GetRollEnabledAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RCS_get_RollEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when roll control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_RollEnabled")]
    public void SetRollEnabled(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RCS_set_RollEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when roll control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_RollEnabled")]
    public async Task SetRollEnabledAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RCS_set_RollEnabled", args);
    }

    /// <summary>
    /// Gets the current specific impulse of the RCS, in seconds. Returns zero
    /// if the RCS is not active.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_SpecificImpulse")]
    public float GetSpecificImpulse()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "RCS_get_SpecificImpulse", args);
    }

    /// <summary>
    /// Gets the current specific impulse of the RCS, in seconds. Returns zero
    /// if the RCS is not active.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_SpecificImpulse")]
    public async Task<float> GetSpecificImpulseAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "RCS_get_SpecificImpulse", args);
    }

    /// <summary>
    /// Gets the thrust limiter of the thruster. A value between 0 and 1.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_ThrustLimit")]
    public float GetThrustLimit()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "RCS_get_ThrustLimit", args);
    }

    /// <summary>
    /// Gets the thrust limiter of the thruster. A value between 0 and 1.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_ThrustLimit")]
    public async Task<float> GetThrustLimitAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "RCS_get_ThrustLimit", args);
    }

    /// <summary>
    /// Sets the thrust limiter of the thruster. A value between 0 and 1.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_ThrustLimit")]
    public void SetThrustLimit(float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RCS_set_ThrustLimit", args);
    }

    /// <summary>
    /// Sets the thrust limiter of the thruster. A value between 0 and 1.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_ThrustLimit")]
    public async Task SetThrustLimitAsync(float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RCS_set_ThrustLimit", args);
    }

    /// <summary>
    /// Gets a list of thrusters, one of each nozzel in the RCS part.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Thrusters")]
    public List<Thruster> GetThrusters()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<List<Thruster>>("SpaceCenter", "RCS_get_Thrusters", args);
    }

    /// <summary>
    /// Gets a list of thrusters, one of each nozzel in the RCS part.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_Thrusters")]
    public async Task<List<Thruster>> GetThrustersAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<List<Thruster>>("SpaceCenter", "RCS_get_Thrusters", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_UpEnabled")]
    public bool GetUpEnabled()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RCS_get_UpEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when yaw control input is given.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_UpEnabled")]
    public async Task<bool> GetUpEnabledAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RCS_get_UpEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_UpEnabled")]
    public void SetUpEnabled(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RCS_set_UpEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when yaw control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_UpEnabled")]
    public async Task SetUpEnabledAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RCS_set_UpEnabled", args);
    }

    /// <summary>
    /// Gets the vacuum specific impulse of the RCS, in seconds.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_VacuumSpecificImpulse")]
    public float GetVacuumSpecificImpulse()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<float>("SpaceCenter", "RCS_get_VacuumSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the vacuum specific impulse of the RCS, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_VacuumSpecificImpulse")]
    public async Task<float> GetVacuumSpecificImpulseAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<float>("SpaceCenter", "RCS_get_VacuumSpecificImpulse", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_YawEnabled")]
    public bool GetYawEnabled()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RCS_get_YawEnabled", args);
    }

    /// <summary>
    /// Gets whether the RCS thruster will fire when yaw control input is given.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RCS_get_YawEnabled")]
    public async Task<bool> GetYawEnabledAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RCS_get_YawEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when yaw control input is given.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_YawEnabled")]
    public void SetYawEnabled(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        InvokeVoid("SpaceCenter", "RCS_set_YawEnabled", args);
    }

    /// <summary>
    /// Sets whether the RCS thruster will fire when yaw control input is given.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    [SetRpc("SpaceCenter", "RCS_set_YawEnabled")]
    public async Task SetYawEnabledAsync(bool value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            value
        };
        await InvokeVoidAsync("SpaceCenter", "RCS_set_YawEnabled", args);
    }
}
