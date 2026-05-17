namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Represents a request to execute a remote procedure on the server.
/// </summary>
/// <param name="resultType">The type of the result from this procedure</param>
/// <param name="service">The service the procedure exists on</param>
/// <param name="procedure">The name of the procedure to execute</param>
/// <param name="arguments">A list of arguments required by the procedure, in the order they're required</param>
internal class ProcedureRequest(string service, string procedure, object[]? arguments = null, Type? resultType = null)
{
    public readonly string RequestId = Guid.NewGuid().ToString();
    public readonly Type? ResultType = resultType;
    public readonly string Service = service;
    public readonly string Procedure = procedure;
    public readonly object[] Arguments = arguments ?? [];
}