using System.Linq.Expressions;
using System.Reflection;

namespace kRPC.Client.Boost.Streams;

/// <summary>
/// StreamSubscription subscribes to a stream of data described by a set of expressions. When destroyed or disposed,
/// it automatically unsubscribes from all the streams it subscribed to.
/// </summary>
public sealed class StreamSubscription : IDisposable
{
    private readonly MethodInfo _addSubscription = 
        typeof(StreamManager).GetMethod(nameof(StreamManager.AddSubscription))!;

    private readonly List<string> _managedKeys = new();
    
    /// <summary>
    /// Creates a stream subscription to one or more pieces of kRPC data for the lifetime of the object.
    /// All provided expressions must be of a type Expression&lt;Func&lt;T&gt;&gt;.
    /// </summary>
    /// <param name="expressions">Expressions describing the data that should be subscribed to.</param>
    /// <exception cref="ArgumentException">Thrown if provided with expressions of an invalid type.</exception>
    public StreamSubscription(params LambdaExpression[] expressions)
    {
        if (expressions.Any(e => !IsValidExpressionType(e)))
            throw new ArgumentException("Expressions must be an Expression<Func<T>> that calls a single function with no chaining and no parameters");

        foreach (var expression in expressions)
        {
            AddSubscription(expression);
        }
    }

    ~StreamSubscription()
    {
        Dispose();
    }

    public void Dispose()
    {
        foreach (var key in _managedKeys)
        {
            StreamManager.RemoveSubscription(key);
        }
    }

    private bool IsValidExpressionType(LambdaExpression expression)
    {
        return expression.Type.IsGenericType &&
               expression.Type.GetGenericTypeDefinition() == typeof(Func<>) &&
               expression.Parameters.Count == 0 &&
               expression.Body.GetType() == typeof(MethodCallExpression);
    }
    
    private void AddSubscription(LambdaExpression expression)
    {
        var methodCallExpression = expression.Body as MethodCallExpression;
        var returnType = methodCallExpression!.Method.ReturnType;
        var addMethod = _addSubscription.MakeGenericMethod(returnType);
        
        var key = GetStreamKey(expression);
        _managedKeys.Add(key);
        addMethod.Invoke(null, [key, expression]);
    }

    private string GetStreamKey(LambdaExpression expression)
    {
        // TODO implement this when we have attributes indicating procedure names
        throw new NotImplementedException();
    }
}