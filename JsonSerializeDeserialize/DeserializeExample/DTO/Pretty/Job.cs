using System.Collections.Immutable;

namespace JsonSerializeDeserialize.DeserializeExample.DTO.Pretty;

public record Job
{
    public required string Title { get; init; }
    public required int Salary { get; init; }
    public required ImmutableList<Tag> Tags { get; init; }
    public required Recruiter Recruiter { get; init; }
}
