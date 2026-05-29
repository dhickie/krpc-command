namespace kRPC.Client.Boost.Exceptions;

public class CodecException(string message) : 
    Exception($"{message} - if you're seeing this then there's a bug that needs fixing!");