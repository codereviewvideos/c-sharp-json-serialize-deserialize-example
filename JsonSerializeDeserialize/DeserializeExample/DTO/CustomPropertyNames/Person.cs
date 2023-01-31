using System.Text.Json.Serialization;

namespace JsonSerializeDeserialize.DeserializeExample.DTO.CustomPropertyNames;

public record Person
{
    [JsonPropertyName("fore_name")]
    public required string FirstName { get; init; }
    [JsonPropertyName("surname")]
    public required string LastName { get; init; }
};
