namespace kRPC.Client.Boost.Attributes;

[AttributeUsage(AttributeTargets.Method)]
internal class RpcAttribute(string service, string procedure) : Attribute
{
    public readonly string Service = service;
    public readonly string Procedure = procedure;
}