using Moq;
using Microsoft.Extensions.Logging;
using TrickyMottram.UnitConversion.Time;

namespace TrickyMottram.UnitConversion.Tests.Time
{
    public class TimeConverterTests
    {
        private readonly TimeConverter _converter;

        public TimeConverterTests()
        {
            var loggerMock = new Mock<ILogger<TimeConverter>>();
            _converter = new TimeConverter(loggerMock.Object);
        }

        [Theory]
        [InlineData(1_000_000_000, "ns", "s", 1.0)]
        [InlineData(1_000_000, "µs", "s", 1.0)]
        [InlineData(1_000, "ms", "s", 1.0)]
        [InlineData(120.0, "s", "min", 2.0)]
        [InlineData(2.0, "h", "min", 120.0)]
        [InlineData(1.0, "d", "h", 24.0)]
        [InlineData(2.0, "wk", "d", 14.0)]
        [InlineData(1.0, "mo", "d", 30.44)] // average month
        [InlineData(1.0, "yr", "d", 365.25)] // average year
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
            Assert.True(_converter.CanConvert("min", "s"));
            Assert.True(_converter.CanConvert("h", "d"));
        }

        [Fact]
        public void CanConvert_InvalidUnits_ReturnsFalse()
        {
            Assert.False(_converter.CanConvert("moment", "second"));
            Assert.False(_converter.CanConvert("s", "aeon"));
        }

        [Fact]
        public void Convert_InvalidUnits_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _converter.Convert(1.0, "foo", "bar"));
        }

        [Fact]
        public void Convert_ZeroValue_ReturnsZero()
        {
            var result = _converter.Convert(0.0, "h", "s");
            Assert.Equal(0.0, result);
        }
    }
}