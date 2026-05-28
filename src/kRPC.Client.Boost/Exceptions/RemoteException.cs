namespace kRPC.Client.Boost.Exceptions;

public class RemoteException(string message) 
    : Exception($"An exception occured on the remote server: {message}");