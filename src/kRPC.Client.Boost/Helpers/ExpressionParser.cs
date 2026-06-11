using System.Linq.Expressions;
using System.Reflection;
using kRPC.Client.Boost.Attributes;
using kRPC.Client.Boost.Services;

namespace kRPC.Client.Boost.Helpers;

/// <summary>
/// Determines the details of an RPC call based on an input LambdaExpression. Used when setting up streams of data
/// based on an expression.
/// </summary>
public class ExpressionParser
{
    /// <summary>
    /// The service in which the RPC represented by the expression exists.
    /// </summary>
    public string Service { get; private set; }
    
    /// <summary>
    /// The procedure represented by the expression.
    /// </summary>
    public string Procedure { get; private set; }
    
    /// <summary>
    /// The arguments to the RPC that the expression represents, as a collection of object & type tuples
    /// </summary>
    public (object? value, Type type)[] Arguments { get; private set; }

    /// <summary>
    /// Creates an expression parser for the provided expression.
    /// </summary>
    /// <param name="expression">The expression to parse</param>
    /// <exception cref="ArgumentException">Thrown if the provided expression is not a valid RPC call expression</exception>
    public ExpressionParser(LambdaExpression expression)
    {
        // Ensure that the expression actually calls an RPC
        var body = expression.Body;
        if (body is not MethodCallExpression methodCallExpression)
            throw new ArgumentException("Invalid expression. Expressions must be an Expression<Func<T>> that calls a single function with no chaining and no input parameters");
        
        var attribute = methodCallExpression.Method.GetCustomAttribute<RpcAttribute>();
        if (attribute == null)
            throw new ArgumentException("Invalid expression. Method must call a remote procedure.");
        
        // Populate the service and procedure
        Service = attribute.Service;
        Procedure = attribute.Procedure;

        // Work out the remote object argument if the RPC exists on a remote object
        var arguments = new List<(object?, Type)>();
        if (RepresentsRemoteObjectCall(methodCallExpression))
            arguments.Add((ParseRemoteObject(methodCallExpression), typeof(RemoteObject)));
        
        // Work out the rest of the RPC arguments
        arguments.AddRange(methodCallExpression.Arguments.Select(GetValue));
        
        Arguments = arguments.ToArray();
    }

    // Determines whether a method call expression is a call to an RPC on a RemoteObject instance
    private static bool RepresentsRemoteObjectCall(MethodCallExpression methodCallExpression)
    {
        return methodCallExpression.Object?.Type.IsAssignableTo(typeof(RemoteObject)) ?? false;
    }

    // Gets the remote object instance on which the method represented by the MethodCallExpression is being called
    private static RemoteObject ParseRemoteObject(MethodCallExpression methodCallExpression)
    {
        if (GetValue(methodCallExpression.Object).value is not RemoteObject remoteObject || remoteObject.Id is 0)
            throw new ArgumentException(
                "Invalid expression. Remote object RPC calls must be made on initialise instances");

        return remoteObject;
    }

    // Gets the actual value that an expression represents. Objects from outside the expression that are referenced
    // inside the expression are added to a closure object by the compiler, which is why we have to access them
    // through a MemberExpression.
    private static (object? value, Type type) GetValue(Expression? expression)
    {
        return expression switch
        {
            ConstantExpression constant =>
                (constant.Value, constant.Type),

            MemberExpression memberExpression =>
                GetMemberValue(
                    GetValue(memberExpression.Expression),
                    memberExpression.Member),
            
            null => throw new ArgumentException("Invalid expression. Cannot determine type of null expression"),

            _ => throw new ArgumentException(
                $"Invalid expression. Unable to get value of expression of type {expression.GetType()}")
        };
    }

    // Gets the value of an object member
    private static (object? value, Type type) GetMemberValue((object? value, Type type) instance, MemberInfo member)
    {
        return member switch
        {
            FieldInfo field =>
                (field.GetValue(instance.value), field.FieldType),

            PropertyInfo property =>
                (property.GetValue(instance.value), property.PropertyType),

            _ => throw new NotSupportedException(
                $"Invalid expression. Member type {member.GetType()} is not supported in RPC expressions")
        };
    }
}