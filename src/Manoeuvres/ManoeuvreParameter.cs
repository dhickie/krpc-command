namespace KrpcCommand.Manoeuvres;

/// <summary>
/// Defines a configuration parameter for a manoeuvre that can be rendered as a UI input field.
/// </summary>
public class ManoeuvreParameter<T> : ManoeuvreParameterBase
{
    public T Value { get; private set; }

    public override string ValueAsString => Value?.ToString() ?? string.Empty;

    public ManoeuvreParameter(string name, string label, T value) : base(name, label)
    {
        Value = value;
    }

    public override void SetFromString(string value)
    {
        var targetType = typeof(T);
        if (targetType == typeof(string))
        {
            Value = (T)(object)value;
        }
        else if (targetType == typeof(double))
        {
            Value = (T)(object)double.Parse(value);
        }
        else if (targetType == typeof(int))
        {
            Value = (T)(object)int.Parse(value);
        }
        else if (targetType == typeof(bool))
        {
            Value = (T)(object)bool.Parse(value);
        }
        else
        {
            throw new NotSupportedException($"Unsupported parameter type: {targetType.Name}");
        }
    }
}
