namespace kRPC.Client.Boost.Helpers;

/// <summary>
/// Provides static access to a pre-configured IMethodInjector instance in methods where method injection
/// is useful for testing.
/// </summary>
internal static class StaticMethodInjector
{
    /// <summary>
    /// The current IMethodInjector instance.
    /// </summary>
    public static IMethodInjector MethodInjector { get; set; }

    /// <summary>
    /// Defaults to a NullMethodInjector that takes no action.
    /// </summary>
    static StaticMethodInjector()
    {
        MethodInjector = new NullMethodInjector();
    }

    /// <summary>
    /// Performs some work using the current method injector.
    /// </summary>
    /// <param name="operationId">The ID of the operation being performed that is invoked this method</param>
    public static void DoWork(object? operationId)
    {
        MethodInjector.DoWork(operationId);
    }
}