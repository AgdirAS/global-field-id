using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Agdir.GlobalFieldId;

[JsonConverter(typeof(GfidJsonConverter))]
public class Gfid : IEquatable<Gfid>
{
	private static readonly Regex ValidFormat = new("^[A-HJ-NP-Z0-9]{4}\\.[A-HJ-NP-Z0-9]{4}$");
	private readonly string value;

	public Gfid(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			throw new ArgumentNullException(nameof(value));
		}

		if (!ValidFormat.IsMatch(value))
		{
			throw new ArgumentException("Invalid Gfid format. Must be [A-HJ-NP-Z0-9]{4}.[A-HJ-NP-Z0-9]{4} excluding I and O.");
		}

		this.value = value;
	}

	public bool Equals(Gfid? other)
	{
		if (other is null)
		{
			return false;
		}

		return value == other.value;
	}

	public override string ToString()
	{
		return value;
	}

	public override bool Equals(object? obj)
	{
		return obj is Gfid other && Equals(other);
	}

	public override int GetHashCode()
	{
		return value.GetHashCode();
	}

	public static bool operator ==(Gfid left, Gfid right)
	{
		if (left is null)
		{
			return right is null;
		}

		return left.Equals(right);
	}

	public static bool operator !=(Gfid left, Gfid right)
	{
		return !(left == right);
	}
}
