using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Weight.Enums;
using TrickyMottram.UnitConversion.Weight.Extensions;

namespace TrickyMottram.UnitConversion.Weight
{
    /// <summary>
    /// A unit converter for weight and mass units.
    /// </summary>
    public class WeightConverter : IUnitConverter
    {
        private readonly ILogger<WeightConverter> _logger;

        private readonly Dictionary<string, double> _toKilograms = new(StringComparer.OrdinalIgnoreCase)
        {
            ["mg"] = 1e-6,
            ["g"] = 0.001,
            ["kg"] = 1.0,
            ["t"] = 1000.0,
            ["oz"] = 0.0283495231,
            ["lb"] = 0.45359237,
            ["st"] = 6.35029318,
            ["cwt"] = 50.80234544,
            ["ton"] = 907.18474,
            ["us_ton"] = 907.18474,
            ["uk_ton"] = 1016.0469088
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="WeightConverter"/> class.
        /// </summary>
        /// <param name="logger">The logger instance for diagnostics.</param>
        public WeightConverter(ILogger<WeightConverter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Checks whether a conversion between two unit symbols is supported.
        /// </summary>
        /// <param name="fromUnit">The source unit symbol.</param>
        /// <param name="toUnit">The target unit symbol.</param>
        /// <returns><c>true</c> if both units are supported; otherwise, <c>false</c>.</returns>
        public bool CanConvert(string fromUnit, string toUnit)
        {
            return _toKilograms.ContainsKey(fromUnit) && _toKilograms.ContainsKey(toUnit);
        }

        /// <summary>
        /// Converts a value from one strongly typed <see cref="WeightUnit"/> to another.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <param name="from">The source unit.</param>
        /// <param name="to">The target unit.</param>
        /// <returns>The converted value in the target unit.</returns>
        public double Convert(double value, WeightUnit from, WeightUnit to)
        {
            return Convert(value, from.ToSymbol(), to.ToSymbol());
        }

        /// <summary>
        /// Converts a value between two weight units represented by string symbols.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="fromUnit">The unit symbol to convert from.</param>
        /// <param name="toUnit">The unit symbol to convert to.</param>
        /// <returns>The converted value.</returns>
        /// <exception cref="ArgumentException">Thrown when the conversion is not supported.</exception>
        public double Convert(double value, string fromUnit, string toUnit)
        {
            _logger.LogInformation("Converting {Value} from {FromUnit} to {ToUnit}", value, fromUnit, toUnit);

            if (!CanConvert(fromUnit, toUnit))
            {
                _logger.LogError("Unsupported units: {FromUnit} -> {ToUnit}", fromUnit, toUnit);
                throw new ArgumentException("Unsupported weight units.");
            }

            double valueInKg = value * _toKilograms[fromUnit];
            double result = valueInKg / _toKilograms[toUnit];

            _logger.LogInformation("Converted result: {Result}", result);
            return result;
        }
    }
}
