# TrickyMottram.UnitConversion.Length

Length unit conversion implementation for the TrickyMottram Unit Conversion libraries.

This package provides an implementation of `IUnitConverter` and `IUnitRegistry` for handling common length and distance conversions using metric, imperial, and nautical units. It is part of the TrickyMottram.UnitConversion ecosystem.

## ✨ Features

- Converts between all common length units (e.g. millimeter, inch, foot, mile, nautical mile)
- Supports both string-based and strongly typed enum-based APIs
- Fully compatible with the `UnitConversionService`
- Designed for testability, extensibility, and structured logging
- Provides a unit registry for easy UI population or discovery

## 🔧 Usage Example

### Add to Dependency Injection

```csharp
services.AddSingleton<IUnitConverter, LengthConverter>();
services.AddSingleton<IUnitRegistry, LengthUnitRegistry>();
```

### Convert via UnitConversionService

```csharp
public class LengthController : ControllerBase
{
    private readonly UnitConversionService _service;

    public LengthController(UnitConversionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ConvertLength(double value, string from, string to)
    {
        var result = _service.Convert(value, from, to);
        return Ok(result);
    }
}
```

### Strongly Typed Conversion

```csharp
double km = new LengthConverter(logger)
    .Convert(1000, LengthUnit.Meter, LengthUnit.Kilometer); // 1.0
```

## 📚 Main Types

- `TrickyMottram.UnitConversion.Length.LengthConverter`
- `TrickyMottram.UnitConversion.Length.Registry.LengthUnitRegistry`
- `TrickyMottram.UnitConversion.Length.Enums.LengthUnit`
- `TrickyMottram.UnitConversion.Length.Extensions.LengthUnitExtensions`

## 📦 Package Metadata

- **Target Framework**: `.NET 8`
- **License**: MIT
- **Source**: [GitHub Repository](https://github.com/trickymottram/UnitConversion)
- **Tags**: `unit conversion`, `length`, `measurement`, `dotnet`

## ✅ Contributing

Suggestions and improvements for additional length units, precision handling, or international standards are welcome via PR or [GitHub issues](https://github.com/trickymottram/UnitConversion).

---

© Tricky Mottram