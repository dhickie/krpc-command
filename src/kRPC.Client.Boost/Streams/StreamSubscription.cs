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
            throw new ArgumentException("Expressions must be a LambdaExpression or Expression<Func<T>>");

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

    private bool IsValidExpressionType(Expression expression)
    {
        if (expression is not LambdaExpression le)
            return false;
        
        return le.Type.IsGenericType &&
               le.Type.GetGenericTypeDefinition() == typeof(Func<>) &&
               le.Parameters.Count == 0;
    }
    
    private void AddSubscription(LambdaExpression expression)
    {
        var key = GetStreamKey(expression);
        _managedKeys.Add(key);
        _addSubscription.Invoke(null, [key, expression]);
    }

    private string GetStreamKey(LambdaExpression expression)
    {
        throw new NotImplementedException();
    }
}