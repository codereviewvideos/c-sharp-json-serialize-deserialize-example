using System.Collections.Immutable;
using System.Text.Json;
using JsonSerializeDeserialize.DeserializeExample.DTO.Harder;

namespace JsonSerializeDeserializeTest.DeserializeExample;

public class HarderExampleTest
{
    [Test]
    public void Deserialize_ValidJsonString_ReturnsExpectedJobRecruiterAndTagsObjects()
    {
        const string json = """
        {
          "Recruiter": {
            "Name": "Ken Addams"
          },
          "Title": "C# Developer",
          "Salary": 38000,
          "Tags": [
            { "Name": "entity framework" },
            { "Name": "dot net" },
            { "Name": "azure" }
          ]
        }
        """;

        var job = JsonSerializer.Deserialize<Job>(json);

        Assert.That(job.Title, Is.EqualTo("C# Developer"));
        Assert.That(job.Salary, Is.EqualTo(38_000));
        Assert.That(job.Recruiter, Is.InstanceOf<Recruiter>());
        Assert.That(job.Recruiter.Name, Is.EqualTo("Ken Addams"));
        Assert.That(job.Tags, Has.Count.EqualTo(3));
        Assert.That(job.Tags[0].Name, Is.EqualTo("entity framework"));
        Assert.That(job.Tags[1].Name, Is.EqualTo("dot net"));
        Assert.That(job.Tags[2].Name, Is.EqualTo("azure"));
    }

    [Test]
    public void Serialize_ValidJobRecruiterAndTagsObject_SerializesToExpectedJSONString()
    {
        var job = new Job
        {
            Title = "Kotlin Developer",
            Salary = 85_950,
            Recruiter = new Recruiter { Name = "Alan Johnson" },
            Tags = ImmutableList.Create(
                new Tag { Name = "java" },
                new Tag { Name = "android" }
            )
        };

        const string expectedJson =
            @"{""Title"":""Kotlin Developer"",""Salary"":85950,""Tags"":[{""Name"":""java""},{""Name"":""android""}],""Recruiter"":{""Name"":""Alan Johnson""}}";

        var actualJson = JsonSerializer.Serialize(job);

        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }
}
