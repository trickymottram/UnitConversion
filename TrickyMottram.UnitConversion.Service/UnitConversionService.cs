using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;

namespace TrickyMottram.UnitConversion.Service
{
    /// <summary>
    /// Central service that delegates unit conversion operations to appropriate registered converters.
    /// </summary>
    public class UnitConversionService
    {
        private readonly IEnumerable<IUnitConverter> _converters;
        private readonly ILogger<UnitConversionService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitConversionService"/> class.
        /// </summary>
        /// <param name="converters">The collection of available unit converters.</param>
        /// <param name="logger">Logger instance for diagnostic output.</param>
        public UnitConversionService(IEnumerable<IUnitConverter> converters, ILogger<UnitConversionService> logger)
        {
            _converters = converters;
            _logger = logger;
        }

        /// <summary>
        /// Converts a value from one unit to another using the first matching registered converter.
        /// </summary>
        /// <param name="value">The numeric value to convert.</param>
        /// <param name="fromUnit">The source unit symbol (e.g., "kg").</param>
        /// <param name="toUnit">The destination unit symbol (e.g., "lb").</param>
        /// <returns>The converted value in the target unit.</returns>
        /// <exception cref="NotSupportedException">Thrown if no registered converter supports the given units.</exception>
        public double Convert(double value, string fromUnit, string toUnit)
        {
            var converter = _converters.FirstOrDefault(c => c.CanConvert(fromUnit, toUnit));
            if (converter == null)
            {
                _logger.LogError("No converter available for: {FromUnit} -> {ToUnit}", fromUnit, toUnit);
                throw new NotSupportedException($"Conversion from {fromUnit} to {toUnit} is not supported.");
            }

            return converter.Convert(value, fromUnit, toUnit);
        }
    }
}
