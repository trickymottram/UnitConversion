# TrickyMottram.UnitConversion.Time

Time unit conversion implementation for the TrickyMottram Unit Conversion libraries.

This package provides an implementation of `IUnitConverter` and `IUnitRegistry` for converting between a wide range of time units including nanoseconds, seconds, days, and years. It is part of the TrickyMottram.UnitConversion ecosystem.

## ✨ Features

- Supports nanoseconds, microseconds, milliseconds, seconds, minutes, hours, days, weeks, months, and years
- Supports both string-based and strongly typed enum-based conversion methods
- Integrates with the `UnitConversionService` orchestration layer
- Fully compatible with dependency injection and Microsoft.Extensions.Logging
- Includes a unit registry for enumeration and UI binding

## 🔧 Usage Example

### Add to Dependency Injection

```csharp
services.AddSingleton<IUnitConverter, TimeConverter>();
services.AddSingleton<IUnitRegistry, TimeUnitRegistry>();
```

### Convert via UnitConversionService

```csharp
public class TimeController : ControllerBase
{
    private readonly UnitConversionService _service;

    public TimeController(UnitConversionService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult ConvertTime(double value, string from, string to)
    {
        var result = _service.Convert(value, from, to);
        return Ok(result);
    }
}
```

### Strongly Typed Conversion

```csharp
double minutes = new TimeConverter(logger)
    .Convert(3600, TimeUnit.Second, TimeUnit.Minute); // 60.0
```

## 📚 Main Types

- `TrickyMottram.UnitConversion.Time.TimeConverter`
- `TrickyMottram.UnitConversion.Time.Registry.TimeUnitRegistry`
- `TrickyMottram.UnitConversion.Time.Enums.TimeUnit`
- `TrickyMottram.UnitConversion.Time.Extensions.TimeUnitExtensions`

## 📦 Package Metadata

- **Target Framework**: `.NET 8`
- **License**: MIT
- **Source**: [GitHub Repository](https://github.com/trickymottram/UnitConversion)
- **Tags**: `unit conversion`, `time`, `duration`, `datetime`, `dotnet`

## ✅ Contributing

Suggestions and PRs for expanding time unit support or improving conversions are welcome at [GitHub Issues](https://github.com/trickymottram/UnitConversion).

---

© Tricky Mottram