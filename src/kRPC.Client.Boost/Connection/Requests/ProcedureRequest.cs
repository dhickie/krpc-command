namespace kRPC.Client.Boost.Connection.Requests;

/// <summary>
/// Represents a request to perform a procedure.
/// </summary>
/// <param name="service">The service the procedure exists in</param>
/// <param name="procedure">The procedure to perform</param>
/// <param name="arguments">The arguments to the procedure</param>
internal class ProcedureRequest(string service, string procedure, object[]? arguments = null)
{
    public readonly string RequestId = Guid.NewGuid().ToString();
    public readonly string Service = service;
    public readonly string Procedure = procedure;
    public readonly object[] Arguments = arguments ?? [];
}