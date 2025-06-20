using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Temperature.Enums;
using TrickyMottram.UnitConversion.Temperature.Extensions;

namespace TrickyMottram.UnitConversion.Temperature
{
    /// <summary>
    /// Provides functionality to convert between various temperature units.
    /// </summary>
    public class TemperatureConverter : IUnitConverter
    {
        private readonly ILogger<TemperatureConverter> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TemperatureConverter"/> class.
        /// </summary>
        /// <param name="logger">Logger instance for diagnostic logging.</param>
        public TemperatureConverter(ILogger<TemperatureConverter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Determines whether the converter supports the given unit strings.
        /// </summary>
        /// <param name="fromUnit">The source temperature unit symbol.</param>
        /// <param name="toUnit">The target temperature unit symbol.</param>
        /// <returns><c>true</c> if both units are supported; otherwise, <c>false</c>.</returns>
        public bool CanConvert(string fromUnit, string toUnit)
        {
            return IsSupported(fromUnit) && IsSupported(toUnit);
        }

        /// <summary>
        /// Converts a temperature value between strongly-typed <see cref="TemperatureUnit"/> enums.
        /// </summary>
        /// <param name="value">The numeric temperature value.</param>
        /// <param name="from">The source temperature unit.</param>
        /// <param name="to">The target temperature unit.</param>
        /// <returns>The converted temperature value.</returns>
        public double Convert(double value, TemperatureUnit from, TemperatureUnit to)
        {
            return Convert(value, from.ToSymbol(), to.ToSymbol());
        }

        /// <summary>
        /// Converts a temperature value from one unit to another using string representations.
        /// </summary>
        /// <param name="value">The numeric temperature value.</param>
        /// <param name="fromUnit">The source unit symbol (e.g., "C", "F").</param>
        /// <param name="toUnit">The destination unit symbol (e.g., "K", "Re").</param>
        /// <returns>The converted temperature value.</returns>
        /// <exception cref="ArgumentException">Thrown when either unit is not supported.</exception>
        public double Convert(double value, string fromUnit, string toUnit)
        {
            _logger.LogInformation("Converting {Value} from {FromUnit} to {ToUnit}", value, fromUnit, toUnit);

            if (!CanConvert(fromUnit, toUnit))
            {
                _logger.LogError("Unsupported temperature units: {FromUnit} -> {ToUnit}", fromUnit, toUnit);
                throw new ArgumentException("Unsupported temperature units.");
            }

            // Convert to Celsius
            double celsius = fromUnit.ToLower() switch
            {
                "c" or "celsius" => value,
                "f" or "fahrenheit" => (value - 32) * 5 / 9,
                "k" or "kelvin" => value - 273.15,
                "r" or "rankine" => (value - 491.67) * 5 / 9,
                "re" or "reaumur" => value * 1.25,
                _ => throw new ArgumentException("Invalid fromUnit")
            };

            // Convert from Celsius
            double result = toUnit.ToLower() switch
            {
                "c" or "celsius" => celsius,
                "f" or "fahrenheit" => (celsius * 9 / 5) + 32,
                "k" or "kelvin" => celsius + 273.15,
                "r" or "rankine" => (celsius + 273.15) * 9 / 5,
                "re" or "reaumur" => celsius * 0.8,
                _ => throw new ArgumentException("Invalid toUnit")
            };

            _logger.LogInformation("Converted result: {Result}", result);
            return result;
        }

        /// <summary>
        /// Checks if a unit symbol is supported for temperature conversion.
        /// </summary>
        /// <param name="unit">The temperature unit symbol.</param>
        /// <returns><c>true</c> if the unit is supported; otherwise, <c>false</c>.</returns>
        private bool IsSupported(string unit)
        {
            string u = unit.ToLower();
            return u is "c" or "celsius" or
                        "f" or "fahrenheit" or
                        "k" or "kelvin" or
                        "r" or "rankine" or
                        "re" or "reaumur";
        }
    }
}
