namespace KrpcCommand.Manoeuvres.Parameters;

/// <summary>
/// Defines a double-precision floating-point configuration parameter for a manoeuvre
/// that can be rendered as a UI input field.
/// </summary>
public class DoubleManoeuvreParameter(string name, string label, double value) : ManoeuvreParameter(name, label)
{
    /// <summary>
    /// The current value of the parameter.
    /// </summary>
    public double Value { get; private set; } = value;

    /// <inheritdoc />
    public override string ValueAsString => Value.ToString("G");

    /// <inheritdoc />
    public override void Set(string value)
    {
        Value = double.Parse(value);
    }
}
