using TrickyMottram.UnitConversion.Length.Enums;
using TrickyMottram.UnitConversion.Length.Extensions;

namespace TrickyMottram.UnitConversion.Tests.Length.Extensions
{
    public class LengthUnitExtensionsTests
    {
        [Theory]
        [InlineData(LengthUnit.Meter, "m")]
        [InlineData(LengthUnit.Kilometer, "km")]
        [InlineData(LengthUnit.Foot, "ft")]
        public void ToSymbol_ValidEnum_ReturnsCorrectSymbol(LengthUnit unit, string expected)
        {
            var result = unit.ToSymbol();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("m", LengthUnit.Meter)]
        [InlineData("km", LengthUnit.Kilometer)]
        [InlineData("ft", LengthUnit.Foot)]
        public void FromSymbol_ValidSymbol_ReturnsEnum(string symbol, LengthUnit expected)
        {
            var result = LengthUnitExtensions.FromSymbol(symbol);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromSymbol_InvalidSymbol_Throws()
        {
            Assert.Throws<ArgumentException>(() => LengthUnitExtensions.FromSymbol("unknown"));
        }
    }
}