namespace kRPC.Client.Boost.Exceptions;

public class NullRpcResponseException(string service, string procedure) 
    : Exception($"Non-nullable procedure {service}_{procedure} returned a null value")
{
    public static void ThrowIfNull(object? value, string service, string procedure)
    {
        if (value == null)
            throw new NullRpcResponseException(service, procedure);
    }
}