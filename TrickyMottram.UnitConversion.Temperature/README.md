# TrickyMottram.UnitConversion.Temperature

Temperature unit conversion implementation for the TrickyMottram Unit Conversion libraries.

This package provides an implementation of `IUnitConverter` and `IUnitRegistry` for converting between common temperature scales such as Celsius, Fahrenheit, Kelvin, and more. It is part of the TrickyMottram.UnitConversion ecosystem.

## ✨ Features

- Supports all major temperature units: Celsius, Fahrenheit, Kelvin, Rankine, Reaumur
- Includes both strongly typed and symbol-based APIs
- Compatible with the centralized `UnitConversionService`
- Designed for clean architecture and dependency injection
- Full logging support with Microsoft.Extensions.Logging

## 🔧 Usage Example

### Add to Dependency Injection

```csharp
services.AddSingleton<IUnitConverter, TemperatureConverter>();
services.AddSingleton<IUnitRegistry, TemperatureUnitRegistry>();
```

### Convert via UnitConversionService

```csharp
public class TemperatureController : ControllerBase
{
    private readonly UnitConversionService _service;

    public TemperatureController(UnitConversionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ConvertTemperature(double value, string from, string to)
    {
        var result = _service.Convert(value, from, to);
        return Ok(result);
    }
}
```

### Strongly Typed Conversion

```csharp
double fahrenheit = new TemperatureConverter(logger)
    .Convert(100.0, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit); // 212.0
```

## 📚 Main Types

- `TrickyMottram.UnitConversion.Temperature.TemperatureConverter`
- `TrickyMottram.UnitConversion.Temperature.Registry.TemperatureUnitRegistry`
- `TrickyMottram.UnitConversion.Temperature.Enums.TemperatureUnit`
- `TrickyMottram.UnitConversion.Temperature.Extensions.TemperatureUnitExtensions`

## 📦 Package Metadata

- **Target Framework**: `.NET 8`
- **License**: MIT
- **Source**: [GitHub Repository](https://github.com/trickymottram/UnitConversion)
- **Tags**: `unit conversion`, `temperature`, `celsius`, `fahrenheit`, `kelvin`, `dotnet`

## ✅ Contributing

Contributions for additional temperature units or features are welcome through [GitHub Issues](https://github.com/trickymottram/UnitConversion/issues) or PRs.

---

© Tricky Mottram