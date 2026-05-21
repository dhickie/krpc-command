using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// A robotic controller. Obtained by calling <see cref="M:SpaceCenter.Part.RoboticController" />.
/// </summary>
public class RoboticController : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public RoboticController (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Add an axis to the controller.
    /// </summary>
    /// <returns>Returns <c>true</c> if the axis is added successfully.</returns>
    [RpcAttribute ("SpaceCenter", "RoboticController_AddAxis")]
    public bool AddAxis (Module module, string fieldName)
    {
        var args = new object[] {
            this,
            module,
            fieldName
        };
        return Connection.Invoke<bool> ("SpaceCenter", "RoboticController_AddAxis", args);
    }

    /// <summary>
    /// Add key frame value for controller axis.
    /// </summary>
    /// <returns>Returns <c>true</c> if the key frame is added successfully.</returns>
    [RpcAttribute ("SpaceCenter", "RoboticController_AddKeyFrame")]
    public bool AddKeyFrame (Module module, string fieldName, float time, float value)
    {
        var args = new object[] {
            this,
            module,
            fieldName,
            time,
            value
        };
        return Connection.Invoke<bool> ("SpaceCenter", "RoboticController_AddKeyFrame", args);
    }

    /// <summary>
    /// The axes for the controller.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticController_Axes")]
    public IList<IList<string>> Axes ()
    {
        var args = new object[] {
            this
        };
        return Connection.Invoke<IList<IList<string>>> ("SpaceCenter", "RoboticController_Axes", args);
    }

    /// <summary>
    /// Clear axis.
    /// </summary>
    /// <returns>Returns <c>true</c> if the axis is cleared successfully.</returns>
    [RpcAttribute ("SpaceCenter", "RoboticController_ClearAxis")]
    public bool ClearAxis (Module module, string fieldName)
    {
        var args = new object[] {
            this,
            module,
            fieldName
        };
        return Connection.Invoke<bool> ("SpaceCenter", "RoboticController_ClearAxis", args);
    }

    /// <summary>
    /// Whether the controller has a part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticController_HasPart")]
    public bool HasPart (Part part)
    {
        var args = new object[] {
            this,
            part
        };
        return Connection.Invoke<bool> ("SpaceCenter", "RoboticController_HasPart", args);
    }

    /// <summary>
    /// The part object for this controller.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticController_get_Part")]
    public Part Part {
        get {
            var args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "RoboticController_get_Part", args);
        }
    }
}
