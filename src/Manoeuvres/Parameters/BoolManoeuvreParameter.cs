namespace KrpcCommand.Manoeuvres.Parameters;

/// <summary>
/// Defines a boolean configuration parameter for a manoeuvre that can be rendered as a UI input field.
/// </summary>
public class BoolManoeuvreParameter(string name, string label, bool value) : ManoeuvreParameter(name, label)
{
    public bool Value { get; private set; } = value;

    public override string ValueAsString => Value.ToString();

    public override void Set(string value)
    {
        Value = bool.Parse(value);
    }
}
