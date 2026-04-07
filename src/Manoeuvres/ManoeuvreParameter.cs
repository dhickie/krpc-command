namespace KrpcCommand.Manoeuvres;

/// <summary>
/// Defines a configuration parameter for a manoeuvre that can be rendered as a UI input field.
/// </summary>
public class ManoeuvreParameter
{
    public string Name { get; }
    public string Label { get; }
    public string DefaultValue { get; }

    private string _value;
    public string Value
    {
        get => _value;
        set => _value = value;
    }

    public ManoeuvreParameter(string name, string label, string defaultValue = "")
    {
        Name = name;
        Label = label;
        DefaultValue = defaultValue;
        _value = defaultValue;
    }

    public double AsDouble() => double.TryParse(Value, out var v) ? v : 0.0;
    public int AsInt() => int.TryParse(Value, out var v) ? v : 0;
    public bool AsBool() => bool.TryParse(Value, out var v) && v;
}
