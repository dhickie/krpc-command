using kRPC.Client.Boost.Connection;
using kRPC.Client.Boost.Exceptions;

namespace kRPC.Client.Boost.Services;

/// <summary>
/// Represents a KRPC object that interacts with the server in some way.
/// </summary>
public abstract class ServiceObject
{
    internal IConnectionMultiplexer Connection { get; }

    /// <summary>
    /// Creates a service object using the provided connection multiplexer.
    /// </summary>
    /// <param name="connection">The connection multiplexer</param>
    internal ServiceObject(IConnectionMultiplexer connection)
    {
        Connection = connection;
    }
    
    /// <summary>
    /// Invoke an RPC that returns a non-nullable value. Executes synchronously.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The name of the procedure</param>
    /// <param name="args">Arguments to the procedure</param>
    /// <typeparam name="T">The type of the result</typeparam>
    /// <returns>The result of the procedure</returns>
    internal T InvokeNonNullable<T>(string service, string procedure, ProcedureArgument[]? args = null)
    {
        var result = Connection.Invoke<T>(service, procedure, args);
        NullRpcResponseException.ThrowIfNull(result, service, procedure);
        return result!;
    }
    
    /// <summary>
    /// Invoke an RPC that returns a non-nullable value. Executes asynchronously.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The name of the procedure</param>
    /// <param name="args">Arguments to the procedure</param>
    /// <typeparam name="T">The type of the result</typeparam>
    /// <returns>The result of the procedure</returns>
    internal async Task<T> InvokeNonNullableAsync<T>(string service, string procedure, ProcedureArgument[]? args = null)
    {
        var result = await Connection.InvokeAsync<T>(service, procedure, args);
        NullRpcResponseException.ThrowIfNull(result, service, procedure);
        return result!;
    }
    
    /// <summary>
    /// Invoke an RPC that returns a nullable value. Executes synchronously.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The name of the procedure</param>
    /// <param name="args">Arguments to the procedure</param>
    /// <typeparam name="T">The non-nullable type of the result</typeparam>
    /// <returns>The result of the procedure</returns>
    internal T? InvokeNullable<T>(string service, string procedure, ProcedureArgument[]? args = null)
    {
        return Connection.Invoke<T>(service, procedure, args);
    }
    
    /// <summary>
    /// Invoke an RPC that returns a nullable value. Executes asynchronously.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The name of the procedure</param>
    /// <param name="args">Arguments to the procedure</param>
    /// <typeparam name="T">The non-nullable type of the result</typeparam>
    /// <returns>The result of the procedure</returns>
    internal async Task<T?> InvokeNullableAsync<T>(string service, string procedure, ProcedureArgument[]? args = null)
    {
        return await Connection.InvokeAsync<T>(service, procedure, args);
    }
    
    /// <summary>
    /// Invoke an RPC that doesn't return a value. Executes synchronously.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The name of the procedure</param>
    /// <param name="args">Arguments to the procedure</param>
    internal void InvokeVoid(string service, string procedure, ProcedureArgument[]? args = null)
    {
        Connection.Invoke(service, procedure, args);
    }
    
    /// <summary>
    /// Invoke an RPC that doesn't return a value. Executes asynchronously.
    /// </summary>
    /// <param name="service">The service the procedure is part of</param>
    /// <param name="procedure">The name of the procedure</param>
    /// <param name="args">Arguments to the procedure</param>
    internal async Task InvokeVoidAsync(string service, string procedure, ProcedureArgument[]? args = null)
    {
        await Connection.InvokeAsync(service, procedure, args);
    }
}