using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using Google.Protobuf;

namespace kRPC.Client.Boost.Services.SpaceCenter;

/// <summary>
/// This can be used to interact with a specific part module. This includes part modules in
/// stock KSP, and those added by mods.
///
/// In KSP, each part has zero or more
/// <a href="https://wiki.kerbalspaceprogram.com/wiki/CFG_File_Documentation#MODULES">PartModules</a>
/// associated with it. Each one contains some of the functionality of the part.
/// For example, an engine has a "ModuleEngines" part module that contains all the
/// functionality of an engine.
/// </summary>
public class Module : RemoteObject
{
    /// <summary>
    /// Construct an instance of this remote object. Should not be called directly. This interface is intended for internal decoding.
    /// </summary>
    public Module (ConnectionMultiplexer connection, ulong id) : base (connection, id)
    {
    }

    /// <summary>
    /// Returns the value of a field with the given name.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_GetField")]
    public string GetField (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Module_GetField", _args);
        return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
    }

    /// <summary>
    /// Returns the value of a field with the given identifier.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_GetFieldById")]
    public string GetFieldById (string id)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Module_GetFieldById", _args);
        return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
    }

    /// <summary><c>true</c> if the part has an action with the given name.
    /// </summary>
    /// <param name="name"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasAction")]
    public bool HasAction (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasAction", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary><c>true</c> if the part has an action with the given identifier.
    /// </summary>
    /// <param name="id"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasActionWithId")]
    public bool HasActionWithId (string id)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasActionWithId", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary><c>true</c> if the module has an event with the given name.
    /// </summary>
    /// <param name="name"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasEvent")]
    public bool HasEvent (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasEvent", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary><c>true</c> if the module has an event with the given identifier.
    /// </summary>
    /// <param name="id"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasEventWithId")]
    public bool HasEventWithId (string id)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasEventWithId", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Returns <c>true</c> if the module has a field with the given name.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasField")]
    public bool HasField (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasField", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Returns <c>true</c> if the module has a field with the given identifier.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_HasFieldWithId")]
    public bool HasFieldWithId (string id)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string))
        };
        ByteString _data = connection.Invoke ("SpaceCenter", "Module_HasFieldWithId", _args);
        return (bool)global::KRPC.Client.Encoder.Decode (_data, typeof(bool), connection);
    }

    /// <summary>
    /// Set the value of a field to its original value.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_ResetField")]
    public void ResetField (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        connection.Invoke ("SpaceCenter", "Module_ResetField", _args);
    }

    /// <summary>
    /// Set the value of a field to its original value.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_ResetFieldById")]
    public void ResetFieldById (string id)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string))
        };
        connection.Invoke ("SpaceCenter", "Module_ResetFieldById", _args);
    }

    /// <summary>
    /// Set the value of an action with the given name.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetAction")]
    public void SetAction (string name, bool value = true)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(bool))
        };
        connection.Invoke ("SpaceCenter", "Module_SetAction", _args);
    }

    /// <summary>
    /// Set the value of an action with the given identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetActionById")]
    public void SetActionById (string id, bool value = true)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(bool))
        };
        connection.Invoke ("SpaceCenter", "Module_SetActionById", _args);
    }

    /// <summary>
    /// Set the value of a field to true or false.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldBool")]
    public void SetFieldBool (string name, bool value)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(bool))
        };
        connection.Invoke ("SpaceCenter", "Module_SetFieldBool", _args);
    }

    /// <summary>
    /// Set the value of a field to true or false.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldBoolById")]
    public void SetFieldBoolById (string id, bool value)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(bool))
        };
        connection.Invoke ("SpaceCenter", "Module_SetFieldBoolById", _args);
    }

    /// <summary>
    /// Set the value of a field to the given floating point number.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldFloat")]
    public void SetFieldFloat (string name, float value)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(float))
        };
        connection.Invoke ("SpaceCenter", "Module_SetFieldFloat", _args);
    }

    /// <summary>
    /// Set the value of a field to the given floating point number.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldFloatById")]
    public void SetFieldFloatById (string id, float value)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(float))
        };
        connection.Invoke ("SpaceCenter", "Module_SetFieldFloatById", _args);
    }

    /// <summary>
    /// Set the value of a field to the given integer number.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldInt")]
    public void SetFieldInt (string name, int value)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(int))
        };
        connection.Invoke ("SpaceCenter", "Module_SetFieldInt", _args);
    }

    /// <summary>
    /// Set the value of a field to the given integer number.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldIntById")]
    public void SetFieldIntById (string id, int value)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(int))
        };
        connection.Invoke ("SpaceCenter", "Module_SetFieldIntById", _args);
    }

    /// <summary>
    /// Set the value of a field to the given string.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldString")]
    public void SetFieldString (string name, string value)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(string))
        };
        connection.Invoke ("SpaceCenter", "Module_SetFieldString", _args);
    }

    /// <summary>
    /// Set the value of a field to the given string.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_SetFieldStringById")]
    public void SetFieldStringById (string id, string value)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string)),
            global::KRPC.Client.Encoder.Encode (value, typeof(string))
        };
        connection.Invoke ("SpaceCenter", "Module_SetFieldStringById", _args);
    }

    /// <summary>
    /// Trigger the named event. Equivalent to clicking the button in the right-click menu
    /// of the part.
    /// </summary>
    /// <param name="name"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_TriggerEvent")]
    public void TriggerEvent (string name)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (name, typeof(string))
        };
        connection.Invoke ("SpaceCenter", "Module_TriggerEvent", _args);
    }

    /// <summary>
    /// Trigger the event with the given identifier.
    /// Equivalent to clicking the button in the right-click menu of the part.
    /// </summary>
    /// <param name="id"></param>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_TriggerEventById")]
    public void TriggerEventById (string id)
    {
        var _args = new ByteString[] {
            global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module)),
            global::KRPC.Client.Encoder.Encode (id, typeof(string))
        };
        connection.Invoke ("SpaceCenter", "Module_TriggerEventById", _args);
    }

    /// <summary>
    /// A list of all the names of the modules actions. These are the parts actions that can
    /// be assigned to action groups in the in-game editor.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Actions")]
    public global::System.Collections.Generic.IList<string> Actions {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Actions", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// A list of all the identifiers of the modules actions. These are the parts actions
    /// that can be assigned to action groups in the in-game editor.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_ActionsById")]
    public global::System.Collections.Generic.IList<string> ActionsById {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_ActionsById", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// A list of the names of all of the modules events. Events are the clickable buttons
    /// visible in the right-click menu of the part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Events")]
    public global::System.Collections.Generic.IList<string> Events {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Events", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// A list of the identifiers of all of the modules events. Events are the clickable buttons
    /// visible in the right-click menu of the part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_EventsById")]
    public global::System.Collections.Generic.IList<string> EventsById {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_EventsById", _args);
            return (global::System.Collections.Generic.IList<string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IList<string>), connection);
        }
    }

    /// <summary>
    /// The modules field names and their associated values, as a dictionary.
    /// These are the values visible in the right-click menu of the part.
    /// </summary>
    /// <remarks>
    /// Throws an exception if there is more than one field with the same name.
    /// In that case, use <see cref="M:SpaceCenter.Module.FieldsById" /> to get the fields by identifier.
    /// </remarks>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Fields")]
    public global::System.Collections.Generic.IDictionary<string,string> Fields {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Fields", _args);
            return (global::System.Collections.Generic.IDictionary<string,string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,string>), connection);
        }
    }

    /// <summary>
    /// The modules field identifiers and their associated values, as a dictionary.
    /// These are the values visible in the right-click menu of the part.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_FieldsById")]
    public global::System.Collections.Generic.IDictionary<string,string> FieldsById {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_FieldsById", _args);
            return (global::System.Collections.Generic.IDictionary<string,string>)global::KRPC.Client.Encoder.Decode (_data, typeof(global::System.Collections.Generic.IDictionary<string,string>), connection);
        }
    }

    /// <summary>
    /// Name of the PartModule. For example, "ModuleEngines".
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Name")]
    public string Name {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Name", _args);
            return (string)global::KRPC.Client.Encoder.Decode (_data, typeof(string), connection);
        }
    }

    /// <summary>
    /// The part that contains this module.
    /// </summary>
    [global::KRPC.Client.Attributes.RPCAttribute ("SpaceCenter", "Module_get_Part")]
    public global::kRPC.Client.Boost.Services.SpaceCenter.Part Part {
        get {
            var _args = new ByteString[] {
                global::KRPC.Client.Encoder.Encode (this, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Module))
            };
            ByteString _data = connection.Invoke ("SpaceCenter", "Module_get_Part", _args);
            return (global::kRPC.Client.Boost.Services.SpaceCenter.Part)global::KRPC.Client.Encoder.Decode (_data, typeof(global::kRPC.Client.Boost.Services.SpaceCenter.Part), connection);
        }
    }
}
