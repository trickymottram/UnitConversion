using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Temperature.Enums;
using TrickyMottram.UnitConversion.Temperature.Extensions;

namespace TrickyMottram.UnitConversion.Temperature.Registry
{
    /// <summary>
    /// Provides a registry of supported temperature units and their symbolic representations.
    /// </summary>
    public class TemperatureUnitRegistry : IUnitRegistry
    {
        /// <summary>
        /// Gets the category of units provided by this registry.
        /// </summary>
        public string Category => "Temperature";

        /// <summary>
        /// Retrieves all supported temperature units and their corresponding symbols.
        /// </summary>
        /// <returns>
        /// A dictionary mapping <see cref="TemperatureUnit"/> names to their symbolic representations.
        /// </returns>
        public IReadOnlyDictionary<string, string> GetAllUnits()
        {
            return Enum.GetValues<TemperatureUnit>()
                       .Cast<TemperatureUnit>()
                       .ToDictionary(
                           unit => unit.ToString(),
                           unit => unit.ToSymbol(),
                           StringComparer.OrdinalIgnoreCase
                       );
        }
    }
}
