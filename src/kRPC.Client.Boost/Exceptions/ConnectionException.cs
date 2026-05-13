namespace kRPC.Client.Boost.Exceptions;

public class ConnectionException(string message) 
    : Exception($"An error occured connecting to the server: {message}")
{
    
}