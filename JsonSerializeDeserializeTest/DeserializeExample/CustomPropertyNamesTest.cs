using System.Text.Json;
using JsonSerializeDeserialize.DeserializeExample.DTO.CustomPropertyNames;

namespace JsonSerializeDeserializeTest.DeserializeExample;

public class CustomPropertyNamesTest
{
    [Test]
    public void Deserialize_VariantJsonStringKeys_ReturnsExpectedPersonObject()
    {
        const string json = """
            { "fore_name": "Timmy", "surname": "Testfield Snr" }
        """;

        var person = JsonSerializer.Deserialize<Person>(json);

        Assert.That(person.FirstName, Is.EqualTo("Timmy"));
        Assert.That(person.LastName, Is.EqualTo("Testfield Snr"));
    }

    [Test]
    public void Serialize_ValidJobObject_SerializesToExpectedJSONString()
    {
        var person = new Person { FirstName = "Barry", LastName = "Ireland" };

        const string expectedJson = "{\"fore_name\":\"Barry\",\"surname\":\"Ireland\"}";

        var actualJson = JsonSerializer.Serialize(person);

        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }
}
