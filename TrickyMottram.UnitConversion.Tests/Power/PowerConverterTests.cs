using Microsoft.Extensions.Logging;
using Moq;
using TrickyMottram.UnitConversion.Power;

namespace TrickyMottram.UnitConversion.Tests.Power
{
    public class PowerConverterTests
    {
        private readonly PowerConverter _converter;

        public PowerConverterTests()
        {
            var loggerMock = new Mock<ILogger<PowerConverter>>();
            _converter = new PowerConverter(loggerMock.Object);
        }

        [Theory]
        [InlineData(1000.0, "w", "kw", 1.0)]
        [InlineData(1.0, "kw", "w", 1000.0)]
        [InlineData(0.001, "gw", "w", 1_000_000.0)]
        [InlineData(1.0, "hp", "w", 745.699872)]
        [InlineData(3412.142, "btu/hr", "kw", 1.0)]
        [InlineData(1.0, "cal/s", "w", 4.1868)]
        public void Convert_KnownConversions_ReturnsExpected(double input, string fromUnit, string toUnit, double expected)
        {
            // Act
            var result = _converter.Convert(input, fromUnit, toUnit);

            // Assert (allowing 0.1% tolerance)
            Assert.InRange(result, expected * 0.999, expected * 1.001);
        }

        [Fact]
        public void CanConvert_ValidUnits_ReturnsTrue()
        {
            Assert.True(_converter.CanConvert("kw", "w"));
            Assert.True(_converter.CanConvert("hp", "kw"));
        }

        [Fact]
        public void CanConvert_InvalidUnits_ReturnsFalse()
        {
            Assert.False(_converter.CanConvert("banana", "watts"));
        }

        [Fact]
        public void Convert_InvalidUnits_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _converter.Convert(1.0, "banana", "hp"));
        }

        [Fact]
        public void Convert_ZeroValue_ReturnsZero()
        {
            var result = _converter.Convert(0.0, "w", "kw");
            Assert.Equal(0.0, result);
        }
    }
}