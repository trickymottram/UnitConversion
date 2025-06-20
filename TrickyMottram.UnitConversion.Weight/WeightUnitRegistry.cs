using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Weight.Enums;
using TrickyMottram.UnitConversion.Weight.Extensions;

namespace TrickyMottram.UnitConversion.Weight.Registry
{
    /// <summary>
    /// Provides a registry of supported weight units and their symbolic representations.
    /// </summary>
    public class WeightUnitRegistry : IUnitRegistry
    {
        /// <summary>
        /// Gets the unit category name represented by this registry.
        /// </summary>
        public string Category => "Weight";

        /// <summary>
        /// Retrieves a dictionary mapping weight unit names to their symbolic strings.
        /// </summary>
        /// <returns>
        /// A case-insensitive dictionary where keys are enum names (e.g., "Kilogram") 
        /// and values are unit symbols (e.g., "kg").
        /// </returns>
        public IReadOnlyDictionary<string, string> GetAllUnits()
        {
            return Enum.GetValues<WeightUnit>()
                       .Cast<WeightUnit>()
                       .ToDictionary(
                           unit => unit.ToString(),
                           unit => unit.ToSymbol(),
                           StringComparer.OrdinalIgnoreCase
                       );
        }
    }
}
