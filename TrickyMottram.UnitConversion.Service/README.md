# TrickyMottram.UnitConversion.Service

The centralized orchestration service for the TrickyMottram Unit Conversion libraries.

This package provides a DI-ready service that coordinates multiple `IUnitConverter` implementations to handle dynamic unit conversion across all registered measurement domains (e.g., Length, Area, Temperature, etc.).

## ✨ Features

- Smart delegation of conversions to the appropriate `IUnitConverter`
- Dependency-injected service with support for runtime extensibility
- Minimal logic with single-responsibility orchestration
- Designed for ASP.NET Core and other .NET DI platforms

## 🔧 Usage Example

### Registering Converters and the Service

```csharp
services.AddSingleton<IUnitConverter, LengthConverter>();
services.AddSingleton<IUnitConverter, TemperatureConverter>();
services.AddSingleton<UnitConversionService>();
```

### Using the Service

```csharp
public class ConversionController : ControllerBase
{
    private readonly UnitConversionService _converter;

    public ConversionController(UnitConversionService converter)
    {
        _converter = converter;
    }

    [HttpGet]
    public IActionResult ConvertUnits(double value, string from, string to)
    {
        double result = _converter.Convert(value, from, to);
        return Ok(result);
    }
}
```

## 📚 Main Type

- `TrickyMottram.UnitConversion.Service.UnitConversionService`

## 📦 Package Metadata

- **Target Framework**: `.NET 8`
- **License**: MIT
- **Source**: [GitHub Repository](https://github.com/trickymottram/UnitConversion)
- **Tags**: `unit conversion`, `service`, `di`, `dotnet`

## ✅ Contributing

If you'd like to contribute improvements, logging features, or additional coordination logic, feel free to open a PR or raise an issue on the [GitHub repo](https://github.com/trickymottram/UnitConversion).

---

© Tricky Mottram