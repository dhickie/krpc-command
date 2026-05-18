using System.Linq.Expressions;
using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Services.KRPC.RemoteObjects;

namespace kRPC.Client.Boost.Services.KRPC;

/// <summary>
/// Provides top level access to the KRPC service.
/// </summary>
/// <param name="connection">The connection multiplexer that provides access to the server</param>
// ReSharper disable once InconsistentNaming
public class KRPC(ConnectionMultiplexer connection)
{
    /// <summary>
    /// Synchronously dds a stream to the server.
    /// </summary>
    /// <param name="expression">The expression for the stream</param>
    /// <param name="start">Whether to start the stream immediately</param>
    /// <typeparam name="T">The type for the data contained in the stream</typeparam>
    /// <returns>The created remote stream object</returns>
    internal RemoteStream AddStream<T>(Expression<Func<T>> expression, bool start)
    {
        return connection.AddStream(expression, start);
    }

    /// <summary>
    /// Asynchronously dds a stream to the server.
    /// </summary>
    /// <param name="expression">The expression for the stream</param>
    /// <param name="start">Whether to start the stream immediately</param>
    /// <typeparam name="T">The type for the data contained in the stream</typeparam>
    /// <returns>The created remote stream object</returns>
    internal async Task<RemoteStream> AddStreamAsync<T>(Expression<Func<T>> expression, bool start)
    {
        return await connection.AddStreamAsync(expression, start);
    }
}