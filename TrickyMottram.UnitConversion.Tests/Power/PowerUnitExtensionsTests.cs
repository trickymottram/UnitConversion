using TrickyMottram.UnitConversion.Power.Enums;
using TrickyMottram.UnitConversion.Power.Extensions;

namespace TrickyMottram.UnitConversion.Tests.Power.Extensions
{
    public class PowerUnitExtensionsTests
    {
        [Theory]
        [InlineData(PowerUnit.Watt, "w")]
        [InlineData(PowerUnit.Kilowatt, "kw")]
        [InlineData(PowerUnit.Horsepower, "hp")]
        [InlineData(PowerUnit.BtuPerHour, "btu/hr")]
        public void ToSymbol_ValidEnum_ReturnsCorrectSymbol(PowerUnit unit, string expected)
        {
            var result = unit.ToSymbol();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("w", PowerUnit.Watt)]
        [InlineData("kw", PowerUnit.Kilowatt)]
        [InlineData("hp", PowerUnit.Horsepower)]
        [InlineData("btu/hr", PowerUnit.BtuPerHour)]
        public void FromSymbol_ValidSymbol_ReturnsEnum(string symbol, PowerUnit expected)
        {
            var result = PowerUnitExtensions.FromSymbol(symbol);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromSymbol_InvalidSymbol_Throws()
        {
            Assert.Throws<ArgumentException>(() => PowerUnitExtensions.FromSymbol("unknown"));
        }
    }
}