using System.Text.Json;
using System.Text.Json.Serialization;

namespace Agdir.GlobalFieldId;

public class GfidJsonConverter : JsonConverter<Gfid>
{
	public override Gfid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return new Gfid(reader.GetString() ?? throw new JsonException("Gfid cannot be null"));
	}

	public override void Write(Utf8JsonWriter writer, Gfid value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToString());
	}
}
