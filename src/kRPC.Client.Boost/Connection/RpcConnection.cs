using System.Collections.Concurrent;
using kRPC.Client.Boost.Connection.Requests;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Represents a connection to the server that invokes RPCs from a queue of pending requests.
/// </summary>
internal class RpcConnection : PollingConnection<ProcedureRequest>
{
    /// <summary>
    /// Create a new RPC connection.
    /// </summary>
    /// <param name="connection">The top level connection for passing to remote object instances</param>
    /// <param name="config">The configuration for the connection</param>
    /// <param name="requestQueue">The queue of pending RPCs to invoke</param>
    /// <param name="responses">The collection of response objects</param>
    public RpcConnection(ConnectionMultiplexer connection, 
        ConnectionConfig config, 
        BlockingCollection<ProcedureRequest> requestQueue, 
        ConcurrentDictionary<string, ProcedureResult> responses)
    : base(connection, config, requestQueue, responses)
    {
        SetInvokeAction(Invoke);
        StartPolling();
    }

    private void Invoke(ProcedureRequest request, ProcedureResult response)
    {
        if (request is ReturningProcedureRequest returningRequest)
        {
            var result = Invoke(returningRequest.ResultType, request.Service, request.Procedure, request.Arguments);
            response.MarkComplete(result);
        }
        else
        {
            Invoke(request.Service, request.Procedure, request.Arguments);
            response.MarkComplete();
        }
    }
}