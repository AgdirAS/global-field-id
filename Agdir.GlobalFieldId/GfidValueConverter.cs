using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Agdir.GlobalFieldId;

public class GfidValueConverter() : ValueConverter<Gfid, string>(v => v.ToString(),
	v => new Gfid(v));
