using System.Text.Json.Serialization;

namespace JsonSerializeDeserialize.DeserializeExample.DTO.CustomPropertyOrder;

public record Alphabodge
{
    [JsonPropertyOrder(3)]
    public required string A { get; init; }
    [JsonPropertyOrder(1)]
    public required string B { get; init; }
    [JsonPropertyOrder(2)]
    public required string C { get; init; }
};
