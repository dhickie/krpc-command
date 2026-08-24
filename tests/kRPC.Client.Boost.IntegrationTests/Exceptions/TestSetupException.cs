namespace kRPC.Client.Boost.IntegrationTests.Exceptions;

public class TestSetupException(string message) : Exception($"An error occured setting up the test: {message}");