using Microsoft.Extensions.Logging;
using Moq;
using TrickyMottram.UnitConversion.Time;
using TrickyMottram.UnitConversion.Time.Enums;

namespace TrickyMottram.UnitConversion.Tests.Time.Converters
{
    public class TimeConverterTypedTests
    {
        private readonly TimeConverter _converter;

        public TimeConverterTypedTests()
        {
            var logger = new Mock<ILogger<TimeConverter>>();
            _converter = new TimeConverter(logger.Object);
        }

        [Theory]
        [InlineData(1.0, TimeUnit.Second, TimeUnit.Millisecond, 1000.0)]
        [InlineData(1.0, TimeUnit.Minute, TimeUnit.Second, 60.0)]
        [InlineData(1.0, TimeUnit.Hour, TimeUnit.Minute, 60.0)]
        [InlineData(1.0, TimeUnit.Day, TimeUnit.Hour, 24.0)]
        [InlineData(1.0, TimeUnit.Week, TimeUnit.Day, 7.0)]
        [InlineData(1.0, TimeUnit.Month, TimeUnit.Day, 30.44)]
        [InlineData(1.0, TimeUnit.Year, TimeUnit.Day, 365.25)]
        public void Convert_TypedEnums_ReturnsExpected(double input, TimeUnit from, TimeUnit to, double expected)
        {
            var result = _converter.Convert(input, from, to);
            Assert.InRange(result, expected * 0.999, expected * 1.001);
        }

        [Fact]
        public void Convert_InvalidEnum_Throws()
        {
            var invalid = (TimeUnit)999;

            Assert.Throws<ArgumentException>(() =>
                _converter.Convert(1.0, TimeUnit.Second, invalid));
        }
    }
}