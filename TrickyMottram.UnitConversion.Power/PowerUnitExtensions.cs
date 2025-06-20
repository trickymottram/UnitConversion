using TrickyMottram.UnitConversion.Abstractions.Helpers;
using TrickyMottram.UnitConversion.Power.Enums;

namespace TrickyMottram.UnitConversion.Power.Extensions
{
    /// <summary>
    /// Provides extension methods for converting between <see cref="PowerUnit"/> values and their string symbols.
    /// </summary>
    public static class PowerUnitExtensions
    {
        private static readonly Dictionary<PowerUnit, string> _symbols = new()
        {
            [PowerUnit.Milliwatt] = "mw",
            [PowerUnit.Watt] = "w",
            [PowerUnit.Kilowatt] = "kw",
            [PowerUnit.Megawatt] = "mwatt",
            [PowerUnit.Gigawatt] = "gw",
            [PowerUnit.Horsepower] = "hp",
            [PowerUnit.BtuPerHour] = "btu/hr",
            [PowerUnit.CaloriePerSecond] = "cal/s"
        };

        /// <summary>
        /// Converts the <see cref="PowerUnit"/> enum to its corresponding unit symbol (e.g., <c>PowerUnit.Kilowatt</c> → <c>"kw"</c>).
        /// </summary>
        /// <param name="unit">The power unit enum value.</param>
        /// <returns>The string symbol representing the unit.</returns>
        /// <exception cref="ArgumentException">Thrown if the unit is not mapped to a symbol.</exception>
        public static string ToSymbol(this PowerUnit unit) =>
            unit.ToSymbolSafe(_symbols, nameof(PowerUnit));

        /// <summary>
        /// Converts a unit symbol string to its corresponding <see cref="PowerUnit"/> enum value (e.g., <c>"hp"</c> → <c>PowerUnit.Horsepower</c>).
        /// </summary>
        /// <param name="symbol">The unit symbol.</param>
        /// <returns>The matching <see cref="PowerUnit"/> enum value.</returns>
        /// <exception cref="ArgumentException">Thrown if the symbol is not recognized.</exception>
        public static PowerUnit FromSymbol(string symbol) =>
            symbol.FromSymbolSafe(_symbols, nameof(PowerUnit));
    }
}
