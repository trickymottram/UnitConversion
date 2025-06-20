# TrickyMottram.UnitConversion.Weight

Weight unit conversion implementation for the TrickyMottram Unit Conversion libraries.

This package provides an implementation of `IUnitConverter` and `IUnitRegistry` for converting between metric and imperial weight units. It is part of the TrickyMottram.UnitConversion ecosystem.

## ✨ Features

- Supports a wide range of units including milligram, kilogram, ton, ounce, pound, stone, and hundredweight
- Enum and string-based conversion APIs
- Works seamlessly with `UnitConversionService`
- Dependency-injection friendly design with Microsoft.Extensions.Logging support
- Provides unit discovery through a registry for UI binding

## 🔧 Usage Example

### Add to Dependency Injection

```csharp
services.AddSingleton<IUnitConverter, WeightConverter>();
services.AddSingleton<IUnitRegistry, WeightUnitRegistry>();
```

### Convert via UnitConversionService

```csharp
public class WeightController : ControllerBase
{
    private readonly UnitConversionService _service;

    public WeightController(UnitConversionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ConvertWeight(double value, string from, string to)
    {
        var result = _service.Convert(value, from, to);
        return Ok(result);
    }
}
```

### Strongly Typed Conversion

```csharp
double pounds = new WeightConverter(logger)
    .Convert(1.0, WeightUnit.Kilogram, WeightUnit.Pound); // ~2.20462
```

## 📚 Main Types

- `TrickyMottram.UnitConversion.Weight.WeightConverter`
- `TrickyMottram.UnitConversion.Weight.Registry.WeightUnitRegistry`
- `TrickyMottram.UnitConversion.Weight.Enums.WeightUnit`
- `TrickyMottram.UnitConversion.Weight.Extensions.WeightUnitExtensions`

## 📦 Package Metadata

- **Target Framework**: `.NET 8`
- **License**: MIT
- **Source**: [GitHub Repository](https://github.com/trickymottram/UnitConversion)
- **Tags**: `unit conversion`, `weight`, `mass`, `measurement`, `dotnet`

## ✅ Contributing

Suggestions for additional units or formatting improvements are welcome via [GitHub Issues](https://github.com/trickymottram/UnitConversion/issues) or pull requests.

---

© Tricky Mottram