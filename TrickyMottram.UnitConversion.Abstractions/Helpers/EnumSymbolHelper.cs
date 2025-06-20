namespace TrickyMottram.UnitConversion.Abstractions.Helpers
{
    public static class EnumSymbolHelper
    {
        public static string ToSymbolSafe<TEnum>(
            this TEnum unit,
            Dictionary<TEnum, string> symbolMap,
            string unitName) where TEnum : struct, Enum
        {
            if (!symbolMap.TryGetValue(unit, out var symbol))
                throw new ArgumentException($"Unsupported {unitName}: {unit}");

            return symbol;
        }

        public static TEnum FromSymbolSafe<TEnum>(
            this string symbol,
            Dictionary<TEnum, string> symbolMap,
            string unitName) where TEnum : struct, Enum
        {
            var match = symbolMap.FirstOrDefault(kv =>
                kv.Value.Equals(symbol, StringComparison.OrdinalIgnoreCase));

            if (EqualityComparer<KeyValuePair<TEnum, string>>.Default.Equals(match, default))
                throw new ArgumentException($"Unsupported {unitName} symbol: {symbol}");

            return match.Key;
        }
    }
}