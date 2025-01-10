using System.Text.Json;

namespace Agdir.GlobalFieldId.Tests;

public class GfidJsonConverterTests
{
	private readonly GfidJsonConverter _converter = new();
	private readonly JsonSerializerOptions _options = new();

	[Fact]
	public void Serialize_ValidGfid_ShouldSerializeToJson()
	{
		var gfid = new Gfid("ABCD.1234");
		var json = JsonSerializer.Serialize(gfid, _options);
		Assert.Equal("\"ABCD.1234\"", json);
	}

	[Fact]
	public void Deserialize_ValidJson_ShouldDeserializeToGfid()
	{
		var json = "\"ABCD.1234\"";
		var gfid = JsonSerializer.Deserialize<Gfid>(json, _options);
		Assert.NotNull(gfid);
		Assert.Equal("ABCD.1234", gfid.ToString());
	}

	// [Fact]
	// public void Deserialize_NullJson_ShouldThrowJsonException()
	// {
		// var json = "null";
		// Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<Gfid>(json, _options));
	// }
}
