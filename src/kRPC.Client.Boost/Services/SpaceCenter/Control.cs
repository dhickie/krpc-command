using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Used to manipulate the controls of a vessel. This includes adjusting the
/// throttle, enabling/disabling systems such as SAS and RCS, or altering the
/// direction in which the vessel is pointing.
/// Obtained by calling <see cref="M:SpaceCenter.Vessel.GetControl" />.
/// </summary>
/// <remarks>
/// Control inputs (such as pitch, yaw and roll) are zeroed when all clients
/// that have set one or more of these inputs are no longer connected.
/// </remarks>
public class Control : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Control(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Activates the next stage. Equivalent to pressing the space bar in-game.
    /// </summary>
    /// <returns>A list of vessel objects that are jettisoned from the active vessel.</returns>
    /// <remarks>
    /// When called, the active vessel may change. It is therefore possible that,
    /// after calling this function, the object(s) returned by previous call(s) to
    /// <see cref="M:SpaceCenter.GetActiveVessel" /> no longer refer to the active vessel.
    /// Throws an exception if staging is locked.
    /// </remarks>
    [Rpc("SpaceCenter", "Control_ActivateNextStage")]
    public IList<Vessel> ActivateNextStage()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Vessel>>("SpaceCenter", "Control_ActivateNextStage", args);
    }

    /// <summary>
    /// Activates the next stage. Equivalent to pressing the space bar in-game.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>A list of vessel objects that are jettisoned from the active vessel.</returns>
    /// <remarks>
    /// When called, the active vessel may change. It is therefore possible that,
    /// after calling this function, the object(s) returned by previous call(s) to
    /// <see cref="M:SpaceCenter.GetActiveVessel" /> no longer refer to the active vessel.
    /// Throws an exception if staging is locked.
    /// </remarks>
    [Rpc("SpaceCenter", "Control_ActivateNextStage")]
    public async Task<IList<Vessel>> ActivateNextStageAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Vessel>>("SpaceCenter", "Control_ActivateNextStage", args);
    }

    /// <summary>
    /// Creates a maneuver node at the given universal time, and returns a
    /// <see cref="T:SpaceCenter.Node" /> object that can be used to modify it.
    /// Optionally sets the magnitude of the delta-v for the maneuver node
    /// in the prograde, normal and radial directions.
    /// </summary>
    /// <param name="ut">Universal time of the maneuver node.</param>
    /// <param name="prograde">Delta-v in the prograde direction.</param>
    /// <param name="normal">Delta-v in the normal direction.</param>
    /// <param name="radial">Delta-v in the radial direction.</param>
    [Rpc("SpaceCenter", "Control_AddNode")]
    public Node AddNode(double ut, float prograde = 0.0f, float normal = 0.0f, float radial = 0.0f)
    {
        var args = new object[]
        {
            this,
            ut,
            prograde,
            normal,
            radial
        };
        return Connection.Invoke<Node>("SpaceCenter", "Control_AddNode", args);
    }

    /// <summary>
    /// Creates a maneuver node at the given universal time, and returns a
    /// <see cref="T:SpaceCenter.Node" /> object that can be used to modify it.
    /// Optionally sets the magnitude of the delta-v for the maneuver node
    /// in the prograde, normal and radial directions.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="ut">Universal time of the maneuver node.</param>
    /// <param name="prograde">Delta-v in the prograde direction.</param>
    /// <param name="normal">Delta-v in the normal direction.</param>
    /// <param name="radial">Delta-v in the radial direction.</param>
    [Rpc("SpaceCenter", "Control_AddNode")]
    public async Task<Node> AddNodeAsync(double ut, float prograde = 0.0f, float normal = 0.0f, float radial = 0.0f)
    {
        var args = new object[]
        {
            this,
            ut,
            prograde,
            normal,
            radial
        };
        return await Connection.InvokeAsync<Node>("SpaceCenter", "Control_AddNode", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the given action group is enabled.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    [Rpc("SpaceCenter", "Control_GetActionGroup")]
    public bool GetActionGroup(uint group)
    {
        var args = new object[]
        {
            this,
            group
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_GetActionGroup", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the given action group is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    [Rpc("SpaceCenter", "Control_GetActionGroup")]
    public async Task<bool> GetActionGroupAsync(uint group)
    {
        var args = new object[]
        {
            this,
            group
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_GetActionGroup", args);
    }

    /// <summary>
    /// Remove all maneuver nodes.
    /// </summary>
    [Rpc("SpaceCenter", "Control_RemoveNodes")]
    public void RemoveNodes()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Control_RemoveNodes", args);
    }

    /// <summary>
    /// Remove all maneuver nodes.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_RemoveNodes")]
    public async Task RemoveNodesAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_RemoveNodes", args);
    }

    /// <summary>
    /// Sets whether the given action group is enabled.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    /// <param name="state"></param>
    [Rpc("SpaceCenter", "Control_SetActionGroup")]
    public void SetActionGroup(uint group, bool state)
    {
        var args = new object[]
        {
            this,
            group,
            state
        };
        Connection.Invoke("SpaceCenter", "Control_SetActionGroup", args);
    }

    /// <summary>
    /// Sets whether the given action group is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    /// <param name="state"></param>
    [Rpc("SpaceCenter", "Control_SetActionGroup")]
    public async Task SetActionGroupAsync(uint group, bool state)
    {
        var args = new object[]
        {
            this,
            group,
            state
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_SetActionGroup", args);
    }

    /// <summary>
    /// Toggles the state of the given action group.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    [Rpc("SpaceCenter", "Control_ToggleActionGroup")]
    public void ToggleActionGroup(uint group)
    {
        var args = new object[]
        {
            this,
            group
        };
        Connection.Invoke("SpaceCenter", "Control_ToggleActionGroup", args);
    }

    /// <summary>
    /// Toggles the state of the given action group.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="group">
    /// A number between 0 and 9 inclusive,
    /// or between 0 and 250 inclusive when the <a href="https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/">Extended Action Groups mod</a> is installed.
    /// </param>
    [Rpc("SpaceCenter", "Control_ToggleActionGroup")]
    public async Task ToggleActionGroupAsync(uint group)
    {
        var args = new object[]
        {
            this,
            group
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_ToggleActionGroup", args);
    }

    /// <summary>
    /// Gets the state of the abort action group.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Abort")]
    public bool GetAbort()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Abort", args);
    }

    /// <summary>
    /// Gets the state of the abort action group.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Abort")]
    public async Task<bool> GetAbortAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Abort", args);
    }

    /// <summary>
    /// Sets the state of the abort action group.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetAbort(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Abort", args);
    }

    /// <summary>
    /// Sets the state of the abort action group.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetAbortAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Abort", args);
    }

    /// <summary>
    /// Returns whether all antennas on the vessel are deployed.
    /// See <see cref="M:SpaceCenter.Antenna.GetDeployed" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Antennas")]
    public bool GetAntennas()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Antennas", args);
    }

    /// <summary>
    /// Returns whether all antennas on the vessel are deployed.
    /// See <see cref="M:SpaceCenter.Antenna.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Antennas")]
    public async Task<bool> GetAntennasAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Antennas", args);
    }

    /// <summary>
    /// Sets the deployment state of all antennas.
    /// See <see cref="M:SpaceCenter.Antenna.GetDeployed" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetAntennas(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Antennas", args);
    }

    /// <summary>
    /// Sets the deployment state of all antennas.
    /// See <see cref="M:SpaceCenter.Antenna.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetAntennasAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Antennas", args);
    }

    /// <summary>
    /// Gets the state of the wheel brakes.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Brakes")]
    public bool GetBrakes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Brakes", args);
    }

    /// <summary>
    /// Gets the state of the wheel brakes.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Brakes")]
    public async Task<bool> GetBrakesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Brakes", args);
    }

    /// <summary>
    /// Sets the state of the wheel brakes.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetBrakes(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Brakes", args);
    }

    /// <summary>
    /// Sets the state of the wheel brakes.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetBrakesAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Brakes", args);
    }

    /// <summary>
    /// Returns whether any of the cargo bays on the vessel are open.
    /// See <see cref="M:SpaceCenter.CargoBay.GetOpen" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CargoBays")]
    public bool GetCargoBays()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_CargoBays", args);
    }

    /// <summary>
    /// Returns whether any of the cargo bays on the vessel are open.
    /// See <see cref="M:SpaceCenter.CargoBay.GetOpen" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CargoBays")]
    public async Task<bool> GetCargoBaysAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_CargoBays", args);
    }

    /// <summary>
    /// Sets the open state of all cargo bays.
    /// See <see cref="M:SpaceCenter.CargoBay.GetOpen" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetCargoBays(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_CargoBays", args);
    }

    /// <summary>
    /// Sets the open state of all cargo bays.
    /// See <see cref="M:SpaceCenter.CargoBay.GetOpen" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetCargoBaysAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_CargoBays", args);
    }

    /// <summary>
    /// Gets the current stage of the vessel. Corresponds to the stage number in
    /// the in-game UI.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CurrentStage")]
    public int GetCurrentStage()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<int>("SpaceCenter", "Control_get_CurrentStage", args);
    }

    /// <summary>
    /// Gets the current stage of the vessel. Corresponds to the stage number in
    /// the in-game UI.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CurrentStage")]
    public async Task<int> GetCurrentStageAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<int>("SpaceCenter", "Control_get_CurrentStage", args);
    }

    /// <summary>
    /// Gets the state of CustomAxis01.
    /// A value between -1 and 1.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CustomAxis01")]
    public float GetCustomAxis01()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_CustomAxis01", args);
    }

    /// <summary>
    /// Gets the state of CustomAxis01.
    /// A value between -1 and 1.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CustomAxis01")]
    public async Task<float> GetCustomAxis01Async()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_CustomAxis01", args);
    }

    /// <summary>
    /// Sets the state of CustomAxis01.
    /// A value between -1 and 1.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetCustomAxis01(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_CustomAxis01", args);
    }

    /// <summary>
    /// Sets the state of CustomAxis01.
    /// A value between -1 and 1.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetCustomAxis01Async(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_CustomAxis01", args);
    }

    /// <summary>
    /// Gets the state of CustomAxis02.
    /// A value between -1 and 1.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CustomAxis02")]
    public float GetCustomAxis02()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_CustomAxis02", args);
    }

    /// <summary>
    /// Gets the state of CustomAxis02.
    /// A value between -1 and 1.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CustomAxis02")]
    public async Task<float> GetCustomAxis02Async()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_CustomAxis02", args);
    }

    /// <summary>
    /// Sets the state of CustomAxis02.
    /// A value between -1 and 1.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetCustomAxis02(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_CustomAxis02", args);
    }

    /// <summary>
    /// Sets the state of CustomAxis02.
    /// A value between -1 and 1.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetCustomAxis02Async(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_CustomAxis02", args);
    }

    /// <summary>
    /// Gets the state of CustomAxis03.
    /// A value between -1 and 1.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CustomAxis03")]
    public float GetCustomAxis03()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_CustomAxis03", args);
    }

    /// <summary>
    /// Gets the state of CustomAxis03.
    /// A value between -1 and 1.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CustomAxis03")]
    public async Task<float> GetCustomAxis03Async()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_CustomAxis03", args);
    }

    /// <summary>
    /// Sets the state of CustomAxis03.
    /// A value between -1 and 1.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetCustomAxis03(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_CustomAxis03", args);
    }

    /// <summary>
    /// Sets the state of CustomAxis03.
    /// A value between -1 and 1.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetCustomAxis03Async(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_CustomAxis03", args);
    }

    /// <summary>
    /// Gets the state of CustomAxis04.
    /// A value between -1 and 1.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CustomAxis04")]
    public float GetCustomAxis04()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_CustomAxis04", args);
    }

    /// <summary>
    /// Gets the state of CustomAxis04.
    /// A value between -1 and 1.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_CustomAxis04")]
    public async Task<float> GetCustomAxis04Async()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_CustomAxis04", args);
    }

    /// <summary>
    /// Sets the state of CustomAxis04.
    /// A value between -1 and 1.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetCustomAxis04(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_CustomAxis04", args);
    }

    /// <summary>
    /// Sets the state of CustomAxis04.
    /// A value between -1 and 1.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetCustomAxis04Async(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_CustomAxis04", args);
    }

    /// <summary>
    /// Gets the state of the forward translational control.
    /// A value between -1 and 1.
    /// Equivalent to the h and n keys.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Forward")]
    public float GetForward()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_Forward", args);
    }

    /// <summary>
    /// Gets the state of the forward translational control.
    /// A value between -1 and 1.
    /// Equivalent to the h and n keys.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Forward")]
    public async Task<float> GetForwardAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_Forward", args);
    }

    /// <summary>
    /// Sets the state of the forward translational control.
    /// A value between -1 and 1.
    /// Equivalent to the h and n keys.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetForward(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Forward", args);
    }

    /// <summary>
    /// Sets the state of the forward translational control.
    /// A value between -1 and 1.
    /// Equivalent to the h and n keys.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetForwardAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Forward", args);
    }

    /// <summary>
    /// Gets the state of the landing gear/legs.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Gear")]
    public bool GetGear()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Gear", args);
    }

    /// <summary>
    /// Gets the state of the landing gear/legs.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Gear")]
    public async Task<bool> GetGearAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Gear", args);
    }

    /// <summary>
    /// Sets the state of the landing gear/legs.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetGear(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Gear", args);
    }

    /// <summary>
    /// Sets the state of the landing gear/legs.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetGearAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Gear", args);
    }

    /// <summary>
    /// Sets the behavior of the pitch, yaw, roll and translation control inputs.
    /// When set to additive, these inputs are added to the vessels current inputs.
    /// This mode is the default.
    /// When set to override, these inputs (if non-zero) override the vessels inputs.
    /// This mode prevents keyboard control, or SAS, from interfering with the controls when
    /// they are set.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_InputMode")]
    public ControlInputMode GetInputMode()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ControlInputMode>("SpaceCenter", "Control_get_InputMode", args);
    }

    /// <summary>
    /// Sets the behavior of the pitch, yaw, roll and translation control inputs.
    /// When set to additive, these inputs are added to the vessels current inputs.
    /// This mode is the default.
    /// When set to override, these inputs (if non-zero) override the vessels inputs.
    /// This mode prevents keyboard control, or SAS, from interfering with the controls when
    /// they are set.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_InputMode")]
    public async Task<ControlInputMode> GetInputModeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ControlInputMode>("SpaceCenter", "Control_get_InputMode", args);
    }

    /// <summary>
    /// Sets the behavior of the pitch, yaw, roll and translation control inputs.
    /// When set to additive, these inputs are added to the vessels current inputs.
    /// This mode is the default.
    /// When set to override, these inputs (if non-zero) override the vessels inputs.
    /// This mode prevents keyboard control, or SAS, from interfering with the controls when
    /// they are set.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetInputMode(ControlInputMode value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_InputMode", args);
    }

    /// <summary>
    /// Sets the behavior of the pitch, yaw, roll and translation control inputs.
    /// When set to additive, these inputs are added to the vessels current inputs.
    /// This mode is the default.
    /// When set to override, these inputs (if non-zero) override the vessels inputs.
    /// This mode prevents keyboard control, or SAS, from interfering with the controls when
    /// they are set.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetInputModeAsync(ControlInputMode value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_InputMode", args);
    }

    /// <summary>
    /// Returns whether all of the air intakes on the vessel are open.
    /// See <see cref="M:SpaceCenter.Intake.GetOpen" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Intakes")]
    public bool GetIntakes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Intakes", args);
    }

    /// <summary>
    /// Returns whether all of the air intakes on the vessel are open.
    /// See <see cref="M:SpaceCenter.Intake.GetOpen" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Intakes")]
    public async Task<bool> GetIntakesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Intakes", args);
    }

    /// <summary>
    /// Sets the open state of all air intakes.
    /// See <see cref="M:SpaceCenter.Intake.GetOpen" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetIntakes(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Intakes", args);
    }

    /// <summary>
    /// Sets the open state of all air intakes.
    /// See <see cref="M:SpaceCenter.Intake.GetOpen" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetIntakesAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Intakes", args);
    }

    /// <summary>
    /// Returns whether all landing legs on the vessel are deployed.
    /// Does not include wheels (for example landing gear).
    /// See <see cref="M:SpaceCenter.Leg.GetDeployed" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Legs")]
    public bool GetLegs()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Legs", args);
    }

    /// <summary>
    /// Returns whether all landing legs on the vessel are deployed.
    /// Does not include wheels (for example landing gear).
    /// See <see cref="M:SpaceCenter.Leg.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Legs")]
    public async Task<bool> GetLegsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Legs", args);
    }

    /// <summary>
    /// Sets the deployment state of all landing legs.
    /// Does not include wheels (for example landing gear).
    /// See <see cref="M:SpaceCenter.Leg.GetDeployed" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetLegs(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Legs", args);
    }

    /// <summary>
    /// Sets the deployment state of all landing legs.
    /// Does not include wheels (for example landing gear).
    /// See <see cref="M:SpaceCenter.Leg.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetLegsAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Legs", args);
    }

    /// <summary>
    /// Gets the state of the lights.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Lights")]
    public bool GetLights()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Lights", args);
    }

    /// <summary>
    /// Gets the state of the lights.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Lights")]
    public async Task<bool> GetLightsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Lights", args);
    }

    /// <summary>
    /// Sets the state of the lights.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetLights(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Lights", args);
    }

    /// <summary>
    /// Sets the state of the lights.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetLightsAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Lights", args);
    }

    /// <summary>
    /// Returns a list of all existing maneuver nodes, ordered by time from first to last.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Nodes")]
    public IList<Node> GetNodes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Node>>("SpaceCenter", "Control_get_Nodes", args);
    }

    /// <summary>
    /// Returns a list of all existing maneuver nodes, ordered by time from first to last.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Nodes")]
    public async Task<IList<Node>> GetNodesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Node>>("SpaceCenter", "Control_get_Nodes", args);
    }

    /// <summary>
    /// Returns whether all parachutes on the vessel are deployed.
    /// Cannot be set to <c>false</c>.
    /// See <see cref="M:SpaceCenter.Parachute.GetDeployed" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Parachutes")]
    public bool GetParachutes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Parachutes", args);
    }

    /// <summary>
    /// Returns whether all parachutes on the vessel are deployed.
    /// Cannot be set to <c>false</c>.
    /// See <see cref="M:SpaceCenter.Parachute.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Parachutes")]
    public async Task<bool> GetParachutesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Parachutes", args);
    }

    /// <summary>
    /// Sets the deployment state of all parachutes.
    /// Cannot be set to <c>false</c>.
    /// See <see cref="M:SpaceCenter.Parachute.GetDeployed" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetParachutes(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Parachutes", args);
    }

    /// <summary>
    /// Sets the deployment state of all parachutes.
    /// Cannot be set to <c>false</c>.
    /// See <see cref="M:SpaceCenter.Parachute.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetParachutesAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Parachutes", args);
    }

    /// <summary>
    /// Gets the state of the pitch control.
    /// A value between -1 and 1.
    /// Equivalent to the w and s keys.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Pitch")]
    public float GetPitch()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_Pitch", args);
    }

    /// <summary>
    /// Gets the state of the pitch control.
    /// A value between -1 and 1.
    /// Equivalent to the w and s keys.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Pitch")]
    public async Task<float> GetPitchAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_Pitch", args);
    }

    /// <summary>
    /// Sets the state of the pitch control.
    /// A value between -1 and 1.
    /// Equivalent to the w and s keys.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetPitch(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Pitch", args);
    }

    /// <summary>
    /// Sets the state of the pitch control.
    /// A value between -1 and 1.
    /// Equivalent to the w and s keys.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetPitchAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Pitch", args);
    }

    /// <summary>
    /// Gets the state of RCS.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_RCS")]
    public bool GetRCS()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_RCS", args);
    }

    /// <summary>
    /// Gets the state of RCS.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_RCS")]
    public async Task<bool> GetRCSAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_RCS", args);
    }

    /// <summary>
    /// Sets the state of RCS.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRCS(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_RCS", args);
    }

    /// <summary>
    /// Sets the state of RCS.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRCSAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_RCS", args);
    }

    /// <summary>
    /// Returns whether all radiators on the vessel are deployed.
    /// See <see cref="M:SpaceCenter.Radiator.GetDeployed" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Radiators")]
    public bool GetRadiators()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Radiators", args);
    }

    /// <summary>
    /// Returns whether all radiators on the vessel are deployed.
    /// See <see cref="M:SpaceCenter.Radiator.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Radiators")]
    public async Task<bool> GetRadiatorsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Radiators", args);
    }

    /// <summary>
    /// Sets the deployment state of all radiators.
    /// See <see cref="M:SpaceCenter.Radiator.GetDeployed" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRadiators(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Radiators", args);
    }

    /// <summary>
    /// Sets the deployment state of all radiators.
    /// See <see cref="M:SpaceCenter.Radiator.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRadiatorsAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Radiators", args);
    }

    /// <summary>
    /// Returns whether all reactive wheels on the vessel are active.
    /// See <see cref="M:SpaceCenter.ReactionWheel.GetActive" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_ReactionWheels")]
    public bool GetReactionWheels()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_ReactionWheels", args);
    }

    /// <summary>
    /// Returns whether all reactive wheels on the vessel are active.
    /// See <see cref="M:SpaceCenter.ReactionWheel.GetActive" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_ReactionWheels")]
    public async Task<bool> GetReactionWheelsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_ReactionWheels", args);
    }

    /// <summary>
    /// Sets the active state of all reaction wheels.
    /// See <see cref="M:SpaceCenter.ReactionWheel.GetActive" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetReactionWheels(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_ReactionWheels", args);
    }

    /// <summary>
    /// Sets the active state of all reaction wheels.
    /// See <see cref="M:SpaceCenter.ReactionWheel.GetActive" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetReactionWheelsAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_ReactionWheels", args);
    }

    /// <summary>
    /// Returns whether all of the resource harvesters on the vessel are deployed.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.GetDeployed" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_ResourceHarvesters")]
    public bool GetResourceHarvesters()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_ResourceHarvesters", args);
    }

    /// <summary>
    /// Returns whether all of the resource harvesters on the vessel are deployed.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_ResourceHarvesters")]
    public async Task<bool> GetResourceHarvestersAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_ResourceHarvesters", args);
    }

    /// <summary>
    /// Sets the deployment state of all resource harvesters.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.GetDeployed" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetResourceHarvesters(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_ResourceHarvesters", args);
    }

    /// <summary>
    /// Sets the deployment state of all resource harvesters.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetResourceHarvestersAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_ResourceHarvesters", args);
    }

    /// <summary>
    /// Returns whether any of the resource harvesters on the vessel are active.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.GetActive" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_ResourceHarvestersActive")]
    public bool GetResourceHarvestersActive()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_ResourceHarvestersActive", args);
    }

    /// <summary>
    /// Returns whether any of the resource harvesters on the vessel are active.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.GetActive" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_ResourceHarvestersActive")]
    public async Task<bool> GetResourceHarvestersActiveAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_ResourceHarvestersActive", args);
    }

    /// <summary>
    /// Sets the active state of all resource harvesters.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.GetActive" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetResourceHarvestersActive(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_ResourceHarvestersActive", args);
    }

    /// <summary>
    /// Sets the active state of all resource harvesters.
    /// See <see cref="M:SpaceCenter.ResourceHarvester.GetActive" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetResourceHarvestersActiveAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_ResourceHarvestersActive", args);
    }

    /// <summary>
    /// Gets the state of the right translational control.
    /// A value between -1 and 1.
    /// Equivalent to the j and l keys.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Right")]
    public float GetRight()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_Right", args);
    }

    /// <summary>
    /// Gets the state of the right translational control.
    /// A value between -1 and 1.
    /// Equivalent to the j and l keys.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Right")]
    public async Task<float> GetRightAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_Right", args);
    }

    /// <summary>
    /// Sets the state of the right translational control.
    /// A value between -1 and 1.
    /// Equivalent to the j and l keys.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRight(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Right", args);
    }

    /// <summary>
    /// Sets the state of the right translational control.
    /// A value between -1 and 1.
    /// Equivalent to the j and l keys.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRightAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Right", args);
    }

    /// <summary>
    /// Gets the state of the roll control.
    /// A value between -1 and 1.
    /// Equivalent to the q and e keys.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Roll")]
    public float GetRoll()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_Roll", args);
    }

    /// <summary>
    /// Gets the state of the roll control.
    /// A value between -1 and 1.
    /// Equivalent to the q and e keys.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Roll")]
    public async Task<float> GetRollAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_Roll", args);
    }

    /// <summary>
    /// Sets the state of the roll control.
    /// A value between -1 and 1.
    /// Equivalent to the q and e keys.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRoll(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Roll", args);
    }

    /// <summary>
    /// Sets the state of the roll control.
    /// A value between -1 and 1.
    /// Equivalent to the q and e keys.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRollAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Roll", args);
    }

    /// <summary>
    /// Gets the state of SAS.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.GetSAS" /></remarks>
    [Rpc("SpaceCenter", "Control_get_SAS")]
    public bool GetSAS()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_SAS", args);
    }

    /// <summary>
    /// Gets the state of SAS.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.GetSAS" /></remarks>
    [Rpc("SpaceCenter", "Control_get_SAS")]
    public async Task<bool> GetSASAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_SAS", args);
    }

    /// <summary>
    /// Sets the state of SAS.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSAS(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_SAS", args);
    }

    /// <summary>
    /// Sets the state of SAS.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetSASAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_SAS", args);
    }

    /// <summary>
    /// Gets the current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to
    /// the left of the navball that appear when SAS is enabled.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.GetSASMode" /></remarks>
    [Rpc("SpaceCenter", "Control_get_SASMode")]
    public SASMode GetSASMode()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<SASMode>("SpaceCenter", "Control_get_SASMode", args);
    }

    /// <summary>
    /// Gets the current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to
    /// the left of the navball that appear when SAS is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.AutoPilot.GetSASMode" /></remarks>
    [Rpc("SpaceCenter", "Control_get_SASMode")]
    public async Task<SASMode> GetSASModeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<SASMode>("SpaceCenter", "Control_get_SASMode", args);
    }

    /// <summary>
    /// Sets the current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to
    /// the left of the navball that appear when SAS is enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSASMode(SASMode value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_SASMode", args);
    }

    /// <summary>
    /// Sets the current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to
    /// the left of the navball that appear when SAS is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetSASModeAsync(SASMode value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_SASMode", args);
    }

    /// <summary>
    /// Returns whether all solar panels on the vessel are deployed.
    /// See <see cref="M:SpaceCenter.SolarPanel.GetDeployed" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_SolarPanels")]
    public bool GetSolarPanels()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_SolarPanels", args);
    }

    /// <summary>
    /// Returns whether all solar panels on the vessel are deployed.
    /// See <see cref="M:SpaceCenter.SolarPanel.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_SolarPanels")]
    public async Task<bool> GetSolarPanelsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_SolarPanels", args);
    }

    /// <summary>
    /// Sets the deployment state of all solar panels.
    /// See <see cref="M:SpaceCenter.SolarPanel.GetDeployed" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSolarPanels(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_SolarPanels", args);
    }

    /// <summary>
    /// Sets the deployment state of all solar panels.
    /// See <see cref="M:SpaceCenter.SolarPanel.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetSolarPanelsAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_SolarPanels", args);
    }

    /// <summary>
    /// Gets the source of the vessels control, for example by a kerbal or a probe core.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Source")]
    public ControlSource GetSource()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ControlSource>("SpaceCenter", "Control_get_Source", args);
    }

    /// <summary>
    /// Gets the source of the vessels control, for example by a kerbal or a probe core.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Source")]
    public async Task<ControlSource> GetSourceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ControlSource>("SpaceCenter", "Control_get_Source", args);
    }

    /// <summary>
    /// Gets the current <see cref="T:SpaceCenter.SpeedMode" /> of the navball.
    /// This is the mode displayed next to the speed at the top of the navball.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_SpeedMode")]
    public SpeedMode GetSpeedMode()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<SpeedMode>("SpaceCenter", "Control_get_SpeedMode", args);
    }

    /// <summary>
    /// Gets the current <see cref="T:SpaceCenter.SpeedMode" /> of the navball.
    /// This is the mode displayed next to the speed at the top of the navball.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_SpeedMode")]
    public async Task<SpeedMode> GetSpeedModeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<SpeedMode>("SpaceCenter", "Control_get_SpeedMode", args);
    }

    /// <summary>
    /// Sets the current <see cref="T:SpaceCenter.SpeedMode" /> of the navball.
    /// This is the mode displayed next to the speed at the top of the navball.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSpeedMode(SpeedMode value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_SpeedMode", args);
    }

    /// <summary>
    /// Sets the current <see cref="T:SpaceCenter.SpeedMode" /> of the navball.
    /// This is the mode displayed next to the speed at the top of the navball.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetSpeedModeAsync(SpeedMode value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_SpeedMode", args);
    }

    /// <summary>
    /// Gets whether staging is locked on the vessel.
    /// </summary>
    /// <remarks>
    /// This is equivalent to locking the staging using Alt+L
    /// </remarks>
    [Rpc("SpaceCenter", "Control_get_StageLock")]
    public bool GetStageLock()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_StageLock", args);
    }

    /// <summary>
    /// Gets whether staging is locked on the vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// This is equivalent to locking the staging using Alt+L
    /// </remarks>
    [Rpc("SpaceCenter", "Control_get_StageLock")]
    public async Task<bool> GetStageLockAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_StageLock", args);
    }

    /// <summary>
    /// Sets whether staging is locked on the vessel.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetStageLock(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_StageLock", args);
    }

    /// <summary>
    /// Sets whether staging is locked on the vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetStageLockAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_StageLock", args);
    }

    /// <summary>
    /// Gets the control state of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_State")]
    public ControlState GetState()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ControlState>("SpaceCenter", "Control_get_State", args);
    }

    /// <summary>
    /// Gets the control state of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_State")]
    public async Task<ControlState> GetStateAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ControlState>("SpaceCenter", "Control_get_State", args);
    }

    /// <summary>
    /// Gets the state of the throttle. A value between 0 and 1.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Throttle")]
    public float GetThrottle()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_Throttle", args);
    }

    /// <summary>
    /// Gets the state of the throttle. A value between 0 and 1.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Throttle")]
    public async Task<float> GetThrottleAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_Throttle", args);
    }

    /// <summary>
    /// Sets the state of the throttle. A value between 0 and 1.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetThrottle(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Throttle", args);
    }

    /// <summary>
    /// Sets the state of the throttle. A value between 0 and 1.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetThrottleAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Throttle", args);
    }

    /// <summary>
    /// Gets the state of the up translational control.
    /// A value between -1 and 1.
    /// Equivalent to the i and k keys.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Up")]
    public float GetUp()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_Up", args);
    }

    /// <summary>
    /// Gets the state of the up translational control.
    /// A value between -1 and 1.
    /// Equivalent to the i and k keys.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Up")]
    public async Task<float> GetUpAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_Up", args);
    }

    /// <summary>
    /// Sets the state of the up translational control.
    /// A value between -1 and 1.
    /// Equivalent to the i and k keys.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetUp(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Up", args);
    }

    /// <summary>
    /// Sets the state of the up translational control.
    /// A value between -1 and 1.
    /// Equivalent to the i and k keys.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetUpAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Up", args);
    }

    /// <summary>
    /// Gets the state of the wheel steering.
    /// A value between -1 and 1.
    /// A value of 1 steers to the left, and a value of -1 steers to the right.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_WheelSteering")]
    public float GetWheelSteering()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_WheelSteering", args);
    }

    /// <summary>
    /// Gets the state of the wheel steering.
    /// A value between -1 and 1.
    /// A value of 1 steers to the left, and a value of -1 steers to the right.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_WheelSteering")]
    public async Task<float> GetWheelSteeringAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_WheelSteering", args);
    }

    /// <summary>
    /// Sets the state of the wheel steering.
    /// A value between -1 and 1.
    /// A value of 1 steers to the left, and a value of -1 steers to the right.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetWheelSteering(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_WheelSteering", args);
    }

    /// <summary>
    /// Sets the state of the wheel steering.
    /// A value between -1 and 1.
    /// A value of 1 steers to the left, and a value of -1 steers to the right.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetWheelSteeringAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_WheelSteering", args);
    }

    /// <summary>
    /// Gets the state of the wheel throttle.
    /// A value between -1 and 1.
    /// A value of 1 rotates the wheels forwards, a value of -1 rotates
    /// the wheels backwards.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_WheelThrottle")]
    public float GetWheelThrottle()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_WheelThrottle", args);
    }

    /// <summary>
    /// Gets the state of the wheel throttle.
    /// A value between -1 and 1.
    /// A value of 1 rotates the wheels forwards, a value of -1 rotates
    /// the wheels backwards.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_WheelThrottle")]
    public async Task<float> GetWheelThrottleAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_WheelThrottle", args);
    }

    /// <summary>
    /// Sets the state of the wheel throttle.
    /// A value between -1 and 1.
    /// A value of 1 rotates the wheels forwards, a value of -1 rotates
    /// the wheels backwards.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetWheelThrottle(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_WheelThrottle", args);
    }

    /// <summary>
    /// Sets the state of the wheel throttle.
    /// A value between -1 and 1.
    /// A value of 1 rotates the wheels forwards, a value of -1 rotates
    /// the wheels backwards.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetWheelThrottleAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_WheelThrottle", args);
    }

    /// <summary>
    /// Returns whether all wheels on the vessel are deployed.
    /// Does not include landing legs.
    /// See <see cref="M:SpaceCenter.Wheel.GetDeployed" />.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Wheels")]
    public bool GetWheels()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Control_get_Wheels", args);
    }

    /// <summary>
    /// Returns whether all wheels on the vessel are deployed.
    /// Does not include landing legs.
    /// See <see cref="M:SpaceCenter.Wheel.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Wheels")]
    public async Task<bool> GetWheelsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Control_get_Wheels", args);
    }

    /// <summary>
    /// Sets the deployment state of all wheels.
    /// Does not include landing legs.
    /// See <see cref="M:SpaceCenter.Wheel.GetDeployed" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetWheels(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Wheels", args);
    }

    /// <summary>
    /// Sets the deployment state of all wheels.
    /// Does not include landing legs.
    /// See <see cref="M:SpaceCenter.Wheel.GetDeployed" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetWheelsAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Wheels", args);
    }

    /// <summary>
    /// Gets the state of the yaw control.
    /// A value between -1 and 1.
    /// Equivalent to the a and d keys.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Yaw")]
    public float GetYaw()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Control_get_Yaw", args);
    }

    /// <summary>
    /// Gets the state of the yaw control.
    /// A value between -1 and 1.
    /// Equivalent to the a and d keys.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Control_get_Yaw")]
    public async Task<float> GetYawAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Control_get_Yaw", args);
    }

    /// <summary>
    /// Sets the state of the yaw control.
    /// A value between -1 and 1.
    /// Equivalent to the a and d keys.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetYaw(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Control_set_Yaw", args);
    }

    /// <summary>
    /// Sets the state of the yaw control.
    /// A value between -1 and 1.
    /// Equivalent to the a and d keys.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetYawAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Control_set_Yaw", args);
    }
}
