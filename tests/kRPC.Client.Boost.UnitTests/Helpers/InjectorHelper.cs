using kRPC.Client.Boost.Helpers;
using NSubstitute;

namespace kRPC.Client.Boost.UnitTests.Helpers;

/// <summary>
/// Provides a helper method for getting the current method injector in a test.
/// </summary>
internal static class InjectorHelper
{
    public static IMethodInjector GetInjector()
    {
        var newInjector = Substitute.For<IMethodInjector>();
        return MethodInjector.GetOrUpdateInjector(newInjector);
    }
}