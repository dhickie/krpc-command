using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using MathNet.Spatial.Euclidean;
using MathNet.Spatial.Units;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// Provides basic auto-piloting utilities for a vessel.
/// Created by calling <see cref="M:SpaceCenter.Vessel.GetAutoPilot" />.
/// </summary>
/// <remarks>
/// If a client engages the auto-pilot and then closes its connection to the server,
/// the auto-pilot will be disengaged and its target reference frame, direction and roll
/// reset to default.
/// </remarks>
public class AutoPilot : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public AutoPilot(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Disengage the auto-pilot.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_Disengage")]
    public void Disengage()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_Disengage", args);
    }

    /// <summary>
    /// Disengage the auto-pilot.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_Disengage")]
    public async Task DisengageAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_Disengage", args);
    }

    /// <summary>
    /// Engage the auto-pilot.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_Engage")]
    public void Engage()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_Engage", args);
    }

    /// <summary>
    /// Engage the auto-pilot.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_Engage")]
    public async Task EngageAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_Engage", args);
    }

    /// <summary>
    /// Set target pitch and heading angles.
    /// </summary>
    /// <param name="pitch">Target pitch angle, between -90° and +90°.</param>
    /// <param name="heading">Target heading angle, between 0° and 360°.</param>
    [Rpc("SpaceCenter", "AutoPilot_TargetPitchAndHeading")]
    public void TargetPitchAndHeading(Angle pitch, Angle heading)
    {
        var args = new object[]
        {
            this,
            (float)pitch.Degrees,
            (float)heading.Degrees
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_TargetPitchAndHeading", args);
    }

    /// <summary>
    /// Set target pitch and heading angles.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="pitch">Target pitch angle, between -90° and +90°.</param>
    /// <param name="heading">Target heading angle, between 0° and 360°.</param>
    [Rpc("SpaceCenter", "AutoPilot_TargetPitchAndHeading")]
    public async Task TargetPitchAndHeadingAsync(Angle pitch, Angle heading)
    {
        var args = new object[]
        {
            this,
            (float)pitch.Degrees,
            (float)heading.Degrees
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_TargetPitchAndHeading", args);
    }

    /// <summary>
    /// Blocks until the vessel is pointing in the target direction and has
    /// the target roll (if set). Throws an exception if the auto-pilot has not been engaged.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_Wait")]
    public void Wait()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_Wait", args);
    }

    /// <summary>
    /// Blocks until the vessel is pointing in the target direction and has
    /// the target roll (if set). Throws an exception if the auto-pilot has not been engaged.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_Wait")]
    public async Task WaitAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_Wait", args);
    }

    /// <summary>
    /// Gets the angle at which the autopilot considers the vessel to be pointing
    /// close to the target.
    /// This determines the midpoint of the target velocity attenuation function.
    /// A vector of three angles, one for each of the pitch, roll and yaw axes.
    /// Defaults to 1° for each axis.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_AttenuationAngle")]
    public Tuple<Angle,Angle,Angle> GetAttenuationAngle()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_AttenuationAngle", args);
        return Tuple.Create(Angle.FromDegrees(result.Item1), Angle.FromDegrees(result.Item2), Angle.FromDegrees(result.Item3));
    }

    /// <summary>
    /// Gets the angle at which the autopilot considers the vessel to be pointing
    /// close to the target.
    /// This determines the midpoint of the target velocity attenuation function.
    /// A vector of three angles, one for each of the pitch, roll and yaw axes.
    /// Defaults to 1° for each axis.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_AttenuationAngle")]
    public async Task<Tuple<Angle,Angle,Angle>> GetAttenuationAngleAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_AttenuationAngle", args);
        return Tuple.Create(Angle.FromDegrees(result.Item1), Angle.FromDegrees(result.Item2), Angle.FromDegrees(result.Item3));
    }

    /// <summary>
    /// Sets the angle at which the autopilot considers the vessel to be pointing
    /// close to the target.
    /// This determines the midpoint of the target velocity attenuation function.
    /// A vector of three angles, one for each of the pitch, roll and yaw axes.
    /// Defaults to 1° for each axis.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetAttenuationAngle(Tuple<Angle,Angle,Angle> value)
    {
        var args = new object[]
        {
            this,
            Tuple.Create(value.Item1.Degrees, value.Item2.Degrees, value.Item3.Degrees)
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_AttenuationAngle", args);
    }

    /// <summary>
    /// Sets the angle at which the autopilot considers the vessel to be pointing
    /// close to the target.
    /// This determines the midpoint of the target velocity attenuation function.
    /// A vector of three angles, one for each of the pitch, roll and yaw axes.
    /// Defaults to 1° for each axis.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetAttenuationAngleAsync(Tuple<Angle,Angle,Angle> value)
    {
        var args = new object[]
        {
            this,
            Tuple.Create(value.Item1.Degrees, value.Item2.Degrees, value.Item3.Degrees)
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_AttenuationAngle", args);
    }

    /// <summary>
    /// Gets whether the rotation rate controllers PID parameters should be automatically tuned
    /// using the vessels moment of inertia and available torque. Defaults to <c>true</c>.
    /// See <see cref="M:SpaceCenter.AutoPilot.GetTimeToPeak" /> and <see cref="M:SpaceCenter.AutoPilot.GetOvershoot" />.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_AutoTune")]
    public bool GetAutoTune()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "AutoPilot_get_AutoTune", args);
    }

    /// <summary>
    /// Gets whether the rotation rate controllers PID parameters should be automatically tuned
    /// using the vessels moment of inertia and available torque. Defaults to <c>true</c>.
    /// See <see cref="M:SpaceCenter.AutoPilot.GetTimeToPeak" /> and <see cref="M:SpaceCenter.AutoPilot.GetOvershoot" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_AutoTune")]
    public async Task<bool> GetAutoTuneAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "AutoPilot_get_AutoTune", args);
    }

    /// <summary>
    /// Sets whether the rotation rate controllers PID parameters should be automatically tuned
    /// using the vessels moment of inertia and available torque. Defaults to <c>true</c>.
    /// See <see cref="M:SpaceCenter.AutoPilot.GetTimeToPeak" /> and <see cref="M:SpaceCenter.AutoPilot.GetOvershoot" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetAutoTune(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_AutoTune", args);
    }

    /// <summary>
    /// Sets whether the rotation rate controllers PID parameters should be automatically tuned
    /// using the vessels moment of inertia and available torque. Defaults to <c>true</c>.
    /// See <see cref="M:SpaceCenter.AutoPilot.GetTimeToPeak" /> and <see cref="M:SpaceCenter.AutoPilot.GetOvershoot" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetAutoTuneAsync(bool value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_AutoTune", args);
    }

    /// <summary>
    /// Gets the time the vessel should take to come to a stop pointing in the target direction.
    /// This determines the angular acceleration used to decelerate the vessel.
    /// A vector of three times, in seconds, one for each of the pitch, roll and yaw axes.
    /// Defaults to 5 seconds for each axis.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_DecelerationTime")]
    public Tuple<double,double,double> GetDecelerationTime()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_DecelerationTime", args);
    }

    /// <summary>
    /// Gets the time the vessel should take to come to a stop pointing in the target direction.
    /// This determines the angular acceleration used to decelerate the vessel.
    /// A vector of three times, in seconds, one for each of the pitch, roll and yaw axes.
    /// Defaults to 5 seconds for each axis.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_DecelerationTime")]
    public async Task<Tuple<double,double,double>> GetDecelerationTimeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_DecelerationTime", args);
    }

    /// <summary>
    /// Sets the time the vessel should take to come to a stop pointing in the target direction.
    /// This determines the angular acceleration used to decelerate the vessel.
    /// A vector of three times, in seconds, one for each of the pitch, roll and yaw axes.
    /// Defaults to 5 seconds for each axis.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetDecelerationTime(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_DecelerationTime", args);
    }

    /// <summary>
    /// Sets the time the vessel should take to come to a stop pointing in the target direction.
    /// This determines the angular acceleration used to decelerate the vessel.
    /// A vector of three times, in seconds, one for each of the pitch, roll and yaw axes.
    /// Defaults to 5 seconds for each axis.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetDecelerationTimeAsync(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_DecelerationTime", args);
    }

    /// <summary>
    /// Gets the error between the direction the ship has been asked
    /// to point in and the direction it is pointing in. Throws an exception if the auto-pilot
    /// has not been engaged and SAS is not enabled or is in stability assist mode.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_Error")]
    public Angle GetError()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "AutoPilot_get_Error", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gets the error between the direction the ship has been asked
    /// to point in and the direction it is pointing in. Throws an exception if the auto-pilot
    /// has not been engaged and SAS is not enabled or is in stability assist mode.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_Error")]
    public async Task<Angle> GetErrorAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "AutoPilot_get_Error", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gets the error between the vessels current and target heading.
    /// Throws an exception if the auto-pilot has not been engaged.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_HeadingError")]
    public Angle GetHeadingError()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "AutoPilot_get_HeadingError", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gets the error between the vessels current and target heading.
    /// Throws an exception if the auto-pilot has not been engaged.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_HeadingError")]
    public async Task<Angle> GetHeadingErrorAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "AutoPilot_get_HeadingError", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gets the target overshoot percentage used to autotune the PID controllers.
    /// A vector of three values, between 0 and 1, for each of the pitch, roll and yaw axes.
    /// Defaults to 0.01 for each axis.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_Overshoot")]
    public Tuple<double,double,double> GetOvershoot()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_Overshoot", args);
    }

    /// <summary>
    /// Gets the target overshoot percentage used to autotune the PID controllers.
    /// A vector of three values, between 0 and 1, for each of the pitch, roll and yaw axes.
    /// Defaults to 0.01 for each axis.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_Overshoot")]
    public async Task<Tuple<double,double,double>> GetOvershootAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_Overshoot", args);
    }

    /// <summary>
    /// Sets the target overshoot percentage used to autotune the PID controllers.
    /// A vector of three values, between 0 and 1, for each of the pitch, roll and yaw axes.
    /// Defaults to 0.01 for each axis.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetOvershoot(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_Overshoot", args);
    }

    /// <summary>
    /// Sets the target overshoot percentage used to autotune the PID controllers.
    /// A vector of three values, between 0 and 1, for each of the pitch, roll and yaw axes.
    /// Defaults to 0.01 for each axis.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetOvershootAsync(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_Overshoot", args);
    }

    /// <summary>
    /// Gets the error between the vessels current and target pitch.
    /// Throws an exception if the auto-pilot has not been engaged.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_PitchError")]
    public Angle GetPitchError()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "AutoPilot_get_PitchError", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gets the error between the vessels current and target pitch.
    /// Throws an exception if the auto-pilot has not been engaged.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_PitchError")]
    public async Task<Angle> GetPitchErrorAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "AutoPilot_get_PitchError", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gains for the pitch PID controller.
    /// </summary>
    /// <remarks>
    /// When <see cref="M:SpaceCenter.AutoPilot.GetAutoTune" /> is true, these values are updated automatically,
    /// which will overwrite any manual changes.
    /// </remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_PitchPIDGains")]
    public Tuple<double,double,double> GetPitchPIDGains()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_PitchPIDGains", args);
    }

    /// <summary>
    /// Gains for the pitch PID controller.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// When <see cref="M:SpaceCenter.AutoPilot.GetAutoTune" /> is true, these values are updated automatically,
    /// which will overwrite any manual changes.
    /// </remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_PitchPIDGains")]
    public async Task<Tuple<double,double,double>> GetPitchPIDGainsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_PitchPIDGains", args);
    }

    /// <summary>
    /// Sets gains for the pitch PID controller.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetPitchPIDGains(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_PitchPIDGains", args);
    }

    /// <summary>
    /// Sets gains for the pitch PID controller.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetPitchPIDGainsAsync(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_PitchPIDGains", args);
    }

    /// <summary>
    /// Gets the reference frame for the target direction (<see cref="M:SpaceCenter.AutoPilot.GetTargetDirection" />).
    /// </summary>
    /// <remarks>
    /// An error will be thrown if this property is set to a reference frame that rotates with
    /// the vessel being controlled, as it is impossible to rotate the vessel in such a
    /// reference frame.
    /// </remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_ReferenceFrame")]
    public ReferenceFrame GetReferenceFrame()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ReferenceFrame>("SpaceCenter", "AutoPilot_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame for the target direction (<see cref="M:SpaceCenter.AutoPilot.GetTargetDirection" />).
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// An error will be thrown if this property is set to a reference frame that rotates with
    /// the vessel being controlled, as it is impossible to rotate the vessel in such a
    /// reference frame.
    /// </remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_ReferenceFrame")]
    public async Task<ReferenceFrame> GetReferenceFrameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ReferenceFrame>("SpaceCenter", "AutoPilot_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Sets the reference frame for the target direction (<see cref="M:SpaceCenter.AutoPilot.GetTargetDirection" />).
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetReferenceFrame(ReferenceFrame value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_ReferenceFrame", args);
    }

    /// <summary>
    /// Sets the reference frame for the target direction (<see cref="M:SpaceCenter.AutoPilot.GetTargetDirection" />).
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetReferenceFrameAsync(ReferenceFrame value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets the error between the vessels current and target roll.
    /// Throws an exception if the auto-pilot has not been engaged or no target roll is set.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_RollError")]
    public Angle GetRollError()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "AutoPilot_get_RollError", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gets the error between the vessels current and target roll.
    /// Throws an exception if the auto-pilot has not been engaged or no target roll is set.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_RollError")]
    public async Task<Angle> GetRollErrorAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "AutoPilot_get_RollError", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gains for the roll PID controller.
    /// </summary>
    /// <remarks>
    /// When <see cref="M:SpaceCenter.AutoPilot.GetAutoTune" /> is true, these values are updated automatically,
    /// which will overwrite any manual changes.
    /// </remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_RollPIDGains")]
    public Tuple<double,double,double> GetRollPIDGains()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_RollPIDGains", args);
    }

    /// <summary>
    /// Gains for the roll PID controller.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// When <see cref="M:SpaceCenter.AutoPilot.GetAutoTune" /> is true, these values are updated automatically,
    /// which will overwrite any manual changes.
    /// </remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_RollPIDGains")]
    public async Task<Tuple<double,double,double>> GetRollPIDGainsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_RollPIDGains", args);
    }

    /// <summary>
    /// Sets gains for the roll PID controller.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRollPIDGains(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_RollPIDGains", args);
    }

    /// <summary>
    /// Sets gains for the roll PID controller.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRollPIDGainsAsync(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_RollPIDGains", args);
    }

    /// <summary>
    /// Gets the threshold at which the autopilot will try to match the target roll angle, if any.
    /// Defaults to 5 degrees.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_RollThreshold")]
    public Angle GetRollThreshold()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<double>("SpaceCenter", "AutoPilot_get_RollThreshold", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Gets the threshold at which the autopilot will try to match the target roll angle, if any.
    /// Defaults to 5 degrees.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_RollThreshold")]
    public async Task<Angle> GetRollThresholdAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<double>("SpaceCenter", "AutoPilot_get_RollThreshold", args);
        return Angle.FromDegrees(result);
    }

    /// <summary>
    /// Sets the threshold at which the autopilot will try to match the target roll angle, if any.
    /// Defaults to 5 degrees.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetRollThreshold(Angle value)
    {
        var args = new object[]
        {
            this,
            value.Degrees
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_RollThreshold", args);
    }

    /// <summary>
    /// Sets the threshold at which the autopilot will try to match the target roll angle, if any.
    /// Defaults to 5 degrees.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetRollThresholdAsync(Angle value)
    {
        var args = new object[]
        {
            this,
            value.Degrees
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_RollThreshold", args);
    }

    /// <summary>
    /// Gets the state of SAS.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.Control.GetSAS" /></remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_SAS")]
    public bool GetSAS()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "AutoPilot_get_SAS", args);
    }

    /// <summary>
    /// Gets the state of SAS.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.Control.GetSAS" /></remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_SAS")]
    public async Task<bool> GetSASAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "AutoPilot_get_SAS", args);
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
        Connection.Invoke("SpaceCenter", "AutoPilot_set_SAS", args);
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
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_SAS", args);
    }

    /// <summary>
    /// Gets the current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to the left of the navball that appear
    /// when SAS is enabled.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.Control.GetSASMode" /></remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_SASMode")]
    public SASMode GetSASMode()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<SASMode>("SpaceCenter", "AutoPilot_get_SASMode", args);
    }

    /// <summary>
    /// Gets the current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to the left of the navball that appear
    /// when SAS is enabled.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>Equivalent to <see cref="M:SpaceCenter.Control.GetSASMode" /></remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_SASMode")]
    public async Task<SASMode> GetSASModeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<SASMode>("SpaceCenter", "AutoPilot_get_SASMode", args);
    }

    /// <summary>
    /// Sets the current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to the left of the navball that appear
    /// when SAS is enabled.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetSASMode(SASMode value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_SASMode", args);
    }

    /// <summary>
    /// Sets the current <see cref="T:SpaceCenter.SASMode" />.
    /// These modes are equivalent to the mode buttons to the left of the navball that appear
    /// when SAS is enabled.
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
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_SASMode", args);
    }

    /// <summary>
    /// Gets the maximum amount of time that the vessel should need to come to a complete stop.
    /// This determines the maximum angular velocity of the vessel.
    /// A vector of three stopping times, in seconds, one for each of the pitch, roll
    /// and yaw axes. Defaults to 0.5 seconds for each axis.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_StoppingTime")]
    public Tuple<double,double,double> GetStoppingTime()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_StoppingTime", args);
    }

    /// <summary>
    /// Gets the maximum amount of time that the vessel should need to come to a complete stop.
    /// This determines the maximum angular velocity of the vessel.
    /// A vector of three stopping times, in seconds, one for each of the pitch, roll
    /// and yaw axes. Defaults to 0.5 seconds for each axis.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_StoppingTime")]
    public async Task<Tuple<double,double,double>> GetStoppingTimeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_StoppingTime", args);
    }

    /// <summary>
    /// Sets the maximum amount of time that the vessel should need to come to a complete stop.
    /// This determines the maximum angular velocity of the vessel.
    /// A vector of three stopping times, in seconds, one for each of the pitch, roll
    /// and yaw axes. Defaults to 0.5 seconds for each axis.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetStoppingTime(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_StoppingTime", args);
    }

    /// <summary>
    /// Sets the maximum amount of time that the vessel should need to come to a complete stop.
    /// This determines the maximum angular velocity of the vessel.
    /// A vector of three stopping times, in seconds, one for each of the pitch, roll
    /// and yaw axes. Defaults to 0.5 seconds for each axis.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetStoppingTimeAsync(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_StoppingTime", args);
    }

    /// <summary>
    /// Direction vector corresponding to the target pitch and heading.
    /// This is in the reference frame specified by <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TargetDirection")]
    public Vector3D GetTargetDirection()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "AutoPilot_get_TargetDirection", args);
    }

    /// <summary>
    /// Direction vector corresponding to the target pitch and heading.
    /// This is in the reference frame specified by <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TargetDirection")]
    public async Task<Vector3D> GetTargetDirectionAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "AutoPilot_get_TargetDirection", args);
    }

    /// <summary>
    /// Sets direction vector corresponding to the target pitch and heading.
    /// This is in the reference frame specified by <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetDirection(Vector3D value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_TargetDirection", args);
    }

    /// <summary>
    /// Sets direction vector corresponding to the target pitch and heading.
    /// This is in the reference frame specified by <see cref="T:SpaceCenter.ReferenceFrame" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetTargetDirectionAsync(Vector3D value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_TargetDirection", args);
    }

    /// <summary>
    /// Gets the target heading, between 0° and 360°.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TargetHeading")]
    public Angle GetTargetHeading()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "AutoPilot_get_TargetHeading", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gets the target heading, between 0° and 360°.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TargetHeading")]
    public async Task<Angle> GetTargetHeadingAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "AutoPilot_get_TargetHeading", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Sets the target heading, between 0° and 360°.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetHeading(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_TargetHeading", args);
    }

    /// <summary>
    /// Sets the target heading, between 0° and 360°.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetTargetHeadingAsync(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_TargetHeading", args);
    }

    /// <summary>
    /// Gets the target pitch, between -90° and +90°.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TargetPitch")]
    public Angle GetTargetPitch()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "AutoPilot_get_TargetPitch", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gets the target pitch, between -90° and +90°.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TargetPitch")]
    public async Task<Angle> GetTargetPitchAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "AutoPilot_get_TargetPitch", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Sets the target pitch, between -90° and +90°.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetPitch(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_TargetPitch", args);
    }

    /// <summary>
    /// Sets the target pitch, between -90° and +90°.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetTargetPitchAsync(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_TargetPitch", args);
    }

    /// <summary>
    /// Gets the target roll. <c>NaN</c> if no target roll is set.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TargetRoll")]
    public Angle GetTargetRoll()
    {
        var args = new object[]
        {
            this
        };
        var result = Connection.Invoke<float>("SpaceCenter", "AutoPilot_get_TargetRoll", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Gets the target roll. <c>NaN</c> if no target roll is set.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TargetRoll")]
    public async Task<Angle> GetTargetRollAsync()
    {
        var args = new object[]
        {
            this
        };
        var result = await Connection.InvokeAsync<float>("SpaceCenter", "AutoPilot_get_TargetRoll", args);
        return Angle.FromDegrees((double)result);
    }

    /// <summary>
    /// Sets the target roll. <c>NaN</c> if no target roll is set.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTargetRoll(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_TargetRoll", args);
    }

    /// <summary>
    /// Sets the target roll. <c>NaN</c> if no target roll is set.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetTargetRollAsync(Angle value)
    {
        var args = new object[]
        {
            this,
            (float)value.Degrees
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_TargetRoll", args);
    }

    /// <summary>
    /// Gets the target time to peak used to autotune the PID controllers.
    /// A vector of three times, in seconds, for each of the pitch, roll and yaw axes.
    /// Defaults to 3 seconds for each axis.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TimeToPeak")]
    public Tuple<double,double,double> GetTimeToPeak()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_TimeToPeak", args);
    }

    /// <summary>
    /// Gets the target time to peak used to autotune the PID controllers.
    /// A vector of three times, in seconds, for each of the pitch, roll and yaw axes.
    /// Defaults to 3 seconds for each axis.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "AutoPilot_get_TimeToPeak")]
    public async Task<Tuple<double,double,double>> GetTimeToPeakAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_TimeToPeak", args);
    }

    /// <summary>
    /// Sets the target time to peak used to autotune the PID controllers.
    /// A vector of three times, in seconds, for each of the pitch, roll and yaw axes.
    /// Defaults to 3 seconds for each axis.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetTimeToPeak(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_TimeToPeak", args);
    }

    /// <summary>
    /// Sets the target time to peak used to autotune the PID controllers.
    /// A vector of three times, in seconds, for each of the pitch, roll and yaw axes.
    /// Defaults to 3 seconds for each axis.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetTimeToPeakAsync(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_TimeToPeak", args);
    }

    /// <summary>
    /// Gains for the yaw PID controller.
    /// </summary>
    /// <remarks>
    /// When <see cref="M:SpaceCenter.AutoPilot.GetAutoTune" /> is true, these values are updated automatically,
    /// which will overwrite any manual changes.
    /// </remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_YawPIDGains")]
    public Tuple<double,double,double> GetYawPIDGains()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_YawPIDGains", args);
    }

    /// <summary>
    /// Gains for the yaw PID controller.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// When <see cref="M:SpaceCenter.AutoPilot.GetAutoTune" /> is true, these values are updated automatically,
    /// which will overwrite any manual changes.
    /// </remarks>
    [Rpc("SpaceCenter", "AutoPilot_get_YawPIDGains")]
    public async Task<Tuple<double,double,double>> GetYawPIDGainsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<double,double,double>>("SpaceCenter", "AutoPilot_get_YawPIDGains", args);
    }

    /// <summary>
    /// Sets gains for the yaw PID controller.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetYawPIDGains(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "AutoPilot_set_YawPIDGains", args);
    }

    /// <summary>
    /// Sets gains for the yaw PID controller.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetYawPIDGainsAsync(Tuple<double,double,double> value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "AutoPilot_set_YawPIDGains", args);
    }
}
