using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.Attributes;
using System.Collections.Generic;

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
    [RpcAttribute ("SpaceCenter", "Module_GetField")]
    public string GetField (string name)
    {
        var _args = new object[] {
            this,
            name
        };
        return Connection.Invoke<string> ("SpaceCenter", "Module_GetField", _args);
    }

    /// <summary>
    /// Returns the value of a field with the given identifier.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [RpcAttribute ("SpaceCenter", "Module_GetFieldById")]
    public string GetFieldById (string id)
    {
        var _args = new object[] {
            this,
            id
        };
        return Connection.Invoke<string> ("SpaceCenter", "Module_GetFieldById", _args);
    }

    /// <summary><c>true</c> if the part has an action with the given name.
    /// </summary>
    /// <param name="name"></param>
    [RpcAttribute ("SpaceCenter", "Module_HasAction")]
    public bool HasAction (string name)
    {
        var _args = new object[] {
            this,
            name
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Module_HasAction", _args);
    }

    /// <summary><c>true</c> if the part has an action with the given identifier.
    /// </summary>
    /// <param name="id"></param>
    [RpcAttribute ("SpaceCenter", "Module_HasActionWithId")]
    public bool HasActionWithId (string id)
    {
        var _args = new object[] {
            this,
            id
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Module_HasActionWithId", _args);
    }

    /// <summary><c>true</c> if the module has an event with the given name.
    /// </summary>
    /// <param name="name"></param>
    [RpcAttribute ("SpaceCenter", "Module_HasEvent")]
    public bool HasEvent (string name)
    {
        var _args = new object[] {
            this,
            name
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Module_HasEvent", _args);
    }

    /// <summary><c>true</c> if the module has an event with the given identifier.
    /// </summary>
    /// <param name="id"></param>
    [RpcAttribute ("SpaceCenter", "Module_HasEventWithId")]
    public bool HasEventWithId (string id)
    {
        var _args = new object[] {
            this,
            id
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Module_HasEventWithId", _args);
    }

    /// <summary>
    /// Returns <c>true</c> if the module has a field with the given name.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [RpcAttribute ("SpaceCenter", "Module_HasField")]
    public bool HasField (string name)
    {
        var _args = new object[] {
            this,
            name
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Module_HasField", _args);
    }

    /// <summary>
    /// Returns <c>true</c> if the module has a field with the given identifier.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [RpcAttribute ("SpaceCenter", "Module_HasFieldWithId")]
    public bool HasFieldWithId (string id)
    {
        var _args = new object[] {
            this,
            id
        };
        return Connection.Invoke<bool> ("SpaceCenter", "Module_HasFieldWithId", _args);
    }

    /// <summary>
    /// Set the value of a field to its original value.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [RpcAttribute ("SpaceCenter", "Module_ResetField")]
    public void ResetField (string name)
    {
        var _args = new object[] {
            this,
            name
        };
        Connection.Invoke ("SpaceCenter", "Module_ResetField", _args);
    }

    /// <summary>
    /// Set the value of a field to its original value.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [RpcAttribute ("SpaceCenter", "Module_ResetFieldById")]
    public void ResetFieldById (string id)
    {
        var _args = new object[] {
            this,
            id
        };
        Connection.Invoke ("SpaceCenter", "Module_ResetFieldById", _args);
    }

    /// <summary>
    /// Set the value of an action with the given name.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    [RpcAttribute ("SpaceCenter", "Module_SetAction")]
    public void SetAction (string name, bool value = true)
    {
        var _args = new object[] {
            this,
            name,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetAction", _args);
    }

    /// <summary>
    /// Set the value of an action with the given identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [RpcAttribute ("SpaceCenter", "Module_SetActionById")]
    public void SetActionById (string id, bool value = true)
    {
        var _args = new object[] {
            this,
            id,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetActionById", _args);
    }

    /// <summary>
    /// Set the value of a field to true or false.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [RpcAttribute ("SpaceCenter", "Module_SetFieldBool")]
    public void SetFieldBool (string name, bool value)
    {
        var _args = new object[] {
            this,
            name,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetFieldBool", _args);
    }

    /// <summary>
    /// Set the value of a field to true or false.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [RpcAttribute ("SpaceCenter", "Module_SetFieldBoolById")]
    public void SetFieldBoolById (string id, bool value)
    {
        var _args = new object[] {
            this,
            id,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetFieldBoolById", _args);
    }

    /// <summary>
    /// Set the value of a field to the given floating point number.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [RpcAttribute ("SpaceCenter", "Module_SetFieldFloat")]
    public void SetFieldFloat (string name, float value)
    {
        var _args = new object[] {
            this,
            name,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetFieldFloat", _args);
    }

    /// <summary>
    /// Set the value of a field to the given floating point number.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [RpcAttribute ("SpaceCenter", "Module_SetFieldFloatById")]
    public void SetFieldFloatById (string id, float value)
    {
        var _args = new object[] {
            this,
            id,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetFieldFloatById", _args);
    }

    /// <summary>
    /// Set the value of a field to the given integer number.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [RpcAttribute ("SpaceCenter", "Module_SetFieldInt")]
    public void SetFieldInt (string name, int value)
    {
        var _args = new object[] {
            this,
            name,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetFieldInt", _args);
    }

    /// <summary>
    /// Set the value of a field to the given integer number.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [RpcAttribute ("SpaceCenter", "Module_SetFieldIntById")]
    public void SetFieldIntById (string id, int value)
    {
        var _args = new object[] {
            this,
            id,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetFieldIntById", _args);
    }

    /// <summary>
    /// Set the value of a field to the given string.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [RpcAttribute ("SpaceCenter", "Module_SetFieldString")]
    public void SetFieldString (string name, string value)
    {
        var _args = new object[] {
            this,
            name,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetFieldString", _args);
    }

    /// <summary>
    /// Set the value of a field to the given string.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [RpcAttribute ("SpaceCenter", "Module_SetFieldStringById")]
    public void SetFieldStringById (string id, string value)
    {
        var _args = new object[] {
            this,
            id,
            value
        };
        Connection.Invoke ("SpaceCenter", "Module_SetFieldStringById", _args);
    }

    /// <summary>
    /// Trigger the named event. Equivalent to clicking the button in the right-click menu
    /// of the part.
    /// </summary>
    /// <param name="name"></param>
    [RpcAttribute ("SpaceCenter", "Module_TriggerEvent")]
    public void TriggerEvent (string name)
    {
        var _args = new object[] {
            this,
            name
        };
        Connection.Invoke ("SpaceCenter", "Module_TriggerEvent", _args);
    }

    /// <summary>
    /// Trigger the event with the given identifier.
    /// Equivalent to clicking the button in the right-click menu of the part.
    /// </summary>
    /// <param name="id"></param>
    [RpcAttribute ("SpaceCenter", "Module_TriggerEventById")]
    public void TriggerEventById (string id)
    {
        var _args = new object[] {
            this,
            id
        };
        Connection.Invoke ("SpaceCenter", "Module_TriggerEventById", _args);
    }

    /// <summary>
    /// A list of all the names of the modules actions. These are the parts actions that can
    /// be assigned to action groups in the in-game editor.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Module_get_Actions")]
    public IList<string> Actions {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "Module_get_Actions", _args);
        }
    }

    /// <summary>
    /// A list of all the identifiers of the modules actions. These are the parts actions
    /// that can be assigned to action groups in the in-game editor.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Module_get_ActionsById")]
    public IList<string> ActionsById {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "Module_get_ActionsById", _args);
        }
    }

    /// <summary>
    /// A list of the names of all of the modules events. Events are the clickable buttons
    /// visible in the right-click menu of the part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Module_get_Events")]
    public IList<string> Events {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "Module_get_Events", _args);
        }
    }

    /// <summary>
    /// A list of the identifiers of all of the modules events. Events are the clickable buttons
    /// visible in the right-click menu of the part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Module_get_EventsById")]
    public IList<string> EventsById {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IList<string>> ("SpaceCenter", "Module_get_EventsById", _args);
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
    [RpcAttribute ("SpaceCenter", "Module_get_Fields")]
    public IDictionary<string,string> Fields {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IDictionary<string,string>> ("SpaceCenter", "Module_get_Fields", _args);
        }
    }

    /// <summary>
    /// The modules field identifiers and their associated values, as a dictionary.
    /// These are the values visible in the right-click menu of the part.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Module_get_FieldsById")]
    public IDictionary<string,string> FieldsById {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<IDictionary<string,string>> ("SpaceCenter", "Module_get_FieldsById", _args);
        }
    }

    /// <summary>
    /// Name of the PartModule. For example, "ModuleEngines".
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Module_get_Name")]
    public string Name {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<string> ("SpaceCenter", "Module_get_Name", _args);
        }
    }

    /// <summary>
    /// The part that contains this module.
    /// </summary>
    [RpcAttribute ("SpaceCenter", "Module_get_Part")]
    public Part Part {
        get {
            var _args = new object[] {
                this
            };
            return Connection.Invoke<Part> ("SpaceCenter", "Module_get_Part", _args);
        }
    }
}
