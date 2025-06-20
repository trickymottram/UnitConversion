using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Power.Enums;
using TrickyMottram.UnitConversion.Power.Extensions;

namespace TrickyMottram.UnitConversion.Power.Registry
{
    /// <summary>
    /// Provides a registry of all supported power units and their corresponding symbols.
    /// </summary>
    public class PowerUnitRegistry : IUnitRegistry
    {
        /// <summary>
        /// Gets the category name for this unit registry.
        /// </summary>
        public string Category => "Power";

        /// <summary>
        /// Retrieves a dictionary of all supported power units, mapping enum names to their unit symbols.
        /// </summary>
        /// <returns>
        /// A read-only dictionary where the keys are the <see cref="PowerUnit"/> enum names,
        /// and the values are their corresponding string symbols (e.g., <c>"Kilowatt"</c> → <c>"kw"</c>).
        /// </returns>
        public IReadOnlyDictionary<string, string> GetAllUnits()
        {
            return Enum.GetValues<PowerUnit>()
                       .Cast<PowerUnit>()
                       .ToDictionary(
                           unit => unit.ToString(),
                           unit => unit.ToSymbol(),
                           StringComparer.OrdinalIgnoreCase
                       );
        }
    }
}
