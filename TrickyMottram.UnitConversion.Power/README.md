# TrickyMottram.UnitConversion.Power

Power unit conversion implementation for the TrickyMottram Unit Conversion libraries.

This package provides an implementation of `IUnitConverter` and `IUnitRegistry` for converting between various power units including metric (watts, kilowatts), mechanical (horsepower), and energy-rate based units. It is part of the TrickyMottram.UnitConversion ecosystem.

## ✨ Features

- Supports units like milliwatt, watt, kilowatt, megawatt, gigawatt, horsepower, BTU/hr, calorie/sec
- Offers both string and strongly typed enum conversion methods
- Integrates easily with `UnitConversionService`
- Clean architecture, DI-ready, and logging enabled
- Unit registry support for UI binding and unit discovery

## 🔧 Usage Example

### Add to Dependency Injection

```csharp
services.AddSingleton<IUnitConverter, PowerConverter>();
services.AddSingleton<IUnitRegistry, PowerUnitRegistry>();
```

### Convert via UnitConversionService

```csharp
public class PowerController : ControllerBase
{
    private readonly UnitConversionService _service;

    public PowerController(UnitConversionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ConvertPower(double value, string from, string to)
    {
        var result = _service.Convert(value, from, to);
        return Ok(result);
    }
}
```

### Strongly Typed Conversion

```csharp
double megawatts = new PowerConverter(logger)
    .Convert(1_000_000, PowerUnit.Watt, PowerUnit.Megawatt); // 1.0
```

## 📚 Main Types

- `TrickyMottram.UnitConversion.Power.PowerConverter`
- `TrickyMottram.UnitConversion.Power.Registry.PowerUnitRegistry`
- `TrickyMottram.UnitConversion.Power.Enums.PowerUnit`
- `TrickyMottram.UnitConversion.Power.Extensions.PowerUnitExtensions`

## 📦 Package Metadata

- **Target Framework**: `.NET 8`
- **License**: MIT
- **Source**: [GitHub Repository](https://github.com/trickymottram/UnitConversion)
- **Tags**: `unit conversion`, `power`, `watt`, `horsepower`, `dotnet`

## ✅ Contributing

Contributions for additional power units or improvements are welcome via [GitHub Issues](https://github.com/trickymottram/UnitConversion/issues).

---

© Tricky Mottram