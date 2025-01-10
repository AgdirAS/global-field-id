namespace Agdir.GlobalFieldId.Tests;

public class GfidTests
{
	[Fact]
	public void Constructor_WithValidGfid_ShouldCreateInstance()
	{
		var gfid = new Gfid("ABCD.1234");
		Assert.NotNull(gfid);
		Assert.Equal("ABCD.1234", gfid.ToString());
	}

	[Theory]
	[InlineData(null)]
	[InlineData("")]
	public void Constructor_WithNullOrEmpty_ShouldThrowArgumentNullException(string value)
	{
		Assert.Throws<ArgumentNullException>(() => new Gfid(value));
	}

	[Theory]
	[InlineData("ABC.1234")]
	[InlineData("ABCDE.1234")]
	[InlineData("ABCD.123")]
	[InlineData("ABCD.12345")]
	[InlineData("ABCD1234")]
	[InlineData("IIII.1234")]
	[InlineData("OOOO.1234")]
	[InlineData("abcd.1234")]
	public void Constructor_WithInvalidFormat_ShouldThrowArgumentException(string value)
	{
		Assert.Throws<ArgumentException>(() => new Gfid(value));
	}

	[Fact]
	public void Equals_WithSameValue_ShouldReturnTrue()
	{
		var gfid1 = new Gfid("ABCD.1234");
		var gfid2 = new Gfid("ABCD.1234");
		Assert.True(gfid1.Equals(gfid2));
		Assert.True(gfid1 == gfid2);
	}

	[Fact]
	public void Equals_WithDifferentValue_ShouldReturnFalse()
	{
		var gfid1 = new Gfid("ABCD.1234");
		var gfid2 = new Gfid("EFGH.5678");
		Assert.False(gfid1.Equals(gfid2));
		Assert.True(gfid1 != gfid2);
	}

	[Fact]
	public void Equals_WithNull_ShouldReturnFalse()
	{
		var gfid = new Gfid("ABCD.1234");
		Assert.False(gfid.Equals(null));
		Assert.NotNull(gfid);
		Assert.NotNull(gfid);
	}

	[Fact]
	public void GetHashCode_SameValue_ShouldReturnSameHashCode()
	{
		var gfid1 = new Gfid("ABCD.1234");
		var gfid2 = new Gfid("ABCD.1234");
		Assert.Equal(gfid1.GetHashCode(), gfid2.GetHashCode());
	}
}