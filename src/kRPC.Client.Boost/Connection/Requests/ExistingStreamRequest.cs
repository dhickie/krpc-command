namespace kRPC.Client.Boost.Connection.Requests;

/// <summary>
/// Represents a request to perform a procedure on a pre-existing stream.
/// </summary>
/// <param name="streamId">The ID of the stream to operate on</param>
/// <param name="procedure">Which procedure to perform</param>
/// <param name="arguments">The arguments of the procedure</param>
internal class ExistingStreamRequest(ulong streamId, string procedure, object?[]? arguments = null) 
    : StreamRequest(procedure, arguments)
{
    public readonly ulong StreamId = streamId;
}
