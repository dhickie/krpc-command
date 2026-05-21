using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using System;
using kRPC.Client.Boost.Attributes;
using MathNet.Spatial.Euclidean;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// These objects are used to interact with vessels in KSP. This includes getting
/// orbital and flight data, manipulating control inputs and managing resources.
/// Created using <see cref="M:SpaceCenter.GetActiveVessel" /> or <see cref="M:SpaceCenter.GetVessels" />.
/// </summary>
public class Vessel : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Vessel(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// The angular velocity of the vessel, in the given reference frame.
    /// </summary>
    /// <returns>The angular velocity as a vector. The magnitude of the vector is the rotational
    /// speed of the vessel, in radians per second. The direction of the vector indicates the
    /// axis of rotation, using the right-hand rule.</returns>
    /// <param name="referenceFrame">The reference frame the returned
    /// angular velocity is in.</param>
    [Rpc("SpaceCenter", "Vessel_AngularVelocity")]
    public Vector3D AngularVelocity(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Vessel_AngularVelocity", args);
    }

    /// <summary>
    /// The angular velocity of the vessel, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The angular velocity as a vector. The magnitude of the vector is the rotational
    /// speed of the vessel, in radians per second. The direction of the vector indicates the
    /// axis of rotation, using the right-hand rule.</returns>
    /// <param name="referenceFrame">The reference frame the returned
    /// angular velocity is in.</param>
    [Rpc("SpaceCenter", "Vessel_AngularVelocity")]
    public async Task<Vector3D> AngularVelocityAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Vessel_AngularVelocity", args);
    }

    /// <summary>
    /// Gets the total available thrust that can be produced by the vessel's
    /// active engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.AvailableThrustAt" /> for every active engine in the vessel.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Vessel_AvailableThrustAt")]
    public float AvailableThrustAt(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_AvailableThrustAt", args);
    }

    /// <summary>
    /// Gets the total available thrust that can be produced by the vessel's
    /// active engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.AvailableThrustAt" /> for every active engine in the vessel.
    /// Takes the given pressure into account.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Vessel_AvailableThrustAt")]
    public async Task<float> AvailableThrustAtAsync(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_AvailableThrustAt", args);
    }

    /// <summary>
    /// The axis-aligned bounding box of the vessel in the given reference frame.
    /// </summary>
    /// <returns>The positions of the minimum and maximum vertices of the box,
    /// as position vectors.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vectors are in.</param>
    [Rpc("SpaceCenter", "Vessel_BoundingBox")]
    public Tuple<Vector3D,Vector3D> BoundingBox(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_BoundingBox", args);
    }

    /// <summary>
    /// The axis-aligned bounding box of the vessel in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The positions of the minimum and maximum vertices of the box,
    /// as position vectors.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vectors are in.</param>
    [Rpc("SpaceCenter", "Vessel_BoundingBox")]
    public async Task<Tuple<Vector3D,Vector3D>> BoundingBoxAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_BoundingBox", args);
    }

    /// <summary>
    /// The direction in which the vessel is pointing, in the given reference frame.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [Rpc("SpaceCenter", "Vessel_Direction")]
    public Vector3D Direction(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Vessel_Direction", args);
    }

    /// <summary>
    /// The direction in which the vessel is pointing, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The direction as a unit vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// direction is in.</param>
    [Rpc("SpaceCenter", "Vessel_Direction")]
    public async Task<Vector3D> DirectionAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Vessel_Direction", args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Flight" /> object that can be used to get flight
    /// telemetry for the vessel, in the specified reference frame.
    /// </summary>
    /// <param name="referenceFrame">
    /// Reference frame. Defaults to the vessel's surface reference frame
    /// (<see cref="M:SpaceCenter.Vessel.GetSurfaceReferenceFrame" />).
    /// </param>
    [Rpc("SpaceCenter", "Vessel_Flight")]
    public Flight Flight(ReferenceFrame? referenceFrame = null)
    {
        var args = new object?[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Flight>("SpaceCenter", "Vessel_Flight", args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Flight" /> object that can be used to get flight
    /// telemetry for the vessel, in the specified reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="referenceFrame">
    /// Reference frame. Defaults to the vessel's surface reference frame
    /// (<see cref="M:SpaceCenter.Vessel.GetSurfaceReferenceFrame" />).
    /// </param>
    [Rpc("SpaceCenter", "Vessel_Flight")]
    public async Task<Flight> FlightAsync(ReferenceFrame? referenceFrame = null)
    {
        var args = new object?[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Flight>("SpaceCenter", "Vessel_Flight", args);
    }

    /// <summary>
    /// The total maximum thrust that can be produced by the vessel's active
    /// engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.MaxThrustAt" /> for every active engine.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Vessel_MaxThrustAt")]
    public float MaxThrustAt(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_MaxThrustAt", args);
    }

    /// <summary>
    /// The total maximum thrust that can be produced by the vessel's active
    /// engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.MaxThrustAt" /> for every active engine.
    /// Takes the given pressure into account.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Vessel_MaxThrustAt")]
    public async Task<float> MaxThrustAtAsync(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_MaxThrustAt", args);
    }

    /// <summary>
    /// The position of the center of mass of the vessel, in the given reference frame.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [Rpc("SpaceCenter", "Vessel_Position")]
    public Vector3D Position(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Vessel_Position", args);
    }

    /// <summary>
    /// The position of the center of mass of the vessel, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The position as a vector.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// position vector is in.</param>
    [Rpc("SpaceCenter", "Vessel_Position")]
    public async Task<Vector3D> PositionAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Vessel_Position", args);
    }

    /// <summary>
    /// Recover the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_Recover")]
    public void Recover()
    {
        var args = new object[]
        {
            this
        };
        Connection.Invoke("SpaceCenter", "Vessel_Recover", args);
    }

    /// <summary>
    /// Recover the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_Recover")]
    public async Task RecoverAsync()
    {
        var args = new object[]
        {
            this
        };
        await Connection.InvokeAsync("SpaceCenter", "Vessel_Recover", args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Resources" /> object, that can used to get
    /// information about resources stored in a given <paramref name="stage" />.
    /// </summary>
    /// <param name="stage">Get resources for parts that are decoupled in this stage.</param>
    /// <param name="cumulative">When <c>false</c>, returns the resources for parts
    /// decoupled in just the given stage. When <c>true</c> returns the resources decoupled in
    /// the given stage and all subsequent stages combined.</param>
    [Rpc("SpaceCenter", "Vessel_ResourcesInDecoupleStage")]
    public Resources ResourcesInDecoupleStage(int stage, bool cumulative = true)
    {
        var args = new object[]
        {
            this,
            stage,
            cumulative
        };
        return Connection.Invoke<Resources>("SpaceCenter", "Vessel_ResourcesInDecoupleStage", args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Resources" /> object, that can used to get
    /// information about resources stored in a given <paramref name="stage" />.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="stage">Get resources for parts that are decoupled in this stage.</param>
    /// <param name="cumulative">When <c>false</c>, returns the resources for parts
    /// decoupled in just the given stage. When <c>true</c> returns the resources decoupled in
    /// the given stage and all subsequent stages combined.</param>
    [Rpc("SpaceCenter", "Vessel_ResourcesInDecoupleStage")]
    public async Task<Resources> ResourcesInDecoupleStageAsync(int stage, bool cumulative = true)
    {
        var args = new object[]
        {
            this,
            stage,
            cumulative
        };
        return await Connection.InvokeAsync<Resources>("SpaceCenter", "Vessel_ResourcesInDecoupleStage", args);
    }

    /// <summary>
    /// The rotation of the vessel, in the given reference frame.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [Rpc("SpaceCenter", "Vessel_Rotation")]
    public Quaternion Rotation(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Quaternion>("SpaceCenter", "Vessel_Rotation", args);
    }

    /// <summary>
    /// The rotation of the vessel, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The rotation as a quaternion of the form <math>(x, y, z, w)</math>.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// rotation is in.</param>
    [Rpc("SpaceCenter", "Vessel_Rotation")]
    public async Task<Quaternion> RotationAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Quaternion>("SpaceCenter", "Vessel_Rotation", args);
    }

    /// <summary>
    /// The combined specific impulse of all active engines, in seconds. This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// Takes the given pressure into account.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Vessel_SpecificImpulseAt")]
    public float SpecificImpulseAt(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_SpecificImpulseAt", args);
    }

    /// <summary>
    /// The combined specific impulse of all active engines, in seconds. This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// Takes the given pressure into account.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="pressure">Atmospheric pressure in atmospheres</param>
    [Rpc("SpaceCenter", "Vessel_SpecificImpulseAt")]
    public async Task<float> SpecificImpulseAtAsync(double pressure)
    {
        var args = new object[]
        {
            this,
            pressure
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_SpecificImpulseAt", args);
    }

    /// <summary>
    /// The velocity of the center of mass of the vessel, in the given reference frame.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the body in meters per second.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// velocity vector is in.</param>
    [Rpc("SpaceCenter", "Vessel_Velocity")]
    public Vector3D Velocity(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return Connection.Invoke<Vector3D>("SpaceCenter", "Vessel_Velocity", args);
    }

    /// <summary>
    /// The velocity of the center of mass of the vessel, in the given reference frame.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>The velocity as a vector. The vector points in the direction of travel,
    /// and its magnitude is the speed of the body in meters per second.</returns>
    /// <param name="referenceFrame">The reference frame that the returned
    /// velocity vector is in.</param>
    [Rpc("SpaceCenter", "Vessel_Velocity")]
    public async Task<Vector3D> VelocityAsync(ReferenceFrame referenceFrame)
    {
        var args = new object[]
        {
            this,
            referenceFrame
        };
        return await Connection.InvokeAsync<Vector3D>("SpaceCenter", "Vessel_Velocity", args);
    }

    /// <summary>
    /// Gets an <see cref="T:SpaceCenter.AutoPilot" /> object, that can be used to perform
    /// simple auto-piloting of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AutoPilot")]
    public AutoPilot GetAutoPilot()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<AutoPilot>("SpaceCenter", "Vessel_get_AutoPilot", args);
    }

    /// <summary>
    /// Gets an <see cref="T:SpaceCenter.AutoPilot" /> object, that can be used to perform
    /// simple auto-piloting of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AutoPilot")]
    public async Task<AutoPilot> GetAutoPilotAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<AutoPilot>("SpaceCenter", "Vessel_get_AutoPilot", args);
    }

    /// <summary>
    /// Gets the maximum torque that the aerodynamic control surfaces can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableControlSurfaceTorque")]
    public Tuple<Vector3D,Vector3D> GetAvailableControlSurfaceTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableControlSurfaceTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque that the aerodynamic control surfaces can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableControlSurfaceTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableControlSurfaceTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableControlSurfaceTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque that the currently active and gimballed engines can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableEngineTorque")]
    public Tuple<Vector3D,Vector3D> GetAvailableEngineTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableEngineTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque that the currently active and gimballed engines can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableEngineTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableEngineTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableEngineTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque that parts (excluding reaction wheels, gimballed engines,
    /// RCS and control surfaces) can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableOtherTorque")]
    public Tuple<Vector3D,Vector3D> GetAvailableOtherTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableOtherTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque that parts (excluding reaction wheels, gimballed engines,
    /// RCS and control surfaces) can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableOtherTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableOtherTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableOtherTorque", args);
    }

    /// <summary>
    /// Gets the maximum force that the currently active RCS thrusters can generate.
    /// Returns the forces in <math>N</math> along each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the right, forward and bottom directions of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableRCSForce")]
    public Tuple<Vector3D,Vector3D> GetAvailableRCSForce()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableRCSForce", args);
    }

    /// <summary>
    /// Gets the maximum force that the currently active RCS thrusters can generate.
    /// Returns the forces in <math>N</math> along each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the right, forward and bottom directions of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableRCSForce")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableRCSForceAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableRCSForce", args);
    }

    /// <summary>
    /// Gets the maximum torque that the currently active RCS thrusters can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableRCSTorque")]
    public Tuple<Vector3D,Vector3D> GetAvailableRCSTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableRCSTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque that the currently active RCS thrusters can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableRCSTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableRCSTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableRCSTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque that the currently active and powered reaction wheels can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableReactionWheelTorque")]
    public Tuple<Vector3D,Vector3D> GetAvailableReactionWheelTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableReactionWheelTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque that the currently active and powered reaction wheels can generate.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableReactionWheelTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableReactionWheelTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableReactionWheelTorque", args);
    }

    /// <summary>
    /// Gets the total available thrust that can be produced by the vessel's
    /// active engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.GetAvailableThrust" /> for every active engine in the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableThrust")]
    public float GetAvailableThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_get_AvailableThrust", args);
    }

    /// <summary>
    /// Gets the total available thrust that can be produced by the vessel's
    /// active engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.GetAvailableThrust" /> for every active engine in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableThrust")]
    public async Task<float> GetAvailableThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_get_AvailableThrust", args);
    }

    /// <summary>
    /// Gets the maximum torque that the vessel generates. Includes contributions from
    /// reaction wheels, RCS, gimballed engines and aerodynamic control surfaces.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableTorque")]
    public Tuple<Vector3D,Vector3D> GetAvailableTorque()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets the maximum torque that the vessel generates. Includes contributions from
    /// reaction wheels, RCS, gimballed engines and aerodynamic control surfaces.
    /// Returns the torques in <math>N.m</math> around each of the coordinate axes of the
    /// vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// These axes are equivalent to the pitch, roll and yaw axes of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_AvailableTorque")]
    public async Task<Tuple<Vector3D,Vector3D>> GetAvailableTorqueAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<Vector3D,Vector3D>>("SpaceCenter", "Vessel_get_AvailableTorque", args);
    }

    /// <summary>
    /// Gets the name of the biome the vessel is currently in.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Biome")]
    public string GetBiome()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Vessel_get_Biome", args);
    }

    /// <summary>
    /// Gets the name of the biome the vessel is currently in.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Biome")]
    public async Task<string> GetBiomeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Vessel_get_Biome", args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Comms" /> object that can be used to interact
    /// with CommNet for this vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Comms")]
    public Comms GetComms()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Comms>("SpaceCenter", "Vessel_get_Comms", args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Comms" /> object that can be used to interact
    /// with CommNet for this vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Comms")]
    public async Task<Comms> GetCommsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Comms>("SpaceCenter", "Vessel_get_Comms", args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Control" /> object that can be used to manipulate
    /// the vessel's control inputs. For example, its pitch/yaw/roll controls,
    /// RCS and thrust.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Control")]
    public Control GetControl()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Control>("SpaceCenter", "Vessel_get_Control", args);
    }

    /// <summary>
    /// Returns a <see cref="T:SpaceCenter.Control" /> object that can be used to manipulate
    /// the vessel's control inputs. For example, its pitch/yaw/roll controls,
    /// RCS and thrust.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Control")]
    public async Task<Control> GetControlAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Control>("SpaceCenter", "Vessel_get_Control", args);
    }

    /// <summary>
    /// Gets the crew in the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Crew")]
    public IList<CrewMember> GetCrew()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<CrewMember>>("SpaceCenter", "Vessel_get_Crew", args);
    }

    /// <summary>
    /// Gets the crew in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Crew")]
    public async Task<IList<CrewMember>> GetCrewAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<CrewMember>>("SpaceCenter", "Vessel_get_Crew", args);
    }

    /// <summary>
    /// Gets the number of crew that can occupy the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_CrewCapacity")]
    public int GetCrewCapacity()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<int>("SpaceCenter", "Vessel_get_CrewCapacity", args);
    }

    /// <summary>
    /// Gets the number of crew that can occupy the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_CrewCapacity")]
    public async Task<int> GetCrewCapacityAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<int>("SpaceCenter", "Vessel_get_CrewCapacity", args);
    }

    /// <summary>
    /// Gets the number of crew that are occupying the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_CrewCount")]
    public int GetCrewCount()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<int>("SpaceCenter", "Vessel_get_CrewCount", args);
    }

    /// <summary>
    /// Gets the number of crew that are occupying the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_CrewCount")]
    public async Task<int> GetCrewCountAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<int>("SpaceCenter", "Vessel_get_CrewCount", args);
    }

    /// <summary>
    /// Gets the total mass of the vessel, excluding resources, in kg.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_DryMass")]
    public float GetDryMass()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_get_DryMass", args);
    }

    /// <summary>
    /// Gets the total mass of the vessel, excluding resources, in kg.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_DryMass")]
    public async Task<float> GetDryMassAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_get_DryMass", args);
    }

    /// <summary>
    /// Gets the inertia tensor of the vessel around its center of mass,
    /// in the vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// Returns the 3x3 matrix as a list of elements, in row-major order.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_InertiaTensor")]
    public IList<double> GetInertiaTensor()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<double>>("SpaceCenter", "Vessel_get_InertiaTensor", args);
    }

    /// <summary>
    /// Gets the inertia tensor of the vessel around its center of mass,
    /// in the vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// Returns the 3x3 matrix as a list of elements, in row-major order.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_InertiaTensor")]
    public async Task<IList<double>> GetInertiaTensorAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<double>>("SpaceCenter", "Vessel_get_InertiaTensor", args);
    }

    /// <summary>
    /// Gets the combined specific impulse of all active engines at sea level on Kerbin, in seconds.
    /// This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_KerbinSeaLevelSpecificImpulse")]
    public float GetKerbinSeaLevelSpecificImpulse()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_get_KerbinSeaLevelSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the combined specific impulse of all active engines at sea level on Kerbin, in seconds.
    /// This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_KerbinSeaLevelSpecificImpulse")]
    public async Task<float> GetKerbinSeaLevelSpecificImpulseAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_get_KerbinSeaLevelSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the mission elapsed time in seconds.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_MET")]
    public double GetMET()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<double>("SpaceCenter", "Vessel_get_MET", args);
    }

    /// <summary>
    /// Gets the mission elapsed time in seconds.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_MET")]
    public async Task<double> GetMETAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<double>("SpaceCenter", "Vessel_get_MET", args);
    }

    /// <summary>
    /// Gets the total mass of the vessel, including resources, in kg.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Mass")]
    public float GetMass()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_get_Mass", args);
    }

    /// <summary>
    /// Gets the total mass of the vessel, including resources, in kg.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Mass")]
    public async Task<float> GetMassAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_get_Mass", args);
    }

    /// <summary>
    /// Gets the total maximum thrust that can be produced by the vessel's active
    /// engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.GetMaxThrust" /> for every active engine.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_MaxThrust")]
    public float GetMaxThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_get_MaxThrust", args);
    }

    /// <summary>
    /// Gets the total maximum thrust that can be produced by the vessel's active
    /// engines, in Newtons. This is computed by summing
    /// <see cref="M:SpaceCenter.Engine.GetMaxThrust" /> for every active engine.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_MaxThrust")]
    public async Task<float> GetMaxThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_get_MaxThrust", args);
    }

    /// <summary>
    /// Gets the total maximum thrust that can be produced by the vessel's active
    /// engines when the vessel is in a vacuum, in Newtons. This is computed by
    /// summing <see cref="M:SpaceCenter.Engine.GetMaxVacuumThrust" /> for every active engine.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_MaxVacuumThrust")]
    public float GetMaxVacuumThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_get_MaxVacuumThrust", args);
    }

    /// <summary>
    /// Gets the total maximum thrust that can be produced by the vessel's active
    /// engines when the vessel is in a vacuum, in Newtons. This is computed by
    /// summing <see cref="M:SpaceCenter.Engine.GetMaxVacuumThrust" /> for every active engine.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_MaxVacuumThrust")]
    public async Task<float> GetMaxVacuumThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_get_MaxVacuumThrust", args);
    }

    /// <summary>
    /// Gets the moment of inertia of the vessel around its center of mass in <math>kg.m^2</math>.
    /// The inertia values in the returned 3-tuple are around the
    /// pitch, roll and yaw directions respectively.
    /// This corresponds to the vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_MomentOfInertia")]
    public Tuple<double,double,double> GetMomentOfInertia()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Tuple<double,double,double>>("SpaceCenter", "Vessel_get_MomentOfInertia", args);
    }

    /// <summary>
    /// Gets the moment of inertia of the vessel around its center of mass in <math>kg.m^2</math>.
    /// The inertia values in the returned 3-tuple are around the
    /// pitch, roll and yaw directions respectively.
    /// This corresponds to the vessels reference frame (<see cref="T:SpaceCenter.ReferenceFrame" />).
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_MomentOfInertia")]
    public async Task<Tuple<double,double,double>> GetMomentOfInertiaAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Tuple<double,double,double>>("SpaceCenter", "Vessel_get_MomentOfInertia", args);
    }

    /// <summary>
    /// Gets the name of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Name")]
    public string GetName()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Vessel_get_Name", args);
    }

    /// <summary>
    /// Gets the name of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Name")]
    public async Task<string> GetNameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Vessel_get_Name", args);
    }

    /// <summary>
    /// Sets the name of the vessel.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetName(string value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Vessel_set_Name", args);
    }

    /// <summary>
    /// Sets the name of the vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetNameAsync(string value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Vessel_set_Name", args);
    }

    /// <summary>
    /// Gets the current orbit of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Orbit")]
    public Orbit GetOrbit()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Orbit>("SpaceCenter", "Vessel_get_Orbit", args);
    }

    /// <summary>
    /// Gets the current orbit of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Orbit")]
    public async Task<Orbit> GetOrbitAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Orbit>("SpaceCenter", "Vessel_get_Orbit", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the vessel,
    /// and orientated with the vessels orbital prograde/normal/radial directions.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the orbital prograde/normal/radial directions.</description></item><item><description>The x-axis points in the orbital anti-radial direction.</description></item><item><description>The y-axis points in the orbital prograde direction.</description></item><item><description>The z-axis points in the orbital normal direction.</description></item></list>
    /// </summary>
    /// <remarks>
    /// Be careful not to confuse this with 'orbit' mode on the navball.
    /// </remarks>
    [Rpc("SpaceCenter", "Vessel_get_OrbitalReferenceFrame")]
    public ReferenceFrame GetOrbitalReferenceFrame()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ReferenceFrame>("SpaceCenter", "Vessel_get_OrbitalReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the vessel,
    /// and orientated with the vessels orbital prograde/normal/radial directions.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the orbital prograde/normal/radial directions.</description></item><item><description>The x-axis points in the orbital anti-radial direction.</description></item><item><description>The y-axis points in the orbital prograde direction.</description></item><item><description>The z-axis points in the orbital normal direction.</description></item></list>
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// Be careful not to confuse this with 'orbit' mode on the navball.
    /// </remarks>
    [Rpc("SpaceCenter", "Vessel_get_OrbitalReferenceFrame")]
    public async Task<ReferenceFrame> GetOrbitalReferenceFrameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ReferenceFrame>("SpaceCenter", "Vessel_get_OrbitalReferenceFrame", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Parts" /> object, that can used to interact with the parts that make up this vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Parts")]
    public Parts GetParts()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Parts>("SpaceCenter", "Vessel_get_Parts", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Parts" /> object, that can used to interact with the parts that make up this vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Parts")]
    public async Task<Parts> GetPartsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Parts>("SpaceCenter", "Vessel_get_Parts", args);
    }

    /// <summary>
    /// Gets whether the vessel is recoverable.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Recoverable")]
    public bool GetRecoverable()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<bool>("SpaceCenter", "Vessel_get_Recoverable", args);
    }

    /// <summary>
    /// Gets whether the vessel is recoverable.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Recoverable")]
    public async Task<bool> GetRecoverableAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Vessel_get_Recoverable", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the vessel,
    /// and orientated with the vessel.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the vessel.</description></item><item><description>The x-axis points out to the right of the vessel.</description></item><item><description>The y-axis points in the forward direction of the vessel.</description></item><item><description>The z-axis points out of the bottom off the vessel.</description></item></list>
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_ReferenceFrame")]
    public ReferenceFrame GetReferenceFrame()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ReferenceFrame>("SpaceCenter", "Vessel_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the vessel,
    /// and orientated with the vessel.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the vessel.</description></item><item><description>The x-axis points out to the right of the vessel.</description></item><item><description>The y-axis points in the forward direction of the vessel.</description></item><item><description>The z-axis points out of the bottom off the vessel.</description></item></list>
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_ReferenceFrame")]
    public async Task<ReferenceFrame> GetReferenceFrameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ReferenceFrame>("SpaceCenter", "Vessel_get_ReferenceFrame", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Resources" /> object, that can used to get information
    /// about resources stored in the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Resources")]
    public Resources GetResources()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Resources>("SpaceCenter", "Vessel_get_Resources", args);
    }

    /// <summary>
    /// Gets a <see cref="T:SpaceCenter.Resources" /> object, that can used to get information
    /// about resources stored in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Resources")]
    public async Task<Resources> GetResourcesAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Resources>("SpaceCenter", "Vessel_get_Resources", args);
    }

    /// <summary>
    /// Gets the situation the vessel is in.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Situation")]
    public VesselSituation GetSituation()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<VesselSituation>("SpaceCenter", "Vessel_get_Situation", args);
    }

    /// <summary>
    /// Gets the situation the vessel is in.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Situation")]
    public async Task<VesselSituation> GetSituationAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<VesselSituation>("SpaceCenter", "Vessel_get_Situation", args);
    }

    /// <summary>
    /// Gets the combined specific impulse of all active engines, in seconds. This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_SpecificImpulse")]
    public float GetSpecificImpulse()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_get_SpecificImpulse", args);
    }

    /// <summary>
    /// Gets the combined specific impulse of all active engines, in seconds. This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_SpecificImpulse")]
    public async Task<float> GetSpecificImpulseAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_get_SpecificImpulse", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the vessel,
    /// and orientated with the surface of the body being orbited.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the north and up directions on the surface of the body.</description></item><item><description>The x-axis points in the <a href="https://en.wikipedia.org/wiki/Zenith">zenith</a>
    /// direction (upwards, normal to the body being orbited, from the center of the body towards the center of
    /// mass of the vessel).</description></item><item><description>The y-axis points northwards towards the
    /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a> (north, and tangential to the
    /// surface of the body -- the direction in which a compass would point when on the surface).</description></item><item><description>The z-axis points eastwards towards the
    /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a> (east, and tangential to the
    /// surface of the body -- east on a compass when on the surface).</description></item></list>
    /// </summary>
    /// <remarks>
    /// Be careful not to confuse this with 'surface' mode on the navball.
    /// </remarks>
    [Rpc("SpaceCenter", "Vessel_get_SurfaceReferenceFrame")]
    public ReferenceFrame GetSurfaceReferenceFrame()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ReferenceFrame>("SpaceCenter", "Vessel_get_SurfaceReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the vessel,
    /// and orientated with the surface of the body being orbited.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the north and up directions on the surface of the body.</description></item><item><description>The x-axis points in the <a href="https://en.wikipedia.org/wiki/Zenith">zenith</a>
    /// direction (upwards, normal to the body being orbited, from the center of the body towards the center of
    /// mass of the vessel).</description></item><item><description>The y-axis points northwards towards the
    /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a> (north, and tangential to the
    /// surface of the body -- the direction in which a compass would point when on the surface).</description></item><item><description>The z-axis points eastwards towards the
    /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a> (east, and tangential to the
    /// surface of the body -- east on a compass when on the surface).</description></item></list>
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// Be careful not to confuse this with 'surface' mode on the navball.
    /// </remarks>
    [Rpc("SpaceCenter", "Vessel_get_SurfaceReferenceFrame")]
    public async Task<ReferenceFrame> GetSurfaceReferenceFrameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ReferenceFrame>("SpaceCenter", "Vessel_get_SurfaceReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the vessel,
    /// and orientated with the velocity vector of the vessel relative
    /// to the surface of the body being orbited.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the vessel's velocity vector.</description></item><item><description>The y-axis points in the direction of the vessel's velocity vector,
    /// relative to the surface of the body being orbited.</description></item><item><description>The z-axis is in the plane of the
    /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a>.</description></item><item><description>The x-axis is orthogonal to the other two axes.</description></item></list>
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_SurfaceVelocityReferenceFrame")]
    public ReferenceFrame GetSurfaceVelocityReferenceFrame()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<ReferenceFrame>("SpaceCenter", "Vessel_get_SurfaceVelocityReferenceFrame", args);
    }

    /// <summary>
    /// Gets the reference frame that is fixed relative to the vessel,
    /// and orientated with the velocity vector of the vessel relative
    /// to the surface of the body being orbited.
    /// <list type="bullet"><item><description>The origin is at the center of mass of the vessel.</description></item><item><description>The axes rotate with the vessel's velocity vector.</description></item><item><description>The y-axis points in the direction of the vessel's velocity vector,
    /// relative to the surface of the body being orbited.</description></item><item><description>The z-axis is in the plane of the
    /// <a href="https://en.wikipedia.org/wiki/Horizon">astronomical horizon</a>.</description></item><item><description>The x-axis is orthogonal to the other two axes.</description></item></list>
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_SurfaceVelocityReferenceFrame")]
    public async Task<ReferenceFrame> GetSurfaceVelocityReferenceFrameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<ReferenceFrame>("SpaceCenter", "Vessel_get_SurfaceVelocityReferenceFrame", args);
    }

    /// <summary>
    /// Gets the total thrust currently being produced by the vessel's engines, in
    /// Newtons. This is computed by summing <see cref="M:SpaceCenter.Engine.GetThrust" /> for
    /// every engine in the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Thrust")]
    public float GetThrust()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_get_Thrust", args);
    }

    /// <summary>
    /// Gets the total thrust currently being produced by the vessel's engines, in
    /// Newtons. This is computed by summing <see cref="M:SpaceCenter.Engine.GetThrust" /> for
    /// every engine in the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Thrust")]
    public async Task<float> GetThrustAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_get_Thrust", args);
    }

    /// <summary>
    /// Gets the type of the vessel.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Type")]
    public VesselType GetType()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<VesselType>("SpaceCenter", "Vessel_get_Type", args);
    }

    /// <summary>
    /// Gets the type of the vessel.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_Type")]
    public async Task<VesselType> GetTypeAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<VesselType>("SpaceCenter", "Vessel_get_Type", args);
    }

    /// <summary>
    /// Sets the type of the vessel.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public void SetType(VesselType value)
    {
        var args = new object[]
        {
            this,
            value
        };
        Connection.Invoke("SpaceCenter", "Vessel_set_Type", args);
    }

    /// <summary>
    /// Sets the type of the vessel.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="value">The value to set.</param>
    public async Task SetTypeAsync(VesselType value)
    {
        var args = new object[]
        {
            this,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Vessel_set_Type", args);
    }

    /// <summary>
    /// Gets the combined vacuum specific impulse of all active engines, in seconds. This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_VacuumSpecificImpulse")]
    public float GetVacuumSpecificImpulse()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<float>("SpaceCenter", "Vessel_get_VacuumSpecificImpulse", args);
    }

    /// <summary>
    /// Gets the combined vacuum specific impulse of all active engines, in seconds. This is computed using the formula
    /// <a href="https://wiki.kerbalspaceprogram.com/wiki/Specific_impulse#Multiple_engines">described here</a>.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Vessel_get_VacuumSpecificImpulse")]
    public async Task<float> GetVacuumSpecificImpulseAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<float>("SpaceCenter", "Vessel_get_VacuumSpecificImpulse", args);
    }
}
