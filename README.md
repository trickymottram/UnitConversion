# TrickyMottram.UnitConversion

A modular and extensible unit conversion library suite for .NET 8.  
Each package supports a specific category (e.g., weight, length, temperature), following clean architecture principles, full DI support, and strong testability.

## 📦 Packages

| Package | Description |
|--------|-------------|
| `TrickyMottram.UnitConversion.Abstractions` | Interfaces and shared contracts |
| `TrickyMottram.UnitConversion.Service` | Central conversion service that delegates to individual converters |
| `TrickyMottram.UnitConversion.Length` | Length unit conversions (e.g., m, ft, in, km) |
| `TrickyMottram.UnitConversion.Weight` | Weight conversions (e.g., kg, lb, oz, ton) |
| `TrickyMottram.UnitConversion.Temperature` | Temperature conversions (C, F, K, etc.) |
| `TrickyMottram.UnitConversion.Area` | Area conversions (m², ft², acre, hectare, etc.) |
| `TrickyMottram.UnitConversion.Power` | Power conversions (watt, kW, hp, BTU/hr, etc.) |
| `TrickyMottram.UnitConversion.Time` | Time conversions (sec, min, hr, day, etc.) |

## 🧠 Features

- Strongly-typed enum-based and flexible string-based APIs
- Supports structured logging via `Microsoft.Extensions.Logging`
- Built with dependency injection in mind
- Clean architecture and SOLID principles
- Includes `IUnitRegistry` for UI-friendly listing of units

## 🔧 Example Usage

### Register Services (e.g., in ASP.NET Core)

```csharp
services.AddSingleton<IUnitConverter, LengthConverter>();
services.AddSingleton<IUnitConverter, WeightConverter>();
services.AddSingleton<IUnitConverter, TemperatureConverter>();
services.AddSingleton<IUnitRegistry, LengthUnitRegistry>();
services.AddSingleton<IUnitRegistry, WeightUnitRegistry>();
services.AddSingleton<UnitConversionService>();
```

### Perform a Conversion

```csharp
var service = provider.GetRequiredService<UnitConversionService>();

double inches = service.Convert(1.0, "m", "in"); // 39.3701
```

### Strongly Typed

```csharp
double miles = new LengthConverter(logger)
    .Convert(1609.344, LengthUnit.Meter, LengthUnit.Mile); // 1.0
```

## 📚 Architecture

- Each domain lives in its own NuGet-packaged project (Length, Weight, etc.)
- Shared contracts live in `Abstractions`
- `UnitConversionService` coordinates conversions between multiple registered converters

## 🧪 Testing

- Full xUnit test coverage for all converters and edge cases
- AAA pattern (Arrange-Act-Assert)
- Typed and string test coverage for each converter

## ✅ Roadmap

Planned upcoming packages:
- Volume
- Pressure
- Energy
- Currency (if justified)
- Engineering-specific: Torque, Force, Frequency

## 📦 NuGet

Packages are available via NuGet. Add references via CLI or Package Manager UI.

## 🔗 Repository

https://github.com/trickymottram/UnitConversion

---

© Tricky Mottram