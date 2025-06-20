using Microsoft.Extensions.Logging;
using Moq;
using TrickyMottram.UnitConversion.Length;

namespace TrickyMottram.UnitConversion.Tests.Length
{
    public class LengthConverterTests
    {
        private readonly LengthConverter _converter;

        public LengthConverterTests()
        {
            var loggerMock = new Mock<ILogger<LengthConverter>>();
            _converter = new LengthConverter(loggerMock.Object);
        }

        [Theory]
        [InlineData(1000.0, "mm", "m", 1.0)]
        [InlineData(100.0, "cm", "m", 1.0)]
        [InlineData(1.0, "km", "m", 1000.0)]
        [InlineData(39.3701, "in", "m", 1.0)]
        [InlineData(3.28084, "ft", "m", 1.0)]
        [InlineData(1.09361, "yd", "m", 1.0)]
        [InlineData(0.621371, "mi", "km", 1.0)]
        [InlineData(0.539957, "nm", "km", 1.0)]
        [InlineData(39370.1, "mil", "m", 1.0)]
        public void Convert_KnownValues_ReturnsExpected(double input, string fromUnit, string toUnit, double expected)
        {
            // Act
            var result = _converter.Convert(input, fromUnit, toUnit);

            // Assert
            Assert.InRange(result, expected * 0.999, expected * 1.001);
        }

        [Fact]
        public void CanConvert_ValidUnits_ReturnsTrue()
        {
            Assert.True(_converter.CanConvert("m", "km"));
            Assert.True(_converter.CanConvert("ft", "in"));
        }

        [Fact]
        public void CanConvert_InvalidUnits_ReturnsFalse()
        {
            Assert.False(_converter.CanConvert("lightyear", "m"));
            Assert.False(_converter.CanConvert("cm", "parsec"));
        }

        [Fact]
        public void Convert_InvalidUnits_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _converter.Convert(1.0, "foo", "bar"));
        }

        [Fact]
        public void Convert_ZeroValue_ReturnsZero()
        {
            var result = _converter.Convert(0.0, "m", "km");
            Assert.Equal(0.0, result);
        }
    }
}