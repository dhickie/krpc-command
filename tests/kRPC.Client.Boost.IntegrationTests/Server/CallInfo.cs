namespace kRPC.Client.Boost.IntegrationTests.Server;

public class CallInfo(string service, string procedure, object?[]? arguments)
{
    public readonly string Service = service;
    public readonly string Procedure = procedure;
    public readonly object?[]? Arguments = arguments;
}