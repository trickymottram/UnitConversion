using TrickyMottram.UnitConversion.Abstractions.Helpers;
using TrickyMottram.UnitConversion.Length.Enums;

namespace TrickyMottram.UnitConversion.Length.Extensions
{
    /// <summary>
    /// Provides extension methods for converting between <see cref="LengthUnit"/> values and their string representations.
    /// </summary>
    public static class LengthUnitExtensions
    {
        private static readonly Dictionary<LengthUnit, string> _symbols = new()
        {
            [LengthUnit.Millimeter] = "mm",
            [LengthUnit.Centimeter] = "cm",
            [LengthUnit.Meter] = "m",
            [LengthUnit.Kilometer] = "km",
            [LengthUnit.Inch] = "in",
            [LengthUnit.Foot] = "ft",
            [LengthUnit.Yard] = "yd",
            [LengthUnit.Mile] = "mi"
        };

        /// <summary>
        /// Converts a <see cref="LengthUnit"/> value to its corresponding string symbol (e.g., <c>LengthUnit.Meter</c> → <c>"m"</c>).
        /// </summary>
        /// <param name="unit">The length unit to convert.</param>
        /// <returns>The string symbol representing the unit.</returns>
        /// <exception cref="ArgumentException">Thrown if the unit is not supported.</exception>
        public static string ToSymbol(this LengthUnit unit) =>
            unit.ToSymbolSafe(_symbols, nameof(LengthUnit));

        /// <summary>
        /// Converts a string symbol to its corresponding <see cref="LengthUnit"/> value (e.g., <c>"ft"</c> → <c>LengthUnit.Foot</c>).
        /// </summary>
        /// <param name="symbol">The symbol to convert.</param>
        /// <returns>The corresponding <see cref="LengthUnit"/> value.</returns>
        /// <exception cref="ArgumentException">Thrown if the symbol is not recognized.</exception>
        public static LengthUnit FromSymbol(string symbol) =>
            symbol.FromSymbolSafe(_symbols, nameof(LengthUnit));
    }
}
