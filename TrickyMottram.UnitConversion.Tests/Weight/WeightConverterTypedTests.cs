using Microsoft.Extensions.Logging;
using Moq;
using TrickyMottram.UnitConversion.Weight;
using TrickyMottram.UnitConversion.Weight.Enums;

namespace TrickyMottram.UnitConversion.Tests.Weight.Converters
{
    public class WeightConverterTypedTests
    {
        private readonly WeightConverter _converter;

        public WeightConverterTypedTests()
        {
            var logger = new Mock<ILogger<WeightConverter>>();
            _converter = new WeightConverter(logger.Object);
        }

        [Theory]
        [InlineData(1000.0, WeightUnit.Gram, WeightUnit.Kilogram, 1.0)]
        [InlineData(1.0, WeightUnit.Kilogram, WeightUnit.Gram, 1000.0)]
        [InlineData(1.0, WeightUnit.Pound, WeightUnit.Ounce, 16.0)]
        [InlineData(1.0, WeightUnit.Stone, WeightUnit.Pound, 14.0)]
        [InlineData(1.0, WeightUnit.UsTon, WeightUnit.Kilogram, 907.18474)]
        [InlineData(1.0, WeightUnit.UkTon, WeightUnit.Kilogram, 1016.0469088)]
        [InlineData(1.0, WeightUnit.Milligram, WeightUnit.Gram, 0.001)]
        public void Convert_TypedEnums_ReturnsExpected(double input, WeightUnit from, WeightUnit to, double expected)
        {
            var result = _converter.Convert(input, from, to);
            Assert.InRange(result, expected * 0.999, expected * 1.001); // Allow minor floating-point variance
        }

        [Fact]
        public void Convert_InvalidEnum_Throws()
        {
            var invalid = (WeightUnit)999;

            Assert.Throws<ArgumentException>(() =>
                _converter.Convert(1.0, WeightUnit.Kilogram, invalid));
        }
    }
}