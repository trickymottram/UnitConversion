using TrickyMottram.UnitConversion.Weight.Enums;
using TrickyMottram.UnitConversion.Weight.Extensions;

namespace TrickyMottram.UnitConversion.Tests.Weight.Extensions
{
    public class WeightUnitExtensionsTests
    {
        [Theory]
        [InlineData(WeightUnit.Milligram, "mg")]
        [InlineData(WeightUnit.Gram, "g")]
        [InlineData(WeightUnit.Kilogram, "kg")]
        [InlineData(WeightUnit.Tonne, "t")]
        [InlineData(WeightUnit.Ounce, "oz")]
        [InlineData(WeightUnit.Pound, "lb")]
        [InlineData(WeightUnit.Stone, "st")]
        [InlineData(WeightUnit.Hundredweight, "cwt")]
        [InlineData(WeightUnit.UsTon, "us_ton")]
        [InlineData(WeightUnit.UkTon, "uk_ton")]
        public void ToSymbol_ValidEnum_ReturnsCorrectSymbol(WeightUnit unit, string expected)
        {
            var result = unit.ToSymbol();
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("mg", WeightUnit.Milligram)]
        [InlineData("g", WeightUnit.Gram)]
        [InlineData("kg", WeightUnit.Kilogram)]
        [InlineData("t", WeightUnit.Tonne)]
        [InlineData("oz", WeightUnit.Ounce)]
        [InlineData("lb", WeightUnit.Pound)]
        [InlineData("st", WeightUnit.Stone)]
        [InlineData("cwt", WeightUnit.Hundredweight)]
        [InlineData("us_ton", WeightUnit.UsTon)]
        [InlineData("uk_ton", WeightUnit.UkTon)]
        public void FromSymbol_ValidSymbol_ReturnsEnum(string symbol, WeightUnit expected)
        {
            var result = WeightUnitExtensions.FromSymbol(symbol);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FromSymbol_InvalidSymbol_Throws()
        {
            Assert.Throws<ArgumentException>(() => WeightUnitExtensions.FromSymbol("invalid"));
        }
    }
}