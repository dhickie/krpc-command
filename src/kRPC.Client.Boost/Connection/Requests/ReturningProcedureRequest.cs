namespace kRPC.Client.Boost.Connection.Requests;

/// <summary>
/// Represents a request to execute a remote procedure on the server which returns a value.
/// </summary>
/// <param name="resultType">The type of the result from this procedure</param>
/// <param name="service">The service the procedure exists on</param>
/// <param name="procedure">The name of the procedure to execute</param>
/// <param name="arguments">A list of arguments required by the procedure, in the order they're required</param>
internal class ReturningProcedureRequest(Type resultType, string service, string procedure, object[]? arguments = null)
    : ProcedureRequest(service, procedure, arguments)
{
    public readonly Type ResultType = resultType;
}