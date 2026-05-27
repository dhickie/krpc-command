namespace kRPC.Client.Boost.Exceptions;

public class StreamCreationException(string message) 
    : Exception($"An error occured trying to create the stream: {message}")
{
}