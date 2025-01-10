namespace Agdir.GlobalFieldId.Tests;

public class GfidValueConverterTests
{
	private readonly GfidValueConverter _converter = new();

	[Fact]
	public void ConvertToProvider_ValidGfid_ShouldConvertToString()
	{
		var gfid = new Gfid("ABCD.1234");
		var result = _converter.ConvertToProvider(gfid);
		Assert.Equal("ABCD.1234", result);
	}

	[Fact]
	public void ConvertFromProvider_ValidString_ShouldConvertToGfid()
	{
		var value = "ABCD.1234";
		var result = _converter.ConvertFromProvider(value);
		Assert.NotNull(result);
		Assert.Equal(value, result.ToString());
	}

	// [Theory]
	// [InlineData(null)]
	// [InlineData("")]
	// public void ConvertFromProvider_InvalidString_ShouldThrowArgumentNullException(string value)
	// {
	// 	Assert.Throws<ArgumentNullException>(() => _converter.ConvertFromProvider(value));
	// }

	[Theory]
	[InlineData("INVALID")]
	[InlineData("ABC.123")]
	public void ConvertFromProvider_InvalidFormat_ShouldThrowArgumentException(string value)
	{
		Assert.Throws<ArgumentException>(() => _converter.ConvertFromProvider(value));
	}
}