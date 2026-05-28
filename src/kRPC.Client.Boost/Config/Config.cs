namespace kRPC.Client.Boost.Config;

/// <summary>
/// Abstract base class from which all other configuration classes are derived.
/// </summary>
public abstract class Config
{
    private List<string> _errors = [];
    
    internal void Validate(List<string> errors)
    {
        Validate();
        errors.AddRange(_errors);
    }
    
    protected abstract void Validate();

    protected void IsInvalid<T>(T value, Func<T, bool> validator, string errorMessage)
    {
        if (validator(value))
            _errors.Add(errorMessage);
    }

    protected void IsInvalid<T1, T2>(T1 value1, T2 value2, Func<T1, T2, bool> validator, string errorMessage)
    {
        if (validator(value1, value2))
            _errors.Add(errorMessage);
    }
}