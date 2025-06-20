using Microsoft.Extensions.Logging;
using Moq;
using TrickyMottram.UnitConversion.Area;

namespace TrickyMottram.UnitConversion.Tests.Area
{
    public class AreaConverterTests
    {
        private readonly AreaConverter _converter;

        public AreaConverterTests()
        {
            var loggerMock = new Mock<ILogger<AreaConverter>>();
            _converter = new AreaConverter(loggerMock.Object);
        }

        [Theory]
        [InlineData(1_000_000.0, "mm2", "m2", 1.0)]
        [InlineData(10_000.0, "cm2", "m2", 1.0)]
        [InlineData(1.0, "km2", "mi2", 0.386102)]
        [InlineData(1.0, "mi2", "km2", 2.589988)]
        [InlineData(1550.0031, "in2", "m2", 1.0)]
        [InlineData(10.7639, "ft2", "m2", 1.0)]
        [InlineData(1.19599, "yd2", "m2", 1.0)]
        [InlineData(1.0, "acre", "m2", 4046.8564224)]
        [InlineData(1.0, "hectare", "m2", 10000.0)]
        public void Convert_KnownConversions_ReturnsExpected(double input, string fromUnit, string toUnit, double expected)
        {
            // Act
            var result = _converter.Convert(input, fromUnit, toUnit);

            // Assert
            Assert.InRange(result, expected * 0.999, expected * 1.001);
        }

        [Fact]
        public void CanConvert_ValidUnits_ReturnsTrue()
        {
            Assert.True(_converter.CanConvert("m2", "km2"));
            Assert.True(_converter.CanConvert("acre", "m2"));
        }

        [Fact]
        public void CanConvert_InvalidUnits_ReturnsFalse()
        {
            Assert.False(_converter.CanConvert("foo", "bar"));
            Assert.False(_converter.CanConvert("acre", "barn")); // barn = 1e-28 m² (not supported here)
        }

        [Fact]
        public void Convert_InvalidUnits_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _converter.Convert(1.0, "pixel", "m2"));
        }

        [Fact]
        public void Convert_ZeroValue_ReturnsZero()
        {
            var result = _converter.Convert(0.0, "m2", "km2");
            Assert.Equal(0.0, result);
        }
    }
}