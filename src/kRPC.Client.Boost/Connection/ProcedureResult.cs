using kRPC.Client.Boost.Exceptions;

namespace kRPC.Client.Boost.Connection;

/// <summary>
/// Represents the pending or complete result of a procedure that returns the provided type.
/// </summary>
/// <typeparam name="T">The type of the value returned by the procedure</typeparam>
internal sealed class ProcedureResult<T>() : ProcedureResult(typeof(T))
{
    private T? _result;

    /// <summary>
    /// Waits synchronously for the result of the procedure to become available.
    /// </summary>
    /// <param name="ct">The cancellation token for the wait operation</param>
    /// <returns>The result of the procedure</returns>
    public T WaitForResult(CancellationToken ct)
    {
        return WaitForResult<T>(ct);
    }

    /// <summary>
    /// Waits asynchronously for the result of the procedure to become available.
    /// </summary>
    /// <param name="ct">The cancellation token for the wait operation</param>
    /// <returns>The result of the procedure</returns>
    public async Task<T> WaitForResultAsync(CancellationToken ct)
    {
        return await WaitForResultAsync<T>(ct);
    }

    /// <summary>
    /// Gets the result object for the procedure. Will throw an InvalidOperationException if the procedure isn't
    /// yet complete.
    /// Use <c>WaitForResult</c>/<c>WaitForResultAsync</c> to both wait for the procedure to complete
    /// and return the result object, or call <c>WaitForCompletion</c>/<c>WaitForCompletionAsync</c> before calling
    /// this method.
    /// </summary>
    /// <returns>The result of the procedure</returns>
    public T GetResult()
    {
        return GetResult<T>();
    }
    
    protected override void MarkCompleteImpl(object result)
    {
        _result = (T)result;
    }

    protected override object GetResultImpl()
    {
        return _result ?? throw new ProcedureException("Attempt to get the result of unfinished procedure");
    }
}

internal class ProcedureResult
{
    private Exception? _error;
    private readonly Type? _resultType;
    private readonly SemaphoreSlim _resultLock = new(0, 1);

    /// <summary>
    /// Creates a pending procedure result for a procedure that doesn't return a result object.
    /// </summary>
    public ProcedureResult()
    {
        _resultType = null;
    }

    /// <summary>
    /// Creates a pending procedure result for a procedure that returns a result object of the provided type.
    /// </summary>
    /// <param name="resultType">The type of the result object returned by the procedure</param>
    protected ProcedureResult(Type resultType)
    {
        _resultType = resultType;
    }
    
    /// <summary>
    /// Sets the result of the procedure and notifies threads waiting for the result.
    /// </summary>
    /// <param name="result">The result of the operation</param>
    /// <exception cref="ArgumentException">
    ///     Thrown if the provided result does not match the type of the result for this procedure
    /// </exception>
    public void MarkComplete(object? result = null)
    {
        if (_resultType != null && result == null)
            throw new ArgumentException("Non null result must be provided for procedures that return a result object");
        
        if (_resultType == null && result != null)
            throw new ArgumentException($"Can't set the result of a procedure that doesn't return a result object");

        if (result != null)
        {
            if (result.GetType() != _resultType)
                throw new ArgumentException($"Result type {result.GetType().Name} does not match the specified type for this procedure");
            
            MarkCompleteImpl(result); // Set the result
        }
        
        _resultLock.Release(); // Let other threads know the result is ready
    }

    /// <summary>
    /// Sets the error for an unsuccessful procedure, and notifies other threads that the procedure has completed.
    /// </summary>
    /// <param name="error">The exception that was thrown while trying to perform the operation</param>
    public void MarkFaulted(Exception error)
    {
        _error = error;
        _resultLock.Release();
    }

    /// <summary>
    /// Waits synchronously for the procedure to complete.
    /// </summary>
    /// <param name="ct">The cancellation token for the wait operation</param>
    public void WaitForCompletion(CancellationToken ct)
    {
        _resultLock.Wait(ct);

        if (_error != null)
            throw _error;
    }

    /// <summary>
    /// Waits asynchronously for the procedure to complete.
    /// </summary>
    /// <param name="ct">The cancellation token for the wait operation</param>
    public async Task WaitForCompletionAsync(CancellationToken ct)
    {
        await _resultLock.WaitAsync(ct);
        
        if (_error != null)
            throw _error;
    }

    protected T WaitForResult<T>(CancellationToken ct)
    {
        if (_resultType == null)
            throw new InvalidOperationException("Can't wait for a result object from a procedure that doesn't return a result object");
        
        WaitForCompletion(ct);
        return GetResult<T>();
    }
    
    protected async Task<T> WaitForResultAsync<T>(CancellationToken ct)
    {
        await WaitForCompletionAsync(ct);
        return GetResult<T>();
    }

    protected virtual void MarkCompleteImpl(object result)
    {
        throw new NotImplementedException("Can't set the result of a procedure that doesn't return a result object");
    }

    protected virtual object GetResultImpl()
    {
        throw new NotImplementedException("Can't get the result of a procedure that doesn't have a return object");
    }
    
    protected T GetResult<T>()
    {
        if (_resultLock.CurrentCount == 0)
            throw new InvalidOperationException("Can't get the result of a procedure that hasn't completed yet");

        if (typeof(T) != _resultType)
            throw new ArgumentException($"Result type {typeof(T).Name} does not match the specified type for this procedure");
            
        return (T)GetResultImpl();
    }
}