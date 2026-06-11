using System.Reflection;
using AutoFixture;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services;
using kRPC.Client.Boost.UnitTests.Fakes;
using NSubstitute;

namespace kRPC.Client.Boost.UnitTests.Helpers;

/// <summary>
/// Remote objects don't have a public constructor, so AutoFixture can't create them directly.
/// This provides a helper method for tests to randomly generate remote objects.
/// </summary>
public static class RemoteObjectFixture
{
    private static readonly Fixture Fixture = new();
    private static readonly IConnectionMultiplexer Connection = Substitute.For<IConnectionMultiplexer>();

    public static T Create<T>() where T : RemoteObject
    {
        var remoteObject = Create(typeof(T)) as T;
        return remoteObject 
               ?? throw new InvalidOperationException(
                   "Requested type didn't have a constructor with the expected signature");
    }

    public static object Create(Type type)
    {
        var id = Fixture.Create<ulong>();
        return RemoteObjectFactory.Create(type, Connection, id);
    }
}