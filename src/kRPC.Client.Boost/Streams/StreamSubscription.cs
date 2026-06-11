using System.Linq.Expressions;
using System.Reflection;
using kRPC.Client.Boost.Helpers;
using kRPC.Client.Boost.Services;

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
        var expressionDictionary = expressions.ToDictionary(
            GetStreamKey,
            e => e);

        foreach (var kvp in expressionDictionary)
        {
            AddSubscription(kvp.Key, kvp.Value);
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
    
    private void AddSubscription(string key, LambdaExpression expression)
    {
        var methodCallExpression = expression.Body as MethodCallExpression;
        var returnType = methodCallExpression!.Method.ReturnType;
        var addMethod = _addSubscription.MakeGenericMethod(returnType);
        
        _managedKeys.Add(key);
        addMethod.Invoke(null, [key, expression]);
    }

    private static string GetStreamKey(LambdaExpression expression)
    {
        var parser = new ExpressionParser(expression);
        var key = $"{parser.Service}_{parser.Procedure}";

        foreach (var argument in parser.Arguments)
        {
            var argumentValue = argument.value;
            if (argument.type == typeof(RemoteObject))
            {
                var remoteObject = argument.value as RemoteObject;
                argumentValue = remoteObject?.Id;
            }
            
            key += $"_{argumentValue?.ToString() ?? "null"}";
        }

        return key;
    }
}