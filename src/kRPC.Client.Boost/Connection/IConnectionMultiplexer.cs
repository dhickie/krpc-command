using System.Linq.Expressions;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;

namespace kRPC.Client.Boost.Connection;


internal interface IConnectionMultiplexer : IConnection
{
    /// <summary>
    /// Synchronously adds a new stream to the server.
    /// </summary>
    /// <param name="expression">The expression for the stream</param>
    /// <param name="start">Whether to start the stream immediately</param>
    /// <typeparam name="T">The type of the data updated by the stream</typeparam>
    /// <returns>The remote stream object</returns>
    RemoteStream AddStream<T>(Expression<Func<T>> expression, bool start);

    /// <summary>
    /// Asynchronously adds a new stream to the server.
    /// </summary>
    /// <param name="expression">The expression for the stream</param>
    /// <param name="start">Whether to start the stream immediately</param>
    /// <typeparam name="T">The type of the data updated by the stream</typeparam>
    /// <returns>The remote stream object</returns>
    Task<RemoteStream> AddStreamAsync<T>(Expression<Func<T>> expression, bool start);

    /// <summary>
    /// Synchronously removes a stream from the server.
    /// </summary>
    /// <param name="streamId">The ID of the stream to remove</param>
    void RemoveStream(ulong streamId);

    /// <summary>
    /// Asynchronously removes a stream from the server.
    /// </summary>
    /// <param name="streamId">The ID of the stream to remove</param>
    Task RemoveStreamAsync(ulong streamId);

    /// <summary>
    /// Synchronously invokes a procedure that doesn't have a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    void Invoke(string service, string procedure, ProcedureArgument[]? arguments = null);

    /// <summary>
    /// Synchronously invokes a procedure that returns a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    /// <typeparam name="TResponse">The type of the response object</typeparam>
    /// <returns>The result object from the procedure.</returns>
    TResponse? Invoke<TResponse>(string service, string procedure, ProcedureArgument[]? arguments = null);

    /// <summary>
    /// Asynchronously invokes a procedure that doesn't have a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    Task InvokeAsync(string service, string procedure, ProcedureArgument[]? arguments = null);

    /// <summary>
    /// Asynchronously invokes a procedure that returns a result object.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The procedure to invoke</param>
    /// <param name="arguments">The arguments to the procedure</param>
    /// <typeparam name="TResponse">The type of the response object</typeparam>
    /// <returns>The result object from the procedure.</returns>
    Task<TResponse?> InvokeAsync<TResponse>(string service, string procedure, ProcedureArgument[]? arguments = null);
}