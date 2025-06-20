using TrickyMottram.UnitConversion.Abstractions.Helpers;
using TrickyMottram.UnitConversion.Area.Enums;

namespace TrickyMottram.UnitConversion.Area.Extensions
{
    /// <summary>
    /// Provides extension methods for converting between <see cref="AreaUnit"/> values and their string representations.
    /// </summary>
    public static class AreaUnitExtensions
    {
        private static readonly Dictionary<AreaUnit, string> _symbols = new()
        {
            [AreaUnit.SquareMillimeter] = "mm2",
            [AreaUnit.SquareCentimeter] = "cm2",
            [AreaUnit.SquareMeter] = "m2",
            [AreaUnit.SquareKilometer] = "km2",
            [AreaUnit.SquareInch] = "in2",
            [AreaUnit.SquareFoot] = "ft2",
            [AreaUnit.SquareYard] = "yd2",
            [AreaUnit.SquareMile] = "mi2",
            [AreaUnit.Acre] = "acre",
            [AreaUnit.Hectare] = "hectare"
        };

        /// <summary>
        /// Converts an <see cref="AreaUnit"/> to its corresponding string symbol (e.g., <c>AreaUnit.SquareMeter</c> to <c>"m2"</c>).
        /// </summary>
        /// <param name="unit">The area unit to convert.</param>
        /// <returns>The string representation of the unit.</returns>
        /// <exception cref="ArgumentException">Thrown if the unit is not supported.</exception>
        public static string ToSymbol(this AreaUnit unit) =>
            unit.ToSymbolSafe(_symbols, nameof(AreaUnit));

        /// <summary>
        /// Converts a string symbol to its corresponding <see cref="AreaUnit"/> (e.g., <c>"m2"</c> to <c>AreaUnit.SquareMeter</c>).
        /// </summary>
        /// <param name="symbol">The symbol to convert.</param>
        /// <returns>The corresponding <see cref="AreaUnit"/>.</returns>
        /// <exception cref="ArgumentException">Thrown if the symbol is not recognized.</exception>
        public static AreaUnit FromSymbol(string symbol) =>
            symbol.FromSymbolSafe(_symbols, nameof(AreaUnit));
    }
}
