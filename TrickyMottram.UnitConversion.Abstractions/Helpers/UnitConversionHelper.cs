using TrickyMottram.UnitConversion.Abstractions.Interfaces;

namespace TrickyMottram.UnitConversion.Abstractions.Helpers
{
    public static class UnitConversionHelper
    {
        public static double Convert<TUnit>(
            IUnitConverter converter,
            double value,
            TUnit from,
            TUnit to,
            Func<TUnit, string> toSymbolFunc)
            where TUnit : Enum
        {
            string fromSymbol = toSymbolFunc(from);
            string toSymbol = toSymbolFunc(to);
            return converter.Convert(value, fromSymbol, toSymbol);
        }
    }
}
