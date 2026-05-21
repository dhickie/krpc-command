using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Connection;

namespace kRPC.Client.Boost.Services.SpaceCenter.RemoteObjects;

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
    public Module(ConnectionMultiplexer connection, ulong id) : base(connection, id)
    {
    }

    /// <summary>
    /// Returns the value of a field with the given name.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [Rpc("SpaceCenter", "Module_GetField")]
    public string GetField(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return Connection.Invoke<string>("SpaceCenter", "Module_GetField", args);
    }

    /// <summary>
    /// Returns the value of a field with the given name.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [Rpc("SpaceCenter", "Module_GetField")]
    public async Task<string> GetFieldAsync(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Module_GetField", args);
    }

    /// <summary>
    /// Returns the value of a field with the given identifier.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [Rpc("SpaceCenter", "Module_GetFieldById")]
    public string GetFieldById(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        return Connection.Invoke<string>("SpaceCenter", "Module_GetFieldById", args);
    }

    /// <summary>
    /// Returns the value of a field with the given identifier.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [Rpc("SpaceCenter", "Module_GetFieldById")]
    public async Task<string> GetFieldByIdAsync(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Module_GetFieldById", args);
    }

    /// <summary><c>true</c> if the part has an action with the given name.
    /// </summary>
    /// <param name="name"></param>
    [Rpc("SpaceCenter", "Module_HasAction")]
    public bool HasAction(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return Connection.Invoke<bool>("SpaceCenter", "Module_HasAction", args);
    }

    /// <summary><c>true</c> if the part has an action with the given name.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name"></param>
    [Rpc("SpaceCenter", "Module_HasAction")]
    public async Task<bool> HasActionAsync(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Module_HasAction", args);
    }

    /// <summary><c>true</c> if the part has an action with the given identifier.
    /// </summary>
    /// <param name="id"></param>
    [Rpc("SpaceCenter", "Module_HasActionWithId")]
    public bool HasActionWithId(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        return Connection.Invoke<bool>("SpaceCenter", "Module_HasActionWithId", args);
    }

    /// <summary><c>true</c> if the part has an action with the given identifier.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id"></param>
    [Rpc("SpaceCenter", "Module_HasActionWithId")]
    public async Task<bool> HasActionWithIdAsync(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Module_HasActionWithId", args);
    }

    /// <summary><c>true</c> if the module has an event with the given name.
    /// </summary>
    /// <param name="name"></param>
    [Rpc("SpaceCenter", "Module_HasEvent")]
    public bool HasEvent(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return Connection.Invoke<bool>("SpaceCenter", "Module_HasEvent", args);
    }

    /// <summary><c>true</c> if the module has an event with the given name.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name"></param>
    [Rpc("SpaceCenter", "Module_HasEvent")]
    public async Task<bool> HasEventAsync(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Module_HasEvent", args);
    }

    /// <summary><c>true</c> if the module has an event with the given identifier.
    /// </summary>
    /// <param name="id"></param>
    [Rpc("SpaceCenter", "Module_HasEventWithId")]
    public bool HasEventWithId(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        return Connection.Invoke<bool>("SpaceCenter", "Module_HasEventWithId", args);
    }

    /// <summary><c>true</c> if the module has an event with the given identifier.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id"></param>
    [Rpc("SpaceCenter", "Module_HasEventWithId")]
    public async Task<bool> HasEventWithIdAsync(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Module_HasEventWithId", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the module has a field with the given name.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [Rpc("SpaceCenter", "Module_HasField")]
    public bool HasField(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return Connection.Invoke<bool>("SpaceCenter", "Module_HasField", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the module has a field with the given name.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [Rpc("SpaceCenter", "Module_HasField")]
    public async Task<bool> HasFieldAsync(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Module_HasField", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the module has a field with the given identifier.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [Rpc("SpaceCenter", "Module_HasFieldWithId")]
    public bool HasFieldWithId(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        return Connection.Invoke<bool>("SpaceCenter", "Module_HasFieldWithId", args);
    }

    /// <summary>
    /// Returns <c>true</c> if the module has a field with the given identifier.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [Rpc("SpaceCenter", "Module_HasFieldWithId")]
    public async Task<bool> HasFieldWithIdAsync(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        return await Connection.InvokeAsync<bool>("SpaceCenter", "Module_HasFieldWithId", args);
    }

    /// <summary>
    /// Set the value of a field to its original value.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [Rpc("SpaceCenter", "Module_ResetField")]
    public void ResetField(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        Connection.Invoke("SpaceCenter", "Module_ResetField", args);
    }

    /// <summary>
    /// Set the value of a field to its original value.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    [Rpc("SpaceCenter", "Module_ResetField")]
    public async Task ResetFieldAsync(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_ResetField", args);
    }

    /// <summary>
    /// Set the value of a field to its original value.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [Rpc("SpaceCenter", "Module_ResetFieldById")]
    public void ResetFieldById(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        Connection.Invoke("SpaceCenter", "Module_ResetFieldById", args);
    }

    /// <summary>
    /// Set the value of a field to its original value.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    [Rpc("SpaceCenter", "Module_ResetFieldById")]
    public async Task ResetFieldByIdAsync(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_ResetFieldById", args);
    }

    /// <summary>
    /// Set the value of an action with the given name.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    [Rpc("SpaceCenter", "Module_SetAction")]
    public void SetAction(string name, bool value = true)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetAction", args);
    }

    /// <summary>
    /// Set the value of an action with the given name.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    [Rpc("SpaceCenter", "Module_SetAction")]
    public async Task SetActionAsync(string name, bool value = true)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetAction", args);
    }

    /// <summary>
    /// Set the value of an action with the given identifier.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [Rpc("SpaceCenter", "Module_SetActionById")]
    public void SetActionById(string id, bool value = true)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetActionById", args);
    }

    /// <summary>
    /// Set the value of an action with the given identifier.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    [Rpc("SpaceCenter", "Module_SetActionById")]
    public async Task SetActionByIdAsync(string id, bool value = true)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetActionById", args);
    }

    /// <summary>
    /// Set the value of a field to true or false.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldBool")]
    public void SetFieldBool(string name, bool value)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetFieldBool", args);
    }

    /// <summary>
    /// Set the value of a field to true or false.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldBool")]
    public async Task SetFieldBoolAsync(string name, bool value)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetFieldBool", args);
    }

    /// <summary>
    /// Set the value of a field to true or false.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldBoolById")]
    public void SetFieldBoolById(string id, bool value)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetFieldBoolById", args);
    }

    /// <summary>
    /// Set the value of a field to true or false.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldBoolById")]
    public async Task SetFieldBoolByIdAsync(string id, bool value)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetFieldBoolById", args);
    }

    /// <summary>
    /// Set the value of a field to the given floating point number.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldFloat")]
    public void SetFieldFloat(string name, float value)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetFieldFloat", args);
    }

    /// <summary>
    /// Set the value of a field to the given floating point number.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldFloat")]
    public async Task SetFieldFloatAsync(string name, float value)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetFieldFloat", args);
    }

    /// <summary>
    /// Set the value of a field to the given floating point number.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldFloatById")]
    public void SetFieldFloatById(string id, float value)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetFieldFloatById", args);
    }

    /// <summary>
    /// Set the value of a field to the given floating point number.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldFloatById")]
    public async Task SetFieldFloatByIdAsync(string id, float value)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetFieldFloatById", args);
    }

    /// <summary>
    /// Set the value of a field to the given integer number.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldInt")]
    public void SetFieldInt(string name, int value)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetFieldInt", args);
    }

    /// <summary>
    /// Set the value of a field to the given integer number.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldInt")]
    public async Task SetFieldIntAsync(string name, int value)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetFieldInt", args);
    }

    /// <summary>
    /// Set the value of a field to the given integer number.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldIntById")]
    public void SetFieldIntById(string id, int value)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetFieldIntById", args);
    }

    /// <summary>
    /// Set the value of a field to the given integer number.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldIntById")]
    public async Task SetFieldIntByIdAsync(string id, int value)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetFieldIntById", args);
    }

    /// <summary>
    /// Set the value of a field to the given string.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldString")]
    public void SetFieldString(string name, string value)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetFieldString", args);
    }

    /// <summary>
    /// Set the value of a field to the given string.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name">Name of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldString")]
    public async Task SetFieldStringAsync(string name, string value)
    {
        var args = new object[]
        {
            this,
            name,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetFieldString", args);
    }

    /// <summary>
    /// Set the value of a field to the given string.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldStringById")]
    public void SetFieldStringById(string id, string value)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        Connection.Invoke("SpaceCenter", "Module_SetFieldStringById", args);
    }

    /// <summary>
    /// Set the value of a field to the given string.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id">Identifier of the field.</param>
    /// <param name="value">Value to set.</param>
    [Rpc("SpaceCenter", "Module_SetFieldStringById")]
    public async Task SetFieldStringByIdAsync(string id, string value)
    {
        var args = new object[]
        {
            this,
            id,
            value
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_SetFieldStringById", args);
    }

    /// <summary>
    /// Trigger the named event. Equivalent to clicking the button in the right-click menu
    /// of the part.
    /// </summary>
    /// <param name="name"></param>
    [Rpc("SpaceCenter", "Module_TriggerEvent")]
    public void TriggerEvent(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        Connection.Invoke("SpaceCenter", "Module_TriggerEvent", args);
    }

    /// <summary>
    /// Trigger the named event. Equivalent to clicking the button in the right-click menu
    /// of the part.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="name"></param>
    [Rpc("SpaceCenter", "Module_TriggerEvent")]
    public async Task TriggerEventAsync(string name)
    {
        var args = new object[]
        {
            this,
            name
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_TriggerEvent", args);
    }

    /// <summary>
    /// Trigger the event with the given identifier.
    /// Equivalent to clicking the button in the right-click menu of the part.
    /// </summary>
    /// <param name="id"></param>
    [Rpc("SpaceCenter", "Module_TriggerEventById")]
    public void TriggerEventById(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        Connection.Invoke("SpaceCenter", "Module_TriggerEventById", args);
    }

    /// <summary>
    /// Trigger the event with the given identifier.
    /// Equivalent to clicking the button in the right-click menu of the part.
    /// Executes asynchronously.
    /// </summary>
    /// <param name="id"></param>
    [Rpc("SpaceCenter", "Module_TriggerEventById")]
    public async Task TriggerEventByIdAsync(string id)
    {
        var args = new object[]
        {
            this,
            id
        };
        await Connection.InvokeAsync("SpaceCenter", "Module_TriggerEventById", args);
    }

    /// <summary>
    /// Gets a list of all the names of the modules actions. These are the parts actions that can
    /// be assigned to action groups in the in-game editor.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_Actions")]
    public IList<string> GetActions()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "Module_get_Actions", args);
    }

    /// <summary>
    /// Gets a list of all the names of the modules actions. These are the parts actions that can
    /// be assigned to action groups in the in-game editor.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_Actions")]
    public async Task<IList<string>> GetActionsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "Module_get_Actions", args);
    }

    /// <summary>
    /// Gets a list of all the identifiers of the modules actions. These are the parts actions
    /// that can be assigned to action groups in the in-game editor.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_ActionsById")]
    public IList<string> GetActionsById()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "Module_get_ActionsById", args);
    }

    /// <summary>
    /// Gets a list of all the identifiers of the modules actions. These are the parts actions
    /// that can be assigned to action groups in the in-game editor.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_ActionsById")]
    public async Task<IList<string>> GetActionsByIdAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "Module_get_ActionsById", args);
    }

    /// <summary>
    /// Gets a list of the names of all of the modules events. Events are the clickable buttons
    /// visible in the right-click menu of the part.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_Events")]
    public IList<string> GetEvents()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "Module_get_Events", args);
    }

    /// <summary>
    /// Gets a list of the names of all of the modules events. Events are the clickable buttons
    /// visible in the right-click menu of the part.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_Events")]
    public async Task<IList<string>> GetEventsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "Module_get_Events", args);
    }

    /// <summary>
    /// Gets a list of the identifiers of all of the modules events. Events are the clickable buttons
    /// visible in the right-click menu of the part.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_EventsById")]
    public IList<string> GetEventsById()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IList<string>>("SpaceCenter", "Module_get_EventsById", args);
    }

    /// <summary>
    /// Gets a list of the identifiers of all of the modules events. Events are the clickable buttons
    /// visible in the right-click menu of the part.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_EventsById")]
    public async Task<IList<string>> GetEventsByIdAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IList<string>>("SpaceCenter", "Module_get_EventsById", args);
    }

    /// <summary>
    /// Gets the modules field names and their associated values, as a dictionary.
    /// These are the values visible in the right-click menu of the part.
    /// </summary>
    /// <remarks>
    /// Throws an exception if there is more than one field with the same name.
    /// In that case, use <see cref="M:SpaceCenter.Module.GetFieldsById" /> to get the fields by identifier.
    /// </remarks>
    [Rpc("SpaceCenter", "Module_get_Fields")]
    public IDictionary<string,string> GetFields()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IDictionary<string,string>>("SpaceCenter", "Module_get_Fields", args);
    }

    /// <summary>
    /// Gets the modules field names and their associated values, as a dictionary.
    /// These are the values visible in the right-click menu of the part.
    /// Executes asynchronously.
    /// </summary>
    /// <remarks>
    /// Throws an exception if there is more than one field with the same name.
    /// In that case, use <see cref="M:SpaceCenter.Module.GetFieldsById" /> to get the fields by identifier.
    /// </remarks>
    [Rpc("SpaceCenter", "Module_get_Fields")]
    public async Task<IDictionary<string,string>> GetFieldsAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IDictionary<string,string>>("SpaceCenter", "Module_get_Fields", args);
    }

    /// <summary>
    /// Gets the modules field identifiers and their associated values, as a dictionary.
    /// These are the values visible in the right-click menu of the part.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_FieldsById")]
    public IDictionary<string,string> GetFieldsById()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<IDictionary<string,string>>("SpaceCenter", "Module_get_FieldsById", args);
    }

    /// <summary>
    /// Gets the modules field identifiers and their associated values, as a dictionary.
    /// These are the values visible in the right-click menu of the part.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_FieldsById")]
    public async Task<IDictionary<string,string>> GetFieldsByIdAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<IDictionary<string,string>>("SpaceCenter", "Module_get_FieldsById", args);
    }

    /// <summary>
    /// Name of the PartModule. For example, "ModuleEngines".
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_Name")]
    public string GetName()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<string>("SpaceCenter", "Module_get_Name", args);
    }

    /// <summary>
    /// Name of the PartModule. For example, "ModuleEngines".
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_Name")]
    public async Task<string> GetNameAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<string>("SpaceCenter", "Module_get_Name", args);
    }

    /// <summary>
    /// Gets the part that contains this module.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_Part")]
    public Part GetPart()
    {
        var args = new object[]
        {
            this
        };
        return Connection.Invoke<Part>("SpaceCenter", "Module_get_Part", args);
    }

    /// <summary>
    /// Gets the part that contains this module.
    /// Executes asynchronously.
    /// </summary>
    [Rpc("SpaceCenter", "Module_get_Part")]
    public async Task<Part> GetPartAsync()
    {
        var args = new object[]
        {
            this
        };
        return await Connection.InvokeAsync<Part>("SpaceCenter", "Module_get_Part", args);
    }
}
