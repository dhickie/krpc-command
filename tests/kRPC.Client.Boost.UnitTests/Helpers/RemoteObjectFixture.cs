using System.Reflection;
using AutoFixture;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.UnitTests.Fakes;

namespace kRPC.Client.Boost.UnitTests.Helpers;

/// <summary>
/// Remote objects don't have a public constructor, so AutoFixture can't create them directly.
/// This provides a helper method for tests to randomly generate remote objects.
/// </summary>
public static class RemoteObjectFixture
{
    private static readonly Fixture Fixture = new();
    private static readonly FakeConnectionMultiplexer Connection = new();

    public static T Create<T>() where T : RemoteObject
    {
        var id = Fixture.Create<ulong>();

        var ctor = typeof(T)
            .GetTypeInfo()
            .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
            .FirstOrDefault(c => c.GetParameters().Length == 2);

        if (ctor == null)
            throw new ArgumentException($"No valid constructor found for {typeof(T).Name}");

        var remoteObject = ctor.Invoke([Connection, id]) as T;
        return remoteObject 
               ?? throw new InvalidOperationException(
                   "Requested type didn't have a constructor with the expected signature");
    }
}