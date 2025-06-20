using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Time.Enums;
using TrickyMottram.UnitConversion.Time.Extensions;

namespace TrickyMottram.UnitConversion.Time
{
    /// <summary>
    /// Provides functionality to convert between various units of time.
    /// </summary>
    public class TimeConverter : IUnitConverter
    {
        private readonly ILogger<TimeConverter> _logger;

        /// <summary>
        /// Dictionary for converting supported time units to seconds.
        /// </summary>
        private readonly Dictionary<string, double> _toSeconds = new(StringComparer.OrdinalIgnoreCase)
        {
            ["ns"] = 1e-9,
            ["µs"] = 1e-6,
            ["ms"] = 1e-3,
            ["s"] = 1.0,
            ["min"] = 60.0,
            ["h"] = 3600.0,
            ["d"] = 86400.0,
            ["wk"] = 604800.0,
            ["mo"] = 2629800.0, // average month (30.44 days)
            ["yr"] = 31557600.0 // average year (365.25 days)
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeConverter"/> class.
        /// </summary>
        /// <param name="logger">The logger used for diagnostics and tracing.</param>
        public TimeConverter(ILogger<TimeConverter> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc />
        public bool CanConvert(string fromUnit, string toUnit)
        {
            return _toSeconds.ContainsKey(fromUnit) && _toSeconds.ContainsKey(toUnit);
        }

        /// <summary>
        /// Converts a value between two time units using typed <see cref="TimeUnit"/> enums.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="from">The source time unit.</param>
        /// <param name="to">The target time unit.</param>
        /// <returns>The converted value.</returns>
        public double Convert(double value, TimeUnit from, TimeUnit to)
        {
            return Convert(value, from.ToSymbol(), to.ToSymbol());
        }

        /// <inheritdoc />
        public double Convert(double value, string fromUnit, string toUnit)
        {
            _logger.LogInformation("Converting {Value} from {FromUnit} to {ToUnit}", value, fromUnit, toUnit);

            if (!CanConvert(fromUnit, toUnit))
            {
                _logger.LogError("Unsupported time units: {FromUnit} -> {ToUnit}", fromUnit, toUnit);
                throw new ArgumentException("Unsupported time units.");
            }

            double valueInSeconds = value * _toSeconds[fromUnit];
            double result = valueInSeconds / _toSeconds[toUnit];

            _logger.LogInformation("Converted result: {Result}", result);
            return result;
        }
    }
}
