using TrickyMottram.UnitConversion.Area.Enums;
using TrickyMottram.UnitConversion.Area.Extensions;
using TrickyMottram.UnitConversion.Abstractions.Interfaces;

namespace TrickyMottram.UnitConversion.Area.Registry
{
    /// <summary>
    /// Provides a registry of all supported area units and their corresponding string symbols.
    /// </summary>
    public class AreaUnitRegistry : IUnitRegistry
    {
        /// <summary>
        /// Gets the category name for this unit registry.
        /// </summary>
        public string Category => "Area";

        /// <summary>
        /// Retrieves a dictionary of all area units, mapping unit enum names to their display symbols.
        /// </summary>
        /// <returns>
        /// A read-only dictionary where the keys are <see cref="AreaUnit"/> enum names
        /// and the values are their corresponding unit symbols (e.g., "SquareMeter" → "m2").
        /// </returns>
        public IReadOnlyDictionary<string, string> GetAllUnits()
        {
            return Enum.GetValues<AreaUnit>()
                       .Cast<AreaUnit>()
                       .ToDictionary(
                           unit => unit.ToString(),
                           unit => unit.ToSymbol(),
                           StringComparer.OrdinalIgnoreCase
                       );
        }
    }
}
