// ReSharper disable UnusedParameter.Global
namespace kRPC.Client.Boost.Helpers;

/// <summary>
/// Used to facilitate testing, by allowing tests to inject custom logic during certain method calls.
/// Useful for simulating race conditions.
/// </summary>
internal interface IMethodInjector
{
    void DoWork(object operationId, Dictionary<string,object>? bag = null);
}