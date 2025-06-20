using TrickyMottram.UnitConversion.Abstractions.Helpers;
using TrickyMottram.UnitConversion.Temperature.Enums;

namespace TrickyMottram.UnitConversion.Temperature.Extensions
{
    /// <summary>
    /// Extension methods for working with <see cref="TemperatureUnit"/> enums and their corresponding string symbols.
    /// </summary>
    public static class TemperatureUnitExtensions
    {
        /// <summary>
        /// A mapping of <see cref="TemperatureUnit"/> enum values to their unit symbol representations.
        /// </summary>
        private static readonly Dictionary<TemperatureUnit, string> _symbols = new()
        {
            [TemperatureUnit.Celsius] = "c",
            [TemperatureUnit.Fahrenheit] = "f",
            [TemperatureUnit.Kelvin] = "k",
            [TemperatureUnit.Rankine] = "r",
            [TemperatureUnit.Reaumur] = "re"
        };

        /// <summary>
        /// Converts the <see cref="TemperatureUnit"/> enum value to its corresponding symbol (e.g., <c>TemperatureUnit.Celsius</c> → <c>"c"</c>).
        /// </summary>
        /// <param name="unit">The temperature unit enum value.</param>
        /// <returns>The corresponding string symbol.</returns>
        public static string ToSymbol(this TemperatureUnit unit) =>
            unit.ToSymbolSafe(_symbols, nameof(TemperatureUnit));

        /// <summary>
        /// Parses a unit symbol into its corresponding <see cref="TemperatureUnit"/> enum value (e.g., <c>"f"</c> → <c>TemperatureUnit.Fahrenheit</c>).
        /// </summary>
        /// <param name="symbol">The unit symbol to parse.</param>
        /// <returns>The corresponding <see cref="TemperatureUnit"/> value.</returns>
        /// <exception cref="ArgumentException">Thrown when the symbol is not recognized.</exception>
        public static TemperatureUnit FromSymbol(string symbol) =>
            symbol.FromSymbolSafe(_symbols, nameof(TemperatureUnit));
    }
}
