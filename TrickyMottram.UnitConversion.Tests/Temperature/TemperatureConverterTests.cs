using Moq;
using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Temperature;

namespace TrickyMottram.UnitConversion.Tests.Temperature
{
    public class TemperatureConverterTests
    {
        private readonly TemperatureConverter _converter;

        public TemperatureConverterTests()
        {
            var loggerMock = new Mock<ILogger<TemperatureConverter>>();
            _converter = new TemperatureConverter(loggerMock.Object);
        }

        [Theory]
        [InlineData(0.0, "C", "F", 32.0)]
        [InlineData(100.0, "C", "K", 373.15)]
        [InlineData(0.0, "C", "R", 491.67)]
        [InlineData(0.0, "C", "Re", 0.0)]
        [InlineData(32.0, "F", "C", 0.0)]
        [InlineData(212.0, "F", "K", 373.15)]
        [InlineData(491.67, "R", "C", 0.0)]
        [InlineData(0.0, "Re", "C", 0.0)]
        public void Convert_KnownConversions_ReturnsExpected(double input, string fromUnit, string toUnit, double expected)
        {
            // Act
            var result = _converter.Convert(input, fromUnit, toUnit);

            // Assert (allow slight margin for floating-point math)
            Assert.InRange(result, expected * 0.999, expected * 1.001);
        }

        [Fact]
        public void CanConvert_ValidUnits_ReturnsTrue()
        {
            Assert.True(_converter.CanConvert("C", "F"));
            Assert.True(_converter.CanConvert("k", "r"));
        }

        [Fact]
        public void CanConvert_InvalidUnits_ReturnsFalse()
        {
            Assert.False(_converter.CanConvert("hot", "cold"));
            Assert.False(_converter.CanConvert("Kel", "F"));
        }

        [Fact]
        public void Convert_UnsupportedUnits_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _converter.Convert(100.0, "X", "C"));
            Assert.Throws<ArgumentException>(() => _converter.Convert(100.0, "C", "Y"));
        }

        [Fact]
        public void Convert_ZeroValue_RetainsExpectedZeroCelsius()
        {
            var result = _converter.Convert(32.0, "F", "C");
            Assert.Equal(0.0, result, precision: 1);
        }
    }
}