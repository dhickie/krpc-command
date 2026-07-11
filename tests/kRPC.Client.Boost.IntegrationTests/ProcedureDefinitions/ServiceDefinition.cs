using System.Text.Json.Serialization;

namespace kRPC.Client.Boost.IntegrationTests.ProcedureDefinitions;

/// <summary>
/// A kRPC service definition.
/// </summary>
public class ServiceDefinition
{
    /// <summary>
    /// The service identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// The XML documentation for the service.
    /// </summary>
    [JsonPropertyName("documentation")]
    public string Documentation { get; set; } = string.Empty;

    /// <summary>
    /// The procedures exposed by the service, keyed by procedure name.
    /// </summary>
    [JsonPropertyName("procedures")]
    public Dictionary<string, ProcedureDefinition> Procedures { get; set; } = [];

    /// <summary>
    /// The classes exposed by the service, keyed by class name.
    /// </summary>
    [JsonPropertyName("classes")]
    public Dictionary<string, RpcClass> Classes { get; set; } = [];

    /// <summary>
    /// The enumerations exposed by the service, keyed by enumeration name.
    /// </summary>
    [JsonPropertyName("enumerations")]
    public Dictionary<string, RpcEnum> Enumerations { get; set; } = [];

    /// <summary>
    /// The exceptions exposed by the service, keyed by exception name.
    /// </summary>
    [JsonPropertyName("exceptions")]
    public Dictionary<string, RpcException> Exceptions { get; set; } = [];
}

/// <summary>
/// A kRPC procedure definition.
/// </summary>
public class ProcedureDefinition
{
    /// <summary>
    /// The procedure identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// The procedure parameters.
    /// </summary>
    [JsonPropertyName("parameters")]
    public RpcParameter[] Parameters { get; set; } = [];

    /// <summary>
    /// The procedure return type, or <see langword="null" /> when the procedure has no return value.
    /// </summary>
    [JsonPropertyName("return_type")]
    public RpcParameterType? ReturnType { get; set; }

    /// <summary>
    /// Whether the procedure return value can be null.
    /// </summary>
    [JsonPropertyName("return_is_nullable")]
    public bool ReturnIsNullable { get; set; }

    /// <summary>
    /// The game scenes in which the procedure is available.
    /// </summary>
    [JsonPropertyName("game_scenes")]
    public string[] GameScenes { get; set; } = [];

    /// <summary>
    /// The XML documentation for the procedure.
    /// </summary>
    [JsonPropertyName("documentation")]
    public string Documentation { get; set; } = string.Empty;
}

/// <summary>
/// A kRPC procedure parameter definition.
/// </summary>
public class RpcParameter
{
    /// <summary>
    /// The parameter name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The parameter type.
    /// </summary>
    [JsonPropertyName("type")]
    public RpcParameterType Type { get; set; } = new();

    /// <summary>
    /// The serialized default value, or <see langword="null" /> when no default is specified.
    /// </summary>
    [JsonPropertyName("default_value")]
    public string? DefaultValue { get; set; }

    /// <summary>
    /// Whether the parameter can be null.
    /// </summary>
    [JsonPropertyName("nullable")]
    public bool Nullable { get; set; }
}

/// <summary>
/// A kRPC type definition.
/// </summary>
public class RpcParameterType
{
    /// <summary>
    /// The type code.
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// The service name for class and enumeration types.
    /// </summary>
    [JsonPropertyName("service")]
    public string? Service { get; set; }

    /// <summary>
    /// The class or enumeration name for class and enumeration types.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The child types for composite types such as lists, dictionaries, sets and tuples.
    /// </summary>
    [JsonPropertyName("types")]
    public RpcParameterType[] Types { get; set; } = [];
}

/// <summary>
/// A kRPC class definition.
/// </summary>
public class RpcClass
{
    /// <summary>
    /// The XML documentation for the class.
    /// </summary>
    [JsonPropertyName("documentation")]
    public string Documentation { get; set; } = string.Empty;
}

/// <summary>
/// A kRPC enumeration definition.
/// </summary>
public class RpcEnum
{
    /// <summary>
    /// The XML documentation for the enumeration.
    /// </summary>
    [JsonPropertyName("documentation")]
    public string Documentation { get; set; } = string.Empty;

    /// <summary>
    /// The values defined by the enumeration.
    /// </summary>
    [JsonPropertyName("values")]
    public RpcEnumValue[] Values { get; set; } = [];
}

/// <summary>
/// A kRPC enumeration value definition.
/// </summary>
public class RpcEnumValue
{
    /// <summary>
    /// The enumeration value name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The numeric enumeration value.
    /// </summary>
    [JsonPropertyName("value")]
    public int Value { get; set; }

    /// <summary>
    /// The XML documentation for the enumeration value.
    /// </summary>
    [JsonPropertyName("documentation")]
    public string Documentation { get; set; } = string.Empty;
}

/// <summary>
/// A kRPC exception definition.
/// </summary>
public class RpcException
{
    /// <summary>
    /// The XML documentation for the exception.
    /// </summary>
    [JsonPropertyName("documentation")]
    public string Documentation { get; set; } = string.Empty;
}
