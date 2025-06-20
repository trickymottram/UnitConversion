using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Length.Enums;
using TrickyMottram.UnitConversion.Length.Extensions;

namespace TrickyMottram.UnitConversion.Length.Registry
{
    /// <summary>
    /// Provides a registry of all supported length units and their corresponding string symbols.
    /// </summary>
    public class LengthUnitRegistry : IUnitRegistry
    {
        /// <summary>
        /// Gets the category name for this unit registry.
        /// </summary>
        public string Category => "Length";

        /// <summary>
        /// Retrieves a dictionary of all supported length units, mapping enum names to their display symbols.
        /// </summary>
        /// <returns>
        /// A read-only dictionary where the keys are the <see cref="LengthUnit"/> enum names
        /// and the values are their corresponding string symbols (e.g., "Meter" → "m").
        /// </returns>
        public IReadOnlyDictionary<string, string> GetAllUnits()
        {
            return Enum.GetValues<LengthUnit>()
                       .Cast<LengthUnit>()
                       .ToDictionary(
                           unit => unit.ToString(),
                           unit => unit.ToSymbol(),
                           StringComparer.OrdinalIgnoreCase
                       );
        }
    }
}
