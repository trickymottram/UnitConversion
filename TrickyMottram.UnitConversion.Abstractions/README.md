# TrickyMottram.UnitConversion.Abstractions

Interfaces and foundational contracts for the TrickyMottram Unit Conversion libraries.

This package defines the core abstractions used by the TrickyMottram UnitConversion ecosystem, enabling consistent and extensible unit conversion handling across different measurement domains such as Length, Area, Temperature, Power, Time, and Weight.

## ✨ Features

- `IUnitConverter` – standard interface for implementing unit converters
- `IUnitRegistry` – interface for exposing unit categories and symbols for UI binding or documentation
- Consistent API surface for both string-based and strongly typed enum-based conversions
- Supports a hybrid string/enum system to balance flexibility with type safety
- Designed for dependency injection and testability

## 🔧 Usage Example

### Implementing a Custom Converter

```csharp
public class MyLengthConverter : IUnitConverter
{
    public bool CanConvert(string fromUnit, string toUnit) =>
        fromUnit == "m" && toUnit == "cm";

    public double Convert(double value, string fromUnit, string toUnit) =>
        value * 100;
}
```

### Using in an Application

```csharp
services.AddSingleton<IUnitConverter, MyLengthConverter>();
services.AddSingleton<UnitConversionService>();
```

```csharp
public class MyController : ControllerBase
{
    private readonly UnitConversionService _service;

    public MyController(UnitConversionService service)
    {
        _service = service;
    }

    public IActionResult ConvertToCm(double meters)
    {
        var result = _service.Convert(meters, "m", "cm");
        return Ok(result);
    }
}
```

## 📚 Main Interfaces

- `TrickyMottram.UnitConversion.Abstractions.Interfaces.IUnitConverter`
- `TrickyMottram.UnitConversion.Abstractions.Interfaces.IUnitRegistry`

## 📦 Package Metadata

- **Target Framework**: `.NET 8`
- **License**: MIT
- **Source**: [GitHub Repository](https://github.com/trickymottram/UnitConversion)
- **Tags**: `unit conversion`, `abstractions`, `interfaces`

## ✅ Contributing

You’re welcome to contribute converters, registries, or improvements. Please raise an issue or submit a PR on the [GitHub repo](https://github.com/trickymottram/UnitConversion).

---

© Tricky Mottram