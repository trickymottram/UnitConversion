using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Length.Enums;
using TrickyMottram.UnitConversion.Length.Extensions;

namespace TrickyMottram.UnitConversion.Length
{
    /// <summary>
    /// Provides functionality to convert between various length units.
    /// </summary>
    public class LengthConverter : IUnitConverter
    {
        private readonly ILogger<LengthConverter> _logger;

        private readonly Dictionary<string, double> _toMeters = new(StringComparer.OrdinalIgnoreCase)
        {
            ["mm"] = 0.001,
            ["cm"] = 0.01,
            ["m"] = 1.0,
            ["km"] = 1000.0,
            ["in"] = 0.0254,
            ["ft"] = 0.3048,
            ["yd"] = 0.9144,
            ["mi"] = 1609.344,
            ["nm"] = 1852.0,
            ["mil"] = 0.0000254
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="LengthConverter"/> class.
        /// </summary>
        /// <param name="logger">The logger instance used for diagnostic logging.</param>
        public LengthConverter(ILogger<LengthConverter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Determines whether the converter supports conversion between the specified units.
        /// </summary>
        /// <param name="fromUnit">The source unit symbol (e.g., "m").</param>
        /// <param name="toUnit">The target unit symbol (e.g., "ft").</param>
        /// <returns><c>true</c> if both units are supported; otherwise, <c>false</c>.</returns>
        public bool CanConvert(string fromUnit, string toUnit)
        {
            return _toMeters.ContainsKey(fromUnit) && _toMeters.ContainsKey(toUnit);
        }

        /// <summary>
        /// Converts a value between two length units using strongly typed enums.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <param name="from">The source <see cref="LengthUnit"/>.</param>
        /// <param name="to">The target <see cref="LengthUnit"/>.</param>
        /// <returns>The converted value in the target unit.</returns>
        public double Convert(double value, LengthUnit from, LengthUnit to)
        {
            return Convert(value, from.ToSymbol(), to.ToSymbol());
        }

        /// <summary>
        /// Converts a value between two length units using string unit symbols.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <param name="fromUnit">The source unit symbol (e.g., "m").</param>
        /// <param name="toUnit">The target unit symbol (e.g., "ft").</param>
        /// <returns>The converted value in the target unit.</returns>
        /// <exception cref="ArgumentException">Thrown when either unit is not supported.</exception>
        public double Convert(double value, string fromUnit, string toUnit)
        {
            _logger.LogInformation("Converting {Value} from {FromUnit} to {ToUnit}", value, fromUnit, toUnit);

            if (!CanConvert(fromUnit, toUnit))
            {
                _logger.LogError("Unsupported units: {FromUnit} -> {ToUnit}", fromUnit, toUnit);
                throw new ArgumentException("Unsupported length units.");
            }

            double valueInMeters = value * _toMeters[fromUnit];
            double result = valueInMeters / _toMeters[toUnit];

            _logger.LogInformation("Converted result: {Result}", result);
            return result;
        }
    }
}
