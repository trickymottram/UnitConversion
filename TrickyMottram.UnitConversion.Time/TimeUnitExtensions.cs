using TrickyMottram.UnitConversion.Abstractions.Helpers;
using TrickyMottram.UnitConversion.Time.Enums;

namespace TrickyMottram.UnitConversion.Time.Extensions
{
    /// <summary>
    /// Provides extension methods for converting <see cref="TimeUnit"/> values to and from symbolic string representations.
    /// </summary>
    public static class TimeUnitExtensions
    {
        private static readonly Dictionary<TimeUnit, string> _symbols = new()
        {
            [TimeUnit.Nanosecond] = "ns",
            [TimeUnit.Microsecond] = "µs",
            [TimeUnit.Millisecond] = "ms",
            [TimeUnit.Second] = "s",
            [TimeUnit.Minute] = "min",
            [TimeUnit.Hour] = "h",
            [TimeUnit.Day] = "d",
            [TimeUnit.Week] = "wk",
            [TimeUnit.Month] = "mo",
            [TimeUnit.Year] = "yr"
        };

        /// <summary>
        /// Converts a <see cref="TimeUnit"/> enum value to its corresponding unit symbol.
        /// </summary>
        /// <param name="unit">The <see cref="TimeUnit"/> to convert.</param>
        /// <returns>The symbol representing the unit.</returns>
        public static string ToSymbol(this TimeUnit unit) =>
            unit.ToSymbolSafe(_symbols, nameof(TimeUnit));

        /// <summary>
        /// Converts a unit symbol to its corresponding <see cref="TimeUnit"/> enum value.
        /// </summary>
        /// <param name="symbol">The symbol to convert.</param>
        /// <returns>The corresponding <see cref="TimeUnit"/> enum value.</returns>
        /// <exception cref="ArgumentException">Thrown if the symbol is not recognized.</exception>
        public static TimeUnit FromSymbol(string symbol) =>
            symbol.FromSymbolSafe(_symbols, nameof(TimeUnit));
    }
}
