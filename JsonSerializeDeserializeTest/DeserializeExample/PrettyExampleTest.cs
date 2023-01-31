using System.Collections.Immutable;
using System.Text.Json;
using JsonSerializeDeserialize.DeserializeExample.DTO.Harder;

namespace JsonSerializeDeserializeTest.DeserializeExample;

public class PrettyExampleTest
{
    [Test]
    public void Deserialize_ValidPrettyJsonString_ReturnsExpectedJobAndRecruiterObject()
    {
        const string json = """
        {
          "recruiter": {
            "name": "Malcolm Tucker"
          },
          "title": "Java Developer",
          "salary": 44450,
          "tags": [
            { "name": "spring framework" },
            { "name": "abstract singleton factory bean" }
          ]
        }
        """;

        var job = JsonSerializer.Deserialize<Job>(json, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });

        Assert.That(job.Title, Is.EqualTo("Java Developer"));
        Assert.That(job.Salary, Is.EqualTo(44_450));
        Assert.That(job.Recruiter, Is.InstanceOf<Recruiter>());
        Assert.That(job.Recruiter.Name, Is.EqualTo("Malcolm Tucker"));
        Assert.That(job.Tags, Has.Count.EqualTo(2));
        Assert.That(job.Tags[0].Name, Is.EqualTo("spring framework"));
        Assert.That(job.Tags[1].Name, Is.EqualTo("abstract singleton factory bean"));
    }

    [Test]
    public void Serialize_ValidJobAndRecruiterObject_SerializesToExpectedPrettyJSONString()
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

        const string expectedJson = """
        {
          "title": "Kotlin Developer",
          "salary": 85950,
          "tags": [
            {
              "name": "java"
            },
            {
              "name": "android"
            }
          ],
          "recruiter": {
            "name": "Alan Johnson"
          }
        }
        """;

        var actualJson = JsonSerializer.Serialize(job, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        });

        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }
}
