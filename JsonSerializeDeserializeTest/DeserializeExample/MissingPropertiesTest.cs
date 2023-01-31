using JsonSerializeDeserialize.DeserializeExample.DTO.MissingProperties;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JsonSerializeDeserializeTest.DeserializeExample;

public class MissingPropertiesTest
{
    [Test]
    public void Deserialize_PartialJsonString_ReturnsAnimal()
    {
        // the "Unexpected" key will be silently discarded
        const string json = """
            { "Name": "Pebbles", "Unexpected": "value" }
        """;

        var animal = JsonSerializer.Deserialize<Animal>(json);

        Assert.That(animal.Name, Is.EqualTo("Pebbles"));
        Assert.That(animal.Age, Is.EqualTo(0));
        Assert.That(animal.Weight, Is.EqualTo(36.3));
    }

    [Test]
    public void Deserialize_EmptyJsonString_ReturnsAnimal()
    {
        const string json = "{}";

        var animal = JsonSerializer.Deserialize<Animal>(json);

        Assert.That(animal.Name, Is.EqualTo(null));
        Assert.That(animal.Age, Is.EqualTo(0));
        Assert.That(animal.Weight, Is.EqualTo(36.3));
    }

    [Test]
    public void Serialize_EmptyAnimalObject_SerializesToExpectedJSONString()
    {
        var animal = new Animal();

        var actualJson = JsonSerializer.Serialize(animal);

        Assert.That(actualJson, Is.EqualTo(""""{"Name":null,"Age":0,"Weight":36.3}""""));
    }

    [Test]
    public void Serialize_PartialAnimalObject_SerializesToExpectedJSONString()
    {
        var animal = new Animal() { Weight = 99.9 , Age = 14 };

        var actualJson = JsonSerializer.Serialize(animal);

        Assert.That(actualJson, Is.EqualTo(""""{"Name":null,"Age":14,"Weight":99.9}""""));
    }
}
