using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Power.Enums;
using TrickyMottram.UnitConversion.Power.Extensions;

namespace TrickyMottram.UnitConversion.Power
{
    /// <summary>
    /// Provides functionality to convert between various power units.
    /// </summary>
    public class PowerConverter : IUnitConverter
    {
        private readonly ILogger<PowerConverter> _logger;

        private readonly Dictionary<string, double> _toWatts = new(StringComparer.OrdinalIgnoreCase)
        {
            ["mw"] = 0.001,
            ["w"] = 1.0,
            ["kw"] = 1000.0,
            ["mwatt"] = 1_000_000.0,
            ["gw"] = 1_000_000_000.0,
            ["hp"] = 745.699872,
            ["btu/hr"] = 0.29307107,
            ["cal/s"] = 4.1868
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerConverter"/> class.
        /// </summary>
        /// <param name="logger">Logger instance for diagnostic output.</param>
        public PowerConverter(ILogger<PowerConverter> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Determines if conversion between two unit symbols is supported.
        /// </summary>
        /// <param name="fromUnit">The source power unit symbol (e.g., "kw").</param>
        /// <param name="toUnit">The target power unit symbol (e.g., "hp").</param>
        /// <returns><c>true</c> if both units are supported; otherwise, <c>false</c>.</returns>
        public bool CanConvert(string fromUnit, string toUnit)
        {
            return _toWatts.ContainsKey(fromUnit) && _toWatts.ContainsKey(toUnit);
        }

        /// <summary>
        /// Converts a power value using strongly typed <see cref="PowerUnit"/> enums.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="from">The source unit.</param>
        /// <param name="to">The target unit.</param>
        /// <returns>The converted value in the target unit.</returns>
        public double Convert(double value, PowerUnit from, PowerUnit to)
        {
            return Convert(value, from.ToSymbol(), to.ToSymbol());
        }

        /// <summary>
        /// Converts a power value between two string-based unit symbols.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="fromUnit">The source unit symbol.</param>
        /// <param name="toUnit">The target unit symbol.</param>
        /// <returns>The converted value in the target unit.</returns>
        /// <exception cref="ArgumentException">Thrown when units are not supported.</exception>
        public double Convert(double value, string fromUnit, string toUnit)
        {
            _logger.LogInformation("Converting {Value} from {FromUnit} to {ToUnit}", value, fromUnit, toUnit);

            if (!CanConvert(fromUnit, toUnit))
            {
                _logger.LogError("Unsupported power units: {FromUnit} -> {ToUnit}", fromUnit, toUnit);
                throw new ArgumentException("Unsupported power units.");
            }

            double valueInWatts = value * _toWatts[fromUnit];
            double result = valueInWatts / _toWatts[toUnit];

            _logger.LogInformation("Converted result: {Result}", result);
            return result;
        }
    }
}
