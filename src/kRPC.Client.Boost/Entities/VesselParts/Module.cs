using BaseModule = KRPC.Client.Services.SpaceCenter.Module;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Module object.
/// </summary>
public class Module
{
    internal BaseModule Internal { get; }

    internal Module(BaseModule module)
    {
        Internal = module;
    }
    public IList<string> Actions
        => Internal.Actions;
    public IList<string> ActionsById
        => Internal.ActionsById;
    public IList<string> Events
        => Internal.Events;
    public IList<string> EventsById
        => Internal.EventsById;
    public IDictionary<string, string> Fields
        => Internal.Fields;
    public IDictionary<string, string> FieldsById
        => Internal.FieldsById;
    public string Name
        => Internal.Name;
    public Part Part
        => new Part(Internal.Part);
    public string GetField(string name)
        => Internal.GetField(name);
    public string GetFieldById(string id)
        => Internal.GetFieldById(id);
    public bool HasAction(string name)
        => Internal.HasAction(name);
    public bool HasActionWithId(string id)
        => Internal.HasActionWithId(id);
    public bool HasEvent(string name)
        => Internal.HasEvent(name);
    public bool HasEventWithId(string id)
        => Internal.HasEventWithId(id);
    public bool HasField(string name)
        => Internal.HasField(name);
    public bool HasFieldWithId(string id)
        => Internal.HasFieldWithId(id);
    public void ResetField(string name)
        => Internal.ResetField(name);
    public void ResetFieldById(string id)
        => Internal.ResetFieldById(id);
    public void SetAction(string name, bool value = true)
        => Internal.SetAction(name, value);
    public void SetActionById(string id, bool value = true)
        => Internal.SetActionById(id, value);
    public void SetFieldBool(string name, bool value)
        => Internal.SetFieldBool(name, value);
    public void SetFieldBoolById(string id, bool value)
        => Internal.SetFieldBoolById(id, value);
    public void SetFieldFloat(string name, float value)
        => Internal.SetFieldFloat(name, value);
    public void SetFieldFloatById(string id, float value)
        => Internal.SetFieldFloatById(id, value);
    public void SetFieldInt(string name, int value)
        => Internal.SetFieldInt(name, value);
    public void SetFieldIntById(string id, int value)
        => Internal.SetFieldIntById(id, value);
    public void SetFieldString(string name, string value)
        => Internal.SetFieldString(name, value);
    public void SetFieldStringById(string id, string value)
        => Internal.SetFieldStringById(id, value);
    public void TriggerEvent(string name)
        => Internal.TriggerEvent(name);
    public void TriggerEventById(string id)
        => Internal.TriggerEventById(id);
}
