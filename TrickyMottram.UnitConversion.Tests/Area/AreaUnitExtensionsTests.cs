using TrickyMottram.UnitConversion.Area.Enums;
using TrickyMottram.UnitConversion.Area.Extensions;

namespace TrickyMottram.UnitConversion.Tests.Area.Extensions
{
    public class AreaUnitExtensionsTests
    {
        [Theory]
        [InlineData(AreaUnit.SquareMeter, "m2")]
        [InlineData(AreaUnit.SquareKilometer, "km2")]
        [InlineData(AreaUnit.SquareFoot, "ft2")]
        [InlineData(AreaUnit.Acre, "acre")]
        public void ToSymbol_ValidEnum_ReturnsCorrectSymbol(AreaUnit unit, string expected)
        {
            var result = unit.ToSymbol();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("m2", AreaUnit.SquareMeter)]
        [InlineData("km2", AreaUnit.SquareKilometer)]
        [InlineData("ft2", AreaUnit.SquareFoot)]
        [InlineData("acre", AreaUnit.Acre)]
        public void FromSymbol_ValidSymbol_ReturnsEnum(string symbol, AreaUnit expected)
        {
            var result = AreaUnitExtensions.FromSymbol(symbol);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromSymbol_InvalidSymbol_Throws()
        {
            Assert.Throws<ArgumentException>(() => AreaUnitExtensions.FromSymbol("unknown"));
        }
    }
}