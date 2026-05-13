namespace kRPC.Client.Boost.Exceptions;

public class ProcedureException(string message)
    : Exception($"An error occured in the client trying to execute a remote procedure: {message}")
{
}