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
    /// <returns>The result of the procedure</returns>
    public T WaitForResult()
    {
        return WaitForResult<T>();
    }

    /// <summary>
    /// Waits asynchronously for the result of the procedure to become available.
    /// </summary>
    /// <returns>The result of the procedure</returns>
    public async Task<T> WaitForResultAsync()
    {
        return await WaitForResultAsync<T>();
    }
    
    protected override void SetResultImpl(object result)
    {
        _result = (T)result;
    }

    protected override object GetResultImpl()
    {
        return _result ?? throw new ProcedureException("Attempt to get the result of unfinished procedure");
    }
}

/// <summary>
/// Represents the pending or complete result of a procedure that returns the provided type.
/// </summary>
/// <param name="resultType">The type of the result</param>
internal abstract class ProcedureResult(Type resultType)
{
    private readonly SemaphoreSlim _resultLock = new(0, 1);
    
    /// <summary>
    /// Sets the result of the procedure and notifies threads waiting for the result.
    /// </summary>
    /// <param name="result">The result of the operation</param>
    /// <exception cref="ArgumentException">
    ///     Thrown if the provided result does not match the type of the result for this procedure
    /// </exception>
    public void SetResult(object result)
    {
        if (result.GetType() != resultType)
            throw new ArgumentException($"Result type {result.GetType().Name} does not match the specified type for this procedure");

        SetResultImpl(result); // Set the result
        _resultLock.Release(); // Let other threads know the result is ready
    }

    protected T WaitForResult<T>()
    {
        _resultLock.Wait();
        return GetResult<T>();
    }
    
    protected async Task<T> WaitForResultAsync<T>()
    {
        await _resultLock.WaitAsync();
        return GetResult<T>();
    }

    protected abstract void SetResultImpl(object result);
    
    protected abstract object GetResultImpl();
    
    private T GetResult<T>()
    {
        return typeof(T) != resultType 
            ? throw new ArgumentException($"Result type {typeof(T).Name} does not match the specified type for this procedure") 
            : (T)GetResultImpl();
    }
}