using System.Collections.Concurrent;
using kRPC.Client.Boost.Config;
using kRPC.Client.Boost.Connection.Requests;
using kRPC.Client.Boost.Logging;
using Microsoft.Extensions.Logging;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Represents a connection to the server that invokes RPCs from a queue of pending requests.
/// </summary>
internal class RpcConnection : PollingConnection<ProcedureRequest, RpcConnection>
{
    private readonly ILogger<RpcConnection> _logger = LogManager.GetLogger<RpcConnection>();
    private readonly string _connectionName;

    /// <summary>
    /// Create a new RPC connection.
    /// </summary>
    /// <param name="connection">The top level connection for passing to remote object instances</param>
    /// <param name="config">The configuration for the connection</param>
    /// <param name="connectionName">The name of this connection</param>
    /// <param name="requestQueue">The queue of pending RPCs to invoke</param>
    /// <param name="responses">The collection of response objects</param>
    public RpcConnection(ConnectionMultiplexer connection, 
        ConnectionConfig config,
        string connectionName,
        BlockingCollection<ProcedureRequest> requestQueue, 
        ConcurrentDictionary<string, ProcedureResult> responses)
    : base(connection, config, connectionName, requestQueue, responses)
    {
        _connectionName = connectionName;
        Setup(_logger, Invoke);
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

    protected override void LogRequestStart(ProcedureRequest request)
    {
        var argumentsString = string.Join(", ", request.Arguments);
        var queueTime = GetQueueTime(request);
        _logger.LogDebug(
            "RPC request {requestId} to {service}_{procedure} with arguments {arguments} served by {connectionName} after {queueTime}ms in queue",
            request.RequestId, 
            request.Service, 
            request.Procedure, 
            argumentsString, 
            _connectionName,
            queueTime.TotalMilliseconds);
    }

    protected override void LogRequestEnd(ProcedureRequest request, TimeSpan duration, bool success)
    {
        var resultString = success ? "success" : "failure";
        _logger.LogDebug("RPC Request {requestId} ended in {result} after {duration}ms", 
            request.RequestId, resultString, duration.TotalMilliseconds);
    }
}