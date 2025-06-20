using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Area.Enums;
using TrickyMottram.UnitConversion.Area.Extensions;

namespace TrickyMottram.UnitConversion.Area
{
    /// <summary>
    /// Provides functionality to convert between various area units.
    /// </summary>
    public class AreaConverter : IUnitConverter
    {
        private readonly ILogger<AreaConverter> _logger;

        private readonly Dictionary<string, double> _toSquareMeters = new(StringComparer.OrdinalIgnoreCase)
        {
            ["mm2"] = 1e-6,
            ["cm2"] = 1e-4,
            ["m2"] = 1.0,
            ["km2"] = 1_000_000.0,
            ["in2"] = 0.00064516,
            ["ft2"] = 0.09290304,
            ["yd2"] = 0.83612736,
            ["mi2"] = 2_589_988.110336,
            ["acre"] = 4046.8564224,
            ["hectare"] = 10000.0
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaConverter"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public AreaConverter(ILogger<AreaConverter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Determines whether the converter can convert between the specified units.
        /// </summary>
        /// <param name="fromUnit">The source unit symbol (e.g. "m2").</param>
        /// <param name="toUnit">The target unit symbol (e.g. "ft2").</param>
        /// <returns><c>true</c> if conversion is supported; otherwise, <c>false</c>.</returns>
        public bool CanConvert(string fromUnit, string toUnit)
        {
            return _toSquareMeters.ContainsKey(fromUnit) && _toSquareMeters.ContainsKey(toUnit);
        }
        /// <summary>
        /// Converts the specified value from one area unit to another using strongly typed enums.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <param name="from">The source <see cref="AreaUnit"/>.</param>
        /// <param name="to">The target <see cref="AreaUnit"/>.</param>
        /// <returns>The converted value in the target unit.</returns>
        public double Convert(double value, AreaUnit from, AreaUnit to)
        {
            return Convert(value, from.ToSymbol(), to.ToSymbol());
        }

        /// <summary>
        /// Converts the specified value from one area unit to another using string unit symbols.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <param name="fromUnit">The source unit symbol (e.g. "m2").</param>
        /// <param name="toUnit">The target unit symbol (e.g. "ft2").</param>
        /// <returns>The converted value in the target unit.</returns>
        /// <exception cref="ArgumentException">Thrown when either unit is unsupported.</exception>
        public double Convert(double value, string fromUnit, string toUnit)
        {
            _logger.LogInformation("Converting {Value} from {FromUnit} to {ToUnit}", value, fromUnit, toUnit);

            if (!CanConvert(fromUnit, toUnit))
            {
                _logger.LogError("Unsupported area units: {FromUnit} -> {ToUnit}", fromUnit, toUnit);
                throw new ArgumentException("Unsupported area units.");
            }

            double valueInSquareMeters = value * _toSquareMeters[fromUnit];
            double result = valueInSquareMeters / _toSquareMeters[toUnit];

            _logger.LogInformation("Converted result: {Result}", result);
            return result;
        }
    }
}
