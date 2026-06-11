using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

/// <summary>
/// A robotic controller. Obtained by calling <see cref="M:kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects.Part.GetRoboticController" />.
/// </summary>
public class RoboticController : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    internal RoboticController(IConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Add an axis to the controller.
    /// </summary>
    /// <returns>Returns <c>true</c> if the axis is added successfully.</returns>
    [SetRpc("SpaceCenter", "RoboticController_AddAxis")]
    public bool AddAxis(Module module, string fieldName)
    {
        var args = new ProcedureArgument[]
        {
            this,
            module,
            fieldName
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RoboticController_AddAxis", args);
    }

    /// <summary>
    /// Add an axis to the controller.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>Returns <c>true</c> if the axis is added successfully.</returns>
    [SetRpc("SpaceCenter", "RoboticController_AddAxis")]
    public async Task<bool> AddAxisAsync(Module module, string fieldName)
    {
        var args = new ProcedureArgument[]
        {
            this,
            module,
            fieldName
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RoboticController_AddAxis", args);
    }

    /// <summary>
    /// Add key frame value for controller axis.
    /// </summary>
    /// <returns>Returns <c>true</c> if the key frame is added successfully.</returns>
    [SetRpc("SpaceCenter", "RoboticController_AddKeyFrame")]
    public bool AddKeyFrame(Module module, string fieldName, float time, float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            module,
            fieldName,
            time,
            value
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RoboticController_AddKeyFrame", args);
    }

    /// <summary>
    /// Add key frame value for controller axis.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>Returns <c>true</c> if the key frame is added successfully.</returns>
    [SetRpc("SpaceCenter", "RoboticController_AddKeyFrame")]
    public async Task<bool> AddKeyFrameAsync(Module module, string fieldName, float time, float value)
    {
        var args = new ProcedureArgument[]
        {
            this,
            module,
            fieldName,
            time,
            value
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RoboticController_AddKeyFrame", args);
    }

    /// <summary>
    /// The axes for the controller.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticController_Axes")]
    public IList<IList<string>> GetAxes()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<IList<IList<string>>>("SpaceCenter", "RoboticController_Axes", args);
    }

    /// <summary>
    /// The axes for the controller.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticController_Axes")]
    public async Task<IList<IList<string>>> GetAxesAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<IList<IList<string>>>("SpaceCenter", "RoboticController_Axes", args);
    }

    /// <summary>
    /// Clear axis.
    /// </summary>
    /// <returns>Returns <c>true</c> if the axis is cleared successfully.</returns>
    [SetRpc("SpaceCenter", "RoboticController_ClearAxis")]
    public bool ClearAxis(Module module, string fieldName)
    {
        var args = new ProcedureArgument[]
        {
            this,
            module,
            fieldName
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RoboticController_ClearAxis", args);
    }

    /// <summary>
    /// Clear axis.
    /// Executes asynchronously.
    /// </summary>
    /// <returns>Returns <c>true</c> if the axis is cleared successfully.</returns>
    [SetRpc("SpaceCenter", "RoboticController_ClearAxis")]
    public async Task<bool> ClearAxisAsync(Module module, string fieldName)
    {
        var args = new ProcedureArgument[]
        {
            this,
            module,
            fieldName
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RoboticController_ClearAxis", args);
    }

    /// <summary>
    /// Whether the controller has a part.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticController_HasPart")]
    public bool HasPart(Part part)
    {
        var args = new ProcedureArgument[]
        {
            this,
            part
        };
        return InvokeNonNullable<bool>("SpaceCenter", "RoboticController_HasPart", args);
    }

    /// <summary>
    /// Whether the controller has a part.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticController_HasPart")]
    public async Task<bool> HasPartAsync(Part part)
    {
        var args = new ProcedureArgument[]
        {
            this,
            part
        };
        return await InvokeNonNullableAsync<bool>("SpaceCenter", "RoboticController_HasPart", args);
    }

    /// <summary>
    /// Gets the part object for this controller.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticController_get_Part")]
    public Part GetPart()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return InvokeNonNullable<Part>("SpaceCenter", "RoboticController_get_Part", args);
    }

    /// <summary>
    /// Gets the part object for this controller.
    /// Executes asynchronously.
    /// </summary>
    [GetRpc("SpaceCenter", "RoboticController_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new ProcedureArgument[]
        {
            this
        };
        return await InvokeNonNullableAsync<Part>("SpaceCenter", "RoboticController_get_Part", args);
    }
}
