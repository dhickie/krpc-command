using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// An engine, including ones of various types.
/// For example liquid fuelled gimballed engines, solid rocket boosters and jet engines.
/// Obtained by calling <see cref="M:SpaceCenter.Part.GetEngine" />.
/// </summary>
/// <remarks>
/// For RCS thrusters <see cref="M:SpaceCenter.Part.GetRCS" />.
/// </remarks>
public class Engine : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Engine(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and with its throttle set to 100%.
    /// Returns zero if the engine does not have any fuel.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Engine_AvailableThrustAt")]
    public float AvailableThrustAt(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_AvailableThrustAt", args);
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and with its throttle set to 100%.
    /// Returns zero if the engine does not have any fuel.
    /// Takes the given pressure into account.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Engine_AvailableThrustAt")]
    public async Task<float> AvailableThrustAtAsync(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_AvailableThrustAt", args);
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and fueled, with its throttle and throttle limiter set to 100%.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Engine_MaxThrustAt")]
    public float MaxThrustAt(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_MaxThrustAt", args);
    }

    /// <summary>
    /// The amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and fueled, with its throttle and throttle limiter set to 100%.
    /// Takes the given pressure into account.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Engine_MaxThrustAt")]
    public async Task<float> MaxThrustAtAsync(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_MaxThrustAt", args);
    }

    /// <summary>
    /// The specific impulse of the engine under the given pressure, in seconds. Returns zero
    /// if the engine is not active.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Engine_SpecificImpulseAt")]
    public float SpecificImpulseAt(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_SpecificImpulseAt", args);
    }

    /// <summary>
    /// The specific impulse of the engine under the given pressure, in seconds. Returns zero
    /// if the engine is not active.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Engine_SpecificImpulseAt")]
    public async Task<float> SpecificImpulseAtAsync(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_SpecificImpulseAt", args);
    }

    /// <summary>
    /// Toggle the current engine mode.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_ToggleMode")]
    public void ToggleMode()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Engine_ToggleMode", args);
    }

    /// <summary>
    /// Toggle the current engine mode.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_ToggleMode")]
    public async Task ToggleModeAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Engine_ToggleMode", args);
    }

    /// <summary>
    /// Gets whether the engine is active. Setting this attribute may have no effect,
    /// depending on <see cref="M:SpaceCenter.Engine.GetCanShutdown" /> and <see cref="M:SpaceCenter.Engine.GetCanRestart" />.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Active")]
    public bool GetActive()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_Active", args);
    }

    /// <summary>
    /// Gets whether the engine is active. Setting this attribute may have no effect,
    /// depending on <see cref="M:SpaceCenter.Engine.GetCanShutdown" /> and <see cref="M:SpaceCenter.Engine.GetCanRestart" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Active")]
    public async Task<bool> GetActiveAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_Active", args);
    }

    /// <summary>
    /// Sets whether the engine is active. Setting this attribute may have no effect,
    /// depending on <see cref="M:SpaceCenter.Engine.GetCanShutdown" /> and <see cref="M:SpaceCenter.Engine.GetCanRestart" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetActive(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Engine_set_Active", args);
    }

    /// <summary>
    /// Sets whether the engine is active. Setting this attribute may have no effect,
    /// depending on <see cref="M:SpaceCenter.Engine.GetCanShutdown" /> and <see cref="M:SpaceCenter.Engine.GetCanRestart" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetActiveAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Engine_set_Active", args);
    }

    /// <summary>
    /// Gets whether the engine will automatically switch modes.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_AutoModeSwitch")]
    public bool GetAutoModeSwitch()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_AutoModeSwitch", args);
    }

    /// <summary>
    /// Gets whether the engine will automatically switch modes.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_AutoModeSwitch")]
    public async Task<bool> GetAutoModeSwitchAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_AutoModeSwitch", args);
    }

    /// <summary>
    /// Sets whether the engine will automatically switch modes.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetAutoModeSwitch(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Engine_set_AutoModeSwitch", args);
    }

    /// <summary>
    /// Sets whether the engine will automatically switch modes.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetAutoModeSwitchAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Engine_set_AutoModeSwitch", args);
    }

    /// <summary>
    /// Gets the amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and with its throttle set to 100%.
    /// Returns zero if the engine does not have any fuel.
    /// Takes the engine's current <see cref="M:SpaceCenter.Engine.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_AvailableThrust")]
    public float GetAvailableThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_AvailableThrust", args);
    }

    /// <summary>
    /// Gets the amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and with its throttle set to 100%.
    /// Returns zero if the engine does not have any fuel.
    /// Takes the engine's current <see cref="M:SpaceCenter.Engine.GetThrustLimit" /> and atmospheric conditions
    /// into account.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_AvailableThrust")]
    public async Task<float> GetAvailableThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_AvailableThrust", args);
    }

    /// <summary>
    /// Gets the available torque, in Newton meters, that can be produced by this engine,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// Returns zero if the engine is inactive, or not gimballed.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_AvailableTorque")]
    public Tuple<Tuple<double,double,double>,Tuple<double,double,double>> GetAvailableTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>>("SpaceCenter", "Engine_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets the available torque, in Newton meters, that can be produced by this engine,
    /// in the positive and negative pitch, roll and yaw axes of the vessel. These axes
    /// correspond to the coordinate axes of the <see cref="M:SpaceCenter.Vessel.GetReferenceFrame" />.
    /// Returns zero if the engine is inactive, or not gimballed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_AvailableTorque")]
    public async Task<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>> GetAvailableTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Tuple<double,double,double>,Tuple<double,double,double>>>("SpaceCenter", "Engine_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets whether the engine can be restarted once shutdown. If the engine cannot be shutdown,
    /// returns <c>false</c>. For example, this is <c>true</c> for liquid fueled rockets
    /// and <c>false</c> for solid rocket boosters.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_CanRestart")]
    public bool GetCanRestart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_CanRestart", args);
    }

    /// <summary>
    /// Gets whether the engine can be restarted once shutdown. If the engine cannot be shutdown,
    /// returns <c>false</c>. For example, this is <c>true</c> for liquid fueled rockets
    /// and <c>false</c> for solid rocket boosters.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_CanRestart")]
    public async Task<bool> GetCanRestartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_CanRestart", args);
    }

    /// <summary>
    /// Gets whether the engine can be shutdown once activated. For example, this is
    /// <c>true</c> for liquid fueled rockets and <c>false</c> for solid rocket boosters.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_CanShutdown")]
    public bool GetCanShutdown()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_CanShutdown", args);
    }

    /// <summary>
    /// Gets whether the engine can be shutdown once activated. For example, this is
    /// <c>true</c> for liquid fueled rockets and <c>false</c> for solid rocket boosters.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_CanShutdown")]
    public async Task<bool> GetCanShutdownAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_CanShutdown", args);
    }

    /// <summary>
    /// Gets the gimbal limiter of the engine. A value between 0 and 1.
    /// Returns 0 if the gimbal is locked.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_GimbalLimit")]
    public float GetGimbalLimit()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_GimbalLimit", args);
    }

    /// <summary>
    /// Gets the gimbal limiter of the engine. A value between 0 and 1.
    /// Returns 0 if the gimbal is locked.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_GimbalLimit")]
    public async Task<float> GetGimbalLimitAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_GimbalLimit", args);
    }

    /// <summary>
    /// Sets the gimbal limiter of the engine. A value between 0 and 1.
    /// Returns 0 if the gimbal is locked.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetGimbalLimit(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Engine_set_GimbalLimit", args);
    }

    /// <summary>
    /// Sets the gimbal limiter of the engine. A value between 0 and 1.
    /// Returns 0 if the gimbal is locked.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetGimbalLimitAsync(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Engine_set_GimbalLimit", args);
    }

    /// <summary>
    /// Gets whether the engines gimbal is locked in place. Setting this attribute has
    /// no effect if the engine is not gimballed.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_GimbalLocked")]
    public bool GetGimbalLocked()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_GimbalLocked", args);
    }

    /// <summary>
    /// Gets whether the engines gimbal is locked in place. Setting this attribute has
    /// no effect if the engine is not gimballed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_GimbalLocked")]
    public async Task<bool> GetGimbalLockedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_GimbalLocked", args);
    }

    /// <summary>
    /// Sets whether the engines gimbal is locked in place. Setting this attribute has
    /// no effect if the engine is not gimballed.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetGimbalLocked(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Engine_set_GimbalLocked", args);
    }

    /// <summary>
    /// Sets whether the engines gimbal is locked in place. Setting this attribute has
    /// no effect if the engine is not gimballed.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetGimbalLockedAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Engine_set_GimbalLocked", args);
    }

    /// <summary>
    /// Gets the range over which the gimbal can move, in degrees.
    /// Returns 0 if the engine is not gimballed.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_GimbalRange")]
    public float GetGimbalRange()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_GimbalRange", args);
    }

    /// <summary>
    /// Gets the range over which the gimbal can move, in degrees.
    /// Returns 0 if the engine is not gimballed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_GimbalRange")]
    public async Task<float> GetGimbalRangeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_GimbalRange", args);
    }

    /// <summary>
    /// Gets whether the engine is gimballed.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Gimballed")]
    public bool GetGimballed()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_Gimballed", args);
    }

    /// <summary>
    /// Gets whether the engine is gimballed.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Gimballed")]
    public async Task<bool> GetGimballedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_Gimballed", args);
    }

    /// <summary>
    /// Gets whether the engine has any fuel available.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_HasFuel")]
    public bool GetHasFuel()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_HasFuel", args);
    }

    /// <summary>
    /// Gets whether the engine has any fuel available.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_HasFuel")]
    public async Task<bool> GetHasFuelAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_HasFuel", args);
    }

    /// <summary>
    /// Gets whether the engine has multiple modes of operation.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_HasModes")]
    public bool GetHasModes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_HasModes", args);
    }

    /// <summary>
    /// Gets whether the engine has multiple modes of operation.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_HasModes")]
    public async Task<bool> GetHasModesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_HasModes", args);
    }

    /// <summary>
    /// Gets whether the independent throttle is enabled for the engine.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_IndependentThrottle")]
    public bool GetIndependentThrottle()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_IndependentThrottle", args);
    }

    /// <summary>
    /// Gets whether the independent throttle is enabled for the engine.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_IndependentThrottle")]
    public async Task<bool> GetIndependentThrottleAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_IndependentThrottle", args);
    }

    /// <summary>
    /// Sets whether the independent throttle is enabled for the engine.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetIndependentThrottle(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Engine_set_IndependentThrottle", args);
    }

    /// <summary>
    /// Sets whether the independent throttle is enabled for the engine.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetIndependentThrottleAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Engine_set_IndependentThrottle", args);
    }

    /// <summary>
    /// Gets the specific impulse of the engine at sea level on Kerbin, in seconds.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_KerbinSeaLevelSpecificImpulse")]
    public float GetKerbinSeaLevelSpecificImpulse()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_KerbinSeaLevelSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the specific impulse of the engine at sea level on Kerbin, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_KerbinSeaLevelSpecificImpulse")]
    public async Task<float> GetKerbinSeaLevelSpecificImpulseAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_KerbinSeaLevelSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and fueled, with its throttle and throttle limiter set to 100%.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_MaxThrust")]
    public float GetMaxThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_MaxThrust", args);
    }

    /// <summary>
    /// Gets the amount of thrust, in Newtons, that would be produced by the engine
    /// when activated and fueled, with its throttle and throttle limiter set to 100%.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_MaxThrust")]
    public async Task<float> GetMaxThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_MaxThrust", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the engine in a
    /// vacuum, in Newtons. This is the amount of thrust produced by the engine
    /// when activated, <see cref="M:SpaceCenter.Engine.GetThrustLimit" /> is set to 100%, the main
    /// vessel's throttle is set to 100% and the engine is in a vacuum.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_MaxVacuumThrust")]
    public float GetMaxVacuumThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_MaxVacuumThrust", args);
    }

    /// <summary>
    /// Gets the maximum amount of thrust that can be produced by the engine in a
    /// vacuum, in Newtons. This is the amount of thrust produced by the engine
    /// when activated, <see cref="M:SpaceCenter.Engine.GetThrustLimit" /> is set to 100%, the main
    /// vessel's throttle is set to 100% and the engine is in a vacuum.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_MaxVacuumThrust")]
    public async Task<float> GetMaxVacuumThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_MaxVacuumThrust", args);
    }

    /// <summary>
    /// Gets the name of the current engine mode.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Mode")]
    public string GetMode()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Engine_get_Mode", args);
    }

    /// <summary>
    /// Gets the name of the current engine mode.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Mode")]
    public async Task<string> GetModeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Engine_get_Mode", args);
    }

    /// <summary>
    /// Sets the name of the current engine mode.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetMode(string value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Engine_set_Mode", args);
    }

    /// <summary>
    /// Sets the name of the current engine mode.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetModeAsync(string value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Engine_set_Mode", args);
    }

    /// <summary>
    /// Gets the available modes for the engine.
    /// A dictionary mapping mode names to <see cref="T:SpaceCenter.Engine" /> objects.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Modes")]
    public IDictionary<string,Engine> GetModes()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IDictionary<string,Engine>>("SpaceCenter", "Engine_get_Modes", args);
    }

    /// <summary>
    /// Gets the available modes for the engine.
    /// A dictionary mapping mode names to <see cref="T:SpaceCenter.Engine" /> objects.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Modes")]
    public async Task<IDictionary<string,Engine>> GetModesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IDictionary<string,Engine>>("SpaceCenter", "Engine_get_Modes", args);
    }

    /// <summary>
    /// Gets the part object for this engine.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Engine_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this engine.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Engine_get_Part", args);
    }

    /// <summary>
    /// Gets the names of the propellants that the engine consumes.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_PropellantNames")]
    public IList<string> GetPropellantNames()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "Engine_get_PropellantNames", args);
    }

    /// <summary>
    /// Gets the names of the propellants that the engine consumes.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_PropellantNames")]
    public async Task<IList<string>> GetPropellantNamesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "Engine_get_PropellantNames", args);
    }

    /// <summary>
    /// Gets the ratio of resources that the engine consumes. A dictionary mapping resource names
    /// to the ratio at which they are consumed by the engine.
    /// </summary>
    /// <remarks>
    /// For example, if the ratios are 0.6 for LiquidFuel and 0.4 for Oxidizer, then for every
    /// 0.6 units of LiquidFuel that the engine burns, it will burn 0.4 units of Oxidizer.
    /// </remarks>
    [Rpc("SpaceCenter", "Engine_get_PropellantRatios")]
    public IDictionary<string,float> GetPropellantRatios()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IDictionary<string,float>>("SpaceCenter", "Engine_get_PropellantRatios", args);
    }

    /// <summary>
    /// Gets the ratio of resources that the engine consumes. A dictionary mapping resource names
    /// to the ratio at which they are consumed by the engine.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// For example, if the ratios are 0.6 for LiquidFuel and 0.4 for Oxidizer, then for every
    /// 0.6 units of LiquidFuel that the engine burns, it will burn 0.4 units of Oxidizer.
    /// </remarks>
    [Rpc("SpaceCenter", "Engine_get_PropellantRatios")]
    public async Task<IDictionary<string,float>> GetPropellantRatiosAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IDictionary<string,float>>("SpaceCenter", "Engine_get_PropellantRatios", args);
    }

    /// <summary>
    /// Gets the propellants that the engine consumes.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Propellants")]
    public IList<Propellant> GetPropellants()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Propellant>>("SpaceCenter", "Engine_get_Propellants", args);
    }

    /// <summary>
    /// Gets the propellants that the engine consumes.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Propellants")]
    public async Task<IList<Propellant>> GetPropellantsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Propellant>>("SpaceCenter", "Engine_get_Propellants", args);
    }

    /// <summary>
    /// Gets the current specific impulse of the engine, in seconds. Returns zero
    /// if the engine is not active.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_SpecificImpulse")]
    public float GetSpecificImpulse()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_SpecificImpulse", args);
    }

    /// <summary>
    /// Gets the current specific impulse of the engine, in seconds. Returns zero
    /// if the engine is not active.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_SpecificImpulse")]
    public async Task<float> GetSpecificImpulseAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_SpecificImpulse", args);
    }

    /// <summary>
    /// Gets the current throttle setting for the engine. A value between 0 and 1.
    /// This is not necessarily the same as the vessel's main throttle
    /// setting, as some engines take time to adjust their throttle
    /// (such as jet engines), or independent throttle may be enabled.
    ///
    /// When the engine's independent throttle is enabled
    /// (see <see cref="M:SpaceCenter.Engine.GetIndependentThrottle" />), can be used to set the throttle percentage.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Throttle")]
    public float GetThrottle()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_Throttle", args);
    }

    /// <summary>
    /// Gets the current throttle setting for the engine. A value between 0 and 1.
    /// This is not necessarily the same as the vessel's main throttle
    /// setting, as some engines take time to adjust their throttle
    /// (such as jet engines), or independent throttle may be enabled.
    ///
    /// When the engine's independent throttle is enabled
    /// (see <see cref="M:SpaceCenter.Engine.GetIndependentThrottle" />), can be used to set the throttle percentage.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Throttle")]
    public async Task<float> GetThrottleAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_Throttle", args);
    }

    /// <summary>
    /// Sets the current throttle setting for the engine. A value between 0 and 1.
    /// This is not necessarily the same as the vessel's main throttle
    /// setting, as some engines take time to adjust their throttle
    /// (such as jet engines), or independent throttle may be enabled.
    ///
    /// When the engine's independent throttle is enabled
    /// (see <see cref="M:SpaceCenter.Engine.GetIndependentThrottle" />), can be used to set the throttle percentage.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetThrottle(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Engine_set_Throttle", args);
    }

    /// <summary>
    /// Sets the current throttle setting for the engine. A value between 0 and 1.
    /// This is not necessarily the same as the vessel's main throttle
    /// setting, as some engines take time to adjust their throttle
    /// (such as jet engines), or independent throttle may be enabled.
    ///
    /// When the engine's independent throttle is enabled
    /// (see <see cref="M:SpaceCenter.Engine.GetIndependentThrottle" />), can be used to set the throttle percentage.
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
        await Connection.InvokeAsync("SpaceCenter", "Engine_set_Throttle", args);
    }

    /// <summary>
    /// Gets whether the <see cref="M:SpaceCenter.Control.GetThrottle" /> affects the engine. For example,
    /// this is <c>true</c> for liquid fueled rockets, and <c>false</c> for solid rocket
    /// boosters.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_ThrottleLocked")]
    public bool GetThrottleLocked()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Engine_get_ThrottleLocked", args);
    }

    /// <summary>
    /// Gets whether the <see cref="M:SpaceCenter.Control.GetThrottle" /> affects the engine. For example,
    /// this is <c>true</c> for liquid fueled rockets, and <c>false</c> for solid rocket
    /// boosters.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_ThrottleLocked")]
    public async Task<bool> GetThrottleLockedAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Engine_get_ThrottleLocked", args);
    }

    /// <summary>
    /// Gets the current amount of thrust being produced by the engine, in Newtons.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Thrust")]
    public float GetThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_Thrust", args);
    }

    /// <summary>
    /// Gets the current amount of thrust being produced by the engine, in Newtons.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_Thrust")]
    public async Task<float> GetThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_Thrust", args);
    }

    /// <summary>
    /// Gets the thrust limiter of the engine. A value between 0 and 1. Setting this
    /// attribute may have no effect, for example the thrust limit for a solid
    /// rocket booster cannot be changed in flight.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_ThrustLimit")]
    public float GetThrustLimit()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_ThrustLimit", args);
    }

    /// <summary>
    /// Gets the thrust limiter of the engine. A value between 0 and 1. Setting this
    /// attribute may have no effect, for example the thrust limit for a solid
    /// rocket booster cannot be changed in flight.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_ThrustLimit")]
    public async Task<float> GetThrustLimitAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_ThrustLimit", args);
    }

    /// <summary>
    /// Sets the thrust limiter of the engine. A value between 0 and 1. Setting this
    /// attribute may have no effect, for example the thrust limit for a solid
    /// rocket booster cannot be changed in flight.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetThrustLimit(float value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Engine_set_ThrustLimit", args);
    }

    /// <summary>
    /// Sets the thrust limiter of the engine. A value between 0 and 1. Setting this
    /// attribute may have no effect, for example the thrust limit for a solid
    /// rocket booster cannot be changed in flight.
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
        await Connection.InvokeAsync("SpaceCenter", "Engine_set_ThrustLimit", args);
    }

    /// <summary>
    /// Gets the components of the engine that generate thrust.
    /// </summary>
    /// <remarks>
    /// For example, this corresponds to the rocket nozzel on a solid rocket booster,
    /// or the individual nozzels on a RAPIER engine.
    /// The overall thrust produced by the engine, as reported by <see cref="M:SpaceCenter.Engine.GetAvailableThrust" />,
    /// <see cref="M:SpaceCenter.Engine.GetMaxThrust" /> and others, is the sum of the thrust generated by each thruster.
    /// </remarks>
    [Rpc("SpaceCenter", "Engine_get_Thrusters")]
    public IList<Thruster> GetThrusters()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<Thruster>>("SpaceCenter", "Engine_get_Thrusters", args);
    }

    /// <summary>
    /// Gets the components of the engine that generate thrust.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// For example, this corresponds to the rocket nozzel on a solid rocket booster,
    /// or the individual nozzels on a RAPIER engine.
    /// The overall thrust produced by the engine, as reported by <see cref="M:SpaceCenter.Engine.GetAvailableThrust" />,
    /// <see cref="M:SpaceCenter.Engine.GetMaxThrust" /> and others, is the sum of the thrust generated by each thruster.
    /// </remarks>
    [Rpc("SpaceCenter", "Engine_get_Thrusters")]
    public async Task<IList<Thruster>> GetThrustersAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<Thruster>>("SpaceCenter", "Engine_get_Thrusters", args);
    }

    /// <summary>
    /// Gets the vacuum specific impulse of the engine, in seconds.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_VacuumSpecificImpulse")]
    public float GetVacuumSpecificImpulse()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Engine_get_VacuumSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the vacuum specific impulse of the engine, in seconds.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Engine_get_VacuumSpecificImpulse")]
    public async Task<float> GetVacuumSpecificImpulseAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Engine_get_VacuumSpecificImpulse", args);
    }
}
