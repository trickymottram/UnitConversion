using TrickyMottram.UnitConversion.Abstractions.Helpers;
using TrickyMottram.UnitConversion.Weight.Enums;

namespace TrickyMottram.UnitConversion.Weight.Extensions
{
    /// <summary>
    /// Provides extension methods for converting <see cref="WeightUnit"/> enum values to and from their symbolic representations.
    /// </summary>
    public static class WeightUnitExtensions
    {
        private static readonly Dictionary<WeightUnit, string> _symbols = new()
        {
            [WeightUnit.Milligram] = "mg",
            [WeightUnit.Gram] = "g",
            [WeightUnit.Kilogram] = "kg",
            [WeightUnit.Tonne] = "t",
            [WeightUnit.Ounce] = "oz",
            [WeightUnit.Pound] = "lb",
            [WeightUnit.Stone] = "st",
            [WeightUnit.Hundredweight] = "cwt",
            [WeightUnit.UsTon] = "us_ton",
            [WeightUnit.UkTon] = "uk_ton"
        };

        /// <summary>
        /// Converts the specified <see cref="WeightUnit"/> enum value to its symbolic string representation.
        /// </summary>
        /// <param name="unit">The weight unit to convert.</param>
        /// <returns>The symbol corresponding to the unit (e.g., "kg" for Kilogram).</returns>
        public static string ToSymbol(this WeightUnit unit) =>
            unit.ToSymbolSafe(_symbols, nameof(WeightUnit));

        /// <summary>
        /// Parses the provided unit symbol into a <see cref="WeightUnit"/> enum value.
        /// </summary>
        /// <param name="symbol">The string symbol to parse (e.g., "lb", "t").</param>
        /// <returns>The corresponding <see cref="WeightUnit"/> enum value.</returns>
        /// <exception cref="ArgumentException">Thrown when the symbol is not recognized.</exception>
        public static WeightUnit FromSymbol(string symbol) =>
            symbol.FromSymbolSafe(_symbols, nameof(WeightUnit));
    }
}
