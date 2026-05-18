namespace kRPC.Client.Boost.Connection.Requests;

/// <summary>
/// Represents a request to perform a procedure related to a stream.
/// </summary>
/// <param name="procedure">The procedure to perform</param>
/// <param name="arguments">The arguments to the procedure</param>
internal abstract class StreamRequest(string procedure, object[]? arguments = null) 
    : ProcedureRequest("KRPC", procedure, arguments)
{
    
}