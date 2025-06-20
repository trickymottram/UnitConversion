using TrickyMottram.UnitConversion.Abstractions.Interfaces;
using TrickyMottram.UnitConversion.Time.Enums;
using TrickyMottram.UnitConversion.Time.Extensions;

namespace TrickyMottram.UnitConversion.Time.Registry
{
    /// <summary>
    /// Provides a registry of all supported <see cref="TimeUnit"/> values and their symbolic representations.
    /// </summary>
    public class TimeUnitRegistry : IUnitRegistry
    {
        /// <summary>
        /// Gets the category name of the unit registry.
        /// </summary>
        public string Category => "Time";

        /// <summary>
        /// Returns a dictionary of all supported time units, where the key is the enum name and the value is the symbolic representation.
        /// </summary>
        /// <returns>A dictionary of time unit names and their corresponding symbols.</returns>
        public IReadOnlyDictionary<string, string> GetAllUnits()
        {
            return Enum.GetValues<TimeUnit>()
                       .Cast<TimeUnit>()
                       .ToDictionary(
                           unit => unit.ToString(),
                           unit => unit.ToSymbol(),
                           StringComparer.OrdinalIgnoreCase
                       );
        }
    }
}
