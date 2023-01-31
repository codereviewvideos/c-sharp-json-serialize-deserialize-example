using System.Text.Json;
using JsonSerializeDeserialize.DeserializeExample.DTO.CustomPropertyOrder;

namespace JsonSerializeDeserializeTest.DeserializeExample;

public class CustomPropertyOrderTest
{
    [Test]
    public void Deserialize_UnorderedJsonStringKeys_ReturnsExpectedAlphabetObject()
    {
        const string json = """
            { "C": "this is C", "B": "B is here", "A": "hello from A" }
        """;

        var alphabet = JsonSerializer.Deserialize<Alphabet>(json);

        Assert.That(alphabet.A, Is.EqualTo("hello from A"));
        Assert.That(alphabet.B, Is.EqualTo("B is here"));
        Assert.That(alphabet.C, Is.EqualTo("this is C"));
    }

    [Test]
    public void Serialize_ValidAlphabetObject_SerializesToExpectedDefaultOrderedJSONString()
    {
        var alphabet = new Alphabet { A = "hello from A", B = "B is here also", C = "USB C"};

        const string expectedJson = "{\"A\":\"hello from A\",\"B\":\"B is here also\",\"C\":\"USB C\"}";

        var actualJson = JsonSerializer.Serialize(alphabet);

        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }

    [Test]
    public void Deserialize_UnorderedJsonStringKeys_ReturnsExpectedAlphabodgeObject()
    {
        const string json = """
            { "C": "this is C", "B": "B is here", "A": "hello from A" }
        """;

        var alphabodge = JsonSerializer.Deserialize<Alphabodge>(json);

        Assert.That(alphabodge.A, Is.EqualTo("hello from A"));
        Assert.That(alphabodge.B, Is.EqualTo("B is here"));
        Assert.That(alphabodge.C, Is.EqualTo("this is C"));
    }

    [Test]
    public void Serialize_ValidAlphabodgeObject_SerializesToExpectedDefaultOrderedJSONString()
    {
        var alphabodge = new Alphabodge { A = "hello from A", B = "B is here also", C = "USB C"};

        const string expectedJson = "{\"B\":\"B is here also\",\"C\":\"USB C\",\"A\":\"hello from A\"}";

        var actualJson = JsonSerializer.Serialize(alphabodge);

        Assert.That(actualJson, Is.EqualTo(expectedJson));
    }
}
