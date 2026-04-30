using BaseModule = KRPC.Client.Services.SpaceCenter.Module;

namespace kRPC.Client.Boost.Entities.VesselParts;

/// <summary>
/// Wraps a kRPC SpaceCenter Module object.
/// </summary>
public class Module
{
    internal readonly BaseModule Wrapped;

    internal Module(BaseModule module)
    {
        Wrapped = module;
    }

    public IList<string> Actions
        => Wrapped.Actions;

    public IList<string> ActionsById
        => Wrapped.ActionsById;

    public IList<string> Events
        => Wrapped.Events;

    public IList<string> EventsById
        => Wrapped.EventsById;

    public IDictionary<string, string> Fields
        => Wrapped.Fields;

    public IDictionary<string, string> FieldsById
        => Wrapped.FieldsById;

    public string Name
        => Wrapped.Name;

    public Part Part
        => new Part(Wrapped.Part);

    public string GetField(string name)
        => Wrapped.GetField(name);

    public string GetFieldById(string id)
        => Wrapped.GetFieldById(id);

    public bool HasAction(string name)
        => Wrapped.HasAction(name);

    public bool HasActionWithId(string id)
        => Wrapped.HasActionWithId(id);

    public bool HasEvent(string name)
        => Wrapped.HasEvent(name);

    public bool HasEventWithId(string id)
        => Wrapped.HasEventWithId(id);

    public bool HasField(string name)
        => Wrapped.HasField(name);

    public bool HasFieldWithId(string id)
        => Wrapped.HasFieldWithId(id);

    public void ResetField(string name)
        => Wrapped.ResetField(name);

    public void ResetFieldById(string id)
        => Wrapped.ResetFieldById(id);

    public void SetAction(string name, bool value = true)
        => Wrapped.SetAction(name, value);

    public void SetActionById(string id, bool value = true)
        => Wrapped.SetActionById(id, value);

    public void SetFieldBool(string name, bool value)
        => Wrapped.SetFieldBool(name, value);

    public void SetFieldBoolById(string id, bool value)
        => Wrapped.SetFieldBoolById(id, value);

    public void SetFieldFloat(string name, float value)
        => Wrapped.SetFieldFloat(name, value);

    public void SetFieldFloatById(string id, float value)
        => Wrapped.SetFieldFloatById(id, value);

    public void SetFieldInt(string name, int value)
        => Wrapped.SetFieldInt(name, value);

    public void SetFieldIntById(string id, int value)
        => Wrapped.SetFieldIntById(id, value);

    public void SetFieldString(string name, string value)
        => Wrapped.SetFieldString(name, value);

    public void SetFieldStringById(string id, string value)
        => Wrapped.SetFieldStringById(id, value);

    public void TriggerEvent(string name)
        => Wrapped.TriggerEvent(name);

    public void TriggerEventById(string id)
        => Wrapped.TriggerEventById(id);
}
