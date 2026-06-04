using System.Linq.Expressions;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Creates a procedure argument with a value that may or may not be null.
/// </summary>
/// <param name="value">The value of the argument</param>
/// <param name="type">The type of the argument</param>
internal class ProcedureArgument(object? value, Type type)
{
    /// <summary>
    /// The value of the argument.
    /// </summary>
    public object? Value { get; } = value;

    /// <summary>
    /// The type of the argument.
    /// </summary>
    public Type Type { get; } = type;
    
    // Implicit conversions to make life easier for services invoking procedures
    public static implicit operator ProcedureArgument(int value) => new(value, typeof(int));
    public static implicit operator ProcedureArgument(uint value) => new(value, typeof(uint));
    public static implicit operator ProcedureArgument(long value) => new(value, typeof(long));
    public static implicit operator ProcedureArgument(ulong value) => new(value, typeof(ulong));
    public static implicit operator ProcedureArgument(float value) => new(value, typeof(float));
    public static implicit operator ProcedureArgument(double value) => new(value, typeof(double));
    public static implicit operator ProcedureArgument(string value) => new(value, typeof(string));
    public static implicit operator ProcedureArgument(bool value) => new(value, typeof(bool));
    public static implicit operator ProcedureArgument(LambdaExpression value) => new(value, typeof(LambdaExpression));
}