namespace kRPC.Client.Boost.Connection.Requests;

/// <summary>
/// Represents a request to remove a stream from the server.
/// </summary>
/// <param name="streamId">The ID of the stream to remove</param>
internal class RemoveStreamRequest(ulong streamId) 
    : ExistingStreamRequest(streamId, "RemoveStream", [streamId])
{
}