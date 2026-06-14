namespace kRPC.Client.Boost.IntegrationTests.Exceptions;

public class InvalidRequestException(string service, string procedure, string message) 
    : Exception($"Request to procedure {procedure} in service {service} was invalid: {message}");