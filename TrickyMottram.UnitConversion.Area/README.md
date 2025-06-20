# TrickyMottram.UnitConversion.Area

Area unit conversion implementation for the TrickyMottram Unit Conversion libraries.

This package provides an implementation of `IUnitConverter` and `IUnitRegistry` for handling common area conversions including metric and imperial square units, acres, and hectares. It is part of the TrickyMottram.UnitConversion ecosystem.

## ✨ Features

- Converts between square millimeters, centimeters, meters, kilometers, inches, feet, yards, miles, acres, and hectares
- Supports both string-based and strongly typed enum-based APIs
- Fully compatible with the `UnitConversionService`
- Designed for testability, extensibility, and structured logging
- Provides a unit registry for easy UI population or discovery

## 🔧 Usage Example

### Add to Dependency Injection

```csharp
services.AddSingleton<IUnitConverter, AreaConverter>();
services.AddSingleton<IUnitRegistry, AreaUnitRegistry>();
```

### Convert via UnitConversionService

```csharp
public class AreaController : ControllerBase
{
    private readonly UnitConversionService _service;

    public AreaController(UnitConversionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ConvertArea(double value, string from, string to)
    {
        var result = _service.Convert(value, from, to);
        return Ok(result);
    }
}
```

### Strongly Typed Conversion

```csharp
double hectares = new AreaConverter(logger)
    .Convert(10000, AreaUnit.SquareMeter, AreaUnit.Hectare); // 1.0
```

## 📚 Main Types

- `TrickyMottram.UnitConversion.Area.AreaConverter`
- `TrickyMottram.UnitConversion.Area.Registry.AreaUnitRegistry`
- `TrickyMottram.UnitConversion.Area.Enums.AreaUnit`
- `TrickyMottram.UnitConversion.Area.Extensions.AreaUnitExtensions`

## 📦 Package Metadata

- **Target Framework**: `.NET 8`
- **License**: MIT
- **Source**: [GitHub Repository](https://github.com/trickymottram/UnitConversion)
- **Tags**: `unit conversion`, `area`, `square`, `hectare`, `acre`, `dotnet`

## ✅ Contributing

Suggestions and improvements for additional area units or edge case support are welcome via PR or [GitHub issues](https://github.com/trickymottram/UnitConversion).

---

© Tricky Mottram