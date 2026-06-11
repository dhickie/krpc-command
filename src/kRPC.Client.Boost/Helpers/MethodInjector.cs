namespace kRPC.Client.Boost.Helpers;

/// <summary>
/// Provides static access to a pre-configured IMethodInjector instance in methods where method injection
/// is useful for testing.
/// </summary>
internal static class MethodInjector
{
    private static object injectorLock = new();
    private static IMethodInjector _methodInjector;

    /// <summary>
    /// Defaults to a NullMethodInjector that takes no action.
    /// </summary>
    static MethodInjector()
    {
        _methodInjector = new NullMethodInjector();
    }

    /// <summary>
    /// Gets the current method injector if it isn't a NullMethodInjector, or updates it to the provided value and
    /// then returns it. This should only be called from tests.
    /// </summary>
    /// <param name="injector">The injector to use if it hasn't already been customised from the default NullMethodInjector</param>
    /// <returns>The current method injector</returns>
    public static IMethodInjector GetOrUpdateInjector(IMethodInjector injector)
    {
        if (_methodInjector.GetType() == typeof(NullMethodInjector))
        {
            lock (injectorLock)
            {
                if (_methodInjector.GetType() == typeof(NullMethodInjector))
                    _methodInjector = injector;
            }
        }
        
        return _methodInjector;
    }

    /// <summary>
    /// Performs some work using the current method injector.
    /// </summary>
    /// <param name="operationId">The ID of the operation being performed that is invoked this method</param>
    /// <param name="bag">A string indexed bag of any relevant information that may be useful</param>
    public static void DoWork(object operationId, Dictionary<string,object>? bag = null)
    {
        _methodInjector.DoWork(operationId, bag);
    }
}