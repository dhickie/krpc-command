using System.Linq.Expressions;
using kRPC.Client.Boost.Services;
using MathNet.Spatial.Euclidean;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Encapsulates an argument passed to a remote procedure.
/// </summary>
internal class ProcedureArgument
{
    /// <summary>
    /// The value of the argument.
    /// </summary>
    public object? Value { get; }

    /// <summary>
    /// The type of the argument.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    /// Creates a procedure argument with a value that is not null.
    /// </summary>
    /// <param name="value">The value of the argument</param>
    public ProcedureArgument(object value)
    {
        Value = value;
        Type = value.GetType();
    }

    /// <summary>
    /// Creates a procedure argument with a value that may or may not be null.
    /// </summary>
    /// <param name="value">The value of the argument</param>
    /// <param name="type">The type of the argument</param>
    public ProcedureArgument(object? value, Type type)
    {
        Value = value;
        Type = type;
    }
    
    // Implicit conversions to make life easier for services invoking procedures
    public static implicit operator ProcedureArgument(int value) => new(value);
    public static implicit operator ProcedureArgument(uint value) => new(value);
    public static implicit operator ProcedureArgument(long value) => new(value);
    public static implicit operator ProcedureArgument(ulong value) => new(value);
    public static implicit operator ProcedureArgument(float value) => new(value);
    public static implicit operator ProcedureArgument(double value) => new(value);
    public static implicit operator ProcedureArgument(string value) => new(value);
    public static implicit operator ProcedureArgument(bool value) => new(value);
    public static implicit operator ProcedureArgument(LambdaExpression value) => new(value);
    public static implicit operator ProcedureArgument(Vector3D value) => new(value);
    public static implicit operator ProcedureArgument(Quaternion value) => new(value);
    public static implicit operator ProcedureArgument(RemoteObject? value) => new(value, typeof(RemoteObject));
    public static implicit operator ProcedureArgument(Enum value) => new(value);
    
}
