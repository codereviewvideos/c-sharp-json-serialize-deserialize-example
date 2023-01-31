namespace JsonSerializeDeserialize.DeserializeExample.DTO.MissingProperties;

public record Animal
{
    public string? Name { get; init; }
    public int Age { get; init; }
    public double Weight { get; init; } = 36.3;

}
