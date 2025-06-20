namespace TrickyMottram.UnitConversion.Abstractions.Interfaces
{
    /// <summary>
    /// Defines a general unit converter interface.
    /// </summary>
    public interface IUnitConverter
    {
        /// <summary>
        /// Converts a value from one unit to another.
        /// </summary>
        double Convert(double value, string fromUnit, string toUnit);

        /// <summary>
        /// Returns true if this converter supports the given units.
        /// </summary>
        bool CanConvert(string fromUnit, string toUnit);
    }
}