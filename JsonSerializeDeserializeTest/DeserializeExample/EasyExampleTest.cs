using System.Text.Json;
using JsonSerializeDeserialize.DeserializeExample.DTO.Easy;

namespace JsonSerializeDeserializeTest.DeserializeExample;

public class EasyExampleTest
{
    [Test]
    public void Deserialize_ValidJsonString_ReturnsExpectedJobObject()
    {
        const string json = """
            { "Title": "C# Developer", "Salary": 38000 }
        """;

        var job = JsonSerializer.Deserialize<Job>(json);

        Assert.That(job.Title, Is.EqualTo("C# Developer"));
        Assert.That(job.Salary, Is.EqualTo(38_000));
    }

    [Test]
    public void Serialize_ValidJobObject_SerializesToExpectedJSONString()
    {
        var job = new Job { Salary = 55_000, Title = "PHP Developer" };

        const string expectedJson = "{\"Title\":\"PHP Developer\",\"Salary\":55000}";

        var actualJson = JsonSerializer.Serialize(job);

        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }
}
