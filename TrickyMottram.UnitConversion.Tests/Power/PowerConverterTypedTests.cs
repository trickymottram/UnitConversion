using Microsoft.Extensions.Logging;
using Moq;
using TrickyMottram.UnitConversion.Power;
using TrickyMottram.UnitConversion.Power.Enums;

namespace TrickyMottram.UnitConversion.Tests.Power.Converters
{
    public class PowerConverterTypedTests
    {
        private readonly PowerConverter _converter;

        public PowerConverterTypedTests()
        {
            var logger = new Mock<ILogger<PowerConverter>>();
            _converter = new PowerConverter(logger.Object);
        }

        [Theory]
        [InlineData(1.0, PowerUnit.Watt, PowerUnit.Kilowatt, 0.001)]
        [InlineData(1.0, PowerUnit.Kilowatt, PowerUnit.Watt, 1000.0)]
        [InlineData(1.0, PowerUnit.Horsepower, PowerUnit.Watt, 745.699872)]
        [InlineData(1.0, PowerUnit.BtuPerHour, PowerUnit.Watt, 0.29307107)]
        [InlineData(1.0, PowerUnit.CaloriePerSecond, PowerUnit.Watt, 4.1868)]
        public void Convert_TypedEnums_ReturnsExpected(double input, PowerUnit from, PowerUnit to, double expected)
        {
            var result = _converter.Convert(input, from, to);
            Assert.InRange(result, expected * 0.999, expected * 1.001);
        }

        [Fact]
        public void Convert_InvalidEnum_Throws()
        {
            var invalid = (PowerUnit)999;

            Assert.Throws<ArgumentException>(() =>
                _converter.Convert(1.0, PowerUnit.Watt, invalid));
        }
    }
}