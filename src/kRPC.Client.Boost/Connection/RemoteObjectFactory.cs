using System.Reflection;
using kRPC.Client.Boost.Services;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Provides tools for creating instances of remote objects while decoding objects.
/// </summary>
internal static class RemoteObjectFactory
{
    /// <summary>
    /// Creates an instance of the specified remote object type.
    /// </summary>
    /// <param name="type">The type of remote object</param>
    /// <param name="connection">The connection multiplexer to use</param>
    /// <param name="id">The ID of the remote object</param>
    /// <returns>The remote object</returns>
    /// <exception cref="ArgumentException">
    ///     Thrown if the provided type does not inherit from RemoteObject or does not expose a constructor with the correct signature.
    /// </exception>
    public static object Create(Type type, IConnectionMultiplexer connection, ulong id)
    {
        if (!type.IsAssignableTo(typeof(RemoteObject)))
            throw new ArgumentException($"The type {type.Name} does not inherit from {nameof(RemoteObject)}");
        
        var ctor = type
            .GetTypeInfo()
            .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(c => c.GetParameters().Length == 2);

        if (ctor == null)
            throw new ArgumentException($"No valid constructor found for {type.Name}");

        return ctor.Invoke([connection, id]);
    }
}