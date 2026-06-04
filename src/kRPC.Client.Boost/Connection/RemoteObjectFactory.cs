using System.Reflection;

namespace kRPC.Client.Boost.Connection;

internal static class RemoteObjectFactory
{
    public static object Create(Type type, IConnectionMultiplexer connection, ulong id)
    {
        var ctor = type
            .GetTypeInfo()
            .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(c => c.GetParameters().Length == 2);

        if (ctor == null)
            throw new ArgumentException($"No valid constructor found for {type.Name}");

        return ctor.Invoke([connection, id]);
    }
}