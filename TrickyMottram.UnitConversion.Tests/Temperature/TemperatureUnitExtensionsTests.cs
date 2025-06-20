using TrickyMottram.UnitConversion.Temperature.Enums;
using TrickyMottram.UnitConversion.Temperature.Extensions;

namespace TrickyMottram.UnitConversion.Tests.Temperature.Extensions
{
    public class TemperatureUnitExtensionsTests
    {
        [Theory]
        [InlineData(TemperatureUnit.Celsius, "c")]
        [InlineData(TemperatureUnit.Fahrenheit, "f")]
        [InlineData(TemperatureUnit.Kelvin, "k")]
        [InlineData(TemperatureUnit.Rankine, "r")]
        [InlineData(TemperatureUnit.Reaumur, "re")]
        public void ToSymbol_ValidEnum_ReturnsCorrectSymbol(TemperatureUnit unit, string expected)
        {
            var result = unit.ToSymbol();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("c", TemperatureUnit.Celsius)]
        [InlineData("f", TemperatureUnit.Fahrenheit)]
        [InlineData("k", TemperatureUnit.Kelvin)]
        [InlineData("r", TemperatureUnit.Rankine)]
        [InlineData("re", TemperatureUnit.Reaumur)]
        public void FromSymbol_ValidSymbol_ReturnsEnum(string symbol, TemperatureUnit expected)
        {
            var result = TemperatureUnitExtensions.FromSymbol(symbol);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromSymbol_InvalidSymbol_Throws()
        {
            Assert.Throws<ArgumentException>(() => TemperatureUnitExtensions.FromSymbol("invalid"));
        }
    }
}