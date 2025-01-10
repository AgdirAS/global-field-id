# Agdir.GlobalFieldId

.NET support for GlobalFieldId™ - a human-friendly, case-insensitive identifier format. GlobalFieldId™ is a trademark of
Varda AG.

## Installation

```bash
dotnet add package Agdir.GlobalFieldId
```

## Usage

```csharp
using Agdir.GlobalFieldId;

// Create from valid string
var id = new Gfid("ABCD.1234");

// Throws ArgumentException for invalid format
var invalid = new Gfid("IO1A.1234"); // Invalid: contains 'I'

// Serializes to string
using System.Text.Json;
var json = JsonSerializer.Serialize(id); // "ABCD.1234"
```

## Entity Framework Core Support

To use Gfid with EF Core, add a value converter in your DbContext:

```csharp
protected override void ConfigureConventions(ModelConfigurationBuilder builder)
{
    builder.Properties<Gfid>()
           .HaveConversion<GfidValueConverter>();
}
```

For JSON owned collections:

```csharp
builder.OwnsMany(x => x.Fields)
    .ToJson()
    .Property(x => x.FieldId)
    .HasConversion(
        v => v.ToString(),
        v => new Gfid(v));
```

## Format

- `[A-Z0-9]{4}.[A-Z0-9]{4}`
- Only capital letters and numbers
- Letters I and O are never used to avoid confusion with numbers
- Dot separator