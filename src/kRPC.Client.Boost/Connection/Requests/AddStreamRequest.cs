using System.Linq.Expressions;

namespace kRPC.Client.Boost.Connection.Requests;

/// <summary>
/// Represents a request from the multiplexer to the stream connection to add a new stream.
/// </summary>
/// <param name="streamType">The type of data returned by the stream</param>
/// <param name="expression">The stream's expression</param>
/// <param name="start">Whether to start the stream immediately</param>
internal class AddStreamRequest(Type streamType, LambdaExpression expression, bool start)
    : StreamRequest("AddStream", [expression, start])
{
    public readonly Type StreamType = streamType;
}