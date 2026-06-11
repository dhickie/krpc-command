namespace kRPC.Client.Boost.Attributes;

internal abstract class RpcAttribute(string service, string procedure) : Attribute
{
    public readonly string Service = service;
    public readonly string Procedure = procedure;
}

[AttributeUsage(AttributeTargets.Method)]
internal class GetRpcAttribute(string service, string procedure) : RpcAttribute(service, procedure);

[AttributeUsage(AttributeTargets.Method)]
internal class SetRpcAttribute(string service, string procedure) : RpcAttribute(service, procedure);