namespace kRPC.Client.Boost.Helpers;

/// <summary>
/// An implementation of IMethodInjector that doesn't do anything.
/// </summary>
internal class NullMethodInjector : IMethodInjector
{
    public void DoWork(object? operationId)
    {
    }
}