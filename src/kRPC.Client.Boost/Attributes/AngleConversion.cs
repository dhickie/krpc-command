namespace kRPC.Client.Boost.Attributes;

/// <summary>
/// Used to denote that an RPC performs a client side conversion of the data type that is returned from the server.
/// Used in tests to assist in performing assertions that cross the boundary between the client and server.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class AngleConversion(AngleType angleType, Type angleDataType) : Attribute
{
    public Type AngleDataType { get; private set; } = angleDataType;
    public AngleType AngleType { get; private set; } = angleType;
}

public enum AngleType
{
    Radians,
    Degrees
}