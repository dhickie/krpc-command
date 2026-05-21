using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;
using kRPC.Client.Boost.Attributes;

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
    public bool AddAxis (global::kRPC.Client.Boost.Services.SpaceCenter.Module module, string fieldName)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticController)),
            global::KRPC.Client.Encoder.Encode (module, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (fieldName, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_AddAxis", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Add key frame value for controller axis.
    /// </summary>
    /// <returns>Returns <c>true</c> if the key frame is added successfully.</returns>
    [RpcAttribute ("SpaceCenter", "RoboticController_AddKeyFrame")]
    public bool AddKeyFrame (global::kRPC.Client.Boost.Services.SpaceCenter.Module module, string fieldName, float time, float value)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticController)),
            global::KRPC.Client.Encoder.Encode (module, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (fieldName, typeof(string)),
            global::KRPC.Client.Encoder.Encode (time, typeof(float)),
            global::KRPC.Client.Encoder.Encode (value, typeof(float))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_AddKeyFrame", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// The axes for the controller.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticController_Axes")]
    public global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<string>> Axes ()
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticController))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_Axes", _args);
        return (global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<string>>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<global::System.Collections.Generic.IList<string>>), connection);
    }

    /// <summary>
    /// Clear axis.
    /// </summary>
    /// <returns>Returns <c>true</c> if the axis is cleared successfully.</returns>
    [RpcAttribute ("SpaceCenter", "RoboticController_ClearAxis")]
    public bool ClearAxis (global::kRPC.Client.Boost.Services.SpaceCenter.Module module, string fieldName)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticController)),
            global::KRPC.Client.Encoder.Encode (module, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (fieldName, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_ClearAxis", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Whether the controller has a part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticController_HasPart")]
    public bool HasPart (global::kRPC.Client.Boost.Services.SpaceCenter.Part part)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticController)),
            global::KRPC.Client.Encoder.Encode (part, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_HasPart", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// The part object for this controller.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "RoboticController_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.RoboticController))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "RoboticController_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }
}
