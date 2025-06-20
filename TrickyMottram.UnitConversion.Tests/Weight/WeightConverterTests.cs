using Moq;
using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Weight;

namespace TrickyMottram.UnitConversion.Tests.Weight
{
    public class WeightConverterTests
    {
        private readonly WeightConverter _converter;

        public WeightConverterTests()
        {
            var loggerMock = new Mock<ILogger<WeightConverter>>();
            _converter = new WeightConverter(loggerMock.Object);
        }

        [Theory]
        [InlineData(1_000_000.0, "mg", "kg", 1.0)]
        [InlineData(1_000.0, "g", "kg", 1.0)]
        [InlineData(2.20462, "lb", "kg", 1.0)]
        [InlineData(35.274, "oz", "kg", 1.0)]
        [InlineData(0.157473, "st", "kg", 1.0)]
        [InlineData(0.019684, "cwt", "kg", 1.0)]
        [InlineData(0.00110231, "ton", "kg", 1.0)]
        [InlineData(1.0, "us_ton", "kg", 907.18474)]
        [InlineData(1.0, "uk_ton", "kg", 1016.0469088)]
        public void Convert_KnownConversions_ReturnsExpected(double input, string fromUnit, string toUnit, double expected)
        {
            var result = _converter.Convert(input, fromUnit, toUnit);
            Assert.InRange(result, expected * 0.999, expected * 1.001);
        }

        [Fact]
        public void CanConvert_ValidUnits_ReturnsTrue()
        {
            Assert.True(_converter.CanConvert("kg", "lb"));
            Assert.True(_converter.CanConvert("oz", "g"));
        }

        [Fact]
        public void CanConvert_InvalidUnits_ReturnsFalse()
        {
            Assert.False(_converter.CanConvert("rock", "kg"));
            Assert.False(_converter.CanConvert("kg", "moon_weight"));
        }

        [Fact]
        public void Convert_InvalidUnits_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _converter.Convert(1.0, "abc", "xyz"));
        }

        [Fact]
        public void Convert_ZeroValue_ReturnsZero()
        {
            var result = _converter.Convert(0.0, "kg", "lb");
            Assert.Equal(0.0, result);
        }
    }
}
